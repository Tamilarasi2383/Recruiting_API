
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
    

    $("#anchDashboard").removeClass("active");
    $("#anchCand").addClass("active");
    $("#candView").addClass("active");
    $('#anchCand').attr('aria-expanded', 'true');
    $("#div_Cand").addClass("show");
    //$("#anchJob").addClass("active");
    $('#lblPagetitle').text("Candidate");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    getClosureList();


});

function getClosureList() {
    var TWE_Id = getSession('TWE_ID');

    var strdata = { "TWE_Id": TWE_Id };
    if (TWE_Id != "") {
        common_api_ajax_request("api/CandidateClosureListIndia", "CLOSURELISTINDIA", strdata);
    }
}

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "CLOSURELISTINDIA") {
        createCandTable(resData._lstcandilist);
        getPaging(5);
        stopLoader();
    }
}



function createCandTable(data) {
    $("#tblCandlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {
        if (item.Jobcode == "") {

        } else {
            var strImg = "";
            if (item.linkedinURL == "") {
                strImg = "<img src='Images/LinkedIn-no.png' class='avatar avatar-sm me-3' style='margin-right: -1rem !important;'>";
            }
            else if (item.linkedinURL != "") {
                strImg = "<img src='Images/LinkedIn.png' class='avatar avatar-sm me-3' style='margin-right: -1rem !important;'>";
            }
            strTable += "<tr style='cursor:pointer !important;' class='divControl'>" +
                "<td class='align-middle text-center text-sm' style='width: 0rem;'><div><a href='" + item.linkedinURL + "' target='_blank'>" + strImg + "</a></div></td>" +
                "<td onclick=gotocandidatepage('" + item.candidateid + "');> <div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<h6 class='mb-0 text-sm'>" + item.candidatename + "</h6>" +
                "<p class='text-xs text-secondary mb-0'><a >" + item.candidateemailid + " | " + item.candidatemobno + " | " + "<img src='Images/in-rupee.png'width='15'height='15'/>" + item.ratePerHr + "/Day" + "</a></p>" +
                "</div ></div ></td > ";


            strTable += "<td onclick=gotocandidatepage('" + item.candidateid + "');><p class='text-xs font-weight-bold mb-0'>" + item.vendorname + "</p><p class='text-xs text-secondary mb-0'>" + item.vendoremailid + "</p></td>";
                                   
            strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-success'>" + item.candidatestatus + "</span></td>";           


            strTable += "<td onclick=gotocandidatepage('" + item.candidateid + "');><p class='text-xs font-weight-bold mb-0'>" + item.submittedby + "</p><p class='text-xs text-secondary mb-0'> " + item.submitteddate + "|" + item.submittedtime + "</p></td>";

            var strCandTable = "<li><a class='dropdown-item border-radius-md' href='CandidateIndia.aspx?id=" + item.jobcode + "&jobId=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            

            strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                    "<div class='dropdown float-lg-end pe-1'>" +
                    "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                    "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                    "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                    "<li><a class='dropdown-item border-radius-md' href='Candidate_Viewindia.aspx?id=" + item.candidateid + "' id='View'>View</a></li>" +
                    strCandTable +
                    "</ul></div></div></td></tr>";
         
        }
    });
    $("#tblCandlist tbody").append(strTable);

}

$('#maxRows').on('change', function () {
    getPaging($(this).val());
});

function gotocandidatepage(candidateid) {
    window.location.href = "Candidate_ViewIndia.aspx?id=" + candidateid;
}
