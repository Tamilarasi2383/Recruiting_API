$(document).ready(function () {

    setSession("Page", "Candidate");
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchCand").addClass("active");
    $('#lblPagetitle').text("Candidate");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        if (hash.length == 1) {
            var params = hash[0].split("=");
            getcandidateProfile(params[1]);
        }
        else if (hash.length > 1) {
            var params = hash[0].split("=");
            var params1 = hash[1].split("=");
            getcandidateProfile(params[1]);
            getcandidateFeedback(params1[1]);
            return load_Div('div-feedback');

        }
    }

    stopLoader();
});


function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "CANDPROFILE") {
        $('#hdncandid').val(resData.candDetail.candidateid);
        $('#lblCandidatename').text(resData.candDetail.candidatename);
        $('#lblLocation').text(resData.candDetail.currentLocation);
        $('#lblCandcandidatename').text(resData.candDetail.candidatename);
        $('#lblCandlocation').text(resData.candDetail.currentLocation);
        $('#lblCandmobile').text(resData.candDetail.candidatemobileno);
        $('#lblCandemail').text(resData.candDetail.candidateemailid);
        $("#imgCandlinkedin").attr("href", resData.candDetail.linkedinURL);
        $('#lblSkillscertification').text(resData.candDetail.skillsandCertif);

        $('#lblEmpemployername').text(resData.candDetail.employeename);
        $('#lblEmpmobile').text(resData.candDetail.employerContactno);
        $('#lblEmpemail').text(resData.candDetail.employermailid);
        $('#lblEmpcorporation').text(resData.candDetail.corporationname);
        $('#lblEmpspecialization').text(resData.candDetail.employerspecialization);
        $('#lblEmpAddedinfo').text(resData.candDetail.employeradderinformation);
        getrateUser("mrat_" + resData.candDetail.recruiterrating.trim());

        if (resData.positiverating == "") {
            resData.positiverating = "0";
        }

        if (resData.negativerating == "") {
            resData.negativerating = "0";
        }

        $('#lblPositive').text(resData.positiverating + "%");
        $("#div_positive").addClass("w-" + resData.positiverating);

        $('#lblNegative').text(resData.negativerating + "%");
        $("#div_negative").addClass("w-" + resData.negativerating);
        document.getElementById("drpJobtitle").options.length = 0;
        var option1 = new Option("--Select Job--", "-1");
        $(option1).html("--Select Job--");
        $("#drpJobtitle").append(option1);


        for (var i = 0; i < resData._lstdrpJob.length; i++) {

            var option = new Option(resData._lstdrpJob[i].Name, resData._lstdrpJob[i].ID);

            $(option).html(resData._lstdrpJob[i].Name);
            $("#drpJobtitle").append(option);
        }

        matching_jobs(resData._lstMatchJob);
        if (resData._lstJob.length > 0) {
            committedjobs(resData._lstJob);
        }
        proofdocuments(resData._lstCandProof);

        //
        assignedJobs(resData._lstAssignedJob);

        stopLoader();
    }

    else if (key == "CANDFEED") {

        if (resData.candcommentid != null) {
            $('#div_candfeedback').css('display', 'block');
            feedback(resData);
        }
        stopLoader();

    }

   

}

