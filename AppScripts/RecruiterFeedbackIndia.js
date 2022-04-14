$(document).ready(function () {

    setSession("Page", "RecruiterPerformanceIndia");
    $('#lblEmployeename').text(getSession('Name'));
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    $('#lblPagetitle').text("My Feedback");

});

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    
    if (key == "TARGETDATA") {
        for (var j = 1; j <= 6; j++) {
            document.getElementById("drpRemarks" + j).options.length = 0;
        }

        document.getElementById("drpOverallRemarks").options.length = 0;

        for (var j = 1; j <= 6; j++) {

            var option1 = new Option("--Select Remarks--", "-1");
            $(option1).html("--Select Remarks--");
            $("#drpRemarks" + j).append(option1);

            for (var i = 0; i < resData.lstRemarks.length; i++) {

                var option = new Option(resData.lstRemarks[i].Name, resData.lstRemarks[i].ID);

                $(option).html(resData.lstRemarks[i].Name);
                $("#drpRemarks" + j).append(option);
            }
        }

        var option1 = new Option("--Select Remarks--", "-1");
        $(option1).html("--Select Remarks--");
        $("#drpOverallRemarks").append(option1);

        for (var i = 0; i < resData.lstRemarks.length; i++) {

            var option = new Option(resData.lstRemarks[i].Name, resData.lstRemarks[i].ID);

            $(option).html(resData.lstRemarks[i].Name);
            $("#drpOverallRemarks").append(option);
        }

        $('#lblTMduration').text(" " + mgrfeedback);

        if (resData.Feedback.candidatetarget != null) {
            $('#txtCandidateadding').val(pad2(resData.Feedback.candidatetarget));
            $('#txtVendorcreation').val(pad2(resData.Feedback.vendorTarget));
            $('#txtSubmission').val(pad2(resData.Feedback.submittiontarget));
            $('#txtTLApproval').val(pad2(resData.Feedback.TLApprovalTarget));
            $('#txtBPApproval').val(pad2(resData.Feedback.BPApprovalTarget));
            $('#txtECApproval').val(pad2(resData.Feedback.ECApprovalTarget));

            $('#txtCandidateaddachieved').val(pad2(resData.Feedback.candidateAchieved));
            $('#txtVendorachieved').val(pad2(resData.Feedback.vendorAchieved));
            $('#txtSubmissionachieved').val(pad2(resData.Feedback.submittionAchieved));
            $('#txtTLApprovalachieved').val(pad2(resData.Feedback.TLApprovalAchieved));
            $('#txtBPApprovalachieved').val(pad2(resData.Feedback.BPApprovalAchieved));
            $('#txtECApprovalachieved').val(pad2(resData.Feedback.ECApprovalAchieved));
            $('#txtComments').val(pad2(resData.Feedback.Remarks));
            $("#drpRemarks1").val(resData.Feedback.candidateRemarks).prop("selected", true);
            $("#drpRemarks2").val(resData.Feedback.vendorRemarks).prop("selected", true);
            $("#drpRemarks3").val(resData.Feedback.submittionRemarks).prop("selected", true);
            $("#drpRemarks4").val(resData.Feedback.TLApprovalRemarks).prop("selected", true);
            $("#drpRemarks5").val(resData.Feedback.BPApprovalRemarks).prop("selected", true);
            $("#drpRemarks6").val(resData.Feedback.ECApprovalRemarks).prop("selected", true);
            $("#drpOverallRemarks").val(resData.Feedback.OverallRating).prop("selected", true);

            $("#drpRemarks1").prop('disabled', 'disabled');
            $("#drpRemarks2").prop('disabled', 'disabled');
            $("#drpRemarks3").prop('disabled', 'disabled');
            $("#drpRemarks4").prop('disabled', 'disabled');
            $("#drpRemarks5").prop('disabled', 'disabled');
            $("#drpRemarks6").prop('disabled', 'disabled');
            $("#drpOverallRemarks").prop('disabled', 'disabled');
            $("#txtComments").prop('disabled', 'disabled');
            $("#btnSave").prop('disabled', 'disabled');


            //$('#lblBPTitle').text(resData.PerformaceOverView[0].PerformanceName);
            $('#lblBPSelectedfb').text(pad2(resData.Feedback.BPApprovalAchieved) + "/" + pad2(resData.Feedback.BPApprovalTarget) + " Profiles");
            //$('#lblCanTitle').text(resData.PerformaceOverView[1].PerformanceName);
            $('#lblCandidatesfb').text(pad2(resData.Feedback.candidateAchieved) + "/" + pad2(resData.Feedback.candidatetarget) + " Connected");
            //$('#lblECTitle').text(resData.PerformaceOverView[2].PerformanceName);
            $('#lblECClosuresfb').text(pad2(resData.Feedback.ECApprovalAchieved) + "/" + pad2(resData.Feedback.ECApprovalTarget) + " Candidates");
            //$('#lblSBTitle').text(resData.PerformaceOverView[3].PerformanceName);
            $('#lblSubmittedfb').text(pad2(resData.Feedback.submittionAchieved) + "/" + pad2(resData.Feedback.submittiontarget) + " Candidates");
            //$('#lblTLTitle').text(resData.PerformaceOverView[4].PerformanceName);
            $('#lblTLApprovedfb').text(pad2(resData.Feedback.TLApprovalAchieved) + "/" + pad2(resData.Feedback.TLApprovalTarget) + " Profiles");
            //$('#lblVenTitle').text(resData.PerformaceOverView[5].PerformanceName);
            $('#lblVendorsfb').text(pad2(resData.Feedback.vendorAchieved) + "/" + pad2(resData.Feedback.vendorTarget) + " Connected");

            $('#lblPerformanceValfb').text(resData.OverViewPercentage + " " + mgrfeedback);


            $('#div_candadd').css('display', 'block');
            $('#div_vendadd').css('display', 'block');
            $('#div_subcand').css('display', 'block');
            $('#div_TLcand').css('display', 'block');
            $('#div_BPcand').css('display', 'block');
            $('#div_ECcand').css('display', 'block');
            $('#div_Overall').css('display', 'block');
            $('#div_Remarks').css('display', 'block');
            $('#div_feedback').css('display', 'block');

            $('#lblTeammemberfb').text(resData.Feedback.TWEID + "'s ");
            $('#lblTeammember2').text(resData.Feedback.TWEID + "'s ");


            if (parseInt(resData.OverViewPercentage) >= 80) {
                $('#icon_overviewfb').addClass("fa fa-arrow-up text-success");
            }
            else if (parseInt(resData.OverViewPercentage) >= 50 && parseInt(resData.OverViewPercentage) <= 79) {
                $('#icon_overviewfb').addClass("fa fa-arrows-alt-h text-warning");
            }
            else if (parseInt(resData.OverViewPercentage) <= 49) {
                $('#icon_overviewfb').addClass("fa fa-arrow-down text-danger");
            }
        }

        else if (resData.lstTarget.length != 0) {

            $('#txtCandidateadding').val(pad2(resData.lstTarget[0].CandidateValue));
            $('#txtVendorcreation').val(pad2(resData.lstTarget[0].Vendorsvalue));
            $('#txtSubmission').val(pad2(resData.lstTarget[0].SubmittiontoValue));
            $('#txtTLApproval').val(pad2(resData.lstTarget[0].TlApprovalValue));
            $('#txtBPApproval').val(pad2(resData.lstTarget[0].BPApprovalValue));
            $('#txtECApproval').val(pad2(resData.lstTarget[0].ECApprovalValue));

            $('#txtCandidateaddachieved').val(pad2(resData.lstTarget[1].CandidateValue));
            $('#txtVendorachieved').val(pad2(resData.lstTarget[1].Vendorsvalue));
            $('#txtSubmissionachieved').val(pad2(resData.lstTarget[1].SubmittiontoValue));
            $('#txtTLApprovalachieved').val(pad2(resData.lstTarget[1].TlApprovalValue));
            $('#txtBPApprovalachieved').val(pad2(resData.lstTarget[1].BPApprovalValue));
            $('#txtECApprovalachieved').val(pad2(resData.lstTarget[1].ECApprovalValue));

            $('#div_candadd').css('display', 'none');
            $('#div_vendadd').css('display', 'none');
            $('#div_subcand').css('display', 'none');
            $('#div_TLcand').css('display', 'none');
            $('#div_BPcand').css('display', 'none');
            $('#div_ECcand').css('display', 'none');
            $('#div_Overall').css('display', 'none');
            $('#div_Remarks').css('display', 'none');

            $('#lblTeammember1').text(resData.lstTarget[0].TargetfixingId);
            $('#lblTeammember2').text(resData.lstTarget[0].TargetfixingId);
            $('#lblTeammemberfb').text(resData.lstTarget[0].TargetfixingId);
            $('#lblTMduration').text(mgrfeedback);


            $("#drpRemarks1").val("-1").prop("selected", true);
            $("#drpRemarks2").val("-1").prop("selected", true);
            $("#drpRemarks3").val("-1").prop("selected", true);
            $("#drpRemarks4").val("-1").prop("selected", true);
            $("#drpRemarks5").val("-1").prop("selected", true);
            $("#drpRemarks6").val("-1").prop("selected", true);
            $("#drpOverallRemarks").val("-1").prop("selected", true);
            $('#txtComments').val("");
            $('#lblTeammember2').text(resData.lstTarget[0].TargetfixingId);
            $('#lblPerformanceValfb').text(resData.OverViewPercentage + " " + mgrfeedback);
            $('#lblTMduration').text(mgrfeedback);
            $('#lblBPSelectedfb').text(pad2(resData.lstTarget[1].BPApprovalValue) + "/" + pad2(resData.lstTarget[0].BPApprovalValue) + " Profiles");
            //$('#lblCanTitle').text(resData.PerformaceOverView[1].PerformanceName);
            $('#lblCandidatesfb').text(pad2(resData.lstTarget[1].CandidateValue) + "/" + pad2(resData.lstTarget[0].CandidateValue) + " Connected");
            //$('#lblECTitle').text(resData.PerformaceOverView[2].PerformanceName);
            $('#lblECClosuresfb').text(pad2(resData.lstTarget[1].ECApprovalValue) + "/" + pad2(resData.lstTarget[0].ECApprovalValue) + " Candidates");
            //$('#lblSBTitle').text(resData.PerformaceOverView[3].PerformanceName);
            $('#lblSubmittedfb').text(pad2(resData.lstTarget[1].SubmittiontoValue) + "/" + pad2(resData.lstTarget[0].SubmittiontoValue) + " Candidates");
            //$('#lblTLTitle').text(resData.PerformaceOverView[4].PerformanceName);
            $('#lblTLApprovedfb').text(pad2(resData.lstTarget[1].TlApprovalValue) + "/" + pad2(resData.lstTarget[0].TlApprovalValue) + " Profiles");
            //$('#lblVenTitle').text(resData.PerformaceOverView[5].PerformanceName);
            $('#lblVendorsfb').text(pad2(resData.lstTarget[1].Vendorsvalue) + "/" + pad2(resData.lstTarget[0].Vendorsvalue) + " Connected");


            $("#btnSave").prop('disabled', false);
            if (parseInt(resData.OverViewPercentage) >= 80) {
                $('#icon_overviewfb').addClass("fa fa-arrow-up text-success");
            }
            else if (parseInt(resData.OverViewPercentage) >= 50 && parseInt(resData.OverViewPercentage) <= 79) {
                $('#icon_overviewfb').addClass("fa fa-arrows-alt-h text-warning");
            }
            else if (parseInt(resData.OverViewPercentage) <= 49) {
                $('#icon_overviewfb').addClass("fa fa-arrow-down text-danger");
            }

            $("#drpRemarks1").prop('disabled', 'disabled');
            $("#drpRemarks2").prop('disabled', 'disabled');
            $("#drpRemarks3").prop('disabled', 'disabled');
            $("#drpRemarks4").prop('disabled', 'disabled');
            $("#drpRemarks5").prop('disabled', 'disabled');
            $("#drpRemarks6").prop('disabled', 'disabled');
            $("#drpOverallRemarks").prop('disabled', 'disabled');
            $("#txtComments").prop('disabled', 'disabled');

            $('#div_feedback').css('display', 'block');
            $('#div_mgrfeedbackperf').css('display', 'block');
            $('#div_mgrfeedback').css('display', 'block');
        }

        else {
            $('#txtComments').val("");
        }
        $('#div_mgrfeedback').css('display', 'block');
        $('#div_mgrfeedbackperf').css('display', 'block');
        stopLoader();
    }

    
    else if (key == "FEEDBACKINFO") {
        var j = 0;
        for (var i = 1; i < resData.length; i++) {
            if (resData[j].status == "1") {
                $('#btnfbWeek' + i).addClass("week-color-green");
            }
            else if (resData[j].status == "0") {
                $('#btnfbWeek' + i).addClass("week-color-blue");
            }
            j++;
        }

        $('#divDoughchart').empty();
        $('#divDoughchart').append(resData[resData.length - 1].Weekinfo);
        $('#div_mgrfeedbackperfchart').css('display', 'block');
        $('#lblduration').text(" for the duration of " + document.getElementById("hdnchartdate").value);
        $('#lblPerformaceVal').text(resData[resData.length - 1].status);

        $('#chart-consumption').height(200);
        $('#chart-consumption').width(240);
        stopLoader();

    }

}


