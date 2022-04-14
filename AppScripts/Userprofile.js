$(document).ready(function () {
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $('#lblPagetitle').text("Users");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").addClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").removeClass("active");

    getFormData();

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        var params1 = hash[1].split("=");

        getManagerData();
        getUserViewData(params[1]);

        if (params1[1] == "V") {
            $('#btnSave').css('display', 'none');
            disableControls();

        }
        else if (params1[1] == "U") {
            $('#btnSave').css('display', 'block');
        }
        
    }

});

function getUserViewData(Userid) {

    var strdata = { "Userid": Userid };

    common_api_ajax_request("api/ViewUserProfile", "USERDATA", strdata);

}


function getFormData() {

    common_api_ajax_request("api/Drplist", "Drplist", "");
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}

function getManagerData() {

    common_api_ajax_request("api/DrpManagerlist", "DrpManagerlist", "");
    getRolebasemenu();
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}


function getTargetData() {

    var strdata = {
        "roletype": $('select#drpRole option:selected').val(), "leveltype": $('select#drpLevel option:selected').val(), "region": $('select#drpRegion option:selected').val()
    };

    common_api_ajax_request("api/Targetfixing", "Targetfixing", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}

function getRolebasemenu() {

    var strdata = {
        "roletype": $('select#drpRole option:selected').val()
    };

    common_api_ajax_request("api/RoleMenu", "RoleMenu", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "Drplist") {

        var option1 = new Option("--Select Designation--", "-1");
        /// jquerify the DOM object 'o' so we can use the html method
        $(option1).html("--Select Designation--");
        $("#drpDesignation").append(option1);

        for (var i = 0; i < resData.Designation.length; i++) {
            var option = new Option(resData.Designation[i].drpname, resData.Designation[i].drpid);
            /// jquerify the DOM object 'o' so we can use the html method
            $(option).html(resData.Designation[i].drpname);
            $("#drpDesignation").append(option);
        }


        var option1 = new Option("--Select Gender--", "-1");
        $(option1).html("--Select Gender--");
        $("#drpGender").append(option1);

        for (var i = 0; i < resData.Gender.length; i++) {

            var option = new Option(resData.Gender[i].drpname, resData.Gender[i].drpid);

            $(option).html(resData.Gender[i].drpname);
            $("#drpGender").append(option);
        }

        var option1 = new Option("--Select Role--", "-1");
        $(option1).html("--Select Role--");
        $("#drpRole").append(option1);

        for (var i = 0; i < resData.Role.length; i++) {

            var option = new Option(resData.Role[i].drpname, resData.Role[i].drpid);

            $(option).html(resData.Role[i].Name);
            $("#drpRole").append(option);
        }


        var option1 = new Option("--Select Level--", "-1");
        $(option1).html("--Select Level--");
        $("#drpLevel").append(option1);

        for (var i = 0; i < resData.Level.length; i++) {

            var option = new Option(resData.Level[i].drpname, resData.Level[i].drpid);

            $(option).html(resData.Level[i].drpname);
            $("#drpLevel").append(option);
        }

        var option1 = new Option("--Select Language--", "-1");
        $(option1).html("--Select Language--");
        $("#drpLanguage").append(option1);

        for (var i = 0; i < resData.Language.length; i++) {

            var option = new Option(resData.Language[i].drpname, resData.Language[i].drpid);

            $(option).html(resData.Language[i].drpname);
            $("#drpLanguage").append(option);
        }

        stopLoader();
    }
    else if (key == "DrpManagerlist") {

        $('#drpReportingManager').find('option').remove();
        var option1 = new Option("--Select Manager--", "-1");
        /// jquerify the DOM object 'o' so we can use the html method
        $(option1).html("--Select Manager--");
        $("#drpReportingManager").append(option1);

        for (var i = 0; i < resData.lstManager.length; i++) {
            var option = new Option(resData.lstManager[i].Name, resData.lstManager[i].ID);
            /// jquerify the DOM object 'o' so we can use the html method
            $(option).html(resData.lstManager[i].Name);
            $("#drpReportingManager").append(option);
        }

        $('#drpReportingTL').find('option').remove();
        var option1 = new Option("--Select Team Lead--", "-1");
        $(option1).html("--Select Team Lead--");
        $("#drpReportingTL").append(option1);

        for (var i = 0; i < resData.lstTeamlead.length; i++) {

            var option = new Option(resData.lstTeamlead[i].Name, resData.lstTeamlead[i].ID);

            $(option).html(resData.lstTeamlead[i].Name);
            $("#drpReportingTL").append(option);
        }

        if ($('select#drpRole option:selected').val() == "4000" || $('select#drpRole option:selected').val() == "4002") {
            $('#drpReportingTL').prop('disabled', 'disabled');
            $('#drpReportingManager').prop('disabled', '');
        }

        else {
            $('#drpReportingTL').prop('disabled', '');
            $('#drpReportingManager').prop('disabled', '');
        }
        stopLoader();
    }

    else if (key == "Targetfixing") {

        $("#txtcandidatedaily").val(resData.Submission_Daily);
        $("#txttldaily").val(resData.SubmissiontoTL_Daily);
        $("#txtbpdaily").val(resData.SubmissiontoBP_Daily);
        $("#txtclosuredaily").val(resData.Closure_Daily);
        $("#txtvendordaily").val(resData.Vendor_Daily);

        $("#txtcandidateweekly").val(resData.Submission_Weekly);
        $("#txttlweekly").val(resData.SubmissiontoTL_Weekly);
        $("#txtbpweekly").val(resData.SubmissiontoBP_Weekly);
        $("#txtclosureweekly").val(resData.Closure_Weekly);
        $("#txtvendorweekly").val(resData.Vendor_Weekly);

        $("#txtcandidatemonthly").val(resData.Submission_Monthly);
        $("#txttlmonthly").val(resData.SubmissiontoTL_Monthly);
        $("#txtbpmonthly").val(resData.SubmissiontoBP_Monthly);
        $("#txtclosuremonthly").val(resData.Closure_Monthly);
        $("#txtvendormonthly").val(resData.Vendor_Monthly);
        stopLoader();
    }

    else if (key == "RoleMenu") {

        if (resData.jobAccess == '1') {
            $('input[id="chkJobs"]').prop("checked", true);
        }
        else {
            $('input[id="chkJobs"]').prop("checked", false);
        }
        if (resData.jobCreation == '1') {
            $('input[id="chkJobscreation"]').prop("checked", true);
        }
        else {
            $('input[id="chkJobscreation"]').prop("checked", false);
        }
        if (resData.jobEdit == '2') {
            $('input[id="chkEditalljobs"]').prop("checked", true);
            $('input[id="chkEditselfcreated"]').prop("checked", true);
        }
        else if (resData.jobEdit == '1') {
            $('input[id="chkEditalljobs"]').prop("checked", false);
            $('input[id="chkEditselfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkEditalljobs"]').prop("checked", false);
            $('input[id="chkEditselfcreated"]').prop("checked", false);
        }
        if (resData.jobView == '2') {
            $('input[id="chkViewalljobs"]').prop("checked", true);
            $('input[id="chkViewpersonalized"]').prop("checked", true);
        }
        else if (resData.jobView == '1') {
            $('input[id="chkViewalljobs"]').prop("checked", false);
            $('input[id="chkViewpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkViewalljobs"]').prop("checked", false);
            $('input[id="chkViewpersonalized"]').prop("checked", false);
        }
        if (resData.jobFeedback == '2') {
            $('input[id="chkFeedbackalljobs"]').prop("checked", true);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", true);
        }
        else if (resData.jobFeedback == '1') {
            $('input[id="chkFeedbackalljobs"]').prop("checked", false);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkFeedbackalljobs"]').prop("checked", false);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", false);
        }
        if (resData.candidateAccess == '1') {
            $('input[id="chkCandidate"]').prop("checked", true);
        }
        else {
            $('input[id="chkCandidate"]').prop("checked", false);
        }
        if (resData.candidateCreation == '1') {
            $('input[id="chkCandidatecreation"]').prop("checked", true);
        }
        else {
            $('input[id="chkCandidatecreation"]').prop("checked", false);
        }
        if (resData.candidateEdit == '2') {
            $('input[id="chkEditdatabase"]').prop("checked", true);
            $('input[id="chkSelfcreated"]').prop("checked", true);
        }
        else if (resData.candidateEdit == '1') {
            $('input[id="chkEditdatabase"]').prop("checked", false);
            $('input[id="chkSelfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkEditdatabase"]').prop("checked", false);
            $('input[id="chkSelfcreated"]').prop("checked", false);
        }
        if (resData.candidateView == '2') {
            $('input[id="chkViewdatabase"]').prop("checked", true);
            $('input[id="chkPersonalized"]').prop("checked", true);
        }
        else if (resData.candidateView == '1') {
            $('input[id="chkViewdatabase"]').prop("checked", false);
            $('input[id="chkPersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkViewdatabase"]').prop("checked", false);
            $('input[id="chkPersonalized"]').prop("checked", false);
        }
        if (resData.vendorAccess == '1') {
            $('input[id="chkVendorenabled"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendorenabled"]').prop("checked", false);
        }
        if (resData.vendorCreation == '1') {
            $('input[id="chkCreationenabled"]').prop("checked", true);
        }
        else {
            $('input[id="chkCreationenabled"]').prop("checked", false);
        }
        if (resData.vendorEdit == '2') {
            $('input[id="chkVendoreditdatabase"]').prop("checked", true);
            $('input[id="chkVendorselfcreated"]').prop("checked", true);
        }
        else if (resData.vendorEdit == '1') {
            $('input[id="chkVendoreditdatabase"]').prop("checked", false);
            $('input[id="chkVendorselfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendoreditdatabase"]').prop("checked", false);
            $('input[id="chkVendorselfcreated"]').prop("checked", false);
        }
        if (resData.vendorView == '2') {
            $('input[id="chkVendordatabase"]').prop("checked", true);
            $('input[id="chkVendorpersonalized"]').prop("checked", true);
        }
        else if (resData.vendorView == '1') {
            $('input[id="chkVendordatabase"]').prop("checked", false);
            $('input[id="chkVendorpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendordatabase"]').prop("checked", false);
            $('input[id="chkVendorpersonalized"]').prop("checked", false);
        }
        if (resData.reportAccess == '1') {
            $('input[id="chkReportdisable"]').prop("checked", true);
        }
        else {
            $('input[id="chkReportdisable"]').prop("checked", false);
        }
        stopLoader();
    }

    else if (key == "USERDATA") {
        
        $("#hdnUserid").val(resData.basicinfo.TWE_ID);
        $("#txtFirstName").val(resData.basicinfo.firstname);
        $("#txtLastName").val(resData.basicinfo.lastname);
        $("#drpGender").val(resData.basicinfo.gender).prop("selected", true);
        $("#hdnstartdate").val(resData.basicinfo.dob);
        $("#txtDob").val(resData.basicinfo.dob);
        $("#txtemail").val(resData.basicinfo.email);
        $("#txtalternateemail").val(resData.basicinfo.confirmationemail);
        $("#txtLocation").val(resData.basicinfo.location);
        $("#txtPhoneno").val(resData.basicinfo.phoneno);
        $("#drpLanguage").val(resData.basicinfo.language).prop("selected", true);
        $("#drpDesignation").val(resData.basicinfo.designation).prop("selected", true);
        $("#drpRole").val(resData.basicinfo.role).prop("selected", true);
        $("#drpLevel").val(resData.basicinfo.level).prop("selected", true);
        $("#drpReportingManager").val(resData.account.reportingmanager).prop("selected", true);
        $("#drpReportingTL").val(resData.account.reportingTL).prop("selected", true);
        $("#lblRegion").text(resData.supportaccess.region);
        $("#lblMonster").text(resData.supportaccess.monster);
        $("#lblTextnow").text(resData.supportaccess.textnow);
        $('#hdnRegion').val(resData.supportaccess.region);

        $("#txtcandidatedaily").val(resData.targetfixingMstr.Submission_Daily);
        $("#txttldaily").val(resData.targetfixingMstr.SubmissiontoTL_Daily);
        $("#txtbpdaily").val(resData.targetfixingMstr.SubmissiontoBP_Daily);
        $("#txtclosuredaily").val(resData.targetfixingMstr.Closure_Daily);
        $("#txtvendordaily").val(resData.targetfixingMstr.Vendor_Daily);

        $("#txtcandidateweekly").val(resData.targetfixingMstr.Submission_Weekly);
        $("#txttlweekly").val(resData.targetfixingMstr.SubmissiontoTL_Weekly);
        $("#txtbpweekly").val(resData.targetfixingMstr.SubmissiontoBP_Weekly);
        $("#txtclosureweekly").val(resData.targetfixingMstr.Closure_Weekly);
        $("#txtvendorweekly").val(resData.targetfixingMstr.Vendor_Weekly);

        $("#txtcandidatemonthly").val(resData.targetfixingMstr.Submission_Monthly);
        $("#txttlmonthly").val(resData.targetfixingMstr.SubmissiontoTL_Monthly);
        $("#txtbpmonthly").val(resData.targetfixingMstr.SubmissiontoBP_Monthly);
        $("#txtclosuremonthly").val(resData.targetfixingMstr.Closure_Monthly);
        $("#txtvendormonthly").val(resData.targetfixingMstr.Vendor_Monthly);


        if (resData.MenuAccess.jobAccess == '1') {
            $('input[id="chkJobs"]').prop("checked", true);
        }
        else {
            $('input[id="chkJobs"]').prop("checked", false);
        }
        if (resData.MenuAccess.jobCreation == '1') {
            $('input[id="chkJobscreation"]').prop("checked", true);
        }
        else {
            $('input[id="chkJobscreation"]').prop("checked", false);
        }
        if (resData.MenuAccess.jobEdit == '2') {
            $('input[id="chkEditalljobs"]').prop("checked", true);
            $('input[id="chkEditselfcreated"]').prop("checked", true);
        }
        else if (resData.MenuAccess.jobEdit == '1') {
            $('input[id="chkEditalljobs"]').prop("checked", false);
            $('input[id="chkEditselfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkEditalljobs"]').prop("checked", false);
            $('input[id="chkEditselfcreated"]').prop("checked", false);
        }
        if (resData.MenuAccess.jobView == '2') {
            $('input[id="chkViewalljobs"]').prop("checked", true);
            $('input[id="chkViewpersonalized"]').prop("checked", true);
        }
        else if (resData.MenuAccess.jobView == '1') {
            $('input[id="chkViewalljobs"]').prop("checked", false);
            $('input[id="chkViewpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkViewalljobs"]').prop("checked", false);
            $('input[id="chkViewpersonalized"]').prop("checked", false);
        }
        if (resData.MenuAccess.jobFeedback == '2') {
            $('input[id="chkFeedbackalljobs"]').prop("checked", true);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", true);
        }
        else if (resData.MenuAccess.jobFeedback == '1') {
            $('input[id="chkFeedbackalljobs"]').prop("checked", false);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkFeedbackalljobs"]').prop("checked", false);
            $('input[id="chkFeedbackpersonalized"]').prop("checked", false);
        }
        if (resData.MenuAccess.candidateAccess == '1') {
            $('input[id="chkCandidate"]').prop("checked", true);
        }
        else {
            $('input[id="chkCandidate"]').prop("checked", false);
        }
        if (resData.MenuAccess.candidateCreation == '1') {
            $('input[id="chkCandidatecreation"]').prop("checked", true);
        }
        else {
            $('input[id="chkCandidatecreation"]').prop("checked", false);
        }
        if (resData.MenuAccess.candidateEdit == '2') {
            $('input[id="chkEditdatabase"]').prop("checked", true);
            $('input[id="chkSelfcreated"]').prop("checked", true);
        }
        else if (resData.MenuAccess.candidateEdit == '1') {
            $('input[id="chkEditdatabase"]').prop("checked", false);
            $('input[id="chkSelfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkEditdatabase"]').prop("checked", false);
            $('input[id="chkSelfcreated"]').prop("checked", false);
        }
        if (resData.MenuAccess.candidateView == '2') {
            $('input[id="chkViewdatabase"]').prop("checked", true);
            $('input[id="chkPersonalized"]').prop("checked", true);
        }
        else if (resData.MenuAccess.candidateView == '1') {
            $('input[id="chkViewdatabase"]').prop("checked", false);
            $('input[id="chkPersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkViewdatabase"]').prop("checked", false);
            $('input[id="chkPersonalized"]').prop("checked", false);
        }
        if (resData.MenuAccess.vendorAccess == '1') {
            $('input[id="chkVendorenabled"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendorenabled"]').prop("checked", false);
        }
        if (resData.MenuAccess.vendorCreation == '1') {
            $('input[id="chkCreationenabled"]').prop("checked", true);
        }
        else {
            $('input[id="chkCreationenabled"]').prop("checked", false);
        }
        if (resData.MenuAccess.vendorEdit == '2') {
            $('input[id="chkVendoreditdatabase"]').prop("checked", true);
            $('input[id="chkVendorselfcreated"]').prop("checked", true);
        }
        else if (resData.vendorEdit == '1') {
            $('input[id="chkVendoreditdatabase"]').prop("checked", false);
            $('input[id="chkVendorselfcreated"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendoreditdatabase"]').prop("checked", false);
            $('input[id="chkVendorselfcreated"]').prop("checked", false);
        }
        if (resData.MenuAccess.vendorView == '2') {
            $('input[id="chkVendordatabase"]').prop("checked", true);
            $('input[id="chkVendorpersonalized"]').prop("checked", true);
        }
        else if (resData.MenuAccess.vendorView == '1') {
            $('input[id="chkVendordatabase"]').prop("checked", false);
            $('input[id="chkVendorpersonalized"]').prop("checked", true);
        }
        else {
            $('input[id="chkVendordatabase"]').prop("checked", false);
            $('input[id="chkVendorpersonalized"]').prop("checked", false);
        }

        stopLoader();
    }

    else if (key == "ADDUSERPROFILE") {

        $("#div-message").text('User saved successfully');
        $('#div_Success').css('display', 'block');
        $('#div_Confirm').css('display', 'none');
        $("#msgpopup").modal('show');
        stopLoader();

    }

}


