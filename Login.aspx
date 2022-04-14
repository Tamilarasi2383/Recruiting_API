<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Recruiting_API.Login" %>

<!--
=========================================================
* Soft UI Dashboard - v1.0.2
=========================================================

* Product Page: https://www.creative-tim.com/product/soft-ui-dashboard
* Copyright 2021 Creative Tim (https://www.creative-tim.com)
* Licensed under MIT (https://github.com/creativetimofficial/soft-ui-dashboard/blob/master/LICENSE.md)

* Coded by Creative Tim

=========================================================

* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
-->
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
    <link rel="icon" type="image/png" href="Images/hunt%20crew%20Fav.png">
    <title>Hunt Crew
    </title>
    <!-- Extra details for Live View on GitHub Pages -->
    <!-- Canonical SEO -->
    <link rel="canonical" href="https://www.creative-tim.com/product/soft-ui-dashboard" />
    <!--  Social tags      -->
    <meta name="keywords" content="creative tim, html dashboard, html css dashboard, web dashboard, bootstrap 5 dashboard, bootstrap 5, css3 dashboard, bootstrap 5 admin, Soft UI Dashboard bootstrap 5 dashboard, frontend, responsive bootstrap 5 dashboard, free dashboard, free admin dashboard, free bootstrap 5 admin dashboard">
    <meta name="description" content="Soft UI Dashboard is a beautiful Bootstrap 5 admin dashboard with a large number of components, designed to look beautiful and organized. If you are looking for a tool to manage and visualize data about your business, this dashboard is the thing for you.">
    <!-- Twitter Card data -->
    <meta name="twitter:card" content="product">
    <meta name="twitter:site" content="@creativetim">
    <meta name="twitter:title" content="Soft UI Dashboard by Creative Tim">
    <meta name="twitter:description" content="Soft UI Dashboard is a beautiful Bootstrap 5 admin dashboard with a large number of components, designed to look beautiful and organized. If you are looking for a tool to manage and visualize data about your business, this dashboard is the thing for you.">
    <meta name="twitter:creator" content="@creativetim">
    <meta name="twitter:image" content="https://s3.amazonaws.com/creativetim_bucket/products/450/original/opt_sd_free_thumbnail.png">
    <!-- Open Graph data -->
    <meta property="fb:app_id" content="655968634437471">
    <meta property="og:title" content="Soft UI Dashboard by Creative Tim" />
    <meta property="og:type" content="article" />
    <meta property="og:url" content="http://demos.creative-tim.com/soft-ui-dashboard/examples/dashboard.html" />
    <meta property="og:image" content="https://s3.amazonaws.com/creativetim_bucket/products/450/original/opt_sd_free_thumbnail.png" />
    <meta property="og:description" content="Soft UI Dashboard is a beautiful Bootstrap 5 admin dashboard with a large number of components, designed to look beautiful and organized. If you are looking for a tool to manage and visualize data about your business, this dashboard is the thing for you." />
    <meta property="og:site_name" content="Creative Tim" />
    <!--     Fonts and icons     -->
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,600,700" rel="stylesheet" />
    <!-- Nucleo Icons -->
    <link href="assets/css/nucleo-icons.css" rel="stylesheet" />
    <link href="assets/css/nucleo-svg.css" rel="stylesheet" />
    <!-- Font Awesome Icons -->
    <script src="https://kit.fontawesome.com/42d5adcbca.js" crossorigin="anonymous"></script>
    <link href="assets/css/nucleo-svg.css" rel="stylesheet" />
    <!-- CSS Files -->
    <link id="pagestyle" href="assets/css/soft-ui-dashboard.min.css?v=1.0.2" rel="stylesheet" />
    <link href="assets/css/Common.css" rel="stylesheet" />
    <!-- Anti-flicker snippet (recommended)  -->
    <style>
        .async-hide {
            opacity: 0 !important;
        }
    </style>

    <!-- end Analytics-Optimize Snippet -->
    <!-- Google Tag Manager -->

    <!-- End Google Tag Manager -->
</head>

<body class="g-sidenav-show   bg-white">
    <!-- Extra details for Live View on GitHub Pages -->
    <!-- Google Tag Manager (noscript) -->

    <!-- End Google Tag Manager (noscript) -->
    <div class="container position-sticky z-index-sticky top-0">
        <div class="row">
            <div class="col-12">
                <!-- Navbar -->

                <!-- End Navbar -->
            </div>
        </div>
    </div>
    <section>
        <div class="page-header">
            <div class="container  section-height-100">
                <div class="row">
                    <div class="col-xl-4 col-lg-5 col-md-6 d-flex flex-column mx-auto">
                        <div class="card card-plain login-bg mt-6">
                            <div class="card-header pb-0 text-left bg-transparent">
                                <center>
                                   <img src="Images/hunt%20crew%20logo.png" style="width: 50%;"/></center>
                                
                            </div>
                            <div class="card-body pt-2">
                                <form runat="server" role="form text-left">
                                    <label>User Name</label>
                                    <div class="mb-3">
                                        <input type="text" class="form-control" placeholder="User Name" aria-label="Email" id="id_username" aria-describedby="email-addon">
                                        <%--<asp:TextBox id="txtUsername" runat="server" placeholder="User Name" class="form-control"></asp:TextBox>--%>
                                        <%--<input type="text" class="form-control" placeholder="User Name" aria-label="Name" aria-describedby="email-addon" >--%>
                                    </div>
                                    <label>Password</label>
                                    <div class="input-group mb-4">
                                        <input class="form-control" placeholder="******" type="password" id="id_psw">
                                        <span class="input-group-text"><i class="fas fa-eye" onclick="viewpass()" id="pass_view"></i><i class="far fa-eye-slash" onclick="viewpass()" id="pass_unview" style="display: none;"></i></span>
                                    </div>

                                    <div class="alert alert-danger font-weight-bold p-2" role="alert" id="Alert" style="display: none;">
                                        <span class="alert-icon"><i class="far fa-times"></i></span>
                                        <span id="lblMsg">Enter Valid Username/Password</span>
                                    </div>
                                    <div class="form-check form-switch">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <input class="form-check-input" type="checkbox" id="rememberMe">
                                                    <label class="form-check-label" for="rememberMe">Remember me</label>
                                                </div>
                                                <div class="col-md-6" style="text-align: right; padding-right: 15px; padding-left: 0px;">
                                                    <a href="ForgetPassword.aspx" class="card-link" style="color: #1000ff; font-family: Open Sans !important; font-size: .875rem;" id="aForgotpass">Forgot Password?</a>
                                                </div>
                                            </div>
                                        </div>

                                    </div>


                                    <div class="text-center">
                                        <%--<asp:Button ID="btnLogin" runat="server" class="btn btn-rose w-100 mt-4 mb-0" Text="Login" OnClick="btnLogin_Click" />--%>
                                        <label for="example-text-input-1" class="btn btn-rose w-100 mt-4 mb-0" id="id_proced">Login</label>
                                        <%--<button type="button" class="btn btn-rose w-100 mt-4 mb-0" id="btnLogin">Login</button>--%>
                                    </div>
                                </form>
                            </div>
                            <%--<div class="card-footer text-center pt-0 px-lg-2 px-1">
                <p class="mb-4 text-sm mx-auto">
                  Don't have an account?
                  <a href="javascript:;" class="text-info text-gradient font-weight-bold">Sign up</a>
                </p>
              </div>--%>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="oblique position-absolute top-0 h-100 d-md-block d-none me-n8">
                            <div class="oblique-image bg-cover position-absolute fixed-top ms-auto h-100 z-index-0 ms-n6" style="background-size: contain !important; background-image: url('assets/img/curved-images/Cover16.jpg')"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- -------- START FOOTER 3 w/ COMPANY DESCRIPTION WITH LINKS & SOCIAL ICONS & COPYRIGHT ------- -->

    <!-- -------- END FOOTER 3 w/ COMPANY DESCRIPTION WITH LINKS & SOCIAL ICONS & COPYRIGHT ------- -->
    <!--   Core JS Files   -->
    <script src="assets/js/core/popper.min.js"></script>
    <script src="assets/js/core/bootstrap.min.js"></script>
    <script src="assets/js/plugins/smooth-scrollbar.min.js"></script>
    <script>
        var win = navigator.platform.indexOf('Win') > -1;
        if (win && document.querySelector('#sidenav-scrollbar')) {
            var options = {
                damping: '0.5'
            }
            Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
        }
    </script>
    <!-- Github buttons -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>
    <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->
    <script src="assets/js/soft-ui-dashboard.min.js?v=1.0.2"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="Scripts/jquery.cookie.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="assets/js/db_js/db_login.js"></script>
</body>

</html>
