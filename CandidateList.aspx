<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="CandidateList.aspx.cs" Inherits="Recruiting_API.CandidateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .colorgray{
            background-color: #d6d5d5 !important;
            border-radius: 1rem;
        }
        .count-list {
            border-color: #e9ecef;
            border-radius: .25rem;
            padding: 6px;
        }

        .dataTable-input2 {

            font-size: .875rem;
            color: #495057;
            border: 1px solid #e9ecef;
            border-radius: .5rem;
        }

            .dataTable-input2:focus {
                outline: none;
                font-size: .875rem;
                color: #495057;
                border: 1px solid #e9ecef;
                border-radius: .5rem !important;
            }

        .colorchange {
            background-color: #d6d5d5 !important;
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

    <div class="container-fluid mt-4 hidden">
        <div class="row align-items-center">
            <div class="col-lg-6 col-sm-8">
                <div class="nav-wrapper position-relative end-0">
                    <ul class="nav nav-pills nav-fill p-1" role="tablist">
                        <%--<li class="nav-item" onclick="window.location.href='CandidateOverview.aspx'">
                            <a class="nav-link mb-0 px-0 py-1 " data-bs-toggle="tab" role="tab" aria-selected="false">Today's Overview
                            </a>
                        </li>--%>
                        <li class="pe-5" onclick="getcandidateList('All');" style="cursor:pointer;">
                            <a class="mb-0 px-0 py-1" id="anchCandidate" data-bs-toggle="tab" role="tab" aria-selected="true">Candidate List
                            </a>
                        </li>
                        <li class="pe-5" onclick="getcandidateList('Follow');" style="cursor:pointer;">
                            <a class="mb-0 px-0 py-1" id="anchFollowup" data-bs-toggle="tab" role="tab" aria-selected="false">Follow Up
                            </a>
                        </li>
                        <li class="pe-5" onclick="getcandidateList('Draft');" style="cursor:pointer;">
                            <a class="mb-0 px-0 py-1" id="anchDraft" data-bs-toggle="tab" role="tab" aria-selected="false">Draft
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- End Navbar -->
    <div class="container-fluid py-4 hidden">
        <div class="row">
            <div class="col-lg-6 col-12">
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-12">
                        <div class="card zm"  style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('All');">
                            <span class="mask bg-gradient-dark opacity-9 border-radius-xl"></span>
                            <div class="card-body p-3 position-relative" id="div_TotSubmitted">
                                <div class="row">
                                    <div class="col-8 text-start">
                                        <div class="icon icon-shape bg-white shadow text-center border-radius-md">
                                            <i class="ni ni-circle-08 text-dark text-gradient text-lg opacity-10" aria-hidden="true"></i>
                                        </div>
                                        <h5 class="text-white font-weight-bolder mb-0 mt-3">
                                            <span id="lblTotalcandidatevalue"></span>
                                        </h5>
                                        <span class="text-white text-sm" id="lblTotalcandidate"></span>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-12 mt-4 mt-md-0">
                        <div class="card zm" style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('TLSubmitted');">
                            <span class="mask bg-gradient-dark opacity-9 border-radius-xl"></span>
                            <div class="card-body p-3 position-relative "  id="div_TLSubmitted">
                                <div class="row">
                                    <div class="col-8 text-start">
                                        <div class="icon icon-shape bg-white shadow text-center border-radius-md">
                                            <i class="ni ni-single-copy-04 text-dark text-gradient text-lg opacity-10" aria-hidden="true"></i>
                                        </div>
                                        <h5 class="text-white font-weight-bolder mb-0 mt-3">
                                            <span id="lblSubmitedtlvalue"></span>
                                        </h5>
                                        <span class="text-white text-sm" id="lblSubmitedtl"></span>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-lg-6 col-md-6 col-12">
                        <div class="card zm"  style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('BPSubmitted');">
                            <span class="mask bg-gradient-dark opacity-9 border-radius-xl"></span>
                            <div class="card-body p-3 position-relative" id="div_BPSubmitted">
                                <div class="row">
                                    <div class="col-8 text-start">
                                        <div class="icon icon-shape bg-white shadow text-center border-radius-md">
                                            <i class="ni ni-paper-diploma text-dark text-gradient text-lg opacity-10" aria-hidden="true"></i>
                                        </div>
                                        <h5 class="text-white font-weight-bolder mb-0 mt-3">
                                            <span id="lblSubmittedbpvalue"></span>
                                        </h5>
                                        <span class="text-white text-sm" id="lblSubmittedbp"></span>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-12 mt-4 mt-md-0">
                        <div class="card zm"  style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('ECSubmitted');">
                            <span class="mask bg-gradient-dark opacity-9 border-radius-xl"></span>
                            <div class="card-body p-3 position-relative" id="div_ECSubmitted">
                                <div class="row">
                                    <div class="col-8 text-start">
                                        <div class="icon icon-shape bg-white shadow text-center border-radius-md">
                                            <i class="ni ni-like-2 text-dark text-gradient text-lg opacity-10" aria-hidden="true"></i>
                                        </div>
                                        <h5 class="text-white font-weight-bolder mb-0 mt-3">
                                            <span id="lblSumbittedecvalue"></span>
                                        </h5>
                                        <span class="text-white text-sm" id="lblSumbittedec"></span>
                                    </div>

                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6 col-12 mt-4 mt-lg-0">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <h6 class="mb-0">Management Feedback</h6>
                    </div>
                    <div class="card-body pb-0 p-4">
                        <ul class="list-group">
                            <li class="list-group-item border-0 d-flex align-items-center px-0 mb-0">
                                <div class="w-100">
                                    <div class="d-flex mb-2">
                                        <span class="me-2 text-sm font-weight-bold text-capitalize">Positive feedback</span>
                                        <span class="ms-auto text-sm font-weight-bold" id="lblPositive">80%</span>
                                    </div>
                                    <div>
                                        <div class="progress progress-md">
                                            <div class="progress-bar bg-gradient-info" id="div_positive" role="progressbar" aria-valuenow="60" aria-valuemin="0" aria-valuemax="100"></div>
                                        </div>
                                    </div>
                                </div>
                            </li>
                            <%-- <li class="list-group-item border-0 d-flex align-items-center px-0 mb-2">
                  <div class="w-100">
                    <div class="d-flex mb-2">
                      <span class="me-2 text-sm font-weight-bold text-capitalize">Neutral feedback</span>
                      <span class="ms-auto text-sm font-weight-bold">17%</span>
                    </div>
                    <div>
                      <div class="progress progress-md">
                        <div class="progress-bar bg-gradient-dark w-10" role="progressbar" aria-valuenow="10" aria-valuemin="0" aria-valuemax="100"></div>
                      </div>
                    </div>
                  </div>
                </li>--%>
                            <li class="list-group-item border-0 d-flex align-items-center px-0 mb-2 p-4">
                                <div class="w-100">
                                    <div class="d-flex mb-2">
                                        <span class="me-2 text-sm font-weight-bold text-capitalize">Negative feedback</span>
                                        <span class="ms-auto text-sm font-weight-bold" id="lblNegative"></span>
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
                    <div class="card-footer pt-0 p-3 d-flex align-items-center">
                        <div class="w-60">
                            <p class="text-sm">
                                More than <span style="font-weight: bold;" id="lblFeedbackprofile"></span> profiles in hunT creW's product and over <span style="font-weight: bold;" id="lblJobcreted"></span> Jobs were created.
                            </p>
                        </div>
                        <div class="w-40 text-end">
                            <a class="btn bg-gradient-dark mb-0 text-end" href="Candidate.aspx?id=NoJob">Add Candidates </a>
                        </div>
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


                        <table class="table align-items-center mb-0" id="tblCandlist">
                            <thead>
                                <tr>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"></th>
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
                                <ul id="paginus" class="pagination pagination-info">
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


    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <%--<script src="AppScripts/Job.js"></script>--%>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/CandidateList.js"></script>

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
