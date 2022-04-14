<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManagerPerformanceviewIndia.aspx.cs" Inherits="Recruiting_API.ManagerPerformanceviewIndia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">  

    <script src="assets/js/plugins/chartjs.min.js"></script>
    <script src="assets/js/plugins/Chart.extension.js"></script>

    <style>
        .linkClass {
            padding: 5px 5px 5px 5px !important;
        }

        * {
            box-sizing: border-box;
        }

        #tabsDiv {
            height: 300px;
            border: 2px solid #c0c0c0;
            /*border-radius: 10px !important;*/
            border: none;
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

        .green {
            display: block;
            background-color: #b5eea5 !important;
            color: black;
            padding: 25px 15px;
            width: 100%;
            text-align: left;
            cursor: pointer;
            border-radius: 10px;
        }

            .green:hover {
                display: block;
                background-color: #7ddc62 !important;
                color: black;
                padding: 25px 15px;
                width: 100%;
                text-align: left;
                cursor: pointer;
                border-radius: 10px;
            }

        .blue {
            display: block;
            background-color: #99f3ff !important;
            color: black;
            padding: 25px 15px;
            width: 100%;
            text-align: left;
            cursor: pointer;
            border-radius: 10px;
        }

            .blue:hover {
                display: block;
                background-color: #10e2fd !important;
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
            background-color: #c0c0c0;
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
            display: block !important;
        }

        .divhide {
            display: none !important;
        }

         .dropdown_item {
            box-shadow: 0px 0px 13px 0px rgb(0 0 0 / 30%);
            inset: 0px auto auto 0px !important;
            min-width: 8.5rem !important;
        }
    </style>

    <%--<style>
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
    </div>--%>

    <div class="container-fluid py-4" id="div_month">
        <div class="row">
            <div class="col-xl-7">
                <div class="card h-100">
                    <div class="card-header d-flex pb-0 p-3">
                        
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <h6><span class="my-auto" id="txtcandidatename">Rexaline</span> <br />
                                        <span class="my-auto h6" id="lblmonthname"></span>  
                                        <i id="icon_refresh" style="display:none;" class="fa fa-refresh me-sm-1" aria-hidden="true"></i>
                                    </h6>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <a class="text-body text-sm font-weight-bold mb-0 icon-move-right mt-2" id="anchCheck" href="ManagerFeedbackpageIndia.aspx" style="float: right;">
                                                Give Feedback <i class="fas fa-arrow-right text-sm ms-1" aria-hidden="true"></i>
                                            </a>
                                        </div>
                                        <div class="col-md-6 ps-0">
                                            <div class="dropdown " style="float:right;">
                                                <button class="btn bg-gradient-primary mb-0 dropdown-toggle" type="button" id="dropdownMenuButton" data-bs-toggle="dropdown" aria-expanded="false">
                                                    View Performance
                                                </button>
                                                <ul class="dropdown-menu dd" aria-labelledby="dropdownMenuButton" style="position: absolute; inset: 0px auto auto 0px; margin: 0px; transform: translate(110px, 43px) !important;" data-popper-placement="bottom-end">
                                                  <li><a class="dropdown-item" id="txtweek" onclick="openCurrentDiv()";>Weekly</a></li>
                                                  <li><a class="dropdown-item" id="txtmonth" onclick="openFeedback()";>Monthly</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="card-body p-3 mt-2">
                        <div class="tab-content" id="v-pills-tabContent">

                            <div class="position-relative height-372 border-radius-lg" background-size: cover;">
                               <div class="position-absolute d-flex top-0 w-100 divhide" id="div_monthpicker">
                                        <div class="col-md-12">
                                            <label>Select Month</label><span style="color: red;">*</span>
                                            <input class="form-control form-controlnew datepicker" type="text" id="txtFeedbackdatefb" style="background-color:white !important" placeholder="Start Date" onchange="openCalendarData('Givefeedback','Weekly');"/>
                                            <input type="hidden" id="hdnfirstday" />
                                            <input type="hidden" id="hdnlastday" />
                                        </div>
                                    </div>
                                
                                
                                <div class="position-absolute d-flex top-0 w-100 divhide" id="div_feedbackweek">
                                    
                                    <div class="col-md-12" id="tabsDiv">
                                        <div id="divfeedbackcontent" class="">
                                            <h6><span class="btn-inner--text" id="lblWeekinfo">Week Info</span></h6>
                                                <div class="col-md-12 p-2" id="div_weekdata">
                                                  <div class="position-absolute d-flex top-0 w-100 mt-4" id="div_monthweek">
                                    <div class="col-md-12" id="tabsDiv">
                                        <table class="table align-items-center mb-0">
                                          <thead>
                                            <tr>
                                              <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Jobs</th>
                                              <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Client</th>
                                              <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                              <th class="text-secondary opacity-7"></th>
                                            </tr>
                                          </thead>
                                          <tbody>
                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-2.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">John Michael</h6>
                                                    <p class="text-xs text-secondary mb-0">john@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Manager</p>
                                                <p class="text-xs text-secondary mb-0">Organization</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-success">Online</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="javascript:;" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  Edit
                                                </a>
                                              </td>
                                            </tr>

                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-3.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">Alexa Liras</h6>
                                                    <p class="text-xs text-secondary mb-0">alexa@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Programator</p>
                                                <p class="text-xs text-secondary mb-0">Developer</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-secondary">Offline</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="#!" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  View
                                                </a>
                                              </td>
                                            </tr>


                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-3.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">Alexa Liras</h6>
                                                    <p class="text-xs text-secondary mb-0">alexa@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Programator</p>
                                                <p class="text-xs text-secondary mb-0">Developer</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-secondary">Offline</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="#!" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  View
                                                </a>
                                              </td>
                                            </tr>


                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-3.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">Alexa Liras</h6>
                                                    <p class="text-xs text-secondary mb-0">alexa@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Programator</p>
                                                <p class="text-xs text-secondary mb-0">Developer</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-secondary">Offline</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="#!" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  View
                                                </a>
                                              </td>
                                            </tr>
                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-4.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">Laurent Perrier</h6>
                                                    <p class="text-xs text-secondary mb-0">laurent@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Executive</p>
                                                <p class="text-xs text-secondary mb-0">Projects</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-success">Online</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="#!" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  View
                                                </a>
                                              </td>
                                            </tr>

                                            <tr>
                                              <td>
                                                <div class="d-flex px-2 py-1">
                                                  <div>
                                                    <img src="https://demos.creative-tim.com/soft-ui-design-system-pro/assets/img/team-4.jpg" class="avatar avatar-sm me-3">
                                                  </div>
                                                  <div class="d-flex flex-column justify-content-center">
                                                    <h6 class="mb-0 text-xs">Miriam Eric</h6>
                                                    <p class="text-xs text-secondary mb-0">miriam@creative-tim.com</p>
                                                  </div>
                                                </div>
                                              </td>
                                              <td>
                                                <p class="text-xs font-weight-bold mb-0">Programtor</p>
                                                <p class="text-xs text-secondary mb-0">Developer</p>
                                              </td>
                                              <td class="align-middle text-center text-sm">
                                                <span class="badge badge-sm badge-secondary">Offline</span>
                                              </td>
                                              <td class="align-middle">
                                                <a href="#!" class="text-secondary font-weight-bold text-xs" data-toggle="tooltip" data-original-title="Edit user">
                                                  View
                                                </a>
                                              </td>
                                            </tr>
                                          </tbody>
                                        </table>
                                    </div>
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
            <div class="col-xl-5 ms-auto mt-xl-0 mt-4">
                <div class="row">
                    <div class="col-12">
                        <div class="sidenav-footer">
                            <div class="card card-background shadow-none card-background-mask-secondary" id="sidenavCard">
                                <div class="full-background" style="background-image: url('assets/img/curved-images/white-curved.jpeg')"></div>
                                <div class="card-body text-left p-3 w-100">
                                    <div class="row">
                                      <div class="col-8 my-auto">
                                          <div class="numbers">
                                              <p class="text-white text-sm mb-0 text-capitalize font-weight-bold opacity-7">System Rating</p>
                                                 <h5 class="text-white font-weight-bolder mb-0">Good</h5>
                                          </div>
                                      </div>
                                      <div class="col-4 text-end">
                                          <h5 class="mb-0 text-white text-end me-1" style="font-size:35px;">70 %</h5>
                                      </div>
                                    </div>                                
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;box-shadow: 0px 0px 20px 6px #66c6f5 inset;border-radius: 10px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status1" countto="05">05</span> </h1>
                                <h6 class="mb-0 font-weight-bolder">Jobs Worked</h6>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mt-md-0 mt-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status2" countto="03">03</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submissions</h6>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status3" countto="20">20</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission to TL</h6>

                            </div>
                        </div>
                    </div>
                </div>
                <div class="row mt-4">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status3" countto="20">20</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Submission to BP</h6>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 mt-md-0 mt-4">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status4" countto="30">01</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Closure Candidates</h6>

                            </div>
                        </div>
                    </div>
                    <div class="col-md-4 divhide">
                        <div class="card">
                            <div class="card-body text-center" style="padding: 24px 0px 24px 0px;cursor:pointer;">
                                <h1 class="text-gradient text-primary"><span id="status3" countto="20">20</span></h1>
                                <h6 class="mb-0 font-weight-bolder">Candidates Added</h6>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row mt-4">
            <div class="col-lg-4 ms-auto">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Active Candidates</h6>

                        </div>
                    </div>
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-5 text-center">
                                <div class="chart">
                                    <canvas id="chart-consumption" class="chart-canvas" height: "197px"; width: "106px;"></canvas>
                                </div>
                                <h4 class="font-weight-bold mt-n7">
                                    <span>70%</span>
                                    <span class="d-block text-body text-sm">Good</span>
                                </h4>
                            </div>
                            <div class="col-7">
                                <div class="table-responsive">
                                    <table class="table align-items-center mb-0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-primary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submissions</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">15% </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to TL</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">20% </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to BP</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">5% </span>
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

            <div class="col-lg-4 ms-auto">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Submission Overview</h6>

                        </div>
                    </div>
                    <div class="card-body p-3">
                        <div class="row">
                            <div class="col-5 text-center">
                                <div class="chart">
                                    <canvas id="chart-consumption" class="chart-canvas" height: "197px"; width: "106px;"></canvas>
                                </div>
                                <h4 class="font-weight-bold mt-n8">
                                    <span>70%</span>
                                    <span class="d-block text-body text-sm">Good</span>
                                </h4>
                            </div>
                            <div class="col-7">
                                <div class="table-responsive">
                                    <table class="table align-items-center mb-0">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-primary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submissions</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">15% </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to TL</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">20% </span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div class="d-flex px-2 py-0">
                                                        <span class="badge bg-gradient-secondary me-3"></span>
                                                        <div class="d-flex flex-column justify-content-center">
                                                            <h6 class="mb-0 text-sm">Submission to BP</h6>
                                                        </div>
                                                    </div>
                                                </td>
                                                <td class="align-middle text-center text-sm">
                                                    <span class="text-xs font-weight-bold">5% </span>
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

            <div class="col-lg-4 mt-lg-0 mt-4">
                <div class="card h-100">
                    <div class="card-header pb-0 p-3">
                        <div class="d-flex align-items-center">
                            <h6 class="mb-0">Performance overview</h6>
                            <button type="button" class="btn btn-icon-only btn-rounded btn-outline-secondary mb-0 ms-2 btn-sm d-flex align-items-center justify-content-center ms-auto" data-bs-toggle="tooltip" data-bs-placement="bottom" title="See the consumption per room">
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
            </div>
        </div>
    </div>


    <script src="http://code.jquery.com/jquery-1.8.2.js"></script>
    <script src="http://code.jquery.com/ui/1.9.1/jquery-ui.js"></script>


    <script>

        function getcandidateList(filterVal) {
            if (filterVal == "TLSubmitted") {
                $("#div_TLSubmitted").removeClass("colorgray");
                $("#div_TotSubmitted").addClass("colorgray");
                $("#div_BPSubmitted").addClass("colorgray");
                $("#div_ECSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Submitted to TL-Candidate List");

            }
            else if (filterVal == "BPSubmitted") {
                $("#div_BPSubmitted").removeClass("colorgray");
                $("#div_TotSubmitted").addClass("colorgray");
                $("#div_TLSubmitted").addClass("colorgray");
                $("#div_ECSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Submitted to BP-Candidate List");
            }
            else if (filterVal == "ECSubmitted") {
                $("#div_ECSubmitted").removeClass("colorgray");
                $("#div_TotSubmitted").addClass("colorgray");
                $("#div_TLSubmitted").addClass("colorgray");
                $("#div_BPSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Submitted to EC-Candidate List");
            }
            else if (filterVal == "All") {
                $("#anchOverview").removeClass("change_color");
                $("#anchviewperfom").addClass("change_color");
                $("#anchgivefeedback").removeClass("change_color");
                $("#anchDraft").removeClass("change_color");

                $("#div_ECSubmitted").addClass("colorgray");
                $("#div_TotSubmitted").removeClass("colorgray");
                $("#div_TLSubmitted").addClass("colorgray");
                $("#div_BPSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Candidate List");
            }
            else if (filterVal == "Follow") {
                filterType = "Follow";
                $("#anchOverview").removeClass("change_color");
                $("#anchviewperfom").removeClass("change_color");
                $("#anchgivefeedback").addClass("change_color");
                $("#anchDraft").removeClass("change_color");

                $("#div_ECSubmitted").addClass("colorgray");
                $("#div_TotSubmitted").addClass("colorgray");
                $("#div_TLSubmitted").addClass("colorgray");
                $("#div_BPSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Follow Up-Candidate List");
            }
            else if (filterVal == "Draft") {
                $("#anchOverview").removeClass("change_color");
                $("#anchviewperfom").removeClass("change_color");
                $("#anchgivefeedback").removeClass("change_color");
                $("#anchDraft").addClass("change_color");

                $("#div_ECSubmitted").addClass("colorgray");
                $("#div_TotSubmitted").addClass("colorgray");
                $("#div_TLSubmitted").addClass("colorgray");
                $("#div_BPSubmitted").addClass("colorgray");
                $("#lblTableheader").text("Drafted-Candidate List");
            }


            //var TWE_Id = getSession('TWE_ID');
            //var st = getSession('Duration').split("$");

            //var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1], "filter": filterVal };
            //if (TWE_Id != "") {
            //    common_api_ajax_request("api/CandidateOveviewIndiaList", "CANDOVERVIEWLIST", strdata);
            //}
        }

        var ctx1 = document.getElementById("chart-consumption").getContext("2d");

        var gradientStroke1 = ctx1.createLinearGradient(0, 230, 0, 50);

        gradientStroke1.addColorStop(1, 'rgba(203,12,159,0.2)');
        gradientStroke1.addColorStop(0.2, 'rgba(72,72,176,0.0)');
        gradientStroke1.addColorStop(0, 'rgba(203,12,159,0)'); //purple colors

        new Chart(ctx1, {
            type: "doughnut",
            data: {
                labels: ['Submissions', 'TL Submissions', 'BP Submissions'],
                datasets: [{
                    label: "Consumption",
                    weight: 9,
                    cutout: 90,
                    tension: 0.9,
                    pointRadius: 2,
                    borderWidth: 2,
                    backgroundColor: ['#FF0080', '#A8B8D8', '#21d4fd'],
                    data: [15, 20, 13],
                    fill: false
                }],
            },
            options: {
                responsive: true,
                cutoutPercentage: 93,
                maintainAspectRatio: false,
                legend:
                {
                    display: false
                },
                plugins: {
                    legend: {
                        display: false,
                    }
                },
                interaction: {
                    intersect: false,
                    mode: 'index',
                },
                scales: {
                    y: {
                        grid: {
                            drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false,
                        },
                        ticks: {
                            display: false
                        }
                    },
                    x: {
                        grid: {
                            drawBorder: false,
                            display: false,
                            drawOnChartArea: false,
                            drawTicks: false,
                        },
                        ticks: {
                            display: false,
                        }
                    },
                },
            },
        });

    </script>

    <script>

        function opendiv(div_name1, div_name2) {
            $(div_name2).addClass("divhide");
            $(div_name2).removeClass("divshow");
            $(div_name1).addClass("divshow");
            $(div_name1).removeClass("divhide");
        }

        function displayContent(event, contentNameID) {

            let content =
                document.getElementsByClassName("contentClass");
            let totalCount = content.length;

            // Loop through the content class
            // and hide the tabs first
            for (let count = 0;
                count < totalCount; count++) {
                content[count].style.display = "none";
            }

            let links =
                document.getElementsByClassName("linkClass");
            totalLinks = links.length;

            // Loop through the links and
            // remove the active class
            for (let count = 0;
                count < totalLinks; count++) {
                links[count].classList.remove("active");
            }

            // Display the current tab
            document.getElementById(contentNameID)
                .style.display = "block";

            // Add the active class to the current tab
            event.currentTarget.classList.add("active");
        }

        function data_Week(txtname) {
            var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

            var date = new Date($('#' + txtname).val().substring(6, 10), (parseInt($('#' + txtname).val().substring(3, 5)) - 1), $('#' + txtname).val().substring(0, 2));


            var firstDay =
                new Date(date.getFullYear(), date.getMonth(), 1);

            var lastDay =
                new Date(date.getFullYear(), date.getMonth() + 1, 0);


            var DateBind = firstDay.getDate() + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " to " + lastDay.getDate() + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();
            var stdate = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
            var etdate = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
            document.getElementById(txtname).value = DateBind;

            if (txtname == "txtFeedbackdate") {
                mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();

                document.getElementById("hdnstartdate").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
                document.getElementById("hdnenddate").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
                $('#lblmonthname').text(mgrfeedback);
                $('#div_feedbackweek').addClass("divshow");
                $('#div_monthpicker').removeClass("divshow");
                $('#div_feedbackweek').removeClass("divhide");
                $('#div_monthpicker').addClass("divhide");
                //$('#btn01').click(); 
                $('#btn01').addClass("active");
                displayContent('click', 'interview');
                //getMgrDashboardPage(stdate, etdate, "Weekly");

            }

            else if (txtname == "txtFeedbackdatefb") {
                document.getElementById("hdnfirstday").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
                document.getElementById("hdnlastday").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
                document.getElementById("hdnchartdate").value = DateBind;
            }

        }

        function data_Week1(txtname) {
            var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

            var date = new Date($('#' + txtname).val().substring(6, 10), (parseInt($('#' + txtname).val().substring(3, 5)) - 1), $('#' + txtname).val().substring(0, 2));


            var firstDay =
                new Date(date.getFullYear(), date.getMonth(), 1);

            var lastDay =
                new Date(date.getFullYear(), date.getMonth() + 1, 0);


            var DateBind = firstDay.getDate() + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " to " + lastDay.getDate() + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();
            var stdate = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
            var etdate = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
            document.getElementById(txtname).value = DateBind;

            if (txtname == "txtFeedbackdatewk") {
                mgrfeedback = pad2(firstDay.getDate()) + " " + arr[firstDay.getMonth()] + " " + firstDay.getFullYear() + " To " + pad2(lastDay.getDate()) + " " + arr[lastDay.getMonth()] + " " + lastDay.getFullYear();

                document.getElementById("hdnstartdate").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
                document.getElementById("hdnenddate").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
                $('#lblmonthname1').text(mgrfeedback);
                $('#div_monthweek').addClass("divshow");
                $('#div_weekmonthpicker').removeClass("divshow");
                $('#div_monthweek').removeClass("divhide");
                $('#div_weekmonthpicker').addClass("divhide");
                //$('#btn01').click(); 
                //$('#btn01').addClass("active");
                //displayContent('click', 'interview');
                //getMgrDashboardPage(stdate, etdate, "Weekly");

            }

            else if (txtname == "txtFeedbackdatefb") {
                document.getElementById("hdnfirstday").value = firstDay.getFullYear() + "-" + (parseInt(firstDay.getMonth()) + parseInt(1)) + "-" + firstDay.getDate();
                document.getElementById("hdnlastday").value = lastDay.getFullYear() + "-" + (parseInt(lastDay.getMonth()) + parseInt(1)) + "-" + lastDay.getDate();
                document.getElementById("hdnchartdate").value = DateBind;
            }

        }

    </script>

</asp:Content>
