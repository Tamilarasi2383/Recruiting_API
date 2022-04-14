var arr = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
var skillVal = "";
$(document).ready(function () {
    $('#lblEmployeename').text(getSession('Name'));
    setSession("Page", "JobIndia");

    var d1 = new Date;
    var dt = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
    var dt1 = dt.getDate() + " " + arr[dt.getMonth()] + " " + d1.getFullYear();
    $('#lblCreatedonind').text(dt1);
    $('#hdnCreatedOnind').val(d1.getFullYear() + "-" + pad2((parseInt(d1.getMonth() + 1))) + "-" + d1.getDate());

    $('#lblCreatebyind').text(getSession('Name'));
    $('#hdnCreatedByind').val(getSession('TWE_ID'));
    $("#anchDashboard").removeClass("active");
    $("#anchJob").addClass("active");
    $('#lblPagetitle').text("Jobs");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#txtClosecomind').prop('disabled', 'disabled');
   
    getFormData();   
   
    

    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {
        var hash = hashes.split('&');
        var params = hash[0].split("=");
        getJobFormData(params[1]);
    }

    else {
        $("#drpJobstatusind").val("10200").prop("selected", true);
        $("#drpCurrency1").val("10101").prop("selected", true);
        // $("#drpCurrency1").val("CUR0002").prop("disabled", "disabled");
        $("#drpCurrency2").val("10101").prop("selected", true);
        //$("#drpJobstatusind").val("JOB0002").prop("disabled", "disabled");
        //$("#drpJobstatusind").val("JOB0003").prop("disabled", true);

        $("#drpAssigntoind").val(getSession('TWE_ID')).prop("selected", true);
        //$("#drpAssigntoind").val(getSession('TWE_ID')).prop("disabled", "disabled");
        $('#lbl1').css('display', 'none');
        $('#lblUpdateOn').css('display', 'none');
        $('#lbl2').css('display', 'none');
        $('#lblUpdateBy').css('display', 'none');
    }

});

function getSkillData() {
    common_api_ajax_request("api/CandidateFormIndia", "SkillData", "");
}