function matching_jobs(data) {


    var str1 = "<ul class='list-group'>";
    for (var i = 0; i < data.length; i++) {

        str1 += "<li class='list-group-item border-0 d-flex align-items-center px-0 mb-2'>" +
            "<div class='avatar me-3'>" +
            "<img src='" + data[i].JobMediaPath + "' class='avatar avatar-sm me-3'>" +
            "</div>" +
            "<div class='d-flex align-items-start flex-column justify-content-center'>" +
            "<div class='d-flex flex-column justify-content-center'>" +
            "<label class='mb-0 text-sm h6' id='lblJobname'>" + data[i].JobTitle + "</label>" +
            "<label class='mb-0'>" +
            "<label class='text-xs' id='lblJobmonth'>" + data[i].JobDuration + "</label>|<label class='text-xs' id='lblJobcontract'>" + data[i].JobType + "</label>|<label class='text-xs' id='lblJobcity'>" + data[i].JobState + "</label></label>" +
            "</div>" +
            "</div>" +
            "<a class='btn btn-link pe-3 ps-0 mb-0 ms-auto' href='javascript:;' onclick=window.location.href='CandidateIndia.aspx?jobid=" + data[i].Jobcode + "&candid=" + $('#hdncandid').val() + "'>Apply</a>" +
            "</li>";

    }
    str1 += "</ul>";



    $('#div-matchjobs').empty();
    $('#div-matchjobs').append(str1);
}
function getcandidateProfile(candVal) {
    var TWE_Id = getSession('TWE_ID');

    var strdata = { "TWE_Id": TWE_Id, "candidateid": candVal };
    if (TWE_Id != "") {
        common_api_ajax_request("api/CandidateProfileviewIndia", "CANDPROFILE", strdata);
    }
}

function getcandidateFeedback(jobVal) {

    var strdata = { "Jobid": jobVal,"candid": $('#hdncandid').val() };
    if (jobVal != "") {
        common_api_ajax_request("api/CandidateFeedbackIndia", "CANDFEED", strdata);
    }
}

function committedjobs(lstCommit) {
    var strData = ""
    for (var i = 0; i < lstCommit.length; i++) {
        strData = "<div class='row'>" +
            "<div class='col-xl-3 col-md-6 mb-xl-0 mb-4'>" +
            "<div class='card card-blog card-plain'>" +
            "<div class='position-relative'>" +
            "<a class='d-block shadow-xl border-radius-xl'>" +
            "<img src='" + lstCommit[i].JobMediaPath + "' alt='img-blur-shadow' class='img-fluid shadow border-radius-xl'>" +
            "</a>" +
            "</div>";

        strData += "<div class='card-body px-1 pb-0'>" +
            "<a href='javascript:;'>" +
            "<h5>" + lstCommit[i].JobTitle +
            "</h5>" +
            "</a>" +
            "<label class='text-gradient text-dark mb-2 text-sm' id='lblJobmonth'>" + lstCommit[i].JobDuration + "</label>|<label class='text-gradient text-dark mb-2 text-sm' id='lblJobcontract'>" + lstCommit[i].JobType + "</label>|<label class='text-gradient text-dark mb-2 text-sm' id='lblJobcity'>" + lstCommit[i].JobState + "</label></label>" +
            "<p class='mb-4 text-sm'>" +
            "Rate:<img src='Images/in-rupee.png' width='15' height='15' />" + lstCommit[i].JobRate + " On " + lstCommit[i].JobType +
            "</p>" +
            "<div class='d-flex align-items-center justify-content-between'>" +
            "<button type='button' class='btn btn-outline-primary btn-sm mb-0' onclick=window.location.href='FollowuppageIndia.aspx?id=" + lstCommit[i].Jobcode + "'>View Job</button>" +
            "</div></div></div></div>";

    }
    strData += "<div class='col-xl-3 col-md-6 mb-xl-0 mb-4'>" +
        "<div class='card h-100 card-plain border'>" +
        "<div class='card-body d-flex flex-column justify-content-center text-center'>" +
        "<a href='javascript:;' onclick=addJob();>" +
        "<i class='fa fa-plus text-secondary mb-3'></i>" +
        "<h5 class=' text-secondary'>Add to Job </h5>" +
        "</a></div></div></div></div>";

    $('#div_committed').empty();
    $('#div_committed').append(strData);
}


