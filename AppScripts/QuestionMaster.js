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
    getQuestionlist("");
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function getTotalmarks() {
   
    if ($('select#drptablename option:selected').val() != "-1") {
        var strdata = {
            "QuestionHeadingid": $('select#drptablename option:selected').val()
        }

        common_api_ajax_request("api/SuperAdminTotalCalculation", "TotalMarks", strdata);
    }
   

}

function savequestion() {

    if (Validatefield() == true) {

        var obj = {};
        obj.QuestionHeadingid = $('select#drptablename option:selected').val(); 
        obj.Question = $("#txtquestion").val();
        obj.Mark = $("#txtmark").val();
        obj.Answer = $('select#drpanswer option:selected').val(); 

        if ($('#hdnrowid').val() == "") {
            obj.Questionid = "";
            obj.Status = "1";
        }
        else {
            obj.Questionid = $('#hdnrowid').val();
            obj.Status = $("#hdnstatus").val();
        }


        var strdata = {
            "question": obj
        }

        common_api_ajax_request("api/SuperAdminQueHeadingMaster", "ADDQuestion", strdata);
    }

}


function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "QUESTIONLIST") {
        $("#drptablename").empty();
        var option1 = new Option("--Select Table Name--", "-1");
        $(option1).html("--Select Table Name--");
        $("#drptablename").append(option1);

        for (var i = 0; i < resData.lstquestionTable.length; i++) {

            var option = new Option(resData.lstquestionTable[i].Name, resData.lstquestionTable[i].ID);

            $(option).html(resData.lstquestionTable[i].Name);
            $("#drptablename").append(option);
        }

        $("#drpanswer").empty();
        var option1 = new Option("--Select Answer--", "-1");
        $(option1).html("--Select Answer--");
        $("#drpanswer").append(option1);

        for (var i = 0; i < resData.lstanswer.length; i++) {

            var option = new Option(resData.lstanswer[i].Name, resData.lstanswer[i].ID);

            $(option).html(resData.lstanswer[i].Name);
            $("#drpanswer").append(option);
        }

               

        createTable(resData.question);
        //getPaging(5);
        //getPagination('#tblCreation', 5);
        //stopLoader();
    }

    else if (key == "ADDQuestion" || key == "DELETEQuestion" || key == "UPDATEQuestion") {
        $("#txtquestion").val("");
        $("#txtmark").val("");
        $('#div_total').css('display', 'none');
        if (key == "ADDQuestion") {
            $("#div-message").text('Question saved successfully');
        }
        else if (key == "DELETEQuestion") {
            $("#div-message").text('Question deleted successfully');
        }
        else if (key == "UPDATEQuestion") {
            $("#div-message").text('Question status updated successfully');
        }

        $('#hdnrowid').val("");
        $("#hdnstatus").val("");

        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        getQuestionlist("");
        stopLoader();
    }

    else if (key == "TotalMarks") {
        var tbl = resData.split('|');
        $("#lbltotalmark").text(tbl[0]);
        $("#lbloutofmark").text(tbl[1]);

        $('#div_total').css('display', 'block');
        
        stopLoader();
    }


}

function calculateMark() {
    if ((parseInt($("#lbltotalmark").text()) + parseInt($("#txtmark").val())) > parseInt($("#lbloutofmark").text())) {
        $("#div-message").text('Total Marks has Exceeded');
        $('#div_Success').css('display', 'block');
        $("#msgpopup").modal('show');

       
    }
    //else {
        
    //    var mark = parseInt($("#lbloutofmark").text()) - (parseInt($("#lbltotalmark").text()) + parseInt($("#txtmark").val()));        
    //    $("#div-message").text('You can add more ' + mark +" marks to the selected Table heading");
    //}
    
}


