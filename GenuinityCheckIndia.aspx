<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="GenuinityCheckIndia.aspx.cs" Inherits="Recruiting_API.GenuinityCheckIndia" %>
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
            background-color: red !important;
        }
    </style>


    <div class="container-fluid my-3 py-3">
        <div class="col-lg-9 col-12 mx-auto">
            <div class="card col-md-12 mb-3">
                <div class="row">
                    <div class="col-md-6">
                        <div id="div_job2">
                            <div class="d-flex px-2 py-1 mt-2">
                                <div>
                                    <img src="Images/userimg.png" class="avatar avatar-sm me-3" />
                                    <%--<img id="imgJob2" src="https://techwaukee.com//admin//Job-Images//SAP_job.png" class="avatar avatar-sm me-3">--%>
                                </div>
                                <div class="d-flex flex-column justify-content-center">
                                    <label style="margin-bottom: -7px;"><span class="mb-0 text-sm h6" id="lblJobtitle2">Satish Kumbhare</span></label>
                                    <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblCandidatemail">satishkumbhare@hotmail.com</span> | <span class="text-xs text-secondary mb-0" id="lblType2">8484992057</span></p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="d-flex px-2 py-1 mt-2">
                            <div class="col-md-12">
                                <div class="row" id="div_job1">
                                    <div class="col-md-10">
                                        <div class="d-flex flex-column justify-content-center text-right">
                                            <label style="margin-bottom: -7px;">
                                                <input type="hidden" id="hdnJobid" value="TWEIND0006">
                                                <input type="hidden" id="hdnCandStatus" value="105">
                                                <span class="mb-0 text-sm h6" id="lblJobtitle1">SAP MM Consultant</span></label>
                                            <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblDuration1">3 Months</span> | <span class="text-xs text-secondary mb-0" id="lblType1">Contract</span> | <span class="text-xs text-secondary mb-0" id="lblWorkingtype1">Remote</span></p>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div>
                                            <img id="imgJob1" src="https://techwaukee.com//admin//Job-Images//SAP_job.png" class="avatar avatar-sm me-3">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid mb-3">
                <div class="row align-items-center">
                    <div class="col-md-12">
                        <div class="nav-wrapper position-relative end-0">
                            <ul class="nav nav-pills nav-fill p-1" role="tablist" style="background: transparent !important;">
                                <li class="pe-5" onclick="tabList1('LinkedIn');" style="cursor: pointer;">
                                    <a class="change_color mb-0 px-2 py-1 " id="anchlinkedIn" data-bs-toggle="tab" role="tab" aria-selected="true">Screening</a>
                                </li>
                                <li class="pe-5" onclick="tabList2('VISA');" style="cursor: pointer;">
                                    <a class=" mb-0 px-2 py-1" id="anchvisa" data-bs-toggle="tab" role="tab" aria-selected="false">Rating</a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card card-body col-md-12">

                <div class="container-fluid" id="div_tile1">
                    <div class="" id="LinkedIn" style="display:block;" tabindex="0">
                         <div class="card-header ps-0 pt-0">
                              <div class="row">
                                    <div class="col-6">
                                        <label id="lbltableheading1" class="h5"></label>
                                        <input id="hdntableheadingid1" type="hidden" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsglinkedIn1" style="color:red;display:none">Fill All the Fields..</label>
                                    </div>
                                </div>
                         </div>
                       
                        <div class=" pt-0" style="height: 400px; overflow: scroll; overflow-x: hidden;" id="div_linkedin1_question">
                            
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label class="mt-4">Overall Rating:</label>
                                <label id="lbllinkedIn1ovrallrating">0</label>
                                <label>/</label><label id="lbllinkedIn1overallvalue">50</label>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <label>Overall Percentage:</label>
                                    <label id="lbllinkedIn1percentage">0</label><label>%</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="button-row d-flex mt-4 col-12">
                                <button class="btn bg-gradient-dark mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return validateradiobtn('linkedIn1','10')" id="btnsocial" type="button" title="Next">Next</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="container-fluid" id="div_tile2">
                    <div class="" id="tail2" style="display:none;" tabindex="0">
                        <div class="card-header ps-0 pt-1">
                            <div class="row">
                                    <div class="col-6">
                                        <label id="lbltableheading2" class="h5"></label>
                                        <input id="hdntableheadingid2" type="hidden" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsglinkedIn2" style="color:red;display:none">Fill All the Fields..</label>
                                    </div>
                                </div>

                        </div>
                      
                        <div class=" pt-0" style="height: 400px; overflow: scroll; overflow-x: hidden;" id="div_linkedin2_question">
                            
                           
                        </div>
                       <div class="row">
                            <div class="col-12">
                                <label class="mt-4">Overall Rating:</label>
                                <label id="lbllinkedIn2ovrallrating">0</label>
                                <label>/</label><label id="lbllinkedIn2overallvalue">50</label>
                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <label>Overall Percentage:</label>
                                    <label id="lbllinkedIn2percentage">0</label><label>%</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="button-row d-flex mt-4 col-12">
                                 <button class="btn bg-gradient-light mb-0  me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" type="button" title="Prev" onclick=" validatevisaprev()">Prev</button>
                                <button class="btn bg-gradient-dark mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return validateradiobtn('linkedIn2','10')" id="btnsave" type="button" title="save">Next</button>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="container-fluid" id="rating" >
                    <div class="" id="Rating" style="display:none;" tabindex="0">
                        <div class="card-header pe-0 ps-0 pt-0">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6">
                                        <h5>System Check Rating</h5>
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsgRating" style="color:red;display:none">Fill All the Fields</label>
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-6">
                                    <label>System Rating</label>
                                    </div>
                                <div class="col-6">
                                    <h4 class="font-weight-bold"  style="float:right;" ><span class="text-dark" id="value1">0</span><span>%</span></h4>
                                </div>
                                </div>
                                <div class="row">
                                    <div class="col-6">
                                     <label>Recruting Rating</label>
                                        </div>
                                    <div class="col-6">
                                    <h4 class="font-weight-bold" ><span class="text-dark" id="value" style="float:right;">0</span></h4>
                                </div>
                                </div>
                         
                            <div class="mb-5">
                                <div id="slider-format" class="noUi-target noUi-ltr noUi-horizontal noUi-txt-dir-ltr">
                                </div>
                                <p class="ps-1 mb-0">
                                    <span class="text-xs">0</span>
                                    <span class="text-xs mt-2" style="float: right;">100</span>
                                </p>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <label>Recruiter Comments</label>
                            <div class="form-group">
                                <textarea class="form-control" id="txtRatingcommentsQ1" rows="3"></textarea>
                            </div>
                        </div>
                        
                        <div class="row">
                            <div class="button-row d-flex mt-4 col-12">
                                <button class="btn bg-gradient-light mb-0  me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" type="button" title="Prev" onclick=" validateeducationprev()">Prev</button>
                                <button class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return saveGenuinity('linkedIn1','linkedIn2','Rating')" id="btnsubmit" type="button" title="Submit">Save</button>
                             <!--<button type="button" class="btn btn-outline-info" onclick="return findthevalue('linkedIn','visa','Education')">Test</button>-->
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
                                <p class="mb-0 h6"><span id="div-message">Save successfully</span></p>
                            </div>

                            <div class="modal-footer pt-0 text-center" style="border-top: none;">
                                <div class="col-md-12">
                                    <button type="button" class="btn bg-gradient-primary mb-0 btn-resize" id="btnOk" onclick="closepopup();">Ok</button>
                                </div>
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
    <script src="AppScripts/GenuinityCheckIndia.js"></script>
    <script src="assets/js/plugins/nouislider.min.js"></script>
    <script src="assets/js/plugins/wNumb.js"></script>
    <script src="assets/js/plugins/wNumb.min.js"></script>

    <script type="text/javascript">
        var sliderFormat = document.getElementById('slider-format');
        noUiSlider.create(sliderFormat, {
            start: 0,
            step: 1,
            connect: [true, false],
            range: {
                min: 0,
                max: 100
            },
            format: wNumb({
                decimals: 0,
                thousand: '.',
                suffix: '%'
            })
        });

        var inputFormat = document.getElementById('value');

        sliderFormat.noUiSlider.on('update', function (values, handle) {

            inputFormat.innerHTML = values[handle];
        });

        inputFormat.addEventListener('change', function () {
            sliderFormat.noUiSlider.set(this.value);
        });
        
    </script>

</asp:Content>
