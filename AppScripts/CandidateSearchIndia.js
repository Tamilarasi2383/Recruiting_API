$(document).ready(function () {
    setSession("Page", "CandidateSearchIndia");

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
    common_api_ajax_request("api/CandidateFormIndia", "CandidateFormIndia", "");
}

function getCandCount() {
    common_api_ajax_request("api/CandidateCountIndia", "CandidateCount", "");
}

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;

    if (key == "CandidateFormIndia") {       
        

        document.getElementById("drpSkill").options.length = 0;
        //var option1 = new Option("--Select Visa Status--", "-1");
        //$(option1).html("--Select Visa Status--");
        //$("#drpSkill").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }

    }

    else if (key == "CandidateCount") {
        $("#lblCandidatecount").text(resData.candidateid);
    }

    else if (key == "CANDIDATESER") {
        createCandidateTable(resData);
        getPaging(5);
        if (resData!=null) {
            $('#btnGetmail').css('display', 'initial');
        }
        
        
        //getPagination('#tblCandlist', "5");
    }

}

function getCandidatePage() {

    //if (Validatecandidatesearch() == true) {

        var values1 = "";
        $("#drpSkill :selected").each(function () {
            values1 += this.value + ",";
        });

        var skill = values1.substring(0, values1.length - 1);
        var Candidatename = $("#txtCandidatename").val();
        var yrsofexp = $('select#drpYrsofExp option:selected').val();
        var rating = $('select#drpRating option:selected').val();
        var Candidatemail = $("#txtCandidatemailid").val();
        //var yrsofexp = "";
        //var visastatus = "";
    var strdata = {
        "skill": skill, "Candidatename": Candidatename, "yrsofexp": yrsofexp, "Candidatemail": Candidatemail, "rating": rating, "TWE_Id": getSession('TWE_ID') };
    
        common_api_ajax_request("api/CandidateSearchIndia", "CANDIDATESER", strdata);
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
                strAction21 = "<li><a class='dropdown-item border-radius-md' href='Candidate_Viewindia.aspx?id=" + item.candidateid + "' id='View'>View</a></li>";
            }
            else if (getSession('CandidateView') == "1") {
                if (assigneduser == true) {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='Candidate_Viewindia.aspx?id=" + item.candidateid + "' id='View'>View</a></li>";
                }
            }

            //if (getSession('CandidateEdit') == "2") {
            //    //if (assigneduser == true) {
            //    //}
            //    //else {
            //    strAction22 = " <li><a class='dropdown-item border-radius-md' href='CandidateIndia.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            //    //}
            //}

            //else if (getSession('CandidateEdit') == "1") {
            //    if (assigneduser == true) {
            //        strAction22 = " <li><a class='dropdown-item border-radius-md' href='CandidateIndia.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>";
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

    if ($('#txtCandidatename').val() == "") {
        $("#txtCandidatename").addClass("is-invalid");
        emptycount++;
    }
    else {
        $("#txtCandidatename").removeClass("is-invalid");
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

    //if ($('#drpVisastatus').val() == "-1") {
    //    $('#drpVisastatus').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#drpVisastatus').removeClass("is-invalid");
    //    count++;
    //}

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

var emailId = "";
function openpopup() {

    var table = document.getElementById("tblCandlist");
    var tr = table.getElementsByTagName("tr");
    var txtValue;
    var strTable = "";
    for (i = 0; i < tr.length; i++) {
        var td = tr[i].getElementsByTagName("td")[2];
        if (td) {

            txtValue = td.textContent || td.innerText;
            emailId += txtValue+ ";";
            strTable += "<label>" + txtValue + "</label><br/>";
        }
    }
    $("#hdnMailid").val(emailId);
    $('#div_mail').empty();
    $('#div_mail').append(strTable);
    $("#getmail").modal('show');
}

function copyemail() {



    var copyText = document.getElementById("hdnMailid");

    /* Select the text field */
    copyText.select();
    copyText.setSelectionRange(0, 99999); /* For mobile devices */

    /* Copy the text inside the text field */
    navigator.clipboard.writeText(copyText.value);


    //$temp.val($(emailId)).select();

    //document.execCommand("Copy");
    //$temp.remove();
}