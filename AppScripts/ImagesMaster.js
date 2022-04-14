var strTile = "";
$(document).ready(function () {
    setSession("Page", "MailMaster");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $('#lblPagetitle').text("Config Tables-Images");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");
    getImagelist();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function saveImage() {
    
    var technologyname = $("#txtAddtechnology").val();
    var status = "1";
    var path = $("#lblImageurl").text();
    var imageid = $('#hdnrowid').val();

    var strdata = {
        "technologyname": technologyname, "path": path, "imageid": imageid, "status": status
    }

    common_api_ajax_request("api/SuperAdminImageMaster", "ADDIMAGE", strdata);

}

function uploadImage() {
    var data = new FormData($('#dropBasic1')[0]);
    data.append("Images", "1");
    $.ajax({
        type: "POST",
        url: '/api/FileUpload/',    // CALL WEB API TO SAVE THE FILES.
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,         // PREVENT AUTOMATIC DATA PROCESSING.
        cache: false,
        data: data, 		        // DATA OR FILES IN THIS CONTEXT.
        success: function (data, textStatus, xhr) {
            //$('p').text(data);
            saveImage();
            $("#div-message").text('File Uploaded Successfully');
            $("#msgpopup").modal('show');
            //$("#btnOk").attr("onclick", "closepopup('0')");
            //$('#btremove1').css('display', 'block');
            //$('#btnAdd').prop('disabled', false);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
}

function getImagelist() {

    var strdata = { };

    common_api_ajax_request("api/getImagemaster", "IMAGELIST", strdata);

}



function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;

    if (key == "IMAGELIST") {
        createJobTable(resData);
        getPaging(5);
        //getPagination('#tblImagelist', 5);
        stopLoader();
    }
    else if (key == "ADDIMAGE" || key == "DELETEIMAGE" || key == "UPDATEIMAGE") {
        $("#txtAddtechnology").val("");
        $("#lblImageurl").text("");

        if (key == "ADDIMAGE") {
            $("#div-message").text('Image saved successfully');
        }
        else if (key == "DELETEIMAGE") {
            $("#div-message").text('Image deleted successfully');
        }
        else if (key == "UPDATEIMAGE") {
            $("#div-message").text('Image updated successfully');
        }

        $('#hdnrowid').val("");
        $("#hdnstatus").val("");
        
        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        getImagelist();
        getPaging(5);
        //getPagination('#tblImagelist', 5);
        stopLoader();
        //stopLoader();
    }
}


$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblImagelist', $(this).val());
});
function createJobTable(data) {
    $("#tblImagelist tbody").empty();
    var strTable = "";
    var statusTD = "";
    var i = 1;
    $.each(data, function (key, item) {

        if (item.imageid == "") {

        } else {
            if (item.status == 1) {
                statusTD = "<td class='align-middle text-left'>" +
                    "<div class='form-check form-switch ms-1'>" +
                    "<input class='form-check-input' type='checkbox' id='chkID_" + i + "' checked='checked' onclick='updateRowstatus(this)'>" +
                    "<label class='form-check-label text-success text-bold'>Active</label>" +
                    "</div>" +
                    "</td>";
            }
            else {
                statusTD = "<td class='align-middle text-left'>" +
                    "<div class='form-check form-switch ms-1'>" +
                    "<input class='form-check-input' type='checkbox' id='chkID_" + i + "' onclick='updateRowstatus(this)'>" +
                    "<label class='form-check-label text-danger text-bold'>Deactive</label>" +
                    "</div>" +
                    "</td>";
            }

            strTable += "<tr class='divControl'>" +
                "<td>" +
                "<div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblImagerowid' style='display:none;'>" + item.imageid + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblImagevalue'>" + item.technologyname + "</label>" +
                "</div>" +
                "</div >" +
                "</td >" +
                "<td>" +
                "<div class='d-flex px-2 py-1' style='white-space: pre-wrap !important;'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblImagepath'>" + item.path + "</label>" +
                "</div>" +
                "</div >" +
                "</td >" +
                statusTD +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Edit' onclick=editRow(this);>Edit</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Delete' onclick=deleteRow(this);>Delete</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "</tr>";
            i++;
        }

    });

    $("#tblImagelist tbody").append(strTable);

}

function confirmUpdate(rowid) {
    var table = $("#tblImagelist")[0];
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;
    var technologyname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    var path = table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML;
    var status = "";
    var imageid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        status = "1";
    }
    else {
        status = "0";
    }


    var strdata = {
        "technologyname": technologyname, "path": path, "imageid": imageid, "status": status
    }

    common_api_ajax_request("api/SuperAdminImageMaster", "UPDATEIMAGE", strdata);

}

function confirmDelete(rowid) {
    var table = $("#tblImagelist")[0];
    var technologyname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    var path = table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML;
    var status = "2";
    var imageid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;
    var strdata = {
        "technologyname": technologyname, "path": path, "imageid": imageid, "status": status
    }

    common_api_ajax_request("api/SuperAdminImageMaster", "DELETEIMAGE", strdata);

}

function clearSearch() {
    $('#txtSearch').val("");
    getImagelist();
}

function editRow(Expbutton) {
    var row = $(Expbutton).closest("TR");
    var rowid = row[0].rowIndex;
    var table = $("#tblImagelist")[0];

    $('#hdnrowid').val(table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML);
    $('#txtAddtechnology').val(table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML);
    $('#lblImageurl').text(table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML);

    var id = table.rows[rowid].cells[1].getElementsByTagName("input")[0].id;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        $('#hdnstatus').val("1");
    }
    else {
        $('#hdnstatus').val("0");
    }
    table.deleteRow(rowid);
    getPaging(5);
    //getPagination('#tblImagelist', 5);
}

