var feedbacktype = "";
var feedbackGivencount = 0;
var feedbackTotalcount = 0;

$(document).ready(function () {

    setSession("Page", "ManagerDashboardIndia");
    $('#lblEmployeename').text(getSession('Name'));
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    $('#lblPagetitle').text("Manager Feedback");

    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchCand").removeClass("active");
    

    if (getSession('Rolename') == "Recruiter") {
        $("#anchPerf").addClass("active");
        $('#btnval').text("View Feedback");
    }
    else {
        $("#anchTeam").addClass("active");
        $('#anchTeam').attr('aria-expanded', 'true');
        $("#div_Team").addClass("show");
        $("#teamList").addClass("active");
        $('#btnval').text("Give Feedback");
    }

    var currDate = new Date();

    var dt1 = "01" + "-" + (currDate.getMonth() + 1) + "-" + currDate.getFullYear();
    var dt2 = "01-02-2032";



    if (document.querySelector('#txtFeedbackdatefb')) {
        flatpickr('#txtFeedbackdatefb', {
            //mode: "range",
            dateFormat: "d-m-Y",
            //disable: ["30-01-2021", "21-01-2022", "08-03-2021"],
            disable: [{
                from: dt1,
                to: dt2
            }]
            //disable: ["2021-01-30", "2021-02-21", "2021-03-08" ],
        }); // flatpickr
    }

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        var params1 = hash[1].split("=");
        setSession("RecruiterID", params[1]);
        $('#txtcandidatename').text(params1[1].replace("%20", " "));

        //getMgrDashboardPage(params[1], getSession('Duration'), "");
    }
});

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    var listdata = resData.lstJob;

    if (key == "MGRDASHBOARD") {

        $('#div_performancetitle').css('display', 'flex');
        $('#lblPerformancetitle').text("Performance of " + resData.UserName + " for the duration of " + mgrfeedback);
        $('p#p_Total').text(resData.Tiles[0].TileTitle);
        $('#lblTotaljob').text(pad2(resData.Tiles[0].TotalCount));
        //$('#lblActivejob').text(resData.Tiles[0].Name + " " + pad2(resData.Tiles[0].AchiveCount));
        $('p#p_Inte').text(resData.Tiles[1].TileTitle);
        $('#lblInterview').text(pad2(resData.Tiles[1].TotalCount));
        //$('#lblResumeEC').text(resData.Tiles[1].Name + " " + pad2(resData.Tiles[1].AchiveCount));
        $('p#p_Cand').text(resData.Tiles[2].TileTitle);
        $('#lblCandidateAdd').text(pad2(resData.Tiles[2].TotalCount));
        //$('#lblNewVendors').text(resData.Tiles[2].Name + " " + pad2(resData.Tiles[2].AchiveCount));
        $('p#p_Clos').text(resData.Tiles[3].TileTitle);
        $('#lblMadeclosure').text(pad2(resData.Tiles[3].TotalCount));
        //$('#lblOnLive').text(resData.Tiles[3].Name + " " + pad2(resData.Tiles[3].AchiveCount));

        $('#lblBarTitle').text(resData.BarTitle);
        $('#lblBarDuration').text(resData.BarDuration + " " + mgrfeedback);

        $('#divBarchart').empty();
        $('#divBarchart').append(resData.Barchart);

        $('#lblSubTitle1').text(resData.LinechartTitle);
        $('#lblSubTitle2').text(resData.LineDuration + " " + mgrfeedback);

        $('p#p_SB').text(resData.StatusCount[0].StatusTitle);
        $('#lblSubCount').text(pad2(resData.StatusCount[0].StatusValue));
        $('p#p_TL').text(resData.StatusCount[1].StatusTitle);
        $('#lblTl').text(pad2(resData.StatusCount[1].StatusValue));
        $('p#p_BP').text(resData.StatusCount[2].StatusTitle);
        $('#lblSubBp').text(pad2(resData.StatusCount[2].StatusValue));
        $('p#p_EC').text(resData.StatusCount[3].StatusTitle);
        $('#lblEc').text(pad2(resData.StatusCount[3].StatusValue));

        $('#divLinechart').empty();
        $('#divLinechart').append(resData.Linechart);

        $('#chart-bars').height(170);
        $('#chart-line').height(300);

        if (parseInt(resData.OverViewPercentage) >= 75) {
            $('#icon_overview').addClass("fas fa-angle-double-up text-success");
        }
        else if (parseInt(resData.OverViewPercentage) >= 50) {
            $('#icon_overview').addClass("fa fa-arrow-up text-success");
        }


        else if (parseInt(resData.OverViewPercentage) >= 25) {
            $('#icon_overview').addClass("fa fa-arrows-alt-h text-warning");
        }
        else if (parseInt(resData.OverViewPercentage) < 24) {
            $('#icon_overview').addClass("fa fa-arrow-down text-danger");
        }


        //$('#lblCanTitle').text(resData.PerformaceOverView[1].PerformanceName);

        //$('#lblECTitle').text(resData.PerformaceOverView[2].PerformanceName);
        $('#lblECClosures').text(pad2(resData.lstTarget[0].Closure_Daily) + "/" + pad2(resData.lstTarget[1].Closure_Daily) + " Candidates");
        //$('#lblSBTitle').text(resData.PerformaceOverView[3].PerformanceName);
        $('#lblBPSelected').text(pad2(resData.lstTarget[0].SubmissiontoBP_Daily) + "/" + pad2(resData.lstTarget[1].SubmissiontoBP_Daily) + " Profiles");
        $('#lblCandidates').text(pad2(resData.lstTarget[0].Submission_Daily) + "/" + pad2(resData.lstTarget[1].Submission_Daily) + " Connected");
        $('#lblTLApproved').text(pad2(resData.lstTarget[0].SubmissiontoTL_Daily) + "/" + pad2(resData.lstTarget[1].SubmissiontoTL_Daily) + " Profiles");
        //$('#lblVenTitle').text(resData.PerformaceOverView[5].PerformanceName);
        $('#lblVendors').text(pad2("0") + "/" + pad2("0") + " Connected");

        $('#lblPerformanceVal').text(resData.OverViewPercentage + " " + mgrfeedback);
        $('#lblTeammember1').text(resData.UserName + "'s");
        $('#lblTeammember2').text(resData.UserName);
        $('#lblTeammembername').text(resData.UserName);
        //$('#txtCandidateadding').val(resData.Target.CandidateValue);
        //$('#txtVendorcreation').val(resData.Target.Vendorsvalue);
        //$('#txtSubmission').val(resData.Target.SubmittiontoValue);
        //$('#txtTLApproval').val(resData.Target.TlApprovalValue);
        //$('#txtBPApproval').val(resData.Target.BPApprovalValue);
        //$('#txtECApproval').val(resData.Target.ECApprovalValue);

        //$('#txtCandidateaddachieved').val(pad2(resData.PerformaceOverView[1].PerformanceCount));
        //$('#txtVendorachieved').val(pad2(resData.PerformaceOverView[5].PerformanceCount));
        //$('#txtSubmissionachieved').val(pad2(resData.PerformaceOverView[3].PerformanceCount));
        //$('#txtTLApprovalachieved').val(pad2(resData.PerformaceOverView[4].PerformanceCount));
        //$('#txtBPApprovalachieved').val(pad2(resData.PerformaceOverView[0].PerformanceCount));
        //$('#txtECApprovalachieved').val(pad2(resData.PerformaceOverView[2].PerformanceCount));

        createJobTable(listdata);
        getPaging(5);
        $('#div_CandidateJobs').css('display', 'block');

        $("#div_total").removeClass("colorchange");
        $("#div_total").addClass("colorchange2");
        $("#div_interview").addClass("colorchange");
        $("#div_jobcandidates").addClass("colorchange");
        $("#div_closures").addClass("colorchange");
        //getPagination('#tblJoblist', 5);

        $('#div_performanceinfo').css('display', 'block');
        $('#chart-bars').height(300);

        $('#chart-line').height(430);
        stopLoader();
    }


    else if (key == "TEAMFEEDBACK") {
        $("#div-message").text('Feedback saved successfully');
        $("#msgpopup").modal('show');
        $("#btnOk").attr("onclick", "closepopup();");
        stopLoader();
    }

    else if (key == "TARGETDATA") {

        $('#div_rating').removeClass("divhide");
        $('#div_chart').removeClass("divhide");
        $('#div_overallrating').removeClass("divhide");

        $('#div_feedbackcontent').removeClass("divhide");
        $('#txtComments').removeClass("is-invalid");
        $('#div_feedbackcontent').addClass("divshow");


        $('#divfeedbackcontent').removeClass("divhide");
        $('#divfeedbackcontent').addClass("divshow");

        document.getElementById("drpOverallRemarks").options.length = 0;

        var option1 = new Option("--Select Remarks--", "-1");
        $(option1).html("--Select Remarks--");
        $("#drpOverallRemarks").append(option1);

        for (var i = 0; i < resData.lstRemarks.length; i++) {

            var option = new Option(resData.lstRemarks[i].Name, resData.lstRemarks[i].ID);

            $(option).html(resData.lstRemarks[i].Name);
            $("#drpOverallRemarks").append(option);
        }

        $('#divdoughnutchart').empty();
        $('#divdoughnutchart').append(resData.Barchart);
        // $('#divdoughnutchart').append("Doughnut");       

        $('#divdoughnutchartprev').empty();
        $('#divdoughnutchartprev').append(resData.Linechart);
        // $('#divdoughnutchartprev').append("Doughnut-Prev");  


        $('#chart-consumption').height(145);
        $('#chart-consumption').width(300);

        $('#chart-consumptionprev').height(145);
        $('#chart-consumptionprev').width(300);
        $('#lblprevweek').text($('#hdnprevweek').val());

        $('#lblsubmssiontarget').text(resData.lstTarget[1].Submission_Daily != null ? pad2(resData.lstTarget[1].Submission_Daily) : "00");
        $('#lblsubmssionachived').text(pad2(resData.lstTarget[0].Submission_Daily));
        $('#lblsubmissionvalue').text(Math.round(pad2(resData.lstTarget[0].SBPercentage)));
        getRemarks(parseInt($('#lblsubmissionvalue').text()), "#lblsubmissionper");

        $('#lbltltarget').text(resData.lstTarget[1].SubmissiontoTL_Daily != null ? pad2(resData.lstTarget[1].SubmissiontoTL_Daily) : "00");
        $('#lbltlachived').text(pad2(resData.lstTarget[0].SubmissiontoTL_Daily));
        $('#lbltlvalue').text(Math.round(pad2(resData.lstTarget[0].TLPercentage)));
        getRemarks(parseInt($('#lbltlvalue').text()), "#lblsubmissiontlper");

        $('#lblbptarget').text(resData.lstTarget[1].SubmissiontoBP_Daily != null ? pad2(resData.lstTarget[1].SubmissiontoBP_Daily) : "00");
        $('#lblbpachived').text(pad2(resData.lstTarget[0].SubmissiontoBP_Daily));
        $('#lblbpvalue').text(Math.round(pad2(resData.lstTarget[0].BPPercentage)));
        getRemarks(parseInt($('#lblbpvalue').text()), "#lblsubmissionbpper");

        $('#lblecsubmissionvalue').text(pad2(resData.lstTarget[0].SubmissiontoEC_Daily));

        if (parseInt($('#lblecsubmissionvalue').text()) > 0) {
            $('#lblecsubmissionper').text("Good");
            $('#lblecsubmissionper').addClass("badge badge-sm bg-gradient-success");
        }
        else {
            $('#lblecsubmissionper').text("Bad");
            $('#lblecsubmissionper').addClass("badge badge-sm bg-gradient-danger");
        }



        $('#lblsubmissionchartval').text($('#lblsubmissionvalue').text() + "%");
        $('#lbltlchartval').text($('#lbltlvalue').text() + "%");
        $('#lbllbpchartval').text($('#lblbpvalue').text() + "%");

        $('#lblprevsubchartval').text(Math.round(resData.lstprevTarget[0].SBPercentage) + "%");
        $('#lblprevtlchartval').text(Math.round(resData.lstprevTarget[0].TLPercentage) + "%");
        $('#lblprevbpchartval').text(Math.round(resData.lstprevTarget[0].BPPercentage) + "%");



        if (feedbacktype == "Monthly") {
            $('#div_closure').removeClass("divhide");
            $('#div_closure').addClass("divshow");

            $('#div_ECSubmission').removeClass("divshow");
            $('#div_ECSubmission').addClass("divhide");

            $('#lblclosuretarget').text(pad2(resData.lstTarget[1].Closure_Daily));
            $('#lblclosureachived').text(pad2(resData.lstTarget[0].Closure_Daily));
            $('#lblclosurevalue').text(pad2(resData.lstTarget[0].CLPercentage));
            getRemarks(parseInt($('#lblclosurevalue').text()), "#lblclosureper");

            $('#lblsystemgenvalue').text(Math.round(((parseFloat($('#lblsubmissionvalue').text()) + parseFloat($('#lbltlvalue').text()) + parseFloat($('#lblbpvalue').text()) + parseFloat($('#lblclosurevalue').text())) / 4)));
            getRemarks(parseInt($('#lblsystemgenvalue').text()), "#lblsystemgenrating");
            $('#lblprevclchartval').text(resData.lstprevTarget[0].CLPercentage + "%");
            $('#tr_prevclosure').css('display', 'revert');

            $('#lblclchartval').text(resData.lstTarget[0].CLPercentage + "%");
            $('#tr_closure').css('display', 'revert');

            $('#lbloverallperfvalprev').text(Math.round(((parseFloat(resData.lstprevTarget[0].SBPercentage) + parseFloat(resData.lstprevTarget[0].TLPercentage)
                + parseFloat(resData.lstprevTarget[0].BPPercentage) + parseFloat(resData.lstprevTarget[0].CLPercentage)) / 4)));

            $('#lbloverallperfval').text($('#lblsystemgenvalue').text());

            getRatingRemarks('#lbloverallperfval', '#lbloverallperfvalue');
            getRatingRemarks('#lbloverallperfvalprev', '#lbloverallperfvalueprev');
            $('#lbloverallperfval').text($('#lblsystemgenvalue').text() + " %");
            $('#lbloverallperfvalprev').text($('#lbloverallperfvalprev').text() + " %");

            $('#lblselectweek').text($('#lblmonthname').text());
        }

        else {
            $('#lblsystemgenvalue').text(Math.round(((parseFloat($('#lblsubmissionvalue').text()) + parseFloat($('#lbltlvalue').text()) + parseFloat($('#lblbpvalue').text())) / 3)));
            getRemarks(parseInt($('#lblsystemgenvalue').text()), "#lblsystemgenrating");
            $('#tr_closure').css('display', 'none');

            $('#lbloverallperfvalprev').text(Math.round(((parseFloat(resData.lstprevTarget[0].SBPercentage) + parseFloat(resData.lstprevTarget[0].TLPercentage)
                + parseFloat(resData.lstprevTarget[0].BPPercentage)) / 3)));
            $('#lbloverallperfval').text($('#lblsystemgenvalue').text());
            getRatingRemarks('#lbloverallperfval', '#lbloverallperfvalue');
            getRatingRemarks('#lbloverallperfvalprev', '#lbloverallperfvalueprev');
            $('#lbloverallperfval').text($('#lblsystemgenvalue').text() + " %");
            $('#lbloverallperfvalprev').text($('#lbloverallperfvalprev').text() + " %");

            var str = $('#lblWeekinfo').text().split(":")

            $('#lblselectweek').text(str[1]);

            $('#div_ECSubmission').removeClass("divhide");
            $('#div_ECSubmission').addClass("divshow");

            $('#div_closure').removeClass("divshow");
            $('#div_closure').addClass("divhide");
        }

        if (resData.Feedback.Weekinfo != null) {

            if (getSession('Rolename') == "Recruiter") {

                $('#iconoverall').css('display', 'none');
                $('#iconremarks').css('display', 'none');
            }
            else {

                $('#iconoverall').css('display', 'block');
                $('#iconremarks').css('display', 'block');
            }

            $('#txtComments').val(pad2(resData.Feedback.Remarks));
            $("#drpOverallRemarks").val(resData.Feedback.OverallRating).prop("selected", true);

            
            if (getSession('Rolename') == "Recruiter") {
                $('#btnSave').removeClass("divshow");
                $('#btnSave').addClass("divhide");
                $("#drpOverallRemarks").prop('disabled', 'disabled');
                $("#txtComments").prop('disabled', 'disabled');
            }
            else {

                $('#btnSave').addClass("divshow");
                $('#btnSave').removeClass("divhide");
                $("#btnSave").prop('disabled', 'disabled');
                $("#drpOverallRemarks").prop('disabled', 'disabled');
                $("#txtComments").prop('disabled', 'disabled');
            }


        }

        else {
            $('#txtComments').val("");
            //$("#drpOverallRemarks").text($('#lblsystemgenrating').text()).prop("selected", true);
            $('#iconoverall').css('display', 'none');
            $('#iconremarks').css('display', 'none');
            
            if (getSession('Rolename') == "Recruiter") {
                $('#btnSave').removeClass("divshow");
                $('#btnSave').addClass("divhide");
                $("#drpOverallRemarks").prop('disabled', 'disabled');
                $("#txtComments").prop('disabled', 'disabled');
            }
            else {

                $('#btnSave').addClass("divshow");
                $('#btnSave').removeClass("divhide");
                $("#btnSave").prop('disabled', false);
                $("#drpOverallRemarks").prop('disabled', false);
                $("#txtComments").prop('disabled', false);
            }



            var op = document.getElementById("drpOverallRemarks").getElementsByTagName("option");
            for (var i = 0; i < op.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op[i].text == $('#lblsystemgenrating').text()) {

                    op[i].selected = true;
                }
            }

        }

        stopLoader();
    }


    else if (key == "RecruiterDetailsList") {

        createCandTable(resData._lstcandilist);
        //getPagination('#tblCandlist', 5);
        getPaging(5);
        $('#div_ratingtable').removeClass("divhide");
        $('#div_tiles').addClass("divhide");
        stopLoader();
    }

    else if (key == "FEEDBACKINFO") {
        var j = 1;

        var strDrpdown = "";
        feedbackTotalcount = resData.length - 1;
        for (var i = 0; i < resData.length - 1; i++) {
            if (resData[i].Weekinfo != null) {
                if (resData[i].Weekinfo != "") {

                    if (resData[i].status == "0") {
                        strDrpdown += '<li>' +
                            '<a class="dropdown-item" id="anchWeek_' + j + '" href="javascript:;" onclick="getWeekdata(this,0,hdnWeek' + j + '1)">' +
                            'Week ' + j + ': ' + resData[i].Weekinfo +
                            '</a>' +
                            '</li>';
                    }
                    else {
                        strDrpdown += '<li>' +
                            '<a class="dropdown-item" id="anchWeek_' + j + '" href="javascript:;" style="color:green" onclick="getWeekdata(this,1,hdnWeek' + j + '1)">' +
                            'Week ' + j + ': ' + resData[i].Weekinfo +
                            '</a>' +
                            '</li>';
                        feedbackGivencount++;
                    }
                    j++;
                }

            }
        }


        var str = '<div class="dropdown">' +
            '<a href="javascript:;" class="btn bg-gradient-dark dropdown-toggle " data-bs-toggle="dropdown" id="navbarDropdownMenuLink2">' +
            '<i class="far fa-calendar-alt me-2"></i> Choose Week' +
            '</a>' +
            '<ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink2">' + strDrpdown
        //    '<li>' +
        //    '<a class="dropdown-item" href="javascript:;">' +
        //    'Week 1:' + resData[0].Weekinfo +
        //    '</a>' +
        //    '</li>' +
        //    '<li>' +
        //    '<a class="dropdown-item" href="javascript:;">' +
        //    'Week 2:' + resData[1].Weekinfo +
        //    '</a>' +
        //    '</li>' +
        //    '<li>' +
        //    '<a class="dropdown-item" href="javascript:;">' +
        //    'Week 3:' + resData[2].Weekinfo +
        //    '</a>' +
        //    '</li>' +
        //    '<li>' +
        //    '<a class="dropdown-item" href="javascript:;">' +
        //    'Week 4:' + resData[3].Weekinfo +
        //    '</a>' +
        //    '</li>' +
        //    '<li>' +
        //    '<a class="dropdown-item" href="javascript:;">' +
        //'Week 5:' + resData[4].Weekinfo + '</a></li>'+
        '</ul ></div > ';



        $('#div_weekdata').empty();
        $('#div_weekdata').append(str);
        //$('#lblmonthname').removeClass("divhide");
        //$('#icon_refresh').removeClass("divhide");
        //$('#lblmonthname').addClass("divshow");
        //$('#icon_refresh').addClass("divshow");

        $('#div_feedback').css('display', 'block');
        $('#div_mgrfeedbackperfchart').css('display', 'block');
        //$('#lblduration').text(" for the duration of " + document.getElementById("hdnchartdate").value);
        //$('#lblPerformaceVal').text(resData[resData.length - 1].status);

        //$('#chart-consumption').height(200);
        //$('#chart-consumption').width(240);
        $('.flatpickr-calendar').removeClass('open');

        if (parseInt(feedbackGivencount) == parseInt(feedbackTotalcount) && feedbacktype == "Monthly") {

            $("#div-message").text('Feedback not given for all the weeks of the selected month');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup();");
        }
        else {

            if (feedbacktype == "Monthly") {
                getmonthlyTargetData();
                $('#div_monthinfo').removeClass("divhide");
                $('#div_monthinfo').addClass("divshow");
                $('#div_monthinfo').removeClass("text-right");
                $('#div_weekinfo').addClass("divhide");
                $('#div_weekdata').removeClass("divrevert");
                $('#div_weekdata').addClass("divhide");
                if (getSession('Rolename') == "Recruiter") {
                    $('#btnSave').removeClass("divshow");
                    $('#btnSave').addClass("divhide");
                    $("#drpOverallRemarks").prop('disabled', 'disabled');
                    $("#txtComments").prop('disabled', 'disabled');
                }
                else {

                    $('#btnSave').addClass("divshow");
                    $('#btnSave').removeClass("divhide");
                    $("#drpOverallRemarks").prop('disabled', false);
                    $("#txtComments").prop('disabled', false);
                }
                $('#lblWeekinfotitle').addClass("divhide");
            }
            else if (feedbacktype == "Weekly") {
                $('#div_weekdata').removeClass("divhide");
                $('#div_weekdata').addClass("divrevert");
                $('#div_monthinfo').removeClass("divhide");
                $('#div_monthinfo').addClass("divshow");
                $('#div_weekinfo').removeClass("divhide");
            }
        }
        stopLoader();
    }
}

