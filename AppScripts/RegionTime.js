$(document).ready(function () {
    $('#lblEmployeename').text(getSession('Name'));
    setInterval("getDashboardTimer();", 1000);
    $('#lblPagetitle').text("Time Zone");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    //stopLoader();
});

function getDashboardTimer() {
    //common_api_ajax_request("RecruitingAPI/api/DashboardTimer", "TIMER", "");
    common_api_ajax_request("api/DashboardTimer", "TIMER", "");
}

function successCallBack(key, value) {
    var response = value.d;
    var resData = response.data;
    if (key == "TIMER") {
        var strTable = "";

        $('#lblEsttimezone').text(resData.Timezonelist[0].TimeZoneTime);
        $('#lblCsttimezone').text(resData.Timezonelist[1].TimeZoneTime);
        $('#lblMsttimezone').text(resData.Timezonelist[3].TimeZoneTime);
        $('#lblPsttimezone').text(resData.Timezonelist[2].TimeZoneTime);

        $("#tblTimezone tbody").empty();
        for (var i = 0; i < resData.Timezonelist.length; i++) {
            var str1;
            if (resData.Timezonelist[i].TimeZoneName == "India") {
                str1 = "<div class='d-flex px-2 py-1 align-items-center'>" +
                    "<div><img src='Images/IN.png' alt='Country flag' width='25' height='25'></div>" +
                    "<div class='ms-4'>" +
                    "<p class='text-xs font-weight-bold mb-0'>Region:</p>" +
                    "<h6 class='text-sm mb-0'>" + resData.Timezonelist[i].TimeZoneName + "</h6>" +
                    "</div></div>";
            }
            else {
                str1 = "<div class='d-flex px-2 py-1 align-items-center'>" +
                    "<div><img src='Images/US.png' alt='Country flag'></div>" +
                    "<div class='ms-4'>" +
                    "<p class='text-xs font-weight-bold mb-0'>Region:</p>" +
                    "<h6 class='text-sm mb-0'>" + resData.Timezonelist[i].TimeZoneName + "</h6>" +
                    "</div></div>";
            }

            strTable += "<tr><td>" + str1 + "</td>";

            strTable += "<td class='align-middle text-center'><div class='text-center'>" +
                "<p class='text-xs font-weight-bold mb-0'>Day:</p>" +
                "<h6 class='text-sm mb-0' id='lblEasternday'>" + resData.Timezonelist[i].TimeZoneDay + "</h6>" +
                "</div><td>";

            strTable += "<td class='align-middle text-center'><div class='text-center'>" +
                "<p class='text-xs font-weight-bold mb-0'>Date:</p>" +
                "<h6 class='text-sm mb-0' id='lblEasternday'>" + resData.Timezonelist[i].TimeZoneDate + "</h6>" +
                "</div></td>";

            strTable += "<td class='align-middle text-center'><div class='text-center'>" +
                "<p class='text-xs font-weight-bold mb-0'>Time:</p>" +
                "<h6 class='text-sm mb-0' id='lblEasternday'>" + resData.Timezonelist[i].TimeZoneTime + "</h6>" +
                "</div></td>";
        }
       


        $("#tblTimezone tbody").append(strTable);
    }

}