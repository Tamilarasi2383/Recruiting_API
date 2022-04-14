var skillVal = "";
var shiftTime = "";
$(document).ready(function () {
    $('#lblEmployeename').text(getSession('Name'));
    $('#hdnJobid').val(getSession('Jobid'));
    $('#lblJobtitle1').text(getSession('JobTitle'));
    $('#lblJobtitle2').text(getSession('JobTitle'));
    $('#lblDuration1').text(getSession('JobDuration'));
    $('#lblDuration2').text(getSession('JobDuration'));
    $('#lblType1').text(getSession('Type'));
    $('#lblType2').text(getSession('Type'));
    $('#lblWorkingtype1').text(getSession('Location'));
    $('#lblWorkingtype2').text(getSession('Location'));
    $("#imgJob1").attr("src", getSession('Jobimg'));
    $("#imgJob2").attr("src", getSession('Jobimg'));
    shiftTime = getSession('ShiftTime');


    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Candidate");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    $('#btnSave').css('display', 'none');

    disableControls();
    disableemplcontrols();
    getSkillData();
    setSession("counter", "1");

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {

        var hash = hashes.split('&');
        if (hash.length == 1) {
            var params1 = hash[0].split("=");
            if (params1[1] == "NoJob") {
                $("#anchDashboard").removeClass("active");
                $("#anchJob").removeClass("active");
                $("#anchCand").addClass("active");

                localStorage.removeItem("JobTitle");
                localStorage.removeItem("Jobid");
                localStorage.removeItem("JobDuration");
                localStorage.removeItem("Location");
                localStorage.removeItem("Jobimg");
                $('#hdnJobid').val("");
                $('#div_job1').css("display", "none");
                $('#div_job2').css("display", "none");
                $('#btnCheck').prop('disabled', false);
                $('#btnRtr').css('display', 'none');
                $('#btnSubmittl').css('display', 'none');
                $('#btnDraft').css('display', 'block');
                $('#btnPipeline').css('display', 'none');
                $('#btnSave').css('display', 'none');

            }
            else {
                $("#anchDashboard").removeClass("active");
                $("#anchJob").removeClass("active");
                $("#anchCand").addClass("active");

                getCandidateData(params1[1]);
                $('#btnRtr').css('display', 'none');

                $('#btnCheck').prop('disabled', 'disabled');
                $('#btUCheckcontactno').prop('disabled', 'disabled');
            }

        }
        else {
            var params1 = hash[0].split("=");
            var params2 = hash[1].split("=");
            getCandidateInfoData(params2[1], params1[1]);

            $('#btnCheck').prop('disabled', 'disabled');
            $('#btUCheckcontactno').prop('disabled', 'disabled');
        }

    }
});


