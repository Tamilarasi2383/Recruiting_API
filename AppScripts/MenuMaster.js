var strTile = "";
$(document).ready(function () {
    setSession("Page", "MailMaster");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');


    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");
    $('#lblPagetitle').text("Config Tables-Menu");


    getFormData();
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        var params1 = hash[1].split("=");

        if (params1[1] == "V") {
            disableControls();
            $('#btnSave').css('display', 'none');
        }
        else if (params1[1] == "U") {
            $('#btnSave').css('display', 'block');
        }
        getMenuViewData(params[1]);
    }

    else {
        disablemenujobs();
        disablemenuvendors();
        disablemenucandidate();
    }

    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function saveMenuValue() {
    if (ValidateMenu() == true) {
        var menuaccessid = $("#hdnMenuid").val();

        var roleid = $('select#drpRole option:selected').val();
        var regionid = $('select#drpRegion option:selected').val();

        var jobaccess, jobcreation, jobedit, jobview, jobfeedback;
        if ($('input[name="chkIDjob"]:checked').val() == "on") {
            jobaccess = "1";
        }
        else {
            jobaccess = "0";
        }
        if ($('input[name="chkjobCreate"]:checked').val() == "on") {
            jobcreation = "1";
        }
        else {
            jobcreation = "0";
        }
        if ($('input[name="chkjobEdit"]:checked').val() == "on") {
            jobedit = "1";
        }
        else {
            jobedit = "0";
        }
        if ($('input[name="chkjobView"]:checked').val() == "on") {
            jobview = "1";
        }
        else {
            jobview = "0";
        }
        if ($('input[name="chkjobFeedback"]:checked').val() == "on") {
            jobfeedback = "1";
        }
        else {
            jobfeedback = "0";
        }

        var candidateaccess, candidatecreation, candidateview, candidateedit;
        if ($('input[name="chkIDcandidate"]:checked').val() == "on") {
            candidateaccess = "1";
        }
        else {
            candidateaccess = "0";
        }
        if ($('input[name="chkcandCreate"]:checked').val() == "on") {
            candidatecreation = "1";
        }
        else {
            candidatecreation = "0";
        }
        if ($('input[name="chkcandEdit"]:checked').val() == "on") {
            candidateedit = "1";
        }
        else {
            candidateedit = "0";
        }
        if ($('input[name="chkcandView"]:checked').val() == "on") {
            candidateview = "1";
        }
        else {
            candidateview = "0";
        }

        var vendoraccess, vendorcreation, vendorview, vendoredit;
        if ($('input[name="chkIDvendor"]:checked').val() == "on") {
            vendoraccess = "1";
        }
        else {
            vendoraccess = "0";
        }
        if ($('input[name="chkvendCreate"]:checked').val() == "on") {
            vendorcreation = "1";
        }
        else {
            vendorcreation = "0";
        }
        if ($('input[name="chkvendEdit"]:checked').val() == "on") {
            vendoredit = "1";
        }
        else {
            vendoredit = "0";
        }
        if ($('input[name="chkvendView"]:checked').val() == "on") {
            vendorview = "1";
        }
        else {
            vendorview = "0";
        }

        //var reportaccess;
        //if ($('input[name="chkIDvendor"]:checked').val() == "on") {
        //    reportaccess = "1";
        //}
        //else {
        //    reportaccess = "0";
        //}

        var status = "1";


        var strdata = {
            "menuaccessid": menuaccessid, "regionid": regionid, "roleid": roleid, "jobaccess": jobaccess, "jobcreation": jobcreation,
            "jobedit": jobedit, "jobview": jobview, "jobfeedback": jobfeedback,
            "candidateaccess": candidateaccess, "candidatecreation": candidatecreation,
            "candidateview": candidateview, "candidateedit": candidateedit,
            "vendoraccess": vendoraccess, "vendorcreation": vendorcreation,
            "vendorview": vendorview, "vendoredit": vendoredit, "status": status

        }

        common_api_ajax_request("api/SuperAdminMenuMaster", "ADDMENU", strdata);
    }

}

function getFormData() {

    var strdata = {};

    common_api_ajax_request("api/TargetForm", "FORMDATA", strdata);

}

function getMenuViewData(menuaccessId) {

    var strdata = { "menuaccessId": menuaccessId };

    common_api_ajax_request("api/getMenuAccess", "MENUDATA", strdata);

}


function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "FORMDATA") {

        var option1 = new Option("--Select Role--", "-1");
        /// jquerify the DOM object 'o' so we can use the html method
        $(option1).html("--Select Role--");
        $("#drpRole").append(option1);

        for (var i = 0; i < resData.lstPriority.length; i++) {
            var option = new Option(resData.lstPriority[i].Name, resData.lstPriority[i].ID);
            /// jquerify the DOM object 'o' so we can use the html method
            $(option).html(resData.lstPriority[i].Name);
            $("#drpRole").append(option);
        }

       
        var option1 = new Option("--Select Region--", "-1");
        $(option1).html("--Select Region--");
        $("#drpRegion").append(option1);

        for (var i = 0; i < resData.lstClient.length; i++) {

            var option = new Option(resData.lstClient[i].Name, resData.lstClient[i].ID);

            $(option).html(resData.lstClient[i].Name);
            $("#drpRegion").append(option);
        }
        stopLoader();
    }

    else if (key == "ADDMENU") {
        $("#div-message").text('Menu saved successfully');
        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        stopLoader();
        //stopLoader();
    }

    else if (key == "MENUDATA") {

        $("#hdnMenuid").val(resData[0].menuaccessid);
        $("#drpRole").val(resData[0].roleid).prop("selected", true);
        $("#drpRegion").val(resData[0].regionid).prop("selected", true);
        if (resData[0].jobAccess == "1") {
            $('input[name="chkIDjob"]').prop("checked", true);
            $("#lbljobAccess").text("On");
            
        }
        else {
            $('input[name="chkIDjob"]').prop("checked", false);
            $("#lbljobAccess").text("Off");
        }


        if (resData[0].jobCreation == "1") {
            $('input[name="chkjobCreate"]').prop("checked", true);
            $("#lbljobCreate").text("On");
            
        }
        else {
            $('input[name="chkjobCreate"]').prop("checked", false);
            $("#lbljobCreate").text("Off");
        }
        if (resData[0].jobEdit == "1") {
            $('input[name="chkjobEdit"]').prop("checked", true);
            $("#lbljobEdit").text("On");
            
        }
        else {
            $('input[name="chkjobEdit"]').prop("checked", false);
            $("#lbljobEdit").text("Off");
        }
        
        if (resData[0].jobView == "1") {
            $('input[name="chkjobView"]').prop("checked", true);
            $("#lbljobView").text("On");
        }
        else {
            $('input[name="chkjobView"]').prop("checked", false);
            $("#lbljobView").text("Off");
        }
        if (resData[0].jobFeedback == "1") {
            $('input[name="chkjobFeedback"]').prop("checked", true);
            $("#lbljobFeedback").text("On");
        }
        else {
            $('input[name="chkjobFeedback"]').prop("checked", false);
            $("#lbljobFeedback").text("Off");
        }


        if (resData[0].vendorAccess == "1") {
            $('input[name="chkIDvendors"]').prop("checked", true);
            $("#lblVenAccess").text("On");
            
        }
        else {
            $('input[name="chkIDvendors"]').prop("checked", false);
            $("#lblVenAccess").text("Off");
        }

        if (resData[0].vendorCreation == "1") {
            $('input[name="chkvendCreate"]').prop("checked", true);
            $("#lblvenCreate").text("On");
        }
        else {
            $('input[name="chkvendCreate"]').prop("checked", false);
            $("#lblvenCreate").text("Off");
        }
        if (resData[0].vendorEdit == "1") {
            $('input[name="chkvendEdit"]').prop("checked", true);
            $("#lblvenEdit").text("On");
        }
        else {
            $('input[name="chkvendEdit"]').prop("checked", false);
            $("#lblvenEdit").text("Off");
        }
        if (resData[0].vendorView == "1") {
            $('input[name="chkvendView"]').prop("checked", true);
            $("#lblvenView").text("On");
        }
        else {
            $('input[name="chkvendView"]').prop("checked", false);
            $("#lblvenView").text("Off");
        }

        if (resData[0].candidateAccess == "1") {
            $('input[name="chkIDcandidate"]').prop("checked", true);
            $("#lblCanAccess").text("On");
        }
        else {
            $('input[name="chkIDcandidate"]').prop("checked", false);
            $("#lblCanAccess").text("Off");
        }

        if (resData[0].candidateCreation == "1") {
            $('input[name="chkcandCreate"]').prop("checked", true);
            $("#lblCancreate").text("On");
        }
        else {
            $('input[name="chkcandCreate"]').prop("checked", false);
            $("#lblCancreate").text("Off");
        }
        if (resData[0].candidateEdit == "1") {
            $('input[name="chkcandEdit"]').prop("checked", true);
            $("#lblCanedit").text("On");
        }
        else {
            $('input[name="chkcandEdit"]').prop("checked", false);
            $("#lblCanedit").text("Off");
        }
        if (resData[0].candidateView == "1") {
            $('input[name="chkcandView"]').prop("checked", true);
            $("#lblCanview").text("On");
        }
        else {
            $('input[name="chkcandView"]').prop("checked", false);
            $("#lblCanview").text("Off");
        }

    }
}


