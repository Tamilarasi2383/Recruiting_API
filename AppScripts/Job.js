var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];

var skillVal = "";
$(document).ready(function () {
    $('#lblEmployeename').text(getSession('Name'));
    
    var d1 = new Date;
    var dt = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
    var dt1 = dt.getDate() + " " + arr[dt.getMonth()] +" "+ d1.getFullYear();
    $('#lblCreatedon').text(dt1);
    $('#hdnCreatedOn').val(d1.getFullYear() + "-" + pad2((parseInt(d1.getMonth() + 1))) + "-" + d1.getDate());    
    
    $('#lblCreateby').text(getSession('Name'));
    $('#hdnCreatedBy').val(getSession('TWE_ID'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Jobs");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');
    
    getFormData();
   
    $('#txtClosecom').prop('disabled', 'disabled');
    $("#drpCurrency1").val("10100").prop("selected", true);
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        getJobFormData(params[1]);
    }

    else {
        $("#drpJobstatus").val("10200").prop("selected", true);
        $("#drpCurrency1").val("10100").prop("selected", true);
        // $("#drpCurrency1").val("CUR0002").prop("disabled", "disabled");
        $("#drpCurrency2").val("10100").prop("selected", true);
        //$("#drpJobstatus").val("JOB0002").prop("disabled", "disabled");
        //$("#drpJobstatus").val("JOB0003").prop("disabled", true);
        $("#drpAssignto").val(getSession('TWE_ID')).prop("selected", true);

        $('#lbl1').css('display', 'none');
        $('#lblUpdateOn').css('display', 'none');
        $('#lbl2').css('display', 'none');
        $('#lblUpdateBy').css('display', 'none');
    }
  
});

function pad2(number) {
    return (number < 10 ? '0' : '') + number
}
function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;
    
    if (key == "JOB") {
        $('#txtJobcode').val(resData.Jobcodename);
        $('#txtJobcode').attr("disabled", true);
        var option1 = new Option("--Select Client--", "-1");
        /// jquerify the DOM object 'o' so we can use the html method
        $(option1).html("--Select Client--");
        $("#drpClient").append(option1);

        for (var i = 0; i < resData.lstClient.length; i++) {
            var option = new Option(resData.lstClient[i].Name, resData.lstClient[i].ID);
            /// jquerify the DOM object 'o' so we can use the html method
            $(option).html(resData.lstClient[i].Name);
            $("#drpClient").append(option);
        }

        //if (document.getElementById('drpClient')) {
        //    var element = document.getElementById('drpClient');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        itemSelectText: ''
        //    });

        //};

        var option1 = new Option("--Select Priority Level--", "-1");
        $(option1).html("--Select Priority Level--");
        $("#drpPrioritylevel").append(option1);

        for (var i = 0; i < resData.lstPriority.length; i++) {

            var option = new Option(resData.lstPriority[i].Name, resData.lstPriority[i].ID);

            $(option).html(resData.lstPriority[i].Name);
            $("#drpPrioritylevel").append(option);
        }

        //if (document.getElementById('drpPrioritylevel')) {
        //    var element = document.getElementById('drpPrioritylevel');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};

        var option1 = new Option("--Select Currency--", "-1");
        $(option1).html("--Select Currency--");
        $("#drpCurrency1").append(option1);

        for (var i = 0; i < resData.lstCurrency.length; i++) {

            var option = new Option(resData.lstCurrency[i].Name, resData.lstCurrency[i].ID);

            $(option).html(resData.lstCurrency[i].Name);
            $("#drpCurrency1").append(option);
        }

        //if (document.getElementById('drpCurrency1')) {
        //    var element = document.getElementById('drpCurrency1');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};

        var option1 = new Option("--Select Currency--", "-1");
        $(option1).html("--Select Currency--");
        $("#drpCurrency2").append(option1);

        for (var i = 0; i < resData.lstCurrency.length; i++) {

            var option = new Option(resData.lstCurrency[i].Name, resData.lstCurrency[i].ID);

            $(option).html(resData.lstCurrency[i].Name);
            $("#drpCurrency2").append(option);
        }

        //if (document.getElementById('drpCurrency2')) {
        //    var element = document.getElementById('drpCurrency2');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};

        var option1 = new Option("--Select Type--", "-1");
        $(option1).html("--Select Type--");
        $("#drpType1").append(option1);

        for (var i = 0; i < resData.lstType.length; i++) {

            var option = new Option(resData.lstType[i].Name, resData.lstType[i].ID);

            $(option).html(resData.lstType[i].Name);
            $("#drpType1").append(option);
        }

        //if (document.getElementById('drpType1')) {
        //    var element = document.getElementById('drpType1');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        itemSelectText: ''
        //    });

        //};

        var option1 = new Option("--Select Type--", "-1");
        $(option1).html("--Select Type--");
        $("#drpType2").append(option1);

        for (var i = 0; i < resData.lstType.length; i++) {

            var option = new Option(resData.lstType[i].Name, resData.lstType[i].ID);

            $(option).html(resData.lstType[i].Name);
            $("#drpType2").append(option);
            typeArr.push(resData.lstType[i].ID);
        }



        //if (document.getElementById('drpType2')) {
        //    var element = document.getElementById('drpType2');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        itemSelectText:''
        //    });

        //};

        var option1 = new Option("--Select Status--", "-1");
        $(option1).html("--Select Status--");
        $(option1).attr("disabled", true);
        $("#drpJobstatus").append(option1);

        for (var i = 0; i < resData.lstJobstatus.length; i++) {

            var option = new Option(resData.lstJobstatus[i].Name, resData.lstJobstatus[i].ID);
            //if (i == 0) {
            //    $(option).attr("selected", true);
            //}
            //else {
            //    $(option).attr("disabled", true);
            //}


            $(option).html(resData.lstJobstatus[i].Name);
            $("#drpJobstatus").append(option);
        }



        //if (document.getElementById('drpJobstatus')) {
        //    var element = document.getElementById('drpJobstatus');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};

        var option1 = new Option("--Select Employment--", "-1");
        $(option1).html("--Select Employment--");
        $("#drpEmptype").append(option1);

        for (var i = 0; i < resData.lstEmploymentType.length; i++) {

            var option = new Option(resData.lstEmploymentType[i].Name, resData.lstEmploymentType[i].ID);

            $(option).html(resData.lstEmploymentType[i].Name);
            $("#drpEmptype").append(option);
        }

        //if (document.getElementById('drpEmptype')) {
        //    var element = document.getElementById('drpEmptype');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        itemSelectText: ''
        //    });


        //};

        var option1 = new Option("--Select Location--", "-1");
        $(option1).html("--Select Location--");
        $("#drpLocation").append(option1);

        for (var i = 0; i < resData.lstLocation.length; i++) {

            var option = new Option(resData.lstLocation[i].Name, resData.lstLocation[i].ID);

            $(option).html(resData.lstLocation[i].Name);
            $("#drpLocation").append(option);
        }

        //if (document.getElementById('drpLocation')) {
        //    var tags = document.getElementById('drpLocation');
        //    const examples = new Choices(tags, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};


        var option1 = new Option("--Select Employee--", "-1");
        $(option1).html("--Select Employee--");
        $("#drpAssignto").append(option1);
        for (var i = 0; i < resData.lstEmployee.length; i++) {

            var option = new Option(resData.lstEmployee[i].Name, resData.lstEmployee[i].ID);

            $(option).html(resData.lstEmployee[i].Name);
            $("#drpAssignto").append(option);
        }
        //$("#drpAssignto").val("-1").prop("selected", true);
        //if (document.getElementById('drpAssignto')) {
        //    var element = document.getElementById('drpAssignto');

        //    const example = new Choices(element, {
        //        removeItemButton: true,
        //        searchEnabled: true,
        //        shouldSort: false,
        //        addItems: true
        //    });

        //};


        var option1 = new Option("--Select Technology--", "https://techwaukee.com//admin//Job-Images//Default_job.png");
        $(option1).html("--Select Technology--");
        $("#drpChooseimage").append(option1);

        var option2 = new Option("No Relevant Image", "https://techwaukee.com//admin//Job-Images//Default_job.png");
        $(option2).html("No Relevant Image");
        $("#drpChooseimage").append(option2);

        for (var i = 0; i < resData.lstTechnology.length; i++) {

            var option = new Option(resData.lstTechnology[i].Name, resData.lstTechnology[i].ID);

            $(option).html(resData.lstTechnology[i].Name);
            $("#drpChooseimage").append(option);
        }

        //if (document.getElementById('drpChooseimage')) {
        //    var element = document.getElementById('drpChooseimage');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        itemSelectText: '',
        //    });

        //};

        //var option1 = new Option("--Select Skill--", "-1");
        //$(option1).html("--Select Skill--");
        //$("#drpSkill").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }

        //if (document.getElementById('drpSkill')) {
        //    var element = document.getElementById('drpSkill');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false,
        //        removeItemButton: true,
        //        addItems: true
        //    });

        //};
        
       // $("#drpJobstatus").val("JOB0002").prop("disabled", true);

        var url = window.location.href;
        hashes = url.split("?")[1];
        if (hashes == null) {
            var op = document.getElementById("drpJobstatus").getElementsByTagName("option");
            for (var i = 0; i < op.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op[i].value != 10200) {

                    op[i].disabled = true;
                }
            }
        }
        else {
            var op = document.getElementById("drpJobstatus").getElementsByTagName("option");
            for (var i = 0; i < op.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op[i].value !=10200) {

                    op[i].disabled = false;
                }
            }
        }
        stopLoader();
    }

    else if (key == "CLICONTACT") {


        $('#drpCliContact').find('option').remove();
        for (var i = 0; i < resData.lstClicontact.length; i++) {
            var option = new Option(resData.lstClicontact[i].Name, resData.lstClicontact[i].ID);

            $(option).html(resData.lstClicontact[i].Name);
            $("#drpCliContact").append(option);
        }

        //if (document.getElementById('drpCliContact')) {
        //    var element = document.getElementById('drpCliContact');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        items:[0,1],
        //        shouldSort: false
        //    });

        //};

        stopLoader();
    }


    else if (key == "EDITJOB") {

        $("#txtJobcode").val(resData.Jobcodename);
        $("#txtJobtitle").val(resData.JobTitle);
        $("#txtDuration").val(resData.Duration);
        $("#drpEmptype").val(resData.EmplType).prop("selected", true);
        $("#drpLocation").val(resData.Location).prop("selected", true);
        $("#txtCity").val(resData.City);
        $("#txtState").val(resData.State);
        $("#txtCountry").val(resData.Country);
        $("#drpClient").val(resData.Clientname).prop("selected", true);
        getContactpersonData();
        $("#drpCliContact").val(resData.Contactname).prop("selected", true);


        $("#txtJobdesc").val(resData.Description);
        $("#drpPrioritylevel").val(resData.Prioritylevel).prop("selected", true);
        $("#drpJobstatus").val(resData.Jobstatus).prop("selected", true);
        $("#txtRate1").val(resData.Rate1);
        $("#drpCurrency1").val(resData.Currency1).prop("selected", true);
        $("#drpType1").val(resData.WorkType1).prop("selected", true);
        $("#txtRate2").val(resData.Rate2);
        $("#drpCurrency2").val(resData.Currency2).prop("selected", true);
        $("#drpType2").val(resData.WorkType2).prop("selected", true);
        
        $("#txtOpencom").val(resData.OpenComments);
        $("#txtClosecom").val(resData.CloseComments);
        if (resData.CloseComments != "") {
            $('#txtClosecom').prop('disabled', false);
        }
        else {
            $('#txtClosecom').prop('disabled', true);
        }
        $("#imgJob").attr("src", resData.Jobimage);
        $("#lblCreateby").text(resData.Created_By);


        $("#drpChooseimage").val(resData.Jobimage).prop("selected", true);

        options = Array.from(document.querySelectorAll('#drpSkill option'));

        resData.Skill.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
        });

        options = Array.from(document.querySelectorAll('#drpAssignto option'));

        resData.AssignedTo.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
            options.find(c => c.value == v).disabled = true;
        });

        if (resData.Publish_Web == "Yes") {
            $('input[name="chkPublish"]').prop("checked", true);
        }
        else {
            $('input[name="chkPublish"]').prop("checked", false);
        }

        var dt1 = new Date(resData.Created_On);
        var dt2 = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate());
        var dt11 = pad2(dt2.getDate()) + " " + arr[dt2.getMonth()] + " " + dt2.getFullYear();
        $('#lblCreatedon').text(dt11);
        $('#hdnCreatedOn').val(dt1.getFullYear() + "-" + pad2((parseInt(dt1.getMonth() + 1))) + "-" + dt1.getDate());

        if (resData.Updated_On == "") {

            var d1 = new Date;
            var dt = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
            var dt1 = pad2(dt.getDate()) + " " + arr[dt.getMonth()] + " " + dt.getFullYear();
            $('#lblUpdateOn').text(dt1);
            $('#hdnUpdateon').val(d1.getFullYear() + "-" + pad2((parseInt(d1.getMonth() + 1))) + "-" + d1.getDate());
            $("#lblUpdateBy").text(getSession('Name'));
            $("#hdnUpdateby").val(getSession('TWE_ID'))
        }

        else {

            var dt1 = new Date(resData.Updated_On);
            var dt2 = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate());
            var dt11 = dt2.getDate() + " " + arr[dt2.getMonth()] + " " + dt2.getFullYear();
            $('#lblUpdateOn').text(dt11);
            $('#hdnUpdateon').val(dt1.getFullYear() + "-" + pad2((parseInt(dt1.getMonth() + 1))) + "-" + dt1.getDate());
            $("#lblUpdateBy").text(resData.Updated_By);
            $("#hdnUpdateby").text(resData.Updated_By_ID);

        }
        //var element = document.getElementById('drpEmptype');
        //alert(element.length);
        //const example = new Choices(element, {

        //});
        //var str = '"' + resData.EmplType + '"';
        //alert(str);
        //example.setChoiceByValue("EMP0001");
        stopLoader();
    }
    else if (key == "ADDJOB") {
        $("#div-message").text('Job saved successfully');
        $("#msgpopup").modal('show');
        $("#btnOk").attr("onclick", "pagenav();");
        stopLoader();
    }
    else if (key == "SkillData") {
        document.getElementById("drpSkill").options.length = 0;
        //var option1 = new Option("--Select Skill--", "-1");
        //$(option1).html("--Select Skill--");
        $("#drpSkill").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkill").append(option);
        }
        stopLoader();
    }
    else if (key == "ADDSKILL") {

        var skiVal = resData.split(",");
        $('#txtSkill').val("");
        if (skiVal[1] == "Old") {
            $("#addskill").modal('hide');
            $("#div-message").text('Skill you have entered already exists');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");
            if (skillVal != "") {
                skillVal += "," + skiVal[0];
            }
            else {
                skillVal += skiVal[0];
            }           
            
        }
        else if (skiVal[1] == "New") {
            
            $("#addskill").modal('hide');
            $("#div-message").text('Skill has been added successfully');
            $("#msgpopup").modal('show');
            $("#btnOk").attr("onclick", "closepopup('0')");

            if (skillVal != "") {
                skillVal += "," + skiVal[0];                
            }
            else {
                skillVal += skiVal[0];                
            }           
            
            getSkillData();
            
        }
        
        options = Array.from(document.querySelectorAll('#drpSkill option'));
        if (skillVal.includes(",")) {
            skillVal.split(',').forEach(function (v) {
                options.find(c => c.value == v).selected = true;
            });
        }
        else {           
            $("#drpSkill").val(skillVal).prop("selected", true);           
            
        }
        skillVal = "";
        stopLoader();
    }
    
}


