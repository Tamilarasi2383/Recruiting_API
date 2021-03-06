<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="Candidate.aspx.cs" Inherits="Recruiting_API.Candidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="assets/css/Select2.css" rel="stylesheet" />

    <style>
        .ratechecked {
            color: #ffc400;
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
        .zm:hover {
    color:#7abff3 !important;
    transform: scale(0.9);
    box-shadow: none;
    cursor:pointer;
   

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

    <div class="container-fluid py-4 hidden" style="background-image: url(assets/img/curved-images/Whitw-Cover.jpg);">
        <div class="row">
            <div class="col-lg-9 col-12 mx-auto">
                <div class="card card-body mt-4">

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <h6 class="mb-0">New Candidate</h6>
                                <p class="text-sm mb-0">Create new candidate</p>
                            </div>
                            <div class="col-md-6">
                                <div class="d-flex px-2 py-1">
                                    <div class="col-md-12">
                                        <div class="row" id="div_job1">
                                            <div class="col-md-10">
                                                <div class="d-flex flex-column justify-content-center text-right">
                                                    <label style="margin-bottom: -7px;">
                                                        <input type="hidden" id="hdnJobid" />
                                                        <input type="hidden" id="hdnCandStatus" />
                                                        <span class="mb-0 text-sm h6" id="lblJobtitle1"></span></label>
                                                    <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblDuration1"></span> | <span class="text-xs text-secondary mb-0" id="lblType1"></span> | <span class="text-xs text-secondary mb-0" id="lblWorkingtype1"></span></p>
                                                </div>
                                            </div>
                                            <div class="col-md-2">
                                                <div>
                                                    <img id="imgJob1"  class="avatar avatar-sm me-3">
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr class="horizontal dark my-3">
                    <div class="row">
                        <div class="col-6">                            
                            <label class="form-label">Email ID</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Enter Candidate's Email ID" id="txtEmailid" onblur="setGenuinityCandidate();"><%--onblur="ValidateEmail('txtEmailid');"--%>
                        </div>
                        <div class="col-6">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="form-label">Contact Number </label>
                                        <span style="color: red;">*</span>
                                    </div>
                                    <%--<div class="col-md-6 text-right">
                                        <button id="btUCheck" class="btn bg-gradient-primary mb-0 p-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="checkifCandExists();">
                                                <span class="btn-inner--icon"><i class="fas fa-user-check" style="font-size: 20px;margin-right: 10px;"></i></span>
                                            </button>
                                    </div>--%>
                                </div>
                            </div>
                            <input class="form-control" type="text" placeholder="Enter Candidate's contact number" id="txtContactno" onkeypress="return numValidation(this);" onblur="setGenuinityCandidate();">
                        </div>
                    </div>

                    <div class="col-md-12 mt-4">
                        <div class="row">
                            <div class="col-md-6">
                            </div>
                            <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                                <button id="btnCheck" type="button" class="btn bg-gradient-primary btn-sm mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 btn-resize" onclick="checkifCandExists();">Check</button>

                                <button id="btnCheckhid" type="button" class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0" data-bs-toggle="modal" data-bs-target="#check" style="display: none;">Check</button>
                            </div>

                            <div class="ms-auto my-auto mt-lg-0 mt-4">
                                <div class="ms-auto my-auto">
                                    <div class="modal fade" id="check" tabindex="-1" aria-hidden="true" style="display: none;">
                                        <div class="modal-dialog mt-lg-10">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title">Check Candidate</h5>
                                                </div>
                                                <div class="col-md-12 mt-3 text-center">
                                                    <p><span id="lblmsg1">This Candidate already exists in the database.</span></p>
                                                </div>

                                                <div class="col-md-12 text-center">
                                                    <p><span id="lblmsg2">If you wish to use the same candidate.Press Continue</span></p>
                                                </div>
                                                <div class="modal-footer mt-2">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-6 text-left">
                                                                <button type="button" id="btnClose" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal" onclick="enableControls();">Close</button>
                                                            </div>
                                                            <div class="col-md-6 text-right" id="div_continue">
                                                                <button type="button" class="btn bg-gradient-primary btn-resize" id="btnApplydur" onclick="fillData();" >Continue</button>
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

                    <div class="col-md-12">
                        <label for="projectName" class="form-label mt-2">Candidate Name</label><span style="color: red;">*</span>
                        <input type="text" class="form-control" id="txtCandidatename" placeholder="Candidate Name" onblur="setGenuinityCandidate();">
                    </div>

                    <div class="row mt-4">
                        <div class="col-4">
                            <label class="form-label">Current Location</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Curent Location" id="txtCurrentlocation">
                        </div>
                        <div class="col-4">
                            <label class="form-label">Visa Status</label><span style="color: red;">*</span>
                            <%--<input class="form-control" type="text" placeholder="Visa Status" id="txtVisastatus">--%>
                            <select class="form-control form-controlnew" name="choices-emptype" id="drpVisastatus">
                            </select>
                        </div>
                        <div class="col-4">
                            <label class="form-label">Total years of experience</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Years of Experience" id="txtExperience" onkeypress="return numValidation(this);">
                        </div>
                    </div>

                    <%--<div class="row">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <label class="form-label">Document Type</label>
                                    <input class="form-control" type="text" placeholder="Document Type" id="txtDocumenttype">
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label">ID No.</label>
                                    <input class="form-control" type="text" placeholder="Id Number" id="txtIdno">
                                </div>
                            </div>
                        </div>
                    </div>--%>

                    <div class="row mt-4">
                        <div class="col-6">
                            <label class="form-label">Rate/Hr</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Enter in $" id="txtRate" onkeypress="return numValidation(this);">
                        </div>
                        <div class="col-6">
                            <label class="form-label">Type</label><span style="color: red;">*</span>
                            <select class="form-control form-controlnew" name="choices-emptype" id="drpType">
                            </select>
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-10 col-md-6">
                            <div class="form-group">
                                <label>
                                    Rate Coverage 
                                </label>
                                <p class="form-text text-muted text-xs ms-1">
                                    Make sure, this rate is inclusive of all expenses
                                </p>
                                <div class="form-check form-switch ms-1">
                                    <input class="form-check-input" type="checkbox" name="chkID" checked="checked" onclick="notify(this)" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                    <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                </div>
                            </div>
                        </div>
                        <div class="col-10 col-md-6">
                            <div class="form-group">
                                <label>
                                    Relocate 
                                </label>
                                <p class="form-text text-muted text-xs ms-1">
                                    Make sure, candidates Willing to relocate or only remote
                                </p>
                                <div class="form-check form-switch ms-1">
                                    <input class="form-check-input" type="checkbox" name="chkRelocate" onclick="notify(this)" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                    <label class="form-check-label" for="flexSwitchCheckDefault"></label>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <label class="mt-4 form-label">Skills and Certification</label><span style="color: red;">*</span>
                                <label class="form-label" style="font-size: .60rem; color: #bdc4ca;">Add Atleast Five Skills</label>
                            </div>
                            <div class="col-md-6 text-right">
                                <button id="btnAddskills" class="btn bg-gradient-warning p-0 mt-4" type="button" style="background: none !important; box-shadow: none !important; color: #0400ff;" data-bs-toggle="modal" data-bs-target="#addskill">
                                    <span class="btn-inner--icon">Add Skill</span>
                                </button>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <%--<textarea name="txtDec" rows="2" cols="20" id="txtSkillsandcertification" class="form-control text-font font_size" placeholder="Skills and Certification" style="height: 100px;"></textarea>--%>
                            <select class="form-control" name="choices-sizes" id="drpSkill" multiple>
                            </select>
                            <label style="color: red; display: none;" id="lblAddatlest">Add Atleast Five Skills</label>
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

                    <%--<label class="mt-2 form-label">Skills and Certification</label>
                    <textarea name="txtDec" rows="2" cols="20" id="txtSkillsandcertification" class="form-control text-font font_size" placeholder="Skills and Certification" style="height: 100px;"></textarea>--%>

                    <label for="projectName" class="form-label mt-4">Active LinkedIn URL</label>
                    <input type="text" class="form-control" id="txtActivelinkedinurl" placeholder="LinkedIN URL">

                    <div class="row mt-4">
                        <div class="col-md-6">
                            <label class="form-label">Notice Period</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Enter in days" id="txtNoticeperiod">
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Available for Interview</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Available for Interview" id="txtAvailabelinterview">
                        </div>
                    </div>

                    <div class="row mt-4">
                        <div class="col-6">
                            <label class="form-label">Employer's Email ID</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Enter Employer's Email ID" id="txtEmpmailid" onblur="ValidateEmail('txtEmpmailid');">
                        </div>
                        <div class="col-6">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="form-label">Employer's Contact Number</label><span style="color: red;">*</span>
                                    </div>

                                </div>
                            </div>
                            <input class="form-control" type="text" placeholder="Enter Employer's contact number" id="txtEmpcontnumber">
                        </div>



                    </div>

                    <div class="col-md-12 mt-4">
                        <div class="row">
                            <div class="col-md-6">
                            </div>
                            <div class="col-lg-6 text-right d-flex flex-column justify-content-center">
                                <button id="btUCheckcontactno" type="button" class="btn bg-gradient-primary btn-sm mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 btn-resize" onclick="checkifEmplExists();">Check</button>

                            </div>

                            <div class="ms-auto my-auto mt-lg-0 mt-4">
                                <div class="ms-auto my-auto">
                                    <div class="modal fade" id="checkEmp" tabindex="-1" aria-hidden="true" style="display: none;">
                                        <div class="modal-dialog mt-lg-10">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <h5 class="modal-title">Check Employer</h5>
                                                </div>
                                                <div class="col-md-12 mt-3 text-center">
                                                    <p><span id="lblmsgEmp1">This Employer already exists in the database.</span></p>
                                                </div>

                                                <div class="col-md-12 text-center">
                                                    <p><span id="lblmsgEmp2">If you wish to use the same Employer.Press Continue</span></p>
                                                </div>
                                                <div class="modal-footer mt-2">
                                                    <div class="col-md-12">
                                                        <div class="row">
                                                            <div class="col-md-6 text-left">
                                                                <button type="button" id="btnEmpClose" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal" onclick="enableemplcontrols();">Close</button>
                                                            </div>
                                                            <div class="col-md-6 text-right" id="div_emplcontinue">
                                                                <button type="button" class="btn bg-gradient-primary btn-resize" id="btnApplyEmpl" onclick="fillEmpData();">Continue</button>
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


                    <div class="row mt-4">
                        <div class="col-md-6">
                            <label for="Employer Name" class="form-label">Employer Name</label><span style="color: red;">*</span>
                            <input type="hidden" id="hdnEmployerid">
                            <input type="text" class="form-control" id="txtEmpname" placeholder="Employer Name">
                        </div>
                        <div class="col-md-6">
                            <label class="form-label">Corporation Name</label><span style="color: red;">*</span>
                            <input class="form-control" type="text" placeholder="Corporation Name" id="txtCorpationname">
                        </div>
                    </div>

                    <div class="col-md-12">
                        <label for="projectName" class="form-label mt-4">Specialization</label><span style="color: red;">*</span>
                        <%--<input type="text" class="form-control" id="txtSpecilization" placeholder="Specilization">--%>

                        <select class="form-control" name="choices-sizes" id="drpSpecialization" multiple>
                        </select>
                        <label class="mb-0" style="color: red; display: none;" id="lblvaliSpecialization">Add Atleast One Specialization</label>
                    </div>

                    <div class="col-md-12">
                        <label class="mt-4">Employer Added Information</label><span style="color: red;">*</span>
                        <textarea name="txtDec" rows="2" cols="20" id="txtEmpaddinfo" class="form-control text-font font_size" placeholder="Added Information" style="height: 100px;"></textarea>
                    </div>


                    <div class="col-md-12 mt-3">
                        <button type="button" name="button" class="btn bg-gradient-primary m-0 ms-2 btn-resize" id="btnRtr" data-bs-toggle="modal" data-bs-target="#rtr" style="float: right;" onclick="getRTRdata();">Get RTR</button>

                        <div class="ms-auto my-auto mt-lg-0 mt-4">
                            <div class="ms-auto my-auto">
                                <div class="modal fade" id="rtr" tabindex="-1" aria-hidden="true" style="display: none;">
                                    <div class="modal-dialog mt-lg-8" style="max-width: 700px;">
                                        <div class="modal-content">

                                            <div class="modal-header">
                                                <h5 class="modal-title">Content Preview</h5>
                                            </div>

                                            <div class="col-md-12 p-3">
                                                <div class="row">
                                                    <div class="col-md-2">
                                                        <label class="form-label">Subject</label>
                                                    </div>
                                                    <div class="col-md-10">
                                                        <input class="form-control" type="text" placeholder="Subject" id="txtSubject">
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-md-12 p-3" style="margin-top: -24px;">
                                                <label class="">Mail Content</label>
                                                <textarea id="txtMailcont" class="form-control col-12" style="height: 200px; overflow: scroll; overflow-x: hidden;">
                                                </textarea>
                                            </div>

                                            <div class="modal-footer mt-2">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6 text-left ps-4">
                                                            <button type="button" id="btnCanceltr" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Cancel</button>
                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button type="button" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" onclick=" return  popup()">Continue</button>
                                                        </div>
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
                                <div class="modal fade" id="rtrmailview" tabindex="-1" aria-hidden="true" style="display: none;">
                                    <div class="modal-dialog mt-lg-8" style="max-width: 700px;">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title">Mail Preview</h5>
                                            </div>

                                            <div class="col-md-12 p-3" style="margin-top: -24px;">
                                                <label class="">Mail Preview</label>
                                                <div id="txtMaildescriptioncont" class="form-control col-12" style="height: 200px; overflow: scroll; overflow-x: hidden;">
                                                </div>
                                            </div>

                                            <div class="modal-footer mt-2">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6 text-left ps-4">
                                                            <button type="button" id="btnCanceltrview" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Cancel</button>
                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button type="button" class="btn bg-gradient-primary btn-resize" data-bs-toggle="modal" onclick=" return  popupcontinue()">Continue</button>
                                                        </div>
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
                                <div class="modal fade" id="rtrcontinue" tabindex="-1" aria-hidden="true" style="display: none;">
                                    <div class="modal-dialog mt-lg-4" style="max-width: 700px;">
                                        <div class="modal-content">
                                            <div class="modal-header">
                                                <h5 class="modal-title">RTR Info</h5>
                                            </div>
                                            <div class="col-md-12 p-3">
                                                <div class="row">
                                                    <div class="col-md-6" style="margin-top: -16px;">
                                                        <label class="form-label">From</label>
                                                        <input type="text" class="form-control" id="txtMailFrom" placeholder="Mail ID" disabled="disabled">
                                                    </div>

                                                    <div class="col-md-6" style="margin-top: -16px;">
                                                        <label class="form-label">To</label>
                                                        <input type="text" class="form-control" id="txtMailto" placeholder="Mail ID">
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="col-md-12 p-3" style="margin-top: -26px;">
                                                <label class="form-label">CC</label>
                                                <input type="text" class="form-control" id="txtCC" placeholder="Mail ID" disabled="disabled">
                                            </div>

                                            <div class="col-md-12 p-3" style="margin-top: -26px;">
                                                <label class="form-label">Subject</label>
                                                <input class="form-control" type="text" placeholder="Subject" id="txtsubject" disabled="disabled">
                                            </div>

                                            <div class="col-md-12 p-3" style="margin-top: -26px;">
                                                <label class="">Mail Content</label>
                                                <div id="txtMaildescription" class="form-control col-12" style="height: 200px; overflow: scroll; overflow-x: hidden;">
                                                </div>
                                                <%--<textarea name="txtDec" rows="2" cols="20" id="txtMaildescription" class="form-control text-font font_size" placeholder="" style="height: 100px;" disabled="disabled"></textarea>--%>
                                            </div>

                                            <div class="modal-footer mt-2">
                                                <div class="col-md-12">
                                                    <div class="row">
                                                        <div class="col-md-6 text-left ps-4">
                                                            <button type="button" id="btnClosertr" class="btn bg-gradient-secondary btn-resize" data-bs-dismiss="modal">Close</button>
                                                        </div>
                                                        <div class="col-md-6 text-right">
                                                            <button type="button" class="btn bg-gradient-primary btn-resize" id="btnSend" onclick="sendRTRMail();">Send</button>
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

                    <div class="col-md-12">
                        <label>Candidate Remarks</label><span style="color: red;">*</span>
                        <textarea name="txtDec" rows="2" cols="20" id="txtCandidateremark" class="form-control text-font font_size" placeholder="Candidate Remarks" style="height: 100px;"></textarea>
                    </div>


                    <div class="col-md-12 mt-3">
                        <label>Recruiter Rating</label><span style="color: red;">*</span>
                        
                        <div class="col-12 pl-0" id="mgrRatingDiv">
                            <span id='mrat_1' class="fa fa-star" onclick="rateUser(this);"></span>
                            <span id='mrat_2' class="fa fa-star" onclick="rateUser(this);"></span>
                            <span id='mrat_3' class="fa fa-star" onclick="rateUser(this);"></span>
                            <span id='mrat_4' class="fa fa-star" onclick="rateUser(this);"></span>
                            <span id='mrat_5' class="fa fa-star" onclick="rateUser(this);"></span>
                            <span id="starRating">0</span>
                            &nbsp;<span>Rating <label class="mb-0" style="color: red; display: none;margin-left: 20px;" id="vali_star">Please Rate the Candidate</label></span>
                        </div>
                        
                    </div>

                    <div class="col-md-12 form-control mt-4" id="divFile">
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Documents</label><span style="color: red;">*</span>
                                </div>
                                <div class="col-md-6">
                                    <label class="form-label" style="color: #fa9b7e;">Supported Documents: .doc,.docx,.pdf &nbsp;&nbsp; & &nbsp;&nbsp; File Size: Max 2MB</label>
                                </div>
                                <div class="col-md-3 text-right">
                                    <button id="btnAdd" class="btn bg-gradient-warning mb-0 ps-0 pt-1" type="button" style="background: none !important; box-shadow: none !important; color: #0400ff; padding: 0;" onclick="AddMore();" disabled="disabled">
                                        <span class="btn-inner--icon">Add Documents</span>
                                    </button>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12" style="height: 70px;" id="divAttach1">
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Document Type</label>
                                    <input type="hidden" id="proofId1" />
                                    <%--<input class="form-control" type="text" placeholder="Document Type" id="txtDocumenttype">--%>
                                    <select class="form-control form-controlnew" id="drpDocumenttype1">
                                        <option selected>Resume</option>
                                        <option disabled>Driving Licence</option>
                                        <option disabled>Visa</option>
                                        <option disabled>Others</option>
                                    </select>

                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">ID No.</label>
                                    <input class="form-control form-controlnew" type="text" placeholder="Id Number" id="txtIdno1" disabled="disabled">
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="margin-top: 36px;">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-10" id="div_Filename1" style="display:none;">
                                                    <span id="lblFilename1"></span>
                                                </div>
                                                <div class="col-md-2">
                                                    <form action="" id="dropBasic1" style="min-height: 117px !important;">
                                                        <button id="btnAttach1" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('1');">
                                                            <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                        </button>
                                                        <input name="file" id="fileupload1" type="file" style="display: none;" />
                                                    </form>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="col-md-2">
                                            <button id="btUpload1" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc; display: none;">
                                                <span class="btn-inner--icon"><i class="fas fa-upload" style="font-size: 20px;"></i></span>
                                            </button>
                                            <button id="btremove1" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;display:none;">
                                                <span class="btn-inner--icon"><i class="fas fa-times-circle" style="font-size: 20px;" title="Delete Uploaded File"></i></span>
                                            </button>
                                        </div>
                                        <div class="col-md-2">
                                            
                                            <button id="btdelete1" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;display:none;" >
                                                <span class="btn-inner--icon"><i class="fas fa-trash-alt" style="font-size: 20px;"></i></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                        <div class="col-md-12" style="height: 70px; display: none;" id="divAttach2">
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Document Type</label>
                                    <input type="hidden" id="proofId2" />
                                    <%--<input class="form-control" type="text" placeholder="Document Type" id="txtDocumenttype">--%>
                                    <select class="form-control form-controlnew" id="drpDocumenttype2">
                                        <option value='-1'>--Select Document Type--</option>
                                        <option disabled>Resume</option>
                                        <option>Driving Licence</option>
                                        <option>Visa</option>
                                        <option>Others</option>
                                    </select>

                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">ID No.</label>
                                    <input class="form-control" type="text" placeholder="Id Number" id="txtIdno2">
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="margin-top: 36px;">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-10" id="div_Filename2" style="display:none;">
                                                    <span id="lblFilename2"></span>
                                                </div>
                                                <div class="col-md-2">
                                                    <form action="" id="dropBasic2" style="min-height: 117px !important;">
                                                        <button id="btnAttach2" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('2');">
                                                            <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                        </button>
                                                        <input name="file" id="fileupload2" type="file" style="display: none;" />
                                                    </form>
                                                </div>
                                            </div>
                                        </div>

<%--                                        <div class="col-md-10">
                                            <form action="" id="dropBasic2" style="min-height: 117px !important;">
                                                <button id="btnAttach2" class="btn bg-gradient-primary mb-0 ps-0 pt-0 p-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('2');">
                                                    <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                </button>
                                                <span id="lblFilename2"></span>
                                                <input name="file" id="fileupload2" type="file" style="display: none;" />
                                            </form>
                                        </div>--%>

                                        <div class="col-md-2">
                                            <button id="btUpload2" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc; display: none;">
                                                <span class="btn-inner--icon"><i class="fas fa-upload" style="font-size: 20px;"></i></span>
                                            </button>
                                            <button id="btremove2" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;display:none;">
                                                <span class="btn-inner--icon"><i class="fas fa-times-circle" style="font-size: 20px;" title="Delete Uploaded File"></i></span>
                                            </button>
                                        </div>
                                        <div class="col-md-2">
                                            
                                            <button id="btdelete2" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;" onclick="removeDocuments();">
                                                <span class="btn-inner--icon"><i class="fas fa-trash-alt" style="font-size: 20px;" title="Delete Row"></i></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                        <div class="col-md-12" style="height: 70px; display: none;" id="divAttach3">
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Document Type</label>
                                    <input type="hidden" id="proofId3" />
                                    <%--<input class="form-control" type="text" placeholder="Document Type" id="txtDocumenttype">--%>
                                    <select class="form-control" id="drpDocumenttype3">
                                        <option value='-1'>--Select Document Type--</option>
                                        <option disabled>Resume</option>
                                        <option>Driving Licence</option>
                                        <option>Visa</option>
                                        <option>Others</option>
                                    </select>

                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">ID No.</label>
                                    <input class="form-control" type="text" placeholder="Id Number" id="txtIdno3">
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="margin-top: 36px;">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-10" id="div_Filename3" style="display:none;">
                                                    <span id="lblFilename3"></span>
                                                </div>
                                                <div class="col-md-2">
                                                    <form action="" id="dropBasic3" style="min-height: 117px !important;">
                                                        <button id="btnAttach3" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('3');">
                                                            <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                        </button>
                                                        <input name="file" id="fileupload3" type="file" style="display: none;" />
                                                    </form>
                                                </div>
                                            </div>
                                        </div>


                                        <%--<div class="col-md-10">
                                            <form action="" id="dropBasic3" style="min-height: 117px !important;">
                                                <button id="btnAttach3" class="btn bg-gradient-primary mb-0 ps-0 pt-0 p-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('3');">
                                                    <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                </button>
                                                <span id="lblFilename3"></span>
                                                <input name="file" id="fileupload3" type="file" style="display: none;" />
                                            </form>
                                        </div>--%>

                                        <div class="col-md-2">
                                            <button id="btUpload3" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc; display: none;">
                                                <span class="btn-inner--icon"><i class="fas fa-upload" style="font-size: 20px;"></i></span>
                                            </button>
                                            <button id="btremove3" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;display:none;">
                                                <span class="btn-inner--icon"><i class="fas fa-times-circle" style="font-size: 20px;" title="Delete Uploaded File"></i></span>
                                            </button>

                                        </div>
                                        <div class="col-md-2">
                                            
                                            <button id="btdelete3" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;" onclick="removeDocuments();">
                                                <span class="btn-inner--icon"><i class="fas fa-trash-alt" style="font-size: 20px;" title="Delete Row"></i></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>

                        <div class="col-md-12" style="height: 70px; display: none;" id="divAttach4">
                            <div class="row">
                                <div class="col-md-3">
                                    <label class="form-label">Document Type</label>
                                    <input type="hidden" id="proofId4" />
                                    <%--<input class="form-control" type="text" placeholder="Document Type" id="txtDocumenttype">--%>
                                    <select class="form-control" id="drpDocumenttype4">
                                        <option value='-1'>--Select Document Type--</option>
                                        <option disabled>Resume</option>
                                        <option>Driving Licence</option>
                                        <option>Visa</option>
                                        <option>Others</option>
                                    </select>

                                </div>
                                <div class="col-md-3">
                                    <label class="form-label">ID No.</label>
                                    <input class="form-control" type="text" placeholder="Id Number" id="txtIdno4">
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="margin-top: 36px;">
                                        <div class="col-md-8">
                                            <div class="row">
                                                <div class="col-md-10" id="div_Filename4" style="display:none;">
                                                    <span id="lblFilename4"></span>
                                                </div>
                                                <div class="col-md-2">
                                                    <form action="" id="dropBasic4" style="min-height: 117px !important;">
                                                        <button id="btnAttach4" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('4');">
                                                            <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                        </button>
                                                        <input name="file" id="fileupload4" type="file" style="display: none;" />
                                                    </form>
                                                </div>
                                            </div>
                                        </div>

                                        <%--<div class="col-md-10">
                                            <form action="" id="dropBasic4" style="min-height: 117px !important;">
                                                <button id="btnAttach4" class="btn bg-gradient-primary mb-0 ps-0 pt-0 p-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc;" onclick="uploadFile('4');">
                                                    <span class="btn-inner--icon"><i class="fa fa-paperclip" aria-hidden="true" style="font-size: 20px;"></i></span>
                                                </button>
                                                <span id="lblFilename4"></span>
                                                <input name="file" id="fileupload4" type="file" style="display: none;" />
                                            </form>
                                        </div>--%>

                                        <div class="col-md-2">
                                            <button id="btUpload4" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color: #21dcfc; display: none;">
                                                <span class="btn-inner--icon"><i class="fas fa-upload" style="font-size: 20px;"></i></span>
                                            </button>
                                            <button id="btremove4" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;display:none;">
                                                <span class="btn-inner--icon"><i class="fas fa-times-circle" style="font-size: 20px;" title="Delete Uploaded File"></i></span>
                                            </button>

                                        </div>

                                        <div class="col-md-2">
                                            
                                            <button id="btdelete4" class="btn bg-gradient-primary mb-0 ps-0 pt-0" type="button" style="background: none !important; box-shadow: none !important; color:red;" onclick="removeDocuments();">
                                                <span class="btn-inner--icon"><i class="fas fa-trash-alt" style="font-size: 20px;" title="Delete Row"></i></span>
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>


                        </div>
                    </div>

                    <div class="col-md-12 mt-3">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-check">
                                    <input class="form-check-input" type="checkbox" value="" id="chkRTR" disabled="disabled" onclick="enableTLButton();">
                                    <label class="custom-control-label" for="customCheck1">Received RTR Confirmation</label>
                                </div>
                            </div>
                            <div class="col-md-6 text-right">
                                <div class="form-check" style="float: right;display:none;" id="div_genuinity">
                                    <input class="form-check-input" type="checkbox" value="" name="chkgencheck" id="chkgencheck" disabled="disabled" >
                                    <%--<a class="custom-control-label" for="customCheck1" style="color:#0400ff;">Genuinity Check</a>--%>
                                    <label class="custom-control-label zm" for="customCheck1" style="color:#0400ff;" onclick="gotoGenuinity()">Genuinity Check</label>
                                    <label id="lblgenvalue"></label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="div_job2">
                        <div class="d-flex px-2 py-1 mt-2">
                            <div>
                                <img id="imgJob2" src="../assets/img/Sap.png" class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label style="margin-bottom: -7px;"><span class="mb-0 text-sm h6" id="lblJobtitle2">SAP ABAP Developer</span></label>
                                <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblDuration2">12+ Months</span> | <span class="text-xs text-secondary mb-0" id="lblType2">Contract</span> | <span class="text-xs text-secondary mb-0" id="lblWorkingtype2">Remote</span></p>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <div class=" justify-content-end mt-4">
                            <span class="text-xs text-secondary mb-0">Genuinity rating should be above 70% for TL submittion</span>
                       </div>
                    </div>
                         <div class="col-6">
                              <div class=" justify-content-end mt-4">
                        <button type="button" name="button" class="btn bg-gradient-secondary m-0 btn-resize" style="display:none;">Back</button>
                        <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnGenuinity" onclick="openGenuinity();" style="float: right;display:none;">Genuinity Check</button>
                        <button type="button" name="button" class="btn bg-gradient-warning m-0 ms-2 btn-resize" id="btnSave" onclick="saveCandidate('Save');" style="float: right;">Save</button>
                        <button type="button" name="button" class="btn bg-gradient-success m-0 ms-2 btn-resize" id="btnSubmittl" onclick="saveCandidate('Submit');" style="float: right;display:none;">Submit to TL</button>
                        <button type="button" name="button" class="btn bg-gradient-primary m-0 ms-2 btn-resize" id="btnDraft" style="float: right;" onclick="saveCandidate('Draft');">Draft</button>
                        <button type="button" name="button" class="btn bg-gradient-secondary m-0 ms-2 btn-resize" id="btnPipeline" style="float: right;display:none;" onclick="saveCandidate('Pipeline');">Pipeline</button>
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




    <script src="assets/js/jquery.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/select2@4.1.0-beta.1/dist/js/select2.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Candidate.js"></script>


    <script>
        $("#drpSkill").select2();
        $("#drpSpecialization").select2();
        function popup() {
            $("#rtr").modal('hide');
            $("#rtrmailview").modal('show');
            $("#txtsubject").val($("#txtSubject").val());
        }

        function popupcontinue() {
            $("#rtrmailview").modal('hide');
            $("#rtrcontinue").modal('show');
            $("#txtsubject").val($("#txtSubject").val());
            $("#txtMaildescription").append($("#txtMailcont").val() + $("#txtMaildescriptioncont").html());
        }

        function rateUser(a) {
            //document.getElementById("rat1").classList.remove("inputlayout");
            //document.getElementById("txtEnddate").classList.remove("font_size");
            var id = a.id;
            var count = id.split('_');
            for (var k = 1; k <= 5; k++) {
                document.getElementById(count[0] + "_" + k).classList.remove("ratechecked");
            }


            for (var i = 1; i <= count[1]; i++) {
                if (document.getElementById(count[0] + "_" + i).classList.contains('ratechecked')) {
                    document.getElementById(count[0] + "_" + i).classList.remove("ratechecked");
                }
                else {

                    document.getElementById(count[0] + "_" + i).classList.add("ratechecked");
                }
            }

            var ratings = document.getElementsByClassName("ratechecked");
            var rateCount = 0;
            for (var i = 0; i < ratings.length; i++) {
                rateCount++;
            }
            document.getElementById("starRating").innerHTML = rateCount;
            //document.getElementById("ContentPlaceHolder1_hdnStarrating").innerHTML = rateCount;

        }

    </script>
</asp:Content>
