<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ClosureCandidateListIndia.aspx.cs" Inherits="Recruiting_API.ClosureCandidateListIndia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <style>
        .colorgray{
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

    
    <!-- End Navbar -->
    <div class="container-fluid py-4">
        

        <div class="card">
            <div class="row mt-4">
                <div class="col-12">
                    <h5 class="ms-3"><span id="lblTableheader">Closure Candidate List</span></h5>

                    <div class="">

                        <div class="dataTable-top mt-2">

                            <div class="dataTable-dropdown">
                                <label style="margin-bottom: 0; margin-left: 0; color: #8392ab; font-weight: 400;">
                                    <select class="count-list" id="maxRows">
                                        <option value="5">5</option>
                                        <option value="10">10</option>
                                        <option value="15">15</option>
                                        <option value="20">20</option>
                                        <option value="25">25</option>
                                    </select>
                                    entries per page</label>
                            </div>

                            <div class="dataTable-search" style="width: 50%;">
                                <div class="col-md-12">
                                    <div class="row">
                                        <div class="col-md-4 mt-2 text-right p-0">
                                            <span class="text-bold" id="lblSearch">Search</span>
                                            <span class="text-bold" id="lblAdvSearch" style="display: none;">Advance Search</span>
                                        </div>
                                        <div class="col-md-1 mt-2 p-0">
                                            <div class="form-group mb-0">
                                                <div class="form-check form-switch ms-1" onclick="openEmployer()">
                                                    <input class="form-check-input" type="checkbox" id="chkSearch" name="chkSearch" data-type="warning" data-content="Once a project is made private, you cannot revert it to a public project." data-title="Warning" data-icon="ni ni-bell-55">
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-5">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="Search..." type="text" id="txtSearch">
                                            <input class="dataTable-input dataTable-input2 w-100" placeholder="column1,column2,column3,column4" type="text" id="txtAdvSearch" style="display: none;" onkeyup="return keyValidation(this,'tblCandlist');">
                                        </div>
                                        <div class="col-md-2">

                                        </div>
                                    </div>
                                </div>

                                <%----%>
                                <%--onkeyup="return keyValidation(this);"--%>
                            </div>
                        </div>


                        <table class="table align-items-center mb-0" id="tblCandlist">
                            <thead>
                                <tr>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7"></th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Candidates</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Vendor</th>
                                    <th class="text-center text-uppercase text-secondary text-xxs font-weight-bolder opacity-7">Status</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Submitted By</th>
                                    <th class="text-uppercase text-secondary text-xxs font-weight-bolder opacity-7 ps-2">Action</th>
                                </tr>
                            </thead>
                            <tbody>
                            </tbody>
                        </table>

                        <%--<div class="dataTable-bottom">
                            <div class="dataTable-info" id="divInfo"></div>
                            <nav>
                                <ul id="paginus" class="pagination pagination-info">
                                </ul>
                            </nav>
                        </div>--%>

                        <div class="dataTable-bottom">
                            <div class="dataTable-info" id="divInfo"></div>
                            <div id="paginus" class="pagination pagination-info">
                                <div class="prev"><i class='ni ni-bold-left' aria-hidden='true'></i></div>
                                <div class="pagination pagination-info" id="divPages"></div>
                                <div class="next"><i class='ni ni-bold-right' aria-hidden='true'></i></div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


    </div>

    </div>

    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
    <script src="AppScripts/Table.js"></script>
    <script src="AppScripts/ClosureCandidateListIndia.js"></script>



 <script>

        function openEmployer() {
            if ($('input[name="chkSearch"]:checked').val() == "on") {
                document.getElementById("txtSearch").style.display = "none";
                document.getElementById("txtAdvSearch").style.display = "block";

                document.getElementById("lblSearch").style.display = "none";
                document.getElementById("lblAdvSearch").style.display = "block";
                enableemplcontrols();
            }
            else {
                document.getElementById("txtSearch").style.display = "block";
                document.getElementById("txtAdvSearch").style.display = "none";

                document.getElementById("lblSearch").style.display = "block";
                document.getElementById("lblAdvSearch").style.display = "none";
            }
        }


        $(document).ready(function () {
            $("#txtSearch").on("keyup", function () {
                var value = $(this).val().toLowerCase();

                $("#tblCandlist tr").filter(function () {
                    $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)

                    //var totalRows = $(table + ' tbody tr').length; 
                    var len = $('table tbody tr:not([style*="display: none"])').length;
                    //var trWithoutDisplayNone =$("#tblJoblist").find('tr:not([style*="display: none"])').length;
                    //alert(len);

                    //getPager("#tblCandlist", 5);
                });

                getSearchPaging($('select#maxRows option:selected').val());

            });

        });

        

    </script>

</asp:Content>