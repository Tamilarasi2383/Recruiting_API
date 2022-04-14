$(document).ready(function () {

    setSession("Page", "Feedback");
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
            getcandidateProfile(params[1], params1[1]);

            $('#hdnjobid').val(params1[1]);
        }
    }

    stopLoader();
});


function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "CANDPROFILEFEEDBACK") {

        $('#hdncandid').val(resData.id);
        $('#lblCandidatename').text(resData.name);
        $('#lblLocation').text(resData.location);
        //getrateUser("mrat_" + resData.candDetail.recruiterrating.trim());

        if (resData.range.negativepercentage == "") {
            resData.range.negativepercentage = "0";
        }

        if (resData.range.positivepercentage == "") {
            resData.range.positivepercentage = "0";
        }

        $('#lblPositive').text(resData.range.positivepercentage + "%");
        $("#div_positive").addClass("w-" + resData.range.positivepercentage);

        $('#lblNegative').text(resData.range.negativepercentage + "%");
        $("#div_negative").addClass("w-" + resData.range.negativepercentage);


        if (resData.projects.length > 0) {
            assignedJobs(resData.projects);
        }
        stopLoader();
    }

    else if (key == "CANDFEEDBACK") {


        if (resData != "") {
            $('#div_candfeedback').css('display', 'block');
            feedback(resData);
        }
        stopLoader();
    }

    else if (key == "SAVECANDCOMMENT") {
        if (resData == "Saved") {
            $("#msgpopup").modal('show');
            stopLoader();
        }
    }


}

function getcandidateProfile(candVal, JobVal) {
    var TWE_Id = getSession('TWE_ID');

    var strdata = { "TWE_Id": TWE_Id, "Userid": candVal, "prjid": JobVal };
    if (TWE_Id != "") {
        common_api_ajax_request("api/FeedbackPageLoad", "CANDPROFILEFEEDBACK", strdata);
    }
}

function getcandidateFeedback(JobVal) {

    var TWE_Id = getSession('TWE_ID');

    var strdata = { "jobId": JobVal, "Candid": $('#hdncandid').val() };
    if (TWE_Id != "") {
        common_api_ajax_request("api/CandidateComments", "CANDFEEDBACK", strdata);
    }
}


