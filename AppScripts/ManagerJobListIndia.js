var strTile = "";
$(document).ready(function () {
    setSession("Page", "ManagerJoblistIndia");

  
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $("#jobList").addClass("active");
    $('#anchJob').attr('aria-expanded', 'true');
    $("#div_Jobs").addClass("show");
    $('#lblPagetitle').text("Jobs");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    getEmployeeDetails();

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        if (hash.length == 1) {
            getJoblist('Feedback', 'All');
        }        
    }
    else {
        getJoblist("Open", "");
    }
    
    
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function getJoblist(tileValue, filtertype) {
   
    if (tileValue == "Feedback") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_feedback").removeClass("colorchange");
        $("#div_feedback").addClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").addClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        strTile = "Feedback";
        $('#lblTableheader').text("Jobs List-Feedback");
        $('#div_duration').css('display', 'flex');
        if (filtertype == "All") {
            $('input[id="serFilter1"]').prop("checked", true);
        }
        else {
            $('input[id="serFilter2"]').prop("checked", true);
        }

    }

    else if (tileValue == "TL Submitted") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_TLsubmitted").removeClass("colorchange");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").addClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").addClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#div_feedback").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-TL Submitted");
        $('#div_duration').css('display', 'none');
    }

    else if (tileValue == "No Submission") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_nosubmission").removeClass("colorchange");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").addClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").addClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#div_feedback").addClass("colorchange");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-No Submission");
        $('#div_duration').css('display', 'none');
    }

    else if (tileValue == "Interview") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_interview").removeClass("colorchange");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_interview").addClass("colorchange2");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").addClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_feedback").addClass("colorchange");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Interview");
        $('#div_duration').css('display', 'none');
    }

    else if (tileValue == "Overall") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_Total").removeClass("colorchange");
        $("#div_Total").addClass("colorchange2");
        $("#lblTotaljobsus").addClass("text-white");
        $("#lblTotaljobsvalueus").addClass("text-white");
        $("#div_TotalHeader").removeClass("colorchange");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_feedback").addClass("colorchange");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Overall Jobs");
        $('#div_duration').css('display', 'none');
    }

    else if (tileValue == "Closure") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_Closure").addClass("colorchange2");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_feedback").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#lblClosureus").addClass("text-white");
        $("#lblClosurevalueus").addClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_feedback").addClass("colorchange");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Interview");
        $('#div_duration').css('display', 'none');
    }

    else if (tileValue == "Open") {

        $("#div_open").addClass("card-background-mask-info");

        $("#div_feedback").removeClass("colorchange2");
        $("#div_TLsubmitted").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_feedback").addClass("colorchange");
        $("#div_TLsubmitted").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $("#div_Closure").addClass("colorchange");
        $("#div_ClosureHeader").addClass("colorchange");
        $("#div_Closure").removeClass("colorchange2");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#lblFeedbackvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblTLSubmittedvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $('#div_duration').css('display', 'none');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Open Jobs");
        $('#div_duration').css('display', 'none');
    } 

 
    var TWE_Id = getSession('TWE_ID');
    var strdata = { "TWE_Id": TWE_Id, "tiletype": tileValue, "filtertype": filtertype };
        if (TWE_Id != "") {
            common_api_ajax_request("api/ManagerJobListIndia", "MANAGERJOBLISTINDIA", strdata);
        }
        else {
            alert("fill");
        }
}

