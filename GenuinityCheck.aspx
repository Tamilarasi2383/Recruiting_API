<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="GenuinityCheck.aspx.cs" Inherits="Recruiting_API.GenuinityCheck" %>

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
            background-color: #d6d5d5 !important;
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
                                    <label style="margin-bottom: -7px;"><span class="mb-0 text-sm h6" id="lblCandidatename">Satish Kumbhare</span></label>
                                    <p style="cursor: point;"><span class="text-xs text-secondary mb-0" id="lblCandidatemail">satishkumbhare@hotmail.com</span> | <span class="text-xs text-secondary mb-0" id="lblCandidatephone">8484992057</span></p>
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
                                                <span class="mb-0 text-sm h6" id="lblJobtitle">SAP MM Consultant</span></label>
                                            <p style="cursor: pointer;"><span class="text-xs text-secondary mb-0" id="lblDuration">3 Months</span> | <span class="text-xs text-secondary mb-0" id="lblType">Contract</span> | <span class="text-xs text-secondary mb-0" id="lblWorkingtype">Remote</span></p>
                                        </div>
                                    </div>
                                    <div class="col-md-2">
                                        <div>
                                            <img id="imgJob" src="https://techwaukee.com//admin//Job-Images//SAP_job.png" class="avatar avatar-sm me-3">
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
                                <li class="pe-5" onclick="tablist1('linkedIn');" style="cursor: pointer;">
                                    <a class="change_color mb-0 px-0 py-1 " id="anchlinkedIn" data-bs-toggle="tab" role="tab" aria-selected="true">LinkedIn
                                    </a>
                                </li>
                                <li class="pe-5" onclick="tablist2('visa');" style="cursor: pointer;">
                                    <a class=" mb-0 px-0 py-1" id="anchvisa" data-bs-toggle="tab" role="tab" aria-selected="false">ID & Visa
                                    </a>
                                </li>
                                <li class="pe-5" onclick="tablist3('Education');" style="cursor: pointer;">
                                    <a class=" mb-0 px-0 py-1 " id="anchEducation" data-bs-toggle="tab" role="tab" aria-selected="false">Education
                                    </a>
                                </li>
                                <li class="pe-5" onclick="tablist4('Rating');" style="cursor: pointer;">
                                    <a class=" mb-0 px-0 py-1 " id="anchDraft" data-bs-toggle="tab" role="tab" aria-selected="false">Rating
                                    </a>
                                </li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>

            <div class="card card-body">

                <div class="container-fluid" id="div_linkedIn">
                    <div class="" id="linkedIn" style="display: block;" tabindex="0">
                        <div class="card-header ps-0 pt-0">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6">
                                         <label id="lbltableheading1" class="h5"></label>
                                         <input id="hdntableheadingid1" type="hidden" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsglinkedIn" style="color:red;display:none">Fill All the fields</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" pt-0" style="height: 400px; overflow: scroll; overflow-x: hidden;" id="div_linkedIn_question">
                           

                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label class="mt-4">Overall Rating:</label>
                                <label id="lbllinkedInovrallrating">0</label>
                                <label>/</label><label id="lbllinkedInoverallvalue">100</label>

                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <label>Overall Percentage:</label>
                                    <label id="lbllinkedInpercentage">0</label><label>%</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="button-row d-flex mt-4 col-12">
                                <button class="btn bg-gradient-dark mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return validateradiobtn('linkedIn','9')" id="btnsocial" type="button" title="Next">Next</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="container-fluid mt-4" id="visa" style="display: none;" tabindex="0">
                    <div class="" id="visa1" tabindex="0">
                        <div class="card-header ps-0 pt-0">
                            <div class="col-12">
                                <div class="row">
                                    <div class="col-6">
                                        <label id="lbltableheading2" class="h5"></label>
                                        <input id="hdntableheadingid2" type="hidden" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsgvisa" style="color:red;display:none">Fill All the Fields..</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" pt-0" style="height: 400px; overflow: scroll; overflow-x: hidden;" id="div_visa_question">
                            
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label class="mt-4">Overall Rating:</label>
                                <label id="lblvisaovrallrating">0</label>
                                <label>/</label><label id="lblvisaoverallvalue">100</label>

                            </div>
                            <div class="row">
                                <div class="col-12">
                                    <label>Overall Percentage:</label>
                                    <label id="lblvisapercentage">0</label><label>%</label>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="button-row d-flex mt-4 col-12">
                                <button class="btn bg-gradient-light mb-0  me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" type="button" title="Prev" onclick=" validatevisaprev()">Prev</button>
                                <button class="btn bg-gradient-dark mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return  validateradiobtn('visa','8')" type="button" title="Next">Next</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="container-fluid mt-4" id="Education" style="display: none;">

                    <div class="" id="educationverification1" tabindex="1">
                        <div class="card-header ps-0 pt-0">
                             <div class="col-12">
                                <div class="row">
                                    <div class="col-6 ">
                                        <label id="lbltableheading3" class="h5"></label>
                                        <input id="hdntableheadingid3" type="hidden" />
                                    </div>
                                    <div class="col-6 text-right">
                                        <label id="lblerrormsgEducation" style="color:red;display:none">Fill All the Fields..</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=" pt-0" style="height: 400px; overflow: scroll; overflow-x: hidden;" id="div_Education_question">
                           

                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <label class="mt-4">Overall Rating:</label>
                            <label id="lblEducationovrallrating">0</label>
                            <label>/</label><label id="lblEducationoverallvalue">100</label>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <label>Overall Percentage:</label>
                                <label id="lblEducationpercentage">0</label><label>%</label>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="button-row d-flex mt-4 col-12">
                            <button class="btn bg-gradient-light mb-0  me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" type="button" onclick="validateEducationprev()" title="Prev">Prev</button>
                            <button class="btn bg-gradient-dark mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick='return  validateradiobtn("Education","4")' type="button" title="Next">Next</button>
                        </div>
                    </div>
                </div>
                <div class="container-fluid" id="rating" >
                    <div class="" id="Rating" style="display:none;" tabindex="0">
                        <div class="card-header ps-0 pt-0">
                            <h5>Rating</h5>
                           
                        </div>

                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-6">
                                    <label>System Rating</label>
                                    </div>
                                <div class="col-6">
                                    <h4 class="font-weight-bold"  style="float:right;" ><span class="text-dark" id="value">0</span></h4>
                                </div>
                                </div>

                            <div class="row">
                                <div class="col-6">
                                    <label>Recruiter Rating</label>
                                </div>
                                <div class="col-6">
                                     <h4 class="font-weight-bold" style="float:right;"><span class="text-dark" id="value1">0</span></h4>
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
                                <button class="btn bg-gradient-light mb-0  me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" type="button" onclick="" title="Prev">Prev</button>
                                <button class="btn bg-gradient-primary mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 mt-2 btn-resize" onclick="return saveGenuinity('linkedIn','visa','Education')" id="btnsubmit" type="button" title="Submit">Submit</button>
                            </div>
                        </div>
                    </div>
                </div>
                

               

            </div>
        </div>
    </div>

    <!-- Card Profile -->
    <link href="assets/css/soft-ui-dashboard-pro.css" rel="stylesheet" />
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="assets/js/Common.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/GenuinityCheck.js"></script>
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
               suffix: ' %'
           })
       });

       var inputFormat = document.getElementById('value1');

       sliderFormat.noUiSlider.on('update', function (values, handle) {

           inputFormat.innerHTML = values[handle];
       });

       inputFormat.addEventListener('change', function () {
           sliderFormat.noUiSlider.set(this.value);
       });
    </script>
   

</asp:Content>