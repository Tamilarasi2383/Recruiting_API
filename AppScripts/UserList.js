var strTile = "";
$(document).ready(function () {
    setSession("Page", "UserMaster");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#li_job').css('display', 'none');
    $('#li_cand').css('display', 'none');
    $('#li_vendor').css('display', 'none');
    $('#li_user').css('display', 'block');
    $('#li_client').css('display', 'block');
    $('#li_config').css('display', 'block');

    $('#lblEmployeename').text(getSession('Name'));
    $('#lblPagetitle').text("User List");
    $("#anchDashboard").removeClass("active");
    $("#anchUser").addClass("active");
    $("#anchClient").removeClass("active");
    $("#anchConfig").removeClass("active");

    getUserlist();

});

function getUserlist() {

    var strdata = { "Userid": "" };

    common_api_ajax_request("api/ViewUserProfile", "USERLIST", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "USERLIST") {
        createUserTable(resData.LstbasicInfo);
        getPaging(5);
        //getPagination('#tblUserlist', 5);
        stopLoader();
    }
    
}


function createUserTable(data) {
    $("#tblUserlist tbody").empty();
    var strTable = "";

    $.each(data, function (key, item) {

        if (item.userid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.firstname + ' ' + item.lastname+ "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.region + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.role + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.level + "</label></td>" +
                "<td class=''>" +
                "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_Userprofile.aspx?id=" + item.TWE_ID + "&Mode=V' id='View'>View</a></li>" +
                "<li><a class='dropdown-item border-radius-md' href='Superadmin_Userprofile.aspx?id=" + item.TWE_ID + "&Mode=U' id='Edit'>Edit</a></li>" +
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
                //"<li><a class='dropdown-item border-radius-md' href='Superadmin_Userprofile.aspx?id=" + item.userid + "&Mode=V' id='View'>View</a></li>" +
                //"<li><a class='dropdown-item border-radius-md' href='Superadmin_Userprofile.aspx?id=" + item.userid + "&Mode=U' id='Edit'>Edit</a></li>" +
                //"</ul></div></div></td></tr>";

            //"<td class='align-middle text-center'>" +
            //"<div class='col-lg-3 col-1 my-auto text-end' style='float: right;'>" +
            //"<div class='dropdown float-lg-end pe-1'>" +
            //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            //"<i class='fa fa-ellipsis-v text-secondary'></i>" +
            //"</a>" +
            //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            //"<li><a class='dropdown-item border-radius-md' href='Superadmin_UserMaster.aspx?id=" + item.TaretfixingId + "&Mode=V' id='View'>View</a></li>" +
            //"<li><a class='dropdown-item border-radius-md' href='Superadmin_UserMaster.aspx?id=" + item.TaretfixingId + "&Mode=U' id='Edit'>Edit</a></li>" +
            ////"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='delete'>Delete</a></li>"+
            //"</ul></div></div></td></tr>";
        }

    });

    $("#tblUserlist tbody").append(strTable);

}