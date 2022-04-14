<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="AddJobcode.aspx.cs" Inherits="Recruiting_API.AddJobcode" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />

    <style>
        .btn-disable{
            background-image: linear-gradient(310deg, #d9e0e0 0%, #c3c6c7 100%);
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
            <div class="col-lg-6">
                <h4>Add Job</h4>
            </div>
        </div>
        <div class="row mt-4">
            <div class="col-lg-4">
                <div class="card h-100">
                    <div class="card-body pb-0">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <h5 class="font-weight-bolder">Job Image</h5>
                                </div>
                                <%--<div class="col-md-6" style="text-align: right;">
                                    <button class="btn bg-gradient-primary btn-sm mb-0 me-2" type="button" name="button" id="btnEdit" data-bs-toggle="modal" data-bs-target="#addimage">Change</button>
                                </div>--%>
                            </div>
                        </div>

                        <div class="col-md-12 mt-2">
                            <div class="row">
                                <div class="col-md-1">
                                </div>
                                <div class="col-md-10">
                                    <label class="">Choose Image </label><span style="color: red;">*</span>
                                    <select class="form-control form-controlnew" name="choices-emptype" id="drpChooseimage" onchange="changejobImage();">
                                    </select>
                                </div>
                                <div class="col-md-1">
                                </div>
                            </div>
                        </div>

                        <div class="row mt-3">
                            <div class="col-12 text-center">
                                <img class="w-80 border-radius-lg shadow-lg" id="imgJob" src="Images/Default_job.png" alt="product_image">
                            </div>
                            <div class="col-md-12 mt-3">
                                <label>Created On : </label>
                                <label id="lblCreatedon"></label>
                                <%--|<label id="lblCreatedtime">12:08</label>--%>
                                <input type="hidden" id="hdnCreatedOn" />
                            </div>
                            <div class="col-md-12">
                                <label>Created By : </label>
                                <label id="lblCreateby"></label>
                                <input type="hidden" id="hdnCreatedBy" />
                            </div>

                            <div class="col-md-12">
                                <label id="lbl1">Updated On :</label>
                                <label id="lblUpdateOn"></label>
                                <%--|<label id="lblUpdatetime">12:08</label>--%>
                                <input type="hidden" id="hdnUpdateon" />
                            </div>

                            <div class="col-md-12">
                                <label id="lbl2">Last Updated By :</label>
                                <label id="lblUpdateBy"></label>
                                <input type="hidden" id="hdnUpdateby" />
                            </div>



                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8 mt-lg-0 mt-4">
                <div class="card" style="height: 100%;">
                    <div class="card-body">
                         <div class="row">
                                    <div class="col-12 col-sm-6">
                        <h5 class="font-weight-bolder">Job Information</h5>
                                        </div>

                             <div class="col-12 col-sm-6">
                        <div class="form-check form-switch ms-1" style="float:right">
                             <label class="form-check-label" for="flexSwitchCheckDefault">Publish to Web</label>
                                    <input class="form-check-input" type="checkbox" name="chkPublish" checked="checked" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                   
                                </div>
                                        </div>
                             </div>
                        <div class="row">
                            <div class="col-md-12">
                                <%--<div class="row">
                                    <div class="col-md-4">
                                        <label>Job Code</label>
                                        <input class="form-control" type="text" id="txtJobcode" placeholder="Job Code" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Job Open Date</label>
                                        <input class="form-control datepicker" type="text" id="txtJobopendate" placeholder="Open Date" />
                                    </div>
                                    <div class="col-md-4">
                                        <label>Job Title</label>
                                <input class="form-control" type="text" id="txtJobtitle" placeholder="Job Title" />
                                    </div>
                                </div>--%>

                                <div class="row">
                                    <div class="col-12 col-sm-6">
                                        <label>Job Code</label>
                                        <input class="form-control" type="text" id="txtJobcode" placeholder="Job Code" />

                                    </div>
                                    <div class="col-12 col-sm-6 mt-3 mt-sm-0">
                                        <label>Job Title</label><span style="color: red;">*</span>
                                        <input class="form-control" type="text" id="txtJobtitle" placeholder="Job Title" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <label class="mt-4">Duration</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtDuration" placeholder="Duration" />
                            </div>
                            <div class="col-4">
                                <label class="mt-4">Type</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" name="choices-emptype" id="drpEmptype">
                                </select>
                            </div>
                            <div class="col-4">
                                <label class="mt-4">Location </label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" name="choices-emptype" id="drpLocation">
                                    <%--<option>Remote</option>
                                    <option>Onsite</option>
                                    <option>Remote only till Covid</option>--%>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <label class="mt-4">City</label>
                                <input class="form-control" type="text" id="txtCity" placeholder="City" />
                            </div>
                            <div class="col-4">
                                <label class="mt-4">State</label>
                                <input class="form-control" type="text" id="txtState" placeholder="State" />
                            </div>
                            <div class="col-4">
                                <label class="mt-4">Country </label><span style="color: red;">*</span>
                                <input class="form-control" type="text" id="txtCountry" placeholder="Country" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="mt-4">Client</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" name="choices-category" id="drpClient" onchange="getContactpersonData();">
                                </select>
                            </div>
                            <div class="col-sm-6">
                                <label class="mt-4">Contact Person</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" name="choices-color" id="drpCliContact">
                                    <option value="-1" disabled selected hidden>--Select Contact--</option>
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-sm-12">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-bolder">Job Description</h5>
                        <div class="col-sm-12">
                            <label class="mt-2">Description</label><span style="color: red;">*</span>
                            <textarea name="txtDec" rows="2" cols="20" id="txtJobdesc" class="form-control text-font font_size" placeholder="Description" style="height: 100px;"></textarea>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-bolder">Process</h5>
                        <label class="">Assign To</label><span style="color: red;">*</span><label> Total No. Assigned <span id="lblAssno">0</span></label>
                        
                        <select class="form-control" name="choices-sizes" id="drpAssignto" multiple style="border: 1px solid #d2d6da;border-radius:.5rem;" onchange="totAssignCount();">
                            </select>
                        <label class=""></label>
                        <div class="col-12 ">
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Priority Level</label><span style="color: red;">*</span>
                                    <select class="form-control form-controlnew" name="choices-sizes" id="drpPrioritylevel">
                                    </select>
                                </div>
                                <div class="col-md-6">
                                    <label class="">Job Status</label>
                                    <select class="form-control form-controlnew" name="choices-sizes" id="drpJobstatus" onchange="statusChange();">
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-sm-6 mt-sm-0 mt-4">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <h5 class="font-weight-bolder">Package</h5>
                            <div class="col-4">
                                <label>Type</label><span style="color: red;">*</span>
                                <select class="form-control form-controlnew" id="drpType1" onchange="disableType();">
                                </select>
                            </div>
                            <div class="col-3">
                                <label>Rate/Hr</label><span style="color: red;">*</span>
                                <input class="form-control" type="text" placeholder="0" id="txtRate1" onkeypress="return numValidation(this);"/>
                            </div>
                            <div class="col-5">
                                <label>Currency</label>
                                <select class="form-control form-controlnew" name="choices-sizes" id="drpCurrency1">
                                </select>
                            </div>
                        </div>
                        <div class="row mt-4">
                            <div class="col-4">
                                <label>Type</label>
                                <select class="form-control form-controlnew" id="drpType2">
                                </select>
                            </div>
                            <div class="col-3">
                                <label>Rate/Hr</label>
                                <input class="form-control" type="text" placeholder="0" id="txtRate2" onkeypress="return numValidation(this);"/>
                            </div>
                            <div class="col-5">
                                <label>Currency</label>
                                <select class="form-control form-controlnew" name="choices-sizes" id="drpCurrency2">
                                </select>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12">
                <div class="row">
                    <div class="col-md-6">
                        <label class="mt-4 form-label">Skills and Certification</label><span style="color: red;">*</span><br /><label>Selected Skills <span id="lblSkillsno">0</span></label>
                        <label class="form-label" id="lblSkill" style="display:none;color:red;"></label>
                    </div>
                    <div class="col-md-6 text-right">
                        <button id="btnAddskills" class="btn bg-gradient-warning p-0 mt-4" type="button" style="background: none !important; box-shadow: none !important; color: #0400ff;" data-bs-toggle="modal" data-bs-target="#addskill">
                            <span class="btn-inner--icon">Add Skill</span>
                        </button>
                    </div>
                </div>
                <div class="col-md-12">
                    <%--<textarea name="txtDec" rows="2" cols="20" id="txtSkillsandcertification" class="form-control text-font font_size" placeholder="Skills and Certification" style="height: 100px;"></textarea>--%>
                    <select class="form-control" name="choices-sizes" id="drpSkill" multiple onchange="totSkillCount();">
                    </select>
                </div>
                <div class="ms-auto my-auto mt-lg-0 mt-4">
                            <div class="ms-auto my-auto">
                                <div class="modal fade" id="addskill" tabindex="-1" aria-hidden="true" style="display: none;">
                                    <div class="modal-dialog mt-lg-10" style="max-width: 700px;">
                                        <div class="modal-content">

                                            <div class="modal-header">
                                                <h5 class="modal-title">Add Skill</h5>
                                            </div>

                                            <div class="col-md-12 p-3">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label class="form-label">Skill Name</label>
                                                    </div>
                                                    <div class="col-md-10">
                                                        <input class="form-control" type="text" placeholder="Skill" id="txtSkill">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="modal-footer mt-2">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6 text-left ps-4">
                                                            <button type="button" id="btnCancelskill" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Cancel</button>
                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button type="button" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" onclick="SaveSkill();">Save</button>
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

            <%--<div class="col-md-12 mt-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-bolder">Skills</h5>
                        <div class="col-md-12">
                            <label class="">Required Skills</label>
                            
                            <select class="form-control" name="choices-sizes" id="drpSkill" multiple="multiple">
                                       
                            </select>
                        </div>
                    </div>
                </div>
            </div>--%>


            <div class="col-md-12 mt-4">
                <div class="card">
                    <div class="card-body">
                        <h5 class="font-weight-bolder">Comments</h5>
                        <div class="row">
                            <div class="col-sm-6">
                                <label class="">Open Comments</label><span style="color: red;">*</span>
                                <textarea name="txtDec" rows="2" cols="20" id="txtOpencom" class="form-control text-font font_size" placeholder="Description" style="height: 100px;"></textarea>
                            </div>
                            <div class="col-sm-6">
                                <label class="">Close/Hold comments</label>
                                <textarea name="txtDec" rows="2" cols="20" id="txtClosecom" class="form-control text-font font_size" placeholder="Description" style="height: 100px;"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </div>

        <div class="col-md-12 mt-3">
            <div class="row">
                <div class="col-md-6">
                    <button type="button" id="btnBack" class="btn bg-gradient-secondary btn-resize" onclick="pagenav();">Back</button>
                </div>
                <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                    <button id="btnSave" type="button" class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize">Save</button>
                </div>
            </div>
        </div>

        <div class="ms-auto my-auto mt-lg-0 mt-4">
            <div class="ms-auto my-auto">
                <div class="modal fade" id="msgpopup" tabindex="-1" aria-hidden="true" style="display: none;">
                    <div class="modal-dialog" style="max-width: 300px !important; margin-top: 15rem !important;">
                        <div class="modal-content">

                            <div class="col-md-12 mt-3 text-center">
                                <p class="mb-0 h6"><span id="div-message"></span></p>
                            </div>

                            <div class="modal-footer pt-0 text-center" style="border-top: none;">
                                <div class="col-md-12">
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk">Ok</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script>
        
        function disablebtn() {
            $('#btnSave').prop('disabled', true);
            $("#btnSave").removeClass("bg-gradient-primary");
            $("#btnSave").addClass("btn-disable");
        }
    </script>

    <!-- Control Center for Soft Dashboard: parallax effects, scripts for the example pages etc -->
    <link href="assets/css/soft-ui-dashboard-pro.css" rel="stylesheet" />

    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="assets/js/Common.js"></script>

    <%--<script src="assets/js/Pro_js/popper.min.js"></script>
    <script src="assets/js/Pro_js/bootstrap.min.js"></script>
    <script src="assets/js/Pro_js/smooth-scrollbar.min.js"></script>
    <script src="assets/js/Pro_js/choices.min.js"></script>
    <script src="assets/js/Pro_js/quill.min.js"></script>
    
    <!-- Kanban scripts -->
    <script src="assets/js/Pro_js/dragula.min.js"></script>
    <script src="assets/js/Pro_js/jkanban.js"></script>--%>

    <script src="AppScripts/Job.js"></script>

    <script>
          $("#drpAssignto").select2();
          $("#drpSkill").select2();
    </script>

    <%--    <script>
        
        document.addEventListener('DOMContentLoaded', function() {
        var textRemove = new Choices(document.getElementById('choices-text-remove-button'), {
        delimiter: ',',
        editItems: true,
        maxItemCount: 5,
        removeItemButton: true,
        });
        });
    </script>--%>
    <%-- <script src="assets/js/plugins/flatpickr.min.js"></script>--%>
    <%--<script type="text/javascript">
      if (document.querySelector('.datepicker')) {
        flatpickr('.datepicker', {
          //mode: "range"
         dateFormat: "d-m-Y",
            //disable: ["30-01-2021", "21-02-2021", "08-03-2021"],
            disable:[{
            from: "01-01-2000",
            to:  new Date()
        }]
         //disable: ["2021-01-30", "2021-02-21", "2021-03-08" ],
        }); // flatpickr
      }
    </script>--%>
</asp:Content>

