<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Feedback.aspx.cs" Inherits="Recruiting_API.Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />

    <style>
        .nav{
               float: right;
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
                            <i class="fa fa-pen top-0" data-bs-toggle="tooltip" data-bs-placement="top" title="Edit Profile"></i>
                        </a>
                    </div>
                </div>
                <div class="col-auto my-auto">
                    <div class="h-100">
                        <h5 class="mb-1"><span id="lblCandidatename">CHANDRASEKAR GOVINDARAJAN</span><input type="hidden" id="hdncandid" />
                        </h5>
                        <p class="mb-0 font-weight-bold text-sm">
                            <span id="lblLocation">Greater St. Louis</span>
                        </p>
                        <%-- <div class="col-12 pl-0" id="mgrRatingDiv" >
                            <span id='mrat_1' class="fa fa-star" ></span>
                            <span id='mrat_2' class="fa fa-star" ></span>
                            <span id='mrat_3' class="fa fa-star" ></span>
                            <span id='mrat_4' class="fa fa-star" ></span>
                            <span id='mrat_5' class="fa fa-star" ></span>
                        </div>--%>
                    </div>
                </div>
                <div class="col-lg-2 col-md-6 my-sm-auto ms-sm-auto me-sm-0 mx-auto mt-3">
                    <div class="nav-wrapper position-relative end-0">
                        <ul class="nav nav-pills nav-fill p-1 bg-transparent" role="tablist">
                            <li class="pe-5">
                                <a class="change_color mb-0 px-0 py-1 active" data-bs-toggle="tab" href="javascript:;" role="tab" aria-controls="dashboard" aria-selected="false">
                                    <span class="ms-1">Feedback</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>

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
                                                                <div class="progress-bar bg-gradient-info" id="div_positive" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
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
                                                                <div class="progress-bar bg-gradient-danger" id="div_negative" role="progressbar" aria-valuenow="5" aria-valuemin="0" aria-valuemax="100"></div>
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
                                <%--<img src="assets/img/shapes/waves-white.svg" class="position-absolute h-100 w-50 top-0 d-lg-block d-none" alt="waves">--%>
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
                                    <a href="javascript:;" class=""><span class="badge badge-sm bg-gradient-success" id="lblStatus" style="padding: 10px;cursor: not-allowed;"></span></a>
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
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_ECname" style="display: none;">Rejected By Cognizant</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_ECcommdate" style="display: none;">25 JUN 2021 | 10:13PM IST</p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">EC Interview</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_ECIname" style="display: none;">Scheduled</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_ECIcommdate" style="display: none;">28 JUN 2021 | 03:00PM EST</p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">BP Feedback</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_BPname" style="display: none;">Rejected By Cognizant</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_BPcommdate" style="display: none;">25 JUN 2021 | 10:13PM IST</p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-paper-diploma text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">BP Interview</h6>
                                                <p class="text-success font-weight-bold text-xs mt-1 mb-0" id="p_BPIname" style="display: none;">Scheduled</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_BPIcommdate" style="display: none;">28 JUN 2021 | 03:00PM EST</p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-circle-08 text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">TL Feedback</h6>
                                                <p class="font-weight-bold text-xs mt-1 mb-0" id="p_Teamleadname" style="display: none;">Approved By Mohan</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_TLcommdate" style="display: none;">25 JUN 2021 | 6:13PM IST</p>
                                            </div>
                                        </div>

                                        <div class="timeline-block mb-3">
                                            <span class="timeline-step">
                                                <i class="ni ni-single-copy-04 text-secondary"></i>
                                            </span>
                                            <div class="timeline-content">
                                                <h6 class="text-dark text-sm font-weight-bold mb-0">Submitted</h6>
                                                <p class="text-success font-weight-bold text-xs mt-1 mb-0" id="p_Recruitername">By Rexaline</p>
                                                <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="p_Reccommdate">22 JUN 2021 | 7:20PM IST</p>
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
                                                <div class="row">
                                                <div class="col-md-5">
                                                    <h6 class="mb-3">EC Comments</h6>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault5" id="radECApp" onclick="getstatusfeedback('radECApp', 'txtECComments')">
                                                              <label class="custom-control-label" style="color:green" for="customRadio2">Approve</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault5" id="radECRej" onclick="getstatusfeedback('radECRej', 'txtECComments')">
                                                              <label class="custom-control-label text-danger" for="customRadio2">Reject</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblTlcomments"></span></p>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                                <input class="form-check-input" type="checkbox" name="chkTlcomments" onclick="getstatusfeedback('chkTlcomments', 'lblTlcomments', 'txtTLComments')">
                                                                <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6">

                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button id="btnECComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;display:none;float:right;" onclick="enableControl('txtECComments','','radECApp','radECRej');">
                                                                <i class="fas fa-pencil-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
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
                                                        <span id="lblEccreatedondate">01 Jun 2021</span> | <span id="lblECscreatedontime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblECupdatedondate">01 Jun 2021</span> | <span id="lblEcupdatedontime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_ECI" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <h6 class="mb-3">EC Interview</h6>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault4" id="radECIApp" onclick="getstatus('radECIApp', 'txtdateec', 'txtTimeec')">
                                                              <label class="custom-control-label" style="color:green" for="customRadio2">Scheduled</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault4" id="radECIRej" onclick="getstatus('radECIRej', 'txtdateec', 'txtTimeec')">
                                                              <label class="custom-control-label text-danger" for="customRadio2">Not Scheduled</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6">

                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button id="btnECIComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;display:none;float:right;" onclick="enableControl('txtdateec','txtTimeec','radECIApp','radECIRej');">
                                                                <i class="fas fa-pencil-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
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
                                                        <span id="lblEcintcreatedondate">01 Jun 2021</span> | <span id="lblEcintcreatedontime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblEcintupdatedondate">01 Jun 2021</span> | <span id="lblEcintpdatedontime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_BP" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="row">
                                                <div class="col-md-5">
                                                    <h6 class="mb-3">BP Comments</h6>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="chkBpfeedback" id="radBPApp" onclick="getstatusfeedback('radBPApp', 'txtBPComments')">
                                                              <label class="custom-control-label" style="color:green" for="customRadio2">Approve</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="chkBpfeedback" id="radBPRej" onclick="getstatusfeedback('radBPRej', 'txtBPComments')">
                                                              <label class="custom-control-label text-danger" for="customRadio2">Reject</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblTlcomments"></span></p>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                                <input class="form-check-input" type="checkbox" name="chkTlcomments" onclick="getstatusfeedback('chkTlcomments', 'lblTlcomments', 'txtTLComments')">
                                                                <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>
                                            
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6">

                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button id="btnBPComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;display:none;float:right;" onclick="enableControl('txtBPComments','','radBPApp','radBPRej');">
                                                                <i class="fas fa-pencil-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
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
                                                        <span id="lblBpcreatedondate">01 Jun 2021</span> | <span id="lblBpscreatedontime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPupd" style="display: none;">Updated on
                                                        <br />
                                                        <span id="lblBpupdatedondate">01 Jun 2021</span> | <span id="lblBpupdatedontime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_BPI" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <h6 class="mb-3">BP Interview</h6>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault2" id="radBPIApp" onclick="getstatus('radBPIApp', 'txtBIDate', 'txtBITime')">
                                                              <label class="custom-control-label" style="color:green" for="customRadio2">Scheduled</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault2" id="radBPIRej" onclick="getstatus('radBPIRej', 'txtBIDate', 'txtBITime')">
                                                              <label class="custom-control-label text-danger" for="customRadio2">Not Scheduled</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblBpinterview"></span></p>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                                <input class="form-check-input" type="checkbox" name="chkBpinterview" onclick="getstatus('chkBpinterview', 'lblBpinterview', 'txtBIDate', 'txtBITime')">
                                                                <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6">

                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button id="btnBPIComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;display:none;float:right;" onclick="enableControl('txtBIDate','txtBITime','radBPIApp','radBPIRej');">
                                                                <i class="fas fa-pencil-alt"></i>
                                                            </button>
                                                        </div>
                                                    </div>
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
                                                        <span id="lblBpintcreatedondate">01 Jun 2021</span> | <span id="lblBpintscreatedontime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0" id="div_BPIupd" style="display: none;">Updated on
                                                        <br />
                                                        <span id="lblBpintupdatedondate">01 Jun 2021</span> | <span id="lblBpintupdatedontime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4" id="div_TL" style="display: none;">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <h6 class="mb-3">TL Comments</h6>
                                                </div>
                                                <div class="col-md-7">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault1" id="radTLApp" onclick="getstatusfeedback('radTLApp', 'txtTLComments')">
                                                              <label class="custom-control-label" style="color:green" for="customRadio2">Approve</label>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-check">
                                                              <input class="form-check-input" type="radio" name="flexRadioDefault1" id="radTLRej" onclick="getstatusfeedback('radTLRej', 'txtTLComments')">
                                                              <label class="custom-control-label text-danger" for="customRadio2">Reject</label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <%--<div class="col-md-6 text-right">
                                                    <div class="row">
                                                        <div class="col-md-8 text-right">
                                                            <p><span id="lblTlcomments"></span></p>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-check form-switch">
                                                                <input class="form-check-input" type="checkbox" name="chkTlcomments" onclick="getstatusfeedback('chkTlcomments', 'lblTlcomments', 'txtTLComments')">
                                                                <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>--%>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="row">
                                                        <div class="col-12 pl-0" id="mgrRatingDiv">
                                                            <span id='mrat_1' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mrat_2' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mrat_3' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mrat_4' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id='mrat_5' class="fa fa-star" onclick="rateUser(this);"></span>
                                                            <span id="TLRating"></span>&nbsp;
                                                            <label id="lblRatingvali" style="color:red; display:none;">Select Rating</label>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-6 text-right">
                                                    <button id="btnTLComm" data-bs-dismiss="alert" aria-label="Close" class="btn bg-gradient-warning p-0 mb-0" type="button" style="background: none !important; box-shadow: none !important; color: #75e6fc; font-size:20px;display:none;float:right;" onclick="enableControl('txtTLComments','','radTLApp','radTLRej');">
                                                        <i class="fas fa-pencil-alt"></i>
                                                    </button>
                                                </div>
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
                                                        <span id="lblTlcommentscreatedondate">01 Jun 2021</span> | <span id="lblTlcommentscreatedontime">06.15 PM</span> IST</p>
                                                </div>
                                                <div class="col-6 text-right" id="div_TLupd" style="display: none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblTlcommentsupdatedondate">01 Jun 2021</span> | <span id="lblTlcommentsupdatedontime">06.15 PM</span> IST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-4">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <h6 class="mb-3">Recrutier Remarks</h6>
                                            </div>
                                            <div class="col-md-6 text-right">
                                            </div>
                                        </div>
                                        <div class="row" style="margin-top: -20px;">
                                            <div class="col-md-6">
                                                <div class="row">
                                                    <div class="col-12 pl-0" id="RecRatingDiv">
                                                        <span id='mrrat_1' class="fa fa-star"></span>
                                                        <span id='mrrat_2' class="fa fa-star"></span>
                                                        <span id='mrrat_3' class="fa fa-star"></span>
                                                        <span id='mrrat_4' class="fa fa-star"></span>
                                                        <span id='mrrat_5' class="fa fa-star"></span>
                                                        <span id="starRecRating"></span>
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
                                                        <span id="lblRecrutiercreatedate">01 Jun 2021</span> | <span id="lblRecrutiercreatedontime">06.15 PM</span> EST</p>
                                                </div>
                                                <div class="col-6 text-right" id="div_Recupd" style="display: none;">
                                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0">Updated on
                                                        <br />
                                                        <span id="lblRecrutierupdatedondate">01 Jun 2021</span> | <span id="lblRecrutierupdatedontime">06.15 PM</span> EST</p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-md-12 mt-3">
                                        <div class="row">
                                            <div class="col-md-6 text-left">
                                                <button type="button" id="btnCancel" class="btn bg-gradient-secondary btn-resize">Cancel</button>
                                            </div>
                                            <div class="col-md-6 text-right">
                                                <button type="button" id="btnSave" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" data-bs-target="#" onclick="saveCandComments();">Save</button>
                                            </div>
                                        </div>
                                    </div>


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
    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Feedback.js"></script>

    <script>
        function closepopop(){
            $("#msgpopup").modal('hide');
            location.reload();
        }

        function getstatus(chkname, txt1, txt2) {

            if ($("#" + chkname).is(":checked") == true && chkname.includes("App")) {
                
                $('#' + txt1).prop('disabled', false);
                $('#' + txt2).prop('disabled', false);
                
            }
            else {
                
                $('#' + txt1).prop('disabled', true);
                $('#' + txt2).prop('disabled', true);
                if (chkname.includes("BPI")) {
                    // $('#div_BPI').css('display', 'none');
                    $('#div_BP').css('display', 'block');
                }
                else if (chkname.includes("ECI")) {
                    // $('#div_BPI').css('display', 'none');
                    $('#div_EC').css('display', 'block');
                }
            }

            return false;
        }

        function getstatusfeedback(chkname, txtarea) {
            if ($("#" + chkname).is(":checked") == true) {
                $('#' + txtarea).prop('disabled', false);
            }
            else {
                $('#' + txtarea).prop('disabled', true);
            }

            return false;
        }

        function enableControl(txtarea1, txtarea2,rad1,rad2) {
            var isDisabled = $('#' + txtarea1).prop('disabled');
            if (isDisabled == true) {
                $('#' + txtarea1).prop('disabled', false);
                $('#' + rad1).prop('disabled', false);
                $('#' + rad2).prop('disabled', false);
            }
            else {
                $('#' + txtarea1).prop('disabled', true);
                $('#' + rad1).prop('disabled', true);
                $('#' + rad2).prop('disabled', true);
            }
            if (txtarea2 != "") {
                var isDisabled2 = $('#' + txtarea2).prop('disabled');
                if (isDisabled2 == true) {
                    $('#' + txtarea2).prop('disabled', false);
                }
                else {
                    $('#' + txtarea2).prop('disabled', true);
                }
            }
        }

    </script>

</asp:Content>