var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

var skillVal = "";
$(document).ready(function () {
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

    getSpecialization();

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        var params1 = hash[1].split("=");

        if (params1[1] == "V") {
            disableControls();
            $('#btnAdd').css('display', 'none');
            $('#btnSave').css('display', 'none');
        }
        else if (params1[1] == "U") {
            $('#btnAdd').css('display', 'initial');
            $('#btnSave').css('display', 'initial');
        }
        $('#hdnUpdateby').val(getSession('TWE_ID'));
        getClientFormData(params[1]);
    }
    else {
        var d1 = new Date;
        var dt = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
        var dt1 = dt.getDate() + " " + arr[dt.getMonth()] + " " + d1.getFullYear();
        $('#lblCreatedon').text(dt1);
        $('#hdnCreatedOn').val(d1.getFullYear() + "-" + pad2((parseInt(d1.getMonth() + 1))) + "-" + d1.getDate());

        $('#lblCreateby').text(getSession('Name'));
        $('#hdnCreatedBy').val(getSession('TWE_ID'));
        
    }


    
});

function getSpecialization() {

    common_api_ajax_request("api/VendorForm", "VendorForm", "");
}
function getClientFormData(clientid) {

    var strdata = { "clientid": clientid }
    common_api_ajax_request("api/viewClientList", "EDITCLIENT", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}

function pad2(number) {
    return (number < 10 ? '0' : '') + number
}
function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "VendorForm") {

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSpecialization").append(option);
        }

        var option1 = new Option("--Select Place of Supply--", "-1");
        $(option1).html("--Select Place of Supply--");
        $("#drpPlaceofSupply").append(option1);

        for (var i = 0; i < resData.lstrateType.length; i++) {

            var option = new Option(resData.lstrateType[i].Name, resData.lstrateType[i].ID);

            $(option).html(resData.lstrateType[i].Name);
            $("#drpPlaceofSupply").append(option);
        }
        stopLoader();
    }

    else if (key == "ADDCLIENT") {

        //alert("Record saved successfully");
        $("#div-message").text('Client added successfully');
        $('#btn_Div').css('display', 'none');
        $('#btnOk').css('display', 'block');
        $("#msgpopup").modal('show');
        $("#btnOk").attr("onclick", "window.location.href='Clientlist.aspx';");

        stopLoader();
    }

    else if (key == "EDITCLIENT") {
        $("#txtClientname").val(resData.employercorporationaname);
        $("#txtWebsite").val(resData.website);
        $("#txtLinkedinid").val(resData.linkedin);
        $("#drpVendor").val(resData.EmplType).prop("selected", true);
        $("#txtAddress").val(resData.address);
        $("#txtCity").val(resData.city);
        $("#txtCountry").val(resData.country);
        $("#txtComments").val(resData.employeradditionalinfo);
        $("#drpClient").val(resData.vendortype).prop("selected", true);
        $("#lblCreatedon").text(resData.CreatedOn);
        $("#lblCreatedby").text(resData.Created_By);
        $("#drpPlaceofSupply").val(resData.placeofsupply).prop("selected", true);        
        $("#lblUpdateOn").text(resData.UpdatedOn);
        $("#lblUpdateBy").text(resData.Updated_By);
        $("#hdnUpdateon").val(resData.Updated_On);
        options = Array.from(document.querySelectorAll('#drpSpecialization option'));

        resData.employerspecialization.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
        });


        var table = document.getElementById("tblCliConlist");
        table.style.display = "table";
        // document.getElementById("lblCount2").style = "display:none";

        var tBody = document.getElementById("tblCliConlist").getElementsByTagName("TBODY")[0];

        var tableHead = document.getElementById("tblCliConlist").getElementsByTagName("THEAD")[0];;

        //Add Row.
        

        var i = 1;
        
        for (var j = 0; j < resData.lstVencontact.length; j++) {

            row = tBody.insertRow(-1);

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblMode_" + i + "'>U</label>";
            cell.style.display = "none";

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblCliid_" + i + "' style='display:none'>" + resData.lstVencontact[j].vencontactid + "</label>";
            cell.style.display = "none";

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblCliname_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + resData.lstVencontact[j].contactname + "</label>";
            cell.className = "align-middle";

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblEmailid_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + resData.lstVencontact[j].employeremailid + "</label>";
            cell.className = "align-middle";

            var cell = row.insertCell(-1); 
            cell.innerHTML = "<label ID='lblContactno_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + resData.lstVencontact[j].employermobileno + "</label>";
            cell.className = "align-middle";

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblRemarks_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + resData.lstVencontact[j].employerremarks + "</label>";
            cell.className = "align-middle";

            var status;
            if (resData.lstVencontact[j].venConstatus == "1") {

                //$('input[name="chkstatus"]').prop("checked", true);
                status = "Active";
            }
            else {
                //$('input[name="chkstatus"]').prop("checked", false);
                status = "Deactive";
            }

            var cell = row.insertCell(-1);
            cell.innerHTML = "<label ID='lblStatus_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;display:none;'>" + status + "</label>";
            cell.className = "align-middle";


            var cell = row.insertCell(-1);
            // cell.innerHTML = "<button style='border:none;background-color:transparent' onclick='return deleteRow(this); '><i class='material-icons text-red'>delete</i></button>";
            cell.innerHTML = "<div class='col-md-6 text-center'>" +
                "<div class='dropdown float-lg-end pe-1'>" +
                "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                "<i class='fa fa-ellipsis-v text-secondary'></i>" +
                "</a>" +
                "<ul class='dropdown-menu styleul' aria-labelledby='dropdownTable'>" +
                "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Edit' onclick='return editContactRow(this);'>Edit</a></li>" +
                "</ul>" +
                "</div>" +
                "</div>";


                //"<div class='col-lg-3 col-1 my-auto text-end' style='float: right; '>" +
                //"<div class='dropdown float-lg-end pe-1' >" +
                //"<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
                //"<i class='fa fa-ellipsis-v text-secondary'></i></a>" +
                //"<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
                //"<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Edit' onclick='return editContactRow(this);'>Edit</a></li>" +
                ////"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='Follow'>Delete</a></li>" +
                //"</ul></div></div >";
            cell.className = "align-middle text-center";


            var cell = row.insertCell(-1);
            cell.innerHTML = "<label>" + i + "</label>";
            cell.style.display = "none";
            i++;
        }
        stopLoader();
    }

}


