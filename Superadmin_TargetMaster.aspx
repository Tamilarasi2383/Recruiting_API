<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_TargetMaster.aspx.cs" Inherits="Recruiting_API.Superadmin_TargetMaster" %>
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
                        <h5 class="font-weight-bolder">Target Fixing</h5>
                    </div>

                    <div class="col-md-12 mt-3">
                        <div class="row">
                            <div class="col-md-4">
                                <label class="form-label">Role</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" id="drpRole">
                                    
                                </select>
                                <input type="hidden" id="hdnTargetid" />
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Level</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" id="drpLevel">
                                   
                                </select>
                            </div>
                            <div class="col-md-4">
                                <label class="form-label">Region</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" id="drpRegion" onchange="regionChange();">
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12 mt-4 mb-3">
                        <table class="table align-items-center mb-0">
                            <thead>
                                <tr>
                                    <th></th>
                                    <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission</th>
                                    <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" id="th_target" style="color: black;display:none;">Vendor</th>
                                    <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission to TL</th>
                                    <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Submission to BP</th>
                                    <th class="text-uppercase text-xxs font-weight-bolder opacity-7 ps-2" style="color: black;">Closure</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr class="divControl">
                                    <td class="align-middle">
                                        <label class="">Daily</label>
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtcandidatedaily" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle" style="display:none;" id="td_daily">
                                        <input class="form-control" type="text" id="txtvendordaily" placeholder="Vendor" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txttldaily" placeholder="TL" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtbpdaily" placeholder="BP" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtclosuredaily" placeholder="Closure" onkeypress="return numValidation(this);" />
                                    </td>
                                </tr>

                                <tr class="divControl">
                                    <td class="align-middle">
                                        <label class="">Weekly</label>
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtcandidateweekly" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle" style="display:none;" id="td_week">
                                        <input class="form-control" type="text" id="txtvendorweekly" placeholder="Vendor" onkeypress="return numValidation(this);"  />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txttlweekly" placeholder="TL" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtbpweekly" placeholder="BP" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtclosureweekly" placeholder="Closure" onkeypress="return numValidation(this);" />
                                    </td>
                                </tr>

                                <tr class="divControl">
                                    <td class="align-middle">
                                        <label class="">Monthly</label>
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtcandidatemonthly" placeholder="Candidate" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle" style="display:none;" id="td_month">
                                        <input class="form-control" type="text" id="txtvendormonthly" placeholder="Vendor" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txttlmonthly" placeholder="TL" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtbpmonthly" placeholder="BP" onkeypress="return numValidation(this);" />
                                    </td>
                                    <td class="align-middle">
                                        <input class="form-control" type="text" id="txtclosuremonthly" placeholder="Closure" onkeypress="return numValidation(this);" />
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>

                    <%--<div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <label class="mt-4">Candidates</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtCandidates" placeholder="Candidates" onkeypress="return numValidation(this);" />
                            </div>
                            <div class="col-md-6">
                                <label class="mt-4">Submission To TL</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtSubmissiontotl" placeholder="Submission To TL" onkeypress="return numValidation(this);" />
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="mt-4">TL Approval</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtTlapproval" placeholder="TL Approval" onkeypress="return numValidation(this);" />
                                </div>
                                <div class="col-md-6">
                                    <label class="mt-4">BP Approval</label><span style="color: red;">*</span>
                                    <input class="form-control" type="text" id="txtBpapproval" placeholder="BP Approval" onkeypress="return numValidation(this);"/>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-6">
                                <label class="mt-4">EC Approval</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtEcapproval" placeholder="EC Approval" onkeypress="return numValidation(this);" />
                            </div>
                            <div class="col-md-6">
                                <label class="mt-4">Vendors</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtVendors" placeholder="Vendors" onkeypress="return numValidation(this);"/>
                            </div>
                        </div>
                    </div>--%>

                    <div class="col-md-12 mt-3">
                        <div class="row">
                            <div class="col-md-6">
                                <button type="button" id="btnBack" class="btn bg-gradient-secondary btn-resize" onclick="goBack();">Back</button>
                            </div>
                            <div class="col-md-6">
                                <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnSave" onclick="saveTargetValue();" style="float: right;">Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="ms-auto my-auto mt-lg-0 mt-4" >
            <div class="ms-auto my-auto">
                <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog"  style="max-width: 300px !important;margin-top: 15rem !important;">
                        <div class="modal-content">
                            
                            <div class="col-md-12 mt-3 text-center">
                                <p class="mb-0 h6"><span id="div-message">Are You Want to delete This</span></p>
                            </div>

                            <div class=" pt-0" style="border-top:none;padding: 0px 20px 10px 20px;display:none;" id="div_Confirm">
                                <center>
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnYes" onclick="">Yes</button>
                                    <button type="button" id="btnNo" class="btn bg-gradient-secondary mb-0 btn-resize">No</button>
                                </center>
                            </div>
                            <div class=" pt-0" style="border-top:none;padding: 0px 20px 10px 20px;display:none;" id="div_Success">
                                <center>
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnOk" onclick="window.location.href='Superadmin_TargetListMaster.aspx'">OK</button>
                                </center>
                            </div>

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
    <script src="AppScripts/TargetMaster.js"></script>


    <script>
        function goBack() {
            window.history.back()
        }
    </script>

</asp:Content>