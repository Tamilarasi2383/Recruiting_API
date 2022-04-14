var strTile = "";
$(document).ready(function () {
    setSession("Page", "AddTargetMaster");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $('#lblPagetitle').text("Config Tables-Target");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");
    getFormData();
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        var params1 = hash[1].split("=");

        if (params1[1] == "V") {
            disableControls()
            $('#btnSave').css('display', 'none');
        }
        else if (params1[1] == "U") {
            $('#btnSave').css('display', 'block');
        }
        getTargetViewData(params[1]);
    }

    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function saveTargetValue() {
    if (ValidateTarget() == true) {


        var targetfixingid = $("#hdnTargetid").val();

        var RoleType = $('select#drpRole option:selected').val();
        var LevelType = $('select#drpLevel option:selected').val();
        var RegionType = $('select#drpRegion option:selected').val();

        var Submissiondaily = $("#txtcandidatedaily").val();
        var SubmissiontoTLdaily = $("#txttldaily").val();
        var SubmissiontoBPdaily = $("#txtbpdaily").val();
        var Closuredaily = $("#txtclosuredaily").val();
        var Vendorsdaily = $("#txtvendordaily").val() != "" ? $("#txtvendordaily").val():"0";

        var Submissionweekly = $("#txtcandidateweekly").val();
        var SubmissiontoTLweekly = $("#txttlweekly").val();
        var SubmissiontoBPweekly = $("#txtbpweekly").val();
        var Closureweekly = $("#txtclosureweekly").val();
        var Vendorsweekly = $("#txtvendorweekly").val() != "" ? $("#txtvendorweekly").val():"0";

        var Submissionmonthly = $("#txtcandidatemonthly").val();
        var SubmissiontoTLmonthly = $("#txttlmonthly").val();
        var SubmissiontoBPmonthly = $("#txtbpmonthly").val();
        var Closuremonthly = $("#txtclosuremonthly").val();
        var Vendorsmonthly = $("#txtvendormonthly").val() != "" ? $("#txtvendormonthly").val():"0";


        var strdata = {
            "LevelType": LevelType, "RegionType": RegionType, "RoleType": RoleType, "targetfixingid": targetfixingid,
            "Submissiondaily": Submissiondaily, "SubmissiontoTLdaily": SubmissiontoTLdaily,
            "SubmissiontoBPdaily": SubmissiontoBPdaily, "Closuredaily": Closuredaily,
            "Vendorsdaily": Vendorsdaily, "Submissionweekly": Submissionweekly, "SubmissiontoTLweekly": SubmissiontoTLweekly,
            "SubmissiontoBPweekly": SubmissiontoBPweekly, "Closureweekly": Closureweekly, "Vendorsweekly": Vendorsweekly,
            "Submissionmonthly": Submissionmonthly, "SubmissiontoTLmonthly": SubmissiontoTLmonthly,
            "SubmissiontoBPmonthly": SubmissiontoBPmonthly, "Closuremonthly": Closuremonthly,
            "Vendorsmonthly": Vendorsmonthly
        }

        common_api_ajax_request("api/SuperAdminTargetfixing", "ADDTARGET", strdata);
    }

}

function getFormData() {

    var strdata = {};

    common_api_ajax_request("api/TargetForm", "FORMDATA", strdata);

}

function getTargetViewData(targetfixingid) {

    var strdata = { "targetfixingid": targetfixingid };

    common_api_ajax_request("api/getTargetfixingid", "TARGETDATA", strdata);

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

        var option1 = new Option("--Select Level--", "-1");
        $(option1).html("--Select Level--");
        $("#drpLevel").append(option1);

        for (var i = 0; i < resData.lstCurrency.length; i++) {

            var option = new Option(resData.lstCurrency[i].Name, resData.lstCurrency[i].ID);

            $(option).html(resData.lstCurrency[i].Name);
            $("#drpLevel").append(option);
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

    else if (key == "ADDTARGET") {
        $("#div-message").text('Target saved successfully');
        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        stopLoader();
        //stopLoader();
    }

    else if (key == "TARGETDATA") {

        $("#hdnTargetid").val(resData[0].TargetfixingId);
        $("#drpRole").val(resData[0].RoleType).prop("selected", true);
        $("#drpLevel").val(resData[0].LevelType).prop("selected", true);
        $("#drpRegion").val(resData[0].RegionType).prop("selected", true);
        $("#txtcandidatedaily").val(resData[0].Submission_Daily);
        $("#txttldaily").val(resData[0].SubmissiontoTL_Daily);
        $("#txtbpdaily").val(resData[0].SubmissiontoBP_Daily);
        $("#txtclosuredaily").val(resData[0].Closure_Daily);
        $("#txtvendordaily").val(resData[0].Vendor_Daily);

        $("#txtcandidateweekly").val(resData[0].Submission_Weekly);
        $("#txttlweekly").val(resData[0].SubmissiontoTL_Weekly);
        $("#txtbpweekly").val(resData[0].SubmissiontoBP_Weekly);
        $("#txtclosureweekly").val(resData[0].Closure_Weekly);
        $("#txtvendorweekly").val(resData[0].Vendor_Weekly);

        $("#txtcandidatemonthly").val(resData[0].Submission_Monthly);
        $("#txttlmonthly").val(resData[0].SubmissiontoTL_Monthly);
        $("#txtbpmonthly").val(resData[0].SubmissiontoBP_Monthly);
        $("#txtclosuremonthly").val(resData[0].Closure_Monthly);
        $("#txtvendormonthly").val(resData[0].Vendor_Monthly);

    }
}


$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblMaillist', $(this).val());
});
function createJobTable(data) {
    $("#tblMaillist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.masterid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
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


function ValidateTarget() {
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

    if ($('#drpLevel').val() == "-1") {
        $("#drpLevel").addClass("is-invalid");
        $('#drpLevel').focus();

        emptycount++;
    }
    else {
        $("#drpLevel").removeClass("is-invalid");
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

    if ($('#txtcandidatedaily').val() == "") {
        $('#txtcandidatedaily').addClass("is-invalid");
        $('#txtcandidatedaily').focus();
        emptycount++;
    }
    else {
        $('#txtcandidatedaily').removeClass("is-invalid");
        count++;
    }

    if ($('#txttldaily').val() == "") {
        $('#txttldaily').addClass("is-invalid");
        $('#txttldaily').focus();
        emptycount++;
    }
    else {
        $('#txttldaily').removeClass("is-invalid");
        count++;
    }

    if ($('#txtbpdaily').val() == "") {
        $('#txtbpdaily').addClass("is-invalid");
        $('#txtbpdaily').focus();
        emptycount++;
    }
    else {
        $('#txtbpdaily').removeClass("is-invalid");
        count++;
    }

    if ($('#txtclosuredaily').val() == "") {
        $('#txtclosuredaily').addClass("is-invalid");
        $('#txtclosuredaily').focus();
        emptycount++;
    }
    else {
        $('#txtclosuredaily').removeClass("is-invalid");
        count++;
    }

    if ($('select#drpRegion option:selected').val() == "2001") { 

    if ($('#txtvendordaily').val() == "") {
        $('#txtvendordaily').addClass("is-invalid");
        $('#txtvendordaily').focus();
        emptycount++;
    }
    else {
        $('#txtvendordaily').removeClass("is-invalid");
        count++;
        }
    }


    if ($('#txtcandidateweekly').val() == "") {
        $('#txtcandidateweekly').addClass("is-invalid");
        $('#txtcandidateweekly').focus();
        emptycount++;
    }
    else {
        $('#txtcandidateweekly').removeClass("is-invalid");
        count++;
    }

    if ($('#txttlweekly').val() == "") {
        $('#txttlweekly').addClass("is-invalid");
        $('#txttlweekly').focus();
        emptycount++;
    }
    else {
        $('#txttlweekly').removeClass("is-invalid");
        count++;
    }

    if ($('#txtbpweekly').val() == "") {
        $('#txtbpweekly').addClass("is-invalid");
        $('#txtbpweekly').focus();
        emptycount++;
    }
    else {
        $('#txtbpweekly').removeClass("is-invalid");
        count++;
    }

    if ($('#txtclosureweekly').val() == "") {
        $('#txtclosureweekly').addClass("is-invalid");
        $('#txtclosureweekly').focus();
        emptycount++;
    }
    else {
        $('#txtclosureweekly').removeClass("is-invalid");
        count++;
    }

    if ($('select#drpRegion option:selected').val() == "2001") {

        if ($('#txtvendorweekly').val() == "") {
            $('#txtvendorweekly').addClass("is-invalid");
            $('#txtvendorweekly').focus();
            emptycount++;
        }
        else {
            $('#txtvendorweekly').removeClass("is-invalid");
            count++;
        }
    }


    if ($('#txtcandidatemonthly').val() == "") {
        $('#txtcandidatemonthly').addClass("is-invalid");
        $('#txtcandidatemonthly').focus();
        emptycount++;
    }
    else {
        $('#txtcandidatemonthly').removeClass("is-invalid");
        count++;
    }

    if ($('#txttlmonthly').val() == "") {
        $('#txttlmonthly').addClass("is-invalid");
        $('#txttlmonthly').focus();
        emptycount++;
    }
    else {
        $('#txttlmonthly').removeClass("is-invalid");
        count++;
    }

    if ($('#txtbpmonthly').val() == "") {
        $('#txtbpmonthly').addClass("is-invalid");
        $('#txtbpmonthly').focus();
        emptycount++;
    }
    else {
        $('#txtbpmonthly').removeClass("is-invalid");
        count++;
    }

    if ($('#txtclosuremonthly').val() == "") {
        $('#txtclosuremonthly').addClass("is-invalid");
        $('#txtclosuremonthly').focus();
        emptycount++;
    }
    else {
        $('#txtclosuremonthly').removeClass("is-invalid");
        count++;
    }

    if ($('select#drpRegion option:selected').val() == "2001") {

        if ($('#txtvendormonthly').val() == "") {
            $('#txtvendormonthly').addClass("is-invalid");
            $('#txtvendormonthly').focus();
            emptycount++;
        }
        else {
            $('#txtvendormonthly').removeClass("is-invalid");
            count++;
        }
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}


function disableControls() {

    $('#drpRole').prop('disabled', true);
    $('#drpLevel').prop('disabled', true);
    $('#drpRegion').prop('disabled', true);
    $('#txtCandidates').prop('disabled', true);
    $('#txtSubmissiontotl').prop('disabled', true);
    $('#txtTlapproval').prop('disabled', true);
    $('#txtBpapproval').prop('disabled', true);
    $('#txtEcapproval').prop('disabled', true);
    $('#txtVendors').prop('disabled', true);

}

function regionChange() {
    if ($('select#drpRegion option:selected').val() == "2001") {        
        $('#th_target').css('display', 'block');
        $('#td_daily').css('display', 'block');
        $('#td_week').css('display', 'block');
        $('#td_month').css('display', 'block');
    }
    else {
        $('#th_target').css('display', 'none');
        $('#td_daily').css('display', 'none');
        $('#td_week').css('display', 'none');
        $('#td_month').css('display', 'none');
    }
    
}