function createJobTable(data) {
    $("#tblJoblist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.Jobcode == "") {

        } else {
            strTable += "<tr class='divControl'><td onclick=gotojobpage('" + item.Jobcode + "');><div class='d-flex px-2 py-1'>" +
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
        common_api_ajax_request("api/RecruiterJobListIndia", "RECRUITERLIST", strdata);
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


    for (var x = 0; x < wkdateListArr.length; x++) {
        //var dt1, dt2;
        if (wkdateListArr[x].weekNumber == 0) {
            // dt1 = wkdateListArr[x].dateInfo;
            //dt2 = wkdateListArr[x].dateInfo;
            wk1.push(wkdateListArr[x].dateInfo);

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
        }

        //alert(wkdateListArr[x].dateInfo + ":" + wkdateListArr[x].weekInfo + ":" + wkdateListArr[x].weekNumber);
    }



    var dt11 = new Date(wk1[0]);
    var dt21 = new Date(wk1[wk1.length - 1]);
    var dd11 = dt11.getDate();
    var dd21 = dt21.getDate();
    var y1 = dt11.getFullYear();

    if (type == "week") {
        $('#lblWeek1').text(pad2(dd11) + "-" + pad2(dd21) + " " + arr[dt11.getMonth()] + " " + y1);

        $('#hdnWeek1').val(dt11.getFullYear() + "-" + (dt11.getMonth() + 1) + "-" + dt11.getDate() + "$" + dt21.getFullYear() + "-" + (dt21.getMonth() + 1) + "-" + dt21.getDate());
    }
    else if (type == "feedback") {
        $('#lblWeek11').text(pad2(dd11) + "-" + pad2(dd21) + " " + arr[dt11.getMonth()] + " " + y1);

        $('#hdnWeek11').val(dt11.getFullYear() + "-" + (dt11.getMonth() + 1) + "-" + dt11.getDate() + "$" + dt21.getFullYear() + "-" + (dt21.getMonth() + 1) + "-" + dt21.getDate());
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
        $('#lblWeek21').text(pad2(dd12) + "-" + pad2(dd22) + " " + arr[dt12.getMonth()] + " " + y2);
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
        $('#lblWeek31').text(pad2(dd13) + "-" + pad2(dd23) + " " + arr[dt13.getMonth()] + " " + y3);
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
        $('#lblWeek41').text(pad2(dd14) + "-" + pad2(dd24) + " " + arr[dt14.getMonth()] + " " + y4);
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
        $('#lblWeek51').text(pad2(dd15) + "-" + pad2(dd25) + " " + arr[dt15.getMonth()] + " " + y5);
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
            $('#lblWeek61').text(pad2(dd16) + "-" + pad2(dd26) + " " + arr[dt16.getMonth()] + " " + y6);
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








function getTargetData(lbl, hdn) {

    for (var i = 1; i <= 5; i++) {
        $('#lblWeek' + i + "1").removeClass("active-label");
    }

    $(lbl).addClass("active-label");


    var TWE_Id = getSession('TWE_ID');

    var st = $(hdn).val().split("$");
    var firstDay = new Date(st[0]);
    var lastDay = new Date(st[1]);

    mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();
   

    var strdata = { "TWE_Id": TWE_Id, "Weekinfo": $(lbl).text(), "fromdate": st[0], "todate": st[1] };
    if (TWE_Id != "") {
        common_api_ajax_request("api/TeamMemberTargetIndia", "TARGETDATA", strdata);
    }

}
function getWeeklyData(lbl, hdn) {
    $(lbl).addClass("active-label");
    var TWE_Id = getSession('TWE_ID');

    var st = $(hdn).val().split("$");

    var firstDay = new Date(st[0]);
    var lastDay = new Date(st[1]);

    mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();


    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "strType": "Daily" };
    if (TWE_Id != "") {
        common_api_ajax_request("api/ManagerdashboardIndia", "MGRDASHBOARD", strdata);
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


    var strdata = {
        "TWE_Id": TWE_Id, "Weekinfo": wkInfo, "stdate": stdate, "etdate": etdate
    };
    if (TWE_Id != "") {
        common_api_ajax_request("api/TeamMemberFeedbackIndia", "FEEDBACKINFO", strdata);
    }

}



var mgrfeedback;
var chartduration;

function data_Week(txtname) {
    var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

    var date = new Date($('#' + txtname).val().substring(6, 10), (parseInt($('#' + txtname).val().substring(3, 5)) - 1), $('#' + txtname).val().substring(0, 2));


    var firstDay =
        new Date(date.getFullYear(), date.getMonth(), 1);

    var lastDay =
        new Date(date.getFullYear(), date.getMonth() + 1, 0);


    var DateBind = firstDay.getDate() + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " to " + lastDay.getDate() + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();
    var stdate = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
    var etdate = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
    document.getElementById(txtname).value = DateBind;

    if (txtname == "txtFeedbackdatefb") {
        document.getElementById("hdnfirstday").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
        document.getElementById("hdnlastday").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
        document.getElementById("hdnchartdate").value = DateBind;
    }

}

function getDivInfo(filterVal) {

     if (filterVal == "Givefeedback") {
        $("#anchGivefeedback").addClass("change_color");
        $('#div_month').css('display', 'none');
        $('#div_week').css('display', 'none');
        $('#div_week_feedback').css('display', 'block');
        $('#div_feedback').css('display', 'block');
        $('#div_performanceinfo').css('display', 'none');
        $('#div_performancetitle').css('display', 'none');
        $("#div_title").css('display', 'none');
        $("#div_titlewk").css('display', 'none');

    }
}

function openCalendarData(filterVal) {
    if (filterVal == "Givefeedback") {
        //$('#div_mgrfeedback').css('display', 'block');
        if ($('#txtFeedbackdatefb').val() != "") {
            getWeekNumber("feedback");
            $('#div_week_infofeed').css('display', 'flex');

        }

    }

}



