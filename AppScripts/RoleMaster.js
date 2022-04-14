var strTile = "";
$(document).ready(function () {
    setSession("Page", "RoleMaster");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Config Tables-Role");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");

    getRoleidlist();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function saveRolenid() {

    if (ValidateRoleid() == true) {
        var fieldname = $("#txtAddrole").val();
        var status = "";
        var mastertype = "Role";
        var mode = "";
        var rowid = "";
        if ($('#hdnrowid').val() == "") {
            mode = "I";
            status = "1";
        }
        else {
            mode = "U";
            rowid = $('#hdnrowid').val();
            status = $("#hdnstatus").val();
        }


        var strdata = {
            "fieldname": fieldname, "status": status, "mastertype": mastertype, "mode": mode, "rowid": rowid
        }

        common_api_ajax_request("api/Masterinsert", "ADDROLEID", strdata);
    }

}

function confirmUpdate(rowid) {
    var table = $("#tblCreation")[0];
    var id = table.rows[rowid].cells[1].getElementsByTagName("input")[0].id;
    var fieldname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    var status = "";
    var mastertype = "Role";
    var mode = "U";
    var rowid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        status = "1";
    }
    else {
        status = "0";
    }

    var strdata = {
        "fieldname": fieldname, "status": status, "mastertype": mastertype, "mode": mode, "rowid": rowid
    }

    common_api_ajax_request("api/Masterinsert", "UPDATEROLEID", strdata);

}

function confirmDelete(rowid) {
    var table = $("#tblCreation")[0];
    var fieldname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    var status = "2";
    var mastertype = "Role";
    var mode = "D";
    var rowid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;
    var strdata = {
        "fieldname": fieldname, "status": status, "mastertype": mastertype, "mode": mode, "rowid": rowid
    }

    common_api_ajax_request("api/Masterinsert", "DELETEROLEID", strdata);

}


function getRoleidlist() {

    var strdata = { "mastertype": "Role" };

    common_api_ajax_request("api/Masterview", "ROLELIST", strdata);

}



function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "ROLELIST") {

        createJobTable(resData);
        getPaging(5);
        //getPagination('#tblCreation', 5);
        stopLoader();
    }

    else if (key == "ADDROLEID" || key == "DELETEROLEID" || key == "UPDATEROLEID") {
        $("#txtAddrole").val("");
        if (key == "ADDROLEID") {
            $("#div-message").text('Role saved successfully');
        }
        else if (key == "DELETEROLEID") {
            $("#div-message").text('Role deleted successfully');
        }
        else if (key == "UPDATEROLEID") {
            $("#div-message").text('Role status updated successfully');
        }

        $('#hdnrowid').val("");
        $("#hdnstatus").val("");

        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        getRoleidlist();
        stopLoader();
    }


}


$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblCreation', $(this).val());
});
function createJobTable(data) {
    $("#tblCreation tbody").empty();
    var strTable = "";
    var statusTD = "";
    var i = 1;
    $.each(data, function (key, item) {

        if (item.masterid == "") {

        } else {
            if (item.masterstatus == 1) {
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
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblRolerowid' style='display:none;'>" + item.masterid + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblRolevalue'>" + item.mastername + "</label>" +
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

    $("#tblCreation tbody").append(strTable);

}

function ValidateRoleid() {
    var count = 0;
    var emptycount = 0;
    if ($('#txtAddrole').val() == "") {
        $('#txtAddrole').addClass("is-invalid");
        $('#txtAddrole').focus();
        emptycount++;
    }
    else {
        $('#txtAddrole').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function clearSearch() {
    $('#txtSearch').val("");
    getRoleidlist();
}

function editRow(Expbutton) {
    var row = $(Expbutton).closest("TR");
    var rowid = row[0].rowIndex;
    var table = $("#tblCreation")[0];

    $('#hdnrowid').val(table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML);
    $('#txtAddrole').val(table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML);

    var id = table.rows[rowid].cells[1].getElementsByTagName("input")[0].id;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        $('#hdnstatus').val("1");
    }
    else {
        $('#hdnstatus').val("0");
    }
    table.deleteRow(rowid);
    getPaging(5);
    //getPagination('#tblCreation', 5);
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

    var table = $("#tblCreation")[0];
    var id = table.rows[rowid].cells[1].getElementsByTagName("input")[0].id;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        $('input[id="' + id + '"]').prop("checked", false);
    }
    else {
        $('input[id="' + id + '"]').prop("checked", true);
    }

}


function closepopup() {
    $("#msgpopup").modal('hide');

}