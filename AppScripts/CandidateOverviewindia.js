$(document).ready(function () {

    setSession("Page", "CandidateOverviewIndia");
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#candOverview").addClass("active");
    $("#anchCand").addClass("active");
    $('#anchCand').attr('aria-expanded', 'true');
    $("#div_Cand").addClass("show");
    $('#lblPagetitle').text("Candidate");
    $('#dropdownMenuButton').css('display', 'none');
    getcandidateoverviewList("All");
    
});


function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "CANDOVERVIEW") {
        $("#lblPipeline").text(resData._lstTile[0].TileTitle);
        $("#lblPipelinevalue").text(resData._lstTile[0].TotalCount);
        $("#lblInterview").text(resData._lstTile[1].TileTitle);
        $("#lblInterviewvalue").text(resData._lstTile[1].TotalCount);
        $("#lblAddcandidatevalue").text(resData._lstTile[2].TotalCount);
        $("#lblMorecandidates").text(resData._lstTile[3].TotalCount);
        $("#lblMoretitle").text(resData._lstTile[6].TileTitle);
        $("#lblTargetvalue").text(resData._lstTile[4].TotalCount);
        $("#lblachievedvalue").text(resData._lstTile[5].TotalCount);

        Createactivejobs(resData._lstJob);
        createCandTable(resData._lstcandilist);
        getPaging(5);
        //getPagination('#tblCandlist', 5);
        stopLoader();
    }

}


function getcandidateoverviewList(tileValue) {
    if (tileValue == "Pipeline") {
        $("#div_pipeline").removeClass("colorchange");
        $("#div_pipelineheader").removeClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_interviewheader").addClass("colorchange");
        $("#lblTableheader").text("Pipeline-Candidate List");

    }
    else if (tileValue == "Interview") {
        $("#div_interview").removeClass("colorchange");
        $("#div_interviewheader").removeClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $("#div_pipelineheader").addClass("colorchange");
        $("#lblTableheader").text("Interview-Candidate List");
    }
    else if (tileValue == "All") {
        $("#div_interview").addClass("colorchange");
        $("#div_interviewheader").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $("#div_pipelineheader").addClass("colorchange");
        $("#lblTableheader").text("Candidate List");
    }

    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[1], "Enddate": st[1], "filter": tileValue  };
    if (TWE_Id != "") {
        common_api_ajax_request("api/CandidateOveviewIndia", "CANDOVERVIEW", strdata);
    }
}


function Createactivejobs(lstjob) {
    var str = "<ul class='list-group'>";
    for (var i = 0; i < lstjob.length; i++) {

        str += "<li class='list-group-item border-0 d-flex justify-content-between ps-0 mb-2 border-radius-lg' >" +
            "<div class='d-flex flex-column'>" +
            "<h6 class='mb-1 text-dark font-weight-bold text-sm'><span id='lblDesignation'>" + lstjob[i].JobTitle + "</span></h6>" +
            "<span class='text-xs'><span id='lblMonthvalue'>" + lstjob[i].JobDuration + "</span> | <span id='lblType'>" + lstjob[i].JobType + "</span> | <span id='lblState'>" + lstjob[i].JobState + "</span> , <span id='lblCountry'>" + lstjob[i].JobCountry + "</span></span>" +
            "</div>" +
            "<div class='d-flex align-items-center text-sm'>" +
            "<button class='btn btn-link text-dark text-sm mb-0 px-0 ms-4' onclick=window.location.href='FollowuppageIndia.aspx?id=" + lstjob[i].Jobcode +"'><i class='text-lg me-1' id='btnFollow'></i>Follow</button>" +
            "</div>" +
            "</li >";
    }

    str += "</ul>";

    $('#div_activejobs').empty();
    $('#div_activejobs').append(str);
}


function createCandTable(data) {
    $("#tblCandlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {
        if (item.Jobcode == "") {

        } else {
            var strImg = "";
            if (item.linkedinURL == "") {
                strImg = "<img src='Images/LinkedIn-no.png' class='avatar avatar-sm me-3'>";
            }
            else if (item.linkedinURL != "") {
                strImg = "<img src='Images/LinkedIn.png' class='avatar avatar-sm me-3'>";
            }
            strTable += "<tr style='cursor:pointer;' class='divControl'><td onclick=gotocandidatepage('" + item.candidateid +"');> <div class='d-flex px-2 py-1'>" +
                "<div><a href='" + item.linkedinURL + "' target='_blank'>" + strImg + "</a></div>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<h6 class='mb-0 text-sm'>" + item.candidatename + "</h6>" +
                "<p class='text-xs text-secondary mb-0'><a >" + item.candidateemailid + " | " + item.candidatemobno + " | " + "<img src='Images/in-rupee.png'width='15'height='15'/>" + item.ratePerHr + "/Day" + "</a></p>" +
                "</div ></div ></td > ";


            strTable += "<td onclick=gotocandidatepage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.vendorname + "</p><p class='text-xs text-secondary mb-0'>" + item.vendoremailid + "</p></td>";


            if (item.candidatestatus == "Submitted to TL" || item.candidatestatus == "Submitted to BP" || item.candidatestatus == "Submitted to EC" || item.candidatestatus == "Closure") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<span class='badge badge-sm bg-gradient-success'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "TL Rejected" || item.candidatestatus == " BP Rejected" || item.candidatestatus == "EC Rejected") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<span class='badge badge-sm bg-gradient-danger'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Draft") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Pipeline") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "BP Interview" || item.candidatestatus == "EC Interview") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    //"<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    //"<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
            }

            strTable += "<td onclick=gotocandidatepage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.submittedby + "</p><p class='text-xs text-secondary mb-0'> " + item.submitteddate + "|" + item.submittedtime + "</p></td>";
            strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Candidate_Viewindia.aspx?id=" + item.candidateid + "' id='View'>View</a></li>" +
                " <li><a class='dropdown-item border-radius-md' href='CandidateIndia.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>" +
                "</ul></div></div></td></tr>";
        }
    });
    $("#tblCandlist tbody").append(strTable);

}

$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblCandlist', $(this).val());
});

function gotocandidatepage(candidateid) {
    window.location.href = "Candidate_Viewindia.aspx?id=" + candidateid;
}

function gotoJobPage() {

    if (getSession('Designation') == "4001") {
        window.location.href = "JobListindia.aspx";
    }
    else if (getSession('Designation') == "4000" || getSession('Designation') == "4004") {
        window.location.href = "ManagerJobListindia.aspx";
    }
}