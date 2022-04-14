<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="WebForm3.aspx.cs" Inherits="Recruiting_API.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="assets/css/Common.css" rel="stylesheet" />
    <script src="assets/js/plugins/chartjs.min.js"></script>
    <script src="assets/js/plugins/Chart.extension.js"></script>


    <div class="container-fluid py-4 hidden">

        <%--<div class="bg-overlay loader_cls">
            <section class="fullscreen">
                <div class="container-fullwidth">
                    <div class="row justify-content-center p-60">
                        <div class="col-md-12 text-center">
                            <img class="h-100 w-100" src="Images/loader.gif" id="imgLoader" />
                        </div>
                    </div>
                </div>
            </section>
        </div>--%>

        <div class="container-fluid p-0 mb-4">
            <div class="row align-items-center">
                <div class="col-lg-10 col-sm-8">
                    <div class="nav-wrapper position-relative end-0">
                        <ul class="nav nav-pills nav-fill p-1" role="tablist">
                            <li class="pe-5" onclick="#" style="cursor: pointer;">
                                <a class="change_color mb-0 px-0 py-1 " id="anchGivefeedback" data-bs-toggle="tab" role="tab" aria-selected="false">My Feedback
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-12" id="div_week_feedback">
            <div class="row">
                <div class="col-md-4">
                    <label>Select Month</label><span style="color: red;">*</span>
                    <input class="form-control form-controlnew datepicker" type="text" id="txtFeedbackdatefb" style="background-color:white !important" placeholder="Start Date" onchange="openCalendarData('Givefeedback');" />
                    <input type="hidden" id="hdnfirstday" />
                    <input type="hidden" id="hdnlastday" />
                    <input type="hidden" id="hdnchartdate" />
                    <div>
                        <h5 class="mt-3"><span id="lblPerformancetitlefb" style="display: none;">Select Week for the choosen Month</span></h5>
                    </div>

                </div>

                <%--<div class="col-md-8">
                    <button type="button" id="btnGetfb" class="btn bg-gradient-success mt-5 btn-resize" onclick="">Get Week</button>
                    <button type="button" id="btnClearfb" class="btn bg-gradient-secondary mt-5 btn-resize" onclick="">Clear</button>
                </div>--%>                
            </div>

            <div class="row" id="div_week_infofeed" style="display: none;">
                <div class="col-md-2">
                    <button class="btn btn-icon  btn-outline-secondary p-2" id="btnfbWeek1" type="button" onclick="getTargetData('#lblWeek11','#hdnWeek11');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek11"></span>
                    </button>
                    <input type="hidden" id="hdnWeek11" />
                </div>
                <div class="col-md-2">
                    <button class="btn btn-icon btn-outline-secondary p-2" id="btnfbWeek2" type="button" onclick="getTargetData('#lblWeek21','#hdnWeek21');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek21"></span>
                    </button>
                    <input type="hidden" id="hdnWeek21" />
                </div>
                <div class="col-md-2">
                    <button class="btn btn-icon btn-outline-secondary p-2" id="btnfbWeek3" type="button" onclick="getTargetData('#lblWeek31','#hdnWeek31');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek31"></span>
                    </button>
                    <input type="hidden" id="hdnWeek31" />
                </div>
                <div class="col-md-2">
                    <button class="btn btn-icon btn-outline-secondary p-2" id="btnfbWeek4" type="button" onclick="getTargetData('#lblWeek41','#hdnWeek41');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek41"></span>
                    </button>
                    <input type="hidden" id="hdnWeek41" />
                </div>
                <div class="col-md-2">
                    <button class="btn btn-icon btn-outline-secondary p-2" id="btnfbWeek5" type="button" onclick="getTargetData('#lblWeek51','#hdnWeek51');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek51"></span>
                    </button>
                    <input type="hidden" id="hdnWeek51" />
                </div>

                <div class="col-md-2" id="div_week61" style="display:none;">
                    <button class="btn btn-icon btn-outline-secondary p-2" id="btnfbWeek6" type="button" onclick="getTargetData('#lblWeek61','#hdnWeek61');">
                        <span class="btn-inner--icon"><i class="far fa-calendar-alt me-2"></i></span>
                        <span class="btn-inner--text" id="lblWeek61"></span>
                    </button>
                    <input type="hidden" id="hdnWeek61" />
                </div>
            </div>
        </div>

        <div class="col-md-12 mt-5" id="div_feedback">
            <div class="row">
                <div class="col-md-4" id="div_mgrfeedbackperfchart" style="display:none;">
                    <div class="col-md-12 text-center card p-3" style="height:341px;">
                        <div class="card-header pb-0 p-3">
                            <div class="d-flex justify-content-between">
                                <h6 class="mb-0">Performance Indicator</h6>
                                <%--<button type="button" class="btn btn-icon-only btn-rounded btn-outline-secondary mb-0 ms-2 btn-sm d-flex align-items-center justify-content-center" data-bs-toggle="tooltip" data-bs-placement="bottom" title="" data-bs-original-title="See traffic channels">
                                    <i class="fas fa-info" aria-hidden="true"></i>
                                </button>--%>
                            </div>
                        </div>
                        <div class="card-body p-3">
                          <div class="row">
                            <div class="col-12 text-center">
                              <div class="chart">
                                <canvas id="chart-consumption" class="chart-canvas" height="246" width="275" style="display: block; box-sizing: border-box; height: 197px; width: 220.6px;"></canvas>
                              </div>
                              <h4 class="font-weight-bold mt-n8">
                                <span id="lblPerformaceVal">Average</span>
