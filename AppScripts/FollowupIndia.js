$(document).ready(function () {

    setSession("Page", "Follow");
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Follow Up");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    var url = window.location.href;
    hashes = url.split("?")[1];

    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        if (hash.length == 1) {
            getJobFollowupData(params[1], "");
        }

        else if (hash.length > 1) {
            if (hash.length == 2) {
                getJobFollowupData(params[1], "Feedback","");
                $('#btnAdd').css('display', 'none');
            }
            else if (hash.length == 3) {
                var params1 = hash[2].split("=");
                getJobFollowupData(params[1], "Feedback", params1[1]);
                $('#btnAdd').css('display', 'none');
            }        
        }


    }

});

function getJobFollowupData(jobid, type, createdBy) {

    var strdata = { "Jobid": jobid, "type": type, "createdBy": createdBy }
    common_api_ajax_request("api/FollowupJobIndia", "FOLLOWJOB", strdata);
}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "FOLLOWJOB") {

        if (resData.Jobstatus == "Open") {
            $('#btnAdd').css('display', 'block');
            $('#div_comm').css('display', 'none');
            $('#lblJobstatus').addClass("bg-gradient-success");
                
        }
        else {
            $('#btnAdd').css('display', 'none');
            $("#lblComments").text(resData.CloseComments);
            $('#div_comm').css('display', 'block');
            $('#lblJobstatus').addClass("bg-gradient-danger");
        }

        $("#imgJobimage").attr("src", resData.Jobimage);
        $("#lblJobtitle").text(resData.JobTitle);
        $("#lblJobid").text(resData.Jobcodename);
        $("#lblJobstatus").text(resData.Jobstatus);

        $("#lblMonth").text(resData.Duration);
        $("#lblEmptype").text(resData.EmplType);
        $("#lblCity").text(resData.City);
        $("#lblState").text(resData.State);
        $("#lblCountry").text(resData.Country);
        $("#lblLocation").text(resData.Location);
        $("#lblClientname").text(resData.Clientname);
        $("#lblContactperson").text(resData.Contactname);

        $("#lblRate1").text(resData.Minrate);
        $("#lblRate2").text(resData.Maxrate);

        if (resData.Ratetype == 10000) {
            $("#lblRatetype").text("Rate / Day");
        }
        else if (resData.Ratetype == 10001) {
            $("#lblRatetype").text("Rate / Week");
        }
        else if (resData.Ratetype == 10002) {
            $("#lblRatetype").text("Rate / Month");
        }

        else if (resData.Ratetype == 10003) {
            $("#lblRatetype").text("Rate / Year");
        }

        else if (resData.Ratetype == 10004) {
            $("#lblRatetype").text("Rate / Hour");
        }


        $("#lblStartdate").text(resData.Startdate);
        $("#lblNoofopening").text(resData.Noofopening);
        $("#lblShifttiming").text(resData.ShiftTiming);
        $("#lblTurnaroundtime").text(resData.TurnAroundtime);
        $("#lblCurrency").text(resData.Currency);


        $("#lblCreatedname").text(resData.Created_By);
        $("#lblcreatedate").text(resData.Created_On);
        $("#lblcreatetime").text(resData.Created_Time);
        $("#lblUpdatedname").text(resData.Updated_By);
        $("#lblUpdatedate").text(resData.Updated_On);
        $("#lblUpdatetime").text(resData.Updated_Time);

        if (resData.Updated_By == "") {

            $('#update_div').css('display', 'none');
        }
        else {
            $('#update_div').css('display', 'block');
        }
        $("#lblPrioritylevel").text(resData.Prioritylevel);
        $("#lblAssignto").text(resData.AssignedTo);
        $("#lblSkill").text(resData.Skill);

        $("#lblDescription").text(resData.Description);

        setSession("Jobid", resData.Jobcodename);
        setSession("JobTitle", resData.JobTitle);
        setSession("Jobimg", resData.Jobimage);
        setSession("JobDuration", resData.Duration);
        setSession("Type", resData.EmplType);
        setSession("Location", resData.Location);
        setSession("City", resData.City);
        setSession("State", resData.State);
        setSession("ShiftTime", resData.ShiftTiming);
        var listdata = resData.candidatelistinfo;

        createCandTable(listdata);
        getPaging(5);
        //getPagination('#tblCandlist', 5);
    }

    if (key == "CANDSEARCH") {
        //var listdata = resData._lstcandilist;

        createCandTable(resData);
        getPaging(5);
        //getPagination('#tblCandlist', 5);
    }

}