function saveUserprofile() {
    if (Validateuserprofile() == true) {
        var Firstname = $("#txtFirstName").val();
        var Lastname = $("#txtLastName").val();
        var Gender = $('select#drpGender option:selected').val();
        var DOB = $("#hdnstartdate").val();
        var Emailid = $("#txtemail").val();
        var Confirmationemailid = $("#txtalternateemail").val();
        var location = $("#txtLocation").val();
        var Phoneno = $("#txtPhoneno").val();
        var Language = $('select#drpLanguage option:selected').val();
        var Designation = $('select#drpDesignation option:selected').val();
        var Role = $('select#drpRole option:selected').val();
        var Level = $('select#drpLevel option:selected').val();
        var Reportingmanager = $('select#drpReportingManager option:selected').val();
        var ReportingTL = $('select#drpReportingTL option:selected').val();
        var Region = $('#hdnRegion').val();
        var str = $('#lblMonster').text().split("|");
        var Status = "1";
        var Monsterusername = str[0];
        var Monsterpassword = str[1];
        var Textnow = $('#lblTextnow').text();
        var Password = "Techwaukee_2016";
        var Userid = $("#hdnUserid").val();

        var Submissiondaily = $("#txtcandidatedaily").val();
        var SubmissiontoTLdaily = $("#txttldaily").val();
        var SubmissiontoBPdaily = $("#txtbpdaily").val();
        var Closuredaily = $("#txtclosuredaily").val();
        var Vendorsdaily = $("#txtvendordaily").val() != "" ? $("#txtvendordaily").val() : "0";

        var Submissionweekly = $("#txtcandidateweekly").val();
        var SubmissiontoTLweekly = $("#txttlweekly").val();
        var SubmissiontoBPweekly = $("#txtbpweekly").val();
        var Closureweekly = $("#txtclosureweekly").val();
        var Vendorsweekly = $("#txtvendorweekly").val() != "" ? $("#txtvendorweekly").val() : "0";

        var Submissionmonthly = $("#txtcandidatemonthly").val();
        var SubmissiontoTLmonthly = $("#txttlmonthly").val();
        var SubmissiontoBPmonthly = $("#txtbpmonthly").val();
        var Closuremonthly = $("#txtclosuremonthly").val();
        var Vendorsmonthly = $("#txtvendormonthly").val() != "" ? $("#txtvendormonthly").val() : "0";

        var jobmenu;
        var jobcreation;
        var jobedit;
        var jobview;
        var jobfeedback;
        var candidatemenu;
        var candidatecreation;
        var candidateedit;
        var candidateview;
        var vendormenu;
        var vendorcreation;
        var vendoredit;
        var vendorview;
        var reportmenu;

        if ($('input[id="chkJobs"]:checked').val() == "on") {
            jobmenu = "1";
        }
        else {
            jobmenu = "0";
        }

        if ($('input[id="chkJobscreation"]:checked').val() == "on") {
            jobcreation = "1";
        }
        else {
            jobcreation = "0";
        }

        if ($('input[id="chkEditalljobs"]:checked').val() == "on") {
            jobedit = "2";
        }
        else if ($('input[id="chkEditselfcreated"]:checked').val() == "on") {
            jobedit = "1";
        }
        else {
            jobedit = "0";
        }
        if ($('input[id="chkViewalljobs"]:checked').val() == "on") {
            jobview = "2";
        }
        else if ($('input[id="chkViewpersonalized"]:checked').val() == "on") {
            jobview = "1";
        }
        else {
            jobview = "0";
        }

        if ($('input[id="chkFeedbackalljobs"]:checked').val() == "on") {
            jobfeedback = "2";
        }
        else if ($('input[id="chkFeedbackpersonalized"]:checked').val() == "on") {
            jobfeedback = "1";
        }
        else {
            jobfeedback = "0";
        }

        if ($('input[id="chkCandidate"]:checked').val() == "on") {
            candidatemenu = "1";
        }
        else {
            candidatemenu = "0";
        }
        if ($('input[id="chkCandidatecreation"]:checked').val() == "on") {
            candidatecreation = "1";
        }
        else {
            candidatecreation = "0";
        }
        if ($('input[id="chkEditdatabase"]:checked').val() == "on") {
            candidateedit = "2";
        }
        else if ($('input[id="chkSelfcreated"]:checked').val() == "on") {
            candidateedit = "1";
        }
        else {
            candidateedit = "0";
        }
        if ($('input[id="chkViewdatabase"]:checked').val() == "on") {
            candidateview = "2";
        }
        else if ($('input[id="chkPersonalized"]:checked').val() == "on") {
            candidateview = "1";
        }
        else {
            candidateview = "0";
        }
        if ($('input[id="chkVendorenabled"]:checked').val() == "on") {
            vendormenu = "1";
        }
        else {
            vendormenu = "0";
        }
        if ($('input[id="chkCreationenabled"]:checked').val() == "on") {
            vendorcreation = "1";
        }
        else {
            vendorcreation = "0";
        }
        if ($('input[id="chkVendoreditdatabase"]:checked').val() == "on") {
            vendoredit = "2";
        }
        else if ($('input[id="chkVendorselfcreated"]:checked').val() == "on") {
            vendoredit = "1";
        }
        else {
            vendoredit = "0";
        }
        if ($('input[id="chkVendordatabase"]:checked').val() == "on") {
            vendorview = "2";
        }
        else if ($('input[id="chkVendorpersonalized"]:checked').val() == "on") {
            vendorview = "1";
        }
        else {
            vendorview = "0";
        }
        if ($('input[id="chkReportdisable"]:checked').val() == "on") {
            reportmenu = "1";
        }
        else {
            reportmenu = "0";
        }


        var strdata = {
            "Firstname": Firstname, "Lastname": Lastname, "Gender": Gender, "DOB": DOB, "Emailid": Emailid,
            "Confirmationemailid": Confirmationemailid, "Location": location, "Phoneno": Phoneno, "Language": Language,
            "Designation": Designation, "Region": Region, "Monsterusername": Monsterusername, "Monsterpassword": Monsterpassword,
            "Textnow": Textnow, "Reportingmanager": Reportingmanager, "ReportingTL": ReportingTL, "Submissiondaily": Submissiondaily,
            "SubmissiontoTLdaily": SubmissiontoTLdaily,
            "SubmissiontoBPdaily": SubmissiontoBPdaily, "Closuredaily": Closuredaily,
            "Vendorsdaily": Vendorsdaily, "Submissionweekly": Submissionweekly, "SubmissiontoTLweekly": SubmissiontoTLweekly,
            "SubmissiontoBPweekly": SubmissiontoBPweekly, "Closureweekly": Closureweekly, "Vendorsweekly": Vendorsweekly,
            "Submissionmonthly": Submissionmonthly, "SubmissiontoTLmonthly": SubmissiontoTLmonthly,
            "SubmissiontoBPmonthly": SubmissiontoBPmonthly, "Closuremonthly": Closuremonthly,
            "Vendorsmonthly": Vendorsmonthly, "jobMenu": jobmenu, "jobCreation": jobcreation,
            "jobEdit": jobedit, "jobView": jobview, "jobFeedback": jobfeedback, "candidateMenu": candidatemenu,
            "candidateCreation": candidatecreation, "candidateEdit": candidateedit, "candidateView": candidateview, "vendorMenu": vendormenu,
            "vendorCreation": vendorcreation, "vendorEdit": vendoredit, "vendorView": vendorview, "reportMenu": reportmenu, "Userid": Userid, "Status": Status, "Password": Password
        };
        common_api_ajax_request("api/InsertUserProfile", "ADDUSERPROFILE", strdata);
    }

}