function createTable(data) {

    $("#tblCreation tbody").empty();
    var strTable = "";
    var statusTD = "";
    var i = 1;
    $.each(data, function (key, item) {

        if (item.Questionid == "") {

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
                "<label class='text-secondary mb-0 text-sm h6' id='lblQuestionrowid' style='display:none;'>" + item.Questionid + "</label>" +
                "<label class='text-secondary mb-0 text-sm h6' id='lblQuestiontableid' style='display:none;'>" + item.QuestionHeadingid + "</label>" +
                "<label class='text-secondary mb-0 text-sm h6' id='lblQuestionvalue' style='white-space: break-spaces;'>" + item.Question + "</label>" +
                "</div>" +
                "</div >" +
                "</td >" +
                "<td>" +
                "<div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblAnswer'>" + item.Answer + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblAnswerid' style='display:none;'>" + item.Answerid + "</label>" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblMark'  style='display:none;'>" + item.Mark + "</label>" +
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
function Validatefield() {
    var count = 0;
    var emptycount = 0;
    if ($('#drptablename').val() == "-1") {
        $('#drptablename').addClass("is-invalid");
        $('#drptablename').focus();
        emptycount++;
    }
    else {
        $('#drptablename').removeClass("is-invalid");
        count++;
    }

    if ($('#drpanswer').val() == "-1") {
        $('#drpanswer').addClass("is-invalid");
        $('#drpanswer').focus();
        emptycount++;
    }
    else {
        $('#drpanswer').removeClass("is-invalid");
        count++;
    }

    if ($('#txtmark').val() == "") {
        $('#txtmark').addClass("is-invalid");
        $('#txtmark').focus();
        emptycount++;
    }
    else {
        $('#txtmark').removeClass("is-invalid");
        count++;
    }

    if ($('#txtquestion').val() == "") {
        $('#txtquestion').addClass("is-invalid");
        $('#txtquestion').focus();
        emptycount++;
    }
    else {
        $('#txtquestion').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}


function getQuestionlist(val) {

    var strdata = { "id": val };

    common_api_ajax_request("api/Questiondetails", "QUESTIONLIST", strdata);

}


function editRow(Expbutton) {
    var row = $(Expbutton).closest("TR");
    var rowid = row[0].rowIndex;
    var table = $("#tblCreation")[0];

    $('#hdnrowid').val(table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML);
    $("#drptablename").val(table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML).prop("selected", true);
    $('#txtquestion').val(table.rows[rowid].cells[0].getElementsByTagName("label")[2].innerHTML);

    $("#drpanswer").val(table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML).prop("selected", true);
    $('#txtmark').val(table.rows[rowid].cells[1].getElementsByTagName("label")[2].innerHTML);

    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;

    if ($('input[id="' + id + '"]:checked').val() == "on") {
        $('#hdnstatus').val("1");
    }
    else {
        $('#hdnstatus').val("0");
    }
    table.deleteRow(rowid);
    getTotalmarks();
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

//function confirmUpdate(rowid) {
//    var table = $("#tblCreation")[0];
//    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;
//    var obj = {};
//    obj.QuestionHeadingid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;
//    obj.Question = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
//    obj.Mark = table.rows[rowid].cells[1].getElementsByTagName("label")[0].innerHTML;
//    obj.Answer  = table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML;

//    var strdata = {
//        "question": obj
//    }

//    if ($('input[id="' + id + '"]:checked').val() == "on") {
//        obj.Status = "1";
//    }
//    else {
//        obj.Status = "0";
//    }
//    common_api_ajax_request("api/QuestionHeading", "UPDATEQuestion", strdata);

//}

function confirmDelete(rowid) {
    var table = $("#tblCreation")[0];
    var id = table.rows[rowid].cells[2].getElementsByTagName("input")[0].id;
    var obj = {};
    obj.Questionid = table.rows[rowid].cells[0].getElementsByTagName("label")[0].innerHTML;
    obj.QuestionHeadingid  = table.rows[rowid].cells[0].getElementsByTagName("label")[1].innerHTML;
    obj.Question = table.rows[rowid].cells[0].getElementsByTagName("label")[2].innerHTML;
    obj.Mark = table.rows[rowid].cells[1].getElementsByTagName("label")[2].innerHTML;
    obj.Answer = table.rows[rowid].cells[1].getElementsByTagName("label")[1].innerHTML;
    obj.Status = "2";

    var strdata = {
        "question": obj
    }

    common_api_ajax_request("api/SuperAdminQueHeadingMaster", "DELETEQuestion", strdata);
}

