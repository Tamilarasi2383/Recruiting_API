<%@ Page Title="" Language="C#" MasterPageFile="~/RecruitingApp.Master" AutoEventWireup="true" CodeBehind="ManagerdashboardIndia.aspx.cs" Inherits="Recruiting_API.ManagerdashboardIndia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <link href="assets/css/Common.css" rel="stylesheet" />
    <script src="assets/js/plugins/chartjs.min.js"></script>
    <script src="assets/js/plugins/Chart.extension.js"></script>

    <style>
        /*----------------genealogy-scroll----------*/

.genealogy-scroll::-webkit-scrollbar {
    width: 5px;
    height: 8px;
}
.genealogy-scroll::-webkit-scrollbar-track {
    border-radius: 10px;
    background-color: #e4e4e4;
}
.genealogy-scroll::-webkit-scrollbar-thumb {
    background: #212121;
    border-radius: 10px;
    transition: 0.5s;
}
.genealogy-scroll::-webkit-scrollbar-thumb:hover {
    background: #d5b14c;
    transition: 0.5s;
}


/*----------------genealogy-tree----------*/
.genealogy-body{
    white-space: nowrap;
    overflow-y: hidden;
    padding: 50px;
    min-height: 500px;
    padding-top: 10px;
    text-align: center;
}
.genealogy-tree{
  display: inline-block;
}
.genealogy-tree ul {
    padding-top: 20px; 
    position: relative;
    padding-left: 0px;
    display: flex;
    justify-content: center;
}
.genealogy-tree li {
    float: left; text-align: center;
    list-style-type: none;
    position: relative;
    padding: 20px 20px 0 5px;
}
.genealogy-tree li::before, .genealogy-tree li::after{
    content: '';
    position: absolute; 
  top: 0; 
  right: 45%;
    border-top: 2px solid #ccc;
    width: 51%; 
  height: 18px;
}
.genealogy-tree li::after{
    right: auto; left: 55%;
    border-left: 2px solid #ccc;
}
.genealogy-tree li:only-child::after, .genealogy-tree li:only-child::before {
    display: none;
}
.genealogy-tree li:only-child{ 
    padding-top: 0;
}
.genealogy-tree li:first-child::before, .genealogy-tree li:last-child::after{
    border: 0 none;
}
.genealogy-tree li:last-child::before{
    border-right: 2px solid #ccc;
    border-radius: 0 5px 0 0;
    -webkit-border-radius: 0 5px 0 0;
    -moz-border-radius: 0 5px 0 0;
}
.genealogy-tree li:first-child::after{
    border-radius: 5px 0 0 0;
    -webkit-border-radius: 5px 0 0 0;
    -moz-border-radius: 5px 0 0 0;
}
.genealogy-tree ul ul::before{
    content: '';
    position: absolute; top: -20px; left: 50%;
    border-left: 2px solid #ccc;
    width: 0; height: 40px;
}
.genealogy-tree li a{
    text-decoration: none;
    color: #666;
    font-family: arial, verdana, tahoma;
    font-size: 11px;
    display: inline-block;
    border-radius: 5px;
    -webkit-border-radius: 5px;
    -moz-border-radius: 5px;
}

.genealogy-tree li a:hover+ul li::after, 
.genealogy-tree li a:hover+ul li::before, 
.genealogy-tree li a:hover+ul::before, 
.genealogy-tree li a:hover+ul ul::before{
    border-color:  #fbba00;
}

/*--------------memeber-card-design----------*/
.member-view-box{
    padding:0px 20px;
    text-align: center;
    border-radius: 4px;
    position: relative;
}
.member-image{
    width: 80px;
    position: relative;
}
.member-image img{
    width: 60px;
    height: 60px;
    border-radius: 6px;
  background-color :#000;
  z-index: 1;
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
            <div class="col-md-12 text-center">
                <h6 class="mb-0">Team Members List</h6>
            </div>
        </div>
        
        <div class="body genealogy-body genealogy-scroll">
        <%--<button id="btnshow" type="button" class="btn bg-gradient-primary btn-sm mb-0 ms-lg-auto me-lg-0 me-auto mt-lg-0 btn-resize" onclick="();">Show</button>--%>
        <div class="genealogy-tree" id="div_team">

            <%--<ul>
                <li>
                    <a href="javascript:void(0);">
                        <div class="member-view-box">
                            <div class="member-image">
                                <img src="Images/userimg.png" />
                                <div class="member-details">
                                    <h5 style="margin-left: -35px;color: #fa8e2e;">Mohan Nambi</h5>
                                    <h6  style="margin-top: -19px;color: #2ed8fa;">Manager</h6>
                                </div>
                            </div>
                        </div>
                    </a>
                    <ul class="active">
                        <li>
                            <a href="javascript:void(0);">
                                <div class="member-view-box">
                                    <div class="member-image">
                                        <img src="Images/userimg.png" />
                                        <div class="member-details">
                                            <h5 style="margin-left: -37px;color: #fa8e2e;">Rexaline Vinola</h5>
                                            <h6 style="margin-left: -8px;margin-top: -19px;color: #2ed8fa;">Team Lead</h6>
                                        </div>
                                    </div>
                                </div>
                            </a>
                            <ul >
                                <li>
                                    <a href="javascript:void(0);">
                                        <div class="member-view-box">
                                            <div class="member-image">
                                                <img src="Images/userimg.png" />
                                                <div class="member-details">
                                                    <h5 style="margin-left: -29px;font-size: 14px;color: #fac32e;">Narmatha Selvaraj</h5>
                                                    <h6 style="margin-left: -3px;margin-top: -15px;color: #2ed8fa;font-size: 14px;">Recruiter</h6>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                                <li>
                                    <a href="javascript:void(0);">
                                        <div class="member-view-box">
                                            <div class="member-image">
                                                <img src="Images/userimg.png" />
                                                <div class="member-details">
                                                    <h5 style="font-size: 14px;color: #fac32e;">Sherine</h5>
                                                    <h6 style="margin-top: -15px;color: #2ed8fa;font-size: 14px;">Recruiter</h6>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </li>
            </ul>--%>

        </div>
    </div>


    </div>


    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/plugins.js"></script>
    <script src="assets/js/prop/commondatastore.js"></script>
   
    <script>
        
        $(function () {
            $('.genealogy-tree ul').hide();
            $('.genealogy-tree>ul').show();
            $('.genealogy-tree ul.active').show();
            $('.genealogy-tree li').on('click', function (e) {
               
                var children = $(this).find('> ul');
                if (children.is(":visible")) children.hide('fast').removeClass('active');
                else children.show('fast').addClass('active');
                e.stopPropagation();
            });
        });

    </script>
    <script src="AppScripts/MgrDashboardIndia.js"></script>
</asp:Content>