function opendisableComments() {
    if ($('#lblsystemgenrating').text() == $('select#drpOverallRemarks option:selected').text() || $('select#drpOverallRemarks option:selected').val() == "-1") {
        $("#txtComments").prop('disabled', true);
    }
    else {
        $("#txtComments").prop('disabled', false);
    }
}

function getRemarks(percentage, ctrlname) {

    if (!isNaN(percentage)) {

        if (ctrlname == "#lblsystemgenrating") {
            if (percentage >= 0 && percentage <= 25) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("color-red");
                $("#lblsystemgenvalue").addClass("color-red");
                $("#lblsystemgenvalueper").addClass("color-red");

                $(ctrlname).text("Bad");
            }
            else if (percentage > 25 && percentage <= 50) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("color-yellow");
                $("#lblsystemgenvalue").addClass("color-yellow");
                $("#lblsystemgenvalueper").addClass("color-yellow");
                $(ctrlname).text("Need Improvement");
            }
            else if (percentage > 50 && percentage <= 75) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("color-blue");
                $("#lblsystemgenvalue").addClass("color-blue");
                $("#lblsystemgenvalueper").addClass("color-blue");
                $(ctrlname).text("Good");
            }
            else if (percentage > 75 && percentage <= 100) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("color-magenta");
                $("#lblsystemgenvalue").addClass("color-magenta");
                $("#lblsystemgenvalueper").addClass("color-magenta");
                $(ctrlname).text("Excellent");
            }
        }
        else {
            if (percentage >= 0 && percentage <= 25) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("badge badge-sm bg-gradient-danger");
                $(ctrlname).text("Bad");
            }
            else if (percentage > 25 && percentage <= 50) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("badge badge-sm bg-gradient-warning");
                $(ctrlname).text("Need Improvement");
            }
            else if (percentage > 50 && percentage <= 75) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("badge badge-sm bg-gradient-primary");
                $(ctrlname).text("Good");
            }
            else if (percentage > 75 && percentage <= 100) {
                $(ctrlname).removeClass();
                $(ctrlname).addClass("badge badge-sm bg-gradient-success");
                $(ctrlname).text("Excellent");
            }
        }
    }
    else {
        $(ctrlname).removeClass();
        $(ctrlname).text("");
    }

}