function Validatecandidate() {
    var count = 0;
    var emptycount = 0;

    if ($('#txtEmailid').val() == "") {
        $("#txtEmailid").addClass("is-invalid");
        $('#txtEmailid').focus();
        emptycount++;
    }
    else {
        $("#txtEmailid").removeClass("is-invalid");

        count++;
    }

    if ($('#txtContactno').val() == "") {
        $('#txtContactno').addClass("is-invalid");
        $('#txtContactno').focus();
        emptycount++;
    }
    else {
        $('#txtContactno').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCandidatename').val() == "") {
        $('#txtCandidatename').addClass("is-invalid");
        $('#txtCandidatename').focus();
        emptycount++;
    }
    else {
        $('#txtCandidatename').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCurrentlocation').val() == "") {
        $('#txtCurrentlocation').addClass("is-invalid");
        $('#txtCurrentlocation').focus();
        emptycount++;
    }
    else {
        $('#txtCurrentlocation').removeClass("is-invalid");
        count++;
    }

    if ($('#txtExperience2').val() == "") {
        $('#txtExperience2').addClass("is-invalid");
        $('#txtExperience2').focus();
        emptycount++;
    }
    else {
        $('#txtExperience2').removeClass("is-invalid");
        count++;
    }

    if ($('#txtExperience').val() == "") {
        $('#txtExperience').addClass("is-invalid");
        $('#txtExperience').focus();
        emptycount++;
    }
    else {
        $('#txtExperience').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCurrentcompany').val() == "") {
        $('#txtCurrentcompany').addClass("is-invalid");
        $('#txtCurrentcompany').focus();
        emptycount++;
    }
    else {
        $('#txtCurrentcompany').removeClass("is-invalid");
        count++;
    }


    if ($('#txtstart').val() == "") {
        $('#txtstart').addClass("is-invalid");
        $('#txtstart').focus();
        emptycount++;
    }
    else {
        $('#txtstart').removeClass("is-invalid");
        count++;
    }

    if ($('#txtend').val() == "") {
        $('#txtend').addClass("is-invalid");
        $('#txtend').focus();
        emptycount++;
    }
    else {
        $('#txtend').removeClass("is-invalid");
        count++;
    }

    if ($('#txtRate').val() == "") {
        $('#txtRate').addClass("is-invalid");
        $('#txtRate').focus();
        emptycount++;
    }
    else {
        $('#txtRate').removeClass("is-invalid");
        count++;
    }

    if ($('#drpType').val() == "-1") {
        $('#drpType').addClass("is-invalid");
        $('#drpType').focus();
        emptycount++;
    }
    else {
        $('#drpType').removeClass("is-invalid");
        count++;
    }

    if ($('#drpSkill').val() == "-1") {
        $('#drpSkill').addClass("is-invalid");
        $('#drpSkill').focus();
        emptycount++;
    }
    else {
        $('#drpSkill').removeClass("is-invalid");
        count++;
    }

    //if ($('#txtActivelinkedinurl').val() == "") {
    //    $('#txtActivelinkedinurl').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#txtActivelinkedinurl').removeClass("is-invalid");
    //    count++;
    //}

    if ($('#txtNoticeperiod').val() == "") {
        $('#txtNoticeperiod').addClass("is-invalid");
        $('#txtNoticeperiod').focus();
        emptycount++;
    }
    else {
        $('#txtNoticeperiod').removeClass("is-invalid");
        count++;
    }

    if ($('#txtAvailabelinterview').val() == "") {
        $('#txtAvailabelinterview').addClass("is-invalid");
        $('#txtAvailabelinterview').focus();
        emptycount++;
    }
    else {
        $('#txtAvailabelinterview').removeClass("is-invalid");
        count++;
    }

    if ($('input[name="chkEmployer"]:checked').val() == "on") {

        if ($('#txtEmpmailid').val() == "") {
            $('#txtEmpmailid').addClass("is-invalid");
            $('#txtEmpmailid').focus();
            emptycount++;
        }
        else {
            $('#txtEmpmailid').removeClass("is-invalid");
            count++;
        }

        if ($('#txtEmpcontnumber').val() == "") {
            $('#txtEmpcontnumber').addClass("is-invalid");
            $('#txtEmpcontnumber').focus();
            emptycount++;
        }
        else {
            $('#txtEmpcontnumber').removeClass("is-invalid");
            count++;
        }

        if ($('#txtEmpname').val() == "") {
            $('#txtEmpname').addClass("is-invalid");
            $('#txtEmpname').focus();
            emptycount++;
        }
        else {
            $('#txtEmpname').removeClass("is-invalid");
            count++;
        }

        if ($('#txtCorpationname').val() == "") {
            $('#txtCorpationname').addClass("is-invalid");
            $('#txtCorpationname').focus();
            emptycount++;
        }
        else {
            $('#txtCorpationname').removeClass("is-invalid");
            count++;
        }

        if ($('#txtEmpaddinfo').val() == "") {
            $('#txtEmpaddinfo').addClass("is-invalid");
            $('#txtEmpaddinfo').focus();
            emptycount++;
        }
        else {
            $('#txtEmpaddinfo').removeClass("is-invalid");
            count++;
        }

        if ($('#drpSpecialization').val() == "-1") {
            $('#drpSpecialization').addClass("is-invalid");
            $('#drpSpecialization').focus();
            emptycount++;
        }
        else {
            $('#drpSpecialization').removeClass("is-invalid");
            count++;
        }
    }

    if ($('#txtCandidateremark').val() == "") {
        $('#txtCandidateremark').addClass("is-invalid");
        $('#txtCandidateremark').focus();
        emptycount++;
    }
    else {
        $('#txtCandidateremark').removeClass("is-invalid");
        count++;
    }

    if ($('#lblFilename1').text() == "") {
        $('#divFile').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#divFile').removeClass("is-invalid");
        count++;
    }
    
    if ($('#starRating').text() == "0") {
        $('#vali_star').css('display', 'block');
        emptycount++;
    }
    else {
        $('#vali_star').css('display', 'none');
        count++;
    }

    var skicount = 0;
    $("#drpSkill :selected").each(function () {
        skicount++;
    });

    if (skicount < 5) {
        
        $('#lblAddatlest').css('display', 'block');
        $('#drpSkill').removeClass("form-control");
        $('#drpSkill').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#lblAddatlest').css('display', 'none');
        $('#drpSkill').addClass("form-control");
        $('#drpSkill').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function getCandidateData(candId) {
    var strdata = { "Candidateid": candId };
    if (candId != "") {
        common_api_ajax_request("api/CandidateViewIndia", "EDITCAND", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        alert("fill");
    }
}

function checkifCandExists() {
    var emailid = $("#txtEmailid").val();
    var number = $("#txtContactno").val();
    var strdata = { "emailid": emailid, "number": number };
    if (emailid != "") {
        common_api_ajax_request("api/CandidateCheckIndia", "CHECK", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        alert("fill");
    }
}

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;

    if (key == "CHECK") {
        stopLoader();
        if (resData.candidateemailid != null) {
            setSession("candidatename", resData.candidatename);
            setSession("candidatemobileno", resData.candidatemobileno);
            setSession("candidateemailid", resData.candidateemailid);
            setSession("currentLocation", resData.currentLocation);
            setSession("TotYearsofExp", resData.TotYearsofExp);
            setSession("yrsofexp", resData.yrsofexp);
            setSession("currcompany", resData.currcompany);
            setSession("startdate", resData.startdate);
            setSession("enddate", resData.enddate);
            setSession("ratePerHr", resData.ratePerHr);
            setSession("type", resData.type);
            setSession("skillsandCertif", resData.skillsandCertif);
            setSession("linkedinURL", resData.linkedinURL);
            setSession("noticePeriod", resData.noticePeriod);
            setSession("availableforinterview", resData.availableforinterview);
            setSession("employerid", resData.employerid);
            setSession("employermailid", resData.employermailid);
            setSession("employerContactno", resData.employerContactno);
            setSession("employeename", resData.employeename);
            setSession("corporationname", resData.corporationname);
            setSession("employeradderinformation", resData.employeradderinformation);
            //setSession("candidateRemark", resData.candidateRemark);
            
            if (resData.jobcode == $('#hdnJobid').val()) {
                $("#lblmsg1").text("This Candidate is already assigned to the same job.");
                $("#lblmsg2").text("");
                document.getElementById("div_continue").style.display = "none";
            }
            else {
                $("#lblmsg1").text("This Candidate already exists in the database.");
                $("#lblmsg2").text("If you wish to use the same candidate.Press Continue");
                document.getElementById("div_continue").style.display = "block";

            }
            $("#check").modal('show');
            // $("#btnCheckhid").click();
        }

        else {
            $("#lblmsg1").text("This Candidate does not exists in the database.");
            $("#lblmsg2").text("");
            document.getElementById("div_continue").style.display = "none";
            $("#check").modal('show');
            enableControls();
        }

    }

    else if (key == "EMPLCHECK") {
        stopLoader();
        if (resData.employerid != null) {
            setSession("employerid", resData.employerid);
            setSession("emplmailid", resData.employeremailid);
            setSession("emplContactno", resData.employermobileno);
            setSession("emplname", resData.employername);
            setSession("corpname", resData.employercorporationname);
            setSession("emplspecialization", resData.employerspecialization);
            setSession("emplinformation", resData.employeradditionalinfo);
            $("#checkEmp").modal('show');
        }
        else {
            enableemplcontrols();
        }

    }
    else if (key == "EDITCAND") {

        if (resData.jobcode == "") {

            $('#hdnJobid').val("");
            $('#div_job1').css("display", "none");
            $('#div_job2').css("display", "none");

            $('#btnSubmittl').css('display', 'none');
            $('#btnDraft').css('display', 'block');
            $('#btnPipeline').css('display', 'none');
            $('#btnSave').css('display', 'none');
        }
        else {

            $('#hdnJobid').val(resData.jobcode);
            $('#div_job1').css("display", "flex");
            $('#div_job2').css("display", "flex");
        }

        $('#hdnCandStatus').val(resData.candStatus);
        $("#txtEmailid").val(resData.candidateemailid);
        $("#txtContactno").val(resData.candidatemobileno);
        $("#txtCandidatename").val(resData.candidatename);
        $("#txtCurrentlocation").val(resData.currentLocation);
        $("#txtVisastatus").val(resData.visastatus);
        $("#txtExperience").val(resData.yrsofexp);
        $("#txtExperience2").val(resData.TotYearsofExp);
        $("#txtCurrentcompany").val(resData.currcompany);
        $("#txtstart").val(resData.startdate);
        $("#txtend").val(resData.enddate);
        
        if (resData.employerid=="") {
            $('input[name="chkEmployer"]').prop("checked", false);
        }
        else {
            $('input[name="chkEmployer"]').prop("checked", true);
        }

        $("#txtDocumenttype").val(resData.documenttype);
        $("#txtIdno").val(resData.idNo);
        $("#txtRate").val(resData.ratePerHr);
        $("#drpType").val(resData.type).prop("selected", true);
       
        options = Array.from(document.querySelectorAll('#drpSkill option'));

        resData.skillsandCertif.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
        });

        options1 = Array.from(document.querySelectorAll('#drpSpecialization option'));

        if (resData.employerspecialization!="") {
            resData.employerspecialization.split(',').forEach(function (v) {

                options1.find(c => c.value == v).selected = true;
            });
        }

        if (resData.employerid != "") {
            $('input[name="chkEmployer"]').prop("checked", true);
        }
        else {
            $('input[name="chkEmployer"]').prop("checked", false);
        }


        $("#txtActivelinkedinurl").val(resData.linkedinURL);
        $("#txtNoticeperiod").val(resData.noticePeriod);
        $("#txtAvailabelinterview").val(resData.availableforinterview);
        $("#hdnEmployerid").val(resData.employerid);
        $("#txtEmpmailid").val(resData.employermailid);
        $("#txtEmpcontnumber").val(resData.employerContactno);
        $("#txtEmpname").val(resData.employeename);
        $("#txtCorpationname").val(resData.corporationname);
        $("#txtEmpaddinfo").val(resData.employeradderinformation);
        $("#txtCandidateremark").val(resData.candidateRemark);
        $("#starRating").text(resData.recruiterrating);
        getrateUser("mrat_" + resData.recruiterrating.trim());
        var j = 1;
        for (var i = 0; i < resData.lstCandProof.length; i++) {
            $('#div_Filename'+j).css('display', 'block');
            $("#proofId" + j).val(resData.lstCandProof[i].candproofid);
            $("#drpDocumenttype" + j).val(resData.lstCandProof[i].documenttype).prop("selected", true);
            $("#txtIdno" + j).val(resData.lstCandProof[i].idNo);
            $("#lblFilename" + j).text(resData.lstCandProof[i].idfilename);
            $('#lblFilename' + j).css('display', 'block');
            j++;
        }

        if (resData.lstCandProof.length > 0) {
            $('#btnAdd').prop('disabled', false);
        }
        enableControls();
        enableemplcontrols();
        if (parseInt(resData.candStatus) >= 103) {
            $('#btnSubmittl').css('display', 'none');
            $('#btnDraft').css('display', 'none');
            $('#btnPipeline').css('display', 'none');
            $('#btnSave').css('display', 'block');
        }
        else if (resData.candStatus == "101" || resData.candStatus == "102") {
            $('#btnSave').css('display', 'none');
            
        }
        
        if (resData.rtrStatus == "1") {
            $('#btnRtr').css('display', 'none');
            $('#chkRTR').prop('disabled', false);
        }
        stopLoader();
    }

    else if (key == "CANDINFOIND") {
       
        $('#hdnJobid').val(resData.jobcode);
        $('#lblJobtitle1').text(resData.jobtitle);
        $('#lblJobtitle2').text(resData.jobtitle);
        $('#lblDuration1').text(resData.jobduration);
        $('#lblDuration2').text(resData.jobduration);
        $('#lblType1').text(resData.jobempltype);
        $('#lblType2').text(resData.jobempltype);
        $('#lblWorkingtype1').text(resData.joblocation);
        $('#lblWorkingtype2').text(resData.joblocation);
        $("#imgJob1").attr("src", resData.jobimage);
        $("#imgJob2").attr("src", resData.jobimage);
        shiftTime = resData.shiftTime;

        $("#txtEmailid").val(resData.candidateemailid);
        $("#txtContactno").val(resData.candidatemobileno);
        $("#txtCandidatename").val(resData.candidatename);
        $("#txtCurrentlocation").val(resData.currentLocation);
        $("#txtVisastatus").val(resData.visastatus);
        $("#txtExperience").val(resData.yrsofexp);
        $('#hdnCandStatus').val(resData.candStatus);
        if (resData.legalId == "Yes") {
            $('input[name="chkID"]').prop("checked", true);
        }

        if (resData.documenttype == "Yes") {
            $('input[name="chkRelocate"]').prop("checked", true);
        }
        $("#txtDocumenttype").val(resData.documenttype);
        $("#txtIdno").val(resData.idNo);
        $("#txtRate").val(resData.ratePerHr);
        $("#drpType").val(resData.type).prop("selected", true);
        $("#txtExperience2").val(resData.TotYearsofExp);
        $("#txtCurrentcompany").val(resData.currcompany);
        $("#txtstart").val(resData.startdate);
        $("#txtend").val(resData.enddate);
        options = Array.from(document.querySelectorAll('#drpSkill option'));

        resData.skillsandCertif.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
        });

        $("#txtActivelinkedinurl").val(resData.linkedinURL);
        $("#txtNoticeperiod").val(resData.noticePeriod);
        $("#txtAvailabelinterview").val(resData.availableforinterview);
        $("#hdnEmployerid").val(resData.employerid);
        $("#txtEmpmailid").val(resData.employermailid);
        $("#txtEmpcontnumber").val(resData.employerContactno);
        $("#txtEmpname").val(resData.employeename);
        $("#txtCorpationname").val(resData.corporationname);
        $("#txtEmpaddinfo").val(resData.employeradderinformation);
        

        $("#txtCandidateremark").val(resData.candidateRemark);
        $("#starRating").text(resData.recruiterrating);
        getrateUser("mrat_" + resData.recruiterrating.trim());

        options1 = Array.from(document.querySelectorAll('#drpSpecialization option'));

        if (resData.employerspecialization != "") {
            resData.employerspecialization.split(',').forEach(function (v) {

                options1.find(c => c.value == v).selected = true;
            });
        }

        var j = 1;
        for (var i = 0; i < resData.lstCandProof.length; i++) {
            $('#div_Filename' + j).css('display', 'block');
            $("#proofId" + j).val(resData.lstCandProof[i].candproofid);
            $("#drpDocumenttype" + j).val(resData.lstCandProof[i].documenttype).prop("selected", true);
            $("#txtIdno" + j).val(resData.lstCandProof[i].idNo);
            $("#lblFilename" + j).text(resData.lstCandProof[i].idfilename);
            $('#lblFilename' + j).css('display', 'block');
            j++;
        }

        if (resData.lstCandProof.length>0) {
            $('#btnAdd').prop('disabled', false);
        }

        enableControls();
        enableemplcontrols();

        $('#btnCheck').css('display', 'none');
        $('#btUCheckcontactno').css('display', 'none');

        if (parseInt(resData.candStatus) >= 103) {
            $('#btnSubmittl').css('display', 'none');
            $('#btnDraft').css('display', 'none');
            $('#btnPipeline').css('display', 'none');
            $('#btnSave').css('display', 'block');
        }
        else if (resData.candStatus == "101" || resData.candStatus == "102") {
            $('#btnSave').css('display', 'none');
            $('#btnPipeline').css('display', 'block');
            $('#btnDraft').css('display', 'block');
        }

        if (resData.RTRemailstatus == "1") {
            $('#btnRtr').css('display', 'none');
            $('#chkRTR').prop('disabled', false);
        }
        stopLoader();
    }


    else if (key == "MAIL") {
        $("#rtrcontinue").modal('hide');
        if (response.status == 1) {
            $("#div-message").text('RTR Confirmation mail has been sent');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "btnhidden()");
        }
        stopLoader();
    }

    else if (key == "ADDCANDIND") {
        $("#div-message").text('Candidate information saved successfully');
        $("#msgpopup").modal('show');
        var url = window.location.href;
        var hashes = url.split("?")[1];        
        
        if (hashes != null) {
            var hash = hashes.split('&');
            if (hash.length > 0) {
                var params1 = hash[0].split("=");
                if (params1[1] == "NoJob") {
                    $("#btnOk").attr("onclick", "closepopup('2')");
                }
                else if (isNaN(params1[1]) == false) {
                    $("#btnOk").attr("onclick", "closepopup('2')");
                }
                else {
                    $("#btnOk").attr("onclick", "closepopup('1')");
                }
            }
           
        }
        else {
            $("#btnOk").attr("onclick", "closepopup('1')");
        }
        stopLoader();
    }

    else if (key == "CandidateFormIndia") {
        //document.getElementById("drpSkill").options.length = 0;
        //var option1 = new Option("--Select Skill--", "-1");
        //$(option1).html("--Select Skill--");
        //$("#drpSkill").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }     


        document.getElementById("drpType").options.length = 0;
        var option1 = new Option("--Select Rate Type--", "-1");
        $(option1).html("--Select Rate Type--");
        $("#drpType").append(option1);

        for (var i = 0; i < resData.lstrateType.length; i++) {

            var option = new Option(resData.lstrateType[i].Name, resData.lstrateType[i].ID);

            $(option).html(resData.lstrateType[i].Name);
            $("#drpType").append(option);
        }


        for (var i = 0; i < resData.lstPriority.length; i++) {

            var option = new Option(resData.lstPriority[i].Name, resData.lstPriority[i].ID);

            $(option).html(resData.lstPriority[i].Name);
            $("#drpSpecialization").append(option);
        }
        stopLoader();
       
        //$("#drpSkill").select2();
    
    }

    else if (key == "ADDSKILL") {        
        var skiVal = resData.split(",");
        $('#txtSkill').val("");
        if (skiVal[1] == "Old") {
            $("#addskill").modal('hide');
            $("#div-message").text('Skill you have entered already exists');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            if (skillVal != "") {
                skillVal += "," + skiVal[0];
            }
            else {
                skillVal += skiVal[0];
            }           
        }
        else if (skiVal[1] == "New") {
            $("#addskill").modal('hide');
            $("#div-message").text('Skill has been added successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            if (skillVal != "") {
                skillVal += "," + skiVal[0];
            }
            else {
                skillVal += skiVal[0];
            }
            getTotalSkillData();
        }

        options = Array.from(document.querySelectorAll('#drpSkill option'));
        if (skillVal.includes(",")) {
            skillVal.split(',').forEach(function (v) {
                options.find(c => c.value == v).selected = true;
            });
        }
        else {
            $("#drpSkill").val(skillVal).prop("selected", true);

        }
        skillVal = "";
        stopLoader();
    }

    else if (key == "Skill") {


        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }
        stopLoader();
    }

    
}


