$(document).ready(function () {

    setSession("Page", "DashboardIndia");
    $('#lblEmployeename').text(getSession('Name'));

    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchCand").removeClass("active");
    $("#anchTeam").addClass("active");
    $('#anchTeam').attr('aria-expanded', 'true');
    $("#div_Team").addClass("show");
    $("#teamList").addClass("active");


    $('#lblPagetitle').text("Manager Dashboard");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    getManagerDashboard();

});

//function successCallBack(key, value) {

//    var response = value.d;
//    var resData = response.data;
//    //var listdata = resData._lsttl;
//    if (key == "TEAMLIST") {

//        var str2 = "";
//        $.each(resData, function (key, item) {
//            if (item.Userid == "") {

//            } else {
//                if (item.Role == "Recruiter") {
//                    var str = item.Username.replace(" ", "%20");
//                    str2 += "<div class='col-xl-3 col-sm-6 mb-xl-0 mb-4'>" +
//                        "<div class='card zm' style='cursor: pointer;'>" +
//                        "<div class='card-body p-3' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + item.Userid + "&name=" + str + "'>" +
//                        "<div class='row'>" +
//                        "<div class='col-8'>" +
//                        "<div class='numbers'>" +
//                        "<p class='text-sm mb-0 text-capitalize font-weight-bold'></p>" +
//                        "<h5 class='font-weight-bolder mb-0'>" +
//                        "<label class='h5 font-weight-bolder' id='lblEmpname'>" + item.Username + "</label><br/>" +
//                        "<label class='text-success text-sm font-weight-bolder' id='lblEmpRole'>" + item.Role + "</label>" +
//                        "</h5>" +
//                        "</div>" +
//                        "</div>" +
//                        "<div class='col-4 text-end'>" +
//                        "<div class='icon icon-shape bg-gradient-primary shadow text-center border-radius-md'>" +
//                        "<i class='ni ni-diamond text-lg opacity-10' aria-hidden='true'></i>" +
//                        "</div>" +
//                        "</div>" +
//                        "</div>" +
//                        "</div>" +
//                        "</div>" +
//                        "</div>";
//                }
//            }
//        });

//        $('#div_team').empty();
//        $('#div_team').append(str2);


