var strTile = "";
$(document).ready(function () {
    setSession("Page", "TargetMaster");

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
    $('#lblPagetitle').text("Config Tables-Target");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").removeClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").addClass("active");

    getTargetlist();

});

function getTargetlist() {

    var strdata = { "targetfixingid": "" };

    common_api_ajax_request("api/getTargetfixingid", "TARGETLIST", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "TARGETLIST") {
        createTargetTable(resData);
        getPaging(5);
        stopLoader();
    }

}


function createTargetTable(data) {
    $("#tblTargetlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.TargetfixingId == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.RoleType + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.LevelType + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.RegionType + "</label></td>" +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_TargetMaster.aspx?id=" + item.TargetfixingId + "&Mode=V' id='View'>View</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_TargetMaster.aspx?id=" + item.TargetfixingId + "&Mode=U' id='Edit'>Edit</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>" +
                "</td>" +
                "</tr>";

            //"<td class='align-middle text-center'>" +
            //"<div class='col-lg-3 col-1 my-auto text-end' style='float: right;'>" +
            //"<div class='dropdown float-lg-end pe-1'>" +
            //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //"<i class='fa fa-ellipsis-v text-secondary'></i>" +
            //"</a>" +
            //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //"<li><a class='dropdown-item border-radius-md' href='Superadmin_TargetMaster.aspx?id=" + item.TaretfixingId + "&Mode=V' id='View'>View</a></li>" +
            //"<li><a class='dropdown-item border-radius-md' href='Superadmin_TargetMaster.aspx?id=" + item.TaretfixingId + "&Mode=U' id='Edit'>Edit</a></li>" +
            ////"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='delete'>Delete</a></li>"+
            //"</ul></div></div></td></tr>";
        }

    });

    $("#tblTargetlist tbody").append(strTable);

}