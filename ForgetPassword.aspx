<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="Recruiting_API.ForgetPassword" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="Images/hunt%20crew%20Fav.png">
  <title>
    Hunt Crew
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
  
  <!-- End Google Tag Manager -->
</head>

<body class="g-sidenav-show   bg-white">
  <!-- Extra details for Live View on GitHub Pages -->
  <!-- Google Tag Manager (noscript) -->
  <noscript><iframe src="https://www.googletagmanager.com/ns.html?id=GTM-NKDMSK6" height="0" width="0" style="display:none;visibility:hidden"></iframe></noscript>
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
            <div class="card card-plain login-bg  mt-6">
              <div class="card-header pb-0 text-left bg-transparent"><center>
                  <img src="Images/hunt%20crew%20logo.png" style="width: 50%;"/></center>
                  <h3 class="text-info text-gradient text-center">Forgot Password</h3>
              </div>
              <div class="card-body pt-2">
                <form runat="server" role="form text-left">

                    <div class="info-div" role="alert" id="resetpassword.message.expired_token">The user credentials for this hunT creW account will be mailed to your registered email address.</div>

                  <label>User Name</label>
                  <div class="mb-3">
                      <input type="text" class="form-control" placeholder="User Name" aria-label="Username" id="txtusername" aria-describedby="email-addon">
                  </div>

                  <label>Email</label><label class="mb-0 mt-1" id="lblvalidemail" style="color:red;float:right;display:none;">Enter Valid Email</label>
                  <div class="mb-3">
                      <input type="text" class="form-control" placeholder="Email" aria-label="Email" id="txtemailid" aria-describedby="email-addon" onblur="ValidateEmail('txtemailid');">
                  </div>

                    <div class="alert alert-danger font-weight-bold" role="alert" id="Alert" style="display:none;">
                      <span class="alert-icon"><i class="far fa-times"></i></span>
                      <span id="lblMsg">Enter Valid Email</span>
                    </div>
                    
                  <div class="text-center">
                      <button type="button" class="btn btn-rose w-100 mt-4 mb-0" id="btnReset" onclick="sendForgetPasswordMail();">Send</button>
                  </div>

                    <hr class="horizontal dark my-3">
                    <div class="text-center">
                        <a href="Login.aspx" class="card-link text-center" style="color: #1000ff;font-family: Open Sans !important;font-size: .875rem;" id="aForgotpass">Return to Login</a>
                    </div>
                </form>
              </div>
              
            </div>
          </div>
          <div class="col-md-6">
            <div class="oblique position-absolute top-0 h-100 d-md-block d-none me-n8">
              <div class="oblique-image bg-cover position-absolute fixed-top ms-auto h-100 z-index-0 ms-n6" style="background-image:url('assets/img/curved-images/Cover15.jpg')"></div>
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
                                <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk" onclick="$('#msgpopup').modal('hide');">Ok</button>
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
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
   
    <script src="AppScripts/ForgotPassword.js"></script>
</body>

</html>