function getFormData() {

    common_api_ajax_request("api/Job", "JOB", "");   
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}

function getSkillData() {
    common_api_ajax_request("api/CandidateFormIndia", "SkillData", "");
}


function getJobFormData(jobid) {

    var strdata = { "Jobid": jobid }
    common_api_ajax_request("api/viewJobList", "EDITJOB", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}
function getContactpersonData()
{
    var ClientID = $('select#drpClient option:selected').val();    
    var strdata = { "ClientID": ClientID };
    common_api_ajax_request("api/ClientContact", "CLICONTACT", strdata);
    //common_api_ajax_request("RecruitingAPI/api/ClientContact", "CLICONTACT", strdata);
}
var typeArr = new Array;
//function changeImage(img) {
//    var imageURL = $(img).attr('src');
//    $('#mainImage').attr('src', imageURL);
//}

//function displaynextSlide() {

//    var slides = document.getElementsByClassName("showSlide");
//    var temp = slides[0].src;
//    for (i = 0; i < slides.length; i++) {
      
//        if (i + 1 == slides.length) {
//            $('#' + slides[i].id).attr('src', temp);
//        }
//        else {
            
//            $('#' + slides[i].id).attr('src', slides[i + 1].src);
//        }
        
//    }
    
//}

function changejobImage() {
    var imageURL = $('select#drpChooseimage option:selected').val();
    $('#imgJob').attr('src', imageURL);
}


$("#btnSave").click(function () {

    if (Validateaddjob() == true) {
        disablebtn();
        var values = "";
        $("#drpAssignto :selected").each(function () {
            values += this.value + ",";
        });

        var values1 = "";
        $("#drpSkill :selected").each(function () {
            values1 += this.value + ",";
        });

        var Jobcode = $("#txtJobcode").val();
        var JobTitle = $("#txtJobtitle").val();
        var Duration = $("#txtDuration").val();
        var EmplType = $('select#drpEmptype option:selected').val();
        var Location = $('select#drpLocation option:selected').val();
        var City = $("#txtCity").val();
        var State = $("#txtState").val();
        var Country = $("#txtCountry").val();
        var Clientname = $('select#drpClient option:selected').val();
        var Contactname = $('select#drpCliContact option:selected').val();
        var Description = replaceAll(document.getElementById("txtJobdesc").value, "'", "''");
        var Assigned_To = values.substring(0, values.length - 1);
        var Prioritylevel = $('select#drpPrioritylevel option:selected').val();
        var Jobstatus = $('select#drpJobstatus option:selected').val();
        var Rate1 = $("#txtRate1").val();
        var Currency1 = $('select#drpCurrency1 option:selected').val();
        var WorkType1 = $('select#drpType1 option:selected').val();
        var Rate2 = $("#txtRate2").val();
        var Currency2 = $('select#drpCurrency2 option:selected').val();
        var WorkType2 = $('select#drpType2 option:selected').val();
        var Skill = values1.substring(0, values1.length - 1);
        var Jobopendate = $("#lblCreatedon").val();
        var OpenComments = replaceAll(document.getElementById("txtOpencom").value, "'", "''");
        var CloseComments = replaceAll(document.getElementById("txtClosecom").value, "'", "''");
        var Jobimage = $("#imgJob").attr("src");
        var Created_On = $("#hdnCreatedOn").val();
        var Created_By = $("#hdnCreatedBy").val();
        var Updated_On = $("#hdnUpdateon").val();
        var Updated_By = $("#hdnUpdateby").val();

        var Publish_Web = "";

        if ($('input[name="chkPublish"]:checked').val() == "on") {
            Publish_Web = "Yes";
        }
        else {
            Publish_Web = "No";
        }

        var url = window.location.href;
        hashes = url.split("?")[1];
        var Mode;
        if (hashes != null) {
            Mode = "update";
        }

        else {
            Mode = "insert";
        }
       
        var strdata = {
            "Jobcode": Jobcode, "JobTitle": JobTitle, "Duration": Duration, "EmplType": EmplType,
            "Location": Location, "City": City, "State": State, "Country": Country,
            "Clientname": Clientname, "Contactname": Contactname, "Description": Description,
            "Assigned_To": Assigned_To, "Prioritylevel": Prioritylevel, "Jobstatus": Jobstatus,
            "Rate1": Rate1, "Currency1": Currency1, "WorkType1": WorkType1,
            "Rate2": Rate2, "Currency2": Currency2, "WorkType2": WorkType2,
            "Skill": Skill, "Jobopendate": Jobopendate, "OpenComments": OpenComments,
            "CloseComments": CloseComments, "Jobimage": Jobimage, "Created_On": Created_On,
            "Created_By": Created_By, "Updated_On": Updated_On,
            "Updated_By": Updated_By, "Mode": Mode, "Publish_Web": Publish_Web
        };
        common_api_ajax_request("api/AddJob", "ADDJOB", strdata);
    }
});


function disableType() {
    var v1 = $('select#drpType1 option:selected').val();     
    for (var i = 0; i < typeArr.length; i++) {       
        if (typeArr[i] == v1) {
            $("#drpType2 option[value='" + v1 + "']").attr("disabled", true);
            break;
        }
    }
}

function Validateaddjob() {
    var count = 0;
    var emptycount = 0;
    if ($("#drpChooseimage option:selected").text() == "--Select Technology--") {
        $('#drpChooseimage').addClass("is-invalid");
        $('#drpChooseimage').focus();
        emptycount++;
    }
    else {
        $('#drpChooseimage').removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobcode').val() == "") {
        $("#txtJobcode").addClass("is-invalid");
        $('#txtJobcode').focus();
        emptycount++;
    }
    else {
        $("#txtJobcode").removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobtitle').val() == "") {
        $('#txtJobtitle').addClass("is-invalid");
        $('#txtJobtitle').focus();
        emptycount++;
    }
    else {
        $('#txtJobtitle').removeClass("is-invalid");
        count++;
    }

    if ($('#txtDuration').val() == "") {
        $('#txtDuration').addClass("is-invalid");
        $('#txtDuration').focus();
        emptycount++;
    }
    else {
        $('#txtDuration').removeClass("is-invalid");
        count++;
    }

    if ($('#drpEmptype').val() == "-1") {
        $('#drpEmptype').addClass("is-invalid");
        $('#drpEmptype').focus();
        emptycount++;
    }
    else {
        $('#drpEmptype').removeClass("is-invalid");
        count++;
    }

    if ($('#drpLocation').val() == "-1") {
        $('#drpLocation').addClass("is-invalid");
        $('#drpLocation').focus();
        emptycount++;
    }
    else {
        $('#drpLocation').removeClass("is-invalid");
        count++;
    }

    //if ($('#txtCity').val() == "") {
    //    $('#txtCity').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#txtCity').removeClass("is-invalid");
    //    count++;
    //}

    //if ($('#txtState').val() == "") {
    //    $('#txtState').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#txtState').removeClass("is-invalid");
    //    count++;
    //}

    if ($('#txtCountry').val() == "") {
        $('#txtCountry').addClass("is-invalid");
        $('#txtCountry').focus();
        emptycount++;
    }
    else {
        $('#txtCountry').removeClass("is-invalid");
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

    if ($('#drpCliContact').val() == "-1") {
        $('#drpCliContact').addClass("is-invalid");
        $('#drpCliContact').focus();
        emptycount++;
    }
    else {
        $('#drpCliContact').removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobdesc').val() == "") {
        $('#txtJobdesc').addClass("is-invalid");
        $('#txtJobdesc').focus();
        emptycount++;
    }
    else {
        $('#txtJobdesc').removeClass("is-invalid");
        count++;
    }

    if ($('#drpType1').val() == "-1") {
        $('#drpType1').addClass("is-invalid");
        $('#drpType1').focus();
        emptycount++;
    }
    else {
        $('#drpType1').removeClass("is-invalid");
        count++;
    }

    if ($('#txtRate1').val() == "") {
        $('#txtRate1').addClass("is-invalid");
        $('#txtRate1').focus();
        emptycount++;
    }
    else {
        $('#txtRate1').removeClass("is-invalid");
        count++;
    }

    if ($('#drpCurrency1').val() == "-1") {
        $('#drpCurrency1').addClass("is-invalid");
        $('#drpCurrency1').focus();
        emptycount++;
    }
    else {
        $('#drpCurrency1').removeClass("is-invalid");
        count++;
    }

    if ($('#drpPrioritylevel').val() == "-1") {
        $('#drpPrioritylevel').addClass("is-invalid");
        $('#drpPrioritylevel').focus();
        emptycount++;
    }
    else {
        $('#drpPrioritylevel').removeClass("is-invalid");
        count++;
    }

    var assCount = 0;
    $("#drpAssignto :selected").each(function () {
        if (this.value != "-1") {
            assCount++;
        }

    });


    if (assCount == 0) {
        $('#drpAssignto').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#drpAssignto').removeClass("is-invalid");
        count++;
    }

    var skiCount = 0;
    $("#drpSkill :selected").each(function () {
        if (this.value != "-1") {
            skiCount++;
        }

    });


    if (skiCount == 0) {
        $('#lblSkill').text("Please Select Atleast One Skill");
        $('#lblSkill').css('display', 'block');
        emptycount++;
    }
    else if (skiCount < 3) {
        $('#lblSkill').text("Please select Atleast Three Skills");
        $('#lblSkill').css('display', 'block');
        emptycount++;
    }
    else {
        $('#lblSkill').css('display', 'none');
        count++;
    }

    if ($('#drpJobstatus').val() == "-1") {
        $('#drpJobstatus').addClass("is-invalid");
        $('#drpJobstatus').focus();
        emptycount++;
    }
    else {
        $('#drpJobstatus').removeClass("is-invalid");
        count++;
    }

    //if ($('#drpType2').val() == "-1") {
    //    $('#drpType2').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#drpType2').removeClass("is-invalid");
    //    count++;
    //}

    //if ($('#txtRate2').val() == "0") {
    //    $('#txtRate2').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#txtRate2').removeClass("is-invalid");
    //    count++;
    //}

    //if ($('#drpCurrency2').val() == "-1") {
    //    $('#drpCurrency2').addClass("is-invalid");
    //    emptycount++;
    //}
    //else {
    //    $('#drpCurrency2').removeClass("is-invalid");
    //    count++;
    //}

    if ($('#txtSkills').val() == "") {
        $('#txtSkills').addClass("is-invalid");
        $('#txtSkills').focus();
        emptycount++;
    }
    else {
        $('#txtSkills').removeClass("is-invalid");
        count++;
    }

    if ($('#txtOpencom').val() == "") {
        $('#txtOpencom').addClass("is-invalid");
        $('#txtOpencom').focus();
        emptycount++;
    }
    else {
        $('#txtOpencom').removeClass("is-invalid");
        count++;
    }

    if ($('#drpJobstatus').val() == "10201" || $('#drpJobstatus').val() == "10202") {
        if ($('#txtClosecom').val() == "") {
            $('#txtClosecom').addClass("is-invalid");
            $('#txtClosecom').focus();
            emptycount++;
        }
        else {
            $('#txtClosecom').removeClass("is-invalid");
            count++;
        }
    }


    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function statusChange() {
    
    if ($('select#drpJobstatus option:selected').val() == "10201" || $('select#drpJobstatus option:selected').val() == "10202") {
        $('#txtClosecom').prop('disabled', '');
    }

    else if ($('select#drpJobstatus option:selected').val() == "10200") {
        
        $('#txtClosecom').prop('disabled', 'disabled');
    }
}

function SaveSkill() {
    $("#drpSkill :selected").each(function () {
        skillVal += this.value + ",";
    });
    skillVal = skillVal.substring(0, skillVal.length - 1);
    
    var strdata = {
        "Skill": $("#txtSkill").val()
    };
    common_api_ajax_request("api/AddSkill", "ADDSKILL", strdata);
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

function disablebtn() {
    $('#btnSave').prop('disabled', true);
    $("#btnSave").removeClass("bg-gradient-primary");
    $("#btnSave").addClass("btn-disable");
}

function totAssignCount() {
    var counter = 0;
    $("#drpAssignto :selected").each(function () {
        counter++;
    });
    $("#lblAssno").text(counter);
}

function totSkillCount() {
    var counter = 0;
    $("#drpSkill :selected").each(function () {
        counter++;
    });
    $("#lblSkillsno").text(counter);
}

function pagenav() {
    if (getSession('Designation') == "4001") {
        window.location.href = "JobList.aspx";
    }
    else if (getSession('Designation') == "4000" || getSession('Designation') == "4004") {
        window.location.href = "ManagerJobList.aspx";
    }
}
