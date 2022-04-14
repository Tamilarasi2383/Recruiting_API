<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="CandidateOverview.aspx.cs" Inherits="Recruiting_API.CandidateOverview" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Common.css" rel="stylesheet" />
    <style>
        .colorchange{
            background-color: #d6d5d5;
        }
        .card.card-background:after{
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

    <div class="container-fluid mt-4">
        <div class="row align-items-center">
            <div class="col-lg-4 col-sm-8">
                <div class="nav-wrapper position-relative end-0">
                    <ul class="nav nav-pills nav-fill p-1" role="tablist">
                        <li class="pe-5">
                            <a class="change_color mb-0 px-0 py-1" data-bs-toggle="tab" href="../../../examples/pages/account/settings.html" role="tab" aria-selected="true">Today's Overview
                            </a>
                        </li>
                       <%-- <li class="nav-item" onclick="window.location.href='CandidateList.aspx'">
                            <a class="nav-link mb-0 px-0 py-1 active " data-bs-toggle="tab" role="tab" aria-selected="false">Candidate List
                            </a>
                        </li>
                        --%>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid my-3 py-3">
        <div class="row">
            <div class="col-lg-8">
                <div class="row">
                    <div class="col-xl-6 mb-xl-0 mb-4">
                        <div class="card bg-transparent shadow-xl">
                            <div class="overflow-hidden position-relative border-radius-xl" style="background-image: url('assets/img/curved-images/white-curved.jpeg');">
                                <span class="mask bg-gradient-dark"></span>
                                <div class="card-body position-relative z-index-1 p-3">
                                    <%--<i class="fas fa-wifi text-white p-2"></i>--%>
                                    <h5 class="text-white mt-4 mb-4 pb-3"><span>People are not your most important asset. The right people are.</span></h5>
                                    <div class="d-flex">
                                        <div class="d-flex">
                                            <div class="me-4">
                                                <p class="text-white text-sm opacity-8 mb-0"><span id="lbltTarget">Target&nbsp;<span id="lblTargetvalue"></span>&nbsp;<span id="lblsubmission">Submission</span> / <span id="lblDay">day</span></span> </p>
                                                <h6 class="text-white mb-0"><span id="lblachieved">Achieved</span>&nbsp;<span id="lblachievedvalue"></span></h6>
                                            </div>
                                            <div>
                                                <p class="text-white text-sm opacity-8 mb-0"></p>
                                                <h6 class="text-white mb-0"></h6>
                                            </div>
                                        </div>
                                        <div class="ms-auto w-20 d-flex align-items-end justify-content-end">
                                            <img class="w-60 mt-2" src="Images/idlogo.png" alt="logo">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-xl-6">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="card zm colorchange" id="div_pipeline" onclick="getcandidateoverviewList('Pipeline')">
                                    <div class="card-header mx-4 p-3 text-center colorchange" id="div_pipelineheader">
                                        <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                            <i class="ni ni-single-copy-04 opacity-10"></i>
                                        </div>
                                    </div>
                                    <div class="card-body pt-0 p-3 text-center">
                                        <h6 class="text-center mb-0"><span id="lblPipeline"></span></h6>
                                        <span class="text-xs"><span id="lblTofollow">To Follow</span></span>
                                        <hr class="horizontal dark my-3">
                                        <h5 class="mb-0"><span id="lblPipelinevalue"></span></h5>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6 mt-md-0 mt-4">
                                <div class="card zm colorchange" id="div_interview" onclick="getcandidateoverviewList('Interview')">
                                    <div class="card-header mx-4 p-3 text-center colorchange" id="div_interviewheader">
                                        <div class="icon icon-shape icon-lg bg-gradient-primary shadow text-center border-radius-lg">
                                            <i class="ni ni-like-2 opacity-10"></i>
                                        </div>
                                    </div>
                                    <div class="card-body pt-0 p-3 text-center">
                                        <h6 class="text-center mb-0"><span id="lblInterview"></span></h6>
                                        <span class="text-xs"><span id="lblForcandidates">For Candidates</span></span>
                                        <hr class="horizontal dark my-3">
                                        <h5 class="mb-0"><span id="lblInterviewvalue"></span></h5>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12 mb-lg-0 mb-4">
                        <div class="card mt-4">
                            <div class="card-header pb-0 p-3">
                                <div class="row">
                                    <div class="col-6 d-flex align-items-center">
                                        <h6 class="mb-0">Task</h6>
                                    </div>
                                    <div class="col-6 text-end">
                                        <a class="btn bg-gradient-dark mb-0" href="Candidate.aspx?id=NoJob"><i class="fas fa-plus"></i>&nbsp;&nbsp;Add Candidate</a>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body p-4">
                                <div class="row">
                                    <div class="col-md-6 mb-md-0 mb-4">
                                        <div class="card card-body border card-plain border-radius-lg d-flex align-items-center flex-row">
                                            <img class="w-10 me-3 mb-0" src="Images/team.png" alt="logo">
                                            <h6 class="mb-0"><span>Add</span>&nbsp;<span id="lblAddcandidatevalue"></span>&nbsp;<span>candidates</span> / <span>day</span></h6>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="card card-body border card-plain border-radius-lg d-flex align-items-center flex-row">
                                            <img class="w-10 me-3 mb-0" src="Images/teams.png" alt="logo">
                                            <h6 class="mb-0"><span id="lblMorecandidates"></span>&nbsp;<span id="lblMoretitle">more candidates to achieve</span></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <div class="row">
                            <div class="col-6 d-flex align-items-center">
                                <h6 class="mb-0">Active Jobs</h6>
                            </div>
                            <div class="col-6 text-end">
                                <button class="btn btn-outline-primary btn-sm mb-0" onclick="gotoJobPage()">View All</button>
                            </div>
                        </div>
                    </div>
                    <div class="card-body p-3 pb-0" id="div_activejobs" style="overflow: scroll;overflow-x: hidden;height: 100px;">
                        <%--<ul class="list-group">
                            <li class="list-group-item border-0 d-flex justify-content-between ps-0 mb-2 border-radius-lg">
                                <div class="d-flex flex-column">
                                    <h6 class="mb-1 text-dark font-weight-bold text-sm"><span id="lblDesignation">Salesforce Technical Architect</span></h6>
                                    <span class="text-xs"><span id="lblMonthvalue">12</span><span id="lblMonth">+ months</span> | <span id="lblType">Contract</span> | <span id="lblCity">Alanta</span> , <span id="lblState">GA</span><span id="lblCountry">USA</span></span>
                                </div>
                                <div class="d-flex align-items-center text-sm">
                                    <button class="btn btn-link text-dark text-sm mb-0 px-0 ms-4"><i class="text-lg me-1" id="btnFollow"></i>Follow</button>
                                </div>
                            </li>
                        </ul>--%>
                    </div>
                </div>
            </div>
        </div>



        <div class="card mt-4">
            <div class="row mt-4">
                <div class="col-12">
                    <h5 class="ms-3"><span id="lblTableheader">Candidate List</span></h5>

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
                                        <div class="col-md-5">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="Search..." type="text" id="txtSearch">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="column1,column2,column3,column4" type="text" id="txtAdvSearch" style="display: none;" onkeyup="return keyValidation(this,'tblCandlist');">
                                        </div>
                                        <div class="col-md-2">

                                        </div>
                                    </div>
                                </div>

                                <%----%>
                                <%--onkeyup="return keyValidation(this);"--%>
                            </div>
                        </div>
                        </div>


                        <table class="table align-items-center mb-0" id="tblCandlist">
                            <thead>
                                <tr>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Candidates</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Vendor</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Submitted By</th>
                                    <th class="text-secondary opacity-7"></th>
                                </tr>
                            </thead>
                            <tbody>
                                
                            </tbody>
                        </table>

                        <%--<div class="dataTable-bottom">
                            <div class="dataTable-info" id="divInfo"></div>
                            <nav>
                                <ul id="paginus" class="pagination">
                                </ul>
                            </nav>
                        </div>--%>

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

        <script src="assets/js/jquery.js"></script>
        <script src="assets/js/plugins.js"></script>
        <script src="assets/js/prop/commondatastore.js"></script>
        <script src="AppScripts/Table.js"></script>
        <script src="AppScripts/CandidateOverview.js"></script>
        <%--<script src="AppScripts/Job.js"></script>--%>


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

                $("#tblCandlist tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)

                    //var totalRows = $(table + ' tbody tr').length; 
                    var len = $('table tbody tr:not([style*="display: none"])').length;
                    //var trWithoutDisplayNone =$("#tblJoblist").find('tr:not([style*="display: none"])').length;
                    //alert(len);

                    //getPager("#tblCandlist", 5);
                });
                getSearchPaging($('select#maxRows option:selected').val());
            });

        });

        

    </script>



</asp:Content>