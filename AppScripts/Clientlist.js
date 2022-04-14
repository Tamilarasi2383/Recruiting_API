$(document).ready(function () {
    setSession("Page", "Clientlist");

    
    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $('#lblPagetitle').text("Client");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").addClass("active");
    $("#anchConfig").removeClass("active");
    getClientPage();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});


function getClientPage() {
    var strdata = {};

    common_api_ajax_request("api/ClientList", "CLIENTLIST", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;
    var listdata = resData.lstVen;

    if (key == "CLIENTLIST") {
        createVendorTable(listdata);
        getPaging(5);
        //getPagination('#tblClientlist', 5);
        stopLoader();
    }

}


function createVendorTable(data) {
    $("#tblClientlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.vendorid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.vendorname + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.noofrecruiter + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.submittedby + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.status + "</label></td>" +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "</tr>";


                //"<td class='align-middle text-center'>" +
                //"<div class='col-lg-3 col-1 my-auto text-end'>" +
                //"<div class='dropdown float-lg-end pe-1'>" +
                //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                //"<i class='fa fa-ellipsis-v text-secondary'></i>" +
                //"</a>" +
                //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                //"<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
                //"<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
                //"</ul></div></div></td></tr>";


            //"<td class='align-middle text-center'>" +
            //"<div class='col-lg-3 col-1 my-auto text-end' style='float: right;'>" +
            //"<div class='dropdown float-lg-end pe-1'>" +
            //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //"<i class='fa fa-ellipsis-v text-secondary'></i>" +
            //"</a>" +
            //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //"<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
            //"<li><a class='dropdown-item border-radius-md' href='Client.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
            ////"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='delete'>Delete</a></li>" +
            //"</ul></div></div></td></tr>";
        }

    });

    $("#tblClientlist tbody").append(strTable);

}


