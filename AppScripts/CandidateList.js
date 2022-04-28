var filterType = "";
$(document).ready(function () {
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    setSession("Page", "Candidate");
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchCand").addClass("active");
    $('#anchCand').attr('aria-expanded', 'true');
    $("#div_Cand").addClass("show");
    $("#candView").addClass("active");
    $('#lblPagetitle').text("Candidate");
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        getcandidateList("Follow");
        
    }
    else {
        getcandidateList("All");
        localStorage.removeItem("prevPage");
        localStorage.setItem("prevPage", window.location.href);
    }
   
});


function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "CANDOVERVIEWLIST") {

        $("#lblTotalcandidate").text(resData._lstTile[0].TileTitle);
        $("#lblTotalcandidatevalue").text(resData._lstTile[0].TotalCount);
        $("#lblSubmitedtl").text(resData._lstTile[1].TileTitle);
        $("#lblSubmitedtlvalue").text(resData._lstTile[1].TotalCount);
        $("#lblSubmittedbp").text(resData._lstTile[2].TileTitle);
        $("#lblSubmittedbpvalue").text(resData._lstTile[2].TotalCount);
        $("#lblSumbittedec").text(resData._lstTile[3].TileTitle);
        $("#lblSumbittedecvalue").text(resData._lstTile[3].TotalCount);
        $("#lblFeedbackprofile").text(resData._lstTile[4].TotalCount);
        
        $("#lblJobcreted").text(resData._lstTile[5].TotalCount);
        $("#lblPositive").text(resData._lstTile[6].TotalCount+"%");
        $("#div_positive").addClass("w-" + resData._lstTile[6].TotalCount);
        if (resData._lstTile[6].TotalCount == "") {
            resData._lstTile[6].TotalCount = "0";
        }
        if (resData._lstTile[7].TotalCount=="") {
            resData._lstTile[7].TotalCount = "0";
        }
        $("#lblNegative").text(resData._lstTile[7].TotalCount + "%");
        $("#div_negative").addClass("w-" + resData._lstTile[7].TotalCount);

        createCandTable(resData._lstcandilist);
        getPaging(5);
        //getPagination('#tblCandlist', 5);
        stopLoader();
    }
}

