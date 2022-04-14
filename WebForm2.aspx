<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="Recruiting_API.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .prev {
            display: none;
            float: left;
            margin: 8px 10px;
        }

        #divPages {
            float: left;
        }

            #divPages div {
                float: left;
                margin: 5px 10px;
            }

        .next {
            float: left;
            margin: 8px 10px;
        }

        .pageselect {
            background-image: linear-gradient(310deg,#2152ff,#21d4fd) !important;
            border: none !important;
            z-index: 3 !important;
            color: #fff !important;
    padding-left: 0;
    list-style: none;
        }

        .page {
            cursor: pointer;
            align-items: center;
            justify-content: center;
            color: #8392ab;
            padding: 5px 5px 5px 13px !important;
            margin: 0 3px;
            border-radius: 50% !important;
            width: 36px;
            height: 36px;
            font-size: .875rem;
            position: relative !important;
            background-color: #fff !important;
            border: 1px solid #dee2e6 !important;
            transition: color .15s ease-in-out,background-color .15s ease-in-out,border-color .15s ease-in-out,box-shadow .15s ease-in-out;
        }

    </style>

    <%--<div class="divControl">Abi</div>
<div class="divControl">Anant</div>
<div class="divControl">balraj</div>
<div class="divControl">devi</div>
<div class="divControl">manasha</div>
<div class="divControl">mani</div>
<div class="divControl">nimmi</div>
<div class="divControl">god</div>
<div class="divControl">gopal</div>
<div class="divControl">Abi</div>
<div class="divControl">Anant</div>
<div class="divControl">balraj</div>
<div class="divControl">devi</div>
<div class="divControl">manasha</div>
<div class="divControl">mani</div>
<div class="divControl">nimmi</div>
<div class="divControl">god</div>
<div class="divControl">gopal</div>
<div class="divControl">Abi</div>
<div class="divControl">Anant</div>
<div class="divControl">balraj</div>
<div class="divControl">devi</div>
<div class="divControl">manasha</div>
<div class="divControl">mani</div>
<div class="divControl">nimmi</div>
<div class="divControl">god</div>
<div class="divControl">gopal</div>--%>

    <div>
        <table class="table align-items-center mb-0" id="tblJoblist">
            <thead>
                <tr>
                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Jobs</th>
                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Client</th>
                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Job Open date </th>
                    <th class="text-secondary opacity-7"></th>
                </tr>
            </thead>
            <tbody>
                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">1.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">2.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-danger" id="spnClose">Closed</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">3.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnHold">Hold</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Salesforce.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">4.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnOffline">Offline</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">5.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">6.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-danger" id="spnClose">Closed</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">7.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnHold">Hold</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Salesforce.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">8.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnOffline">Offline</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">9.)Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-danger" id="spnClose">Closed</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnHold">Hold</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Salesforce.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnOffline">Offline</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-danger" id="spnClose">Closed</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnHold">Hold</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Salesforce.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-secondary" id="spnOffline">Offline</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">13/05/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>


                <tr class="divControl">
                    <td>
                        <div class="d-flex px-2 py-1">
                            <div>
                                <img src='Images/Sap.png' class="avatar avatar-sm me-3">
                            </div>
                            <div class="d-flex flex-column justify-content-center">
                                <label class="mb-0 text-sm h6" id="lblJobname">Salesforce Technical Architect</label>
                                <label class="m-0">
                                    <label class="text-secondary" id="lblJobmonth">12+ months</label>|<label class="text-secondary" id="lblJobcontract">Contract</label>|<label class="text-secondary" id="lblJobcity">Alanta, GA</label></label>
                            </div>
                        </div>
                    </td>
                    <td>
                        <div class="col-md-12">
                            <label class="text-xs font-weight-bold mb-0 ps-0" id="lblClient">CRMIT</label><br />
                        </div>
                        <div class="col-md-12" style="margin-top: -10px;">
                            <label class="text-xs text-secondary mb-0 ps-0" id="lblClientcont">Contact Rexaline</label>
                        </div>
                    </td>
                    <td class="align-middle text-center text-sm">
                        <span class="badge badge-sm bg-gradient-success" id="spnOpen">Open</span>
                    </td>
                    <td class="align-middle text-center">
                        <label class="text-secondary text-xs font-weight-bold mb-0 ps-0" id="lblJobopendate">07/04/21</label>
                    </td>
                    <td class="align-middle">
                        <div class="col-lg-3 col-1 my-auto text-end">
                            <div class="dropdown float-lg-end pe-1">
                                <a class="cursor-pointer" id="dropdownTable" data-bs-toggle="dropdown" aria-expanded="false">
                                    <i class="fa fa-ellipsis-v text-secondary"></i>
                                </a>
                                <ul class="dropdown-menu px-3 py-3 ms-sm-n8 ms-n3" aria-labelledby="dropdownTable">
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="View">View</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="javascript:;" id="Edit">Edit</a></li>
                                    <li><a class="dropdown-item border-radius-md" href="FollowupPage.aspx" id="Follow">Follow</a></li>
                                </ul>
                            </div>
                        </div>
                    </td>
                </tr>

                
            </tbody>
        </table>

        <div class="dataTable-bottom">
            <div class="dataTable-info" id="divInfo"> </div>
                <div id="paginus" class="pagination pagination-info">
                    <div class="prev"><i class='ni ni-bold-left' aria-hidden='true'></i></div>
                    <div class="pagination pagination-info" id="divPages"></div>
                    <div class="next"><i class='ni ni-bold-right' aria-hidden='true'></i></div>
                </div>
        </div>
    </div>




    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script>
        $(document).ready(function () {
            getPaging(5);
        });
    </script>
    <%--<script>
        $(document).ready(function () {
            var totalrows = $(".divControl").length;
            var pageSize = 5;

            var noOfPage = totalrows / pageSize;
            noOfPage = Math.ceil(noOfPage);
            for (var i = 1; i <= noOfPage; i++) {
                $("#divPages").append('<div class="page" id="page_'+i+'">' + i + '</div>');
            }
            var totalPagenum = $("div.page").length;
            if (totalPagenum > 3) {
                $("div.page").hide();
                for (var n = 1; n <= 3; n++) {
                    $("div.page:nth-child(" + n + ")").show();
                    $("#page_1").addClass('pageselect');
                }
            }
            else {
                $("div.next").hide();
                $("div.prev").hide();
            }
            $(".divControl").hide();
            for (var j = 1; j <= pageSize; j++) {
                $(".divControl:nth-child(" + j + ")").show();
            }
            displayevent();
            //$('#divInfo').text("Showing 1 to " + $('select#maxRows option:selected').val() + " of " + totalRows + " entries");

            $('#divInfo').text("Showing 1 to 5" + " of " + totalrows + " entries");
            $("div.next").click(function () {
                if ($("div.selected:last").nextAll('div.page').length > 3) {
                    $("div.selected").last().nextAll(':lt(3)').show();
                    $("div.selected").hide();
                    displayevent();
                    //lastposevent();
                    $("div.prev").show();
                    $("div.next").show();
                }
                else {
                    $("div.selected").last().nextAll().show();
                    $("div.selected").hide();
                    displayevent();
                    $("div.next").hide();
                    $("div.prev").show();
                }
            });
            $("div.prev").click(function () {
                if ($("div.selected:first").prevAll('div.page').length > 3) {
                    $("div.selected").first().prevAll(':lt(3)').show();
                    $("div.selected").hide();
                    $("div.prev").show();
                    $("div.next").show();
                    displayevent();
                }
                else {
                    $("div.selected").first().prevAll().show();
                    $("div.selected").hide();
                    $("div.prev").hide();
                    $("div.next").show();
                    displayevent();
                }
            });
            $("div.page").click(function () {
                var currentPage = $(this).text();
                $(".divControl").hide();
                for (var k = (currentPage * pageSize) - (pageSize - 1); k <= (currentPage * pageSize); k++) {
                    $(".divControl:nth-child(" + k + ")").show();                  
                   
                }
                for (var i = 1; i <= totalPagenum; i++) {
                    $("#page_" + i).removeClass('pageselect');
                }

                $("#page_" + currentPage).addClass('pageselect');
            });
        });
        function displayevent() {
            $("div.page").each(function () {
                if ($(this).css('display') === 'block') {
                    $(this).addClass('selected');
                    
                }
                else {
                    $(this).removeClass('selected');
                }
            });
        }

    </script>--%>

</asp:Content>