function getFormData() {

    common_api_ajax_request("api/Job", "JOB", "");
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}


$("#btnSave").click(function () {

    if (ValidateClient() == true) {
    var values2 = "";
    $("#drpSpecialization :selected").each(function () {
        values2 += this.value + ",";
    });
    var vendorname = $("#txtClientname").val();
    var website = $("#txtWebsite").val();
    var linkedin = $("#txtLinkedinid").val();
    var specilization = values2.substring(0, values2.length - 1);
    var city = $("#txtCity").val();
    var address = $("#txtAddress").val();
    var country = $("#txtCountry").val();
    var clienttype = $('select#drpClient option:selected').val();
    var placeofsupply = $('select#drpPlaceofSupply option:selected').val();
    var createdon = $("#hdnCreatedOn").val();
    var createdby = $("#hdnCreatedBy").val();
    var updatedon = $("#hdnUpdateon").val();
    var updatedby = $("#hdnUpdateby").val();
    var remarks = $("#txtComments").val();
    var clientid = "";
    var rowstatus;

    if ($('input[name="chkVenstatus"]:checked').val() == "on") {
        rowstatus = "1";
    }
    else {
        rowstatus = "0";
    }

    var url = window.location.href;
    hashes = url.split("?")[1];
    var mode;
        if (hashes != null) {
            var hash = hashes.split('&');
            var params = hash[0].split("=");
            mode = "U";
            clientid = params[1];
    }

    else {
        mode = "I";
    }

    var conArr = new Array;
    var conObj = {};

    var tBody = document.getElementById("tblCliConlist").getElementsByTagName("TBODY")[0];
    var rowCount = tBody.rows.length;

    var i = 1;
    for (var j = 0; j < rowCount; j++) {
        conObj.vencontactid = $("#lblCliid_" + i).text();
        conObj.mode = $("#lblMode_" + i).text();
        conObj.contactname = $("#lblCliname_" + i).text();
        conObj.employermobileno = $("#lblContactno_" + i).text();
        conObj.employeremailid = $("#lblEmailid_" + i).text();
        conObj.employerremarks = $("#lblRemarks_" + i).text();
        conObj.venConstatus = $("#lblStatus_" + i).text();

        conArr.push(conObj);
        i++;
    }
    var strdata = {
        "clientname": vendorname, "website": website, "linkedin": linkedin, "specialization": specilization,
        "address": address, "city": city, "country": country, "createdon": createdon,
        "createdby": createdby, "updatedon": updatedon, "status": rowstatus, "remarks": remarks, "clientid": clientid,
        "updatedby": updatedby, "mode": mode, "clienttype": clienttype, "placeofsupply": placeofsupply, "recruiter": conArr
    };
    common_api_ajax_request("api/client", "ADDCLIENT", strdata);
    }
});