//    }
//}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    //var listdata = resData._lsttl;
    if (key == "TEAMLIST") {

        var str1 = "";
        var str2 = "";
        var str32 = "";
        if (getSession('Rolename') == "Manager") {

            str1 += "<ul>" +
                "<li>" +

                "<center><div class='card mb-4 zm' style='width: 35%;'>" +
                "<div class='card-body p-3'>" +
                "<div class='row'>" +
                "<div class='col-5 text-right p-0'>" +

                "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                "<img alt='Image placeholder' class='p-1' src='Images/Employees/MohanSir.png' style='height: 58px;'>" +
                "</a>" +

                "</div>" +
                "<div class='col-7'>" +
                "<div class='numbers'>" +
                "<h5 class='font-weight-bolder mb-0'>" +
                "<p class='text-sm mb-0 text-capitalize font-weight-bold'>Myself</p>" +
                "</h5>" +
                "<span class='text-success text-sm font-weight-bolder'>Manager</span>" +
                "</div>" +
                "</div>" +

                "</div>" +
                "</div></div></center>";

        }
        else {
            for (var i = 0; i < resData.length; i++) {
                if (resData[i].Role == "Manager") {
                    var str = resData[i].Username.replace(" ", "%20");
                    str1 += "<ul>" +
                        "<li>" +

                        "<center><div class='card mb-4 zm' style='width: 40%;'>" +
                        "<div class='card-body p-3'>" +
                        "<div class='row'>" +
                        "<div class='col-4 text-right p-0'>" +

                        "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                        "<img alt='Image placeholder' style='height: 58px;' class='p-1' src='" + resData[i].Profileimg + "'>" +
                        "</a>" +

                        "</div>" +
                        "<div class='col-8 '>" +
                        "<div class='numbers'>" +
                        "<h5 class='font-weight-bolder mb-0'>" +
                        "<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                        "</h5>" +
                        "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                        "</div>" +
                        "</div>" +

                        "</div>" +
                        "</div></div></center>";
                }


            }
        }
        if (getSession('Rolename') == "Team Lead") {

            str2 += "<ul class='active'>" +
                "<li id='li_teamlead'>" +
                "<center><div class='card mb-4 zm' style='width: 35%;'>" +
                //"<center><div class='card mb-4 zm' style='width: 50%;' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + getSession('TWE_ID') + "&name=" + getSession('Name').replace(" ", "%20") + "'>" +
                "<div class='card-body p-3'>" +
                "<div class='row'>" +
                "<div class='col-5 text-right p-0'>" +

                "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                "<img alt='Image placeholder' class='p-1' src='Images/Employees/Rex.png' style='height: 58px;'>" +
                "</a>" +

                "</div>" +
                "<div class='col-7'>" +
                "<div class='numbers'>" +
                "<h5 class='font-weight-bolder mb-0'>" +
                "<p class='text-sm mb-0 text-capitalize font-weight-bold'>Myself</p>" +
                "</h5>" +
                "<span class='text-success text-sm font-weight-bolder'>Team Lead</span>" +
                "</div>" +
                "</div>" +

                "</div>" +
                "</div></div></center>";


        }

        else {
            for (var i = 0; i < resData.length; i++) {
                if (resData[i].Role == "Team Lead") {
                    var str = resData[i].Username.replace(" ", "%20");
                    str2 += "<ul class='active'>" +
                        "<li id='li_teamlead'>" +

                        "<center><div class='card mb-4 zm' style='width: 40% !important;' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                        "<div class='card-body p-3' style='cursor:pointer'>" +
                        "<div class='row'>" +
                        "<div class='col-4 text-right p-0'>" +

                        "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                        "<img alt='Image placeholder' class='p-1' src='" + resData[i].Profileimg + "' style='height: 58px;'>" +
                        "</a>" +

                        "</div>" +
                        "<div class='col-8'>" +
                        "<div class='numbers'>" +
                        "<h5 class='font-weight-bolder mb-0'>" +
                        "<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                        "</h5>" +
                        "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                        "</div>" +
                        "</div>" +

                        "</div>" +
                        "</div></div></center>";

                }
            }
        }


        for (var i = 0; i < resData.length; i++) {
            if (resData[i].Role == "Recruiter") {
                var str = resData[i].Username.replace(" ", "%20");
                str32 += "<li>" +
                    //"<a href='javascript:void(0);'>" +
                    "<center><div class='card mb-4 zm' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                    "<div class='card-body p-3' style='cursor:pointer'>" +
                    "<div class='row' >" +
                    "<div class='col-4 text-right p-0'>" +

                    "<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                    "<img alt='Image placeholder' class='p-1' src='" + resData[i].Profileimg + "' style='height: 58px;'>" +
                    "</a>" +

                    "</div>" +
                    "<div class='col-8'>" +
                    "<div class='numbers'>" +
                    "<h5 class='font-weight-bolder mb-0'>" +
                    "<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                    "</h5>" +
                    "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                    "</div>" +
                    "</div>" +

                    "</div>" +
                    "</div></div></center>" +
                    // "</a>" +
                    "</li>";
            }
        }


        var str31 = "<ul class='active'>";

        var str33 = "</ul>" +
            "</li>" +
            "</ul>" +
            "</li>" +
            "</ul>";

        var strTeam = str1 + str2 + str31 + str32 + str33;

        $('#div_team').empty();
        $('#div_team').append(strTeam);


    }
}


function getManagerDashboard() {
    var strdata = {
        "userid": getSession('TWE_ID')
    };
    common_api_ajax_request("api/getReportingTeamList", "TEAMLIST", strdata);
}