function deleteRow(Expbutton) {
    var row = $(Expbutton).closest("TR");

    $("#div-message").text('Are you sure.Do you want to Delete?');
    $('#div_Confirm').css('display', 'block');
    $('#div_Success').css('display', 'none');
    $("#msgpopup").modal('show');

    document.getElementById("btnYes").setAttribute("onclick", "return confirmDelete(" + row[0].rowIndex + ");");
    document.getElementById("btnNo").setAttribute("onclick", "closepopup();");
}

function updateRowstatus(Expbutton) {
    var row = $(Expbutton).closest("TR");

    $("#div-message").text('Are you sure.Do you want to change the status?');
    $('#div_Confirm').css('display', 'block');
    $('#div_Success').css('display', 'none');
    $("#msgpopup").modal('show');

    document.getElementById("btnYes").setAttribute("onclick", "return confirmUpdate(" + row[0].rowIndex + ");");
    document.getElementById("btnNo").setAttribute("onclick", "return nostatus(" + row[0].rowIndex + ");");
}


function nostatus(rowid) {
    $("#msgpopup").modal('hide');

    var table = $("#tblImagelist")[0];
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        $('input[id="' + id + '"]').prop("checked", false);
    }
    else {
        $('input[id="' + id + '"]').prop("checked", true);
    }

}

function deleteFile() {
    var f1 = $('#lblImageurl').text();

    var data = new FormData($('#dropBasic1')[0]);
    data.append("Images", "1");
    data.append(f1, "file_name");
    $.ajax({
        type: "POST",
        url: '/api/FileDelete/',    // CALL WEB API TO SAVE THE FILES.
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,         // PREVENT AUTOMATIC DATA PROCESSING.
        cache: false,
        data: data, 		        // DATA OR FILES IN THIS CONTEXT.
        success: function (data, textStatus, xhr) {

            $('#lblImageurl').text("");
            $('#icon_upload').css('display', 'block');
            $('#icon_delete').css('display', 'none');
            $("#div-message").text('Resume Deleted Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
}

function removeFile() {
    $('#lblImageurl').text("Image URL");
    $('#icon_upload').css('display', 'block');
    $('#icon_delete').css('display', 'none');
}


function closepopup() {
    $("#msgpopup").modal('hide');

}