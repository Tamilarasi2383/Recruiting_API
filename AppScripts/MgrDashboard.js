$(document).ready(function () {

    setSession("Page", "Dashboard");
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

//                str2 += "<div class='col-xl-3 col-sm-6 mb-xl-0 mb-4'>" +
//                    "<div class='card zm' style='cursor: pointer;'>" +
//                    "<div class='card-body p-3' onclick=window.location='ManagerFeedback.aspx?id=" + item.Userid + "'>" +
//                    "<div class='row'>" +
//                    "<div class='col-8'>" +
//                    "<div class='numbers'>" +
//                    "<p class='text-sm mb-0 text-capitalize font-weight-bold'></p>" +
//                    "<h5 class='font-weight-bolder mb-0'>" +
//                    "<label class='h5 font-weight-bolder' id='lblEmpname'>" + item.Username + "</label><br/>" +
//                    "<label class='text-success text-sm font-weight-bolder' id='lblEmpRole'>" + item.Role + "</label>" +
//                    "</h5>" +
//                    "</div>" +
//                    "</div>" +
//                    "<div class='col-4 text-end'>" +
//                    "<div class='icon icon-shape bg-gradient-primary shadow text-center border-radius-md'>" +
//                    "<i class='ni ni-diamond text-lg opacity-10' aria-hidden='true'></i>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>";
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

        var str11 = "<ul class='jss678 jss679'>";

        if (getSession('Rolename') == "Senior Manager") {

            str1 += "<li class='jss680 mb-0'>" +

                "<div>" +
                "<img alt='Image placeholder' class='p-0' src='Images/Employees/MohanSir.png' style='border:solid 1px #cb0c9f !important; height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                "</div>" +
                "<div class='jss689 jss691 jsshover1' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;'>" +
                "<div>" +
                "<span class='jss697 jss700' style='background-color: #ff843b !important;'>My Self</span>" +
                "</div>" +
                "<span class='text-success text-sm font-weight-bolder'>Senior Manager</span>" +
                "</div>";

            //"<center><div class='card mb-4 zm' style='width: 30%;'>" +
            //"<div class='card-body p-3'>" +
            //"<div class='row'>" +
            //"<div class='col-5  p-0'>" +

            //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
            //"<img alt='Image placeholder' class='p-1' src='Images/Employees/MohanSir.png' style='height: 58px;'>" +
            //"</a>" +

            //"</div>" +
            //"<div class='col-7'>" +
            //"<div class='numbers'>" +
            //"<h5 class='font-weight-bolder mb-0'>" +
            //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>Myself</p>" +
            //"</h5>" +
            //"<span class='text-success text-sm font-weight-bolder'>Senior Manager</span>" +
            //"</div>" +
            //"</div>" +

            //"</div>" +
            //"</div></div></center>";

        }
        else {
            for (var i = 0; i < resData.length; i++) {
                if (resData[i].Role == "Senior Manager") {
                    var str = resData[i].Username.replace(" ", "%20");
                    str1 += "<li class='jss680 mb-0'>" +


                        "<div>" +
                        //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                        "<img alt='Image placeholder' class='p-0' src='" + resData[i].Profileimg + "' style='border:solid 1px #ff843b !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                        //"</a>" +
                        "</div>" +
                        "<div class='jss689 jss691 jsshover1' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;'>" +
                        "<div>" +
                        "<span class='jss697 jss700' style='background-color: #ff843b !important;'>" + resData[i].Username + "</span>" +
                        "</div>" +
                        "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                        "</div>";

                    //"<center><div class='card mb-4 zm' style='width: 30% !important;'>" +
                    //"<div class='card-body p-3'>" +
                    //"<div class='row'>" +
                    //"<div class='col-5  p-0'>" +

                    //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                    //"<img alt='Image placeholder' style='height: 58px;' class='p-1' src='" + resData[i].Profileimg + "' >" +
                    //"</a>" +

                    //"</div>" +
                    //"<div class='col-7'>" +
                    //"<div class='numbers'>" +
                    //"<h5 class='font-weight-bolder mb-0'>" +
                    //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                    //"</h5>" +
                    //"<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                    //"</div>" +
                    //"</div>" +

                    //"</div>" +
                    //"</div></div></center>";
                }


            }
        }


        if (getSession('Rolename') == "Manager") {

            str1 += "<li class='jss680 mb-0'>" +


                "<div>" +
                "<img alt='Image placeholder' class='p-0' src='Images/Employees/krish.png' style='border:solid 1px #1edefc !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                "</div>" +
                "<div class='jss689 jss691 jsshover2' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;'>" +
                "<div>" +
                "<span class='jss697 jss700' style='background-color: #1edefc !important;'>My Self</span>" +
                "</div>" +
                "<span class='text-success text-sm font-weight-bolder'>Manager</span>" +
                "</div>";

            //"<center><div class='card mb-4 zm' style='width: 22%;'>" +
            //"<div class='card-body p-3'>" +
            //"<div class='row'>" +
            //"<div class='col-5 text-right p-0'>" +

            //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
            //"<img alt='Image placeholder' class='p-1' src='Images/Employees/krish.png' style='height: 58px;'>" +
            //"</a>" +

            //"</div>" +
            //"<div class='col-7'>" +
            //"<div class='numbers'>" +
            //"<h5 class='font-weight-bolder mb-0'>" +
            //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>Myself</p>" +
            //"</h5>" +
            //"<span class='text-success text-sm font-weight-bolder'>Manager</span>" +
            //"</div>" +
            //"</div>" +

            //"</div>" +
            //"</div></div></center>";

        }
        else {
            for (var i = 0; i < resData.length; i++) {
                if (resData[i].Role == "Manager") {
                    var str = resData[i].Username.replace(" ", "%20");
                    str1 += "<li class='jss680 mb-0'>" +


                        "<div>" +
                        //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                        "<img alt='Image placeholder' class='p-0' src='" + resData[i].Profileimg + "' style='border:solid 1px #1edefc !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                        //"</a>" +
                        "</div>" +
                        "<div class='jss689 jss691 jsshover2' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;'>" +
                        "<div>" +
                        "<span class='jss697 jss700' style='background-color: #1edefc !important;'>" + resData[i].Username + "</span>" +
                        "</div>" +
                        "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                        "</div>";

                    //"<center><div class='card mb-4 zm' style='width: 25% !important;'>" +
                    //"<div class='card-body p-3'>" +
                    //"<div class='row'>" +
                    //"<div class='col-5 text-right p-0'>" +

                    //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                    //"<img alt='Image placeholder' style='height: 58px;' class='p-1' src='" + resData[i].Profileimg + "' >" +
                    //"</a>" +

                    //"</div>" +
                    //"<div class='col-7'>" +
                    //"<div class='numbers'>" +
                    //"<h5 class='font-weight-bolder mb-0'>" +
                    //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                    //"</h5>" +
                    //"<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                    //"</div>" +
                    //"</div>" +

                    //"</div>" +
                    //"</div></div></center>";
                }


            }
        }



        if (getSession('Rolename') == "Team Lead") {

            str2 += "<li class='jss680 mb-0'>" +


                "<div>" +
                //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                "<img alt='Image placeholder' class='p-0' src='Images/Employees/Nirmal.png' style='border:solid 1px #28ff8a !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                //"</a>" +
                "</div>" +
                "<div class='jss689 jss691 jsshover3' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + getSession('TWE_ID') + "&name=" + getSession('Name').replace(" ", "%20") + "'>" +
                "<div>" +
                "<span class='jss697 jss700' style='background-color: #28ff8a !important;'>My Self</span>" +
                "</div>" +
                "<span class='text-success text-sm font-weight-bolder'>Team Lead</span>" +
                "</div>";

            //"<center><div class='card mb-4 zm' style='width: 25% !important;'>" +
            ////"<center><div class='card mb-4 zm' style='width: 50%;' onclick=window.location='ManagerFeedbackpageIndia.aspx?id=" + getSession('TWE_ID') + "&name=" + getSession('Name').replace(" ", "%20") + "'>" +
            //"<div class='card-body p-3'>" +
            //"<div class='row'>" +
            //"<div class='col-5 text-right p-0'>" +

            //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
            //"<img alt='Image placeholder' class='p-1' src='Images/Employees/Nirmal.png' style='height: 58px;'>" +
            //"</a>" +

            //"</div>" +
            //"<div class='col-7'>" +
            //"<div class='numbers'>" +
            //"<h5 class='font-weight-bolder mb-0'>" +
            //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>Myself</p>" +
            //"</h5>" +
            //"<span class='text-success text-sm font-weight-bolder'>Team Lead</span>" +
            //"</div>" +
            //"</div>" +

            //"</div>" +
            //"</div></div></center>";


        }

        else {
            for (var i = 0; i < resData.length; i++) {
                if (resData[i].Role == "Team Lead") {
                    var str = resData[i].Username.replace(" ", "%20");
                    str2 += "<li class='jss680 mb-0'>" +


                        "<div>" +
                        //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                        "<img alt='Image placeholder' class='p-0' src='" + resData[i].Profileimg + "' style='border:solid 1px #28ff8a !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                        //"</a>" +
                        "</div>" +
                        "<div class='jss689 jss691 jsshover3' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;' onclick=window.location='ManagerFeedbackpage.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                        "<div>" +
                        "<span class='jss697 jss700' style='background-color: #28ff8a !important;'>" + resData[i].Username + "</span>" +
                        "</div>" +
                        "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                        "</div>";

                    //"<center><div class='card mb-4 zm' style='width: 32% !important;' onclick=window.location='ManagerFeedbackpage.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                    //"<div class='card-body p-3' style='cursor:pointer'>" +
                    //"<div class='row'>" +
                    //"<div class='col-4 text-right p-0'>" +

                    //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                    //"<img alt='Image placeholder' class='p-1' src='" + resData[i].Profileimg + "' style='height: 58px;'>" +
                    //"</a>" +

                    //"</div>" +
                    //"<div class='col-8'>" +
                    //"<div class='numbers'>" +
                    //"<h5 class='font-weight-bolder mb-0'>" +
                    //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                    //"</h5>" +
                    //"<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                    //"</div>" +
                    //"</div>" +

                    //"</div>" +
                    //"</div></div></center>";

                }
            }
        }


        for (var i = 0; i < resData.length; i++) {
            if (resData[i].Role == "Recruiter") {
                var str = resData[i].Username.replace(" ", "%20");
                str32 += "<li class='jss680 mb-0'>" +


                    "<div>" +
                    //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                    "<img alt='Image placeholder' class='p-0' src='" + resData[i].Profileimg + "' style='border:solid 1px #f44336 !important;height: 50px; width: 50px; border-top-left-radius: 50%; border-top-right-radius: 50%; border-bottom-left-radius: 50%; border-bottom-right-radius: 50%;'>" +
                    //"</a>" +
                    "</div>" +
                    "<div class='jss689 jss691 jsshover4' style='float: left; margin-left: 68px; top: -62px;cursor: pointer;' onclick=window.location='ManagerFeedbackpage.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                    "<div>" +
                    "<span class='jss697 jss700'>" + resData[i].Username + "</span>" +
                    "</div>" +
                    "<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                    "</div>";

                //"<a href='javascript:void(0);'>" +
                //"<center><div class='card mb-4 zm' style='width: 105%;' onclick=window.location='ManagerFeedbackpage.aspx?id=" + resData[i].Userid + "&name=" + str + "'>" +
                //"<div class='card-body p-3' style='cursor:pointer;width: 100%;'>" +
                //"<div class='row' >" +
                //"<div class='col-4 text-right p-0'>" +

                //"<a href='javascript:;' class='avatar avatar-lg rounded-circle border border-primary'>" +
                //"<img alt='Image placeholder' class='p-1' src='" + resData[i].Profileimg + "' style='height: 58px;'>" +
                //"</a>" +

                //"</div>" +
                //"<div class='col-8'>" +
                //"<div class='numbers'>" +
                //"<h5 class='font-weight-bolder mb-0'>" +
                //"<p class='text-sm mb-0 text-capitalize font-weight-bold'>" + resData[i].Username + "</p>" +
                //"</h5>" +
                //"<span class='text-success text-sm font-weight-bolder'>" + resData[i].Role + "</span>" +
                //"</div>" +
                //"</div>" +

                //"</div>" +
                //"</div></div></center>" +
                // "</a>" +
                //"</li>";
            }
        }


        //var str31 = "<ul class='active'>";

        //var str33 = "</ul>" +
        //    "</li>" +
        //    "</ul>" +
        //    "</li>" +
        //    "</ul>";

        var strTeam = str11 + str1 + str2 + str32 + "</ul>";

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