function pad2(number) {
    return (number < 10 ? '0' : '') + number
}
function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "JOBIND") {
        $('#txtJobcodeind').val(resData.Jobcodename);
        $('#txtJobcodeind').attr("disabled", true);
        var option1 = new Option("--Select Client--", "-1");
        /// jquerify the DOM object 'o' so we can use the html method
        $(option1).html("--Select Client--");
        $("#drpClientind").append(option1);

        for (var i = 0; i < resData.lstClient.length; i++) {
            var option = new Option(resData.lstClient[i].Name, resData.lstClient[i].ID);
            /// jquerify the DOM object 'o' so we can use the html method
            $(option).html(resData.lstClient[i].Name);
            $("#drpClientind").append(option);
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
        $("#drpPrioritylevelind").append(option1);

        for (var i = 0; i < resData.lstPriority.length; i++) {

            var option = new Option(resData.lstPriority[i].Name, resData.lstPriority[i].ID);

            $(option).html(resData.lstPriority[i].Name);
            $("#drpPrioritylevelind").append(option);
        }       

        var option1 = new Option("--Select Status--", "-1");
        $(option1).html("--Select Status--");
        $(option1).attr("disabled", true);
        $("#drpJobstatusind").append(option1);

        for (var i = 0; i < resData.lstJobstatus.length; i++) {

            var option = new Option(resData.lstJobstatus[i].Name, resData.lstJobstatus[i].ID);
            //if (i == 0) {
            //    $(option).attr("selected", true);
            //}
            //else {
            //    $(option).attr("disabled", true);
            //}


            $(option).html(resData.lstJobstatus[i].Name);
            $("#drpJobstatusind").append(option);
        }

        //if (document.getElementById('drpJobstatusind')) {
        //    var element = document.getElementById('drpJobstatusind');

        //    const example = new Choices(element, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};

        var option1 = new Option("--Select Employment--", "-1");
        $(option1).html("--Select Employment--");
        $("#drpEmptypeind").append(option1);

        for (var i = 0; i < resData.lstEmploymentType.length; i++) {

            var option = new Option(resData.lstEmploymentType[i].Name, resData.lstEmploymentType[i].ID);

            $(option).html(resData.lstEmploymentType[i].Name);
            $("#drpEmptypeind").append(option);
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
        $("#drpLocationind").append(option1);

        for (var i = 0; i < resData.lstLocation.length; i++) {

            var option = new Option(resData.lstLocation[i].Name, resData.lstLocation[i].ID);

            $(option).html(resData.lstLocation[i].Name);
            $("#drpLocationind").append(option);
        }

        //if (document.getElementById('drpLocation')) {
        //    var tags = document.getElementById('drpLocation');
        //    const examples = new Choices(tags, {
        //        searchEnabled: false,
        //        shouldSort: false
        //    });

        //};


        //var option1 = new Option("--Select Employee--", "-1");
        //$(option1).html("--Select Employee--");
        //$("#drpAssigntoind").append(option1);

        //var option2 = new Option("Select All", "1");
        //$(option2).html("Select All");
        //$("#drpAssigntoind").append(option2);


        for (var i = 0; i < resData.lstEmployee.length; i++) {

            var option = new Option(resData.lstEmployee[i].Name, resData.lstEmployee[i].ID);

            $(option).html(resData.lstEmployee[i].Name);
            $("#drpAssigntoind").append(option);
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
        $("#drpChooseimageind").append(option1);

        var option2 = new Option("No Relevant Image", "https://techwaukee.com//admin//Job-Images//Default_job.png");
        $(option2).html("No Relevant Image");
        $("#drpChooseimageind").append(option2);

        for (var i = 0; i < resData.lstTechnology.length; i++) {

            var option = new Option(resData.lstTechnology[i].Name, resData.lstTechnology[i].ID);

            $(option).html(resData.lstTechnology[i].Name);
            $("#drpChooseimageind").append(option);
        }

        var option1 = new Option("--Select Rate Type--", "-1");
        $(option1).html("--Select Rate Type--");
        $("#drpRate").append(option1);

        for (var i = 0; i < resData.lstrateType.length; i++) {

            var option = new Option(resData.lstrateType[i].Name, resData.lstrateType[i].ID);

            $(option).html(resData.lstrateType[i].Name);
            $("#drpRate").append(option);
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
        //$("#drpSkillind").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkillind").append(option);
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
        var url = window.location.href;
        hashes = url.split("?")[1];
        if (hashes == null) {
            var op = document.getElementById("drpJobstatusind").getElementsByTagName("option");
            for (var i = 0; i < op.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op[i].value != "10200") {

                    op[i].disabled = true;
                }
            }

            var op1 = document.getElementById("drpAssigntoind").getElementsByTagName("option");
            for (var i = 0; i < op1.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op1[i].value == getSession('TWE_ID')) {

                    op1[i].disabled = true;
                }
            }
        }
        else {
            var op = document.getElementById("drpJobstatusind").getElementsByTagName("option");
            for (var i = 0; i < op.length; i++) {

                // lowercase comparison for case-insensitivity
                if (op[i].value != "10200") {

                    op[i].disabled = false;
                }
            }
        }

       
        stopLoader();
    }

    else if (key == "CLICONTACT") {


        $('#drpCliContactind').find('option').remove();
        for (var i = 0; i < resData.lstClicontact.length; i++) {
            var option = new Option(resData.lstClicontact[i].Name, resData.lstClicontact[i].ID);

            $(option).html(resData.lstClicontact[i].Name);
            $("#drpCliContactind").append(option);
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


    else if (key == "EDITJOBINDIA") {
        $("#txtJobcodeind").val(resData.Jobcodename);
        $("#txtJobtitleind").val(resData.JobTitle);
        $("#txtDurationind").val(resData.Duration);
        $("#drpEmptypeind").val(resData.EmplType).prop("selected", true);
        $("#drpLocationind").val(resData.Location).prop("selected", true);
        $("#txtCountryind").val(resData.Country);
        $("#txtStartdateind").val(resData.Startdate);
        $("#txtNoopeningind").val(resData.Noofopening);
        $("#txtTimingingind").val(resData.ShiftTiming);
        
        $("#txtTurnaroundtimeind").val(resData.TurnAroundtime);
      

        $("#drpClientind").val(resData.Clientname).prop("selected", true);
        getContactpersonData();
        $("#drpCliContactind").val(resData.Contactname).prop("selected", true);
        $("#txtJobdescind").val(resData.Description);
        $("#drpAssigntoind").val(resData.Rate1);
        $("#drpPrioritylevelind").val(resData.Prioritylevel).prop("selected", true);
        $("#drpJobstatusind").val(resData.Jobstatus).prop("selected", true);
        $("#txtMinrate").val(resData.Minrate);
        $("#txtMaxrate").val(resData.Maxrate);
        $("#drpRate").val(resData.Ratetype).prop("selected", true);
        $("#txtCurrency").val(resData.Currency);
        //$("#drpSkillind").val(resData.Skill).prop("selected", true);
        $("#txtOpencomind").val(resData.OpenComments);
        $("#txtClosecomind").val(resData.CloseComments);
        $("#imgJobind").attr("src", resData.Jobimage);
        //$("#lblCreateby").text(resData.Created_By);

        $("#drpChooseimageind").val(resData.Jobimage).prop("selected", true);

        if (resData.Publish_Web == "Yes") {
            $('input[name="chkPublish"]').prop("checked", true);
        }
        else {
            $('input[name="chkPublish"]').prop("checked", false);
        }

        options = Array.from(document.querySelectorAll('#drpAssigntoind option'));

        resData.AssignedTo.split(',').forEach(function (v) {
            options.find(c => c.value == v).selected = true;
            options.find(c => c.value == v).disabled = true;
        });

        //var textRemove = new Choices(document.getElementById('drpAssigntoind'), {
            
        //    removeItemButton: false,
        //});

        //var element = document.getElementById('#drpAssigntoind');
       
        //const example = new Choices(element, {
        //    removeItemButton: false
        //});


       
        options1 = Array.from(document.querySelectorAll('#drpSkillind option'));

        resData.Skill.split(',').forEach(function (v) {
            options1.find(c => c.value == v).selected = true;
        });

        var dt1 = new Date(resData.Created_On);
        var dt2 = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate());
        var dt11 = pad2(dt2.getDate()) + " " + arr[dt2.getMonth()] + " " + dt2.getFullYear();
        $('#lblCreatedonind').text(dt11);
        $('#hdnCreatedOnind').val(dt1.getFullYear() + "-" + pad2((parseInt(dt1.getMonth() + 1))) + "-" + dt1.getDate());

        if (resData.Updated_On == "") {

            var d1 = new Date;
            var dt = new Date(d1.getFullYear(), d1.getMonth(), d1.getDate());
            var dt1 = pad2(dt.getDate()) + " " + arr[dt.getMonth()] + " " + dt.getFullYear();
            $('#lblUpdateOnind').text(dt1);
            $('#hdnUpdateonind').val(d1.getFullYear() + "-" + pad2((parseInt(d1.getMonth() + 1))) + "-" + d1.getDate());
            $("#lblUpdateByind").text(getSession('Name'));
            $("#hdnUpdatebyind").val(getSession('TWE_ID'))
        }

        else {

            var dt1 = new Date(resData.Updated_On);
            var dt2 = new Date(dt1.getFullYear(), dt1.getMonth(), dt1.getDate());
            var dt11 = dt2.getDate() + " " + arr[dt2.getMonth()] + " " + dt2.getFullYear();
            $('#lblUpdateOnind').text(dt11);
            $('#hdnUpdateonind').val(dt1.getFullYear() + "-" + pad2((parseInt(dt1.getMonth() + 1))) + "-" + dt1.getDate());
            $("#lblUpdateByind").text(resData.Updated_By);
            $("#hdnUpdatebyind").text(resData.Updated_By_ID);

        }
        //var element = document.getElementById('drpEmptype');
        //alert(element.length);
        //const example = new Choices(element, {

        //});
        //var str = '"' + resData.EmplType + '"';
        //alert(str);
        //example.setChoiceByValue("EMP0001");
        totAssignCount();
        stopLoader();

    }
    else if (key == "ADDJOB") {
        $("#div-message").text('Job saved successfully');
        $("#msgpopup").modal('show');
        $("#btnOk").attr("onclick", "pagenav();");
        stopLoader();
    }

    else if (key == "SkillData") {
        document.getElementById("drpSkillind").options.length = 0;
        //var option1 = new Option("--Select Skill--", "-1");
        //$(option1).html("--Select Skill--");
        $("#drpSkillind").append(option1);

        for (var i = 0; i < resData.lstSkill.length; i++) {

            var option = new Option(resData.lstSkill[i].Name, resData.lstSkill[i].ID);

            $(option).html(resData.lstSkill[i].Name);
            $("#drpSkillind").append(option);
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

        options = Array.from(document.querySelectorAll('#drpSkillind option'));
        if (skillVal.includes(",")) {
            skillVal.split(',').forEach(function (v) {
                options.find(c => c.value == v).selected = true;
            });
        }
        else {
            $("#drpSkillind").val(skillVal).prop("selected", true);

        }
        skillVal = "";

        stopLoader();
    }

}


function getFormData() {

    common_api_ajax_request("api/JobIndia", "JOBIND", "");
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}



function getJobFormData(jobid) {
    var strdata = { "Jobid": jobid }
    common_api_ajax_request("api/viewJobListIndia", "EDITJOBINDIA", strdata);
    //common_api_ajax_request("RecruitingAPI/api/Job", "ADDJOB", "");           
}
function getContactpersonData() {
    var ClientID = $('select#drpClientind option:selected').val();
    var strdata = { "ClientID": ClientID };
    common_api_ajax_request("api/ClientContactIndia", "CLICONTACT", strdata);
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
    var imageURL = $('select#drpChooseimageind option:selected').val();
    $('#imgJobind').attr('src', imageURL);
}


$("#btnSave").click(function () {
    
    if (Validateaddjob() == true) {
        disablebtn();
        $('#btnSave').prop('disabled', 'disabled');
        var values = "";
        $("#drpAssigntoind :selected").each(function () {
            values += this.value + ",";
        });

        var values1 = "";
        $("#drpSkillind :selected").each(function () {
            values1 += this.value + ",";
        });

        var Jobcode = $("#txtJobcodeind").val();
        var JobTitle = $("#txtJobtitleind").val();
        var Duration = $("#txtDurationind").val();
        var EmplType = $('select#drpEmptypeind option:selected').val();
        var Location = $('select#drpLocationind option:selected').val();
        var Country = $("#txtCountryind").val();
        var Startdate = $("#txtStartdateind").val();
        var Noofopening = $("#txtNoopeningind").val();        
        var ShiftTiming = $("#txtTimingingind").val();
        var TurnAroundtime = $("#txtTurnaroundtimeind").val();
        var Clientname = $('select#drpClientind option:selected').val();
        var Assigned_To = values.substring(0, values.length - 1);
        var Contactname = $('select#drpCliContactind option:selected').val();
        var Description = replaceAll(document.getElementById("txtJobdescind").value, "'", "''");
        var Prioritylevel = $('select#drpPrioritylevelind option:selected').val();
        var Jobstatus = $('select#drpJobstatusind option:selected').val();
        var Minrate = $("#txtMinrate").val();
        var Maxrate = $("#txtMaxrate").val();
        var Ratetype = $('select#drpRate option:selected').val();
        var Skill = values1.substring(0, values1.length - 1);
        var Currency = $("#txtCurrency").val();
        var OpenComments = replaceAll(document.getElementById("txtOpencomind").value, "'", "''");
        var CloseComments = replaceAll(document.getElementById("txtClosecomind").value, "'", "''");
        var Jobimage = $("#imgJobind").attr("src");
        var Created_On = $("#hdnCreatedOnind").val();
        var Created_By = $("#hdnCreatedByind").val();
        var Updated_On = $("#hdnUpdateonind").val();
        var Updated_By = $("#hdnUpdatebyind").val();
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
            "Location": Location, "Country": Country, "Startdate": Startdate, "Noofopening": Noofopening,
            "ShiftTiming": ShiftTiming, "TurnAroundtime": TurnAroundtime,
            "Clientname": Clientname, "Contactname": Contactname, "Description": Description,
            "Assigned_To": Assigned_To, "Prioritylevel": Prioritylevel, "Jobstatus": Jobstatus,
            "Minrate": Minrate, "Maxrate": Maxrate, "Ratetype": Ratetype, "Currency": Currency, 
            "Skill": Skill, "Jobopendate": Created_On, "OpenComments": OpenComments,
            "CloseComments": CloseComments, "Jobimage": Jobimage, "Created_On": Created_On,
            "Created_By": Created_By, "Updated_On": Updated_On,
            "Updated_By": Updated_By, "Mode": Mode, "Publish_Web": Publish_Web
        };
        common_api_ajax_request("api/AddJobIndia", "ADDJOB", strdata);
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

function Validateaddjob() {/*Tamil*/
    var count = 0;
    var emptycount = 0;

    if ($('#drpChooseimageind').val() == "Images/Default_job.png") {
        $('#drpChooseimageind').addClass("is-invalid");
        $('#drpChooseimageind').focus();
        emptycount++;
    }
    else {
        $('#drpChooseimageind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobcodeind').val() == "") {
        $("#txtJobcodeind").addClass("is-invalid");
        //document.getElementById("txtJobcodeind").focus();
        
        emptycount++;
    }
    else {
        $("#txtJobcodeind").removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobtitleind').val() == "") {
        $('#txtJobtitleind').addClass("is-invalid");
        $('#txtJobtitleind').focus();
        emptycount++;
    }
    else {
        $('#txtJobtitleind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtDurationind').val() == "") {
        $('#txtDurationind').addClass("is-invalid");
        $('#txtDurationind').focus();
        emptycount++;
    }
    else {
        $('#txtDurationind').removeClass("is-invalid");
        count++;
    }

    if ($('#drpEmptypeind').val() == "-1") {
        $('#drpEmptypeind').addClass("is-invalid");
        $('#drpEmptypeind').focus();
        emptycount++;
    }
    else {
        $('#drpEmptypeind').removeClass("is-invalid");
        count++;
    }

    if ($('#drpLocationind').val() == "-1") {
        $('#drpLocationind').addClass("is-invalid");
        $('#drpLocationind').focus();
        emptycount++;
    }
    else {
        $('#drpLocationind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCountryind').val() == "") {
        $('#txtCountryind').addClass("is-invalid");
        $('#txtCountryind').focus();
        emptycount++;
    }
    else {
        $('#txtCountryind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtStartdateind').val() == "") {
        $('#txtStartdateind').addClass("is-invalid");
        $('#txtStartdateind').focus();
        emptycount++;
    }
    else {
        $('#txtStartdateind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtNoopeningind').val() == "") {
        $('#txtNoopeningind').addClass("is-invalid");
        $('#txtNoopeningind').focus();
        emptycount++;
    }
    else {
        $('#txtNoopeningind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtTimingingind').val() == "") {
        $('#txtTimingingind').addClass("is-invalid");
        $('#txtTimingingind').focus();
        emptycount++;
    }
    else {
        $('#txtTimingingind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtTurnaroundtimeind').val() == "") {
        $('#txtTurnaroundtimeind').addClass("is-invalid");
        $('#txtTurnaroundtimeind').focus();
        emptycount++;
    }
    else {
        $('#txtTurnaroundtimeind').removeClass("is-invalid");
        count++;
    }

    if ($('#drpClientind').val() == "-1") {
        $('#drpClientind').addClass("is-invalid");
        $('#drpClientind').focus();
        emptycount++;
    }
    else {
        $('#drpClientind').removeClass("is-invalid");
        count++;
    }

    if ($('#drpCliContactind').val() == "-1") {
        $('#drpCliContactind').addClass("is-invalid");
        $('#drpCliContactind').focus();
        emptycount++;
    }
    else {
        $('#drpCliContactind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtJobdescind').val() == "") {
        $('#txtJobdescind').addClass("is-invalid");
        $('#txtJobdescind').focus();
        emptycount++;
    }
    else {
        $('#txtJobdescind').removeClass("is-invalid");
        count++;
    }

    var skicount = 0;
    $("#drpAssigntoind :selected").each(function () {
        skicount++;
    });
    if (skicount < 1) {

        $('#lblAddassigned').css('display', 'block');
        $('#drpAssigntoind').removeClass("form-control");
        $('#drpAssigntoind').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#lblAddassigned').css('display', 'none');
        $('#drpAssigntoind').addClass("form-control");
        $('#drpAssigntoind').removeClass("is-invalid");
        count++;
    }


    if ($('#drpPrioritylevelind').val() == "-1") {
        $('#drpPrioritylevelind').addClass("is-invalid");
        $('#drpPrioritylevelind').focus();
        emptycount++;
    }
    else {
        $('#drpPrioritylevelind').removeClass("is-invalid");
        count++;
    }

    if ($('#drpJobstatusind').val() == "-1") {
        $('#drpJobstatusind').addClass("is-invalid");
        $('#drpJobstatusind').focus();
        emptycount++;
    }
    else {
        $('#drpJobstatusind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtMinrate').val() == "") {
        $('#txtMinrate').addClass("is-invalid");
        $('#txtMinrate').focus();
        emptycount++;
    }
    else {
        $('#txtMinrate').removeClass("is-invalid");
        count++;
    }

    if ($('#drpRate').val() == "-1") {
        $('#drpRate').addClass("is-invalid");
        $('#drpJobstatusind').focus();
        emptycount++;
    }
    else {
        $('#drpRate').removeClass("is-invalid");
        count++;
    }

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
    
    if ($('#txtMaxrate').val() == "") {
        $('#txtMaxrate').addClass("is-invalid");
        $('#txtMaxrate').focus();
        emptycount++;
    }
    else {
        $('#txtMaxrate').removeClass("is-invalid");
        count++;
    }

    if ($('#drpCurrency2inddd').val() == "") {
        $('#drpCurrency2inddd').addClass("is-invalid");
        $('#drpCurrency2inddd').focus();
        emptycount++;
    }
    else {
        $('#drpCurrency2inddd').removeClass("is-invalid");
        count++;
    }

    if ($('#txtCurrency').val() == "") {
        $('#txtCurrency').addClass("is-invalid");
        $('#txtCurrency').focus();
        emptycount++;
    }
    else {
        $('#txtCurrency').removeClass("is-invalid");
        count++;
    }

    var skicount = 0;
    $("#drpSkillind :selected").each(function () {
        skicount++;
    });
    if (skicount < 3) {

        $('#lblAddatlest').css('display', 'block');
        $('#drpSkillind').removeClass("form-control");
        $('#drpSkillind').addClass("is-invalid");
        emptycount++;
    }
    else {
        $('#lblAddatlest').css('display', 'none');
        $('#drpSkillind').addClass("form-control");
        $('#drpSkillind').removeClass("is-invalid");
        count++;
    }

    if ($('#txtOpencomind').val() == "") {
        $('#txtOpencomind').addClass("is-invalid");
        $('#txtOpencomind').focus();
        emptycount++;
    }
    else {
        $('#txtOpencomind').removeClass("is-invalid");
        count++;
    }

    //if ($('#drpJobstatusind').val() == "JOB0002" || $('#drpJobstatusind').val() == "JOB0003") {
    //    if ($('#txtClosecom').val() == "") {
    //        $('#txtClosecom').addClass("is-invalid");
    //        emptycount++;
    //    }
    //    else {
    //        $('#txtClosecom').removeClass("is-invalid");
    //        count++;
    //    }
    //}
  

   

    if (parseInt(emptycount) > 0 && parseInt(count) != parseInt(emptycount)) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }

}

function statusChange() {

    if ($('select#drpJobstatusind option:selected').val() == "10201" || $('select#drpJobstatusind option:selected').val() == "10202") {
        $('#txtClosecomind').prop('disabled', '');
    }

    else if ($('select#drpJobstatusind option:selected').val() == "10200") {

        $('#txtClosecomind').prop('disabled', 'disabled');
    }
}

function SaveSkill() {

    skillVal = "";
    $("#drpSkillind :selected").each(function () {
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
    $("#drpAssigntoind :selected").each(function () {
        counter++;
    });
    $("#lblAssno").text(counter);
}

function totSkillCount() {
    var counter = 0;
    $("#drpSkillind :selected").each(function () {
        counter++;
    });
    $("#lblSkillsno").text(counter);
}

function pagenav() {
    if (getSession('Designation') == "4001") {
        window.location.href = "JobListindia.aspx";
    }
    else if (getSession('Designation') == "4000" || getSession('Designation') == "4004") {
        window.location.href = "ManagerJobListindia.aspx";
    }
}

