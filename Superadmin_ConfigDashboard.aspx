<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_ConfigDashboard.aspx.cs" Inherits="Recruiting_API.Superadmin_ConfigDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .icon-color {
            color: #25dbfb !important;
        }

            .icon-color:hover {
                color: #555d5e !important;
            }

        .leter:hover {
            color: #25dbfb !important;
        }

        .zm1:hover {
            /*background-color: rgba(255,255,255,0.6);*/
            /*transition: transform .7s;*/
            /*background: linear-gradient(to right,#fce3ec,#ffe8cc);*/
            transform: scale(0.9);
            box-shadow: 0 0px 0px 0px black;
        }
    </style>

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

    <div class="bg-overlay loader_cls hidden">
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

    <div class="container-fluid py-4">

        <div class="row mt-6">
            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_MenuListMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape">
                                            <i class="fas fa-bars icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="header-text-style-BM text-muted text-sm" style="white-space:nowrap;cursor: pointer;">Menu Access</h5>
                                    </div>
                            </div>
                    </div>
                    </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_RegionMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-success ">
                                            <i class="fas fa-globe-asia icon-color" style="font-size: 2rem !important;cursor: pointer;" ></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;">Region Access</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3">
                <center>
                    <a href="Superadmin_RoleMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-danger ">
                                            <i class="fas fa-address-book icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Role</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3">
                <center>
                    <a href="Superadmin_TargetListMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-info">
                                            <i class="fas fa-bullseye icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Target Access</h5>
                                    </div>
                            </div>
                    </div>
                        </a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_CandidateStatusMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="ni ni-paper-diploma icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space: nowrap;cursor: pointer;">Candidate Status</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_CurrencyMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-coins icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space: nowrap;cursor: pointer;">Currency Access</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_DesignationMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="ni ni-delivery-fast icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="header-text-style-BM text-muted text-sm" style="white-space:nowrap;cursor: pointer;">Designation Access</h5>
                                    </div>
                            </div>
                    </div>
                        </a>
                        </center>


            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_EmploymenttypeMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-success ">
                                            <i class="far fa-address-card icon-color" style="font-size: 2rem !important;cursor: pointer;" ></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Employment Type</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3">
                <center>
                    <a href="Superadmin_JobStatusMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-danger ">
                                            <i class="ni ni-note-03 icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Job Status Access</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3">
                <center>
                    <a href="Superadmin_SkillandCertificationMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                <div class="col-auto">
                                        <div class="icon icon-shape text-info">
                                            <i class="ni ni-controller icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                    <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space: nowrap;cursor: pointer;">Skill and Certification</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
                    <a href="Superadmin_SpecilizationMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-sitemap icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Specilization Access</h5>
                                    </div>
                            </div>
                    </div></a></center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_WorkTypeMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-info-circle icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Work Type Access</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_MailIdMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-envelope-open-text icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Mail Id Access</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_LocationMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-location-arrow icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Location Access</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_LevelMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-layer-group icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Level Access</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_PriorityMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="ni ni-money-coins icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Priority Access</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_ImagesMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-images icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Image Master</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>

            <div class="col-md-6 col-lg-2 col-sm-12 mb-3 ">
                <center>
            <a href="Superadmin_QuestionMaster.aspx">
                    <div class="Column">
                            <div class="card-body text-center zm1">
                                     <div class="col-auto">
                                        <div class="icon icon-shape  text-yellow">
                                            <i class="fas fa-images icon-color" style="font-size: 2rem !important;cursor: pointer;"></i>
                                        </div>
                                    </div>
                                <div class="">
                                        <h5 class="card-title header-text-style-BM text-muted text-sm mb-0" style="white-space:nowrap;cursor: pointer;">Question Heading</h5>
                                    </div>
                            </div>
                    </div>
                </a>
                </center>
            </div>
        </div>

    </div>
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script>
        $(document).ready(function () {
            setSession("Page", "Config");
            $('#dropdownMenuButton').css('display', 'none');
            $('#lblDurationview').css('display', 'none');

            $('#li_job').css('display', 'none');
            $('#li_cand').css('display', 'none');
            $('#li_vendor').css('display', 'none');
            $('#li_user').css('display', 'block');
            $('#li_client').css('display', 'block');
            $('#li_config').css('display', 'block');


            $('#lblEmployeename').text(getSession('Name'));
            $('#lblPagetitle').text("Config Dashboard");
            $("#anchDashboard").removeClass("active");
            $("#anchUser").removeClass("active");
            $("#anchClient").removeClass("active");
            $("#anchConfig").addClass("active");

        });
    </script>

</asp:Content>