function getcandidateList(filterVal) {
    if (filterVal == "TLSubmitted") {
        $("#div_TLSubmitted").removeClass("colorgray");
        $("#div_TotSubmitted").addClass("colorgray");
        $("#div_BPSubmitted").addClass("colorgray");
        $("#div_ECSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Submitted to TL-Candidate List");

    }
    else if (filterVal == "BPSubmitted") {
        $("#div_BPSubmitted").removeClass("colorgray");
        $("#div_TotSubmitted").addClass("colorgray");
        $("#div_TLSubmitted").addClass("colorgray");
        $("#div_ECSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Submitted to BP-Candidate List");
    }
    else if (filterVal == "ECSubmitted") {
        $("#div_ECSubmitted").removeClass("colorgray");
        $("#div_TotSubmitted").addClass("colorgray");
        $("#div_TLSubmitted").addClass("colorgray");
        $("#div_BPSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Submitted to EC-Candidate List");
    }
    else if (filterVal == "All") {
        $("#anchCandidate").addClass("change_color");
        $("#anchFollowup").removeClass("change_color");
        $("#anchDraft").removeClass("change_color");

        $("#div_ECSubmitted").addClass("colorgray");
        $("#div_TotSubmitted").removeClass("colorgray");
        $("#div_TLSubmitted").addClass("colorgray");
        $("#div_BPSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Candidate List");
    }
    else if (filterVal == "Follow" ) {
        filterType = "Follow";
        $("#anchCandidate").removeClass("change_color");
        $("#anchFollowup").addClass("change_color");
        $("#anchDraft").removeClass("change_color");

        $("#div_ECSubmitted").addClass("colorgray");
        $("#div_TotSubmitted").addClass("colorgray");
        $("#div_TLSubmitted").addClass("colorgray");
        $("#div_BPSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Follow Up-Candidate List");
    }

    else if (filterVal == "Draft") {
        $("#anchCandidate").removeClass("change_color");
        $("#anchFollowup").removeClass("change_color");
        $("#anchDraft").addClass("change_color");

        $("#div_ECSubmitted").addClass("colorgray");
        $("#div_TotSubmitted").addClass("colorgray");
        $("#div_TLSubmitted").addClass("colorgray");
        $("#div_BPSubmitted").addClass("colorgray");
        $("#lblTableheader").text("Drafted-Candidate List");
    }

    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "filter": filterVal };
    if (TWE_Id != "") {
        common_api_ajax_request("api/CandidateOveviewList", "CANDOVERVIEWLIST", strdata);
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
                "<td class='align-middle text-center text-sm' style='width: 0rem;'><div><a href='" + item.linkedinURL + "' target='_blank'>" + strImg + "</a></div></td>"+
                "<td onclick = gotocandidatepage('" + item.candidateid +"');> <div class='d-flex px-2 py-1'>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<h6 class='mb-0 text-sm'>" + item.candidatename + "</h6>" +
                "<p class='text-xs text-secondary mb-0'><a class='__cf_email__' data-cfemail='96fcf9fef8d6f5e4f3f7e2ffe0f3bbe2fffbb8f5f9fb'>" + item.candidateemailid + " | " + item.candidatemobno + " | " + "$" + item.ratePerHr + "/Hr" + " - " + item.type + "</a></p>" +
                "</div ></div ></td > ";


            strTable += "<td onclick=gotocandidatepage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.vendorname + "</p><p class='text-xs text-secondary mb-0'>" + item.vendoremailid + "</p></td>";
            
            if (item.candidatestatus == "Submitted to TL" || item.candidatestatus == "Submitted to BP" || item.candidatestatus == "Submitted to EC" || item.candidatestatus == "Closure") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>"+
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>"+
                    "<span class='badge badge-sm bg-gradient-success'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "TL Rejected" || item.candidatestatus == "BP Rejected" || item.candidatestatus == "EC Rejected") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-danger'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "BP Interview" || item.candidatestatus == "EC Interview") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Draft") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Pipeline") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid +"');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +                    
                    "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
            }


            strTable += "<td onclick=gotocandidatepage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.submittedby + "</p><p class='text-xs text-secondary mb-0'> " + item.submitteddate + "|" + item.submittedtime + "</p></td>";

            var strCandTable;
            if (item.jobcode == "") {
                strCandTable = "<li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            }
            else {
                strCandTable = "<li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.jobcode + "&jobId=" + item.candidateid + "' id='Edit'>Edit</a></li>";
            }


            if (filterType == "Follow") {
                
                strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                    "<div class='dropdown float-lg-end pe-1'>" +
                    "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                    "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                    "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                    "<li><a class='dropdown-item border-radius-md' href='Candidate_View.aspx?id=" + item.candidateid + "&jobId=" + item.jobcode + "' id='View'>View</a></li>" +
                    //" <li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.candidateid + "' id='Edit'>Edit</a></li>" +
                    "<li><a class='dropdown-item border-radius-md' href='Candidate.aspx?id=" + item.jobcode + "&jobId=" + item.candidateid + "' id='Edit'>Edit</a></li>"+
                    "</ul></div></div></td></tr>";

            }

            else {
                strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                    "<div class='dropdown float-lg-end pe-1'>" +
                    "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                    "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                    "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                    "<li><a class='dropdown-item border-radius-md' href='Candidate_View.aspx?id=" + item.candidateid + "' id='View'>View</a></li>" +
                    strCandTable+
                    "</ul></div></div></td></tr>";
            }

        }
    });
    $("#tblCandlist tbody").append(strTable);

}

$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblCandlist', $(this).val());
});

function gotocandidatepage(candidateid) {
    window.location.href = "Candidate_View.aspx?id=" + candidateid;
}