function proofdocuments(sdata) {
    var str = "<form action='' id=dropBasic1' style='min - height: 117px!important;'><div class='card-body d-flex'>";
    var imgFile = "";
    for (var i = 0; i < sdata.length; i++) {
        var str1;
        if (sdata[i].documenttype == "Resume") {
            imgFile = "Images/Resume.png";
            str1 = "lblResume_";
        }
        else if (sdata[i].documenttype == "Aadhar") {
            imgFile = "Images/Visa.png";
            str1 = "lblAadhar_";
        }
        else if (sdata[i].documenttype == "PAN") {
            imgFile = "Images/ID.png";
            str1 = "lblPAN_";
        }
        else if (sdata[i].documenttype == "Others") {
            imgFile = "Images/ID.png";
            str1 = "lblOthers_";
        }


        str += "<div class='col-lg-1 col-md-2 col-sm-3 col-4 text-center' id='div_proof_"+(parseInt(i)+1)+"' onclick=filedownload(this)>" +
            "<a href='javascript:;' id='anchResume' class='avatar avatar-lg rounded-circle border border-success'>" +
            "<img alt='Image placeholder' class='p-1' src='" + imgFile + "'>" +
            "</a><p class='mb-0 text-sm'><span title='Click to Download file' style='cursor:pointer' id='" + str1 + i + "' value='" + sdata[i].idfilename+"' onclick=downloadFile(this)>" + sdata[i].idfilename + "</span></p></div>";
        //Ushashree_ETL_Talend.docx
    }
    str += "</div></form>";
    $('#div_proof').empty();
    $('#div_proof').append(str);
}