function getJobPage() {
    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "searchkey": $('#txtSearch').val() };
    if ($('#txtSearch').val() != "") {
        common_api_ajax_request("api/JobListIndia", "JOBSEARCHIND", strdata);
        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
    } else {

        getJoblist("Open");
        //alert("fill");
    }
}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;
    var listdata = resData.lstJob;

    if (key == "MANAGERJOBLISTINDIA") {
        $('#lblOpenjobsus').text(resData.lsttiles[0].TileTitle);
        $('#lblOpenjobsvalueus').text(resData.lsttiles[0].TotalCount);

        $('#lblFeedbackus').text(resData.lsttiles[1].TileTitle);
        $('#lblFeedbackvalueus').text(resData.lsttiles[1].TotalCount);
        $('#lblFeedbackvalueus').text(resData.lsttiles[1].TotalCount);

        $('#lblTLSubmittedus').text(resData.lsttiles[2].TileTitle);
        $('#lblTLSubmittedvalueus').text(resData.lsttiles[2].TotalCount);

        $('#lblInterviewus').text(resData.lsttiles[3].TileTitle);
        $('#lblInterviewvalueus').text(resData.lsttiles[3].TotalCount);

        $('#lblClosureus').text(resData.lsttiles[4].TileTitle);
        $('#lblClosurevalueus').text(resData.lsttiles[4].TotalCount);

        $('#lblTotaljobsus').text(resData.lsttiles[5].TileTitle);
        $('#lblTotaljobsvalueus').text(resData.lsttiles[5].TotalCount);

        $('#lblNosubmissionus').text(resData.lsttiles[6].TileTitle);
        $('#lblNosubmissionvalueus').text(resData.lsttiles[6].TotalCount);
        if (listdata.length != 0) {
            $('#div_record').css('display', 'block');
            $('#div_norecord').css('display', 'none');
            createJobTable(listdata);
            getPaging(5);
        }

        else {
            $('#div_record').css('display', 'none');
            $('#div_norecord').css('display', 'block');
        }

        
        
        //getPagination('#tblJoblist', 5);
        stopLoader();
    }

    else if (key == "JOBSEARCHIND") {

        if (listdata.length != 0) {
            $('#div_record').css('display', 'block');
            $('#div_norecord').css('display', 'none');
            createJobTable(listdata);
            getPaging(5);
        }

        else {
            $('#div_record').css('display', 'none');
            $('#div_norecord').css('display', 'block');
        }
        //getPagination('#tblJoblist', 5);
        stopLoader();
        //stopLoader();
    }
    else if (key == "EMPLOYEE") {

        var option1 = new Option("--Select Employee--", "-1");
        $(option1).html("--Select Employee--");
        $("#drpEmployee").append(option1);

        for (var i = 0; i < resData.lstEmployee.length; i++) {

            var option = new Option(resData.lstEmployee[i].Name, resData.lstEmployee[i].ID);

            $(option).html(resData.lstEmployee[i].Name);
            $("#drpEmployee").append(option);
        }

        stopLoader();
    }

}