function saveCandidate(value) {

    if (Validatecandidate() == true) {
        disablebtn();
        var values1 = "";
        $("#drpSkill :selected").each(function () {
            values1 += this.value + ",";
        });

        var values2 = "";
        $("#drpSpecialization :selected").each(function () {
            values2 += this.value + ",";
        });

        var jobcode = $("#hdnJobid").val();
        var jobtitle = $("#lblJobtitle1").text();
        var candidatename = $("#txtCandidatename").val();
        var currentLocation = $("#txtCurrentlocation").val();
        var candidateemailid = $("#txtEmailid").val();
        var candidatemobileno = $("#txtContactno").val();
        var currentLocation = $("#txtCurrentlocation").val();
        var TotYearsofExp = $("#txtExperience").val();
        var yrsofexp = $("#txtExperience2").val();
        var currcompany = $("#txtCurrentcompany").val();
        var startdate = $("#txtstart").val();
        var enddate = $("#txtend").val();
        var ratePerHr = $("#txtRate").val();
        var type = $('select#drpType option:selected').val();
        var skillsandCertif = values1.substring(0, values1.length - 1);
        var linkedinURL = $("#txtActivelinkedinurl").val();
        var noticePeriod = $("#txtNoticeperiod").val();
        var availableforinterview = $("#txtAvailabelinterview").val();
        var employerid = $("#hdnEmployerid").val();
        var employermailid = $("#txtEmpmailid").val();
        var employerContactno = $("#txtEmpcontnumber").val();
        var employeename = $("#txtEmpname").val();
        var corporationname = $("#txtCorpationname").val();
        var employeradderinformation = $("#txtEmpaddinfo").val();
        var employerspecialization = values2.substring(0, values2.length - 1);
        var candidateRemark = replaceAll(document.getElementById("txtCandidateremark").value, "'", "''");
        var recruiterrating = $("#starRating").text();
        var candStatus;
        if (value == "Submit") {
            candStatus = "103";
        }
        else if (value == "Draft") {
            candStatus = "101";
        }
        else if (value == "Pipeline") {
            candStatus = "102";
        }
        else {
            candStatus= $('#hdnCandStatus').val();
        }

        var docArr = new Array;

        var docObj = {};
        docObj.candproofid = $("#proofId1").val();
        if ($("#proofId1").val() == "") {
            docObj.mode = "insert";
        }
        else if ($("#proofId1").val()!="")  {
            docObj.mode = "update";
        }
        docObj.docType = $('select#drpDocumenttype1 option:selected').val();
        docObj.docNo = $("#txtIdno1").val();
        docObj.filename = $("#lblFilename1").text();
        docArr.push(docObj);


        if ($('select#drpDocumenttype2 option:selected').val() != "-1" && $("#txtIdno1").val() != "") {
            var docObj = {};
            docObj.candproofid = $("#proofId2").val();
            if ($("#proofId2").val() == "") {
                docObj.mode = "insert";
            }
            else {
                docObj.mode = "update";
            }
            docObj.docType = $('select#drpDocumenttype2 option:selected').val();
            docObj.docNo = $("#txtIdno2").val();
            docObj.filename = $("#lblFilename2").text();
            docArr.push(docObj);
        }

        if ($('select#drpDocumenttype3 option:selected').val() != "-1" && $("#txtIdno3").val() != "") {
            var docObj = {};
            docObj.candproofid = $("#proofId2").val();
            if ($("#proofId2").val() == "") {
                docObj.mode = "insert";
            }
            else {
                docObj.mode = "update";
            }
            docObj.docType = $('select#drpDocumenttype3 option:selected').val();
            docObj.docNo = $("#txtIdno3").val();
            docObj.filename = $("#lblFilename3").text();
            docArr.push(docObj);
        }

        if ($('select#drpDocumenttype4 option:selected').val() != "-1" && $("#txtIdno4").val() != "") {
            var docObj = {};
            docObj.candproofid = $("#proofId4").val();
            if ($("#proofId4").val() == "") {
                docObj.mode = "insert";
            }
            else {
                docObj.mode = "update";
            }
            docObj.docType = $('select#drpDocumenttype4 option:selected').val();
            docObj.docNo = $("#txtIdno4").val();
            docObj.filename = $("#lblFilename4").text();
            docArr.push(docObj);
        }

        var Created_By = getSession('TWE_ID');
        var lastupdatedBy = getSession('TWE_ID');

        var url = window.location.href;
        var hashes = url.split("?")[1];
        if (hashes != null) {
            var hash = hashes.split('&');
            var params1 = hash[0].split("=");
        }
        var Mode;
        var candid = "";

        if (hashes != null) {
            var hash = hashes.split('&');
            var params1 = hash[0].split("=");

            if (hash.length == 2) {
                var params1 = hash[0].split("=");
                var params2 = hash[1].split("=");
                Mode = "update";
                candid = params2[1];
            }

            else if (params1[1] == "NoJob") {
                Mode = "insert";
                candid = "";
            }
            else {
                Mode = "update";
                candid = params1[1];
            }

        }

        else {
            Mode = "insert";
            candid = "";
        }

        var strdata = {
            "jobcode": jobcode, "candidatename": candidatename, "currentLocation": currentLocation, "candidateemailid": candidateemailid,
            "candidatemobileno": candidatemobileno, "TotYearsofExp": TotYearsofExp, "yrsofexp": yrsofexp, "currcompany": currcompany, "startdate": startdate,
            "enddate": enddate, "ratePerHr": ratePerHr, "type": type, "skillsandCertif": skillsandCertif, "linkedinURL": linkedinURL,
            "noticePeriod": noticePeriod, "availableforinterview": availableforinterview, "employerid": employerid, "employermailid": employermailid,
            "employerContactno": employerContactno, "employeename": employeename, "corporationname": corporationname, "recruiterrating": recruiterrating,
            "employeradderinformation": employeradderinformation, "employerspecialization": employerspecialization, "candidateRemark": candidateRemark, "candStatus": candStatus,
            "createdBy": Created_By, "mode": Mode, "candidateid": candid, "documents": docArr, "jobtitle": jobtitle, "lastupdatedBy": lastupdatedBy
        };
        common_api_ajax_request("api/CandidateIndia", "ADDCANDIND", strdata);
    }
}

