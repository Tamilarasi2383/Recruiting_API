$(document).ready(function () {
    setSession("Page", "Joblist");
    
    $('#lblPagetitle').text("Vendors");
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchVend").addClass("active");
    $('#anchVend').attr('aria-expanded', 'true');
    $("#div_Vend").addClass("show");
    $("#vendView").addClass("active");
    getVendorPage();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});


function getVendorPage() {
    var TWE_Id = getSession('TWE_ID');
    var st = getSession('Duration').split("$");

    var strdata = { "TWE_Id": TWE_Id, "Startdate": st[0], "Enddate": st[1] };

    common_api_ajax_request("api/VendorList", "VENDORLIST", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;
    var listdata = resData.lstVen;

    if (key == "VENDORLIST") {
        createVendorTable(listdata);
        getPaging(5);
        //getPagination('#tblVendorlist', 5);
        stopLoader();
    }

}


function createVendorTable(data) {
    $("#tblVendorlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.vendorid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.vendorname + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.noofrecruiter + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.status + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.submittedby + "</label></td>" +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
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
                //"<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
                //"<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
                //"</ul></div></div></td></tr>";


            //"<td class='align-middle text-center'>"+
            //"<div class='col-lg-3 col-1 my-auto text-end' style='float: right;'>"+
            //"<div class='dropdown float-lg-end pe-1'>"+
            //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>"+
            //"<i class='fa fa-ellipsis-v text-secondary'></i>"+
            //"</a>"+
            //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>"+
            //"<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" +
            //"<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>" +
            ////"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='delete'>Delete</a></li>"+
            //"</ul></div></div></td></tr>";
        }

    });

    $("#tblVendorlist tbody").append(strTable);

}