<%--                                <span class="d-block text-body text-sm">WATTS</span>--%>
                              </h4>
                            </div>
                          </div>
                        </div>
                    </div>

                    <div class="col-md-12 mt-3" id="div_mgrfeedbackperf" style="display: none;">
                        <div class="card h-100">
                            <div class="card-header pb-0">
                                <h6>
                                    <label class="h6" id="lblTeammemberfb"></label>
                                    Performance overview-System generated</h6>
                                <p class="text-sm">
                                    <i id="icon_overviewfb" aria-hidden="true"></i>
                                    <span class="font-weight-bold" id="lblPerformanceValfb">4%</span><%-- <span id="lblPerformance">this month</span>--%>
                                </p>
                            </div>
                            <div class="card-body p-3">
                                <div class="timeline timeline-one-side">
                                    <div class="timeline-block mb-3">
                                        <span class="timeline-step">
                                            <i class="ni ni-like-2 text-success text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblECTitlefb">EC</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblECClosuresfb">4</span></p>
                                        </div>
                                    </div>
                                    <div class="timeline-block mb-3">
                                        <span class="timeline-step">
                                            <i class="ni ni-paper-diploma text-danger text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblBPTitlefb">BP</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblBPSelectedfb">12 Profiles</span></p>
                                        </div>
                                    </div>
                                    <div class="timeline-block mb-3">
                                        <span class="timeline-step">
                                            <i class="ni ni-circle-08 text-info text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblTLTitlefb">TL</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblTLApprovedfb">20 Profiles</span></p>
                                        </div>
                                    </div>
                                    <div class="timeline-block mb-3">
                                        <span class="timeline-step">
                                            <i class="ni ni-single-copy-04 text-warning text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblSBTitlefb">SB</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblSubmittedfb">23 Candidates</span></p>
                                        </div>
                                    </div>
                                    <div class="timeline-block mb-3">
                                        <span class="timeline-step">
                                            <i class="ni ni-tag text-primary text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblVenTitlefb">Ven</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblVendorsfb">2</span></p>
                                        </div>
                                    </div>
                                    <div class="timeline-block">
                                        <span class="timeline-step">
                                            <i class="ni ni-money-coins text-dark text-gradient"></i>
                                        </span>
                                        <div class="timeline-content">
                                            <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblCanTitlefb">Can</span></h6>
                                            <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblCandidatesfb">1</span></p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="col-md-8" id="div_mgrfeedback" style="display:none;">

                    <div class="card h-100 p-3">
                        <div class="card-header pb-0" style="padding: 5px 5px 5px 5px;">
                            <h6>Manager/Team Lead Feedback Form-<label class="h6" id="lblTeammember2"></label>
                                Performance for the duration of
                                <label class="h6" id="lblTMduration"></label>
                            </h6>
                            <%--<hr class="horizontal dark">--%>
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                                <%--<div class="col-md-4">
                                <label>Start Date</label><span style="color: red;">*</span>
                                <input class="form-control form-controlnew datepicker" type="text" id="txtFeedbackdate" placeholder="Start Date" onchange="getWeekNumber();" />
                            </div>--%>
                            </div>
                        </div>

                        <hr class="horizontal dark">

                        <div class="card-body pt-0">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                </div>
                                <div class="my-auto col-md-12">
                                    <div class="row">
                                        <div class="col-md-3 ps-4">
                                            <input type="hidden" id="hdnTeamperfomanceid" />
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <p class="text-sm mb-1">
                                                Target
                                            </p>
                                        </div>
                                        <div class="col-md-2 text-center">
                                            <p class="text-sm mb-1">
                                                Achieved
                                            </p>
                                        </div>
                                        <div class="col-md-4 text-center">
                                            <p class="text-sm mb-1">
                                                Remarks
                                            </p>
                                        </div>
                                        <div class="col-md-1">
                                            <p class="text-sm mb-1">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-single-02 text-lg opacity-6"></i>
                                </div>
                                <div class="my-auto col-md-12">
                                    <div class="row">
                                        <div class="col-md-3 ps-4">
                                            <p class="text-sm mb-1">
                                                Candidate adding
                                            </p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtCandidateadding" class="form-control" type="text" placeholder="Candidate Adding" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtCandidateaddachieved" class="form-control" type="text" placeholder="Candidate Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks1" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_candadd" style="display: none;" onclick="opendisabled('#drpRemarks1')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-paper-diploma text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Vendor creation </p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtVendorcreation" class="form-control" type="text" placeholder="Vendor Creation" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtVendorachieved" class="form-control" type="text" placeholder="Candidating Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks2" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_vendadd" style="display: none;" onclick="opendisabled('#drpRemarks2')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Submission</p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtSubmission" class="form-control" type="text" placeholder="Submittion" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtSubmissionachieved" class="form-control" type="text" placeholder="Candidating Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks3" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_subcand" style="display: none;" onclick="opendisabled('#drpRemarks3')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">TL Approval</p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtTLApproval" class="form-control" type="text" placeholder="Submittion" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtTLApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks4" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_TLcand" style="display: none;" onclick="opendisabled('#drpRemarks4')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">BP Approval</p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtBPApproval" class="form-control" type="text" placeholder="Submittion" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtBPApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks5" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_BPcand" style="display: none;" onclick="opendisabled('#drpRemarks5')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">EC Approval</p>
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtECApproval" class="form-control" type="text" placeholder="Submittion" disabled="disabled">
                                        </div>
                                        <div class="col-md-2">
                                            <input id="txtECApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" disabled="disabled">
                                        </div>
                                        <div class="col-md-4">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks6" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_ECcand" style="display: none;" onclick="opendisabled('#drpRemarks6')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Overall Rating</p>
                                        </div>
                                        <div class="col-md-8">
                                            <select class="form-control form-controlnew" name="choices-sizes" id="drpOverallRemarks" disabled="disabled">
                                            </select>
                                        </div>
                                        <div class="col-md-1" id="div_Overall" style="display: none;" onclick="opendisabled('#drpOverallRemarks')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <hr class="horizontal dark">
                            <div class="d-flex align-items-center">
                                <div class="text-center w-5" style="margin-top: -59px;">
                                    <i class="ni ni-user-run text-lg opacity-6"></i>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-3">
                                            <p class="my-auto ms-3">Remarks</p>
                                        </div>
                                        <div class="col-md-8">
                                            <textarea name="txtComm" rows="2" cols="20" id="txtComments" disabled="disabled" class="form-control form-controlnew text-font font_size" placeholder="Remarks" style="height: 100px;"></textarea>
                                        </div>
                                        <div class="col-md-1" id="div_Remarks" style="display: none;" onclick="opendisabled('#txtComments')">
                                            <i class="fas fa-pencil-alt mt-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <hr class="horizontal dark">
                            <%--<div class="d-flex align-items-center">
                                <div class="text-center w-5">
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-12 text-end">
                                            <div class="ms-auto my-auto mt-lg-0">
                                                <div class="ms-auto my-auto">
                                                    <button type="button" id="btnSave" class="btn bg-gradient-primary btn-sm mb-0" disabled="disabled" style="float: right;">
                                                        Save
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/startPage.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/ManagerFeedbackIndia.js"></script>
    <%--<script src="assets/js/plugins.js"></script>
    <script src="assets/js/core/popper.min.js"></script>
    <script src="assets/js/core/bootstrap.min.js"></script>
    <script src="assets/js/plugins/perfect-scrollbar.min.js"></script>
    <script src="assets/js/plugins/smooth-scrollbar.min.js"></script>--%>


    <%-- <script async defer src="https://buttons.github.io/buttons.js"></script>
    <script src="assets/js/Pro_js/dragula.min.js"></script>
    <script src="assets/js/Pro_js/jkanban.js"></script>
    <script src="assets/js/plugins/chartjs.min.js"></script>

    <script src="assets/js/soft-ui-dashboard.min.js"></script>
    <script src="assets/js/plugins/round-slider.min.js"></script>--%>

    <script>



        var ctx1 = document.getElementById("chart-consumption").getContext("2d");

        var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);

        gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');
        gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');
        gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); //purple colors

        new Chart(ctx1, {
            type: "doughnut",
            data: {
                labels: ['Overall Performance', 'Under Performance'],
                datasets: [{
                    label: "Consumption",
                    weight: 9,
                    cutout: 90,
                    tension: 0.9,
                    pointRadius: 2,
                    borderWidth: 2,
                    backgroundColor: ['#21d4fd','#FF0080'],
                    data: [75, 25],
                    fill: false
                }],
            },
            options: {
                responsive: true,
                cutoutPercentage: 93,
                maintainAspectRatio: false,
                legend: {
                    display: false
                },
                plugins: {
                    legend: {
                        display: false,
                    }
                },
                interaction: {
                    intersect: false,
                    mode: 'index',
                },
                scales: {
                    y: {
                        grid: {
                            drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false,
                        },
                        ticks: {
                            display: false
                        }
                    },
                    x: {
                        grid: {
                            drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false,
                        },
                        ticks: {
                            display: false,
                        }
                    },
                },
            },
        });

        $('#chart-consumption').height(230);

        // Bar chart
        //new Chart(ctx3, {
        //    type: "bar",
        //    data: {
        //        labels: ['16-20', '21-25', '26-30', '31-36', '36-42', '42+'],
        //        datasets: [{
        //            label: "Sales by age",
        //            weight: 5,
        //            borderWidth: 0,
        //            borderRadius: 4,
        //            backgroundColor: '#3A416F',
        //            data: [15, 20, 12, 60, 20, 15],
        //            fill: false
        //        }],
        //    },
        //    options: {
        //        indexAxis: 'y',
        //        responsive: true,
        //        maintainAspectRatio: false,
        //        plugins: {
        //            legend: {
        //                display: false,
        //            }
        //        },
        //        scales: {
        //            y: {
        //                grid: {
        //                    drawBorder: false,
        //                    display: true,
        //                    drawOnChartArea: true,
        //                    drawTicks: false,
        //                    borderDash: [5, 5]
        //                },
        //                ticks: {
        //                    display: true,
        //                    padding: 10,
        //                    color: '#9ca2b7'
        //                }
        //            },
        //            x: {
        //                grid: {
        //                    drawBorder: false,
        //                    display: false,
        //                    drawOnChartArea: true,
        //                    drawTicks: true,
        //                },
        //                ticks: {
        //                    display: true,
        //                    color: '#9ca2b7',
        //                    padding: 10
        //                }
        //            },
        //        },
        //    },
        //});
    </script>
    <%--<script>
        var win = navigator.platform.indexOf('Win') > -1;
        if (win && document.querySelector('#sidenav-scrollbar')) {
            var options = {
                damping: '0.5'
            }
            Scrollbar.init(document.querySelector('#sidenav-scrollbar'), options);
        }
    </script>--%>
    <!-- Github buttons -->

</asp:Content>