function assignedJobs(jobData) {

    //var str = "<div class='d-flex'>" +
    //    "<div class='col-lg-2 col-md-2 col-sm-3 col-4 text-center' >" +
    //    "<a href='javascript:;' onclick=addJob(); class='avatar avatar-lg border-1 rounded-circle bg-gradient-primary'>" +
    //    "<i class='fas fa-plus text-white' aria-hidden='true'></i>" +
    //    "</a>" +
    //    "<p class='mb-0 text-sm' style='margin-top: 6px;'>Add to job</p>" +
    //    "</div >";

    var str = "<div class='row'>";
    for (var i = 0; i < jobData.length; i++) {

        str += "<div class='col-lg-2 col-md-2 col-sm-3 col-4 text-center' onclick=getcandidateFeedback('" + jobData[i].jobid + "')>" +
            "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-success'>" +
            "<img alt='Image placeholder' class='p-1 h-100' src='" + jobData[i].logo + "'>" +
            "</a>" +
            "<p class='mb-0 text-sm'>" + jobData[i].name + "</p>" +
            "</div>";
    }

    str += "</div>";

    $('#div_assignjob').empty();
    $('#div_assignjob').append(str);

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
        $('#btnTLComm').css('display', 'block');
    }
    if (sdata.BPComments != "") {
        $('#div_BPcre').css('display', 'block');
        $('#div_BPupd').css('display', 'block');
        $('#btnBPComm').css('display', 'block');
    }

    if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
        $('#btnBPIComm').css('display', 'block');
    }

    if (sdata.ECIstartdate != "1900-01-01") {
        $('#btnECIComm').css('display', 'block');
    }

    if (sdata.ECComments != "") {
        $('#btnECComm').css('display', 'block');
    }



    $('#p_TLcommdate').text(sdata.TLcomgivenon + "|" + sdata.TLcomgiventime + " EST");

    if (parseInt(sdata.candstatusid) == 103) {
        $('#div_TL').css('display', 'block');
    }

    if (parseInt(sdata.candstatusid) == 104) {
        $('#p_Teamleadname').text("Rejected by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-danger");

        $('#div_TL').css('display', 'block');
        $('input[name="radTLApp"]').prop("checked", false);
        $('input[name="radTLRej"]').prop("checked", true);
        $('input[name="radTLApp"]').prop("disabled", true);
        $('input[name="radTLRej"]').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Rejected");
        $('#lblTlcomments').css('color', 'red');
    }

    else if (parseInt(sdata.candstatusid) == 105) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);

        $('#div_TL').css('display', 'block');
        $('input[name="chkTlcomments"]').prop("checked", true);
        $('input[name="chkTlcomments"]').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Approved");
        $('#lblTlcomments').css('color', 'green');
        $('#div_BPI').css('display', 'block');

    }

    else if (parseInt(sdata.candstatusid) == 106) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Rejected by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-danger");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " EST");
        $('#p_BPcommdate').css('display', 'block');

        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);

        $('#div_TL').css('display', 'block');
        $('input[name="chkTlcomments"]').prop("checked", true);
        $('input[name="chkTlcomments"]').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Approved");
        $('#lblTlcomments').css('color', 'green');

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
            $('#div_BPI').css('display', 'block');
            $('#p_BPIname').text("Scheduled");
            $("#p_BPIname").addClass("text-success");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", true);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $("#lblBpinterview").text("Yes");
            $('#lblBpinterview').css('color', 'green');

            $('#radBPIApp').prop("checked", true);
            $('#radBPIRej').prop("checked", false);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }
        else {
            $('#div_BPI').css('display', 'none');
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            
            
        }

        $('#div_BP').css('display', 'block');
        $('input[name="chkBpfeedback"]').prop("checked", false);
        $('input[name="chkBpfeedback"]').prop("disabled", true);
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
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " EST");
        $('#p_BPcommdate').css('display', 'block');

        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);


        //if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
        //    $('#p_BPIname').text("Scheduled");
        //    $("#p_BPIname").addClass("text-success");
        //    $('#p_BPIname').css('display', 'block');
        //    $('#p_BPIcommdate').css('display', 'block');

        //    $('#radBPIApp').prop("checked", true);
        //    $('#radBPIRej').prop("checked", false);
        //    $('#radBPIApp').prop("disabled", true);
        //    $('#radBPIRej').prop("disabled", true);
        //}

        //else {
        //    $('#p_BPIname').text("Not Scheduled");
        //    $("#p_BPIname").addClass("text-danger");
        //    //$('#p_BPIname').css('display', 'block');
        //    //$('#p_BPIcommdate').css('display', 'block');

        //    $('#radBPIApp').prop("checked", false);
        //    $('#radBPIRej').prop("checked", true);
        //    $('#radBPIApp').prop("disabled", true);
        //    $('#radBPIRej').prop("disabled", true);
        //}

        $('#div_TL').css('display', 'block');
        $('input[name="chkTlcomments"]').prop("checked", true);
        $('input[name="chkTlcomments"]').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Approved");
        $('#lblTlcomments').css('color', 'green');

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
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
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", true);
            $('#radBPIRej').prop("checked", false);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", false);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", false);
            $('#radBPIRej').prop("checked", true);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }

        $('#div_BP').css('display', 'block');
        $('input[id="radBPApp"]').prop("checked", true);
        $('input[id="radBPApp"]').prop("disabled", true);
        $('input[id="radBPRej"]').prop("disabled", true);
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');
        $('#div_ECI').css('display', 'block');



    }
    else if (parseInt(sdata.candstatusid) == 110) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPIname').text("Scheduled");
        $("#p_BPIname").addClass("text-success");
        $('#p_BPIname').css('display', 'block');
        $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
        $('#p_BPIcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Approved");
        $('#lblTlcomments').css('color', 'green');

        $('#div_BPI').css('display', 'block');
        $('input[name="chkBpinterview"]').prop("checked", true);
        $('input[name="chkBpinterview"]').prop("disabled", true);
        $('#txtBIDate').prop('disabled', true);
        $('#txtBITime').prop('disabled', true);
        $("#lblBpinterview").text("Yes");
        $('#lblBpinterview').css('color', 'green');
        $('#div_BP').css('display', 'block');

        $('#radBPIApp').prop("checked", true);
        $('#radBPIRej').prop("checked", false);
        $('#radBPIApp').prop("disabled", true);
        $('#radBPIRej').prop("disabled", true);
    }

    else if (parseInt(sdata.candstatusid) == 111) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");

        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);

        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " EST");
        $('#p_BPcommdate').css('display', 'block');
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " EST");
        $('#p_ECIcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('input[name="chkTlcomments"]').prop("checked", true);
        $('input[name="chkTlcomments"]').prop("disabled", true);
        $('#txtTLComments').prop('disabled', true);
        $("#lblTlcomments").text("Approved");
        $('#lblTlcomments').css('color', 'green');

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
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
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", true);
            $('#radBPIRej').prop("checked", false);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", false);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", false);
            $('#radBPIRej').prop("checked", true);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }

        $('#div_BP').css('display', 'block');

        $('#txtBPComments').prop('disabled', true);
        $('input[id="radBPApp"]').prop("checked", true);
        $('input[id="radBPApp"]').prop("disabled", true);
        $('input[id="radBPRej"]').prop("disabled", true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');
        $('#div_ECI').css('display', 'block');
        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');
            $('#radECIApp').prop("checked", true);
            $('#radECIRej').prop("checked", false);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $("#lblEcinterview").text("Yes");
            $('#lblEcinterview').css('color', 'green');
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);

            $('#radECIApp').prop("checked", false);
            $('#radECIRej').prop("checked", true);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
        }


        $('#div_EC').css('display', 'block');
    }

    else if (parseInt(sdata.candstatusid) == 108) {

        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " EST");
        $('#p_BPcommdate').css('display', 'block');
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " EST");
        $('#p_ECIcommdate').css('display', 'block');
        $('#p_ECname').text("Rejected by " + sdata.BPcomgivenby);
        $("#p_ECname").addClass("text-danger");
        $('#p_ECname').css('display', 'block');
        $('#p_ECcommdate').text(sdata.ECcomgivenon + '|' + sdata.ECcomgiventime + " EST");
        $('#p_ECcommdate').css('display', 'block');

        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);


        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
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
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", true);
            $('#radBPIRej').prop("checked", false);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", false);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", false);
            $('#radBPIRej').prop("checked", true);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }

        $('#div_BP').css('display', 'block');
        $('input[id="radBPApp"]').prop("checked", true);
        $('input[id="radBPApp"]').prop("disabled", true);
        $('input[id="radBPRej"]').prop("disabled", true);
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');
        $('#div_ECI').css('display', 'block');
        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');

            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $('#radECIApp').prop("checked", true);
            $('#radECIRej').prop("checked", false);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);
            $('#radECIApp').prop("checked", false);
            $('#radECIRej').prop("checked", true);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
        }

        $('input[id="radECApp"]').prop("checked", true);
        $('input[id="radECApp"]').prop("disabled", true);
        $('input[id="radECRej"]').prop("disabled", true);
        $('#div_EC').css('display', 'block');
        $('#txtECComments').prop('disabled', true);


    }

    else if (parseInt(sdata.candstatusid) == 109) {
        $('#p_Teamleadname').text("Approved by " + sdata.TLcomgivenby);
        $("#p_Teamleadname").addClass("text-success");

        $('#lblEccreatedondate').text(sdata.ECIcomgivenon);
        $('#lblEccreatedondate').text(sdata.ECIcomgiventime + " EST");
        
        $('#p_BPname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_BPname").addClass("text-success");
        $('#p_BPname').css('display', 'block');
        $('#p_BPcommdate').css('display', 'block');
        $('#p_BPcommdate').text(sdata.BPcomgivenon + '|' + sdata.BPcomgiventime + " EST");
        $('#p_ECIname').text("Scheduled");
        $("#p_ECIname").addClass("text-success");
        $('#p_ECIname').css('display', 'block');
        $('#p_ECIcommdate').text(sdata.ECIcomgivenon + '|' + sdata.ECIcomgiventime + " EST");
        $('#p_ECIcommdate').css('display', 'block');
        $('#p_ECname').text("Approved by " + sdata.BPcomgivenby);
        $("#p_ECname").addClass("text-success");
        $('#p_ECname').css('display', 'block');
        $('#p_ECcommdate').text(sdata.ECcomgivenon + '|' + sdata.ECcomgiventime + " EST");
        $('#p_ECcommdate').css('display', 'block');

        $('#div_TL').css('display', 'block');
        $('#txtTLComments').prop('disabled', true);

        $('#radTLApp').prop("checked", true);
        $('#radTLRej').prop("checked", false);
        $('#radTLApp').prop("disabled", true);
        $('#radTLRej').prop("disabled", true);

        if (sdata.BPIstartdate != "1900-01-01" && sdata.BPITime != "") {
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
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", true);
            $('#radBPIRej').prop("checked", false);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }
        else {
            $('#div_BPI').css('display', 'block');
            $('input[name="chkBpinterview"]').prop("checked", false);
            $('input[name="chkBpinterview"]').prop("disabled", true);
            $('#txtBIDate').prop('disabled', true);
            $('#txtBITime').prop('disabled', true);
            $('#p_BPIname').text("Not Scheduled");
            $("#p_BPIname").addClass("text-danger");
            $('#p_BPIname').css('display', 'block');
            $('#p_BPIcommdate').text(sdata.BPIcomgivenon + '|' + sdata.BPIcomgiventime + " EST");
            $('#p_BPIcommdate').css('display', 'block');

            $('#radBPIApp').prop("checked", false);
            $('#radBPIRej').prop("checked", true);
            $('#radBPIApp').prop("disabled", true);
            $('#radBPIRej').prop("disabled", true);

        }

        $('#div_BP').css('display', 'block');
        $('input[id="radBPApp"]').prop("checked", true);
        $('input[id="radBPApp"]').prop("disabled", true);
        $('input[id="radBPRej"]').prop("disabled", true);
        $('#txtBPComments').prop('disabled', true);
        $("#lblBpfeedback").text("Approved");
        $('#lblBpfeedback').css('color', 'green');

        if (sdata.ECIstartdate != "1900-01-01") {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);

            $('#radECIApp').prop("checked", true);
            $('#radECIRej').prop("checked", false);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
        }
        else {

            $('#div_ECI').css('display', 'block');
            $('#txtdateec').prop('disabled', true);
            $('#txtTimeec').prop('disabled', true);

            $('#radECIApp').prop("checked", false);
            $('#radECIRej').prop("checked", true);
            $('#radECIApp').prop("disabled", true);
            $('#radECIRej').prop("disabled", true);
        }


        $('#div_EC').css('display', 'block');
        $('input[id="radECApp"]').prop("checked", true);
        $('input[id="radECApp"]').prop("disabled", true);
        $('input[id="radECRej"]').prop("disabled", true);
        $('#txtECComments').prop('disabled', true);
        $("#lblEcfeedback").text("Approved");
        $('#lblEcfeedback').css('color', 'green');
    }
    getrateManager("mrat_" + sdata.TLRating.trim());

    $('#txtBIDate').val(sdata.BPIstartdate);
    $('#txtBITime').val(sdata.BPITime);

    $('#txtdateec').val(sdata.ECIstartdate);
    $('#txtTimeec').val(sdata.ECITime);


    $('#txtBPComments').text(sdata.BPComments);
    $('#txtECComments').text(sdata.ECComments);

    $('#txtClosure').text(sdata.CLComments);

    $("#starRecRating").text(sdata.recruiterrating);

    getrateUser("mrrat_" + sdata.recruiterrating.trim());

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

    if ($('#txtTLComments').text() != "") {

        $('#btnTLComm').css('display', 'block');
    }

    else {
        $('#btnTLComm').css('display', 'none');
    }

}