function createCandTable(data) {
    $("#tblCandlist tbody").empty();
    var strTable = "";

    if (getSession('CandCreation') == "1") {
        document.getElementById("btnAdd").style.display = "block";
    }
    else {
        document.getElementById("btnAdd").style.display = "none";
    }

    $.each(data, function (key, item) {
        if (item.Jobcode == "") {

        } else {
            var strImg = "";
            var strImg1 = "";
            var strColumn = "";
            var url = window.location.href;
            hashes = url.split("?")[1];

            if (hashes != null) {
                var hash = hashes.split('&');
                var params = hash[0].split("=");
                if (hash.length > 1) {
                    strColumn = "Feedback";
                }



                if (item.linkedinURL == "") {
                    strImg = "<img src='Images/LinkedIn-no.png' class='avatar avatar-sm me-3' style='margin-right: -1rem !important;'>";
                    strImg1 = "<a>" + strImg + "</a>";
                }
                else if (item.linkedinURL != "") {
                    strImg = "<img src='Images/LinkedIn.png' class='avatar avatar-sm me-3' style='margin-right: -1rem !important;'>";
                    strImg1 = "<a href='" + item.linkedinURL + "' target='_blank'>" + strImg + "</a>";
                }
                strTable += "<tr class='divControl' style='cursor:pointer;'>" +
                    "<td class='align-middle text-center text-sm' style='width: 0rem;'><div>" + strImg1 + "</div></td>"+
                    "<td onclick=gotojobpage('" + item.candidateid +"');> <div class='d-flex px-2 py-1'>" +
                    "<div class='d-flex flex-column justify-content-center'>" +
                    "<h6 class='mb-0 text-sm'>" + item.candidatename + "</h6>" +
                    "<p class='text-xs text-secondary mb-0'><a >" + item.candidateemailid + " | " + item.candidatemobno + " | " + "$" + item.ratePerHr + "/Hr" + " - " + item.type + "</a></p>" +
                    "</div ></div ></td > ";


                strTable += "<td onclick=gotojobpage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.currLocation + "</p><p class='text-xs text-secondary mb-0'>" + item.totYrsExp + " Years Exp</p></td>";


                if (item.candidatestatus == "Submitted to TL" || item.candidatestatus == "Submitted to BP" || item.candidatestatus == "Submitted to EC" || item.candidatestatus == "Closure") {
                    strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.candidateid +"');>" +
                        "<span class='badge badge-sm bg-gradient-success'>" + item.candidatestatus + "</span></td>";
                }

                else if (item.candidatestatus == "TL Rejected" || item.candidatestatus == "BP Rejected" || item.candidatestatus == "EC Rejected") {
                    strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.candidateid +"');>" +
                        "<span class='badge badge-sm bg-gradient-danger'>" + item.candidatestatus + "</span></td>";
                }

                else if (item.candidatestatus == "Draft") {
                    strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.candidateid +"');>" +
                        "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
                }

                else if (item.candidatestatus == "BP Interview" || item.candidatestatus == "EC Interview") {
                    strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.candidateid +"');>" +
                        "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
                }

                else if (item.candidatestatus == "Pipeline") {
                    strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.candidateid +"');>" +
                        "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
                }



                strTable += "<td onclick=gotojobpage('" + item.candidateid +"');><p class='text-xs font-weight-bold mb-0'>" + item.submittedby + "</p><p class='text-xs text-secondary mb-0'> " + item.submitteddate + "|" + item.submittedtime + "</p></td>";
                if (strColumn == "Feedback") {

                    strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                        "<div class='dropdown float-lg-end pe-1'>" +
                        "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                        "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                        "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                        "<li><a class='dropdown-item border-radius-md' href='FeedbackIndia.aspx?id=" + item.candidateid + "&jobid=" + $("#lblJobid").text() + "' id='View'>Feedback</a></li>" +
                        "</ul></div></div></td></tr>";
                }
                else {
                    strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                        "<div class='dropdown float-lg-end pe-1'>" +
                        "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                        "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                        "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                        "<li><a class='dropdown-item border-radius-md' href='Candidate_ViewIndia.aspx?id=" + item.candidateid + "&jobid=" + $("#lblJobid").text() + "' id='View'>View</a></li>" +
                        " <li><a class='dropdown-item border-radius-md' href='CandidateIndia.aspx?jobid=" + $("#lblJobid").text() + "&id=" + item.candidateid + "' id='Edit'>Edit</a></li>" +
                        "</ul></div></div></td></tr>";
                }
            }
        }
    });
    $("#tblCandlist tbody").append(strTable);

}


$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblCandlist', $(this).val());
});

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;

    return [year, month, day].join('-');
}


function getCandPage() {
    var val1 = $('#txtSearch').val();
    var matches = val1.match(/\d+/g);
    var serStr = "";
    if (matches != null) {
        var d = new Date(val1);
        serStr = formatDate(d);
    }
    else {
        serStr = $('#txtSearch').val();
    }

    var st = getSession('Duration').split("$");

    var strdata = { "jobid": $("#lblJobid").text(), "Startdate": st[0], "Enddate": st[1], "searchkey": serStr };
    if ($('#txtSearch').val() != "") {
        common_api_ajax_request("api/FollowupSearch", "CANDSEARCH", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {
        //alert("fill");
    }
}

function gotojobpage(candidateid) {
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