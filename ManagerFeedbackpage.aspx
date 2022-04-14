<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManagerFeedbackpage.aspx.cs" Inherits="Recruiting_API.ManagerFeedbackpage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <script src="assets/js/plugins/chartjs.min.js"></script>
  <script src="assets/js/plugins/Chart.extension.js"></script>

    <%--<style>
        #tabsDiv {
            height: 400px;
            /*border: 2px solid #c0c0c0;*/
            border-radius: 10px !important;
        }

            #tabsDiv ul {
                height: 300px;
                padding: 5px;
            }

            #tabsDiv li {
                width: 30%;
                height: 50px;
            }

            #tabsDiv button {
                float: left;
                border: 1px solid #c0c0c0;
                background-color: #f1f0f4;
            }

            /* Button to open the content */
            #tabsDiv button {
                display: block;
                background-color: inherit;
                color: black;
                padding: 25px 15px;
                width: 100%;
                text-align: left;
                cursor: pointer;
                border-radius: 10px;
            }

                /* Button styling on mouse hover */
                #tabsDiv button:hover {
                    background-color: #d1d1d1;
                    color: White;
                }

                #tabsDiv button.active {
                    background-color: #dfdfdf; /*#c0c0c0*/
                }
    </style>--%>

    <style>
        .color-red {
            color: #f52804 !important;
        }

        .color-yellow {
            color: #ffeb3b !important;
        }

        .color-blue {
            color: #18ffff !important;
        }

        .color-magenta {
            color: #e040fb !important;
        }
    </style>

    <style>
        .linkClass {
            padding: 5px 5px 5px 5px !important;
        }

        * {
            box-sizing: border-box;
        }


        /* Content for tabs*/
        .contentClass {
            display: none;
            position: absolute;
            left: 30%;
            padding: 0px 15px;
            width: 70%;
            border-style: none;
            height: 300px;
        }

        .divshow {
            display: initial !important;
        }

        .divhide {
            display: none !important;
        }

        .divrevert {
            display: revert !important;
        }
    </style>

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

        .dropdown_item {
            box-shadow: 0px 0px 13px 0px rgb(0 0 0 / 30%);
            inset: 0px auto auto 0px !important;
            min-width: 8.5rem !important;
        }

        .week-color-green {
            display: block;
            border: 4px solid #b5eea5 !important;
            color: black;
            padding: 25px 15px;
            width: 100%;
            text-align: left;
            cursor: pointer;
            border-radius: 10px;
        }

            .week-color-green:hover {
                display: block;
                background-color: #7ddc62 !important;
                color: black;
                padding: 25px 15px;
                width: 100%;
                text-align: left;
                cursor: pointer;
                border-radius: 10px;
            }

        .week-color-blue {
            display: block;
            border: 4px solid #99f3ff !important;
            color: black;
            padding: 25px 15px;
            width: 100%;
            text-align: left;
            cursor: pointer;
            border-radius: 10px;
        }

            .week-color-blue:hover {
                display: block;
                background-color: #10e2fd !important;
                color: black;
                padding: 25px 15px;
                width: 100%;
                text-align: left;
                cursor: pointer;
                border-radius: 10px;
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

    <div class="container-fluid py-4 hidden" id="div_feedback">

        <div class="row">
            <div class="col-md-6">
                <div class="col-md-12">
                    <div class="row">
                        <%--<div class="col-md-6">
                            <button class="btn bg-gradient-primary mb-0  " type="button" id="btn" aria-expanded="false" onclick="window.location.href='ManagerPerformanceviewIndia.aspx'">
                                    View Performance
                                </button>
                            <%--<a class="text-body text-sm font-weight-bold mb-0 icon-move-right mt-2" id="anchCheck" href="ManagerPerformanceviewIndia.aspx">
                                View Performance<i class="fas fa-arrow-right text-sm ms-1" aria-hidden="true"></i> 
                            </a>
                        </div>--%>
                        <div class="col-md-6">
                            <div class="dropdown " >
                                <button class="btn bg-gradient-primary mb-0 dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                                    <span id="btnval"></span>
                                </button>
                                <ul class="dropdown-menu dd" aria-labelledby="dropdownMenuButton" style="position: absolute; inset: 0px auto auto 0px; margin: 0px; transform: translate(110px, 43px) !important;" data-popper-placement="bottom-end">
                                  <li><a class="dropdown-item" id="txtweek" onclick="openCurrentDiv('Weekly')";>Weekly</a></li>
                                  <li><a class="dropdown-item" id="txtmonth" onclick="openCurrentDiv('Monthly')";>Monthly</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12" style="margin-top: 22px !important;">
                            <h6>Team member name&nbsp;: &nbsp;&nbsp;<span class="my-auto" id="txtcandidatename"></span></h6>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6 divhide" id="div_overallrating">
                <div class="col-12">
                    <div class="sidenav-footer">
                         <div class="card card-background shadow-none card-background-mask-secondary" id="sidenavCard">
                             <div class="full-background" style="background-image: url('assets/img/curved-images/white-curved.jpeg')"></div>
                             <div class="card-body text-left p-3 w-100">
                                 <div class="row">
                                   <div class="col-8 my-auto">
                                       <div class="numbers">
                                           <p class="text-sm mb-0 text-capitalize font-weight-bold opacity-7" style="color:black">Rating for the duration of&nbsp;&nbsp;<span id="lblselectweek"> 01-12 Jan 2022</span> </p>
                                              <h5 class="text-white font-weight-bolder mb-0"><span id="lblsystemgenrating"></span></h5>
                                       </div>
                                   </div>
                                   <div class="col-4 text-end">
                                       <h5 class="mb-0 text-white text-end me-1" style="font-size:35px;"><span id="lblsystemgenvalue"></span><span id="lblsystemgenvalueper"  class="text-lg ms-n2">&nbsp;&nbsp;%</span></h5>
                                   </div>
                                 </div>                                
                             </div>
                         </div>
                     </div>
                </div>
            </div>
        </div>

        <div class="row mt-3">

            <div class="col-md-12" id="div_image">
                <img src="Images/Feedback.png" style="width:100%;"/>
            </div>

            <div class="col-xl-6 divhide" id="div_feebackform">
                <div class="card h-100">
                    <div class="card-header d-flex pb-0 p-3">
                        
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6" id="div_weekinfo">
                                    <h6  style="font-size: 12px;"><span class="btn-inner--text" id="lblWeekinfotitle"  style="font-size: 12px;">Feedback form</span><span class="btn-inner--text" id="lblWeekinfo"  style="font-size: 12px;"></span></h6>
                                </div>
                                <div class="col-md-6 text-right divhide" id="div_monthinfo">
                                    <h6  style="font-size: 12px;">
                                        <span id=""  style="font-size: 12px;">Month&nbsp;:&nbsp; </span>
                                        <span class="my-auto h6" id="lblmonthname"  style="font-size: 12px;"></span>  
                                        <i id="icon_refresh" class="fa fa-refresh me-sm-1" aria-hidden="true" onclick="refreshData()"></i>
                                    </h6>
                                </div>
                            </div>
                        </div>

                    </div>
                    <div class="card-body p-3" style="max-height: 380px !important;min-height: 380px !important;">
                        <div class="tab-content" id="v-pills-tabContent">
                            
                            <div class="position-relative height-372 border-radius-lg" background-size: cover;">
                               <div class="position-absolute d-flex top-0 w-100 divhide" id="div_monthpicker">
                                        <div class="col-md-12">
                                            <label>Select Month</label><span style="color: red;">*</span>
                                            <input class="form-control form-controlnew datepicker" type="text" id="txtFeedbackdatefb" style="background-color:white !important" placeholder="Start Date" onchange="openCalendarData();"/>
                                            <input type="hidden" id="hdnfirstday" />
                                            <input type="hidden" id="hdnlastday" />
                                            <input type="hidden" id="hdnprevweek" />
                                        </div>
                                    </div>
                                
                                <div class="position-absolute d-flex top-0 w-100 divhide" id="div_feedbackweek">
                                    
                                    <div class="col-md-12" id="tabsDiv">
                                        <div id="divfeedbackcontent" class="">
                                            
                                                <div class="col-md-12 p-2" id="div_weekdata">
                                                  <%--<div class="dropdown">
                                                  <a href="javascript:;" class="btn bg-gradient-dark dropdown-toggle " data-bs-toggle="dropdown" id="navbarDropdownMenuLink2">
                                                      <i class="far fa-calendar-alt me-2"></i> Choose Week
                                                  </a>
                                                  <ul class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink2">
                                                      <li>
                                                          <a class="dropdown-item" href="javascript:;">
                                                            Week 1 01-05 Feb
                                                          </a>
                                                      </li>
                                                      <li>
                                                          <a class="dropdown-item" href="javascript:;">
                                                            Week 2
                                                          </a>
                                                      </li>
                                                      <li>
                                                          <a class="dropdown-item" href="javascript:;">
                                                            Week 3
                                                          </a>
                                                      </li>
                                                      <li>
                                                          <a class="dropdown-item" href="javascript:;">
                                                            Week 4
                                                          </a>
                                                      </li>

                                                      <li>
                                                          <a class="dropdown-item" href="javascript:;">
                                                            Week 5
                                                          </a>
                                                      </li>
                                                  </ul>
                                                </div>--%>
                                                 </div>
                                            <div id="div_feedbackcontent" class="divhide">
                                                <div class="col-md-12 p-2">
                                                    <input type="hidden" id="hdnTeamperfomanceid" />
                                                    <label class="form-label">Overall Rating</label><span style="float:right;"><i class="fas fa-pencil-alt mt-2" id="iconoverall" style="display:none;" onclick="opendisabled('#drpOverallRemarks')"></i></span>
                                                    <select class="form-control form-controlnew" name="choices-sizes" id="drpOverallRemarks" ><%--onchange="opendisableComments();"--%>
                                                     </select>
                                                </div>
                                                <div class="col-md-12 p-2">
                                                    <label class="form-label">Remarks</label><span style="float:right;"><i class="fas fa-pencil-alt mt-2" id="iconremarks" style="display:none;" onclick="opendisabled('#txtComments')" ></i></span>
                                                    <textarea name="txtComm" rows="2" cols="20" id="txtComments" class="form-control form-controlnew text-font font_size" placeholder="Remarks" style="height: 100px;" disabled="disabled" ></textarea>
                                                </div>
                                                <div class="col-md-12 mt-2" >
                                                    <button type="button" id="btnSave" class="btn bg-gradient-primary btn-sm mb-0" style="float: right;display:none;" onclick="Validateweekinfo()">
                                                         Save
                                                    </button>
                                                </div>
                                            </div>
                                        </div>
  
                                        <ul class="ulClass" style="height:300px;display:none;">
                                            <li style="list-style-type:none;">
                                                <button class="linkClass active" id="btnfbWeek1" onclick="getTargetData('#lblWeek11','#hdnWeek11');">
                                                     <span class="btn-inner--text" id="lblWeek11"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek11" />
                                            </li>
              
                                            <li style="list-style-type:none;">
                                                <button class="linkClass" id="btnfbWeek2" onclick="getTargetData('#lblWeek21','#hdnWeek21');">
                                                    <span class="btn-inner--text" id="lblWeek21"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek21" />
                                            </li>
  
                                            <li style="list-style-type:none;">
                                                <button class="linkClass" id="btnfbWeek3" onclick="getTargetData('#lblWeek31','#hdnWeek31');">
                                                    <span class="btn-inner--text" id="lblWeek31"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek31" />
                                            </li>
  
                                            <li style="list-style-type:none;">
                                                <button class="linkClass" id="btnfbWeek4" onclick="getTargetData('#lblWeek41','#hdnWeek41');">
                                                    <span class="btn-inner--text" id="lblWeek41"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek41" />
                                            </li>

                                            <li style="list-style-type:none;">
                                                <button class="linkClass" id="btnfbWeek5" onclick="getTargetData('#lblWeek51','#hdnWeek51');">
                                                    <span class="btn-inner--text" id="lblWeek51"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek51" />
                                            </li>
  
                                            <li style="list-style-type:none;">
                                                <button class="linkClass" id="btnfbWeek6" style="display:none;" onclick="getTargetData('#lblWeek61','#hdnWeek61');">
                                                    <span class="btn-inner--text" id="lblWeek61"></span>
                                                </button>
                                                <input type="hidden" id="hdnWeek61" />
                                            </li>
                                        </ul>

                                        
                                    </div>

                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-xl-6 ms-auto mt-xl-0 mt-4 divhide" id="div_rating">

                <div id="div_ratingtable" class="col-md-12 divhide card h-100">
                    <h5 class="ms-3 pt-3 mx-3"><span id="lblTableheader">Candidate List</span>
                    <i id="icon_close" class="fa fa-close me-sm-1" style="float:right;color:red;" aria-hidden="true" onclick="closeTableview();"></i>
                    </h5>
                    <div style="padding: 0px 15px 0px 15px;">
                        <div style="overflow: scroll;overflow-y: hidden;">
                    <table class="table align-items-center mb-0" id="tblCandlist">
                            <thead>
                                <tr>
                                    
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Candidates</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>
                            </div>
                        <div class="dataTable-bottom">
                            <div class="dataTable-info" id="divInfo">Showing 1 to 5 of 1 entries</div>
                            <div id="paginus" class="pagination pagination-info">
                                <div class="prev" style="display: none;"><i class="ni ni-bold-left" aria-hidden="true"></i></div>
                                <div class="pagination pagination-info" id="divPages"><div class="page pageselect selected" id="page_1">1</div></div>
                                <div class="next" style="display: none;"><i class="ni ni-bold-right" aria-hidden="true"></i></div>
                            </div>
                        </div>
                </div>
                </div>
                
                <div id="div_tiles">
                <div class="row">
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;" id="div_submissions" onclick="getRecruiterDetails('Submission')">
                                <h1 class="text-gradient text-primary"><span id="lblsubmissionvalue" countto="10">10</span> <span class="text-lg ms-n2">%</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission</h6>
                                <span id="lblsubmissionper"></span>

                                <div class="col-md-12 text-center">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Target</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblsubmssiontarget"></span></p>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Achieved</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblsubmssionachived"></span></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 mt-md-0 mt-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;" id="div_TLsubmission" onclick="getRecruiterDetails('TL Submission')">
                                <h1 class="text-gradient text-primary"><span id="lbltlvalue" countto="">0</span> <span class="text-lg ms-n1">%</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission to TL</h6>
                                <span id="lblsubmissiontlper"></span>

                                <div class="col-md-12 text-center">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Target</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lbltltarget"></span></p>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Achieved</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lbltlachived"></span></p>
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
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;" id="div_BPsubmission" onclick="getRecruiterDetails('BP Submission')">
                                <h1 class="text-gradient text-primary"><span id="lblbpvalue" countto="20">20</span> <span class="text-lg ms-n2">%</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission to BP</h6>
                                <span id="lblsubmissionbpper"></span>

                                <div class="col-md-12 text-center">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Target</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblbptarget"></span></p>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Achieved</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblbpachived"></span></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-6 mt-md-0 mt-4" >
                        <div class="card" >
                            <div id="div_closure" onclick="getRecruiterDetails('Closures')" style="cursor:pointer;" class="divhide">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;" id="div_Closures" >
                                <h1 class="text-gradient text-primary"><span id="lblclosurevalue" countto="30">30</span> <span class="text-lg ms-n2">%</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Closure</h6>
                                <span id="lblclosureper"></span>

                                <div class="col-md-12 text-center">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Target</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblclosuretarget"></span></p>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm">Achieved</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm"><span id="lblclosureachived"></span></p>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                                </div>
                        </div>
                        <div class="card" >
                            <div id="div_ECSubmission" onclick="getRecruiterDetails('EC Submission')">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;" >
                                <h1 class="text-gradient text-primary"><span id="lblecsubmissionvalue" countto="30">30</span> <span class="text-lg ms-n2"></span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission to EC</h6>
                                <span id="lblecsubmissionper"></span>

                                <div class="col-md-12 text-center">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm text-white">Target</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm text-white"><span id="lblectarget">00</span></p>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm text-white">Achieved</p>
                                            </div>
                                            <div>
                                                <p class="opacity-8 mb-0 text-sm text-white"><span id="lbleceachived">00</span></p>
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
        </div>

        <div class="row mt-4 mb-5 divhide" id="div_chart">
            <div class="col-lg-6 ms-auto" ><%----%>
                <div class="card h-100" style="height: 115% !important;">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Submission Overview of Previous week</h6> &nbsp;&nbsp; <h6 class="mb-0"><span id="lblprevweek"></span></h6>

                        </div>
                    </div>
                    <div class="card-body p-3" >
                        <div class="row">
                            <div class="col-5 text-center">
                                <div class="chart" id="divdoughnutchartprev">
                                    <%--<canvas id="chart-consumptionprev" class="chart-canvas" height: "197px"; width: "106px;"></canvas>--%>
                                </div>
                                <h4 class="font-weight-bold mt-n7">
                                    <span id="lbloverallperfvalprev">70%</span>
                                    <span class="d-block text-body text-sm" id="lbloverallperfvalueprev">Good</span>
                                </h4>
                            </div>
                            <div class="col-7">
                                <div class="table-responsive">
                                    <table class="table align-items-center mb-0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-primary me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submissions</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblprevsubchartval"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to TL</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblprevtlchartval"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-warning me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to BP</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblprevbpchartval"></span>
                                                </td>
                                            </tr>
                                            <tr id="tr_prevclosure" style="display:none;">
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-success me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Closure</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblprevclchartval"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--<div class="col-lg-2 mt-lg-0 mt-4">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Performance overview</h6>
                            <button type="button" class="btn btn-icon-only btn-rounded btn-outline-secondary mb-0 ms-2 btn-sm d-flex align-items-center justify-content-center ms-auto" data-bs-toggle="tooltip" data-bs-placement="bottom" title="Overall Performance for the given month">
                                <span class="font-weight-bold" id="lblPerformanceVal">4%</span>
                            </button>
                        </div>
                    </div>

                    <div class="card-body p-3">
                        <div class="timeline timeline-one-side">
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-paper-diploma text-danger text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblBPTitle">BP</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblBPSelected">12 Profiles</span></p>
                                </div>
                            </div>
                            <div class="timeline-block mb-3">
                                <span class="timeline-step">
                                    <i class="ni ni-circle-08 text-info text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblTLTitle">TL</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblTLApproved">20 Profiles</span></p>
                                </div>
                            </div>
                            <div class="timeline-block">
                                <span class="timeline-step">
                                    <i class="ni ni-money-coins text-dark text-gradient"></i>
                                </span>
                                <div class="timeline-content">
                                    <h6 class="text-dark text-sm font-weight-bold mb-0"><span id="lblCanTitle">Submission</span></h6>
                                    <p class="text-secondary font-weight-bold text-xs mt-1 mb-0"><span id="lblCandidates">1</span></p>
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>--%>

            <div class="col-lg-6 ms-auto">
                <div class="card h-100" style="height: 115% !important;">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Submission Overview</h6>

                        </div>
                    </div>
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-5 text-center">
                                <div class="chart" id="divdoughnutchart">
                                    <%--<canvas id="chart-consumption" class="chart-canvas" height: "197px"; width: "106px;"></canvas>--%>
                                </div>
                                <h4 class="font-weight-bold mt-n7">
                                    <span id="lbloverallperfval">70%</span>
                                    <span class="d-block text-body text-sm" id="lbloverallperfvalue">Good</span>
                                </h4>
                            </div>
                            <div class="col-7">
                                <div class="table-responsive">
                                    <table class="table align-items-center mb-0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-primary me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submissions</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblsubmissionchartval"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to TL</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lbltlchartval"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-warning me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to BP</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lbllbpchartval"></span>
                                                </td>
                                            </tr>
                                            <tr id="tr_closure" style="display:none;">
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-success me-3">&nbsp;</span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Closure</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold" id="lblclchartval"></span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
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
                                <p class="mb-0 h6"><span id="div-message"></span></p>
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


    <script>

         function refreshData() {

            $('#div_monthpicker').removeClass("divhide");
            $('#div_monthpicker').addClass("divshow");
            $('#div_feedbackweek').removeClass("divshow");
            $('#div_feedbackweek').addClass("divhide");
            $('#txtFeedbackdatefb').val("");
            $('#div_monthinfo').addClass("divhide");

            $('#lblWeek11').text("");
            $('#lblWeek21').text("");
            $('#lblWeek31').text("");
            $('#lblWeek41').text("");
            $('#lblWeek51').text("");
            $('#lblWeek61').text("");

            $('#div_overallrating').addClass("divhide");
            $('#div_rating').addClass("divhide");
            $('#div_chart').addClass("divhide");
            $('#lblWeekinfo').text("");

            $('#div_feedbackcontent').addClass("divhide");
            $('#div_feedbackcontent').removeClass("divshow");
            
        }

        function getWeekdata(txt, status, hdn) {

            $('#lblWeekinfotitle').text("Feedback info of ");
            $('#lblWeekinfo').text($('#' + txt.id).text());
            //alert($('#' + txt.id).text());
            var s1 = ($('#' + txt.id).text()).split(":");


            //alert($('#' + hdn).val());

            var st = ($('#' + hdn.id).val()).split("$");

            const d = new Date();
            var d1 = new Date(st[0]);
            d1.setDate(d1.getDate() - 7);


            var d2 = new Date(st[0]);
            d2.setDate(d2.getDate() - 1);


            var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

            $('#hdnprevweek').val(pad2(d1.getDate()) + "-" + arr[d1.getMonth()] + " " + d1.getFullYear() + " to " +
                pad2(d2.getDate()) + "-" + arr[d2.getMonth()] + " " + d2.getFullYear());

            //if (status == 1) {
            var TWE_Id = getSession('RecruiterID');
            var strdata = {
                "TWE_Id": TWE_Id, "Weekinfo": s1[1].trim(), "fromdate": st[0], "todate": st[1], "strtype": "Daily",
                "prevfromdate": d1.getFullYear() + "-" + (d1.getMonth() + parseInt(1)) + "-" + d1.getDate(),
                "prevtodate": d2.getFullYear() + "-" + (d2.getMonth() + parseInt(1)) + "-" + d2.getDate(), "tablename": "Weekly"
            };
            if (TWE_Id != "") {
                common_api_ajax_request("api/TeamMemberTarget", "TARGETDATA", strdata);
            }
            //}

        }

        function Validateweekinfo() {
            var count = 0;
            var emptycount = 0;


            if ($('#txtComments').val() == "") {
                $('#txtComments').addClass("is-invalid");
                emptycount++;
            }
            else {
                $('#txtComments').removeClass("is-invalid");
                count++;
            }

            if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
                return false;
            }

            else if (parseInt(count) > 0) {
                return true;
            }

        }



        function opendiv(div_name1, div_name2) {
            $(div_name2).addClass("divhide");
            $(div_name2).removeClass("divshow");
            $(div_name1).addClass("divshow");
            $(div_name1).removeClass("divhide");
        }



        function openCurrentDiv(str) {

            $('#div_image').addClass("divhide");
            $('#div_feebackform').removeClass("divhide");
            $('#div_feebackform').addClass("divshow");

            $('#lblWeekinfotitle').text("Feedback form");
            $('#lblWeekinfo').text("");

            $('#div_monthinfo').removeClass("divshow");
            $('#div_monthinfo').addClass("divhide");

            feedbacktype = str;
            $('#div_monthpicker').addClass("divshow");
            $('#div_monthpicker').removeClass("divhide");
            if (str == "Monthly") {
                //$('#div_monthpicker').removeClass("divhide");
                //$('#divfeedbackcontent').removeClass("divshow");
                $('#lblmonthname').removeClass("divshow");
                $('#div_chart').removeClass("divshow");
                $('#div_rating').removeClass("divshow");
                $('#div_overallrating').removeClass("divshow");
                $('#div_overallrating').addClass("divhide");

                $('#div_monthpicker').addClass("divshow");
                $('#divfeedbackcontent').addClass("divhide");
                $('#div_chart').addClass("divhide");
                $('#div_rating').addClass("divhide");
                $('#txtFeedbackdatefb').val("");

            }

            else if (str == "Weekly") {
                //$('#div_monthpicker').removeClass("divhide");
                //$('#div_monthpicker').removeClass("divshow");
                $('#divfeedbackcontent').removeClass("divshow");

                $('#div_chart').removeClass("divshow");
                $('#div_rating').removeClass("divshow");

                $('#divfeedbackcontent').addClass("divhide");
                $('#lblmonthname').addClass("divhide");
                $('#div_chart').addClass("divhide");
                $('#div_rating').addClass("divhide");
                $('#txtFeedbackdatefb').val("");

            }
        }


    </script>

    

    
    <script src="assets/js/jquery.js"></script>
    <script src="https://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>

    <script src="assets/js/plugins/flatpickr.min.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/startPage.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/ManagerFeedback.js"></script>


</asp:Content>