function ValidateClient() {
    var count = 0;
    var emptycount = 0;
    if ($("#txtClientname").val() == "") {
        $('#txtClientname').addClass("is-invalid");
        $('#txtClientname').focus();
        emptycount++;
    }
    else {
        $('#txtClientname').removeClass("is-invalid");
        count++;
    }

    if ($('#txtWebsite').val() == "") {
        $("#txtWebsite").addClass("is-invalid");
        $('#txtWebsite').focus();

        emptycount++;
    }
    else {
        $("#txtWebsite").removeClass("is-invalid");
        count++;
    }

    if ($('#txtLinkedinid').val() == "") {
        $('#txtLinkedinid').addClass("is-invalid");
        $('#txtLinkedinid').focus();
        emptycount++;
    }
    else {
        $('#txtLinkedinid').removeClass("is-invalid");
        count++;
    }

    if ($('#drpSpecialization').val() == "-1") {
        $('#drpSpecialization').addClass("is-invalid");
        $('#drpSpecialization').focus();
        emptycount++;
    }
    else {
        $('#drpSpecialization').removeClass("is-invalid");
        count++;
    }

    if ($('#txtAddress').val() == "") {
        $('#txtAddress').addClass("is-invalid");
        $('#txtAddress').focus();
        emptycount++;
    }
    else {
        $('#txtAddress').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCity').val() == "") {
        $('#txtCity').addClass("is-invalid");
        $('#txtCity').focus();
        emptycount++;
    }
    else {
        $('#txtCity').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCountry').val() == "") {
        $('#txtCountry').addClass("is-invalid");
        $('#txtCountry').focus();
        emptycount++;
    }
    else {
        $('#txtCountry').removeClass("is-invalid");
        count++;
    }

    if ($('#txtComments').val() == "") {
        $('#txtComments').addClass("is-invalid");
        $('#txtComments').focus();
        emptycount++;
    }
    else {
        $('#txtComments').removeClass("is-invalid");
        count++;
    }

    if ($('#drpClient').val() == "-1") {
        $('#drpClient').addClass("is-invalid");
        $('#drpClient').focus();
        emptycount++;
    }
    else {
        $('#drpClient').removeClass("is-invalid");
        count++;
    }

    if ($('#drpPlaceofSupply').val() == "-1") {
        $('#drpPlaceofSupply').addClass("is-invalid");
        $('#drpPlaceofSupply').focus();
        emptycount++;
    }
    else {
        $('#drpPlaceofSupply').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function ValidateClientcontact() {
    var count = 0;
    var emptycount = 0;
    if ($("#txtRecruitername").val() == "") {
        $('#txtRecruitername').addClass("is-invalid");
        $('#txtRecruitername').focus();
        emptycount++;
    }
    else {
        $('#txtRecruitername').removeClass("is-invalid");
        count++;
    }

    if ($('#txtEmail').val() == "") {
        $("#txtEmail").addClass("is-invalid");
        $('#txtEmail').focus();
        emptycount++;
    }
    else {
        $("#txtEmail").removeClass("is-invalid");
        count++;
    }

    if ($('#txtContactno').val() == "") {
        $("#txtContactno").addClass("is-invalid");
        $('#txtContactno').focus();
        emptycount++;
    }
    else {
        $("#txtContactno").removeClass("is-invalid");
        count++;
    }

    if ($('#txtDesignationremarks').val() == "") {
        $("#txtDesignationremarks").addClass("is-invalid");
        $('#txtDesignationremarks').focus();
        emptycount++;
    }
    else {
        $("#txtDesignationremarks").removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function closepopup(val) {
    if (val == 0) {
        $("#msgpopup").modal('hide');

    }
    else if (val == 1) {
        $("#msgpopup").modal('hide');
        window.location.href = "FollowupPage.aspx?id=" + $('#hdnJobid').val();
    }

}

function createTable() {

    if (ValidateClientcontact() == true) {

        var table = document.getElementById("tblCliConlist");
        table.style.display = "table";
        // document.getElementById("lblCount2").style = "display:none";

        var tBody = document.getElementById("tblCliConlist").getElementsByTagName("TBODY")[0];

        var tableHead = document.getElementById("tblCliConlist").getElementsByTagName("THEAD")[0];;

        //Add Row.
        row = tBody.insertRow(-1);

        var i = tBody.rows.length;

        // var roleID = document.getElementById("ContentPlaceHolder1_drpTaskRoleName").value.split('_');
        var CliID = i;

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblMode_" + i + "'>" + document.getElementById("hdnrowMode").value+"</label>";
        cell.style.display = "none";

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblCliid_" + i + "' style='display:none'>" + document.getElementById("hdnVenconId").value + "</label>";
        cell.style.display = "none";

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblCliname_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + document.getElementById("txtRecruitername").value + "</label>";
        cell.className = "align-middle";

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblEmailid_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + document.getElementById("txtEmail").value + "</label>";
        cell.className = "align-middle";

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblContactno_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + document.getElementById("txtContactno").value + "</label>";
        cell.className = "align-middle";

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblRemarks_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;'>" + document.getElementById("txtDesignationremarks").value + "</label>";
        cell.className = "align-middle";

        var status;
        if ($('input[name="chkstatus"]:checked').val() == "on") {
            status = "1";
        }
        else {
            status = "0";
        }

        var cell = row.insertCell(-1);
        cell.innerHTML = "<label ID='lblStatus_" + i + "' class='text-secondary text-xs font-weight-bold mb-0 ps-0' style='fot-size:12px;display:none;'>" + status + "</label>";
        cell.className = "align-middle";


        var cell = row.insertCell(-1);
        // cell.innerHTML = "<button style='border:none;background-color:transparent' onclick='return deleteRow(this); '><i class='material-icons text-red'>delete</i></button>";
        cell.innerHTML = "<div class='col-lg-3 col-1 my-auto text-end' style='float: right; '>" +
            "<div class='dropdown float-lg-end pe-1' >" +
            "<a class='cursor-pointer' id='dropdownTable' data-bs-toggle='dropdown' aria-expanded='false'>" +
            "<i class='fa fa-ellipsis-v text-secondary'></i></a>" +
            "<ul class='dropdown-menu px-3 py-3 ms-sm-n8 ms-n3' aria-labelledby='dropdownTable'>" +
            "<li><a class='dropdown-item border-radius-md' href='javascript:;' id='Edit' onclick='return editContactRow(this);'>Edit</a></li>" +
            //"<li><a class='dropdown-item border-radius-md' href='FollowupPage.aspx' id='Follow'>Delete</a></li>" +
            "</ul></div></div >";
        cell.className = "align-middle text-center";


        var cell = row.insertCell(-1);
        cell.innerHTML = "<label>" + i + "</label>";
        cell.style.display = "none";

        //document.getElementById("div_resp").style.display = "block";
        //document.getElementById("btnsave").style.display = "block";
        //document.getElementById("ContentPlaceHolder1_txtResp").value = "";

        document.getElementById("txtRecruitername").value = "";
        document.getElementById("txtEmail").value = "";
        document.getElementById("txtContactno").value = "";
        document.getElementById("txtDesignationremarks").value = "";

        getPaging(5);
        //getPagination('#tblCliConlist', 5);
    }
}

function editContactRow(button) {

    var row = $(button).closest("TR");

    document.getElementById("div-message").innerHTML = "Are you Sure?Do you want to Edit this Contact?";

    var button = document.createElement("input");
    button.type = "button";
    button.value = "Yes";
    button.id = "btnYes";
    button.className = "btn btn-success";
    button.style = "float:left";
    button.setAttribute("onclick", "return confirmTaskEdit(" + row[0].rowIndex + ");");

    document.getElementById("btn_Div1").innerHTML = "";
    document.getElementById("btn_Div1").appendChild(button);
    btnOk.style.display = "none";
    var button1 = document.createElement("input");
    button1.type = "button";
    button1.value = "No";
    button1.id = "btnNo";
    button1.className = "btn btn-danger";
    button1.style = "float:right";
    button1.setAttribute("onclick", "$('#msgpopup').modal('hide');");

    document.getElementById("btn_Div2").innerHTML = "";
    document.getElementById("btn_Div2").appendChild(button1);

    $("#msgpopup").modal('show');

    return false;
};

function confirmTaskEdit(rowid) {
    //var row = $(button).closest("TR");

    var table = document.getElementById("tblCliConlist").getElementsByTagName("TBODY")[0];
    var rowCount = table.rows.length;

    for (var i = 0; i < rowCount; i++) {
        if (table.rows[i].cells[8].getElementsByTagName("label")[0].innerHTML == rowid) {
            document.getElementById("hdnrowMode").value = table.rows[i].cells[0].getElementsByTagName("label")[0].innerHTML;
            document.getElementById("hdnVenconId").value = table.rows[i].cells[1].getElementsByTagName("label")[0].innerHTML;
            document.getElementById("txtRecruitername").value = table.rows[i].cells[2].getElementsByTagName("label")[0].innerHTML;
            document.getElementById("txtEmail").value = table.rows[i].cells[3].getElementsByTagName("label")[0].innerHTML;
            document.getElementById("txtContactno").value = table.rows[i].cells[4].getElementsByTagName("label")[0].innerHTML;
            document.getElementById("txtDesignationremarks").value = table.rows[i].cells[5].getElementsByTagName("label")[0].innerHTML;

        }
    }


    //rowMode = "E";
    //deleteRow(button);
    var table = $("#tblCliConlist")[0];
    table.deleteRow(rowid);
    var table1 = document.getElementById("tblCliConlist").getElementsByTagName("TBODY")[0];
    var rowCount = table1.rows.length;

    for (var i = 1; i <= rowCount; i++) {

        //if (parseInt(table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML) != 1) {

        //table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML = parseInt(table.rows[i].cells[7].getElementsByTagName("label")[0].innerHTML) - parseInt(1);
        table.rows[i].cells[8].getElementsByTagName("label")[0].innerHTML = i;
        var c1 = (table.rows[i].cells[0].getElementsByTagName("label")[0].id).split('_');
        table.rows[i].cells[0].getElementsByTagName("label")[0].id = c1[0] + '_' + table.rows[i].cells[8].getElementsByTagName("label")[0].innerHTML;
        //table.rows[i].cells[0].getElementsByTagName("label")[0].innerHTML = "PRJ000" + table.rows[i].cells[6].getElementsByTagName("label")[0].innerHTML;

        var c2 = (table.rows[i].cells[1].getElementsByTagName("label")[0].id).split('_');
        table.rows[i].cells[1].getElementsByTagName("label")[0].id = c2[0] + '_' + table.rows[i].cells[8].getElementsByTagName("label")[0].innerHTML;


    }

    $("#msgpopup").modal('hide');

    return false;
}

function disableControls() {

    $('input[name="chkVenstatus"]').prop('disabled', true);

    $('#txtClientname').prop('disabled', true);
    $('#txtWebsite').prop('disabled', true);
    $('#txtLinkedinid').prop('disabled', true);
    $('#drpSpecialization').prop('disabled', true);
    $('#txtAddress').prop('disabled', true);
    $('#txtCity').prop('disabled', true);
    $('#txtCountry').prop('disabled', true);
    $('#drpClient').prop('disabled', true);
    $('#drpPlaceofSupply').prop('disabled', true);
    $('#txtComments').prop('disabled', true);

    $('#txtRecruitername').prop('disabled', true);
    $('#txtEmail').prop('disabled', true);
    $('#txtContactno').prop('disabled', true);
    $('#txtDesignationremarks').prop('disabled', true); 

    $('input[name="chkstatus"]').prop('disabled', true);

}