function disableControls() {
    $('#txtCandidatename').prop('disabled', 'disabled');
    $('#txtCurrentlocation').prop('disabled', 'disabled');
    $('#txtExperience').prop('disabled', 'disabled');
    $('#txtExperience2').prop('disabled', 'disabled');
    $('#txtCurrentcompany').prop('disabled', 'disabled');
    $('#txtstart').prop('disabled', 'disabled');
    $('#txtend').prop('disabled', 'disabled');
    $('#txtRate').prop('disabled', 'disabled');
    $('#drpType').prop('disabled', 'disabled');
    $('#drpSkill').prop('disabled', 'disabled');
    $('#txtActivelinkedinurl').prop('disabled', 'disabled');
    $('#txtNoticeperiod').prop('disabled', 'disabled');
    $('#txtAvailabelinterview').prop('disabled', 'disabled');
    $('#txtEmpmailid').prop('disabled', 'disabled');
    $('#txtEmpcontnumber').prop('disabled', 'disabled');


    $('#chkEmployer').prop('disabled', 'disabled');
    $('#btnRtr').prop('disabled', 'disabled');
    $('#btUpload').prop('disabled', 'disabled');
    $('#btnSubmittl').prop('disabled', 'disabled');
    $('#btnDraft').prop('disabled', 'disabled');
    $('#btnPipeline').prop('disabled', 'disabled');
}


function enableControls() {
    $('#txtCandidatename').prop('disabled', false);
    $('#txtCurrentlocation').prop('disabled', false);
    $('#txtCurrentcompany').prop('disabled', false);
    $('#txtExperience').prop('disabled', false);
    $('#txtExperience2').prop('disabled', false);
    $('#txtstart').prop('disabled', false);
    $('#txtend').prop('disabled', false);
    $('#txtRate').prop('disabled', false);
    $('#drpType').prop('disabled', false);
    $('#drpSkill').prop('disabled', false);
    $('#txtActivelinkedinurl').prop('disabled', false);
    $('#txtNoticeperiod').prop('disabled', false);
    $('#txtAvailabelinterview').prop('disabled', false);
    $('#txtEmpmailid').prop('disabled', false);
    $('#txtEmpcontnumber').prop('disabled', false);
    $('#txtCandidateremark').prop('disabled', false);
    $('#chkEmployer').prop('disabled', false);
    $('#btnRtr').prop('disabled', false);
    $('#btUpload').prop('disabled', false);
    $('#btnDraft').prop('disabled', false);
    $('#btnPipeline').prop('disabled', false);
}


function fillEmpData() {

    $("#hdnEmployerid").val(getSession('employerid'));
    $("#txtEmpcontnumber").val(getSession('emplContactno'));
    $("#txtEmpmailid").val(getSession('emplmailid'));
    $("#txtEmpname").val(getSession('employeename'));
    $("#txtSpecilization").val(getSession('emplspecialization'));
    $("#txtCorpationname").val(getSession('corpname'));
    $("#txtEmpaddinfo").val(getSession('employeradderinformation'));
    enableemplcontrols();
    $("#checkEmp").modal('hide');

}

function enableemplcontrols() {

    $('#txtEmpname').prop('disabled', false);
    $('#txtCorpationname').prop('disabled', false);
    $('#txtEmpaddinfo').prop('disabled', false);
    $('#txtCandidateremark').prop('disabled', false);
    $('#drpSpecialization').prop('disabled', false);
    $('#txtDocument').prop('disabled', false);
}

function disableemplcontrols() {
    $('#txtEmpname').prop('disabled', 'disabled');
    $('#drpSpecialization').prop('disabled', 'disabled');
    $('#txtCorpationname').prop('disabled', 'disabled');
    $('#txtEmpaddinfo').prop('disabled', 'disabled');
    $('#txtCandidateremark').prop('disabled', 'disabled');
    $('#txtDocument').prop('disabled', 'disabled');
}

function fillData() {


    $("#txtCandidatename").val(getSession('candidatename'));
    $("#txtContactno").val(getSession('candidatemobileno'));
    $("#txtEmailid").val(getSession('candidateemailid'));
    $("#txtCurrentlocation").val(getSession('currentLocation'));
    $("#txtExperience2").val(getSession('TotYearsofExp'));
    $("#txtExperience").val(getSession('yrsofexp'));
    $("#txtCurrentcompany").val(getSession('currcompany'));
    $("#txtstart").val(getSession('startdate'));
    $("#txtend").val(getSession('enddate'));
    if (getSession('legalId') == "Yes") {
        $('input[name="chkID"]').prop("checked", true);
    }

    if (getSession('relocate') == "Yes") {
        $('input[name="chkRelocate"]').prop("checked", true);
    }
    $("#txtDocumenttype").val(getSession('documenttype'));
    $("#txtIdno").val(getSession('idNo'));
    $("#txtRate").val(getSession('ratePerHr'));
    $("#drpType").val(getSession('type')).prop("selected", true);


    options1 = Array.from(document.querySelectorAll('#drpSkill option'));

   

              
    $("#txtActivelinkedinurl").val(getSession('linkedinURL'));
    $("#txtNoticeperiod").val(getSession('noticePeriod'));
    $("#txtAvailabelinterview").val(getSession('availableforinterview'));
    $("#txtEmpmailid").val(getSession('employermailid'));
    $("#txtEmpcontnumber").val(getSession('employerContactno'));
    $("#txtEmpname").val(getSession('employeename'));
    $("#txtCorpationname").val(getSession('corporationname'));
    $("#txtEmpaddinfo").val(getSession('employeradderinformation'));
    //$("#txtCandidateremark").val(getSession('candidateRemark'));
    enableControls();
    enableemplcontrols();
    getSession('skillsandCertif').split(',').forEach(function (v) {
        //options1[0].selected = true;
        var opt = options1.find(c => c.value == 11001);
        opt.selected = true;
    });

    $("#check").modal('hide');

}
function enableData() {
    enableControls();
}

