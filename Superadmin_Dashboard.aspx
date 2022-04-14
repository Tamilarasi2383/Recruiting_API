<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_Dashboard.aspx.cs" Inherits="Recruiting_API.Superadmin_Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .loader_cls {
            z-index: 1000;
            background: #fcfefc;
            opacity: 1;
        }

        .hidden {
            display: none !important;
        }
    </style>

    <div class="bg-overlay loader_cls ">
        <section class="fullscreen">
            <div class="container-fullwidth">
                <div class="row justify-content-center p-60">
                    <div class="col-md-12 text-center">
                        <img class="h-100 w-100" src="Images/loader.gif" id="imgLoader" />
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="container-fluid py-4 hidden">
        <div class="row">
            <div class="col-xl-7">
                <div class="card">
                    <div class="card-header d-flex pb-0 p-3">
                        <h6 class="my-auto">Dashboard</h6>
                    </div>
                    <div class="card-body p-3 mt-2">
                        <div class="">
                            <div class="tab-pane show position-relative height-400 border-radius-lg" role="tabpanel" aria-labelledby="cam3" style="background-image: url('../../assets/img/home-decor-3.jpg'); background-size: cover;">

                                <div class="position-absolute d-flex top-0 w-100">
                                    <%--<p class="text-white p-3 mb-0">17.05.2021 4:57PM</p>--%>
                                    <div class="p-3 text-left">
                                        <span class="badge badge-secondary zm" style="background-color: #83868966 !important;">
                                            <h4 style="color: #f8f9fa;"> <i class="fas fa-map-marker-alt text-danger" aria-hidden="true"></i> India</h4>
                                            <br />
                                            <p style="color: #f8f9fa;">
                                                Workafella-High Street,<br />
                                                New No. 431, Anna Salai,<br />
                                                Chennai, TN 600018, India
                                            </p>
                                        </span>
                                    </div>
                                </div>

                                <div class="position-absolute d-flex top-50 w-100">
                                    <div class="ms-auto p-3">
                                        <span class="badge badge-secondary zm" style="background-color: #83868966 !important;">
                                            <h4 style="color: #f8f9fa;"> <i class="fas fa-map-marker-alt text-danger" aria-hidden="true"></i> USA</h4>
                                            <br />
                                            <p style="color: #f8f9fa;">
                                                11310 Brookhollow Tri,<br />
                                                Alpharetta, GA 30022,<br />
                                                USA.
                                            </p>
                                        </span>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-xl-5 ms-auto mt-xl-0 mt-4">
                <div class="row">
                    <div class="col-12">
                        <div class="card bg-gradient-primary">
                            <div class="card-body p-3">
                                <div class="row">
                                    <div class="col-12 my-auto">
                                        <div class="numbers">
                                            <label id="lblIST" class="h5 text-white font-weight-bolder mb-0"></label><br />
                                            <label id="lblEST"class="h5 text-white font-weight-bolder mb-0"></label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md-6" style="cursor: pointer;">
                        <div class="card zm" onclick="window.location.href='Superadmin_UserList.aspx'">
                            <div class="card-body text-center">
                                <h1 class="text-gradient text-primary"><span id="userstatus1">21</span> </h1>
                                <h6 class="mb-0 font-weight-bolder">Active Users</h6>
                                <p class="opacity-8 mb-0 text-sm" id="userstatus2">02 InActive Users</p>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 mt-md-0 mt-4" style="cursor: pointer;">
                        <div class="card zm" onclick="window.location.href='Clientlist.aspx'">
                            <div class="card-body text-center">
                                <h1 class="text-gradient text-primary"><span id="clientstatus1">44</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Active Clients</h6>
                                <p class="opacity-8 mb-0 text-sm" id="clientstatus2">01 InActive Clients</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md-6" style="cursor: pointer;">
                        <div class="card zm" onclick="window.location.href='Superadmin_ConfigDashboard.aspx'">
                            <div class="card-body text-center">
                                <h1 class="text-gradient text-primary"><span id="configstatus1">17</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Config Tables</h6>
                                <p class="opacity-8 mb-0 text-sm">00 InActive Tables</p>
                            </div>
                        </div>
                    </div>
                    <%--<div class="col-md-6 mt-md-0 mt-4">
              <div class="card zm">
                <div class="card-body text-center">
                  <h1 class="text-gradient text-primary"><span id="status4" countto="417">417</span></h1>
                  <h6 class="mb-0 font-weight-bolder">Internet</h6>
                  <p class="opacity-8 mb-0 text-sm">All devices</p>
                </div>
              </div>
            </div>--%>
                </div>
            </div>
        </div>
    </div>
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>

    <script>

        $(document).ready(function () {
            $('#lblPagetitle').text("SuperAdmin Dashboard");
            $('#dropdownMenuButton').css('display', 'none');
            $('#lblDurationview').css('display', 'none');
            rendertime();
            getSuperAdmindata();
        });


        function getSuperAdmindata() {

            common_api_ajax_request("api/Superadmindashboard", "SADashboard", "");

        }

        function successCallBack(key, value) {

            var response = value.d;
            var resData = response.data;

            if (key == "SADashboard") {
                $("#userstatus1").text(pad2(resData.AchiveCount));
                $("p#userstatus2").text(pad2(resData.TotalCount) + " " + " InActive Users");
                $("#clientstatus1").text(pad2(resData.Name));
                $("p#clientstatus2").text(pad2(resData.TileTitle) + " " + " InActive Clients");
                stopLoader();
            }

        }

        function rendertime() {
            var curdate = new Date();

            var strtext = curdate.toString();
            var findzone = (strtext.search("India"));

            if (findzone > 0) {
                estdate = new Date();
                estdate.setHours(estdate.getHours() - 10);
                estdate.setMinutes(estdate.getMinutes() - 30);

                istdate = new Date();
                var hours = istdate.getHours() > 12 ? istdate.getHours() - 12 : istdate.getHours();
                var am_pm = istdate.getHours() >= 12 ? "PM" : "AM";
                hours = hours < 10 ? "0" + hours : hours;
                var minutes = istdate.getMinutes() < 10 ? "0" + istdate.getMinutes() : istdate.getMinutes();
                //var seconds = istdate.getSeconds() < 10 ? "0" + istdate.getSeconds() : istdate.getSeconds();
                time = hours + ":" + minutes + " " + am_pm;
            }

            else {
                estdate = new Date();
                istdate.setHours(istdate.getHours() + 10);
                istdate.setMinutes(istdate.getMinutes() + 30);
            }


          
            var esttimeFormat = estdate.getHours() < 12 ? "AM" : "PM";
           


            //$("#lbldate").html(istFormatDate);
            $('#lblEST').text("EST" + " " +pad2(estdate.getHours()) + ":" + pad2(estdate.getMinutes()) + ' ' + esttimeFormat);
            $('#lblIST').text("IST" + " " + time);
            //$("#lbldate1").html(estdate);
        }

        setInterval(function () {
            rendertime();

        }, 60000);

        function pad2(number) {
            return (number < 10 ? '0' : '') + number
        }

    </script>

</asp:Content>

