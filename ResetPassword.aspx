<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="Recruiting_API.ResetPassword" %>

<!DOCTYPE html>
<html>
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
    <link id="pagestyle" href="assets/css/soft-ui-dashboard.css?v=1.0.2" rel="stylesheet" />
    <link href="assets/css/Common.css" rel="stylesheet" />
    <!-- Anti-flicker snippet (recommended)  -->

    <style>
        .async-hide {
            opacity: 0 !important;
        }
    </style>

    <!-- End Google Tag Manager -->
</head>

<body class="g-sidenav-show   bg-white">
    <!-- Extra details for Live View on GitHub Pages -->
    <!-- Google Tag Manager (noscript) -->
    <noscript>
        <iframe src="https://www.googletagmanager.com/ns.html?id=GTM-NKDMSK6" height="0" width="0" style="display: none; visibility: hidden"></iframe>
    </noscript>
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
                                <h3 class="text-info text-gradient text-center">Reset Password</h3>
                            </div>
                            <div class="card-body pt-2">
                                <form runat="server" role="form text-left">
                                    <label>Email</label><label class="mb-0 mt-1" id="lblvalidemail" style="color: red; float: right; display: none;">#Enter Valid Email</label>
                                    <div class="mb-3">
                                        <input type="text" class="form-control" placeholder="Email" aria-label="Email" id="txtemailid" tabindex="0" aria-describedby="email-addon" onblur="checkifEmailExists();">
                                    </div>

                                    <label>Old Password</label>
                                    <div class="input-group mb-4">
                                        <input class="form-control" placeholder="******" type="password" id="txtoldpassword" disabled="disabled" onblur="checkoldpassword();" tabindex="1">
                                        <input type="hidden" id="hdnoldpassword" />
                                        <input type="hidden" id="hdnTWEID" />
                                        <span class="input-group-text"><i class="fas fa-eye" onclick="viewpass('txtoldpassword','pass_viewold','pass_unviewold')" id="pass_viewold"></i><i class="far fa-eye-slash" onclick="viewpass('txtoldpassword','pass_viewold','pass_unviewold')" id="pass_unviewold" style="display: none;"></i></span>
                                    </div>

                                    <label>New Password</label>
                                    <div class="input-group mb-4">
                                        <input class="form-control" placeholder="******" type="password" id="txtnewpassword" disabled="disabled" onkeyup='check();' tabindex="2">
                                        <span class="input-group-text"><i class="fas fa-eye" onclick="viewpass('txtnewpassword','pass_viewnew','pass_unviewnew')" id="pass_viewnew"></i><i class="far fa-eye-slash" onclick="viewpass('txtnewpassword','pass_viewnew','pass_unviewnew')" id="pass_unviewnew" style="display: none;"></i></span>
                                    </div>

                                    <label>Re-type New Password</label><label class="mb-0 mt-1" id="message" style="color: red; float: right;"></label>
                                    <div class="input-group mb-4">
                                        <input class="form-control" placeholder="******" type="password" id="txtretypenewpass" disabled="disabled" onkeyup='check();' tabindex="3">
                                        <span class="input-group-text"><i class="fas fa-eye" onclick="viewpass('txtretypenewpass','pass_view','pass_unview')" id="pass_view"></i><i class="far fa-eye-slash" onclick="viewpass('txtretypenewpass','pass_view','pass_unview')" id="pass_unview" style="display: none;"></i></span>
                                    </div>

                                    <div class="text-center">
                                        <label class="mb-0" style="color: red; display: none;">#Passwords are not matching</label>
                                    </div>

                                    <div class="text-center">
                                        <button type="button" class="btn btn-rose w-100 mb-0" id="btnSend" onclick="validatesend();" disabled="disabled" tabindex="4">Reset</button>
                                    </div>

                                    <hr class="horizontal dark my-3">
                                    <div class="text-center">
                                        <a href="Login.aspx" class="card-link text-center" style="color: #1000ff; font-family: Open Sans !important; font-size: .875rem;" id="aForgotpass" tabindex="5">Return to Login</a>
                                    </div>
                                </form>
                            </div>

                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="oblique position-absolute top-0 h-100 d-md-block d-none me-n8">
                            <div class="oblique-image bg-cover position-absolute fixed-top ms-auto h-100 z-index-0 ms-n6" style="background-image: url('assets/img/curved-images/Cover16.jpg')"></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="ms-auto my-auto mt-lg-0 mt-4">
            <div class="ms-auto my-auto">
                <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                        <div class="modal-content">

                            <div class="col-md-12 mt-3 text-center">
                                <p class="mb-0 h6"><span id="div-message"></span></p>
                            </div>

                            <div class="modal-footer pt-0 text-center" style="border-top: none;">
                                <div class="col-md-12">
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk" onclick='$("#msgpopup").modal("hide");'>Ok</button>
                                </div>
                            </div>
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

        var check = function () {
            if (document.getElementById('txtnewpassword').value != "") {
                checkoldandnewpassword();

                if (document.getElementById('txtretypenewpass').value != "") {
                    if (document.getElementById('txtnewpassword').value ==
                        document.getElementById('txtretypenewpass').value) {
                        document.getElementById('message').style.color = 'green';
                        document.getElementById('message').innerHTML = 'Matching';
                    }
                    else {
                        document.getElementById('message').style.color = 'red';
                        document.getElementById('message').innerHTML = 'Not Matching';
                    }
                }
            }
        }

        function verifyPassword() {
            var pw = document.getElementById("txtnewpassword").value;

            //minimum password length validation  
            if (pw.length < 8) {
                document.getElementById("message").innerHTML = "**Password length must be atleast 8 characters";
                return false;
            }

            //maximum length of password validation  
            if (pw.length > 15) {
                document.getElementById("message").innerHTML = "**Password length must not exceed 15 characters";
                return false;
            } else {
                alert("Password is correct");
            }
        }

        function viewpass(txt, view1, view2) {
            var x = document.getElementById(txt);
            if (x.type === "password") {
                x.type = "text";
                document.getElementById(view2).style.display = "block";
                document.getElementById(view1).style.display = "none";

            } else {
                x.type = "password";
                document.getElementById(view2).style.display = "none";
                document.getElementById(view1).style.display = "block";
            }
        }


        function Validateresetpass() {
            var count = 0;
            var emptycount = 0;

            if ($('#txtoldpassword').val() == "") {
                $('#txtoldpassword').addClass("is-invalid");
                emptycount++;
            }
            else {
                $('#txtoldpassword').removeClass("is-invalid");
                count++;
            }

            if ($('#txtnewpassword').val() == "") {
                $('#txtnewpassword').addClass("is-invalid");
                emptycount++;
            }
            else {
                $('#txtnewpassword').removeClass("is-invalid");
                count++;
            }

            if ($('#txtretypenewpass').val() == "") {
                $('#txtretypenewpass').addClass("is-invalid");
                emptycount++;
            }
            else {
                $('#txtretypenewpass').removeClass("is-invalid");
                count++;
            }

            if (parseInt(emptycount) > 0) {
                return false;
            }

            else if (parseInt(count) > 0) {
                return true;
            }

        }
    </script>

    <script>
        function validatesend() {
            if (Validateresetpass() == true) {
                resetPassword();
            }
        }

        function ValidateEmail(input) {
            var inputText = document.getElementById(input);
            var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
            if (inputText.value.match(mailformat)) {
                //alert("Valid email address!");
                $("#" + input).removeClass("is-invalid");

                return true;
            }
            else {
                if (inputText.value != "") {
                    $("#" + input).addClass("is-invalid");
                    $("#" + input).focus();
                    $('#btnSend').prop('disabled', 'disabled');
                    $('#txtoldpassword').prop('disabled', 'disabled');
                    $('#lblvalidemail').css("display", "block");
                    //alert("You have entered an invalid email address!");
                    return false;
                }
            }
        }

        function checkifEmailExists() {
            if (ValidateEmail('txtemailid') == true) {
                var emailid = $("#txtemailid").val();
                var strdata = { "emailid": emailid };
                if (emailid != "") {
                    common_api_ajax_request("api/EmailIDCheck", "EMAILCHECK", strdata);
                }
            }
        }

        function resetPassword() {

            var TWE_ID = $("#hdnTWEID").val();
            var newpsw = $("#txtnewpassword").val();


            var strdata = { "TWE_ID": TWE_ID, "newpsw": newpsw };
            if (newpsw != "") {
                common_api_ajax_request("api/updatePassword", "UPDATEPASSWORD", strdata);
            }
        }

        function successCallBack(key, value) {

            var response = value.d;
            var resData = response.data;

            if (key == "EMAILCHECK") {
                if (resData.includes("True")) {
                    var st = resData.split("$");

                    $("#hdnTWEID").val(st[1]);
                    $("#hdnoldpassword").val(st[2]);
                    $('#btnSend').prop('disabled', false);
                    $('#txtoldpassword').prop('disabled', false);
                    $('#txtemailid').removeClass("is-invalid");
                    $('#lblvalidemail').css("display", "none");
                }
                else if (resData == "False") {
                    $("#div-message").text('Enter Registered Mail Id');
                    $("#msgpopup").modal('show');
                    $('#txtemailid').addClass("is-invalid");
                    $('#lblvalidemail').css("display", "none");
                    $("#btnOk").attr("onclick", "closepopup('0')");
                }

            }

            if (key == "UPDATEPASSWORD") {
                if (parseInt(resData) != 0) {
                    $("#div-message").text('Password updated successfully');
                    $("#msgpopup").modal('show');
                    $("#btnOk").attr("onclick", "closepopup('1')");
                }
            }
        }

        function checkoldpassword() {
            if ($('#txtoldpassword').val() != $('#hdnoldpassword').val()) {
                $("#div-message").text('Invalid credentials for this registered email id');
                $("#msgpopup").modal('show');
                $("#btnOk").attr("onclick", "closepopup('0')");
            }
            else {
                $('#txtnewpassword').prop('disabled', false);
            }
        }

        function checkoldandnewpassword() {
            if ($('#txtoldpassword').val() == $('#txtnewpassword').val()) {
                $("#div-message").text('Old Password and new password cannot be the same');
                $("#msgpopup").modal('show');
                $("#btnOk").attr("onclick", "closepopup('0')");
            }
            else {
                $('#txtretypenewpass').prop('disabled', false);
            }
        }

        function closepopup(val) {
            if (val == 0) {
                $("#msgpopup").modal('hide');

            }           
            else if (val == 1) {
                $("#msgpopup").modal('hide');
                window.location.href = "Login.aspx";
            }

        }

    </script>


    <!-- Github buttons -->
    <script async defer src="https://buttons.github.io/buttons.js"></script>
    <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->
    <script src="assets/js/soft-ui-dashboard.min.js?v=1.0.2"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>

    <script>
        var win = navigator.platform.indexOf('Win') > -1;
        if (win && document.querySelector('#sidenav-scrollbar')) {
            var options = {
                damping: '0.5'
            }
            Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
        }

        $(document).ready(function () {
            clearSession();
        });

    </script>

</body>

</html>
