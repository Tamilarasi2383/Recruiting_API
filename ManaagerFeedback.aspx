<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManaagerFeedback.aspx.cs" Inherits="Recruiting_API.ManaagerFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Common.css" rel="stylesheet" />
    <script src="assets/js/plugins/chartjs.min.js"></script>
    <script src="assets/js/plugins/Chart.extension.js"></script>

    <style>
        .colorchange {
            background-color: #d6d5d5;
        }

        .card.card-background:after {
            position: absolute;
            top: 0;
            bottom: 0;
            left: 0;
            height: 100%;
            width: 100%;
            z-index: 1;
            display: block;
            content: "";
            background: none;
            border-radius: 1rem;
        }
    </style>

    <%--<style>
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
    </div>--%>

    <div class="container-fluid py-4 hidden">

        <div class="row">
            <div class="col-md-6">
                <label class="h6 font-weight-bolder" id="lblTeammembername"></label>
            </div>
        </div>

        <div class="col-md-12 mt-3">
            <div class="row">
                <div class="col-md-3">
                    <div class="col-md-12">
                        <div class="card zm colorchange" id="div_total" onclick="getRecruiterJobDetails();">
                            <div class="card-header mx-4 p-3 text-center colorchange" id="div_totalheader" style="background: transparent;">
                                <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                    <i class="ni ni-single-copy-04 opacity-10"></i>
                                </div>
                            </div>
                            <div class="card-body pt-0 p-0 text-center">
                                <div class="numbers">
                                    <p class="text-sm mb-0 text-capitalize font-weight-bold mb-3" id="p_Total"></p>
                                    <hr class="horizontal dark my-3 mb-1">
                                    <h5 class="font-weight-bolder mb-0">
                                        <label class="h5 font-weight-bolder" id="lblTotaljob">Total Jobs Worked</label>
                                        <label class="text-success text-sm font-weight-bolder" id="lblActivejob"></label>
                                    </h5>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-9">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="card zm colorchange" id="div_interview" onclick="getRecruiterDetails('Interview');">
                                <div class="card-header mx-4 p-3 text-center colorchange" id="div_interviewheader" style="background: transparent;">
                                    <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                        <i class="ni ni-single-copy-04 opacity-10"></i>
                                    </div>
                                </div>
                                <div class="card-body pt-0 p-0 text-center">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-capitalize font-weight-bold mb-3" id="p_Inte"></p>
                                        <hr class="horizontal dark my-3 mb-1">
                                        <h5 class="font-weight-bolder mb-0">
                                            <label class="h5 font-weight-bolder" id="lblInterview">Interview</label>
                                            <label class="text-success text-sm font-weight-bolder" id="lblResumeEC"></label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="card zm colorchange" id="div_jobcandidates" onclick="getRecruiterDetails('Candidates');">
                                <div class="card-header mx-4 p-3 text-center colorchange" id="div_candidatesheader" style="background: transparent;">
                                    <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                        <i class="ni ni-single-copy-04 opacity-10"></i>
                                    </div>
                                </div>
                                <div class="card-body pt-0 p-0 text-center">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-capitalize font-weight-bold mb-3" id="p_Cand"></p>
                                        <hr class="horizontal dark my-3 mb-1">
                                        <h5 class="font-weight-bolder mb-0">
                                            <label class="h5 font-weight-bolder" id="lblCandidateAdd">Candidates Added</label>
                                            <label class="text-success text-sm font-weight-bolder" id="lblNewCandidates"></label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="card zm colorchange" id="div_jobvendors" onclick="getRecruiterDetails('Vendors');">
                                <div class="card-header mx-4 p-3 text-center colorchange" id="div_vendorsheader" style="background: transparent;">
                                    <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                        <i class="ni ni-single-copy-04 opacity-10"></i>
                                    </div>
                                </div>
                                <div class="card-body pt-0 p-0 text-center">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-capitalize font-weight-bold mb-3" id="p_Vendor"></p>
                                        <hr class="horizontal dark my-3 mb-1">
                                        <h5 class="font-weight-bolder mb-0">
                                            <label class="h5 font-weight-bolder" id="lblVendorsAdd">Vendors Added</label>
                                            <label class="text-success text-sm font-weight-bolder" id="lblNewVendors"></label>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="card zm colorchange" id="div_closures" onclick="getRecruiterDetails('Closures');">
                                <div class="card-header mx-4 p-3 text-center colorchange" id="div_closuresheader" style="background: transparent;">
                                    <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                        <i class="ni ni-single-copy-04 opacity-10"></i>
                                    </div>
                                </div>
                                <div class="card-body pt-0 p-0 text-center">
                                    <div class="numbers">
                                        <p class="text-sm mb-0 text-capitalize font-weight-bold mb-3" id="p_Clos"></p>
                                        <hr class="horizontal dark my-3 mb-1">
                                        <h5 class="font-weight-bolder mb-0">
                                            <label class="h5 font-weight-bolder" id="lblMadeclosure">Closures</label>
                                            <span class="text-success text-sm font-weight-bolder" id="lblOnLive"></span>
                                        </h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="card mt-3" id="div_CandidateJobs" style="display: none;">
            <h5 class="ms-3"><span id="lblTableheader">Job List</span></h5>
            <div class="dataTable-top mt-2">
                <div class="dataTable-dropdown">
                    <label style="margin-bottom: 0; margin-left: 0; color: #8392ab; font-weight: 400;">
                        <select class="count-list" id="maxRows">
                            <option value="5">5</option>
                            <option value="10">10</option>
                            <option value="15">15</option>
                            <option value="20">20</option>
                            <option value="25">25</option>
                        </select>
                        entries per page</label>
                </div>
                <div class="dataTable-search" style="width: 50%;">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4 mt-2 text-right p-0">
                                <span class="text-bold" id="lblSearch">Search</span>
                                <span class="text-bold" id="lblAdvSearch" style="display: none;">Advance Search</span>
                            </div>
                            <div class="col-md-1 mt-2 p-0">
                                <div class="form-group mb-0">
                                    <div class="form-check form-switch ms-1" onclick="openEmployer()">
                                        <input class="form-check-input" type="checkbox" id="chkSearch" name="chkSearch" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-7">
                                <input class="dataTable-input dataTable-input2 w-100" placeholder="Search..." type="text" id="txtSearch">
                                <input class="dataTable-input dataTable-input2 w-100" placeholder="column1,column2,column3,column4" type="text" id="txtAdvSearch" style="display: none;" onkeyup="return keyValidation(this'tblJoblist');">
                            </div>
                        </div>
                    </div>

                    <%----%>
                    <%--onkeyup="return keyValidation(this);"--%>
                </div>
            </div>

            <table class="table align-items-center mb-0" id="tblJoblist">
                <thead>
                    <tr>
                        <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Jobs</th>
                        <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Client</th>
                        <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                        <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Job Open date </th>
                        <th class="text-secondary opacity-7"></th>
                    </tr>
                </thead>
                <tbody></tbody>
            </table>

            <div class="dataTable-bottom">
                <div class="dataTable-info" id="divInfo"></div>
                <div id="paginus" class="pagination pagination-info">
                    <div class="prev"><i class='ni ni-bold-left' aria-hidden='true'></i></div>
                    <div class="pagination pagination-info" id="divPages"></div>
                    <div class="next"><i class='ni ni-bold-right' aria-hidden='true'></i></div>
                </div>
            </div>

        </div>

        <div class="card mt-4" id="div_candidatetable" style="display: none;">
            <div class="row mt-4">
                <div class="col-12">
                    <h5 class="ms-3"><span id="lblcandTableheader">Candidate List</span></h5>

                    <div class="">

                        <div class="dataTable-top mt-2">
                            <div class="dataTable-dropdown">
                                <label style="margin-bottom: 0; margin-left: 0; color: #8392ab; font-weight: 400;">
                                    <select class="count-list" id="maxRows1">
                                        <option value="5">5</option>
                                        <option value="10">10</option>
                                        <option value="15">15</option>
                                        <option value="20">20</option>
                                        <option value="25">25</option>
                                    </select>
                                    entries per page</label>
                            </div>
                            <div class="dataTable-search" style="width: 50%;">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-4 mt-2 text-right p-0">
                                            <span class="text-bold" id="lblSearch1">Search</span>
                                            <span class="text-bold" id="lblAdvSearch1" style="display: none;">Advance Search</span>
                                        </div>
                                        <div class="col-md-1 mt-2 p-0">
                                            <div class="form-group mb-0">
                                                <div class="form-check form-switch ms-1" onclick="openEmployer()">
                                                    <input class="form-check-input" type="checkbox" id="chkSearch1" name="chkSearch" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="Search..." type="text" id="txtSearch1">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="column1,column2,column3,column4" type="text" id="txtAdvSearch1" style="display: none;" onkeyup="return keyValidation(this,'tblCandlist');">
                                        </div>
                                        <div class="col-md-2">
                                        </div>
                                    </div>
                                </div>

                                <%----%>
                                <%--onkeyup="return keyValidation(this);"--%>
                            </div>
                        </div>


                        <table class="table align-items-center mb-0" id="tblCandlist">
                            <thead>
                                <tr>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Candidates</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Vendor</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Submitted By</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <div class="dataTable-bottom">
                            <div class="dataTable-info" id="divInfo1"></div>
                            <div id="paginus1" class="pagination pagination-info">
                                <div class="prev"><i class='ni ni-bold-left' aria-hidden='true'></i></div>
                                <div class="pagination pagination-info" id="divPages1"></div>
                                <div class="next"><i class='ni ni-bold-right' aria-hidden='true'></i></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-md-4">
                <div class="card h-100">
                    <div class="card-header pb-0">
                        <h6>
                            <label class="h6" id="lblTeammember1"></label>
                            -Performance overview-System generated</h6>
                        <p class="text-sm">
                            <i id="icon_overview" aria-hidden="true"></i>
                            <span class="font-weight-bold" id="lblPerformanceVal">4%</span><%-- <span id="lblPerformance">this month</span>--%>
                        </p>
                    </div>
                    <div class="card-body p-3">
                        <div class="timeline timeline-one-side">
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-like-2 text-success text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblECTitle">EC</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblECClosures">4</span></p>
                                </div>
                            </div>
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-paper-diploma text-danger text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblBPTitle">BP</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblBPSelected">12 Profiles</span></p>
                                </div>
                            </div>
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-circle-08 text-info text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblTLTitle">TL</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblTLApproved">20 Profiles</span></p>
                                </div>
                            </div>
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-single-copy-04 text-warning text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblSBTitle">SB</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblSubmitted">23 Candidates</span></p>
                                </div>
                            </div>
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-tag text-primary text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblVenTitle">Ven</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblVendors">2</span></p>
                                </div>
                            </div>
                            <div class="timeline-block">
                                <span class="timeline-step">
                                    <i class="ni ni-money-coins text-dark text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblCanTitle">Can</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblCandidates">1</span></p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-8">
                <div class="card h-100 p-3">
                    <div class="card-header pb-0" style="padding: 5px 5px 5px 5px;">
                        <h6>Manager/Team Lead Feedback Form-<label class="h6" id="lblTeammember2"></label>- based on Performance</h6>
                        <hr class="horizontal dark">
                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4">
                                <label>Start Date</label><span style="color: red;">*</span>
                                <input class="form-control form-controlnew datepicker" type="text" id="txtFeedbackdate" placeholder="Start Date" onchange="getWeekNumber();" />
                            </div>
                            <div class="col-md-8" id="div_week" style="display: none;">
                                <label>
                                    Week1:<br />
                                    <span id="lblWeek1" onclick="" style="cursor: pointer;"></span>
                                </label>
                                <label>
                                    Week2:<br />
                                    <span id="lblWeek2" onclick="" style="cursor: pointer;"></span>
                                </label>
                                <label>
                                    Week3:<br />
                                    <span id="lblWeek3" onclick="" style="cursor: pointer;"></span>
                                </label>
                                <label>
                                    Week4:<br />
                                    <span id="lblWeek4" onclick="" style="cursor: pointer;"></span>
                                </label>
                                <label>
                                    Week5:<br />
                                    <span id="lblWeek5" onclick="" style="cursor: pointer;"></span>
                                </label>
                            </div>
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
                                        <input id="txtCandidateadding" class="form-control" type="text" placeholder="Candidating Adding" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtCandidateaddachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks1">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <input id="txtVendorcreation" class="form-control" type="text" placeholder="Vendor Creation" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtVendorachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks2">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <input id="txtSubmission" class="form-control" type="text" placeholder="Submittion" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtSubmissionachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks3">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <input id="txtTLApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtTLApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks4">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <input id="txtBPApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtBPApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks5">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <input id="txtECApproval" class="form-control" type="text" placeholder="Submittion" required="required">
                                    </div>
                                    <div class="col-md-2">
                                        <input id="txtECApprovalachieved" class="form-control" type="text" placeholder="Candidating Achieved" required="required">
                                    </div>
                                    <div class="col-md-4">
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpRemarks6">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <select class="form-control form-controlnew" name="choices-sizes" id="drpOverallRemarks">
                                        </select>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
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
                                        <textarea name="txtComm" rows="2" cols="20" id="txtComments" class="form-control form-controlnew text-font font_size" placeholder="Remarks" style="height: 100px;"></textarea>
                                    </div>
                                    <div class="col-md-1" style="display: none;">
                                        <i class="fas fa-pencil-alt mt-2"></i>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="horizontal dark">
                        <div class="d-flex align-items-center">
                            <div class="text-center w-5">
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-12 text-end">
                                        <div class="ms-auto my-auto mt-lg-0">
                                            <div class="ms-auto my-auto">
                                                <button type="button" id="btnSave" class="btn bg-gradient-primary btn-sm mb-0" style="float: right;">
                                                    Save
                                                </button>
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

        <div class="row mt-4">
            <div class="col-lg-5 mb-lg-0 mb-4">
                <div class="card">
                    <div class="card-body p-3">
                        <div class="bg-gradient-dark border-radius-lg py-3 pe-1 mb-3">
                            <div class="chart" id="divBarchart">
                                <%--<asp:Literal runat="server" ID="lblBarChart">--%>
                                <%--<canvas id="chart-bars" class="chart-canvas" height="170px"></canvas>--%>

                                <%--</asp:Literal>--%>
                            </div>
                        </div>
                        <h6 class="ms-2 mt-4 mb-0"><span id="lblBarTitle"></span></h6>
                        <p class="text-sm ms-2"><span id="lblBarDuration"></span></p>
                        <div class="container border-radius-lg">
                            <div class="row">
                                <div class="col-3 py-3 ps-0">
                                    <div class="d-flex mb-2">
                                        <div class="icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-primary text-center me-2 d-flex align-items-center justify-content-center">
                                            <svg width="10px" height="10px" viewBox="0 0 40 44" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                                <title>document</title>
                                                <g id="Basic-Elements" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <g id="Rounded-Icons" transform="translate(-1870.000000, -591.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                        <g id="Icons-with-opacity" transform="translate(1716.000000, 291.000000)">
                                                            <g id="document" transform="translate(154.000000, 300.000000)">
                                                                <path class="color-background" d="M40,40 L36.3636364,40 L36.3636364,3.63636364 L5.45454545,3.63636364 L5.45454545,0 L38.1818182,0 C39.1854545,0 40,0.814545455 40,1.81818182 L40,40 Z" id="Path" opacity="0.603585379"></path>
                                                                <path class="color-background" d="M30.9090909,7.27272727 L1.81818182,7.27272727 C0.814545455,7.27272727 0,8.08727273 0,9.09090909 L0,41.8181818 C0,42.8218182 0.814545455,43.6363636 1.81818182,43.6363636 L30.9090909,43.6363636 C31.9127273,43.6363636 32.7272727,42.8218182 32.7272727,41.8181818 L32.7272727,9.09090909 C32.7272727,8.08727273 31.9127273,7.27272727 30.9090909,7.27272727 Z M18.1818182,34.5454545 L7.27272727,34.5454545 L7.27272727,30.9090909 L18.1818182,30.9090909 L18.1818182,34.5454545 Z M25.4545455,27.2727273 L7.27272727,27.2727273 L7.27272727,23.6363636 L25.4545455,23.6363636 L25.4545455,27.2727273 Z M25.4545455,20 L7.27272727,20 L7.27272727,16.3636364 L25.4545455,16.3636364 L25.4545455,20 Z" id="Shape"></path>
                                                            </g>
                                                        </g>
                                                    </g>
                                                </g>
                                            </svg>
                                        </div>
                                        <p class="text-xs mt-1 mb-0 font-weight-bold" id="p_SB"></p>
                                    </div>
                                    <label class="h5 font-weight-bolder mt-2" id="lblSubCount"></label>
                                    <%--<h4 class="font-weight-bolder">12</h4>--%>
                                    <div class="progress w-75">
                                        <div id="pbid" class="progress-bar bg-dark w-80" role="progressbar" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                                <div class="col-3 py-3 ps-0">
                                    <div class="d-flex mb-2">
                                        <div class="icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-info text-center me-2 d-flex align-items-center justify-content-center">
                                            <svg width="10px" height="10px" viewBox="0 0 40 40" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                                <title>spaceship</title>
                                                <g id="Basic-Elements" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <g id="Rounded-Icons" transform="translate(-1720.000000, -592.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                        <g id="Icons-with-opacity" transform="translate(1716.000000, 291.000000)">
                                                            <g id="spaceship" transform="translate(4.000000, 301.000000)">
                                                                <path class="color-background" d="M39.3,0.706666667 C38.9660984,0.370464027 38.5048767,0.192278529 38.0316667,0.216666667 C14.6516667,1.43666667 6.015,22.2633333 5.93166667,22.4733333 C5.68236407,23.0926189 5.82664679,23.8009159 6.29833333,24.2733333 L15.7266667,33.7016667 C16.2013871,34.1756798 16.9140329,34.3188658 17.535,34.065 C17.7433333,33.98 38.4583333,25.2466667 39.7816667,1.97666667 C39.8087196,1.50414529 39.6335979,1.04240574 39.3,0.706666667 Z M25.69,19.0233333 C24.7367525,19.9768687 23.3029475,20.2622391 22.0572426,19.7463614 C20.8115377,19.2304837 19.9992882,18.0149658 19.9992882,16.6666667 C19.9992882,15.3183676 20.8115377,14.1028496 22.0572426,13.5869719 C23.3029475,13.0710943 24.7367525,13.3564646 25.69,14.31 C26.9912731,15.6116662 26.9912731,17.7216672 25.69,19.0233333 L25.69,19.0233333 Z" id="Shape"></path>
                                                                <path class="color-background" d="M1.855,31.4066667 C3.05106558,30.2024182 4.79973884,29.7296005 6.43969145,30.1670277 C8.07964407,30.6044549 9.36054508,31.8853559 9.7979723,33.5253085 C10.2353995,35.1652612 9.76258177,36.9139344 8.55833333,38.11 C6.70666667,39.9616667 0,40 0,40 C0,40 0,33.2566667 1.855,31.4066667 Z" id="Path"></path>
                                                                <path class="color-background" d="M17.2616667,3.90166667 C12.4943643,3.07192755 7.62174065,4.61673894 4.20333333,8.04166667 C3.31200265,8.94126033 2.53706177,9.94913142 1.89666667,11.0416667 C1.5109569,11.6966059 1.61721591,12.5295394 2.155,13.0666667 L5.47,16.3833333 C8.55036617,11.4946947 12.5559074,7.25476565 17.2616667,3.90166667 L17.2616667,3.90166667 Z" id="color-2" opacity="0.598539807"></path>
                                                                <path class="color-background" d="M36.0983333,22.7383333 C36.9280725,27.5056357 35.3832611,32.3782594 31.9583333,35.7966667 C31.0587397,36.6879974 30.0508686,37.4629382 28.9583333,38.1033333 C28.3033941,38.4890431 27.4704606,38.3827841 26.9333333,37.845 L23.6166667,34.53 C28.5053053,31.4496338 32.7452344,27.4440926 36.0983333,22.7383333 L36.0983333,22.7383333 Z" id="color-3" opacity="0.598539807"></path>
                                                            </g>
                                                        </g>
                                                    </g>
                                                </g>
                                            </svg>
                                        </div>
                                        <p class="text-xs mt-1 mb-0 font-weight-bold" id="p_TL"></p>
                                    </div>
                                    <label class="h5 font-weight-bolder mt-2" id="lblTl"></label>
                                    <%--<h4 class="font-weight-bolder">11</h4>--%>
                                    <div class="progress w-75">
                                        <div class="progress-bar bg-dark w-90" role="progressbar" aria-valuenow="90" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                                <div class="col-3 py-3 ps-0">
                                    <div class="d-flex mb-2">
                                        <div class="icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-warning text-center me-2 d-flex align-items-center justify-content-center">
                                            <svg width="10px" height="10px" viewBox="0 0 43 36" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                                <title>credit-card</title>
                                                <g id="Basic-Elements" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <g id="Rounded-Icons" transform="translate(-2169.000000, -745.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                        <g id="Icons-with-opacity" transform="translate(1716.000000, 291.000000)">
                                                            <g id="credit-card" transform="translate(453.000000, 454.000000)">
                                                                <path class="color-background" d="M43,10.7482083 L43,3.58333333 C43,1.60354167 41.3964583,0 39.4166667,0 L3.58333333,0 C1.60354167,0 0,1.60354167 0,3.58333333 L0,10.7482083 L43,10.7482083 Z" id="Path" opacity="0.593633743"></path>
                                                                <path class="color-background" d="M0,16.125 L0,32.25 C0,34.2297917 1.60354167,35.8333333 3.58333333,35.8333333 L39.4166667,35.8333333 C41.3964583,35.8333333 43,34.2297917 43,32.25 L43,16.125 L0,16.125 Z M19.7083333,26.875 L7.16666667,26.875 L7.16666667,23.2916667 L19.7083333,23.2916667 L19.7083333,26.875 Z M35.8333333,26.875 L28.6666667,26.875 L28.6666667,23.2916667 L35.8333333,23.2916667 L35.8333333,26.875 Z" id="Shape"></path>
                                                            </g>
                                                        </g>
                                                    </g>
                                                </g>
                                            </svg>
                                        </div>
                                        <p class="text-xs mt-1 mb-0 font-weight-bold" id="p_BP"></p>
                                    </div>
                                    <label class="h5 font-weight-bolder mt-2" id="lblSubBp"></label>
                                    <%--<h4 class="font-weight-bolder">05</h4>--%>
                                    <div class="progress w-75">
                                        <div class="progress-bar bg-dark w-55" role="progressbar" aria-valuenow="55" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                                <div class="col-3 py-3 ps-0">
                                    <div class="d-flex mb-2">
                                        <div class="icon icon-shape icon-xxs shadow border-radius-sm bg-gradient-danger text-center me-2 d-flex align-items-center justify-content-center">
                                            <svg width="10px" height="10px" viewBox="0 0 40 40" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink">
                                                <title>settings</title>
                                                <g id="Basic-Elements" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd">
                                                    <g id="Rounded-Icons" transform="translate(-2020.000000, -442.000000)" fill="#FFFFFF" fill-rule="nonzero">
                                                        <g id="Icons-with-opacity" transform="translate(1716.000000, 291.000000)">
                                                            <g id="settings" transform="translate(304.000000, 151.000000)">
                                                                <polygon class="color-background" id="Path" opacity="0.596981957" points="18.0883333 15.7316667 11.1783333 8.82166667 13.3333333 6.66666667 6.66666667 0 0 6.66666667 6.66666667 13.3333333 8.82166667 11.1783333 15.315 17.6716667"></polygon>
                                                                <path class="color-background" d="M31.5666667,23.2333333 C31.0516667,23.2933333 30.53,23.3333333 30,23.3333333 C29.4916667,23.3333333 28.9866667,23.3033333 28.48,23.245 L22.4116667,30.7433333 L29.9416667,38.2733333 C32.2433333,40.575 35.9733333,40.575 38.275,38.2733333 L38.275,38.2733333 C40.5766667,35.9716667 40.5766667,32.2416667 38.275,29.94 L31.5666667,23.2333333 Z" id="Path" opacity="0.596981957"></path>
                                                                <path class="color-background" d="M33.785,11.285 L28.715,6.215 L34.0616667,0.868333333 C32.82,0.315 31.4483333,0 30,0 C24.4766667,0 20,4.47666667 20,10 C20,10.99 20.1483333,11.9433333 20.4166667,12.8466667 L2.435,27.3966667 C0.95,28.7083333 0.0633333333,30.595 0.00333333333,32.5733333 C-0.0583333333,34.5533333 0.71,36.4916667 2.11,37.89 C3.47,39.2516667 5.27833333,40 7.20166667,40 C9.26666667,40 11.2366667,39.1133333 12.6033333,37.565 L27.1533333,19.5833333 C28.0566667,19.8516667 29.01,20 30,20 C35.5233333,20 40,15.5233333 40,10 C40,8.55166667 39.685,7.18 39.1316667,5.93666667 L33.785,11.285 Z" id="Path"></path>
                                                            </g>
                                                        </g>
                                                    </g>
                                                </g>
                                            </svg>
                                        </div>
                                        <p class="text-xs mt-1 mb-0 font-weight-bold" id="p_EC"></p>
                                    </div>
                                    <label class="h5 font-weight-bolder mt-2" id="lblEc"></label>
                                    <%--<h4 class="font-weight-bolder">02</h4>--%>
                                    <div class="progress w-75">
                                        <div class="progress-bar bg-dark w-40" role="progressbar" aria-valuenow="40" aria-valuemin="0" aria-valuemax="100"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header pb-0">
                        <h6><span id="lblSubTitle1"></span></h6>
                        <p class="text-sm">
                            <i class="fa fa-arrow-up text-success"></i>
                            <span class="font-weight-bold" id="lblSubTitle2"></span>
                        </p>
                    </div>
                    <div class="card-body p-3">
                        <div class="chart" id="divLinechart">
                            <%--<canvas id="chart-line" class="chart-canvas" height="300px"></canvas>--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/startPage.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/ManagerFeedback.js"></script>

    <script>
        function openEmployer() {
            if ($('input[name="chkSearch"]:checked').val() == "on") {
                document.getElementById("txtSearch").style.display = "none";
                document.getElementById("txtAdvSearch").style.display = "block";

                document.getElementById("lblSearch").style.display = "none";
                document.getElementById("lblAdvSearch").style.display = "block";
                enableemplcontrols();
            }
            else {
                document.getElementById("txtSearch").style.display = "block";
                document.getElementById("txtAdvSearch").style.display = "none";

                document.getElementById("lblSearch").style.display = "block";
                document.getElementById("lblAdvSearch").style.display = "none";
            }
        }
    </script>

</asp:Content>