function feedback(sdata) {
    $('#hdncommid').text(sdata.candcommentid);
    $('#hdncanstatus').text(sdata.candStatus);

    $('#lblJobImage').attr('src', sdata.jobimage);
    $('#lblJobtitle').text(sdata.jobtitle);

    $('#lblType').text(sdata.emplType);
    $('#lblWorkingtype').text(sdata.joblocation);
    $('#lblJobduration').text(sdata.jobduration);
    $('#lblCreateby').text(sdata.jobcreatedBy);
    $('#lblCreateon').text(sdata.jobcreatedOn);
    $('#lblCreatetime').text(sdata.jobcreatedTime);
    $('#lblStatus').text(sdata.jobstatus);
    $('#lblRate').text(sdata.ratePerHr);
    $('#lblType2').text(sdata.type);
    $('#lblAvlinterview').text(sdata.availableforinterview);


    $('#txtRecComments').text(sdata.RecruiterComments);
    $('#lblRecrutiercreatedate').text(sdata.createdOn);
    $('#lblRecrutiercreatedontime').text(sdata.createdTime);
    $('#p_Recruitername').text("By " + sdata.createdBy);
    $('#p_Reccommdate').text(sdata.createdOn + "|" + sdata.createdTime + " EST");
    $('#txtBIDate').val(sdata.BPIstartdate);
    $('#txtBITime').val(sdata.BPITime);

    $('#txtdateec').val(sdata.ECIstartdate);
    $('#txtTimeec').val(sdata.ECITime);


    $('#txtBPComments').text(sdata.BPComments);
    $('#txtECComments').text(sdata.ECComments);

    $('#txtClosure').text(sdata.CLComments);

    // $("#starRecRating").text(sdata.recruiterrating);

    getrateUser("recrat_" + sdata.recruiterrating.trim());

    $('#lblstatusEC').text(sdata.ECComments);
    $('#lblECcommdate').text(sdata.ECcomgivenon);
    $('#lblECcommtime').text(sdata.ECcomgiventime);
    $('#lblECcommgivenby').text(sdata.ECcomgivenby);

    $('#lblstatusBP').text(sdata.BPComments);
    $('#lblBPcommdate').text(sdata.BPcomgivenon);
    $('#lblBPcommtime').text(sdata.BPcomgiventime);
    $('#lblBPcommgivenby').text(sdata.BPcomgivenby);

    $('#lblstatusTL').text(sdata.TLComments);
    $('#lblTLcommdate').text(sdata.TLcomgivenon);
    $('#lblTLcommtime').text(sdata.TLcomgiventime);
    $('#lblTLcommgivenby').text(sdata.TLcomgivenby);

    if (sdata.lastupdatedOn != "") {
        $('#lblRecrutierupdatedondate').text(sdata.lastupdatedOn);
        $('#div_Recupd').css('display', 'block');
        //$('#lblRecrutierupdatedontime').text(sdata.createdTime);
    }

    else {
        $('#div_Recupd').css('display', 'none');

    }

    $('#txtTLComments').text(sdata.TLComments);
    $('#lblTlcommentscreatedondate').text(sdata.TLcomgivenon);
    $('#lblTlcommentscreatedontime').text(sdata.TLcomgiventime);
    $("#TLRating").text(sdata.TLRating);

    if (sdata.TLComments != "") {
        $('#p_Teamleadname').css('display', 'block');
        $('#p_TLcommdate').css('display', 'block');
        $('#div_TLcre').css('display', 'block');

    }
    if (sdata.BPComments != "") {
        $('#div_BPcre').css('display', 'block');
        $('#div_BPupd').css('display', 'block');
    }



    $('#p_TLcommdate').text(sdata.TLcomgivenon + "|" + sdata.TLcomgiventime + " EST");



    if (parseInt(sdata.candstatusid) == 104) {
        $('#p_Teamleadname').text("Rejected by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-danger");

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

    }

    else if (parseInt(sdata.candstatusid) == 105) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);


    }

    else if (parseInt(sdata.candstatusid) == 106) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Rejected by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-danger");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " IST");
        $('#p_BPcommdate').css('display', 'block');


        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');
        }
        else {
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'Red');
        }

        $('#div_BP').css('display', 'block');
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Rejected");
        $('#lblBpfeedback').css('color', 'red');
        $('#radBPApp').prop("checked", false);
        $('#radBPRej').prop("checked", true);
    }

    else if (parseInt(sdata.candstatusid) == 107) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " IST");
        $('#p_BPcommdate').css('display', 'block');
        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');

        }
        else {
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'red');

        }

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01") {
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');

            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'red');
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
        }

        $('#div_BP').css('display', 'block');
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');

    }
    else if (parseInt(sdata.candstatusid) == 110) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPIname').text("Scheduled");
        $("#p_BPIname").addClass("text-success");
        $('#p_BPIname').css('display', 'block');
        $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
        $('#p_BPIcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        $('#div_BPI').css('display', 'block');
        $('#txtBIDate').prop('disabled', true);
        $('#txtBITime').prop('disabled', true);
        $("#lblBpinterview").text("Yes");
        $('#lblBpinterview').css('color', 'green');

    }

    else if (parseInt(sdata.candstatusid) == 111) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " IST");
        $('#p_BPcommdate').css('display', 'block');
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
        $('#p_ECIcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01") {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", true);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');

            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'red');

            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
        }

        $('#div_BP').css('display', 'block');
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');
        $('#div_ECI').css('display', 'block');
        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("Yes");
            $('#lblEcinterview').css('color', 'green');

            $('#p_ECIname').text("Scheduled");
            $("#p_ECIname").addClass("text-success");
            $('#p_ECIname').css('display', 'block');
            $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
            $('#p_ECIcommdate').css('display', 'block');
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("No");
            $('#lblEcinterview').css('color', 'red');

            $('#p_ECIname').text("Not Scheduled");
            $("#p_ECIname").addClass("text-danger");
            $('#p_ECIname').css('display', 'block');
        }


    }

    else if (parseInt(sdata.candstatusid) == 108) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " IST");
        $('#p_BPcommdate').css('display', 'block');
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
        $('#p_ECIcommdate').css('display', 'block');
        $('#p_ECname').text("Rejected by " + sdata.BPcomgivenby);
        $("#p_ECname").addClass("text-danger");
        $('#p_ECname').css('display', 'block');
        $('#p_ECcommdate').text(sdata.ECcomgivenon + '|' + sdata.ECcomgiventime + " IST");
        $('#p_ECcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01") {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", true);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');

            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", false);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'red');

            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
        }

        $('#div_BP').css('display', 'block');
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');
        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');
            $('input[name="chkEcinterview"]').prop("checked", true);
            $('input[name="chkEcinterview"]').prop("disabled", true);
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("Yes");
            $('#lblEcinterview').css('color', 'green');

            $('#p_ECIname').text("Scheduled");
            $("#p_ECIname").addClass("text-success");
            $('#p_ECIname').css('display', 'block');
            $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
            $('#p_ECIcommdate').css('display', 'block');
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('input[name="chkEcinterview"]').prop("checked", false);
            $('input[name="chkEcinterview"]').prop("disabled", true);
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("No");
            $('#lblEcinterview').css('color', 'red');

            $('#p_ECIname').text("Not Scheduled");
            $("#p_ECIname").addClass("text-danger");
            $('#p_ECIname').css('display', 'block');
        }


        $('#div_EC').css('display', 'block');
        $('#txtECComments').prop('disabled', true);
        $("#lblEcfeedback").text("Rejected");
        $('#lblEcfeedback').css('color', 'red');


    }

    else if (parseInt(sdata.candstatusid) == 109) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " IST");
        $('#p_BPcommdate').css('display', 'block');
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
        $('#p_ECIcommdate').css('display', 'block');
        $('#p_ECname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_ECname").addClass("text-success");
        $('#p_ECname').css('display', 'block');
        $('#p_ECcommdate').text(sdata.ECcomgivenon + '|' + sdata.ECcomgiventime + " IST");
        $('#p_ECcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01") {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", true);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');
            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " IST");
            $('#p_BPIcommdate').css('display', 'block');

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("No");
            $('#lblBpinterview').css('color', 'red');

            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
        }

        $('#div_BP').css('display', 'block');
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');

        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');
            $('input[name="chkEcinterview"]').prop("checked", true);
            $('input[name="chkEcinterview"]').prop("disabled", true);
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("Yes");
            $('#lblEcinterview').css('color', 'green');

            $('#p_ECIname').text("Scheduled");
            $("#p_ECIname").addClass("text-success");
            $('#p_ECIname').css('display', 'block');
            $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " IST");
            $('#p_ECIcommdate').css('display', 'block');
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('input[name="chkEcinterview"]').prop("checked", false);
            $('input[name="chkEcinterview"]').prop("disabled", true);
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("No");
            $('#lblEcinterview').css('color', 'red');

            $('#p_ECIname').text("Not Scheduled");
            $("#p_ECIname").addClass("text-danger");
            $('#p_ECIname').css('display', 'block');
        }


        $('#div_EC').css('display', 'block');
        $('#txtECComments').prop('disabled', true);
        $("#lblEcfeedback").text("Approved");
        $('#lblEcfeedback').css('color', 'green');
    }

    getrateManager("mgrrat_" + sdata.TLRating.trim());


}

