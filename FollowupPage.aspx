<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="FollowupPage.aspx.cs" Inherits="Recruiting_API.FollowupPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <img class="h-100 w-100" src="Images/loader.gif"  id="imgLoader"/>
                    </div>
                </div>
            </div>
        </section>
      </div>

    <div class="container-fluid py-4 hidden">
       

        <div class="row">
            <div class="col-12">
                <h5>Job Details</h5>
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-xl-5 col-lg-5 text-center">
                                <img class="w-100 border-radius-lg shadow-lg mx-auto" id="imgJobimage" src="Images/No-Image.png" />
                            </div>

                            <div class="col-lg-7 mx-auto">
                                <div class="col-md-12">
                                    <h3 class="mt-lg-0 mt-4"><span id="lblJobtitle"></span></h3>
                                    <h6 class="mt-lg-0 mt-4"><span id="lblJobid"></span> <span class="badge badge-sm" id="lblJobstatus"></span></h6>
                                    <h6 class="mt-lg-0 mt-4"><span id="lblMonth"></span> | <span id="lblEmptype"></span> | <span id="lblCity"></span> , <span id="lblState"></span> , <span id="lblCountry"></span> </h6>
                                </div>
                                <div class="col-md-12 mt-2">
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="mb-0 mt-3">Rate / Hr<//label>
                                                <p class="mb-0"><span id="lblRate1"></span> <img src="Images/us-dollar.png" width="15" height="15" />  |<span id="lblWorktype1"></span> </p>
                                                <p id="div_rate"><span id="lblRate2"></span> <img src="Images/us-dollar.png" width="15" height="15" /> |<span id="lblWorktype2"></span> </p>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="mb-0 mt-3">Location</label>
                                                <p style="margin-left: 3px;"><span id="lblLocation"></span> </p>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="mb-0 mt-3">Client Name</label>
                                                <p style="margin-left: 3px;"><span id="lblClientname"></span> </p>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="mb-0 mt-3">Client Contact Person</label>
                                                <p style="margin-left: 3px;"><span id="lblContactperson"></span> </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-5 mt-4">
                                        <div>
                                            <label class="">Created By</label>
                                            <p style="margin-left: 3px;"><span id="lblCreatedname"></span>  | <span id="lblcreatedate"></span> - <span id="lblcreatetime"></span> <span>EST</span></p>
                                            <label class="mt-5">Updated By</label>
                                            <p id="update_div" style="margin-left: 3px;"><span id="lblUpdatedname"></span> | <span id="lblUpdatedate"></span> - <span id="lblUpdatetime"></span> <span>EST</span></p>
                                        </div>
                                    </div>
                                    <div class="col-md-7 mt-4">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <label>Priority Level</label>
                                                    <p style="margin-left: 3px;"><span id="lblPrioritylevel"></span></p>
                                                </div>
                                                <div class="col-lg-6 mt-lg-0 mt-2">
                                                    <label>Assign To</label>
                                                    <p style="margin-left: 3px;"><span id="lblAssignto"></span></p>
                                                </div>
                                            </div>
                                        </div>
                                        <div>
                                            <label class="mt-4">Skills</label>
                                            <p style="margin-left: 3px;"><span id="lblSkill"></span></p>
                                        </div>


                                    </div>
                                </div>
                                <div>
                                    <label class="mt-5">Description</label>
                                    <p style="margin-left: 3px;"><span id="lblDescription"></span></p>
                                </div>

                                <div id="div_comm" style="display:none;">
                                    <label class="mt-5">Comments</label>
                                    <p style="margin-left: 3px;"><span id="lblComments"></span></p>
                                </div>
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
                                        </div>
                                        <div class="col-lg-6 d-flex">
                                            <button class="btn bg-gradient-primary mb-0 mt-lg-auto mt-3 ms-auto" id="btnAdd" type="button" name="button" onclick="window.location.href='Candidate.aspx'">Add Candidates</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row mt-5">
                            <div class="col-12">
                                <h5 class="ms-3">Candidate List</h5>
                                <div class="table table-responsive" style="overflow: hidden;">

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
                                        <div class="dataTable-search" style="width: 30%;">
                                            <input class="dataTable-input dataTable-input2" placeholder="Search..." type="text" id="txtSearch" style="width: 86%;" onkeyup="getCandPage();">
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
                                            <ul id="pagin" class="pagination">
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

                        <div class="col-md-12 mt-3">
                            <div class="row">
                                <div class="col-md-6">
                                    <button type="button" id="btnBack" class="btn bg-gradient-secondary btn-resize" onclick=gotoJobPage();>Back</button>
                                </div>
                                <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                                    
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
    <script src="AppScripts/Followup.js"></script>
    <script src="AppScripts/Table.js"></script>
</asp:Content>
