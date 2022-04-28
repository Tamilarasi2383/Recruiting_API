<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManagerJobList.aspx.cs" Inherits="Recruiting_API.ManagerJobList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

        .no-border{
            border: 3px solid #65c6f5;
            background-color: white !important;
            color: red !important;
            box-shadow: none !important;
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

    <div class="container-fluid hidden">

        <div class="container-fluid mt-4">
            <div class="row align-items-center">
                <div class="col-lg-10 col-sm-8">
                    <div class="nav-wrapper position-relative end-0">
                        <ul class="nav nav-pills nav-fill p-1" role="tablist">
                            <li class="pe-5" onclick="getJoblist('Open');">
                                <a class="change_color mb-0 px-0 py-1" id="anchOverview" data-bs-toggle="tab" href="" role="tab" aria-selected="true">Overview
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>

        <div class="container-fluid py-4">

            <div class="row">
                <div class="col-lg-8 col-12">
                    <div class="row">
                        <div class="col-lg-4 col-12 zm" style="box-shadow: none;">
                            <div id="div_open" class="card card-background h-100 tilt zm" data-tilt="" style="will-change: transform; transform: perspective(1000px) rotateX(0deg) rotateY(0deg) scale3d(1, 1, 1);">
                                <div class="full-background" style="background-image: url('../../../assets/img/curved-images/white-curved.jpeg')"></div>
                                <div class="card-body pt-4 text-center" onclick="getJoblist('Open');">
                                    <h2 class="text-white mb-0 mt-2 up"><span id="lblOpenjobsus">Open Jobs</span></h2>
                                    <h1 class="text-white mb-0 up"><span id="lblOpenjobsvalueus"></span></h1>
                                    <%--                 <span class="badge badge-lg d-block bg-gradient-dark mb-2 up">+15% since last week</span>--%>
                                    <%--                  <a href="javascript:;" class="btn btn-outline-white mb-2 px-5 up">View All</a>--%>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12 mt-4 mt-lg-0">
                            <div class="card zm colorchange" id="div_feedback" onclick="getJoblist('Feedback','All');">
                                <div class="card-body p-3">
                                    <div class="d-flex">
                                        <div>
                                            <div class="icon icon-shape bg-gradient-dark text-center border-radius-md">
                                                <i class="ni ni-building text-lg opacity-10" aria-hidden="true"></i>
                                            </div>
                                        </div>
                                        <div class="ms-3">
                                            <div class="numbers">
                                                <p class="text-sm mb-0 text-capitalize font-weight-bold"><span id="lblFeedbackus">Feedback</span></p>
                                                <h5 class="font-weight-bolder mb-0">
                                                    <span id="lblFeedbackvalueus"></span>
                                                </h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card zm colorchange mt-4" id="div_nosubmission" onclick="getJoblist('No Submission','');">
                                <div class="card-body p-3">
                                    <div class="d-flex">
                                        <div>
                                            <div class="icon icon-shape bg-gradient-dark text-center border-radius-md">
                                                <i class="ni ni-planet text-lg opacity-10" aria-hidden="true"></i>
                                            </div>
                                        </div>
                                        <div class="ms-3">
                                            <div class="numbers">
                                                <p class="text-sm mb-0 text-capitalize font-weight-bold"><span id="lblNosubmissionus">No Submission</span></p>
                                                <h5 class="font-weight-bolder mb-0">
                                                    <span id="lblNosubmissionvalueus"></span>
                                                </h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12 mt-4 mt-lg-0">
                            <div class="card zm colorchange" id="div_TLsubmitted" onclick="getJoblist('TL Submitted','');">
                                <div class="card-body p-3">
                                    <div class="d-flex">
                                        <div>
                                            <div class="icon icon-shape bg-gradient-dark text-center border-radius-md">
                                                <i class="ni ni-world text-lg opacity-10" aria-hidden="true"></i>
                                            </div>
                                        </div>
                                        <div class="ms-3">
                                            <div class="numbers">
                                                <p class="text-sm mb-0 text-capitalize font-weight-bold"><span id="lblTLSubmittedus">TL Submitted</span></p>
                                                <h5 class="font-weight-bolder mb-0">
                                                    <span id="lblTLSubmittedvalueus"></span>
                                                    <%--                          <span class="text-success text-sm font-weight-bolder">+3%</span>--%>
                                                </h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="card zm mt-4 colorchange" id="div_interview" onclick="getJoblist('Interview','');">
                                <div class="card-body p-3">
                                    <div class="d-flex">
                                        <div>
                                            <div class="icon icon-shape bg-gradient-dark text-center border-radius-md">
                                                <i class="ni ni-shop text-lg opacity-10" aria-hidden="true"></i>
                                            </div>
                                        </div>
                                        <div class="ms-3">
                                            <div class="numbers">
                                                <p class="text-sm mb-0 text-capitalize font-weight-bold"><span id="lblInterviewus">Interview</span></p>
                                                <h5 class="font-weight-bolder mb-0">
                                                    <span id="lblInterviewvalueus"></span>
                                                    <%--                          <span class="text-success text-sm font-weight-bolder">+12%</span>--%>
                                                </h5>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-lg-4 col-12 mt-4 mt-lg-0">
                    <div class="col-xl-12">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="card zm colorchange" id="div_Total" onclick="getJoblist('Overall','');">
                                    <div class="card-header mx-4 p-3 text-center colorchange" id="div_TotalHeader" style="background: transparent;">
                                        <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                            <i class="ni ni-single-copy-04 opacity-10"></i>
                                        </div>
                                    </div>
                                    <div class="card-body pt-0 p-3 text-center">
                                        <h6 class="text-center mb-0"><span id="lblTotaljobsus">Overall Jobs</span></h6>
                                        <hr class="horizontal dark my-2">
                                        <h5 class="mb-0"><span id="lblTotaljobsvalueus"></span></h5>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="card zm colorchange" id="div_Closure" onclick="getJoblist('Closure','');">
                                    <div class="card-header mx-4 p-3 text-center colorchange" id="div_ClosureHeader" style="background: transparent;">
                                        <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                            <i class="ni ni-like-2 opacity-10"></i>
                                        </div>
                                    </div>
                                    <div class="card-body pt-0 p-3 text-center">
                                        <h6 class="text-center mb-0"><span id="lblClosureus">Closure</span></h6>
                                        <hr class="horizontal dark my-2">
                                        <h5 class="mb-0"><span id="lblClosurevalueus"></span></h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="mt-4">
            <div class="col-md-12">
                <div class="card">

                    <div class="card-header pb-0">
                        <div class="d-lg-flex">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-3">
                                        <h5 class="mb-0"><span id="lblTableheader">Job List</span></h5>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row" id="div_duration" style="display: none;">
                                            <div class="col-md-6">
                                                <div class="form-check mb-3">
                                                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="serFilter1" onclick="getFeedback();">
                                                    <label class="custom-control-label" for="customRadio1">All</label>
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-check">
                                                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="serFilter2" onclick="$('#drpEmployee').prop('disabled', false);">
                                                    <label class="custom-control-label" for="customRadio2">Recruiter</label><br />
                                                </div>
                                                <select class="form-control form-controlnew" id="drpEmployee" onchange="return getFeedback();" disabled="disabled">
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 p-0">
                                        <div class="ms-auto my-auto mt-lg-0 mt-4">
                                            <div class="ms-auto my-auto text-right">
                                                <button type="button" id="btnNewJob" class="btn bg-gradient-primary btn-sm mb-0" onclick="window.location='AddJobcode.aspx'">
                                                    +&nbsp; New  Job
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="">

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
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" id="th_priority" style="display:none;">Priority</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Job Open date </th>
                                    <th class="text-secondary opacity-7"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <%-- <tr>
                                <td>
                                    <div class="d-flex px-2 py-1">
                                        <div>
                                            <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                                        </div>
                                        <div class="d-flex flex-column justify-content-center">
                                            <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                            <label class="m-0">
                                                <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-md-12">
                                        <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                                    </div>
                                    <div class="col-md-12" style="margin-top: -10px;">
                                        <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                                    </div>
                                </td>
                                <td class="align-middle text-center text-sm">
                                    <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                                </td>
                                <td class="align-middle text-center">
                                    <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                                </td>
                                <td class="align-middle">
                                    <div class="col-lg-3 col-1 my-auto text-end">
                                        <div class="dropdown float-lg-end pe-1">
                                            <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                                <i class="fa fa-ellipsis-v text-secondary"></i>
                                            </a>
                                            <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="d-flex px-2 py-1">
                                        <div>
                                            <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                                        </div>
                                        <div class="d-flex flex-column justify-content-center">
                                            <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                            <label class="m-0">
                                                <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-md-12">
                                        <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                                    </div>
                                    <div class="col-md-12" style="margin-top: -10px;">
                                        <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                                    </div>
                                </td>
                                <td class="align-middle text-center text-sm">
                                    <span class="badge badge-sm bg-gradient-danger" id="spnClose">Closed</span>
                                </td>
                                <td class="align-middle text-center">
                                    <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                                </td>
                                <td class="align-middle">
                                    <div class="col-lg-3 col-1 my-auto text-end">
                                        <div class="dropdown float-lg-end pe-1">
                                            <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                                <i class="fa fa-ellipsis-v text-secondary"></i>
                                            </a>
                                            <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="d-flex px-2 py-1">
                                        <div>
                                            <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                                        </div>
                                        <div class="d-flex flex-column justify-content-center">
                                            <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                            <label class="m-0">
                                                <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-md-12">
                                        <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                                    </div>
                                    <div class="col-md-12" style="margin-top: -10px;">
                                        <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                                    </div>
                                </td>
                                <td class="align-middle text-center text-sm">
                                    <span class="badge badge-sm bg-gradient-secondary" id="spnHold">Hold</span>
                                </td>
                                <td class="align-middle text-center">
                                    <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                                </td>
                                <td class="align-middle">
                                    <div class="col-lg-3 col-1 my-auto text-end">
                                        <div class="dropdown float-lg-end pe-1">
                                            <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                                <i class="fa fa-ellipsis-v text-secondary"></i>
                                            </a>
                                            <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>

                            <tr>
                                <td>
                                    <div class="d-flex px-2 py-1">
                                        <div>
                                            <img src='Images/Salesforce.png'  class="avatar avatar-sm me-3">
                                        </div>
                                        <div class="d-flex flex-column justify-content-center">
                                            <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                            <label class="m-0">
                                                <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <div class="col-md-12">
                                        <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                                    </div>
                                    <div class="col-md-12" style="margin-top: -10px;">
                                        <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                                    </div>
                                </td>
                                <td class="align-middle text-center text-sm">
                                    <span class="badge badge-sm bg-gradient-secondary" id="spnOffline">Offline</span>
                                </td>
                                <td class="align-middle text-center">
                                    <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                                </td>
                                <td class="align-middle">
                                    <div class="col-lg-3 col-1 my-auto text-end">
                                        <div class="dropdown float-lg-end pe-1">
                                            <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                                <i class="fa fa-ellipsis-v text-secondary"></i>
                                            </a>
                                            <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                                <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                            </ul>
                                        </div>
                                    </div>
                                </td>
                            </tr>--%>
                            </tbody>
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
                </div>
            </div>
        </div>

    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/ManagerJobList.js"></script>


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

        $(document).ready(function () {
            $("#txtSearch").on("keyup", function () {
                var value = $(this).val().toLowerCase();

                $("#tblJoblist tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)

                    //var totalRows = $(table + ' tbody tr').length; 
                    var len = $('table tbody tr:not([style*="display: none"])').length;
                    //var trWithoutDisplayNone =$("#tblJoblist").find('tr:not([style*="display: none"])').length;
                    //alert(len);

                    //getPager("#tblJoblist", 5);

                    getSearchPaging($('select#maxRows option:selected').val());
                });

            });

        });

    </script>

</asp:Content>