$('#fileupload1').on('change', function () {
    var fileupload = document.getElementById("fileupload1");
    if (fileupload.value != "") {
        var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];
        checkFileExtension(fileName, "fileupload1", "1");
        //$('#btnAttach1').css('display', 'none');
    }


});

$('#fileupload2').on('change', function () {
    var fileupload = document.getElementById("fileupload2");
    if (fileupload.value != "") {
        var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];
        checkFileExtension(fileName, "fileupload2", "2");
        //$('#btnAttach2').css('display', 'none');
    }
});

$('#fileupload3').on('change', function () {
    var fileupload = document.getElementById("fileupload3");
    if (fileupload.value != "") {
        var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];
        checkFileExtension(fileName, "fileupload3", "3");
        //$('#btnAttach3').css('display', 'none');
    }
});

$('#fileupload4').on('change', function () {
    var fileupload = document.getElementById("fileupload4");
    if (fileupload.value != "") {
        var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];
        checkFileExtension(fileName, "fileupload4", "4");
        //$('#btnAttach4').css('display', 'none');
    }
});

function checkFileExtension(fileName, ctrlName, counter) {
    var fileExt = fileName.split('.');
    if (fileExt[1] == "doc" || fileExt[1] == "docx" || fileExt[1] == "pdf" || fileExt[1] == "DOC" || fileExt[1] == "DOCX" || fileExt[1] == "PDF") {
        // filePath.innerHTML = "<b>Document Attached: </b>" + fileName;
        // document.getElementById("ContentPlaceHolder1_txtFilename").value = fileName;
        checkFileSize(ctrlName, counter);
        //return true;
    }
    else {
        // alert("Upload only doc or pdf files");
        $("#div-message").text('Upload only doc or pdf files');
        $("#msgpopup").modal('show');

        if (ctrlName == "fileupload1") {
            $('#btnAttach1').css('display', 'block');
        }
        else if (ctrlName == "fileupload2") {
            $('#btnAttach2').css('display', 'block');
        }
        else if (ctrlName == "fileupload3") {
            $('#btnAttach3').css('display', 'block');
        }
        else if (ctrlName == "fileupload4") {
            $('#btnAttach4').css('display', 'block');
        }

        return false;

    }
}

function checkFileSize(ctrlName, counter) {
    var fi = document.getElementById(ctrlName);
    // Check if any file is selected.
    if (fi.files.length > 0) {
        //for (var i = 0; i <= fi.files.length - 1; i++) {

        const fsize = fi.files.item(0).size;
        const file = Math.round((fsize / 1024));

        // The size of the file.
        //if (file >= 4096) {
        //    alert(
        //      "File too Big, please select a file less than 4mb");
        //} 
        if (file >= 2048) {
            //alert("File too Big, please select a file less than 2MB");
            $("#div-message").text('File too Big, please select a file less than 2MB');
            $("#msgpopup").modal('show');

            if (ctrlName == "fileupload1") {
                $('#btnAttach1').css('display', 'block');
            }
            else if (ctrlName == "fileupload2") {
                $('#btnAttach2').css('display', 'block');
            }
            else if (ctrlName == "fileupload3") {
                $('#btnAttach3').css('display', 'block');
            }
            else if (ctrlName == "fileupload4") {
                $('#btnAttach4').css('display', 'block');
            }
            //document.getElementById('lblimgError').style.display = "block";
            //document.getElementById('lblimgError').innerHTML = "File too Big, please select a file less than 2MB";
            //document.getElementById('ContentPlaceHolder1_btnFileUpload').disabled = true;
            return false;
            // alert("File too Big, please select a file less than 2mb");
        }

        else {
            //document.getElementById('lblimgError').style.display = "none";
            //document.getElementById('ContentPlaceHolder1_btnFileUpload').disabled = false;
            var fileupload = document.getElementById(ctrlName);
            var fileName = fileupload.value.split('\\')[fileupload.value.split('\\').length - 1];

            $('#lblFilename' + counter).text(fileName);
            $('#div_Filename' + counter).css('display', 'block');
            //$('#btUpload' + counter).css('display', 'block');
            $('#btUpload' + counter).click();
            //var str = 'btUpload' + counter;
            //$(str).click();
            //document.getElementById(str).click();
            //return true;
        }
        //}
    }
}

function uploadFile(i) {
    var count = 0;
    var emptycount = 0;
    if ($('#txtCandidatename').val() == "") {
        $('#txtCandidatename').addClass("is-invalid");
        $('#txtCandidatename').focus();
        return false;
    }
    else {
        $('#txtCandidatename').removeClass("is-invalid");

        if (i > 1) {

            if ($('#drpDocumenttype' + i).val() == "-1") {
                $('#drpDocumenttype' + i).addClass("is-invalid");
                $('#drpDocumenttype' + i).focus();
                emptycount++;
            }

            else {
                $('#drpDocumenttype' + i).removeClass("is-invalid");
                count++;
            }

            if ($('#txtIdno' + i).val() == "") {
                $('#txtIdno' + i).addClass("is-invalid");
                $('#txtIdno' + i).focus();
                emptycount++;
            }
            else {
                $('#txtIdno' + i).removeClass("is-invalid");
                count++;
            }

            if (parseInt(emptycount) > 0) {
                return false;
            }

            else if (parseInt(count) > 0) {
                document.getElementById('fileupload' + i).click();
            }


        }

        else {
              document.getElementById('fileupload' + i).click();
        }
    }

    
    
    
}

function AddMore() {

    var counter = parseInt(getSession('counter')) + 1;
    setSession("counter", counter);
    if (counter == 2) {

        $('#divAttach2').css('display', 'block');
    }
    else if (counter == 3) {

        $('#divAttach3').css('display', 'block');
    }
    else if (counter == 4) {

        $('#divAttach4').css('display', 'block');
    }
    //var strDiv = "";
    //strDiv += "<div class='col- md-12' style='height: 70px;' id='divAttach_" + counter +"'>"+
    //            "<div class='row'>" +
    //            "<div class='col-md-3'><label class='form-label'>Document Type</label>"+
    //            "<input class='form-control' type='text' placeholder='Document Type' id='txtDocumenttype_" + counter+"'>"+
    //            "</div><div class='col-md-3'><label class='form-label'>ID No.</label>"+
    //            "<input class='form-control' type='text' placeholder='Id Number' id='txtIdno_'" + counter+">"+
    //            "</div><div class='col-md-6'><div class='row' style='margin-top: 36px;'>"+
    //            "<div class='col-md-8'><form action='' id='dropBasic_" + counter+"' style='min-height: 117px !important;'>"+
    //            "<button id='btnAttach_"+counter+"' class='btn bg-gradient-primary mb-0 ps-0 pt-0' type='button' style='background:none !important; box-shadow: none !important; color: #21dcfc;' onclick='uploadFile();'>"+
    //            "<span class='btn-inner--icon'><i class='fa fa-paperclip' aria-hidden='true' style='font-size:20px;'></i></span>"+
    //            "</button><span id='lblFilename_" + counter + "'></span><input name='file' id='fileupload_" + counter+"' type='file' style='display:none;' />"+
    //            "</form></div><div class='col-md-2'>"+
    //            "<button id='btUpload_" + counter+"' class='btn bg-gradient-primary mb-0 ps-0 pt-0' type='button' style='background: none !important; box-shadow: none !important; color:#21dcfc; display:none;'>"+
    //            "<span class='btn-inner--icon'><i class='fas fa-upload' style='font-size: 20px;'></i></span>"+
    //            "</button></div></div></div></div></div>";

    //$('#divFile').append(strDiv);

}