$('#maxRows').on('change', function () {
    getPaging(5);
    //getPagination('#tblMaillist', $(this).val());
});
function createJobTable(data) {
    $("#tblMaillist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.masterid == "") {

        } else {
            strTable += "<tr>" +
                "<td>" +
                "<div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<input type='hidden' id='hdnrowid' value='" + item.masterid + "' />" +
                "<label class=text-secondary 'mb-0 text-sm h6' id='lblJobname'>" + item.masterdetaila + "</label>" +
                "</div>" +
                "</div >" +
                "</td >" +
                "<td class='align-middle text-center'>" +
                "<div class='form-check form-switch ms-1'>" +
                "<input class='form-check-input' type='checkbox' name='chkID' checked='checked' data-type='warning' data-content='Once a project is made private, you cannot revert it to a public project.' data-title='Warning' data-icon='ni ni-bell-55'>" +
                "<label class='form-check-label' for='flexSwitchCheckDefault'></label>" +
                "</div>" +
                "</td>" +
                "<td class='align-middle'>" +
                "<div class='col-lg-3 col-1 my-auto text-end'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Edit'>Edit</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Delete'>Delete</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "</tr>";
        }

    });

    $("#tblMaillist tbody").append(strTable);

}

function disableControls() {

    $('#drpRole').prop('disabled', true);
    $('#drpRegion').prop('disabled', true); 
    $('input[name="chkIDjob"]').prop('disabled', true);
    $('input[name="chkjobCreate"]').prop('disabled', true);
    $('input[name="chkjobView"]').prop('disabled', true);
    $('input[name="chkjobEdit"]').prop('disabled', true);
    $('input[name="chkjobFeedback"]').prop('disabled', true);

    $('input[name="chkIDvendors"]').prop('disabled', true);
    $('input[name="chkvendCreate"]').prop('disabled', true);
    $('input[name="chkvendEdit"]').prop('disabled', true);
    $('input[name="chkvendView"]').prop('disabled', true);

    $('input[name="chkIDcandidate"]').prop('disabled', true);
    $('input[name="chkcandCreate"]').prop('disabled', true);
    $('input[name="chkcandEdit"]').prop('disabled', true);
    $('input[name="chkcandView"]').prop('disabled', true);

}

function ValidateMenu() {
    var count = 0;
    var emptycount = 0;
    if ($("#drpRole").val() == "-1") {
        $('#drpRole').addClass("is-invalid");
        $('#drpRole').focus();
        emptycount++;
    }
    else {
        $('#drpRole').removeClass("is-invalid");
        count++;
    }


    if ($('#drpRegion').val() == "-1") {
        $('#drpRegion').addClass("is-invalid");
        $('#drpRegion').focus();
        emptycount++;
    }
    else {
        $('#drpRegion').removeClass("is-invalid");
        count++;
    }


    if (parseInt(emptycount) > 0 && parseInt(count) > 0) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}