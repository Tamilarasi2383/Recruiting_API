<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="VendorSearch.aspx.cs" Inherits="Recruiting_API.VendorSearch" %>

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
                                <h6 class="mb-0">Vendor Search</h6>
                                <%--<p class="text-sm mb-0">Create new Vendor</p>--%>
                            </div>
                            <div class="col-md-6">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <hr class="horizontal dark my-3">

            <div class="col-md-12 card-body pt-0">
                <div class="row">
                    <div class="col-md-4">
                        <label>Specialization</label>
                        <input class="input_hide" type="text" id="hdnMailid" disabled="disabled" />
                        <select class="form-control form-controlnew" id="drpSpecialization">
                        </select>
                    </div>
                    <div class="col-md-4">
                        <label>City</label>
                        <input class="form-control" type="text" id="txtCity" placeholder="City" autocomplete="off" />
                    </div>
                    <div class="col-md-4">
                        <label>Corporation Name</label>
                        <input class="form-control" type="text" id="txtLocation" placeholder="Corporation Name" autocomplete="off" />
                    </div>
                </div>

                <div class="col-md-12 mt-3">
                    <div class="row">
                        <div class="col-md-6">
                            <button type="button" id="btnClear" class="btn bg-gradient-secondary btn-resize text-right" onclick="cleardata()">Clear</button>
                        </div>
                        <div class="col-md-6">
                            <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnSearch" onclick="getVendorPage();" style="float: right;">Search</button>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="">

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
                                <div class="col-md-6">
                                    <%--<div class="dataTable-search" style="width: 30%;">
                                        <input class="dataTable-input dataTable-input2" placeholder="Search..." type="text" id="txtSearch" style="width: 86%;" onkeyup="getJobPage();">
                                    </div>--%>
                                </div>
                            </div>
                        </div>
                    </div>

                    <table class="table align-items-center mb-0" id="tblVendorlist">
                        <thead>
                            <tr>
                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7" style="color: black; display: none;">Vendor ID</th>
                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7" style="color: black;">Vendor Name</th>
                                <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Specialization</th>
                                <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7" style="color: black;">Total No.Of Recruiter</th>
                                <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7" style="color: black;">City</th>
                                <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7" style="color: black;">Country</th>
                                <th class="text-center text-uppercase text-xxs font-weight-bolder opacity-7 text-center" style="color: black;">Status</th>
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

            <div class="modal-footer mt-2">
                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-6 text-left ps-4">
                            <%--<button type="button" id="btnCancelskill" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Cancel</button>--%>
                        </div>
                        <div class="col-md-6 text-right">
                            <button type="button" class="btn bg-gradient-primary btn-resize" id="btnGetmail" style="display: none;" data-bs-toggle="modal" onclick="getMailid();">GET Mail Id</button>
                        </div>
                    </div>
                </div>



            </div>
        </div>
    </div>

    <div class="ms-auto my-auto mt-lg-0 mt-4">
        <div class="ms-auto my-auto">
            <div class="modal fade" id="getmail" tabindex="-1" aria-hidden="true" style="display: none;">
                <div class="modal-dialog mt-lg-8" style="max-width: 700px; margin-top: 65px !important;">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Mail Id List</h5>
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                </div>
                                <div class="col-md-6">
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12 p-3" id="div_mail" style="overflow: scroll; height: 280px; overflow-x: hidden;">
                        </div>

                        <div class="modal-footer mt-2">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6 text-left ps-4">
                                        <button type="button" id="btnCanceltr" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Cancel</button>
                                    </div>
                                    <div class="col-md-6 text-right">
                                        <button type="button" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" onclick="copyemail();">Copy Mail ID</button>
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
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/VendorSearch.js"></script>



</asp:Content>
