<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Clientlist.aspx.cs" Inherits="Recruiting_API.Clientlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .colorgray {
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


    <div class="container-fluid py-4 hidden">

        <%--<div class="col-md-12">
            <div class="row">
                <div class="col-lg-6">
                    <h4>Client List</h4>
                </div>
                <div class="col-lg-6 text-right">
                    <div class="ms-auto my-auto mt-lg-0 mt-4">
                        <div class="ms-auto my-auto">
                            <button type="button" id="btnAdd" class="btn bg-gradient-primary btn-sm mb-0" onclick="window.location='Client.aspx'" style="float: right;">
                                +&nbsp; Add Client
                            </button>
                        </div>
                    </div>
                </div>
            </div>
        </div>--%>

        <div class="col-md-12 mt-3" style="display: none;">
            <div class="row">
                <div class="col-lg-3">
                    <div class="card" style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('All');">
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
                <div class="col-lg-3">
                    <div class="card " style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('TLSubmitted');">
                        <span class="mask bg-gradient-dark opacity-9 border-radius-xl"></span>
                        <div class="card-body p-3 position-relative " id="div_TLSubmitted">
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
                <div class="col-lg-3">
                    <div class="card " style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('BPSubmitted');">
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
                <div class="col-lg-3">
                    <div class="card " style="background-image: url('/assets/img/curved-images/white-curved.jpeg')" onclick="getcandidateList('ECSubmitted');">
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

        <div class="container-fluid py-4 hidden">
        <div class="row">
            <div class="col-lg-9 col-12 mx-auto">
                <div class="card card-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <h5 class="font-weight-bolder">Client List</h5>
                            </div>
                            <div class="col-md-6 text-right">
                                <button type="button" id="btnAdd" class="btn bg-gradient-primary btn-sm mb-0" onclick="window.location='Client.aspx'" style="float: right;">
                                            +&nbsp; Add Client
                                        </button>
                            </div>
                        </div>
                    </div>
                    <%--<div class="card-header pb-0 p-3">
                        <div class="row">
                            <div class="col-6 d-flex align-items-center">
                                <h5 class="ms-3"><span id="lblTableheader">Client List</span></h5>
                            </div>
                            <div class="col-6 text-end">
                                <div class="ms-auto my-auto mt-lg-0">
                                    <div class="ms-auto my-auto">
                                        <button type="button" id="btnAdd" class="btn bg-gradient-primary btn-sm mb-0" onclick="window.location='Client.aspx'" style="float: right;">
                                            +&nbsp; Add Client
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div class="row justify-content-center align-items-center">
                        <div class="mt-3">

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

                            <%--<div class="dataTable-search" style="width: 30%;">
                                <input class="dataTable-input dataTable-input2" placeholder="Search..." type="text" id="txtSearch" style="width: 86%;" onkeyup="getJobPage();">
                            </div>--%>
                        </div>

                        <div class="">
                            <div class="col-md-12">

                                <table class="table align-items-center mb-0" id="tblClientlist">
                                    <thead>
                                        <tr>
                                            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Client Name</th>
                                            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Point of Contact</th>
                                            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Place of Supply</th>
                                            <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Status</th>
                                            <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7 text-center">Action</th>
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
                </div>
            </div>
        </div>
        </div>


    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/Clientlist.js"></script>

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
    </script>


</asp:Content>