function createJobTable(data) {
    $("#tblJoblist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.Jobcode == "") {

        } else {
            strTable += "<tr class='divControl' style='cursor:pointer !important;'><td onclick=gotojobpage('" + item.Jobcode + "');><div class='d-flex px-2 py-1'>" +
                "<div><img src='" + item.JobMediaPath + "' class='avatar avatar-sm me-3'></div>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<label class='mb-0 text-sm h6' id='lblJobname'>" + item.JobTitle + "</label>" +
                "<label class='m-0'>" +
                "<label class='text-secondary' id='lblJobmonth'>" + item.JobDuration + "</label>|<label class='text-secondary' id='lblJobcontract'>" + item.JobType + "</label>|<label class='text-secondary' id='lblJobcity'>" + item.JobCity + "," + item.JobState + "</label></label>" +
                "</div></div></td>";

            strTable += "<td onclick=gotojobpage('" + item.Jobcode + "');><div class='col-md- 12'>" +
                "<label class='text-xs font-weight-bold mb-0 ps-0'>" + item.JobClient + "</label > <br />" +
                "</div ><div class='col-md-12' style='margin-top: -10px;'>" +
                "<label class='text-xs text-secondary mb-0 ps-0'>" + item.JobContact + "</label>" +
                "</div></td>";


            if (item.JobStatus == "Open") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode + "');>" +
                    "<span class='badge badge-sm bg-gradient-success'>" + item.JobStatus + "</span></td>";
            }

            else if (item.JobStatus == "Close") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode + "');>" +
                    "<span class='badge badge-sm bg-gradient-danger'>" + item.JobStatus + "</span></td>";
            }

            else if (item.JobStatus == "Hold") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotojobpage('" + item.Jobcode + "');>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.JobStatus + "</span></td>";
            }


            strTable += "<td class='align-middle text-center' onclick=gotojobpage('" + item.Jobcode + "');><label class='text-secondary text-xs font-weight-bold mb-0 ps-0' id='lblJobopendate'>" + item.CreatedOn + "</label></td>";


            strTable += "<td class='align-middle'><div class='col-lg-3 col-1 my-auto text-end'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i> </a>" +

                "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx?id=" + item.Jobcode + "' id='View'>View</a></li>" +

                "</ul></div></div></td></tr>";

        }

    });

    $("#tblJoblist tbody").append(strTable);

}

