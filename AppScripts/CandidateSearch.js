$(document).ready(function () {
    setSession("Page", "CandidateSearch");

    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchCand").addClass("active");
    $('#lblPagetitle').text("Candidate Search");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#anchCand').attr('aria-expanded', 'true');
    $("#div_Cand").addClass("show");
    $("#candSearch").addClass("active");
    getSkillData();
    getCandCount();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});


function getSkillData() {
    common_api_ajax_request("api/CandidateFormIndia", "CandidateForm", "");
}

function getCandCount() {
    common_api_ajax_request("api/CandidateCount", "CandidateCount", "");
}

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    
    if (key == "CandidateForm") {

        document.getElementById("drpVisastatus").options.length = 0;
        var option1 = new Option("--Select Visa Status--", "-1");
        $(option1).html("--Select Visa Status--");
        $("#drpVisastatus").append(option1);
        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }

        document.getElementById("drpVisastatus").options.length = 0;
        var option1 = new Option("--Select Visa Status--", "-1");
        $(option1).html("--Select Visa Status--");
        $("#drpVisastatus").append(option1);

        for (var i = 0; i < resData.lstEmploymentType.length; i++) {

            var option = new Option(resData.lstEmploymentType[i].Name, resData.lstEmploymentType[i].ID);

            $(option).html(resData.lstEmploymentType[i].Name);
            $("#drpVisastatus").append(option);
        }
        stopLoader();
    }

    else if (key =="CandidateCount") {
        $("#lblCandidatecount").text(resData.candidateid);
        stopLoader();
    }

    else if (key =="CANDIDATESER") {
        createCandidateTable(resData);
        getPaging(5);
        //getPagination('#tblCandlist', "5");
        stopLoader();
    }

}

function getCandidatePage() {  

    //if (Validatecandidatesearch() == true) {

        var values1 = "";
        $("#drpSkill :selected").each(function () {
            values1 += this.value + ",";
        });

        var skill = values1.substring(0, values1.length - 1);
        var location = $("#txtLocation").val();
        var yrsofexp;
        if ($('select#drpYrsofExp option:selected').val() == "-1") {
            yrsofexp = "";
        }

        else {
            yrsofexp = $('select#drpYrsofExp option:selected').val();
        }
        var visastatus;
        if ($('select#drpVisastatus option:selected').val() == "-1") {
            visastatus = "";
        }

        else {

            visastatus=$('select#drpVisastatus option:selected').val();
        }
        var rating = $('select#drpRating option:selected').val();
        var Candidatemail = $("#txtCandidatemailid").val();


        //var yrsofexp = "";
        //var visastatus = "";
    var strdata = { "skill": skill, "location": location, "yrsofexp": yrsofexp, "visastatus": visastatus, "Candidatemail": Candidatemail, "rating": rating, "TWE_Id": getSession('TWE_ID') };

        common_api_ajax_request("api/CandidateSearch", "CANDIDATESER", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    //}
}

function createCandidateTable(data) {
    $("#tblCandlist tbody").empty();
    var strTable = "";

    var strAction1 = "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
        "<div class='dropdown float-lg-end pe-1'>" +
        "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
        "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

        "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>";

    var strAction3 = "</ul></div></div></td></tr>";

    var strAction21 = "";

    var strAction22 = "";


    $.each(data, function (key, item) {
        var assigneduser = item.createdBy.includes(getSession('TWE_ID'));

        if (item.candidateid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle' style='display:none;'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.candidateid + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.candidatename + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.candidateemailid + "</label></td>" +
                "<td class='align-middle'style='white-space: pre-wrap;'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.skillsandCertif + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.currentLocation + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.yrsofexp + "</label></td>";
                
                       
            if (getSession('CandidateView') == "2") {
                strAction21 = "<li><a class='dropdown-item border-radius-md' href='Candidate_View.aspx?id=" + item.candidateid + "' id='View'>View</a></li>";
            }
            else if (getSession('CandidateView') == "1") {
                if (assigneduser == true) {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='Candidate_View.aspx?id=" + item.candidateid + "' id='View'>View</a></li>";
                }
            }

            //if (getSession('CandidateEdit') == "2") {
            //    //if (assigneduser == true) {
            //    //}
            //    //else {
            //    strAction22 = " <li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            //    //}
            //}

            //else if (getSession('CandidateEdit') == "1") {
            //    if (assigneduser == true) {
            //        strAction22 = " <li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            //    }
            //}

            strTable += strAction1 + strAction21 + strAction22 + strAction3;
        }

    });

    $("#tblCandlist tbody").append(strTable);

}


function Validatecandidatesearch() {
    var count = 0;
    var emptycount = 0;
    if ($("#select2-data-drpSkill").text() == "-1") {
        $('#select2-data-drpSkill').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#select2-data-drpSkill').removeClass("is-invalid");
        count++;
    }

    if ($('#txtLocation').val() == "") {
        $("#txtLocation").addClass("is-invalid");
        emptycount++;
    }
    else {
        $("#txtLocation").removeClass("is-invalid");
        count++;
    }

    if ($('#drpYrsofExp').val() == "-1") {
        $('#drpYrsofExp').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#drpYrsofExp').removeClass("is-invalid");
        count++;
    }

    if ($('#drpVisastatus').val() == "-1") {
        $('#drpVisastatus').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#drpVisastatus').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function cleardata() {

    var index = $('#drpSkill').get(0).selectedIndex;
    $("#tblCandlist tbody").empty();

    $('.pagination').html('');
    $('#divInfo').text("");

    $("#divPages").empty();
    //$("#drpSkill").remove();
    $("#txtCandidatename").val("");
    $("#drpYrsofExp").val("-1").prop("selected", true);
    $("#txtCandidatemailid").val("");
    $("#drpRating").val("-1").prop("selected", true);

    $("#divPages").empty();

    $('#drpSkill option').each(function (index, option) {
        $(option).prop("selected", false);
    });

    $(".select2-selection__choice__remove").click();

    //$('.select2').blur();
    $("#drpSkill").dropdown('toggle');

}