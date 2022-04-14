$(document).ready(function () {
    setSession("Page", "Joblist");

    
    $('#lblEmployeename').text(getSession('Name'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").removeClass("active");
    $("#anchVend").addClass("active");
    $('#lblPagetitle').text("Vendor Search");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#anchVend').attr('aria-expanded', 'true');
    $("#div_Vend").addClass("show");
    $("#vendSearch").addClass("active");
    getSpecilization();
   
    //getJobPage(getSession('TWE_ID'), getSession('Duration'));    

});

function getSpecilization() {

    common_api_ajax_request("api/VendorForm", "VendorForm", "");
}


function getVendorPage() {
    var TWE_Id = getSession('TWE_ID');
    var specialization;
    if ($('select#drpSpecialization option:selected').val() == "-1") {
        specialization = "";
    }
    else {
        specialization = $('select#drpSpecialization option:selected').val();
    }
    
    var city = $("#txtCity").val();
    var location = $("#txtLocation").val();
    if ($('select#drpSpecialization option:selected').val() == "-1" && $("#txtCity").val() == "" && $("#txtLocation").val() == "") {

    }
    else {
        var strdata = { "TWE_Id": TWE_Id, "specialization": specialization, "city": city, "location": location };

        common_api_ajax_request("api/VendorSearch", "VENDORSER", strdata);
    }

    
    //common_api_ajax_request("RecruitingAPI/api/Dashboard", "DASHBOARD", strdata);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;
    var listdata = resData.lstContact;

    if (key == "VendorForm") {
        document.getElementById("drpSpecialization").options.length = 0;
        var option1 = new Option("--Select Specialization--", "-1");
        $(option1).html("--Select Specialization--");
        $("#drpSpecialization").append(option1);
        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSpecialization").append(option);
        }
               
        stopLoader();
        //getVendorPage();

    }

    else if (key == "VENDORSER") {
       
        if (listdata.length!=0) {
            $('#btnGetmail').css('display', 'initial');
        }
        createVendorTable(listdata);  
        

        if ($('#paginus').css('display') == 'none') {
            $("#paginus").css('display', 'flex');
        }
        
        getPaging(5);
        //getPagination('#tblVendorlist', 5);
        stopLoader();
    }
    else if (key == "VENDOREMAILLIST") {
        showmailid(listdata);
        stopLoader();
    }
}


function createVendorTable(data) {
    $("#tblVendorlist tbody").empty();
    var strTable = "";

    var strAction1 = "<td class=''>" +
        "<div class='col-md-6 text-center'>" +
        "<div class='dropdown float-lg-end pe-1'>" +
        "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
        "<i class='fa fa-ellipsis-v text-secondary'></i>" +
        "</a>" +

        "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>";

    var strAction3 = "</ul></div></div></td></tr>";

    var strAction21 = "";

    var strAction22 = "";
    
    $.each(data, function (key, item) {
        var assigneduser = item.createdby.includes(getSession('TWE_ID'));
        if (item.vendorid == "") {

        } else {
            strTable += "<tr class='divControl'>" +
                "<td class='align-middle' style='display:none;'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.vendorid + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.vendorname + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.specilization + "</label></td>" +
                "<td class='align-middle text-center'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.noofrecruiter + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.city + "</label></td>" +
                "<td class='align-middle'><label class='text-secondary text-xs font-weight-bold mb-0 ps-0'>" + item.country + "</label></td>";
                
            if (getSession('VendorView') == "2") {
                strAction21 = "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" ;
            }
            else if (getSession('VendorView') == "1") {
                if (assigneduser == true) {
                    strAction21 = "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=V' id='View'>View</a></li>" ;
                }
            }

            if (getSession('VendorEdit') == "2") {
                //if (assigneduser == true) {
                //}
                //else {
                strAction22 = "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>";
                //}
            }

            else if (getSession('VendorEdit') == "1") {
                if (assigneduser == true) {
                    strAction22 = "<li><a class='dropdown-item border-radius-md' href='Vendor.aspx?id=" + item.vendorid + "&Mode=U' id='Edit'>Edit</a></li>";
                }
            }

            strTable += strAction1 + strAction21 + strAction22 + strAction3;
        }

    });

    $("#tblVendorlist tbody").append(strTable);

}

var emailId = "";
function showmailid(data) {

    var strTable = "";

    $.each(data, function (key, item) {

        if (item.vendormailid == "") {

        } else {
            emailId += item.vendormailid + ";";
            
            strTable += "<label>" + item.vendormailid+"</label><br/>"
        }
        $("#hdnMailid").val(emailId);
    });
    $('#div_mail').empty();
    $('#div_mail').append(strTable);
    $("#getmail").modal('show');
}

function getMailid() {
    var table = $("#tblVendorlist")[0];

    var table1 = document.getElementById("tblVendorlist").getElementsByTagName("TBODY")[0];
    var rowCount = table1.rows.length;

    var paramArr = new Array;

    for (var i = 1; i <= rowCount; i++) {
        var parObj = {};
        parObj.vendorid = table.rows[i].cells[0].getElementsByTagName("label")[0].innerHTML;
        paramArr.push(parObj);


        //if (parseInt(table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML) != 1) {

        //table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML = parseInt(table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML) - parseInt(1);

    }
    var strdata = { "lstVen": paramArr };

    common_api_ajax_request("api/VendorEmail", "VENDOREMAILLIST", strdata);
    
}

function copyemail() {


    //var $temp = $('<input>');
    //$('body').append($temp);
    //$("#hdnMailid").val($(emailId));
    

    var copyText = document.getElementById("hdnMailid");

    /* Select the text field */
    copyText.select();
    copyText.setSelectionRange(0, 99999); /* For mobile devices */

    /* Copy the text inside the text field */
    navigator.clipboard.writeText(copyText.value);


    //$temp.val($(emailId)).select();
    
    //document.execCommand("Copy");
    //$temp.remove();
}


function cleardata() {

    $("#tblVendorlist tbody").empty();

    $('#divInfo').text("");
    $("#paginus").css('display', 'none');
    $("#txtCity").val("");
    $("#drpSpecialization").val("-1").prop("selected", true);
    $("#txtLocation").val("");

    $('#btnGetmail').css('display', 'none');

   
}