function getTileinfo() {
    var TWE_Id = getSession('RecruiterID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "tiletype": tileValue };
    if (TWE_Id != "") {
        common_api_ajax_request("api/RecruiterJobList", "RECRUITERLIST", strdata);
    }
    else {
        alert("fill");
    }
}

Date.prototype.getWeek = function () {
    var onejan = new Date(this.getFullYear(), 0, 1);
    var today = new Date(this.getFullYear(), this.getMonth(), this.getDate());
    var dayOfYear = ((today - onejan + 1) / 86400000);
    return Math.ceil(dayOfYear / 7)
};


var dateListArr = new Array();
var wkdateListArr = new Array();

function getWeekNumber(type) {

    dateListArr.length = 0;
    wkdateListArr.length = 0;
    if (type == "week") {
        var dt = new Date($('#txtFeedbackdatewk').val().substring(6, 10), (parseInt($('#txtFeedbackdatewk').val().substring(3, 5)) - 1), $('#txtFeedbackdatewk').val().substring(0, 2));
    }
    else if (type == "feedback") {
        var dt = new Date($('#txtFeedbackdatefb').val().substring(6, 10), (parseInt($('#txtFeedbackdatefb').val().substring(3, 5)) - 1), $('#txtFeedbackdatefb').val().substring(0, 2));
    }

    var firstDay = new Date(dt.getFullYear(), dt.getMonth(), 1);
    var lastDay = new Date(dt.getFullYear(), dt.getMonth() + 1, 0);


    var temp = new Date(dt.getFullYear(), dt.getMonth(), 1);
    var tempWeek = temp.getWeek();



    for (var i = 0; firstDay <= lastDay; i++) {
        var weekno = parseInt(firstDay.getWeek() + 1);
        var weekObj = {};
        weekObj.dateInfo = firstDay.getFullYear() + "-" + pad2(firstDay.getMonth() + 1) + "-" + pad2(firstDay.getDate());
        weekObj.weekInfo = firstDay.getDay();

        dateListArr.push(weekObj);
        firstDay.setDate(firstDay.getDate() + 1);

    }


    var counter = 0;
    for (var k = 0; k < dateListArr.length; k++) {

        if (dateListArr[k].weekInfo == 0) {
            counter++;
        }

        switch (dateListArr[k].weekInfo) {

            case 0:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 1:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 2:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 3:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 4:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 5:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;

            case 6:
                var newweekObj = {};
                newweekObj.weekNumber = counter;
                newweekObj.dateInfo = dateListArr[k].dateInfo;
                newweekObj.weekInfo = dateListArr[k].weekInfo;
                //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
                wkdateListArr.push(newweekObj);
                break;
        }


        //for (var j = 0; j <= 6; j++) {

        //    var weekObj = {};            
        //    if (dateListArr[k].weekInfo == j) {
        //        weekObj.weekNumber = counter;
        //        weekObj.dateInfo = dateListArr[k].dateInfo;
        //        weekObj.weekInfo = dateListArr[k].weekInfo;
        //        //alert(dateListArr[k].dateInfo + ":" + dateListArr[k].weekInfo);
        //        wkdateListArr.push(weekObj); 
        //        break;
        //    }
        //}   



    }

    var wk1 = new Array;
    var wk2 = new Array;
    var wk3 = new Array;
    var wk4 = new Array;
    var wk5 = new Array;
    var wk6 = new Array;

    var currentwk = 0;
    for (var x = 0; x < wkdateListArr.length; x++) {

        //var dt1, dt2;
        if (wkdateListArr[x].weekNumber == 0) {
            // dt1 = wkdateListArr[x].dateInfo;
            //dt2 = wkdateListArr[x].dateInfo;
            wk1.push(wkdateListArr[x].dateInfo);

            if (type == "week") {
                $('#lblWeek1').append(wkdateListArr[x].dateInfo);
                $('#lblWeek1').append(",");
            }
            else if (type == "feedback") {
                $('#lblWeek11').append(wkdateListArr[x].dateInfo);
                $('#lblWeek11').append(",");
            }

            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek11";
            }

        }

        else if (wkdateListArr[x].weekNumber == 1) {
            // dt1 = wkdateListArr[x].dateInfo;
            //dt2 = wkdateListArr[x].dateInfo;
            wk2.push(wkdateListArr[x].dateInfo);
            if (type == "week") {
                $('#lblWeek2').append(wkdateListArr[x].dateInfo);
                $('#lblWeek2').append(",");
            }
            else if (type == "feedback") {
                $('#lblWeek21').append(wkdateListArr[x].dateInfo);
                $('#lblWeek21').append(",");
            }
            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek21";
            }
        }

        else if (wkdateListArr[x].weekNumber == 2) {
            wk3.push(wkdateListArr[x].dateInfo);
            if (type == "week") {
                $('#lblWeek3').append(wkdateListArr[x].dateInfo);
                $('#lblWeek3').append(",");
            }
            else if (type == "feedback") {
                $('#lblWeek31').append(wkdateListArr[x].dateInfo);
                $('#lblWeek31').append(",");
            }
            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek31";
            }

        }

        else if (wkdateListArr[x].weekNumber == 3) {
            wk4.push(wkdateListArr[x].dateInfo);
            if (type == "week") {
                $('#lblWeek4').append(wkdateListArr[x].dateInfo);
                $('#lblWeek4').append(",");
            }
            else if (type == "feedback") {
                $('#lblWeek41').append(wkdateListArr[x].dateInfo);
                $('#lblWeek41').append(",");
            }
            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek41";
            }
        }

        else if (wkdateListArr[x].weekNumber == 4) {
            wk5.push(wkdateListArr[x].dateInfo);
            if (type == "week") {
                $('#lblWeek5').append(wkdateListArr[x].dateInfo);
                $('#lblWeek5').append(",");
            }

            else if (type == "feedback") {
                $('#lblWeek51').append(wkdateListArr[x].dateInfo);
                $('#lblWeek51').append(",");
            }
            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek51";
            }
        }

        else if (wkdateListArr[x].weekNumber == 5) {
            wk6.push(wkdateListArr[x].dateInfo);
            if (type == "week") {
                $('#lblWeek6').append(wkdateListArr[x].dateInfo);
                $('#lblWeek6').append(",");
            }
            else if (type == "feedback") {
                $('#lblWeek61').append(wkdateListArr[x].dateInfo);
                $('#lblWeek61').append(",");
            }
            if (wkdateListArr[x].dateInfo == (dt.getFullYear() + "-" + pad2(parseInt(dt.getMonth()) + parseInt(1)) + "-" + pad2(dt.getDate()))) {
                currentwk = "lblWeek61";
            }
        }


        //alert(wkdateListArr[x].dateInfo + ":" + wkdateListArr[x].weekInfo + ":" + wkdateListArr[x].weekNumber);
    }


    if (currentwk == "lblWeek11") {
        currentwk = $('#lblWeek11').text();

    }
    else if (currentwk == "lblWeek21") {
        currentwk = $('#lblWeek21').text();
    }
    else if (currentwk == "lblWeek31") {
        currentwk = $('#lblWeek31').text();
    }
    else if (currentwk == "lblWeek41") {
        currentwk = $('#lblWeek41').text();
    }
    else if (currentwk == "lblWeek51") {
        currentwk = $('#lblWeek51').text();
    }
    else if (currentwk == "lblWeek61") {
        currentwk = $('#lblWeek61').text();
    }
    currentwk = currentwk.substring(0, currentwk.length - 1);



    var strdate = currentwk.split(",");
    currentwk = "";
    for (var i = 0; i < strdate.length; i++) {
        currentwk += strdate[i] + ",";
    }
    currentwk = currentwk.substring(0, currentwk.length - 1);
    var currstdate = strdate[0];
    var curretdate = strdate[strdate.length - 1];

    //alert(currentwk);

    //if (document.querySelector('#txtFeedbackdatefb')) {
    //    flatpickr('#txtFeedbackdatefb', {
    //        mode: "range",
    //        dateFormat: "Y-m-d",
    //        //disable: ["30-01-2021", "21-01-2022", "08-03-2021"],
    //        defaultDate: [currstdate, curretdate]
    //        //disable: ["2021-01-30", "2021-02-21", "2021-03-08" ],
    //    }); // flatpickr
    //}
    if (wk1.length != 0) {
        var dt11 = new Date(wk1[0]);
        var dt21 = new Date(wk1[wk1.length - 1]);
        var dd11 = dt11.getDate();
        var dd21 = dt21.getDate();
        var y1 = dt11.getFullYear();


        if (type == "week") {
            if (!isNaN(dd11)) {
                $('#lblWeek1').text(pad2(dd11) + "-" + pad2(dd21) + " " + arr[dt11.getMonth()] + " " + y1);
                $('#hdnWeek1').val(dt11.getFullYear() + "-" + (dt11.getMonth() + 1) + "-" + dt11.getDate() + "$" + dt21.getFullYear() + "-" + (dt21.getMonth() + 1) + "-" + dt21.getDate());

            }


        }
        else if (type == "feedback") {

            $('#lblWeek11').text(pad2(dd11) + " " + arr[dt11.getMonth()] + " to " + pad2(dd21) + " " + arr[dt21.getMonth()] + " " + y1);

            $('#hdnWeek11').val(dt11.getFullYear() + "-" + (dt11.getMonth() + 1) + "-" + dt11.getDate() + "$" + dt21.getFullYear() + "-" + (dt21.getMonth() + 1) + "-" + dt21.getDate());
        }
    }

    var dt12 = new Date(wk2[0]);
    var dt22 = new Date(wk2[wk2.length - 1]);
    var dd12 = dt12.getDate();
    var dd22 = dt22.getDate();
    var y2 = dt12.getFullYear();

    if (type == "week") {
        $('#lblWeek2').text(pad2(dd12) + "-" + pad2(dd22) + " " + arr[dt12.getMonth()] + " " + y2);
        $('#hdnWeek2').val(dt12.getFullYear() + "-" + (dt12.getMonth() + 1) + "-" + dt12.getDate() + "$" + dt22.getFullYear() + "-" + (dt22.getMonth() + 1) + "-" + dt22.getDate());
    }
    else if (type == "feedback") {
        $('#lblWeek21').text(pad2(dd12) + " " + arr[dt12.getMonth()] + " to " + pad2(dd22) + " " + arr[dt22.getMonth()] + " " + y2);
        $('#hdnWeek21').val(dt12.getFullYear() + "-" + (dt12.getMonth() + 1) + "-" + dt12.getDate() + "$" + dt22.getFullYear() + "-" + (dt22.getMonth() + 1) + "-" + dt22.getDate());
    }

    var dt13 = new Date(wk3[0]);
    var dt23 = new Date(wk3[wk3.length - 1]);
    var dd13 = dt13.getDate();
    var dd23 = dt23.getDate();
    var y3 = dt13.getFullYear();

    if (type == "week") {
        $('#lblWeek3').text(pad2(dd13) + "-" + pad2(dd23) + " " + arr[dt13.getMonth()] + " " + y3);
        $('#hdnWeek3').val(dt13.getFullYear() + "-" + (dt13.getMonth() + 1) + "-" + dt13.getDate() + "$" + dt23.getFullYear() + "-" + (dt23.getMonth() + 1) + "-" + dt23.getDate());
    }
    else if (type == "feedback") {
        $('#lblWeek31').text(pad2(dd13) + " " + arr[dt13.getMonth()] + " to " + pad2(dd23) + " " + arr[dt23.getMonth()] + " " + y3);
        $('#hdnWeek31').val(dt13.getFullYear() + "-" + (dt13.getMonth() + 1) + "-" + dt13.getDate() + "$" + dt23.getFullYear() + "-" + (dt23.getMonth() + 1) + "-" + dt23.getDate());
    }

    var dt14 = new Date(wk4[0]);
    var dt24 = new Date(wk4[wk4.length - 1]);
    var dd14 = dt14.getDate();
    var dd24 = dt24.getDate();
    var y4 = dt14.getFullYear();

    if (type == "week") {
        $('#lblWeek4').text(pad2(dd14) + "-" + pad2(dd24) + " " + arr[dt14.getMonth()] + " " + y4);
        $('#hdnWeek4').val(dt14.getFullYear() + "-" + (dt14.getMonth() + 1) + "-" + dt14.getDate() + "$" + dt24.getFullYear() + "-" + (dt24.getMonth() + 1) + "-" + dt24.getDate());
    }
    else if (type == "feedback") {
        $('#lblWeek41').text(pad2(dd14) + " " + arr[dt14.getMonth()] + " to " + pad2(dd24) + " " + arr[dt24.getMonth()] + " " + y4);
        $('#hdnWeek41').val(dt14.getFullYear() + "-" + (dt14.getMonth() + 1) + "-" + dt14.getDate() + "$" + dt24.getFullYear() + "-" + (dt24.getMonth() + 1) + "-" + dt24.getDate());
    }

    var dt15 = new Date(wk5[0]);
    var dt25 = new Date(wk5[wk5.length - 1]);
    var dd15 = dt15.getDate();
    var dd25 = dt25.getDate();
    var y5 = dt15.getFullYear();
    if (type == "week") {
        $('#lblWeek5').text(pad2(dd15) + "-" + pad2(dd25) + " " + arr[dt15.getMonth()] + " " + y5);
        $('#hdnWeek5').val(dt15.getFullYear() + "-" + (dt15.getMonth() + 1) + "-" + dt15.getDate() + "$" + dt25.getFullYear() + "-" + (dt25.getMonth() + 1) + "-" + dt25.getDate());
    }
    else if (type == "feedback") {
        $('#lblWeek51').text(pad2(dd15) + " " + arr[dt15.getMonth()] + " to " + pad2(dd25) + " " + arr[dt25.getMonth()] + " " + y5);
        $('#hdnWeek51').val(dt15.getFullYear() + "-" + (dt15.getMonth() + 1) + "-" + dt15.getDate() + "$" + dt25.getFullYear() + "-" + (dt25.getMonth() + 1) + "-" + dt25.getDate());
    }

    if (wk6.length != 0) {
        var dt16 = new Date(wk6[0]);
        var dt26 = new Date(wk6[wk6.length - 1]);
        var dd16 = dt16.getDate();
        var dd26 = dt26.getDate();
        var y6 = dt16.getFullYear();
        if (type == "week") {
            $('#lblWeek6').text(pad2(dd16) + "-" + pad2(dd26) + " " + arr[dt16.getMonth()] + " " + y6);
            $('#hdnWeek6').val(dt16.getFullYear() + "-" + (dt16.getMonth() + 1) + "-" + dt16.getDate() + "$" + dt26.getFullYear() + "-" + (dt26.getMonth() + 1) + "-" + dt26.getDate());

            $('#div_week6').css('display', 'block');
        }
        else if (type == "feedback") {
            $('#lblWeek61').text(pad2(dd16) + " " + arr[dt16.getMonth()] + " to " + pad2(dd26) + " " + arr[dt26.getMonth()] + " " + y6);
            $('#hdnWeek61').val(dt16.getFullYear() + "-" + (dt16.getMonth() + 1) + "-" + dt16.getDate() + "$" + dt26.getFullYear() + "-" + (dt26.getMonth() + 1) + "-" + dt26.getDate());

            $('#div_week61').css('display', 'block');
        }
    }
    else {
        if (type == "week") {
            $('#div_week6').css('display', 'none');
        }
        else if (type == "feedback") {
            $('#div_week61').css('display', 'none');
        }
    }

    $('#div_week_info').css('display', 'flex');

    if (type == "week") {
        data_Week("txtFeedbackdatewk");
    }
    else if (type == "feedback") {
        data_Week("txtFeedbackdatefb");
    }

    if (type == "feedback") {

        getFeedbackInfo();
    }
}