function saveCandComments() {

    if (validateFeedback() == true) {

        var Userid = $('#hdncandid').val();
        var prjid = $('#hdnjobid').val();
        var TLComments = replaceAll(document.getElementById("txtTLComments").value, "'", "''");
        var TLcomgivenby = getSession('TWE_ID');
        var TLRating = $('#TLRating').text();
        var BPIstartdate = $('#txtBIDate').val();
        var BPItime = $('#txtBITime').val();
        var BPIcomgivenby = getSession('TWE_ID');
        var BPComments = replaceAll(document.getElementById("txtBPComments").value, "'", "''");
        var BPcomgivenby = getSession('TWE_ID');
        var ECIstartdate = $('#txtdateec').val();
        var ECItime = $('#txtTimeec').val();
        var ECIcomgivenby = getSession('TWE_ID');
        var ECComments = replaceAll(document.getElementById("txtECComments").value, "'", "''");
        var ECcomgivenby = getSession('TWE_ID');
        //var CLComments = replaceAll(document.getElementById("txtClosure").value, "'", "''");
        //var CLcomgivenby = getSession('TWE_ID');
        var rowid;
        if ($('#hdncommid').text() == "") {
            rowid = "";
        }

        else {
            rowid = "1";
        }


        var Candstatus = "";
        if (($('input[id = "radTLApp"]').is(':disabled') == false) || ($('input[id = "radTLRej"]').is(':disabled') == false)) {
            if ($("#radTLApp").is(":checked") == true) {
                Candstatus = "105";
            }
            else if ($("#radTLRej").is(":checked") == true) {
                Candstatus = "104";
            }

        }

        else if (($('input[id = "radBPIApp"]').is(':disabled') == false) || ($('input[id = "radBPIRej"]').is(':disabled') == false)) {

            if ($("#radBPIApp").is(":checked") == true) {
                Candstatus = "110";
            }
            else {
                if (!($('input[name = "radBPApp"]').is(':disabled')) || !($('input[name = "radBPRej"]').is(':disabled'))) {
                    if ($("#radBPApp").is(":checked") == true) {
                        Candstatus = "107";
                    }
                    else if ($("#radBPRej").is(":checked") == true) {
                        Candstatus = "106";
                    }
                }
            }
        }

        else if (!($('input[id = "radBPApp"]').is(':disabled')) || !($('input[id = "radBPRej"]').is(':disabled'))) {
            if ($("#radBPApp").is(":checked") == true) {
                Candstatus = "107";
            }
            else if ($("#radBPRej").is(":checked") == true) {
                Candstatus = "106";
            }

        }

        //else if (!$('input[name = "chkEcinterview"]').is(':disabled')) {
        else if (!($('input[id = "radECIApp"]').is(':disabled')) || !($('input[id = "radECIRej"]').is(':disabled'))) {
            if ($("#radECIApp").is(":checked") == true) {
                Candstatus = "111";
            }
            else {
                if ($("#radECApp").is(":checked") == true) {
                    Candstatus = "109";
                }
                else if ($("#radECRej").is(":checked") == true) {
                    Candstatus = "108";
                }
            }
        }

        else if (!($('input[id = "radECApp"]').is(':disabled')) || !($('input[id = "radECRej"]').is(':disabled'))) {
            if ($("#radECApp").is(":checked") == true) {
                Candstatus = "109";
            }
            else if ($("#radECRej").is(":checked") == true) {
                Candstatus = "108";
            }
        }

        else if ($('#txtClosure').val() != "") {
            Candstatus = "112";
        }



        if (rowid == "U") {
            var TLupdategivenby = getSession('TWE_ID');
            var BPIupdategivenby = getSession('TWE_ID');
            var BPupdategivenby = getSession('TWE_ID');
            var ECIupdategivenby = getSession('TWE_ID');
            var ECupdategivenby = getSession('TWE_ID');
            var CLupdategivenby = getSession('TWE_ID');
        }

        var strdata = {
            "Userid": Userid, "prjid": prjid, "TLComments": TLComments, "TLcomgivenby": TLcomgivenby,
            "TLRating": TLRating, "BPIstartdate": BPIstartdate, "BPItime": BPItime, "BPIcomgivenby": BPIcomgivenby,
            "BPComments": BPComments, "BPcomgivenby": BPcomgivenby, "ECIstartdate": ECIstartdate,
            "ECItime": ECItime, "ECIcomgivenby": ECIcomgivenby, "ECComments": ECComments,
            "ECcomgivenby": ECcomgivenby,
            "TLupdategivenby": TLupdategivenby, "BPIupdategivenby": BPIupdategivenby, "BPupdategivenby": BPupdategivenby,
            "ECIupdategivenby": ECIupdategivenby, "ECupdategivenby": ECupdategivenby, "CLupdategivenby": CLupdategivenby, "rowid": rowid, "Candstatus": Candstatus
        };
        common_api_ajax_request("api/saveCandidateComments", "SAVECANDCOMMENT", strdata);
    }
}

