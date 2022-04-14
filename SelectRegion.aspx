<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SelectRegion.aspx.cs" Inherits="Recruiting_API.SelectRegion" %>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
  <link rel="apple-touch-icon" sizes="76x76" href="assets/img/apple-icon.png">
  <link rel="icon" type="image/png" href="assets/img/Tab-logo.png">
  <title>
    Techwaukee
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
          <div class="col-md-6 d-flex flex-column mx-auto">
            <div class="card card-plain mt-12">
              <div class="row">
                <div class="col-lg-4 col-md-6">
                  <div class="card card-background card-background-mask-primary mt-md-0 mt-5" onclick="setRegion('India')">
                    <div class="full-background" style="background-image: url('https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/curved-images/curved8.jpg')"></div>
                    <div class="card-body pt-5 text-center">
                      <div class="icon mx-auto text-lg">
                        <%--<i class="ni ni-html5"></i>--%>
                          <img src="Images/Flag-india.png" style="width:20px;"/>
                      </div>
                      <h5 class="text-white mb-2">India</h5>
                      
                    </div>
                  </div>
                </div>
                <div class="col-lg-4 col-md-6">
                  <div class="card card-background card-background-mask-primary mt-md-0 mt-5" onclick="setRegion('USA')">
                    <div class="full-background" style="background-image: url('https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/curved-images/curved9.jpg')"></div>
                    <div class="card-body pt-5 text-center">
                      <div class="icon mx-auto text-lg">
                        <%--<i class="ni ni-paper-diploma"></i>--%>
                          <img src="Images/united-states.png" style="width:20px;"/>
                      </div>
                      <h5 class="text-white mb-2">USA</h5>
                      
                    </div>
                  </div>
                </div>
                <div class="col-lg-4 col-md-6">
                  <div class="card card-background card-background-mask-primary mt-md-0 mt-5" onclick="setRegion('Others')">
                    <div class="full-background" style="background-image: url('https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/curved-images/curved6.jpg')"></div>
                    <div class="card-body pt-5 text-center">
                      <div class="icon mx-auto text-lg">
                        <%--<i class="ni ni-favourite-28"></i>--%>
                          <img src="Images/Global.png" style="width:20px;"/>
                      </div>
                      <h5 class="text-white mb-2">Others</h5>
                      
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="col-md-6">
            <div class="oblique position-absolute top-0 h-100 d-md-block d-none me-n8">
              <div class="oblique-image bg-cover position-absolute fixed-top ms-auto h-100 z-index-0 ms-n6" style="background-image:url('assets/img/curved-images/curved14.jpg')"></div>
            </div>
              <%--<img src="assets/img/curved-images/curved6.jpg" /><img src="assets/img/curved-images/curved14.jpg" />--%>
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

      function setRegion(val) {
          setSession("Region", val);
          if (val=="India") {
              window.location.href = "RecruiterDashboard_Ind.aspx";

          }

          else if (val=="USA") {
              window.location.href = "RecruiterDashboard.aspx";
          }
          
      }

      
  </script>
  <!-- Github buttons -->
  <script async defer src="https://buttons.github.io/buttons.js"></script>
  <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="assets/js/soft-ui-dashboard.min.js?v=1.0.2"></script>
    <script src="assets/js/jquery.js"></script>
    <script src="Scripts/js/jquery.cookie.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="assets/js/db_js/db_login.js"></script>
</body>

</html>