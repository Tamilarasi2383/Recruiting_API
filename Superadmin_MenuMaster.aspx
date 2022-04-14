<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Superadmin_MenuMaster.aspx.cs" Inherits="Recruiting_API.Superadmin_MenuMaster" %>

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
                        <h5 class="font-weight-bolder">Menu Creation</h5>
                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <label class="form-label">Role </label>
                                <select class="form-control form-controlnew" id="drpRole">
                                </select>
                                <input type="hidden" id="hdnMenuid" />
                            </div>
                            <div class="col-md-6">
                                <label class="form-label">Region</label>
                                <select class="form-control form-controlnew" id="drpRegion">
                                </select>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div style="border-radius: 10px; /*box-shadow: 0vw 0vh 8px 2px #d8d0d0; */margin: 7px;">

                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6 class="heading-small text-muted mb-2" style="padding-top: 1.25rem; padding-bottom: 0; font-size: .90rem;">Jobs</h6>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-check form-switch mt-3" style="float: right;">
                                            <input class="form-check-input" type="checkbox" name="chkIDjob" onclick="openmenumaster();" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                            <label class="form-check-label" id="lbljobAccess"  for="flexSwitchCheckDefault">On</label>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <hr class="my-2" style="border-top: 1px solid rgba(255, 160, 109, 0.78) !important;">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">Create</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkjobCreate"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lbljobCreate" for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-1">
                                            </div>
                                            <div class="col-4">
                                                <label for="input-username">Edit</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkjobEdit"  data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lbljobEdit" for="flexSwitchCheckDefault">Off</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">View</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkjobView"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lbljobView" for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-1">
                                            </div>
                                            <div class="col-4">
                                                <label for="input-username">Feedback</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkjobFeedback"  data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lbljobFeedback" for="flexSwitchCheckDefault">Off</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6 class="heading-small text-muted mb-2" style="padding-top: 1.25rem; padding-bottom: 0; font-size: .90rem;">Vendors</h6>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-check form-switch mt-3" style="float: right;">
                                            <input class="form-check-input" type="checkbox" name="chkIDvendors" onclick="openmenumastervendors();" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                             <label class="form-check-label" id="lblVenAccess"   for="flexSwitchCheckDefault">On</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-2" style="border-top: 1px solid rgba(255, 160, 109, 0.78) !important;">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">Create</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkvendCreate"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblvenCreate" for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-1">
                                            </div>
                                            <div class="col-4">
                                                <label for="input-username">Edit</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkvendEdit"  data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblvenEdit" for="flexSwitchCheckDefault">Off</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">View</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkvendView"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblvenView" for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                    </div>
                                </div>
                            </div>


                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <h6 class="heading-small text-muted mb-2" style="padding-top: 1.25rem; padding-bottom: 0; font-size: .90rem;">Candidate</h6>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-check form-switch mt-3" style="float: right;">
                                            <input class="form-check-input" type="checkbox" name="chkIDcandidate" onclick="openmenumastercandidate();" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                            <label class="form-check-label" id="lblCanAccess"   for="flexSwitchCheckDefault">On</label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <hr class="my-2" style="border-top: 1px solid rgba(255, 160, 109, 0.78) !important;">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">Create</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkcandCreate"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblCancreate"  for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-1">
                                            </div>
                                            <div class="col-4">
                                                <label for="input-username">Edit</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkcandEdit"  data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblCanedit"  for="flexSwitchCheckDefault">Off</label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="row">
                                            <div class="col-4">
                                                <label for="input-username">View</label>
                                            </div>
                                            <div class="col-7">
                                                <div class="form-check form-switch">
                                                    <input class="form-check-input" type="checkbox" name="chkcandView"   data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                    <label class="form-check-label" id="lblCanview"  for="flexSwitchCheckDefault">On</label>
                                                </div>
                                            </div>
                                            <div class="col-1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
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
                                <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnSave" onclick="saveMenuValue();" style="float: right;">Save</button>
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
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize text-left" id="btnOk" onclick="window.location='Superadmin_MenuListMaster.aspx'">OK</button>
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
    <script src="AppScripts/MenuMaster.js"></script>


    <script>
        function openmenumaster() {
            //alert('testing');
            if ($('input[name="chkIDjob"]:checked').val() == "on") {
                enablemenujobs();
            }
            else {
                disablemenujobs();
            }
        }

        function openmenumastervendors() {
            //alert('testing');
            if ($('input[name="chkIDvendors"]:checked').val() == "on") {
                enablemenuvendors();
            }
            else {
                disablemenuvendors();
            }
        }

        function openmenumastercandidate() {
            //alert('testing');
            if ($('input[name="chkIDcandidate"]:checked').val() == "on") {
                enablemenucandidate();
            }
            else {
                disablemenucandidate();
            }
        }

        function enablemenujobs() {
            $('input[name="chkjobCreate"]').prop('disabled', false);
            $('input[name="chkjobEdit"]').prop('disabled', false);
            $('input[name="chkjobView"]').prop('disabled', false);
            $('input[name="chkjobFeedback"]').prop('disabled', false);
        }

        function disablemenujobs() {
            $('input[name="chkjobCreate"]').prop('disabled', 'disabled');
            $('input[name="chkjobEdit"]').prop('disabled', 'disabled');
            $('input[name="chkjobView"]').prop('disabled', 'disabled');
            $('input[name="chkjobFeedback"]').prop('disabled', 'disabled');
        }

        function enablemenuvendors() {
            $('input[name="chkvendCreate"]').prop('disabled', false);
            $('input[name="chkvendEdit"]').prop('disabled', false);
            $('input[name="chkvendView"]').prop('disabled', false);
        }

        function disablemenuvendors() {
            $('input[name="chkvendCreate"]').prop('disabled', 'disabled');
            $('input[name="chkvendEdit"]').prop('disabled', 'disabled');
            $('input[name="chkvendView"]').prop('disabled', 'disabled');
        }

        function enablemenucandidate() {
            $('input[name="chkcandCreate"]').prop('disabled', false);
            $('input[name="chkcandEdit"]').prop('disabled', false);
            $('input[name="chkcandView"]').prop('disabled', false);
        }

        function disablemenucandidate() {
            $('input[name="chkcandCreate"]').prop('disabled', 'disabled');
            $('input[name="chkcandEdit"]').prop('disabled', 'disabled');
            $('input[name="chkcandView"]').prop('disabled', 'disabled');
        }

        function goBack() {
            window.history.back()
        }
    </script>



</asp:Content>
