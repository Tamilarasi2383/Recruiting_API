var strTile = "";
$(document).ready(function () {
    setSession("Page", "MenuMaster");

    $('#lblEmployeename').text(getSession('Name'));

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');


    $('#lblEmployeename').text(getSession('Name'));
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Config Tables-Menu");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");


    getMenulist();
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function getMenulist() {

    var strdata = { "menuaccessId": "" };
    common_api_ajax_request("api/getMenuAccess", "MENULIST", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "MENULIST") {
        createMenuTable(resData);
        getPaging(5);
        stopLoader();
    }

}


function createMenuTable(data) {
    $("#tblMenulist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.menuaccessid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.roleid + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.regionid + "</label></td>" +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_MenuMaster.aspx?id=" + item.menuaccessid + "&Mode=V' id='View'>View</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_MenuMaster.aspx?id=" + item.menuaccessid + "&Mode=U' id='Edit'>Edit</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "</tr>";
        }

    });

    $("#tblMenulist tbody").append(strTable);

}