$('#maxRows').on('change', function () {
    getPaging($(this).val());
    //getPagination('#tblJoblist', $(this).val());
});
function createJobTable(data) {
    $("#tblJoblist tbody").empty();
    var strTable = "";
    if (getSession('JobCreation') == "1") {
        document.getElementById("btnNewJob").style.display = "";
    }
    else {
        document.getElementById("btnNewJob").style.display = "none";
    }

    $.each(data, function (key, item) {

        var assigneduser = item.Assigned_To.includes(getSession('TWE_ID'));
        
        if (item.Jobcode == "") {

        } else {
            strTable += "<tr style='cursor:pointer;' class='divControl' ><td onclick=gotojobpage('" + item.Jobcode +"');><div class='d-flex px-2 py-1'>" +
                "<div><img src='" + item.JobMediaPath + "' class='avatar avatar-sm me-3'></div>" +

                "<div class='d-flex flex-column justify-content-center'>" +

                "<label class='mb-0 text-sm h6' id='lblJobname'>" + item.JobTitle + "</label>" +
                "<label class='m-0'>" +
                "<label class='text-secondary' id='lblJobmonth'>" + item.JobDuration + "</label>|<label class='text-secondary' id='lblJobcontract'>" + item.JobType + "</label>|<label class='text-secondary' id='lblJobcity'>" + item.JobState + "</label></label>" +
                "</div></div></td>";


            strTable += "<td onclick=gotojobpage('" + item.Jobcode +"');><div class='col-md- 12'>" +
                "<label class='text-xs font-weight-bold mb-0 ps-0'>" + item.JobClient + "</label > <br />" +
                "</div ><div class='col-md-12' style='margin-top: -10px;'>" +
                "<label class='text-xs text-secondary mb-0 ps-0'>" + item.JobContact + "</label>" +
                "</div></td>";


            if (item.JobStatus == "Open") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode +"');>" +
                    "<span class='badge badge-sm bg-gradient-success'>" + item.JobStatus + "</span></td>";
            }

            else if (item.JobStatus == "Close") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode +"');>" +
                    "<span class='badge badge-sm bg-gradient-danger'>" + item.JobStatus + "</span></td>";
            }

            else if (item.JobStatus == "Hold") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode +"');>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.JobStatus + "</span></td>";
            }


            strTable += "<td class='align-middle text-center' onclick=gotojobpage('" + item.Jobcode +"');><label class='text-secondary text-xs font-weight-bold mb-0 ps-0' id='lblJobopendate'>" + item.CreatedOn + "</label></td>";


            var strAction1 = "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>";

            var strAction3 = "</ul></div></div></td></tr>";

            var strAction21 = "";

            var strAction22 = "";

            var strAction23 = "";

            //alert(getSession('JobView'));
            //alert(getSession('JobEdit'));
            
            if (getSession('JobView') == "2") {
                //if (assigneduser == true) {
                //}
                //else {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
               // }
            }
            else if (getSession('JobView') == "1") {
                if (assigneduser == true) {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
                }
            }


            if (getSession('JobEdit') == "2") {
                //if (assigneduser == true) {
                //}
                //else {
                    strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";
                //}
            }

            else if (getSession('JobEdit') == "1") {
                if (assigneduser == true) {
                    strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";
                }
            }
           
            if (getSession('JobFeedback') == "2") {
                //if (assigneduser == true) {
                //}
                //else {
               
                if (strTile == "Feedback") {

                    strAction21 = "";
                    strAction22 = "";

                    if ($('input[id="serFilter2"]').prop("checked") == true && $('select#drpEmployee option:selected').val() != "-1") {
                        strAction23 = " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback&createdby=" + $('select#drpEmployee option:selected').val() + "' id='Feedback'>Feedback</a></li>";
                    }
                    else {
                        strAction23 = " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback' id='Feedback'>Feedback</a></li>";
                    }
                }

                else {
                    
                        strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
                        strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";                    

                }
                   
                //}
            }

            else if (getSession('JobFeedback') == "1") {
                
                if (assigneduser == true) {
                    if (strTile == "Feedback") {
                        strAction21 = "";
                        strAction22 = "";
                        if ($('input[id="serFilter2"]').prop("checked") == true && $('select#drpEmployee option:selected').val() != "-1") {
                            strAction23 = " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback&createdby=" + $('select#drpEmployee option:selected').val() + "' id='Feedback'>Feedback</a></li>";
                        }
                        else {
                            strAction23 = " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback' id='Feedback'>Feedback</a></li>";
                        }
                    }
                }
                else {

                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
                    strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";

                }
            }

            strTable += strAction1 + strAction21 + strAction22+ strAction23 + strAction3;

           
           

            //if (strTile == "Feedback") {

            //    if ($('input[id="serFilter2"]').prop("checked") == true && $('select#drpEmployee option:selected').val()!="-1") {
                   
            //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
            //            "<div class='dropdown float-lg-end pe-1'>" +
            //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

            //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //            //"<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
            //            //" <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
            //            " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback&createdby=" + $('select#drpEmployee option:selected').val()+"' id='Feedback'>Feedback</a></li>" +
            //            "</ul></div></div></td></tr>";
            //    }

            //    else {
            //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
            //            "<div class='dropdown float-lg-end pe-1'>" +
            //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

            //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //            //"<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
            //            //" <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
            //            " <li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "&mode=Feedback' id='Feedback'>Feedback</a></li>" +
            //            "</ul></div></div></td></tr>";
            //    }

            //}
            //else {

            //    if (getSession('Designation') == "4001") {

            //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
            //            "<div class='dropdown float-lg-end pe-1'>" +
            //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

            //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //            "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
            //            //" <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
            //            "</ul></div></div></td></tr>";
            //    }

            //    else {
            //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
            //            "<div class='dropdown float-lg-end pe-1'>" +
            //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

            //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //            "<li><a class='dropdown-item border-radius-md' href='FollowupPageIndia.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
            //            " <li><a class='dropdown-item border-radius-md' href='AddJobcode_Ind.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
            //            "</ul></div></div></td></tr>";
            //    }
            //}
        }

    });

    $("#tblJoblist tbody").append(strTable);

}


function gotojobpage(jobid) {
    window.location.href = "FollowupPageIndia.aspx?id=" + jobid;
}

function getEmployeeDetails() {
    var strdata = {"region":"2000"};
    common_api_ajax_request("api/DropdownList", "EMPLOYEE", strdata);

}

function getFeedback() {
    var filtertype = "";
    if ($('input[id="serFilter1"]').prop("checked") == true) {       
        filtertype = "All";
    }
    else if ($('input[id="serFilter2"]').prop("checked") == true) {
        filtertype = $('select#drpEmployee option:selected').val();
    }
    getJoblist('Feedback', filtertype);   
}