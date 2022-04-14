﻿<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_UserList.aspx.cs" Inherits="Recruiting_API.Superadmin_UserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .styleul {
            margin: -88px !important;
            margin-top: -13px !important;
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
        <div class="row">
            <div class="col-lg-9 col-12 mx-auto">
                <div class="card card-body" id="profile">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <h5 class="font-weight-bolder">User List</h5>
                            </div>
                            <div class="col-md-6 text-right">
                                <button type="button" id="btnAdduser" class="btn bg-gradient-primary btn-sm mb-0" onclick="window.location='Superadmin_Userprofile.aspx'">
                                    +&nbsp; Add User
                                </button>
                            </div>
                        </div>
                    </div>

                    <div class="row justify-content-center align-items-center">
                        <div class="mt-3">
                            <div class="dataTable-top mt-2">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-6">
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
                                        </div>
                                        <div class="col-md-5 pe-0">
                                            <div class="dataTable-search" style="width: 100%;">
                                                <input class="dataTable-input dataTable-input2 w-100" placeholder="Search..." type="text" id="txtSearch">
                                            </div>
                                        </div>
                                        <div class="col-md-1">
                                            <i class="fas fa-redo mt-1" style="color: #26dafb; font-size: 1.5rem;" onclick="clearSearch();"></i>
                                        </div>

                                    </div>
                                </div>
                            </div>

                            <div class="">
                                <div class="col-md-12">

                                    <table class="table align-items-center mb-0" id="tblUserlist">
                                        <thead>
                                            <tr>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Name</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Region</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Role</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Level</th>
                                                <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7 text-center" style="color: black;">Action</th>
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

                        <div class="col-md-12 mt-3">
                            <div class="row">
                                <div class="col-md-6">
                                    <button type="button" id="btnBack" class="btn bg-gradient-secondary btn-resize" onclick="goBack();">Back</button>
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="ms-auto my-auto mt-lg-0 mt-4">
        <div class="ms-auto my-auto">
            <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                    <div class="modal-content">

                        <div class="col-md-12 mt-3 text-center">
                            <p class="mb-0 h6"><span id="div-message">Are You Want to delete This</span></p>
                        </div>

                        <div class=" pt-0" style="border-top: none; padding: 0px 20px 10px 20px; display: none;" id="div_Confirm">
                            <center>
                                <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnYes" onclick="">Yes</button>
                                <button type="button" id="btnNo" class="btn bg-gradient-secondary mb-0 btn-resize" data-bs-dismiss="modal">No</button>
                            </center>
                        </div>
                        <div class=" pt-0" style="border-top: none; padding: 0px 20px 10px 20px; display: none;" id="div_Success">
                            <center>
                                <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnOk" onclick="$('#msgpopup').modal('hide');">OK</button>
                            </center>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>


    <link href="assets/css/soft-ui-dashboard-pro.css" rel="stylesheet" />

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="assets/js/Common.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/UserList.js"></script>

    <script>
        function goBack() {
            window.history.back()
        }
    </script>

</asp:Content>
