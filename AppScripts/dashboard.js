$(document).ready(function () {

    setSession("Page", "Dashboard");
    $('#lblEmployeename').text(getSession('Name'));   
    
    //setInterval("getDashboardTimer();", 1000);
    rendertime();
    stopLoader();   
    
    if (getSession('Designation') == "4001") {
        document.getElementById("anchCheck").href = "JobList.aspx?tiletype=Follow";
    }
    else if (getSession('Designation') == "4000" || getSession('Rolename') == "Manager" || getSession('Rolename') == "Senior Manager") {
        //document.getElementById("anchCheck1").href = "ManagerJobList.aspx?tiletype=Feedback";
        document.getElementById("anchCheck2").href = "ManagerJobList.aspx?tiletype=Feedback";
    }
       
}); 

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "DASHBOARD") {
        $('p#p_Total').text(resData.Tiles[0].TileTitle);
        $('#lblTotaljob').text(pad2(resData.Tiles[0].TotalCount));
        $('#lblActivejob').text(resData.Tiles[0].Name + " " + pad2(resData.Tiles[0].AchiveCount));
        $('p#p_Cand').text(resData.Tiles[1].TileTitle);
        $('#lblResumeinpros').text(pad2(resData.Tiles[1].TotalCount));
        $('#lblResumeEC').text(resData.Tiles[1].Name + " " + pad2(resData.Tiles[1].AchiveCount));
        $('p#p_Vend').text(resData.Tiles[2].TileTitle);
        $('#lblActiveVendors').text(pad2(resData.Tiles[2].TotalCount));
        $('#lblNewVendors').text(resData.Tiles[2].Name + " " + pad2(resData.Tiles[2].AchiveCount));
        $('p#p_Clos').text(resData.Tiles[3].TileTitle);
        $('#lblMadeclosure').text(pad2(resData.Tiles[3].TotalCount));
        $('#lblOnLive').text(resData.Tiles[3].Name + " " + pad2(resData.Tiles[3].AchiveCount));

        if (resData.Roleid == "4001") {

            $('p#p_Reshold1').text(resData.HoldResumeTiles[0].FirstHeading);
            $('#h_feed').text(resData.HoldResumeTiles[0].SecondHeading);
            $('p#p_Reshold2').text(resData.HoldResumeTiles[0].ThirdHeading);
            $('#lblResumesonhold').text(pad2(resData.HoldResumeTiles[0].Count));

            $('#div_recruiter').css('display', 'block');
            $('#div_manager').css('display', 'none');
        }

        else if (resData.Roleid == "4000" || resData.Roleid == "4002" || resData.Roleid == "4004") { 
            
            $('#lblResumesonhold1').text(pad2(resData.HoldResumeTiles[0].Count));            
            $('#lblResumesonhold2').text(pad2(resData.HoldResumeTiles[1].Count));

            $('#div_recruiter').css('display', 'none');
            $('#div_manager').css('display', 'block');
        }
        
        

        $('#lblBarTitle').text(resData.BarTitle);
        $('#lblBarDuration').text(resData.BarDuration + " " + $('#lblDurationview').text());

        $('#divBarchart').empty();
        $('#divBarchart').append(resData.Barchart);

        $('#lblSubTitle1').text(resData.LinechartTitle);
        $('#lblSubTitle2').text(resData.LineDuration + " " + $('#lblDurationview').text());

        $('#lblRecTitle').text(resData.RecentRecuitmentTitle);
        $('#lblCandCount').text(resData.RecentRecuitmentCount +" " +$('#lblDurationview').text());


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

        $('#chart-line').height(303);
        var strTable = "";
        for (var i = 0; i < resData.RecuitmentTable.length; i++) {

            var str1 = "";
            //if (resData.Joblist[i].Role.startsWith("JAVA")) {
            //    str1 = "<div class='d-flex px-2 py-1'>" +
            //        "<div><img src='Images/Java.svg' class='avatar avatar-sm me-3'></div>" +
            //        "<div class='d-flex flex-column justify-content-center'>" +
            //        "<h6 class='mb-0 text-sm'><span>" + resData.RecuitmentTable[i].JobName + "</span></h6>"
            //    "</div> </div >";
            //}
            //else if (resData.Joblist[i].Role.startsWith("Sales Force")) {
            //    str1 = "<div class='d-flex px-2 py-1'>" +
            //        "<div><img src='Images/Salesforce.png' class='avatar avatar-sm me-3'></div>" +
            //        "<div class='d-flex flex-column justify-content-center'>" +
            //        "<h6 class='mb-0 text-sm'><span>" + resData.Joblist[i].Role + "</span></h6>"
            //    "</div> </div >";
            //}
            //else if (resData.Joblist[i].Role.startsWith("SAP")) {
            str1 = "<div class='d-flex px-2 py-1'>" +
                "<div><img src='" + resData.RecuitmentTable[i].JobMediaPath + "' class='avatar avatar-sm me-3'>"+
                "<label class='mb-0 text-sm h6' id='lblJobid' style='display:none;'>" + resData.RecuitmentTable[i].RecruitmentId + "</label>" +
                "</div>" +
                "<div class='d-flex flex-column justify-content-center'>" +

                "<label class='mb-0 text-sm h6' id='lblJobname'>" + resData.RecuitmentTable[i].JobName+"</label>" +
                "<label class='m-0'>" +
                "<label class='text-secondary' id='lblJobmonth'>" + resData.RecuitmentTable[i].JobDuration + "</label>|<label class='text-secondary' id='lblJobcontract'>" + resData.RecuitmentTable[i].JobType + "</label>|<label class='text-secondary' id='lblJobcity'>" + resData.RecuitmentTable[i].JobCity + "," + resData.RecuitmentTable[i].JobState +"</label></label>" +
                "</div></div>";


            //str1 = "<div class='d-flex px-2 py-1'>" +
            //    "<div><img src='" + resData.RecuitmentTable[i].JobMediaPath + "' class='avatar avatar-sm me-3'></div>" +
            //    "<div class='d-flex flex-column justify-content-center'>" +
            //    "<h6 class='mb-0 text-sm'><span>" + resData.RecuitmentTable[i].JobName + "</span></h6>"
            //"</div> </div >";
            //}


            strTable += "<tr onclick=gotoFollowPage('" + resData.RecuitmentTable[i].RecruitmentId +"')><td>" + str1 + "</td>";
            strTable += "<td class='align-middle text-center text-sm'><span class='text-xs font-weight-bold'>" + resData.RecuitmentTable[i].JobClient + " </span></td>";
            strTable += "<td><div class='progress-wrapper w-75 mx-auto'>" +
                "<div class='progress-info'>" +
                "<div class='progress-percentage'>" +
                "<span class='text-xs font-weight-bold'>" + resData.RecuitmentTable[i].JobSubmission + "</span>" +
                "</div> </div>" +
                "<div class='progress'>" +
                "<div class='progress-bar bg-gradient-info w-60' role='progressbar' aria-valuenow='60' aria-valuemin='0' aria-valuemax='100'></div>" +
                "</div></div></td></tr>";

        }
        $("#tblJoblist tbody").empty();
        $("#tblJoblist tbody").append(strTable);

        $('#lblPerformanceVal').text(resData.OverViewPercentage + " " + $('#lblDurationview').text());

        if (parseInt(resData.OverViewPercentage) >= 80) {
            $('#icon_overview').addClass("fa fa-arrow-up text-success");
        }
        else if (parseInt(resData.OverViewPercentage) >= 50 && parseInt(resData.OverViewPercentage) <= 79) {
            $('#icon_overview').addClass("fa fa-arrows-alt-h text-warning");
        }
        else if (parseInt(resData.OverViewPercentage) <= 49) {
            $('#icon_overview').addClass("fa fa-arrow-down text-danger");
        }

        $('#lblBPTitle').text(resData.PerformaceOverView[0].PerformanceName);
        $('#lblBPSelected').text(pad2(resData.PerformaceOverView[0].PerformanceCount) + " Profiles");
        $('#lblCanTitle').text(resData.PerformaceOverView[1].PerformanceName);
        $('#lblCandidates').text(pad2(resData.PerformaceOverView[1].PerformanceCount) + " Connected");
        $('#lblECTitle').text(resData.PerformaceOverView[2].PerformanceName);
        $('#lblECClosures').text(pad2(resData.PerformaceOverView[2].PerformanceCount) + " Candidates");
        $('#lblSBTitle').text(resData.PerformaceOverView[3].PerformanceName);
        $('#lblSubmitted').text(pad2(resData.PerformaceOverView[3].PerformanceCount) + " Candidates");
        $('#lblTLTitle').text(resData.PerformaceOverView[4].PerformanceName);
        $('#lblTLApproved').text(pad2(resData.PerformaceOverView[4].PerformanceCount) + " Profiles");        
        $('#lblVenTitle').text(resData.PerformaceOverView[5].PerformanceName);
        $('#lblVendors').text(pad2(resData.PerformaceOverView[5].PerformanceCount) + " Connected");

        stopLoader();
    }

    else if (key == "TIMER") {

        $('#lblEst').text(resData.Timezonelist[0].TimeZoneTime);
        $('#lblCst').text(resData.Timezonelist[1].TimeZoneTime);
        $('#lblMst').text(resData.Timezonelist[3].TimeZoneTime);
        $('#lblPst').text(resData.Timezonelist[2].TimeZoneTime);
        $('#lblTodayDate').text(resData.Timezonelist[0].TimeZoneDate);
    }

}
//function getDashboardPage(TWE_Id,duration) {