function assignedJobs(jobData) {

    var str = "<div class='d-flex'>" +
        "<div class='col-lg-2 col-md-2 col-sm-3 col-4 text-center' >" +
        "<a href='javascript:;' onclick=addJob(); class='avatar avatar-lg border-1 rounded-circle bg-gradient-primary'>" +
        "<i class='fas fa-plus text-white' aria-hidden='true'></i>" +
        "</a>" +
        "<p class='mb-0 text-sm' style='margin-top: 6px;'>Add to job</p>" +
        "</div >";

    for (var i = 0; i < jobData.length; i++) {

        str += "<div class='col-lg-2 col-md-2 col-sm-3 col-4 text-center' onclick=getcandidateFeedback('" + jobData[i].Jobcode+"')>" +
            "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-success'>" +
            "<img alt='Image placeholder' class='p-1 h-100' src='" + jobData[i].JobMediaPath + "'>" +
            "</a>" +
            "<p class='mb-0 text-sm'>" + jobData[i].JobTitle + "</p>" +
            "</div>";
    }

    str += "</div>";

    $('#div_assignjob').empty();
    $('#div_assignjob').append(str);

}
function addJob() {

    $("#addtojob").modal('show');
}

function gotocandidate() {

    window.location.href = "CandidateIndia.aspx?jobid=" + $('select#drpJobtitle option:selected').val() + "&canid=" + $('#hdncandid').val();
}

function gotoEditCandiate() {

    window.location.href = "CandidateIndia.aspx?id=" + $('#hdncandid').val();
}


