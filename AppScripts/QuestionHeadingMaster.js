$(document).ready(function () {
    setSession("Page", "RegionMaster");

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
    $('#lblPagetitle').text("Config Tables-Region");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");
    getQuestionHeadinglist("");
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});




function Validatequeshead() {
    var count = 0;
    var emptycount = 0;
    if ($('#txtaddtablename').val() == "") {
        $('#txtaddtablename').addClass("is-invalid");
        $('#txtaddtablename').focus();
        emptycount++;
    }
    else {
        $('#txtaddtablename').removeClass("is-invalid");
        count++;
    }

    if ($('#txtoutof').val() == "") {
        $('#txtoutof').addClass("is-invalid");
        $('#txtoutof').focus();
        emptycount++;
    }
    else {
        $('#txtoutof').removeClass("is-invalid");
        count++;
    }

    if ($('#drpregion').val() == "-1") {
        $('#drpregion').addClass("is-invalid");
        $('#drpregion').focus();
        emptycount++;
    }
    else {
        $('#drpregion').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function savequeshead() {

    if (Validatequeshead() == true) {

        var obj = {};
        obj.QuestionHeadingname = $("#txtaddtablename").val();
        obj.OutofMark = $("#txtoutof").val();
        obj.Regionid = $('select#drpregion option:selected').val();
      
        if ($('#hdnrowid').val() == "") {
            obj.QuestionHeadingid = "";
            obj.Status = "1";
        }
        else {
            obj.QuestionHeadingid = $('#hdnrowid').val();
            obj.Status = $("#hdnstatus").val();
        }


        var strdata = {
            "question": obj
        }

        common_api_ajax_request("api/QuestionHeading", "ADDQuestionHeadingID", strdata);
    }

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "QUESTIONLIST") {
        $("#drpregion").empty();
        var option1 = new Option("--Select Region--", "-1");
        $(option1).html("--Select Region--");
        $("#drpregion").append(option1);

        for (var i = 0; i < resData.lstRegion.length; i++) {

            var option = new Option(resData.lstRegion[i].Name, resData.lstRegion[i].ID);

            $(option).html(resData.lstRegion[i].Name);
            $("#drpregion").append(option);
        }

        createTable(resData.questionheadings);
        getPaging(5);
        //getPagination('#tblCreation', 5);
        stopLoader();
    }

    else if (key == "ADDQuestionHeadingID" || key == "DELETEQuestionHeadingID" || key == "UPDATEQuestionHeadingID") {
        $("#txtaddtablename").val("");
        $("#txtoutof").val("");
        if (key == "ADDQuestionHeadingID") {
            $("#div-message").text('Question Heading saved successfully');
        }
        else if (key == "DELETEQuestionHeadingID") {
            $("#div-message").text('Question Heading deleted successfully');
        }
        else if (key == "UPDATEQuestionHeadingID") {
            $("#div-message").text('Question Heading status updated successfully');
        }

        $('#hdnrowid').val("");
        $("#hdnstatus").val("");

        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        getQuestionHeadinglist("");
        stopLoader();
    }


}


function createTable(data) {
    $("#tblCreation tbody").empty();
    var strTable = "";
    var statusTD = "";
    var i = 1;
    $.each(data, function (key, item) {
        
        if (item.QuestionHeadingid == "") {

        } else {
            if (item.Status == 1) {
               
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
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblQuestionrowid' style='display:none;'>" + item.QuestionHeadingid + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblQuestionvalue'>" + item.QuestionHeadingname + "</label>" +
                "</div>" +
                "</div >" +
                "</td >" +
                "<td style='display:none;'>" +
                "<div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblQuestionoutof' style='display:none;'>" + item.OutofMark + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblQuestionregion'  style='display:none;'>" + item.Regionid + "</label>" +
                "</div>" +
                "</div>" +
                "</td>" +
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

function getQuestionHeadinglist(val) {

    var strdata = { "id": val };

    common_api_ajax_request("api/QuestionHeadingdetails", "QUESTIONLIST", strdata);

}


function editRow(Expbutton) {
    var row = $(Expbutton).closest("TR");
    var rowid = row[0].rowIndex;
    var table = $("#tblCreation")[0];

    $('#hdnrowid').val(table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML);
    $('#txtaddtablename').val(table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML);
    $('#txtoutof').val(table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML);
    $("#drpregion").val(table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML).prop("selected", true);

    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;

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
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;

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

function confirmUpdate(rowid) {
    var table = $("#tblCreation")[0];
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;
    var obj = {};
    obj.QuestionHeadingid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML; 
    obj.QuestionHeadingname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML; 
    obj.OutofMark = table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML; 
    obj.Regionid = table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML; 

    var strdata = {
        "question": obj
    }       

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        obj.Status = "1";
    }
    else {
        obj.Status = "0";
    }
    common_api_ajax_request("api/QuestionHeading", "UPDATEQuestionHeadingID", strdata);

}

function confirmDelete(rowid) {
    var table = $("#tblCreation")[0];
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;
    var obj = {};
    obj.QuestionHeadingid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;
    obj.QuestionHeadingname = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    obj.OutofMark = table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML;
    obj.Regionid = table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML;
    obj.Status = "2";

    var strdata = {
        "question": obj
    }

    common_api_ajax_request("api/QuestionHeading", "UPDATEQuestionHeadingID", strdata);
}