var strTile = ""; 
$(document).ready(function () {
    setSession("Page", "Joblist");
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    if (getSession('Designation') == "4001") {
        $('#div_Feedback').css('display', 'none');
        $('#btnNewJob').css('display', 'none');        
    }

    else {
        $('#div_Feedback').css('display', 'block');
        $('#btnNewJob').css('display', 'block');
    }

    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $("#jobList").addClass("active");
    $('#anchJob').attr('aria-expanded', 'true');
    $("#div_Jobs").addClass("show");

    $('#lblPagetitle').text("Jobs");
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        if (hash.length == 1) {
            getJoblist("Follow Up");
        }

    }

    else {
        getJoblist("Open");
    }
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    
    
}); 

function getJoblist(tileValue) {
    if (tileValue == "Pipeline") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_pipeline").removeClass("colorchange");
        $("#div_pipeline").addClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#lblPipelinevalueus").addClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_highpriority").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Pipeline");
    }

    else if (tileValue == "High Priority") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_highpriority").removeClass("colorchange");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").addClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").addClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_pipeline").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-High Priority");
    }

    else if (tileValue == "No Submission") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_nosubmission").removeClass("colorchange");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").addClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").addClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-No Submission");
    }

    else if (tileValue == "Interview") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#div_interview").removeClass("colorchange");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").addClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").addClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Interview");
    }

    else if (tileValue == "Total") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#lblTotaljobsus").addClass("text-white");
        $("#lblTotaljobsvalueus").addClass("text-white");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange");
        $("#div_TotalHeader").removeClass("colorchange");
        $("#div_interview").removeClass("colorchange");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").addClass("colorchange2");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Total Jobs");
    }

    else if (tileValue == "Open") {
        $("#anchOverview").addClass("change_color");
        $("#anchFollowup").removeClass("change_color");
        $("#div_open").addClass("card-background-mask-info");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblClosureus").removeClass("text-white");
        $("#lblClosurevalueus").removeClass("text-white");
        $("#div_Closure").removeClass("colorchange2");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        strTile = "";
        $('#div_tile').css('display', 'flex');
        $('#lblTableheader').text("Jobs List-Open Jobs");
    }

    else if (tileValue == "Closure") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#lblClosureus").addClass("text-white");
        $("#lblClosurevalueus").addClass("text-white");
        $("#lblTotaljobsus").removeClass("text-white");
        $("#lblTotaljobsvalueus").removeClass("text-white");
        $("#lblPipelinevalueus").removeClass("text-white");
        $("#lblHighpriorityvalueus").removeClass("text-white");
        $("#lblNosubmissionvalueus").removeClass("text-white");
        $("#lblInterviewvalueus").removeClass("text-white");
        $("#div_interview").removeClass("colorchange");
        $("#div_Closure").addClass("colorchange2");
        $("#div_pipeline").removeClass("colorchange2");
        $("#div_highpriority").removeClass("colorchange2");
        $("#div_nosubmission").removeClass("colorchange2");
        $("#div_interview").removeClass("colorchange2");
        $("#div_Total").removeClass("colorchange2");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $('#div_tile').css('display', 'flex');
        strTile = "";
        $('#lblTableheader').text("Jobs List-Closure");
    }

    else if (tileValue == "Follow Up" || tileValue == "Feedback") {
        $("#div_open").removeClass("card-background-mask-info");
        $("#anchOverview").removeClass("change_color");
        $("#anchFollowup").addClass("change_color");
        $("#div_Total").addClass("colorchange");
        $("#div_TotalHeader").addClass("colorchange");
        $("#div_interview").addClass("colorchange");
        $("#div_nosubmission").addClass("colorchange");
        $("#div_highpriority").addClass("colorchange");
        $("#div_pipeline").addClass("colorchange");
        $('#div_tile').css('display', 'none');
        $("#lblTableheader").text("Jobs-Follow Up List");

        if (tileValue == "Feedback") {
            strTile = "Feedback";
            $("#anchOverview").removeClass("change_color");
            $("#anchFollowup").addClass("change_color");
            $('#div_tile').css('display', 'none');
            $("#lblTableheader").text("Jobs-Feedback List");
        }

    }



    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "tiletype": tileValue };
    if (TWE_Id != "") {
        common_api_ajax_request("api/JobList", "JOBLIST", strdata);
    }
    else {
        alert("fill");
    }
}