function getrateUser(id) {

    //document.getElementById("rat1").classList.remove("inputlayout");
    //document.getElementById("txtEnddate").classList.remove("font_size");

    var count = id.split('_');
    for (var k = 1; k <= 5; k++) {
        document.getElementById(count[0] + "_" + k).classList.remove("ratechecked");
    }


    for (var i = 1; i <= count[1]; i++) {
        if (document.getElementById(count[0] + "_" + i).classList.contains('ratechecked')) {
            document.getElementById(count[0] + "_" + i).classList.remove("ratechecked");
        }
        else {

            document.getElementById(count[0] + "_" + i).classList.add("ratechecked");
        }
    }

    var ratings = document.getElementsByClassName("ratechecked");
    var rateCount = 0;
    for (var i = 0; i < ratings.length; i++) {
        rateCount++;
    }

    //document.getElementById("ContentPlaceHolder1_hdnStarrating").innerHTML = rateCount;

}

function getrateManager(id) {

    //document.getElementById("rat1").classList.remove("inputlayout");
    //document.getElementById("txtEnddate").classList.remove("font_size");

    var count = id.split('_');
    for (var k = 1; k <= 5; k++) {
        document.getElementById(count[0] + "_" + k).classList.remove("ratechecked1");
    }


    for (var i = 1; i <= count[1]; i++) {
        if (document.getElementById(count[0] + "_" + i).classList.contains('ratechecked1')) {
            document.getElementById(count[0] + "_" + i).classList.remove("ratechecked1");
        }
        else {

            document.getElementById(count[0] + "_" + i).classList.add("ratechecked1");
        }
    }

    var ratings = document.getElementsByClassName("ratechecked1");
    var rateCount = 0;
    for (var i = 0; i < ratings.length; i++) {
        rateCount++;
    }
    document.getElementById("TLRating").innerHTML = rateCount;
    //document.getElementById("ContentPlaceHolder1_hdnStarrating").innerHTML = rateCount;

}


function downloadFile(a) {

    
    //var data = new FormData($('#dropBasic1')[0]);
    //data.append($("#" + a.id).text(), "filename");
    //if ((a.id).includes("Resume")) {
    //    data.append("Resume_India", "foldername");
    //}
    //else if ((a.id).includes("Aadhar")) {
    //    data.append("Aadhar_India", "foldername");
    //}
    //else if ((a.id).includes("PAN")) {
    //    data.append("PAN_India", "foldername");
    //}
    //else if ((a.id).includes("Others")) {
    //    data.append("OtherDocuments_India", "foldername");
    //}


    var fileName = "";

    if ((a.id).includes("Resume")) {
        fileName = "Resume_India"+"/" + $("#" + a.id).text();
    }
    else if ((a.id).includes("Aadhar")) {
        fileName = "Aadhar_India" + "/" + $("#" + a.id).text();
    }
    else if ((a.id).includes("PAN")) {
        fileName = "PAN_India" + "/" + $("#" + a.id).text();
    }
    else if ((a.id).includes("Others")) {
        fileName = "OtherDocuments_India" + "/" + $("#" + a.id).text();
    }

    //window.location.href = "http://huntcrew.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    //var str = "https://huntcrew.testing.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    //window.open(str, "_blank");

    var str = "http://huntcrew.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    window.open(str, "_blank");

    //window.location.href = "/api/FileAPI/GetFile?fileName=" + fileName;
    
}



function filedownload(a) {
  
    var lblname = $(a).find('span');
    
    if ((lblname.text()).includes("Resume")) {
        fileName = "Resume_India" + "/" + lblname.text();
    }
    else if ((lblname.text()).includes("Aadhar")) {
        fileName = "Aadhar_India" + "/" + lblname.text();
    }
    else if ((lblname.text()).includes("PAN")) {
        fileName = "PAN_India" + "/" + lblname.text();
    }
    else if ((lblname.text()).includes("Others")) {
        fileName = "OtherDocuments_India" + "/" + lblname.text();
    }

    //window.location.href = "http://huntcrew.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    
    //window.location.href = "/api/FileAPI/GetFile?fileName=" + fileName;
    //var str = "https://huntcrew.testing.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    //window.open(str, "_blank");

    var str = "http://huntcrew.techwaukee.com/api/FileAPI/GetFile?fileName=" + fileName;
    window.open(str, "_blank");

}

