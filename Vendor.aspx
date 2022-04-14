<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Vendor.aspx.cs" Inherits="Recruiting_API.Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />
    <style>
        .table td, .table td {
            white-space: none !important;
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
        <div class="mt-4">
            <div class="col-md-12">
                <div class="card">

                    <div class="card-header pb-0">
                        <div class="d-lg-flex">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6 class="mb-0">Vendor Information</h6>
                                        <p class="text-sm mb-0">Create new Vendor</p>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-check form-switch" style="float: right; padding-left: 0.5rem !important;">
                                            <input class="form-check-input ms-0" type="checkbox" name="chkVenstatus" checked="checked" onclick="notify(this)" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                        </div>
                                        <label class="form-check-label" for="flexSwitchCheckDefault" style="float: right;">Active</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="card-body p-3 col-md-12 pt-0 pb-0">
                        <div class="row mt-2">
                            <div class="col-md-6">
                                <div class="col-md-12">
                                    <label>Created On : </label>
                                    <label id="lblCreatedon"></label>
                                    <label id="lblCreatedtime"></label>
                                    <input type="hidden" id="hdnCreatedOn" />
                                </div>
                                <div class="col-md-12" style="margin-top: -10px;">
                                    <label>Created By : </label>
                                    <label id="lblCreateby"></label>
                                    <label id="lblCreatedby"></label>
                                    <input type="hidden" id="hdnCreatedBy" />
                                </div>
                            </div>
                            <div class="col-md-6 text-right">
                                <div class="col-md-12">
                                    <label id="lbl1">Updated On :</label>
                                    <label id="lblUpdateOn"></label>
                                    <%--|<label id="lblUpdatetime">12:08</label>--%>
                                    <input type="hidden" id="hdnUpdateon" />
                                </div>

                                <div class="col-md-12" style="margin-top: -10px;">
                                    <label id="lbl2">Updated By :</label>
                                    <label id="lblUpdateBy"></label>
                                    <input type="hidden" id="hdnUpdateby" />
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr class="horizontal dark my-3">

                    <div class="card-body pt-0">
                        <%--<hr class="horizontal dark my-3">--%>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Vendor Name</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtVendorname" placeholder="Vendor Name" autocomplete="off" />
                            </div>
                            <div class="col-md-4">
                                <label>Website</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtWebsite" placeholder="Website" autocomplete="off" />
                            </div>
                            <div class="col-md-4">
                                <label>Linkedin URL</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtLinkedinid" placeholder="Linkedin URL" autocomplete="off" />
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-md-4">
                                <label>Specilization</label><span style="color: red;">*</span>
                                <select class="form-control" name="choices-sizes" id="drpSpecialization" multiple>
                                    <option value="-1">--Select--</option>
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label>Address</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtAddress" placeholder="Address" autocomplete="off" />
                            </div>
                             <div class="col-md-4">
                                <label>City</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtCity" autocomplete="off" placeholder="Location" />
                            </div>
                        </div>

                        <div class="row mt-3">                           
                            <div class="col-md-4">
                                <label>Country</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtCountry" placeholder="Country" autocomplete="off" />
                            </div>
                            <div class="col-md-4">
                                <label>Vendor Type</label><span style="color: red;">*</span>
                                <select class="form-control" name="choices-sizes" id="drpVendor">
                                    <option value="-1">--Select--</option>
                                    <option value="1">Preferred</option>
                                    <option value="2">First Time</option>
                                    <option value="3">Others</option>
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label>Remarks</label>
                                <textarea name="txtComm" rows="2" cols="20" id="txtComments" class="form-control text-font font_size" placeholder="Remarks" style="height: 100px;"></textarea>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row gx-4 mt-4">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-header p-3 pb-0 ">
                                <h6 class="mb-1">Add Recruiter</h6>
                            </div>
                            <hr class="horizontal dark my-3">
                            <div class="card-body p-3 pt-0">
                                <div class="col-md-12">
                                    <label>Recruiter Name</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtRecruitername" placeholder="Recruiter Name" autocomplete="off" />
                                    <input type="hidden" id="hdnrowMode" />
                                    <input type="hidden" id="hdnVenconId" />
                                </div>
                                <div class="col-md-12">
                                    <label>Email</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtEmail" placeholder="Email" autocomplete="off" onblur="ValidateEmail('txtEmail');"/>
                                </div>
                                <div class="col-md-12">
                                    <label>Contact No.</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtContactno" placeholder="Contact No." autocomplete="off" />
                                </div>
                                <div class="col-md-12">
                                    <label>Designation/Remarks</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtDesignationremarks" placeholder="Designation/Remarks" autocomplete="off" />
                                </div>
                                <div class="col-md-12 mt-3">
                                    <div class="row">
                                        <div class="col-md-6 ">
                                            <div class="form-check form-switch" style="float: left; padding-left: 0.5rem !important;">
                                                <input class="form-check-input ms-0" type="checkbox" name="chkstatus" checked="checked" onclick="notify(this)" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                            </div>
                                            <label class="form-check-label" for="flexSwitchCheckDefault" style="float: left;">Active</label>
                                        </div>
                                        <div class="col-md-6 text-right">
                                            <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnAdd" onclick="createTable();">Add</button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-8 mt-md-0 mt-4">
                        <div class="card">
                            <div class="card-header p-3 pb-0">
                                <h6 class="mb-1">Recruiter List
                                </h6>
                            </div>
                            <hr class="horizontal dark my-3">
                            <div class="card-body p-3 pt-0">
                                <div class="card-body pt-0 p-3">
                                    <table class="table align-items-center mb-0" id="tblVenConlist">
                                        <thead>
                                            <tr>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 pt-0 ps-2" style="color: black !important;">Recruiter Name</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 pt-0 ps-2" style="color: black !important;">Email</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 pt-0 ps-2" style="color: black !important;">Contact No</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 pt-0 ps-2" style="color: black !important;">Designation/Remarks</th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 pt-0 ps-2" style="color: black !important;"></th>
                                                <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2" style="color: black !important; padding-right: 0px;">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                        </tbody>
                                    </table>
                                </div>
                                <div class="dataTable-bottom">
                                    <div class="dataTable-info" id="divInfo"></div>
                                    <nav>
                                        <ul id="paginus" class="pagination">
                                        </ul>
                                    </nav>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12 mt-3">
                        <div class="row">
                            <div class="col-md-6">
                                <button type="button" id="btnBack" class="btn bg-gradient-secondary btn-resize" onclick="window.location.href='Vendorlist.aspx'">Back</button>
                            </div>
                            <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                                <button id="btnSave" type="button" class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="ValidateVendor() ">Save</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>


    </div>

    <div class="ms-auto my-auto mt-lg-0 mt-4">
        <div class="ms-auto my-auto">
            <div class="modal fade open" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                    <div class="modal-content">
                        <div class="col-md-12 mt-3 text-center">
                            <p class="mb-0 h6"><span id="div-message"></span></p>
                        </div>

                        <div class="modal-footer pt-0 text-center" style="border-top: none;">
                            <div class="col-md-12">
                                <center><button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk">Ok</button></center>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6" id="btn_Div1">
                                    </div>
                                    <div class="col-md-6" id="btn_Div2">
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
    <script src="AppScripts/Vendor.js"></script>
    <script>
        $("#drpSpecialization").select2();
    </script>

</asp:Content>