function getJobPage() {
    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "searchkey": $('#txtSearch').val()};
    if ($('#txtSearch').val() != "" ) {
        common_api_ajax_request("api/Search", "JOBSEARCH", strdata);
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

    if (key == "JOBLIST") {

        $('#lblOpenjobsus').text(resData.lsttiles[0].TileTitle);
        $('#lblOpenjobsvalueus').text(resData.lsttiles[0].TotalCount);        

        $('#lblPipelineus').text(resData.lsttiles[1].TileTitle);
        $('#lblPipelinevalueus').text(resData.lsttiles[1].TotalCount);

        $('#lblHighpriorityus').text(resData.lsttiles[2].TileTitle);
        $('#lblHighpriorityvalueus').text(resData.lsttiles[2].TotalCount);       

        $('#lblInterviewus').text(resData.lsttiles[3].TileTitle);
        $('#lblInterviewvalueus').text(resData.lsttiles[3].TotalCount);

        $('#lblClosureus').text(resData.lsttiles[4].TileTitle);
        $('#lblClosurevalueus').text(resData.lsttiles[4].TotalCount);

        $('#lblTotaljobsus').text(resData.lsttiles[5].TileTitle);
        $('#lblTotaljobsvalueus').text(resData.lsttiles[5].TotalCount);

        $('#lblNosubmissionus').text(resData.lsttiles[6].TileTitle);        
        $('#lblNosubmissionvalueus').text(resData.lsttiles[6].TotalCount);

        createJobTable(listdata);
        getPaging(5);
        //getPagination('#tblJoblist', 5);
        stopLoader();
    }

    else if (key == "JOBSEARCH") {

        createJobTable(listdata);
        getPaging(5);
        //getPagination('#tblJoblist', 5);
        stopLoader();
        //stopLoader();
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
                strTable += "<tr class='divControl'><td onclick=gotojobpage('" + item.Jobcode +"');><div class='d-flex px-2 py-1'>" +
                    "<div><img src='" + item.JobMediaPath + "' class='avatar avatar-sm me-3'></div>" +

                    "<div class='d-flex flex-column justify-content-center'>" +

                    "<label class='mb-0 text-sm h6' id='lblJobname'>" + item.JobTitle + "</label>" +
                    "<label class='m-0'>" +
                    "<label class='text-secondary' id='lblJobmonth'>" + item.JobDuration + "</label>|<label class='text-secondary' id='lblJobcontract'>" + item.JobType + "</label>|<label class='text-secondary' id='lblJobcity'>" + item.JobCity + "," + item.JobState + "</label></label>" +
                    "</div></div></td>";


                strTable += "<td onclick=gotojobpage('" + item.Jobcode +"');><div class='col-md- 12'>" +
                    "<label class='text-xs font-weight-bold mb-0 ps-0'>" + item.JobClient + "</label > <br />" +
                    "</div ><div class='col-md-12' style='margin-top: -10px;'>" +
                    "<label class='text-xs text-secondary mb-0 ps-0'>" + item.JobContact + "</label>" +
                    "</div></td>";

               
                if (item.JobStatus=="Open") {
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
                
                //if (strTile=="Feedback") {

                
                //    strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                //        "<div class='dropdown float-lg-end pe-1'>" +
                //        "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                //        "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                //        "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                //        //"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
                //        //" <li><a class='dropdown-item border-radius-md' href='AddJobcode.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
                //        " <li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "&mode=Feedback' id='Feedback'>Feedback</a></li>" +
                //        "</ul></div></div></td></tr>";

                //}
                //else {
                //    if (getSession('Designation') == "4001") {

                //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                //            "<div class='dropdown float-lg-end pe-1'>" +
                //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                //            "<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
                //            //" <li><a class='dropdown-item border-radius-md' href='AddJobcode.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
                //            "</ul></div></div></td></tr>";
                //    }

                //    else {
                //        strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                //            "<div class='dropdown float-lg-end pe-1'>" +
                //            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                //            "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                //            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                //            "<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +
                //            " <li><a class='dropdown-item border-radius-md' href='AddJobcode.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>" +
                //            "</ul></div></div></td></tr>";
                //    }
                //}


                var strAction1 = "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                    "<div class='dropdown float-lg-end pe-1'>" +
                    "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                    "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                    "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>";

                var strAction3 = "</ul></div></div></td></tr>";

                var strAction21 = "";

                var strAction22 = "";

                if (getSession('JobView') == "2") {
                    //if (assigneduser == true) {
                    //}
                    //else {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
                    //}
                }
                else if (getSession('JobView') == "1") {
                    if (assigneduser == true) {
                        strAction21 = "<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>";
                    }
                }


                if (getSession('JobEdit') == "2") {
                    //if (assigneduser == true) {
                    //}
                    //else {
                    strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";
                    //}
                }

                else if (getSession('JobEdit') == "1") {
                    if (assigneduser == true) {
                        strAction22 = " <li><a class='dropdown-item border-radius-md' href='AddJobcode.aspx?id=" + item.Jobcode + "' id='Edit'>Edit</a></li>";
                    }
                }



                strTable += strAction1 + strAction21 + strAction22 + strAction3;


        }
       
    });
    
        $("#tblJoblist tbody").append(strTable);
    
}



function gotojobpage(jobid) {
    window.location.href = "FollowupPage.aspx?id=" + jobid;
}