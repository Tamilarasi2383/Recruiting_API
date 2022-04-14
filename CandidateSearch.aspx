<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="CandidateSearch.aspx.cs" Inherits="Recruiting_API.CandidateSearch" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />

    <style>
        .input_hide {
            border: none;
            color: white;
            background-color: white;
        }

            .input_hide:focus {
                border: none;
                color: white;
            }

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



    <div class="container-fluid py-4 col-md-12 pt-0 hidden">
        <div class="card">

            <div class="card-header pb-0">
                <div class="d-lg-flex">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <h6 class="mb-0">Candidate Search</h6>
                                <%--<p class="text-sm mb-0">Create new Vendor</p>--%>
                            </div>
                            <div class="col-md-6 text-right">
                                <span class="h6">Total Candidates:</span>
                                <span class="h6" id="lblCandidatecount"></span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="horizontal dark my-3">

            <div class="col-md-12 card-body pt-0 pb-0">
                <div class="col-md-12">
                    <label>Specialization</label>
                    <select class="form-control form-controlnew" id="drpSkill" name="choices-sizes" multiple>
                        <option value="-1">--Select--</option>
                    </select>
                </div>
                <div class="row mt-2">
                    <div class="col-md-4">
                        <label>Location</label>
                        <input class="form-control" type="text" id="txtLocation" placeholder="Location" autocomplete="off" />
                    </div>
                    <div class="col-md-4">
                        <label>Years Of Experience</label>
                        <select class="form-control form-controlnew" id="drpYrsofExp">
                            <option value="-1">--Select--</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                            <option value="10">10</option>
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label>Visa Status</label>
                        <select class="form-control form-controlnew" id="drpVisastatus">
                        </select>
                    </div>
                </div>

                <div class="row mt-2">
                    <div class="col-md-4">
                        <label>Candidate Email</label>
                        <input class="form-control" type="text" id="txtCandidatemailid" placeholder="Candidate Email" autocomplete="off" />
                    </div>
                    <div class="col-md-4">
                        <label>Recruiter Rating</label>
                        <select class="form-control form-controlnew" id="drpRating">
                            <option value="-1">--Select--</option>
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                        </select>
                    </div>
                    <div class="col-md-4">
                    </div>
                </div>

                <div class="col-md-12 mt-3">
                    <div class="row">
                        <div class="col-md-6">
                            <button type="button" id="btnClear" class="btn bg-gradient-secondary btn-resize text-right" onclick="cleardata()">Clear</button>
                        </div>
                        <div class="col-md-6">
                            <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnSearch" onclick="getCandidatePage();" style="float: right;">Search</button>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="horizontal dark my-3">

            <div class="">

                <div class="dataTable-top mt-2">

                    <div class="dataTable-dropdown" style="float:left;">
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

                   
                </div>

                    <table class="table align-items-center mb-0" id="tblCandlist">
                        <thead>
                            <tr>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Candidate Name</th>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Email ID</th>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Specialization</th>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Location</th>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Yrs Of Exp</th>
                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Action</th>
                            </tr>
                        </thead>
                        <tbody>
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



    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/CandidateSearch.js"></script>

    <script>
        $("#drpSkill").select2();
    </script>
</asp:Content>