function checkifEmplExists() {
    var emailid = $("#txtEmpmailid").val();
    var number = $("#txtEmpcontnumber").val();
    var strdata = { "emailid": emailid, "number": number };
    if (emailid != "") {
        common_api_ajax_request("api/EmployerCheck", "EMPLCHECK", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        alert("fill");
    }
}


$("#btUpload1").click(function () {

    var f1 = $("#txtCandidatename").val().trim();
    
    var data = new FormData($('#dropBasic1')[0]);
    data.append("Resume_India", "1");
    data.append(f1, "file_name");
    $.ajax({
        type: "POST",
        url: '/api/FileUpload/',    // CALL WEB API TO SAVE THE FILES.
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,         // PREVENT AUTOMATIC DATA PROCESSING.
        cache: false,
        data: data, 		        // DATA OR FILES IN THIS CONTEXT.
        success: function (data, textStatus, xhr) {

            $('#lblFilename1').text(data.data.fileName);

            $("#div-message").text('Resume Uploaded Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            $('#btremove1').css('display', 'block');
            $('#btnAdd').prop('disabled', false);
            
            
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btUpload2").click(function () {

    var data = new FormData($('#dropBasic2')[0]);
    var f1 = $("#txtCandidatename").val().trim();

    if ($('select#drpDocumenttype2 option:selected').text() == "Aadhar") {
        data.append("Aadhar_India", "1");
    }
    else if ($('select#drpDocumenttype2 option:selected').text() == "PAN") {
        data.append("PAN_India", "1");
    }
    else if ($('select#drpDocumenttype2 option:selected').text() == "Others") {
        data.append("OtherDocuments_India", "1");
    }

   
    data.append(f1, "file_name");
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
            $('#lblFilename2').text(data.data.fileName);
            $("#div-message").text('File Uploaded Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            $('#btremove2').css('display', 'block');
            $('#btdelete2').css('display', 'none');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btUpload3").click(function () {

    var data = new FormData($('#dropBasic3')[0]);
    var f1 = $("#txtCandidatename").val().trim();

    if ($('select#drpDocumenttype3 option:selected').text() == "Aadhar") {
        data.append("Aadhar_India", "1");
    }
    else if ($('select#drpDocumenttype3 option:selected').text() == "PAN") {
        data.append("PAN_India", "1");
    }
    else if ($('select#drpDocumenttype3 option:selected').text() == "Others") {
        data.append("OtherDocuments_India", "1");
    }

    data.append(f1, "file_name");
    $.ajax({
        type: "POST",
        url: '/api/FileUpload/',    // CALL WEB API TO SAVE THE FILES.
        enctype: 'multipart/form-data',
        contentType: false,
        processData: false,         // PREVENT AUTOMATIC DATA PROCESSING.
        cache: false,
        data: data, 		        // DATA OR FILES IN THIS CONTEXT.
        success: function (data, textStatus, xhr) {
            $('#lblFilename3').text(data.data.fileName);
            $("#div-message").text('File Uploaded Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            $('#btremove3').css('display', 'block');
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btUpload4").click(function () {

    var data = new FormData($('#dropBasic4')[0]);
    var f1 = $("#txtCandidatename").val().trim();

    if ($('select#drpDocumenttype4 option:selected').text() == "Aadhar") {
        data.append("Aadhar_India", "1");
    }
    else if ($('select#drpDocumenttype4 option:selected').text() == "PAN") {
        data.append("PAN_India", "1");
    }
    else if ($('select#drpDocumenttype4 option:selected').text() == "Others") {
        data.append("OtherDocuments_India", "1");
    }

    data.append(f1, "file_name");
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
            $('#lblFilename4').text(data.data.fileName);
            $("#div-message").text('File Uploaded Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            $('#btremove4').css('display', 'block');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btremove1").click(function () {

    var f1 = $('#lblFilename1').text();

    var data = new FormData($('#dropBasic1')[0]);
    data.append("Resume_India", "1");
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

            $('#lblFilename1').text("");
            $('#btnAttach1').css('display', 'block');        
            $('#btremove1').css('display', 'none');
            $('#div_Filename1').css('display', 'none');            
            $("#div-message").text('Resume Deleted Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            //$('p').text(data);
        },          
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btremove2").click(function () {

    var f1 = $('#lblFilename2').text();

    var data = new FormData($('#dropBasic2')[0]);
    data.append("Aadhar_India", "1");
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

            $('#lblFilename2').text("");
            $('#txtIdno2').val("");
            $("#drpDocumenttype2").val("-1").prop("selected", true);
            $('#btnAttach2').css('display', 'block');
            $('#btremove2').css('display', 'none');
            $('#btdelete2').css('display', 'block');
            $('#div_Filename2').css('display', 'none');
            $("#div-message").text('Resume Deleted Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btremove3").click(function () {

    var f1 = $('#lblFilename3').text();

    var data = new FormData($('#dropBasic3')[0]);
    data.append("PAN_India", "1");
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

            $('#lblFilename3').text("");
            $('#btnAttach3').css('display', 'block');
            $('#btremove3').css('display', 'none');
            $('#btdelete3').css('display', 'block');
            $('#div_Filename3').css('display', 'none');
            $("#div-message").text('Resume Deleted Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});

$("#btremove4").click(function () {

    var f1 = $('#lblFilename4').text();

    var data = new FormData($('#dropBasic4')[0]);
    data.append("OtherDocuments_India", "1");
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

            $('#lblFilename4').text("");
            $('#btnAttach4').css('display', 'block');
            $('#btremove4').css('display', 'none');
            $('#btdelete4').css('display', 'block');
            $('#div_Filename4').css('display', 'none');
            $("#div-message").text('Resume Deleted Successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            //$('p').text(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(textStatus + ': ' + errorThrown);
        }
    });
});


function getRTRdata() {
    if (Validatecandidate() == true) {
        $("#rtr").modal('show');
        $("#txtMailFrom").val(getSession('Mailid'));
        $("#txtMailto").val($("#txtEmpmailid").val());
        $("#txtSubject").val("RTR Confirmation Request" + "-" + $("#lblJobtitle1").text() + "-" + $("#txtCandidatename").val());
        //var strData = "Hi " + $("#txtEmpname").val() + ",<br/>" +
        //    "I _________ residing in _______ hereby confirm for <b>" + "$" + $("#txtRate").val() + "/ Hr on " + $("#txtType").val() + "</b> and <br/>authorize Techwaukee Private Ltd as an exclusive representative of my <br/> candidature for the position of <b>" + $("#lblJobtitle1").text() + "</b> at <b>" + getSession('City') + ", " + getSession('State') +"("+ $("#lblWorkingtype1").text() +")</b>" +
        //    ".<br/>I will not approach the client directly or indirectly and I ______ confirm that <br/>I haven’t submitted my resume for this specific position to any other client/staffing vendor.<br/><br/>" +
        //    "Techwaukee:<br/><br/>" +
        //    "We are into Product Development, IT Consulting Services & Offshore staff <br/> Augmentation.Our Mission is to develop outstanding products with highly skilled<br/> IT professionals, providing quality service and customer management to <br/> determine long term relationship.We also provide skilled and experienced <br/>consultants in various technologies, they handle critical problem in an excellent way.<br/>";

        var compData = "";

        if ($('select#drpType option:selected').val() == 10000) {
            compData = "<li><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Compensation:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b>&nbsp;</b></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $('#txtRate').val() + "</span></span></span><b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>INR per day" +". For e.g., if you work 21 days * in a month = " + $('#txtRate').val() + " * 21 = " + parseInt($('#txtRate').val()) * parseInt(21) + " INR ( 10% TDS deduction on PAN card)</span></span></span></span></span><br>";
        }

        else if ($('select#drpType option:selected').val() ==10001) {
            compData = "<li><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Compensation:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b>&nbsp;</b></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $('#txtRate').val() + "</span></span></span><b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>INR per week" + ". For e.g., if you work 10 hrs * in a week = " + $('#txtRate').val() + " * 10 = " + parseInt($('#txtRate').val()) * parseInt(21) + " INR ( 10% TDS deduction on PAN card)</span></span></span></span></span><br>";
        }

        else if ($('select#drpType option:selected').val() ==10004) {
            compData = "<li><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Compensation:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b>&nbsp;</b></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $('#txtRate').val() + "</span></span></span><b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>INR per hour" + ". For e.g., if you work 8 hours * in a month = " + $('#txtRate').val() + " * 8 = " + parseInt($('#txtRate').val()) * parseInt(8) + " INR ( 10% TDS deduction on PAN card)</span></span></span></span></span><br>";
        }
        else {
            compData = "<li><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Compensation:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b>&nbsp;</b></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $('#txtRate').val() + "</span></span></span><b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>INR " + $('select#drpType option:selected').text() +"</span></span></span></span></span><br>";
        }



        var strData = "<div style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 10pt;'>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 13.3333px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; background-color: rgb(255, 255, 255);'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Hi " + $("#txtCandidatename").val() + ",</span><br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 13.3333px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; background-color: rgb(255, 255, 255);'>" +
            "<br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255);'>" +
            "<div style='color: rgb(0, 0, 0); font-style: normal; font-weight: 400; letter-spacing: normal; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 13.3333px; background-color: rgb(255, 255, 255);'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<div>" +
            "<blockquote style='margin: 0px;'>" +
            "<div style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 10pt;'>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255);'><span class='x_203648327font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>As discussed, Kindly give me your confirmation to proceed further submitting your resume to the client for '</span></span></span></span></span><b><span class='x_203648327font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $("#lblJobtitle1").text() + "</span></span></span></span></span></b><span class='x_203648327font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>' position.</span></span></span></span></span><span><span class='x_203648327font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span></span><span class='x_203648327colour' style='color: rgb(0, 0, 0);'><span class='x_203648327font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Also, Please confirm that you have not submitted your resume or application for this specific position to any other staffing vendor within the last thirty (30) days, nor have you the signed a Right to Represent form with another staffing vendor for this job requisition.</span></span></span></span></span></span><br>" +
            "</div>" +
            "</div>" +
            "</blockquote>" +
            "</div>" +
            "</span></div>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); visibility: visible; line-height: normal;'>" +
            "<br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'><b style='font-family: roboto;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><u>Please confirm the email with below required details .</u></span></span></span></span></b><u><br>" +
            "</u></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'>" +
            "<br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><b><span class='x_203648327font' style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>Full Legal Name:</span></span></span></span></span></span></span></b></span><span class='x_203648327colour' style='color: #000000;'><br>" +
            "</span></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><b><span class='x_203648327font' style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>Current Location:</span></span></span></span></span></span></span></b></span><span class='x_203648327colour' style='color: #000000;'><br>" +
            "</span></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><b><span class='x_203648327font' style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>Emergency Contact Number from Family:</span></span></span></span></span></span></span></b></span><span class='x_203648327colour' style='color: #000000;'><br>" +
            "</span></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><b><span class='x_203648327font' style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>Relationship :</span></span></span></span></span></span></span></b></span><span class='x_203648327colour' style='color: #000000;'><br>" +
            "</span></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal; text-align: left;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif,  sans-serif;'><span class='x_203648327size' style='font-size: 13px;'><span class='x_203648327highlight' style='background-color: rgb(254, 255, 0);'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>Please share any one of your Government ID proof for</span></span><span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>&nbsp;</span></span></span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>identifi</span></span></span></span></span><span class='x_203648327highlight' style='background-color: rgb(254, 255, 0);'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><span class='x_203648327colour' style='color: #000000;'>cation at the time of interview.</span></span></span></b></span></span></span></span></span></span></span></span></span><span class='x_203648327colour' style='color: #000000;'><br>" +
            "</span></div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal; text-align: left;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span style='line-height: normal;'><span><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: verdana,  sans-serif,  sans-serif;'><span class='x_203648327size' style='font-size: 13px;'><span class='x_203648327highlight' style='background-color: rgb(255, 255, 255);'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b><span class='x_203648327colour' style='color: #000000;'>Interview Mode: </span></b><span class='x_203648327colour' style='color: #000000;'>Video</span></span></span></span></span></span></span></span></span></span></span></span></span></span><br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255); line-height: normal; text-align: left;'>" +
            "<br>" +
            "</div>" +
            "<div style='color: rgb(0, 0, 0); font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; font-size: 13.3333px; background-color: rgb(255, 255, 255);'>" +
            "<div style='color: rgb(0, 0, 0); font-style: normal; font-weight: 400; letter-spacing: normal; text-indent: 0px; text-transform: none; white-space: normal; word-spacing: 0px; font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 13.3333px; background-color: rgb(255, 255, 255);'>" +
            "<div>" +
            "<blockquote style='margin: 0px;'>" +
            "<div style='font-family: Verdana,  Arial,  Helvetica,  sans-serif; font-size: 10pt;'>" +
            "<ul dir='ltr'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Role:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $("#lblJobtitle1").text() + "-" + $("#lblType1").text() + "</span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Duration:</span></span></span></b><span><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $("#lblDuration1").text() + "</span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Location:</span></span></span><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" + $("#lblWorkingtype1").text() + "</span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Shift Timings:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;" + shiftTime + "</span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span style='line-height: normal;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Leaves:</span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span style='line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>If you're taking any leaves and you need to inform us and client with the prior notice</span></span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span style='line-height: normal;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Payment Date:</span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span style='line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Every Month 5th</span></span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span style='line-height: normal;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Notice:</span></span></span></span><span style='line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>4 Weeks</span></span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span style='line-height: normal;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Assets:</span></span></span></span><span style='line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>None</span></span></span></span></span></span><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>-&nbsp;</span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>the selected candidate has to use their own laptop for this project.</span></span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span style='line-height: normal;'><b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Timesheet:</span></span></span></span><span style='line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>&nbsp;</span></span></span></span></span></span></span></b><span class='x_203648327font' style='font-family: verdana,  sans-serif; line-height: normal;'><span class='x_203648327font' style='font-family: roboto; line-height: normal;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Approved timesheet has to be submitted on every month on time to credit the salary.</span></span></span></span></span></span></span><br>" +
            "</li>" +
            "</span><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>" +
            "<li><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span><b><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'>Start:</span></span></span></b><span><span class='x_203648327font' style='font-family: verdana,  sans-serif;'><span class='x_203648327size' style='font-size: 13.3333px;'><span class='x_203648327font' style='font-family: arial,  helvetica,  sans-serif,  sans-serif;'><b>&nbsp;</b>Immediate</span></span></span></span></span></span><br>" +
            "</li>" +
            "</span>" +
            compData+
            "</li>" +
            "</ul>" +
            "</div>" +
            "</blockquote>" +
            "</div>" +
            "</div>" +
            "</div>" +
            "</div>";


        $("#txtMaildescriptioncont").empty();
        $("#txtMaildescriptioncont").append(strData);
        $("#txtMailcont").val($("#txtMaildescriptioncont").text());
    }
    //$("#txtMailcont").text(strData);

}



function sendRTRMail() {
    var fromAddr = $("#txtMailFrom").val();
    var toAddr = $("#txtMailto").val();
    var ccAddr = $("#txtCC").val();
    var subject = $("#txtsubject").val();
    var Description = document.getElementById("txtMaildescription").innerHTML;
    var jobcode = $("#hdnJobid").val();
    var candidateemailid = $("#txtEmailid").val();
    var employeremaildid = $("#txtEmpmailid").val();

    var strdata = {
        "fromAddr": fromAddr, "toAddr": toAddr, "ccAddr": ccAddr, "subject": subject
        , "Description": Description, "jobcode": jobcode, "candidateemailid": candidateemailid
        , "employeremaildid": employeremaildid
    };
    if (toAddr != "") {
        common_api_ajax_request("api/SendMailIndia", "MAIL", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        alert("fill");
    }
}


function sendSubmissionMail() {
    var toAddr = "prasanna.m@techwaukee.com";
    var ccAddr = "";
    var subject = "Submission-" + $("#txtCandidatename").val() + "-" + $("#lblJobtitle1").text();

    //var Description = "\n\n<u>Details Required for Submission:</u><br/>" +
    //    "<br/>Kindly Share the below details and your Visa & DL Copy for submission.<br/>" +
    //    "<table style='font-family: Verdana,    Arial,    Helvetica,    sans-serif; font-size: 13.3333px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; background-color: rgb(255, 255, 255); border-collapse: collapse; width: 506pt;' class='' border='1' cellpadding='0' cellspacing='0' width='675'>" +
    //    "<colgroup class=''>" +
    //    "<col style='width: 177pt;' class='' width='236'>" +
    //    "<col style='width: 329pt;' class='' width='439'>" +
    //    "</colgroup>" +
    //    "<tbody class=''>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; width: 177pt; color: windowtext; text-align: left; vertical-align: middle; border: 0.5pt solid windowtext; background: white; white-space: normal;' height='20' class='x_2012675028xl67' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>&nbsp;</span></span><br>"+
    //"</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; background: white;' class='x_2012675028xl69' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>&nbsp;</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 28px; width: 506pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; border: 0.5pt solid windowtext; background: rgb(237, 125, 49); white-space: normal;' colspan='2' height='20' class='x_2012675028xl73' width='675'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Submission</span></span><br>" +
    //    "</td>" +
    //    "</tr>"+
    //"<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: rgb(141, 179, 226); white-space: normal;' height='20' class='x_2012675028xl70' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Details</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: rgb(141, 179, 226); white-space: normal;' class='x_2012675028xl70' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Input</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Candidate Full Name</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; font-weight: 700; text-align: left;' class='x_2012675028xl72'><span class='x_1276292371colour' style='color: rgb(37, 49, 60);'><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 16pt;'><span class='x_1276292371size' style='font-size: 13.3333px;'><span class='x_1276292371font' style='font-family: verdana,  sans-serif;'><b><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt; line-height: 15.6933px;'>" + $("#txtCandidatename").val()+"</span></span></b></span></span></span></span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 25px; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Email ID</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: rgb(5, 99, 193); text-decoration: underline;' class='x_2012675028xl74'>"+
    //"<div style='margin: 0px;' class=''><span><a style='color: rgb(89, 143, 222); cursor: pointer;' href='mailto:bhavani9910@gmail.com' target='_blank'><b><span class='x_1276292371colour' style='color: windowtext;'><span class='x_1276292371size' style='font-size: 11pt; text-decoration: none;'><span class='x_1276292371size' style='font-size: 13.3333px;'>" + $("#txtEmailid").val() +"</span></span></span></b></a></span><br>" +
    //    "</div>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Contact Number</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext;' class='x_2012675028xl75'>"+
    //"<div style='text-align: justify; margin: 0px;' class=''><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt;'><b><span class='x_1276292371font' style='font-family: Calibri,  sans-serif;'><span class='x_1276292371size' style='font-size: 11pt; line-height: 15.6933px;'>(510) 556- 9910</span></span></b></span></span><br>" +
    //    "</div>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Current Location</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; text-align: left;' class='x_2012675028xl71'><span class='x_1276292371highlight' style='background-color: rgb(255, 255, 255);'><span class='x_1276292371font' style='font-family: &quot; lato 2&quot; ,  sans-serif;'><span class='x_1276292371size' style='font-size: 14px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; float: none; display: inline;'><span class='x_1276292371highlight' style='background-color: rgb(255, 255, 255);'><span class='x_1276292371font' style='font-family: -apple-system,  system-ui,  BlinkMacSystemFont,  &quot; segoe ui&quot; ,  roboto,  &quot; helvetica neue&quot; ,  &quot; fira sans&quot; ,  ubuntu,  oxygen,  &quot; oxygen sans&quot; ,  cantarell,  &quot; droid sans&quot; ,  &quot; apple color emoji&quot; ,  &quot; segoe ui emoji&quot; ,  &quot; segoe ui symbol&quot; ,  &quot; lucida grande&quot; ,  helvetica,  arial,  sans-serif;'><span class='x_1276292371size' style='font-size: 10.5px; font-style: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; float: none; display: inline;'><span class='x_1276292371colour' style='color: rgb(0, 0, 0);'><span class='x_1276292371font' style='font-family: verdana,  sans-serif;'><span class='x_1276292371size' style='font-size: 13.3333px;'>Palm Beach Gardens, Florida,</span></span></span></span></span></span></span></span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Visa Status</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'>H1B<br>
    //"</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Rate/Salary</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>$62/hr all inclusive on Corp to Corp (Employer Rate)</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Willing to relocate (Yes/No)</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'>" +
    //    "<br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Total years of experience</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>7 Years</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Relevant experience</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-align: left;' class='x_2012675028xl66'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>7 Years as a Talend developer</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>LinkedIn</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; color: windowtext; text-decoration: underline; text-align: left;' class='x_2012675028xl68'><a style='color: rgb(89, 143, 222); cursor: pointer;' href='https://www.linkedin.com/in/bhavani-venishetti-a76763158/' target='_blank'>(8) Bhavani Venishetti | LinkedIn</a><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Notice Period</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>1 Week</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "<tr style='height: 15pt;' class='' height='20'>" +
    //    "<td style='font-family: inherit; height: 15pt; border: 0.5pt solid windowtext; width: 177pt; color: windowtext; font-weight: 700; text-align: left; vertical-align: middle; background: white; white-space: normal;' height='20' class='x_2012675028xl65' width='236'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>Available for the interview</span></span><br>" +
    //    "</td>" +
    //    "<td style='font-family: inherit; border: 0.5pt solid windowtext; width: 329pt; color: windowtext; text-align: left; vertical-align: middle; background: white; white-space: normal;' class='x_2012675028xl67' width='439'><span class='x_1276292371font' style='font-family: Calibri,  Verdana,  Arial,  sans-serif,  sans-serif;'><span class='x_1276292371size' style='font-size: 16px;'>One Day Prior Notice</span></span><br>" +
    //    "</td>" +
    //    "</tr>" +
    //    "</tbody>" +
    //    "</table>";

    //var strdata = {
    //    "fromAddr": fromAddr, "toAddr": toAddr, "ccAddr": ccAddr, "subject": subject
    //    , "Description": Description
    //};

    //if (toAddr != "") {
    //    common_api_ajax_request("api/SendSubmissionMail", "SUBMAIL", strdata);
    //    //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    //} else {
    //    alert("fill");
    //}
}

function enableTLButton() {
    if ($("#chkRTR").prop("checked") == true) {
        //if ($('input[name="chkRTR"]:checked').val() == "on") {
        $('#btnSubmittl').prop('disabled', false);
        $('#btnSubmittl').css('display', 'block');
        $('#btnPipeline').css('display', 'none');
        $('#btnDraft').css('display', 'none');
    }

    else if ($("#chkRTR").prop("checked") == false) {
        $('#btnSubmittl').css('display', 'none');
        $('#btnPipeline').css('display', 'block');
        $('#btnDraft').css('display', 'block');
    }
}

function openEmployer() {
    if ($('input[name="chkEmployer"]:checked').val() == "on") {
        $('#div-employer').css('display', 'block');
        enableemplcontrols();
    }
    else {
        $('#div-employer').css('display', 'none');
    }
}

function popup() {
    $("#rtr").modal('hide');
    $("#rtrmailview").modal('show');
    $("#txtpreviewSubject").val($("#txtSubject").val());
}

function popupcontinue() {
    $("#rtr").modal('hide');
    $("#rtrmailview").modal('show');

}

function popupcontinue() {

    $("#rtrmailview").modal('hide');
    $("#rtrcontinue").modal('show');
    $("#txtsubject").val($("#txtSubject").val());
    $("#txtMailto").val($("#txtEmailid").val());
    $("#txtMaildescription").append($("#txtMailcont").val() + $("#txtMaildescriptioncont").html());
    //window.location.href = 'FollowupPageIndia.aspx?id=' + $('#hdnJobid').val();
}

function getSkillData() {
    common_api_ajax_request("api/CandidateFormIndia", "CandidateFormIndia", "");    
}

function SaveSkill() {
    $("#drpSkill :selected").each(function () {
        skillVal += this.value + ",";
    });
    skillVal = skillVal.substring(0, skillVal.length - 1);
    
    var strdata = {
        "Skill": $("#txtSkill").val()
    };
    common_api_ajax_request("api/AddSkill", "ADDSKILL", strdata);
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
    document.getElementById("starRating").innerHTML = rateCount;
    //document.getElementById("ContentPlaceHolder1_hdnStarrating").innerHTML = rateCount;

}

function getCandidateInfoData(candId, Jobid) {
    var strdata = { "Candidateid": candId, "Jobid": Jobid };
    if (candId != "") {
        common_api_ajax_request("api/CandidateAssignIndia", "CANDINFOIND", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        alert("fill");
    }
}

function closepopup(val) {
    if (val == 0) {
        $("#msgpopup").modal('hide');

    }
    else if (val == 1) {
        $("#msgpopup").modal('hide');
        window.location.href = "FollowupPageIndia.aspx?id=" + $('#hdnJobid').val();
    }

    else if (val == 2) {
        $("#msgpopup").modal('hide');
        window.location.href = "CandidateOverviewIndia.aspx";
    }

}


function btnhidden() {
    $("#msgpopup").modal('hide');
    $('#btnRtr').css('display', 'none');
    $('#btnDraft').css('display', 'block');
    $('#btnPipeline').css('display', 'block');
}


function getTotalSkillData() {
    common_api_ajax_request("api/Skill", "Skill", "");
}

function removeDocuments() {
    
    var counter = getSession('counter');
    if (counter == 2) {
        $('#txtIdno2').val("");
        $("#drpDocumenttype2").val("-1").prop("selected", true);
        $('#divAttach2').css('display', 'none');
    }
    else if (counter == 3) {
        $('#txtIdno3').val("");
        $("#drpDocumenttype3").val("-1").prop("selected", true);
        $('#divAttach3').css('display', 'none');
    }
    else if (counter == 4) {
        $('#txtIdno4').val("");
        $("#drpDocumenttype4").val("-1").prop("selected", true);
        $('#divAttach4').css('display', 'none');
    }

    var counter = parseInt(getSession('counter')) - 1;
    setSession("counter", counter);
}

function getLength(ctrl1,ctrl2) {
    var maxlength = 0;
    if ($("#" + ctrl1).text() == "Aadhar") {
        maxlength = 12;
    }
    else if ($("#" + ctrl1).text() == "PAN") {
        maxlength = 10;
    }
    var textlength = $('#' + ctrl2).val().length;

    if (textlength != maxlength) {
        alert("Aadhar number should contain 12 digits");
    }
    
    
}