<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Candidate_View.aspx.cs" Inherits="Recruiting_API.Candidate_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />
    <style>
        .nav-tag{
               float: right;
            background: #f8f9fa;
            border-radius: 0.75rem;
            position: relative;
            display: flex;
            flex-wrap: wrap;
            padding-left: 0;
            margin-bottom: 0;
            list-style: none;
           }

        .ratechecked {
            color: #ffc400;
        }

        .ratechecked1 {
            color: #ffc400;
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

    <div class="bg-overlay loader_cls">
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

    <div class="container-fluid">
        <div class="page-header min-height-300 border-radius-xl mt-4" style="background-image: url('../assets/img/curved-images/curved0.jpg'); background-position-y: 50%;">
            <span class="mask bg-gradient-primary opacity-6"></span>
        </div>
        <div class="card card-body blur shadow-blur mx-4 mt-n6">
            <div class="row gx-4">
                <div class="col-auto">
                    <div class="avatar avatar-xl position-relative">
                        <img src="Images/userimg.png" alt="..." class="w-100 border-radius-lg shadow-sm">
                        <a href="javascript:;" class="btn btn-sm btn-icon-only bg-gradient-light position-absolute bottom-0 end-0 mb-n2 me-n2">
                            <i class="fa fa-pen top-0" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit Profile" onclick=gotoEditCandiate();></i>
                        </a>
                    </div>
                </div>
                <div class="col-auto my-auto">
                    <div class="h-100">
                        <h5 class="mb-1"><span id="lblCandidatename">CHANDRASEKAR GOVINDARAJAN</span>
                        </h5>
                        <p class="mb-0 font-weight-bold text-sm">
                            <span id="lblLocation">Greater St. Louis</span>
                        </p>
                        <div class="col-12 pl-0" id="mgrRatingDiv" >
                            <span id='mrat_1' class="fa fa-star" ></span>
                            <span id='mrat_2' class="fa fa-star" ></span>
                            <span id='mrat_3' class="fa fa-star" ></span>
                            <span id='mrat_4' class="fa fa-star" ></span>
                            <span id='mrat_5' class="fa fa-star" ></span>
                        </div>
                    </div>
                </div>

                <div class="col-lg-6 col-md-6 my-sm-auto ms-sm-auto me-sm-0 mx-auto mt-3">
                    <div class="nav-wrapper position-relative end-0">
                        <ul class="nav-tag nav-pills nav-fill p-1 bg-transparent" role="tablist">
                            <li class="pe-5" onclick="return load_Div('div-profile')">
                                <a class="change_color mb-0 px-0 py-1" id="anchOverview" data-bs-toggle="tab" href="javascript:;" role="tab" aria-controls="overview" aria-selected="true">
                                    <span class="ms-1">Overview</span>
                                </a>
                            </li>
                            <li class="pe-5" onclick="return load_Div('div-document')">
                                <a class="mb-0 px-0 py-1" id="anchDocument" data-bs-toggle="tab" href="javascript:;" role="tab" aria-controls="teams" aria-selected="false">
                                    <span class="ms-1">Document</span>
                                </a>
                            </li>
                            <li class="pe-5" onclick="return load_Div('div-feedback')">
                                <a class="mb-0 px-0 py-1" id="anchFeedback" data-bs-toggle="tab" href="javascript:;" role="tab" aria-controls="dashboard" aria-selected="false">
                                    <span class="ms-1">Feedback</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="ms-auto my-auto mt-lg-0 mt-4">
            <div class="ms-auto my-auto">
                <div class="modal fade" id="addtojob" tabindex="-1" aria-hidden="true">
                    <div class="modal-dialog mt-lg-10">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Add to Job</h5>
                            </div>
                            <div class="col-md-12 p-3">
                                <label>Job Title</label>
                                <select id="drpJobtitle" class="form-control">
                                </select>
                            </div>
                            <div class="modal-footer mt-2">
                                <button type="button" class="btn bg-gradient-primary btn-sm" id="btnApplydur" onclick="gotocandidate();">Assign</button>
                                <button type="button" id="btnClose" class="btn bg-gradient-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <%-----Profile-----%>

    <div class="col-md-12" id="div-profile">
        <div class="container-fluid py-4">
            <div class="row">
                <div class="col-12 col-xl-4">
                    <div class="card h-100">
                        <div class="card-header pb-0 p-3">
                            <h6 class="mb-0">Candidate Information</h6>
                        </div>
                        <div class="card-body p-3">
                            <ul class="list-group">
                                <li class="list-group-item border-0 ps-0 pt-0 text-sm"><strong class="text-dark"><span>Candidate Name:</span></strong> &nbsp;<input type="hidden" id="hdncandid" /> <span id="lblCandcandidatename">Chandrasekar Govindarajan</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Mobile:</span></strong> &nbsp; <span id="lblCandmobile">314-755-4157</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Email:</span></strong> &nbsp; <span id="lblCandemail">chandru21.1@gmail.com</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Location:</span></strong> &nbsp; <span id="lblCandlocation">St. Louis, MO</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span">Visa Status:</span></strong> &nbsp; <span id="lblCandvisastatus">H1B</span></li>
                                <li class="list-group-item border-0 ps-0 pb-0">
                                    <strong class="text-dark text-sm"><span>Social:</span></strong> &nbsp;
                                    <a class="btn btn-linkedin btn-simple mb-0 ps-1 pe-2 py-0" href="javascript:;" id="imgCandlinkedin" target="_blank">
                                        <i class="fab fa-linkedin fa-lg"></i>
                                    </a>
                                </li>
                            </ul>
                            <hr class="horizontal gray-light my-4">
                            <ul class="p-0">
                                <li class="list-group-item border-0 ps-0 text-sm mb-1"><strong class="text-dark"><span>Skills and Certifications</span></strong>
                                    <div></div>
                                    <p id="lblSkillscertification">Test | GCP Engineer | GCS | Google Cloud Professional Architect certified</p>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-xl-4">
                    <div class="card h-100">
                        <div class="card-header pb-0 p-3">
                            <div class="row">
                                <div class="col-md-12 d-flex align-items-center">
                                    <h6 class="mb-0">Employer Information</h6>
                                </div>
                            </div>
                        </div>
                        <div class="card-body p-3">
                            <ul class="list-group">
                                <li class="list-group-item border-0 ps-0 pt-0 text-sm"><strong class="text-dark"><span>Employer Name:</span></strong> &nbsp; <span id="lblEmpemployername">Subash Kumar</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Mobile:</span></strong> &nbsp; <span id="lblEmpmobile">646-809-9730</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Email:</span></strong> &nbsp; <span id="lblEmpemail">subashk@ilinesoft.com</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Corporation:</span></strong> &nbsp; <span id="lblEmpcorporation">Glenysys Technologies Inc</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Additional Information:</span></strong> &nbsp; <span id="lblEmpAddedinfo">USA</span></li>
                                <li class="list-group-item border-0 ps-0 text-sm"><strong class="text-dark"><span>Location:</span></strong> &nbsp; <span id="lblEmplocation">USA</span></li>
                                
                            </ul>
                            <hr class="horizontal gray-light my-4">
                            <ul class="list-group">
                            <li class="list-group-item border-0 ps-0 text-sm mb-1"><strong class="text-dark">Specialization</strong>
                                <p id="lblEmpspecialization">Salesforce | SAP | JAVA</p>
                            </li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class="col-12 col-xl-4">
                    <div class="card h-100">
                        <div class="card-header pb-0 p-3">
                            <h6 class="mb-0">Recommended Jobs</h6>
                        </div>
                        <div class="card-body p-3" id="div-matchjobs" style="overflow: scroll;overflow-x: hidden;height: 100px;">
                            <ul class='list-group'><li class='list-group-item border-0 d-flex align-items-center px-0 mb-2'><div class='avatar me-3'><img src='Images/Sap_logo.png' class='avatar avatar-sm me-3'></div><div class='d-flex align-items-start flex-column justify-content-center'><div class='d-flex flex-column justify-content-center'><label class='mb-0 text-sm h6' id='lblJobname'>SAP ABAP Developer</label><label class='mb-0'><label class='text-xs' id='lblJobmonth'>6 Months</label>|<label class='text-xs' id='lblJobcontract'>Part Time</label>|<label class='text-xs' id='lblJobcity'>Atlanta,Georgia</label></label></div></div><a class='btn btn-link pe-3 ps-0 mb-0 ms-auto' href='javascript:;'>Apply</a></li></ul>
                        </div>
                    </div>
                </div>
                <div class="col-12 mt-4">
                    <div class="card mb-4">
                        <div class="card-header pb-0 p-3">
                            <h6 class="mb-1">Committed Jobs</h6>
                            <p class="text-sm">Candidate submitted to</p>
                        </div>
                        <div class="card-body p-3" id="div_committed">
                            
                        </div>
                    </div>
                </div>
            </div>
        </div>


        
    </div>


    <%-----Document-----%>

    <div class="col-md-12" id="div-document" style="display: none;">

        <div class="card card-body d-flex" id="div_proof" style="background:transparent;box-shadow:none !important;">
                <div class="card-body d-flex">
                    <div class="col-md-3 text-center">
                        <a href="javascript:;" class="avatar avatar-lg rounded-circle border border-success">
                            <img alt="Image placeholder" class="p-1" src="assets/img/Resume.png">
                        </a>
                        <p class="mb-0 text-sm"><span>Resume</span></p>
                    </div>
                    <div class="col-md-3 text-center">
                        <a href="javascript:;" class="avatar avatar-lg rounded-circle border border-success">
                            <img alt="Image placeholder" class="p-1" src="assets/img/ID.png">
                        </a>
                        <p class="mb-0 text-sm"><span>ID Proof</span></p>
                    </div>
                    <div class="col-md-3 text-center">
                        <a href="javascript:;" class="avatar avatar-lg rounded-circle border border-secondary">
                            <img alt="Image placeholder" class="p-1" src="assets/img/Visa.png">
                        </a>
                        <p class="mb-0 text-sm"><span>Visa</span></p>
                    </div>
                </div>
            </div>

        <div class="container-fluid py-4">
            <div class="container-fluid py-2">
                <div class="row">
                    <div class="col-lg-12 mx-auto">
                        <div class="card mb-4">
                            <div class="card-header p-5 pb-0">
                                <div class="d-flex justify-content-between align-items-center">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>


    <%-----Feedback-----%>

    <div class="col-md-12" id="div-feedback" style="display: none;">
        <div class="col-lg-11 mx-auto">
            <div class="row mt-4">
                <div class="col-lg-3 mb-lg-0 mb-4">
                    <div>
                        <div class="card-body p-3">
                            <div class="row">
                                <div>
                                    <div class="d-flex flex-column h-100">
                                        <div class="card h-100">

                                            <div class="card-body pb-0 p-4">
                                                <ul class="list-group">
                                                    <li class="list-group-item border-0 d-flex align-items-center px-0 mb-0">
                                                        <div class="w-100">
                                                            <div class="d-flex mb-2">
                                                                <span class="me-2 text-sm font-weight-bold text-capitalize">Positive Rating</span>
                                                                <span class="ms-auto text-sm font-weight-bold" id="lblPositive">80%</span>
                                                            </div>
                                                            <div>
                                                                <div class="progress progress-md">
                                                                    <div class="progress-bar bg-gradient-info" role="progressbar" id="div_positive" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                    <li class="list-group-item border-0 d-flex align-items-center px-0 mb-2 p-4">
                                                        <div class="w-100">
                                                            <div class="d-flex mb-2">
                                                                <span class="me-2 text-sm font-weight-bold text-capitalize">Negative Rating</span>
                                                                <span class="ms-auto text-sm font-weight-bold" id="lblNegative">3%</span>
                                                            </div>
                                                            <div>
                                                                <div class="progress progress-md">
                                                                    <div class="progress-bar bg-gradient-danger" role="progressbar" id="div_negative" aria-valuenow="5" aria-valuemin="0" aria-valuemax="100"></div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5 ms-auto text-center mt-5 mt-lg-0">
                                <div class="bg-gradient-primary border-radius-lg h-100">
                                    <%--<img src="assets/img/shapes/waves-white.svg" class="position-absolute h-100 w-50 top-0 d-lg-block d-none" alt="waves"/>--%>
                                    <div class="position-relative d-flex align-items-center justify-content-center h-100">
                                        <label class="h2 head-tag text-white" id="lblResumesonhold"></label>
                                        <%--<img class="w-100 position-relative z-index-2 pt-4" src="../assets/img/illustrations/rocket-white.png">--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="col-lg-9">
                    <div class="h-100 p-3">
                        <div class="container-fluid py-4">
                            <div id="div_assignjob">
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid py-2" id="div_candfeedback" style="display: none">
        <div class="row">
            <div class="col-lg-12 mx-auto">
                <div class="card mb-4">
                    <div class="card-header p-5 pb-0">
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <h6>Feedback Details</h6>
                            </div>
                        </div>
                        <div class="card-body p-3 pt-0">

                            <div class="row mt-4">
                                <div class="col-lg-6 col-md-6 col-12">
                                    <div class="d-flex">
                                        <div>
                                            <img src="Images/Sap.png" class="avatar avatar-xxl me-3" alt="product image" id="lblJobImage">
                                        </div>
                                        <div>
                                            <input type="hidden" id="hdnjobid" />
                                            <input type="hidden" id="hdncommid" />
                                            <input type="hidden" id="hdncanstatus" />
                                            <label style="margin-bottom: -7px;"><span class="mb-0 text-sm h6" id="lblJobtitle"></span></label>
                                            <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblJobduration"></span> | <span class="text-xs text-secondary mb-0" id="lblType"></span> | <span class="text-xs text-secondary mb-0" id="lblWorkingtype"></span></p>
                                        </div>
                                    </div>
                                    <p class="text-sm mb-3 mt-2">Created By <span id="lblCreateby"></span> | <span id="lblCreateon"></span> - <span id="lblCreatetime"></span> EST</p>
                                </div>
                                <div class="col-lg-6 col-md-6 col-12 my-auto text-end">
                                    <a href="javascript:;"><span class="badge badge-sm bg-gradient-success" style="cursor: not-allowed;padding:10px;" id="lblStatus"></span></a>
                                    <h6 class="text-lg mb-0 mt-2">
                                        <img src="Images/us-dollar.png" width="15" height="15" /><span id="lblRate"></span>/Hr on <span id="lblType2"></span></h6>
                                    <%--<p class="text-sm mt-3 mb-0">Are you waiting for feedback? Click <a href="javascript:;">here</a>.</p>--%>
                                </div>
                            </div>
                            <hr class="horizontal dark mt-4 mb-4">
                            <div class="row">
                                <div class="col-lg-3 col-md-6 col-12">
                                    <h6 class="mb-3">Track Profile</h6>
                                    <div class="timeline timeline-one-side">
                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-like-2 text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">EC Feedback</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_ECname" style="display: none;"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_ECcommdate" style="display: none;"></p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">EC Interview</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_ECIname" style="display: none;"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_ECIcommdate" style="display: none;"></p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">BP Feedback</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_BPname" style="display: none;"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_BPcommdate" style="display: none;"></p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">BP Interview</h6>
                                                <p class="text-success font-weight-bold text-xs mt-1 mb-0" id="p_BPIname" style="display: none;"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_BPIcommdate" style="display: none;"></p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-circle-08 text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">TL Feedback</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_Teamleadname" style="display: none;"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_TLcommdate" style="display: none;"></p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-single-copy-04 text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">Submitted</h6>
                                                <p class="text-success font-weight-bold text-xs mt-1 mb-0" id="p_Recruitername"></p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_Reccommdate"></p>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="col-lg-5 col-md-6 col-12">
                                    <%--<div class="col-md-12 mt-3" id="div_Closure" style="display:none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">Closure</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblClosure"></span></p>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                             
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-12">
                                                    <textarea name="txtDec" rows="2" cols="20" id="txtClosure" class="form-control text-font font_size" placeholder="Closure Comments" style="height: 100px;"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Created on <br /> <span id="lblClousurecreatedondate">01 Jun 2021</span> | <span id="lblClousurecreatedtime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on <br /> <span id="lblClousureupdatedondate">01 Jun 2021</span> | <span id="lblClousureupdatedtime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>--%>

                                    <div class="col-md-12 mt-4" id="div_EC" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">EC Feedback</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    
                                                </div>
                                                
                                                <div class="col-md-12">
                                                    <textarea name="txtDec" rows="2" cols="20" id="txtECComments" class="form-control text-font font_size" placeholder="EC Feedback" disabled="disabled" style="height: 100px;"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Created on
                                                        <br />
                                                        <span id="lblEccreatedondate"></span> | <span id="lblECscreatedontime"></span> </p>
                                                </div>
                                                <div class="col-6 text-right" id="div_ECupdatedon" style="display:none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblECupdatedondate"></span> | <span id="lblEcupdatedontime"></span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_ECI" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">EC Interview</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    
                                                </div>
                                                
                                                <div class="col-md-12">
                                                    <div class="row" style="margin-top: -20px;">
                                                        <div class="col-md-6">
                                                            <label class="">Interview Date</label>
                                                            <input class="form-control" type="date" id="txtdateec" disabled="disabled" />
                                                        </div>
                                                        <div class="col-md-6">
                                                            <label class="">Interview Time</label>
                                                            <input class="form-control" type="time" id="txtTimeec" disabled="disabled" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Created on
                                                        <br />
                                                        <span id="lblEcintcreatedondate"></span> | <span id="lblEcintcreatedontime"></span> </p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblEcintupdatedondate"></span> | <span id="lblEcintpdatedontime"></span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_BP" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">BP Feedback</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    
                                                </div>
                                                
                                                <div class="col-md-12">
                                                    <textarea name="txtDec" rows="2" cols="20" id="txtBPComments" class="form-control text-font font_size" placeholder="BP Feedback" style="height: 100px;" disabled="disabled"></textarea>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPcre" style="display: none;">Created on
                                                        <br />
                                                        <span id="lblBpcreatedondate"></span> | <span id="lblBpscreatedontime"></span> </p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPupd" style="display: none;">Updated on
                                                        <br />
                                                        <span id="lblBpupdatedondate"></span> | <span id="lblBpupdatedontime"></span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_BPI" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">BP Interview</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    
                                                </div>
                                                
                                                <div class="col-md-12">
                                                    <div class="row" style="margin-top: -20px;">
                                                        <div class="col-md-6">
                                                            <label class="">Interview Date</label>
                                                            <input class="form-control" type="date" id="txtBIDate" disabled="disabled" />
                                                        </div>
                                                        <div class="col-md-6">
                                                            <label class="">Interview Time</label>
                                                            <input class="form-control" type="time" id="txtBITime" disabled="disabled" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPIcre" style="display: none;">Created on
                                                        <br />
                                                        <span id="lblBpintcreatedondate"></span> | <span id="lblBpintscreatedontime"></span> </p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPIupd" style="display: none;">Updated on
                                                        <br />
                                                        <span id="lblBpintupdatedondate"></span> | <span id="lblBpintupdatedontime"></span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_TL" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <h6 class="mb-3">TL Comments</h6>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblTlcomments"></span></p>
                                                        </div>
                                                        <%--<div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                                <input class="form-check-input" type="checkbox" name="chkTlcomments" onclick="getstatusfeedback('chkTlcomments', 'lblTlcomments', 'txtTLComments')">
                                                                <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                                            </div>
                                                        </div>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-top: -20px;">
                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-12 pl-0" id="mgr_RatingDiv">
                                                            <span id='mgrrat_1' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mgrrat_2' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mgrrat_3' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mgrrat_4' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mgrrat_5' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id="TLRating"></span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 text-right">
                                                    <button id="btnTLComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;" onclick="enableControl('txtTLComments','');">
                                                        <i class="fas fa-pencil-alt"></i>
                                                    </button>
                                                </div>--%>
                                            </div>
                                            <div class="col-md-12">
                                                <textarea name="txtDec" rows="2" cols="20" id="txtTLComments" class="form-control text-font font_size" placeholder="TL Comments" style="height: 100px;" disabled="disabled"></textarea>
                                            </div>
                                        </div>

                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left" id="div_TLcre" style="display: none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Created on
                                                        <br />
                                                        <span id="lblTlcommentscreatedondate">01 Jun 2021</span> | <span id="lblTlcommentscreatedontime">06.15 PM</span> </p>
                                                </div>
                                                <div class="col-6 text-right" id="div_TLupd" style="display: none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblTlcommentsupdatedondate">01 Jun 2021</span> | <span id="lblTlcommentsupdatedontime">06.15 PM</span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <h6 class="mb-3">Recruiter Remarks</h6>
                                            </div>
                                            <div class="col-md-6 text-right">
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: -20px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-12 pl-0" id="RecRatingDiv">
                                                        <span id='recrat_1' class="fa fa-star"></span>
                                                        <span id='recrat_2' class="fa fa-star"></span>
                                                        <span id='recrat_3' class="fa fa-star"></span>
                                                        <span id='recrat_4' class="fa fa-star"></span>
                                                        <span id='recrat_5' class="fa fa-star"></span>
                                                        <%--<span id="starRecRating"></span>--%>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 text-right">
                                            </div>
                                        </div>

                                        <div class="col-md-12">
                                            <textarea name="txtDec" rows="2" cols="20" id="txtRecComments" class="form-control text-font font_size" placeholder="Recrutier Remarks" style="height: 100px;" disabled="disabled"></textarea>
                                        </div>
                                        <div class="col-md-12 mt-2">
                                            <div class="row">
                                                <div class="col-6 text-left">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Created on
                                                        <br />
                                                        <span id="lblRecrutiercreatedate">01 Jun 2021</span> | <span id="lblRecrutiercreatedontime">06.15 PM</span> </p>
                                                </div>
                                                <div class="col-6 text-right" id="div_Recupd" style="display: none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblRecrutierupdatedondate">01 Jun 2021</span> | <span id="lblRecrutierupdatedontime">06.15 PM</span> </p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <%--<div class="col-md-12 mt-3">
                                        <div class="row">
                                            <div class="col-md-6 text-left">
                                                <button type="button" id="btnCancel" class="btn bg-gradient-secondary btn-resize">Cancel</button>
                                            </div>
                                            <div class="col-md-6 text-right">
                                                <button type="button" id="btnSave" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" data-bs-target="#msgpopup" onclick="saveCandComments();">Save</button>
                                            </div>
                                        </div>
                                    </div>--%>


                                    <div class="ms-auto my-auto mt-lg-0 mt-4">
                                        <div class="ms-auto my-auto">
                                            <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                                                <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                                                    <div class="modal-content">

                                                        <div class="col-md-12 mt-3 text-center">
                                                            <p class="mb-0 h6"><span>Feedback Saved Succesfully</span></p>
                                                        </div>

                                                        <div class="modal-footer pt-0 text-center" style="border-top: none;">
                                                            <div class="col-md-12">
                                                                <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk" onclick="closepopop()">Ok</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
        

    </div>

    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/CandidateProfile.js"></script>

    <script>
        $("#drpJobtitle").select2();

        function load_Div(tar_div) {

            if (tar_div == "div-profile") {
                $("#anchOverview").addClass("change_color");
                $("#anchDocument").removeClass("change_color");
                $("#anchFeedback").removeClass("change_color");

                document.getElementById("div-profile").style.display = "block";
                document.getElementById("div-document").style.display = "none";
                document.getElementById("div-feedback").style.display = "none";
            }
            else if (tar_div == "div-document") {
                $("#anchOverview").removeClass("change_color");
                $("#anchDocument").addClass("change_color");
                $("#anchFeedback").removeClass("change_color");

                document.getElementById("div-profile").style.display = "none";
                document.getElementById("div-document").style.display = "block";
                document.getElementById("div-feedback").style.display = "none";
            }
            else if (tar_div == "div-feedback") {
                $("#anchOverview").removeClass("change_color");
                $("#anchDocument").removeClass("change_color");
                $("#anchFeedback").addClass("change_color");

                document.getElementById("div-profile").style.display = "none";
                document.getElementById("div-document").style.display = "none";
                document.getElementById("div-feedback").style.display = "block";
            }

        }
    </script>

</asp:Content>