function Validateuserprofile() {
    var count = 0;
    var emptycount = 0;
    if ($("#txtFirstName").val() == "") {
        $('#txtFirstName').addClass("is-invalid");
        $('#txtFirstName').focus();
        emptycount++;
    }
    else {
        $('#txtFirstName').removeClass("is-invalid");
        count++;
    }

    if ($('#txtLastName').val() == "") {
        $("#txtLastName").addClass("is-invalid");
        $('#txtLastName').focus();
        emptycount++;
    }
    else {
        $("#txtLastName").removeClass("is-invalid");
        count++;
    }

    if ($('#drpGender').val() == "-1") {
        $('#drpGender').addClass("is-invalid");
        $('#drpGender').focus();
        emptycount++;
    }
    else {
        $('#drpGender').removeClass("is-invalid");
        count++;
    }

    if ($('#txtDob').val() == "") {
        $('#txtDob').addClass("is-invalid");
        $('#txtDob').focus();
        emptycount++;
    }
    else {
        $('#txtDob').removeClass("is-invalid");
        count++;
    }

    if ($('#txtemail').val() == "") {
        $('#txtemail').addClass("is-invalid");
        $('#txtemail').focus();
        emptycount++;
    }
    else {
        $('#txtemail').removeClass("is-invalid");
        count++;
    }

    if ($('#txtalternateemail').val() == "") {
        $('#txtalternateemail').addClass("is-invalid");
        $('#txtalternateemail').focus();
        emptycount++;
    }
    else {
        $('#txtalternateemail').removeClass("is-invalid");
        count++;
    }

    if ($('#txtLocation').val() == "") {
        $('#txtLocation').addClass("is-invalid");
        $('#txtLocation').focus();
        emptycount++;
    }
    else {
        $('#txtLocation').removeClass("is-invalid");
        count++;
    }

    if ($('#txtPhoneno').val() == "") {
        $('#txtPhoneno').addClass("is-invalid");
        $('#txtPhoneno').focus();
        emptycount++;
    }
    else {
        $('#txtPhoneno').removeClass("is-invalid");
        count++;
    }

    if ($('#drpLanguage').val() == "-1") {
        $('#drpLanguage').addClass("is-invalid");
        $('#drpLanguage').focus();
        emptycount++;
    }
    else {
        $('#drpLanguage').removeClass("is-invalid");
        count++;
    }

    if ($('#drpDesignation').val() == "-1") {
        $('#drpDesignation').addClass("is-invalid");
        $('#drpDesignation').focus();
        emptycount++;
    }
    else {
        $('#drpDesignation').removeClass("is-invalid");
        count++;
    }

    if ($('#drpRole').val() == "-1") {
        $('#drpRole').addClass("is-invalid");
        $('#drpRole').focus();
        emptycount++;
    }
    else {
        $('#drpRole').removeClass("is-invalid");
        count++;
    }

    if ($('#drpLevel').val() == "-1") {
        $('#drpLevel').addClass("is-invalid");
        $('#drpLevel').focus();
        emptycount++;
    }
    else {
        $('#drpLevel').removeClass("is-invalid");
        count++;
    }

    if ($('#drpReportingManager').val() == "-1") {
        $('#drpReportingManager').addClass("is-invalid");
        $('#drpReportingManager').focus();
        emptycount++;
    }
    else {
        $('#drpReportingManager').removeClass("is-invalid");
        count++;
    }

    if ($('#drpRole').val() == 4001) {

        if ($('#drpReportingTL').val() == "-1") {
            $('#drpReportingTL').addClass("is-invalid");
            $('#drpReportingTL').focus();
            emptycount++;
        }
        else {
            $('#drpReportingTL').removeClass("is-invalid");
            count++;
        }

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


function Validateregion() {
    var count = 0;
    var emptycount = 0;
    if ($('#drpRegion').val() == "-1") {
        $('#drpRegion').addClass("is-invalid");
        $('#drpRegion').focus();
        emptycount++;
    }
    else {
        $('#drpRegion').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function Validatemonster() {
    var count = 0;
    var emptycount = 0;
    if ($('#txtMonsteruserid').val() == "") {
        $('#txtMonsteruserid').addClass("is-invalid");
        $('#txtMonsteruserid').focus();
        emptycount++;
    }
    else {
        $('#txtMonsteruserid').removeClass("is-invalid");
        count++;
    }

    if ($('#txtMonsterpwd').val() == "") {
        $('#txtMonsterpwd').addClass("is-invalid");
        $('#txtMonsterpwd').focus();
        emptycount++;
    }
    else {
        $('#txtMonsterpwd').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function Validatetextnownumber() {
    var count = 0;
    var emptycount = 0;
    if ($('#txtTextnownumber').val() == "") {
        $('#txtTextnownumber').addClass("is-invalid");
        $('#txtTextnownumber').focus();
        emptycount++;
    }
    else {
        $('#txtTextnownumber').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}


function disableControls() {

    $('#txtFirstName').prop('disabled', true);
    $('#txtLastName').prop('disabled', true);
    $('#drpGender').prop('disabled', true);
    $('#txtDob').prop('disabled', true);
    $('#txtemail').prop('disabled', true);
    $('#txtalternateemail').prop('disabled', true);
    $('#txtLocation').prop('disabled', true);
    $('#txtPhoneno').prop('disabled', true);
    $('#drpLanguage').prop('disabled', true);
    $('#drpDesignation').prop('disabled', true);
    $('#drpRole').prop('disabled', true);
    $('#drpLevel').prop('disabled', true);
    $('#drpReportingManager').prop('disabled', true);
    $('#drpReportingTL').prop('disabled', true); 

    $('#btnRegionadd').prop('disabled', true); 
    $('#btnMonsteradd').prop('disabled', true);
    $('#btnTextnowadd').prop('disabled', true);

    $('#chkDashboard').prop('disabled', true); 
    $('#chkJobs').prop('disabled', true);
    $('#chkJobscreation').prop('disabled', true);
    $('#chkEditalljobs').prop('disabled', true);
    $('#chkEditselfcreated').prop('disabled', true);
    $('#chkViewalljobs').prop('disabled', true);
    $('#chkViewpersonalized').prop('disabled', true);
    $('#chkFeedbackalljobs').prop('disabled', true);
    $('#chkFeedbackpersonalized').prop('disabled', true);

    $('#chkCandidate').prop('disabled', true);
    $('#chkCandidatecreation').prop('disabled', true);
    $('#chkEditdatabase').prop('disabled', true);
    $('#chkSelfcreated').prop('disabled', true);
    $('#chkViewdatabase').prop('disabled', true);
    $('#chkPersonalized').prop('disabled', true);

    $('#chkVendorenabled').prop('disabled', true);
    $('#chkCreationenabled').prop('disabled', true);
    $('#chkVendoreditdatabase').prop('disabled', true);
    $('#chkVendorselfcreated').prop('disabled', true);
    $('#chkVendordatabase').prop('disabled', true);
    $('#chkVendorpersonalized').prop('disabled', true);

    $('#chkReportdisable').prop('disabled', true);

    $('#txtCandidateadding').prop('disabled', true);
    $('#txtVendorcreation').prop('disabled', true);
    $('#txtSubmission').prop('disabled', true);
    $('#txtTLApproval').prop('disabled', true);
    $('#txtBPApproval').prop('disabled', true);
    $('#txtECApproval').prop('disabled', true);

}

function enableControls() {

    $('#txtFirstName').prop('disabled', false);
}


function getDateInfo() {


    var date = new Date($('#txtDob').val().substring(6, 10), (parseInt($('#txtDob').val().substring(3, 5)) - 1), $('#txtDob').val().substring(0, 2));

    var firstDay =
        new Date(date.getFullYear(), date.getMonth(), 1);

    document.getElementById("hdnstartdate").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
}