$("#btnSave").click(function () {

    if (Validateweekinfo() == true) {

        var Remarks = $("#txtComments").val();
        var OverallRating = $('select#drpOverallRemarks option:selected').val();

        var TWEID = getSession('RecruiterID');
        var Feedback_givenby = getSession('TWE_ID');

        //var x = document.getElementsByClassName("active-label");
        //    var Weekinfo = $("#" + x[0].id).text();
        var Weekinfo;

        //alert($("#" + x[0].id).text());
        var Teamperfomanceid = $("#hdnTeamperfomanceid").val();
        var Type = feedbacktype;
        if (feedbacktype == "Weekly") {
            var wkinfo = $("#lblWeekinfo").text().split(":");
            Weekinfo = wkinfo[1];
        }
        else {
            Weekinfo = $("#lblmonthname").text();
        }

        var strdata = {
            "Remarks": Remarks, "OverallRating": OverallRating,
            "TWEID": TWEID, "Feedback_givenby": Feedback_givenby, "Weekinfo": Weekinfo.trim(), "Teamperfomanceid": Teamperfomanceid, "Type": Type
        };
        common_api_ajax_request("api/TeamPerfomanceFeedback", "TEAMFEEDBACK", strdata);


    }

});


function getRecruiterDetails(tileValue) {
    var fromdate;
    var todate;
    if (feedbacktype == "Weekly") {

        var wkinfo = $("#lblWeekinfo").text().split(":");
        Weekinfo = wkinfo[0];
        var st;
        if (Weekinfo == "Week 1") {
            st = $("#hdnWeek11").val().split("$");
        }
        else if (Weekinfo == "Week 2") {
            st = $("#hdnWeek21").val().split("$");
        }
        else if (Weekinfo == "Week 3") {

            st = $("#hdnWeek31").val().split("$");
        }
        else if (Weekinfo == "Week 4") {
            st = $("#hdnWeek41").val().split("$");
        }
        else if (Weekinfo == "Week 5") {
            st = $("#hdnWeek51").val().split("$");
        }
        else if (Weekinfo == "Week 6") {
            st = $("#hdnWeek61").val().split("$");
        }

        fromdate = st[0];
        todate = st[1];
    }
    else if (feedbacktype == "Monthly") {
        fromdate = $("#hdnfirstday").val();
        todate = $("#hdnlastday").val();
    }

    //if (tileValue == "Submission") {
    //    $("#div_interview").removeClass("colorchange");
    //    $("#div_interview").addClass("colorchange2");
    //    $("#div_total").addClass("colorchange");
    //    $("#div_jobcandidates").addClass("colorchange");
    //    $("#div_closures").addClass("colorchange");
    //    $("#div_total").removeClass("colorchange2");
    //    $("#div_jobcandidates").removeClass("colorchange2");
    //    $("#div_closures").removeClass("colorchange2");
    //    $("#lblTableheader").text("Interview-Candidate List");
    //}
    //else if (tileValue == "TL Submission") {
    //    $("#div_jobcandidates").removeClass("colorchange");
    //    $("#div_jobcandidates").addClass("colorchange2");
    //    $("#div_total").addClass("colorchange");
    //    $("#div_interview").addClass("colorchange");
    //    $("#div_closures").addClass("colorchange");
    //    $("#div_total").removeClass("colorchange2");
    //    $("#div_interview").removeClass("colorchange2");
    //    $("#div_closures").removeClass("colorchange2");
    //    $("#lblTableheader").text("Candidate List");
    //}
    //else if (tileValue == "BP Submission") {
    //    $("#div_jobcandidates").removeClass("colorchange");
    //    $("#div_jobcandidates").addClass("colorchange2");
    //    $("#div_total").addClass("colorchange");
    //    $("#div_interview").addClass("colorchange");
    //    $("#div_closures").addClass("colorchange");
    //    $("#div_total").removeClass("colorchange2");
    //    $("#div_interview").removeClass("colorchange2");
    //    $("#div_closures").removeClass("colorchange2");
    //    $("#lblTableheader").text("Candidate List");
    //}
    //else if (tileValue == "EC Submission") {
    //    $("#div_jobcandidates").removeClass("colorchange");
    //    $("#div_jobcandidates").addClass("colorchange2");
    //    $("#div_total").addClass("colorchange");
    //    $("#div_interview").addClass("colorchange");
    //    $("#div_closures").addClass("colorchange");
    //    $("#div_total").removeClass("colorchange2");
    //    $("#div_interview").removeClass("colorchange2");
    //    $("#div_closures").removeClass("colorchange2");
    //    $("#lblTableheader").text("Candidate List");
    //}

    //else if (tileValue == "Closures") {
    //    $("#div_closures").removeClass("colorchange");
    //    $("#div_closures").addClass("colorchange2");
    //    $("#div_total").addClass("colorchange");
    //    $("#div_interview").addClass("colorchange");
    //    $("#div_jobcandidates").addClass("colorchange");
    //    $("#div_total").removeClass("colorchange2");
    //    $("#div_interview").removeClass("colorchange2");
    //    $("#div_jobcandidates").removeClass("colorchange2");
    //}

    var TWE_Id = getSession('RecruiterID');

    $("#lblTableheader").text("Candidate List - " + tileValue);

    var strdata = { "TWE_Id": TWE_Id, "Startdate": fromdate, "Enddate": todate, "tiletype": tileValue };
    if (TWE_Id != "") {
        common_api_ajax_request("api/RecruiterDetailsList", "RecruiterDetailsList", strdata);
    }
}