//    var st = duration.split("$");
    
//    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1]};
//    if (TWE_Id != "" ) {
//        common_api_ajax_request("api/Recrutingdashboard", "DASHBOARD", strdata);
//        //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);
//    } else {
//        alert("fill");
//    }
//}

function rendertime() {
    var curdate = new Date();

    var strtext = curdate.toString();
    var findzone = (strtext.search("India"));

    if (findzone > 0) {
        estdate = new Date();
        estdate.setHours(estdate.getHours() - 10);
        estdate.setMinutes(estdate.getMinutes() - 30);

        cstdate = new Date();
        cstdate.setHours(cstdate.getHours() - 11);
        cstdate.setMinutes(cstdate.getMinutes() - 30);

        mstdate = new Date();
        mstdate.setHours(mstdate.getHours() - 12);
        mstdate.setMinutes(mstdate.getMinutes() - 30);

        pstdate = new Date();
        pstdate.setHours(pstdate.getHours() - 13);
        pstdate.setMinutes(pstdate.getMinutes() - 30);
    }

    else {
        estdate = new Date();
        cstdate.setHours(cstdate.getHours() - 1);
        mstdate.setHours(mstdate.getHours() - 2);
        pstdate.setHours(pstdate.getHours() - 3);
    }


    var istFormatDate = estdate.getMonth() + "/" + estdate.getDate() + "/" + estdate.getDay()
        + "/" + estdate.getHours() + ":" + estdate.getMinutes() + ":" + estdate.getSeconds();

    var esttimeFormat = estdate.getHours() < 12 ? "AM" : "PM";
    var csttimeFormat = cstdate.getHours() < 12 ? "AM" : "PM";
    var msttimeFormat = mstdate.getHours() < 12 ? "AM" : "PM";
    var psttimeFormat = pstdate.getHours() < 12 ? "AM" : "PM";


    //$("#lbldate").html(istFormatDate);
    $('#lblEst').text(pad2(estdate.getHours()) + ":" + pad2(estdate.getMinutes()) + ' ' + esttimeFormat);
    $('#lblCst').text(pad2(cstdate.getHours()) + ":" + pad2(cstdate.getMinutes()) +' '+ csttimeFormat);
    $('#lblMst').text(pad2(mstdate.getHours()) + ":" + pad2(mstdate.getMinutes()) + ' ' + msttimeFormat);
    $('#lblPst').text(pad2(pstdate.getHours()) + ":" + pad2(pstdate.getMinutes()) + ' ' + psttimeFormat);
    //$("#lbldate1").html(estdate);
}

setInterval(function () {
    rendertime();

}, 60000);

function pad2(number) {
    return (number < 10 ? '0' : '') + number

}

function getDashboardTimer() {
    //common_api_ajax_request("RecruitingAPI/api/DashboardTimer", "TIMER", "");    
    common_api_ajax_request("api/DashboardTimer", "TIMER", "");    
}




function gotoFollowPage(id) {
    window.location.href = "FollowupPage.aspx?id=" + id;
}

function gotoJobPage() {

    if (getSession('Designation') == "4001") {
        window.location.href = "JobList.aspx";
    }
    else if (getSession('Designation') == "4000" || getSession('Rolename') == "Manager" || getSession('Rolename') == "Senior Manager") {
        window.location.href = "ManagerJobList.aspx";
    }
}