function rateUser(a) {
    //document.getElementById("rat1").classList.remove("inputlayout");
    //document.getElementById("txtEnddate").classList.remove("font_size");
    var id = a.id;
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
    document.getElementById("starRecRating").innerHTML = rateCount;
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

function enableControl(txtarea1, txtarea2, rad1, rad2) {
    var isDisabled = $('#' + txtarea1).prop('disabled');
    if (isDisabled == true) {
        $('#' + txtarea1).prop('disabled', false);
        $('#' + rad1).prop('disabled', false);
        $('#' + rad2).prop('disabled', false);
    }
    else {
        $('#' + txtarea1).prop('disabled', true);
        $('#' + rad1).prop('disabled', true);
        $('#' + rad2).prop('disabled', true);
    }
    if (txtarea2 != "") {
        var isDisabled2 = $('#' + txtarea2).prop('disabled');
        if (isDisabled2 == true) {
            $('#' + txtarea2).prop('disabled', false);
        }
        else {
            $('#' + txtarea2).prop('disabled', true);
        }
    }
}

function validateFeedback() {

    var count = 0;
    var emptycount = 0;

    //alert($('#txtECComments').is(':disabled'));



    if (($('input[id = "radTLApp"]').is(':disabled') == false) || ($('input[id = "radTLRej"]').is(':disabled') == false)) {

        if (($('textarea[id = "txtTLComments"]').is(':disabled') == false) && $('#txtTLComments').val() == "") {

            $('#txtTLComments').addClass("is-invalid");
            emptycount++;
        }
        else {
            $('#txtTLComments').removeClass("is-invalid");
            count++;
        }

        if ($('#TLRating').text() == "0") {
            $('#lblRatingvali').css('display', 'block');
            emptycount++;
        }
        else {
            $('#lblRatingvali').css('display', 'none');
            count++;
        }

    }


    if (($('input[id = "radBPIApp"]').is(':disabled') == false) || ($('input[id = "radBPIRej"]').is(':disabled') == false)) {

        if (($('input[id = "txtBIDate"]').is(':disabled') == false) && ($('input[id = "txtBITime"]').is(':disabled') == false)) {

            if ($('#txtBIDate').val() == "" || $('#txtBIDate').val() == "1900-01-01") {
                $('#txtBIDate').addClass("is-invalid");
                emptycount++;
            }

            else {
                $('#txtBIDate').removeClass("is-invalid");
                count++;
            }

            if ($('#txtBITime').val() == "") {
                $('#txtBITime').addClass("is-invalid");
                emptycount++;
            }

            else {
                $('#txtBITime').removeClass("is-invalid");
                count++;
            }

        }
    }


    if (($('input[id = "radBPApp"]').is(':disabled') == false) || ($('input[id = "radBPRej"]').is(':disabled') == false)) {

        if (($('textarea[id = "txtBPComments"]').is(':disabled') == false) && $('#txtBPComments').val() == "") {

            $('#txtBPComments').addClass("is-invalid");
            emptycount++;
        }
        else {
            $('#txtBPComments').removeClass("is-invalid");
            count++;
        }
    }


    if (($('input[id = "radECIApp"]').is(':disabled') == false) || ($('input[id = "radECIRej"]').is(':disabled') == false)) {

        if (($('input[id = "txtdateec"]').is(':disabled') == false) && ($('input[id = "txtTimeec"]').is(':disabled') == false)) {

            if ($('#txtdateec').val() == "" || $('#txtdateec').val() == "1900-01-01") {
                $('#txtdateec').addClass("is-invalid");
                emptycount++;
            }

            else {
                $('#txtdateec').removeClass("is-invalid");
                count++;
            }

            if ($('#txtTimeec').val() == "") {
                $('#txtTimeec').addClass("is-invalid");
                emptycount++;
            }

            else {
                $('#txtTimeec').removeClass("is-invalid");
                count++;
            }


        }
    }
       
    if (($('input[id = "radECApp"]').is(':disabled') == false) || ($('input[id = "radECRej"]').is(':disabled') == false)) {

        if (($('textarea[id = "txtECComments"]').is(':disabled') == false) && $('#txtECComments').val() == "") {

            $('#txtECComments').addClass("is-invalid");
            emptycount++;
        }
        else {
            $('#txtECComments').removeClass("is-invalid");
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