function createCandTable(data) {
    $("#tblCandlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {
        if (item.candidateid == "") {

        } else {
            var strImg = "";
            if (item.linkedinURL == "") {
                strImg = "<img src='Images/LinkedIn-no.png' class='avatar avatar-sm me-3'>";
            }
            else if (item.linkedinURL != "") {
                strImg = "<img src='Images/LinkedIn.png' class='avatar avatar-sm me-3'>";
            }
            strTable += "<tr style='cursor:pointer;' class='divControl'><td onclick=gotocandidatepage('" + item.candidateid + "');> <div class='d-flex px-2 py-1'>" +
                "<div><a href='" + item.linkedinURL + "' target='_blank'>" + strImg + "</a></div>" +
                "<div class='d-flex flex-column justify-content-center'>" +
                "<h6 class='mb-0 text-sm'>" + item.candidatename + "</h6>" +
                "<p class='text-xs text-secondary mb-0'><a >" + item.candidateemailid + " | " + item.candidatemobno + " | " + "<img src='Images/in-rupee.png'width='15'height='15'/>" + item.ratePerHr + "/Day" + "</a></p>" +
                "</div ></div ></td > ";

            if (item.candidatestatus == "Submitted to TL" || item.candidatestatus == "Submitted to BP" || item.candidatestatus == "Submitted to EC" || item.candidatestatus == "Closure") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-success'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "TL Rejected" || item.candidatestatus == "BP Rejected" || item.candidatestatus == "EC Rejected") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-danger'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Draft") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "BP Interview" || item.candidatestatus == "EC Interview") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-secondary'>" + item.candidatestatus + "</span></td>";
            }

            else if (item.candidatestatus == "Pipeline") {
                strTable += "<td class='align-middle text-center text-sm' onclick=gotocandidatepage('" + item.candidateid + "');>" +
                    "<p class='text-xs font-weight-bold mb-0' style='display:none;'>" + item.jobcode + "</p>" +
                    "<p class='text-xs font-weight-bold mb-0'>" + item.jobTitle + "</p>" +
                    "<span class='badge badge-sm bg-gradient-info'>" + item.candidatestatus + "</span></td>";
            }


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


function getTargetData(lbl, hdn) {

    for (var i = 1; i <= 5; i++) {
        $('#lblWeek' + i + "1").removeClass("active-label");
    }

    $(lbl).addClass("active-label");


    var TWE_Id = getSession('RecruiterID');

    var st = $(hdn).val().split("$");

    var firstDay = new Date(st[0]);
    var lastDay = new Date(st[1]);

    mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();


    var strdata = { "TWE_Id": TWE_Id, "Weekinfo": $(lbl).text().trim(), "fromdate": st[0], "todate": st[1], "strtype": "Daily" };
    if (TWE_Id != "") {
        common_api_ajax_request("api/TeamMemberTarget", "TARGETDATA", strdata);
    }

}


function getmonthlyTargetData() {


    var TWE_Id = getSession('RecruiterID');

    var firstDay = new Date($("#hdnfirstday").val());
    var lastDay = new Date($("#hdnlastday").val());

    const d1 = new Date(firstDay.getFullYear(), firstDay.getMonth() - 1, 1);

    const d2 = new Date(firstDay.getFullYear(), firstDay.getMonth(), 0);

    $('#hdnprevweek').val(pad2(d1.getDate()) + " " + arr[d1.getMonth()] + " " + d1.getFullYear() + " To " + pad2(d2.getDate()) + " " + arr[d2.getMonth()] + " " + d2.getFullYear());

    var TWE_Id = getSession('RecruiterID');
    var strdata = {
        "TWE_Id": TWE_Id, "Weekinfo": $("#lblmonthname").text().trim(), "fromdate": $("#hdnfirstday").val(), "todate": $("#hdnlastday").val(), "strtype": "Monthly",
        "prevfromdate": d1.getFullYear() + "-" + (d1.getMonth() + parseInt(1)) + "-" + d1.getDate(),
        "prevtodate": d2.getFullYear() + "-" + (d2.getMonth() + parseInt(1)) + "-" + d2.getDate(), "tablename": "Monthly"
    };
    if (TWE_Id != "") {
        common_api_ajax_request("api/TeamMemberTarget", "TARGETDATA", strdata);
    }

}

function getWeeklyData(lbl, hdn) {
    $(lbl).addClass("active-label");
    var TWE_Id = getSession('RecruiterID');

    var st = $(hdn).val().split("$");

    var firstDay = new Date(st[0]);
    var lastDay = new Date(st[1]);

    mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();

    document.getElementById("hdnstartdate").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
    document.getElementById("hdnenddate").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "strType": "Daily" };
    if (TWE_Id != "") {
        common_api_ajax_request("api/Managerdashboard", "MGRDASHBOARD", strdata);
    }

}

function getFeedbackInfo() {


    var TWE_Id = getSession('RecruiterID');
    var stdate = $('#hdnfirstday').val();
    var etdate = $('#hdnlastday').val();

    var wkInfo = new Array;
    var wkObj1 = {};
    wkObj1.Weekdata = $('#lblWeek11').text();
    wkInfo.push(wkObj1.Weekdata);

    var wkObj2 = {};
    wkObj2.Weekdata = $('#lblWeek21').text();
    wkInfo.push(wkObj2.Weekdata);

    var wkObj3 = {};
    wkObj3.Weekdata = $('#lblWeek31').text();
    wkInfo.push(wkObj3.Weekdata);

    var wkObj4 = {};
    wkObj4.Weekdata = $('#lblWeek41').text();
    wkInfo.push(wkObj4.Weekdata);

    var wkObj5 = {};
    wkObj5.Weekdata = $('#lblWeek51').text();
    wkInfo.push(wkObj5.Weekdata);

    var wkObj6 = {};
    wkObj6.Weekdata = $('#lblWeek61').text();
    wkInfo.push(wkObj6.Weekdata);


    var strdata = {
        "TWE_Id": TWE_Id, "Weekinfo": wkInfo, "stdate": stdate, "etdate": etdate, "type": "Monthly"
    };
    if (TWE_Id != "") {
        common_api_ajax_request("api/TeamMemberFeedback", "FEEDBACKINFO", strdata);
    }

}

function closepopup() {

    $("#msgpopup").modal('hide');
}

function getMgrDashboardPage(stdate, etdate, strType) {

    var TWE_Id = getSession('RecruiterID');

    var strdata = { "TWE_Id": TWE_Id, "Startdate": stdate, "Enddate": etdate, "strType": strType };
    if (TWE_Id != "") {
        common_api_ajax_request("api/Managerdashboard", "MGRDASHBOARD", strdata);
    }

}

var mgrfeedback;
var chartduration;
var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

function data_Week(txtname) {


    var date = new Date($('#' + txtname).val().substring(6, 10), (parseInt($('#' + txtname).val().substring(3, 5)) - 1), $('#' + txtname).val().substring(0, 2));


    var firstDay =
        new Date(date.getFullYear(), date.getMonth(), 1);

    var lastDay =
        new Date(date.getFullYear(), date.getMonth() + 1, 0);


    var DateBind = firstDay.getDate() + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " to " + lastDay.getDate() + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();
    var stdate = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
    var etdate = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
    document.getElementById(txtname).value = DateBind;

    if (txtname == "txtFeedbackdate") {
        mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();

        document.getElementById("hdnstartdate").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
        document.getElementById("hdnenddate").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
        getMgrDashboardPage(stdate, etdate, "Weekly");

    }
    else if (txtname == "txtFeedbackdatefb") {
        document.getElementById("hdnfirstday").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
        document.getElementById("hdnlastday").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
        //document.getElementById("hdnchartdate").value = DateBind;

        $('#lblmonthname').text(pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear());

        $('#div_feedbackweek').addClass("divshow");
        $('#div_monthpicker').removeClass("divshow");
        $('#div_feedbackweek').removeClass("divhide");
        $('#div_monthpicker').addClass("divhide");
        //$('#icon_refresh').css('display', 'initial');
        $('#lblmonthname').removeClass("divhide");
        $('#lblmonthname').addClass("divshow");

        if (feedbacktype == "Weekly") {
            $('#divfeedbackcontent').addClass("divshow");
            $('#divfeedbackcontent').removeClass("divhide");
            if (getSession('Rolename') == "Recruiter") {
                $('#btnSave').removeClass("divshow");
                $('#btnSave').addClass("divhide");
                $("#drpOverallRemarks").prop('disabled', 'disabled');
                $("#txtComments").prop('disabled', 'disabled');
            }
            else {

                $('#btnSave').addClass("divshow");
                $('#btnSave').removeClass("divhide");
                $("#drpOverallRemarks").prop('disabled', false);
                $("#txtComments").prop('disabled', false);
            }
        }




    }

}

function getDivInfo(filterVal) {

    if (filterVal == "Bymonth") {
        $("#anchBymonth").addClass("change_color");
        $("#anchByweek").removeClass("change_color");
        $("#anchGivefeedback").removeClass("change_color");
        $('#div_week').css('display', 'none');
        $('#div_month').css('display', 'block');
        $('#div_performanceinfo').css('display', 'none');
        $("#div_week_feedback").css('display', 'none');
        $("#div_titlewk").css('display', 'none');
        $("#div_week_infofeed").css('display', 'none');
        $("#div_feedback").css('display', 'none');
        $("#txtFeedbackdatewk").val("");
        $("#txtFeedbackdatefb").val("");
    }
    else if (filterVal == "Byweek") {
        $("#anchBymonth").removeClass("change_color");
        $("#anchByweek").addClass("change_color");
        $("#anchGivefeedback").removeClass("change_color");
        $('#div_month').css('display', 'none');
        $('#div_week').css('display', 'block');
        $('#div_week_feedback').css('display', 'none');
        $('#div_week_month').css('display', 'block');
        $('#div_performanceinfo').css('display', 'none');
        $("#div_title").css('display', 'none');
        $("#div_week_infofeed").css('display', 'none');
        $("#div_feedback").css('display', 'none');
        $("#div_week_info").css('display', 'none');
        $("#txtFeedbackdate").val("");
        $("#txtFeedbackdatefb").val("");
    }
    else if (filterVal == "Givefeedback") {
        $("#anchBymonth").removeClass("change_color");
        $("#anchByweek").removeClass("change_color");
        $("#anchGivefeedback").addClass("change_color");
        $('#div_month').css('display', 'none');
        $('#div_week').css('display', 'none');
        $('#div_week_feedback').css('display', 'block');
        $('#div_feedback').css('display', 'none');
        $('#div_performanceinfo').css('display', 'none');
        $('#div_performancetitle').css('display', 'none');
        $("#div_title").css('display', 'none');
        $("#div_titlewk").css('display', 'none');
        $("#txtFeedbackdate").val("");
        $("#txtFeedbackdatewk").val("");

    }
}

function openCalendarData() {

    if ($('#txtFeedbackdatefb').val() != "") {



        getWeekNumber("feedback");
    }

    //if ($('#txtFeedbackdatefb').val() != "" && feedbacktype == "Weekly") {
    //    getWeekNumber("feedback");
    //}

    //else if ($('#txtFeedbackdatefb').val() != "" && feedbacktype == "Monthly") {
    //    //data_Week("txtFeedbackdatefb");
    //    data_Week("txtFeedbackdatefb");
    //    //getmonthlyTargetData($('#hdnfirstday').val() + "$" + $('#hdnlastday').val());

    //    //$('#div_mgrfeedbackperfchart').css('display', 'block');
    //}

}

function openEmployer() {
    if ($('input[name="chkSearch"]:checked').val() == "on") {
        document.getElementById("txtSearch").style.display = "none";
        document.getElementById("txtAdvSearch").style.display = "block";

        document.getElementById("lblSearch").style.display = "none";
        document.getElementById("lblAdvSearch").style.display = "block";
        enableemplcontrols();
    }
    else {
        document.getElementById("txtSearch").style.display = "block";
        document.getElementById("txtAdvSearch").style.display = "none";

        document.getElementById("lblSearch").style.display = "block";
        document.getElementById("lblAdvSearch").style.display = "none";
    }
}

function opendisabled(txt) {

    //$("#drpOverallRemarks").prop('disabled', 'disabled');
    //$("#txtComments").prop('disabled', 'disabled');

    var isDisabled2 = $(txt).prop('disabled');
    if (isDisabled2 == true) {
        $(txt).prop('disabled', false);
        $("#btnSave").prop('disabled', false);
    }
    else {
        $(txt).prop('disabled', true);
        $("#btnSave").prop('disabled', true);
    }

    //$(txt).prop('disabled', false);


}


function gotocandidatepage(candidateid) {
    window.location.href = "Candidate_Viewindia.aspx?id=" + candidateid;
}

function gotojobpage(jobid) {
    window.location.href = "FollowupPageIndia.aspx?id=" + jobid;
}

function getRatingRemarks(txtval, lblval) {
    var percentage = parseInt($(txtval).text());

    if (percentage >= 0 && percentage <= 25) {
        $(lblval).text("Bad");
        //$(lblval).addClass("color-red");
    }

    else if (percentage > 25 && percentage <= 50) {
        $(lblval).text("Need Improvement");
        //$(lblval).addClass("color-yellow");
    }

    else if (percentage > 50 && percentage <= 75) {
        $(lblval).text("Good");
        //$(lblval).addClass("color-blue");
    }

    else if (percentage > 75 && percentage <= 100) {
        $(lblval).text("Excellent");
        //$(lblval).addClass("color-magenta");
    }

}

function showweeklyfeedback() {


    $("#getweeklyfeedback").modal('show');
}

function closepopup() {

    $("#msgpopup").modal('hide');

}


function closeTableview() {

    $('#div_ratingtable').addClass("divhide");
    $('#div_tiles').removeClass("divhide");
}
