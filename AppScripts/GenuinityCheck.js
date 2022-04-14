$(document).ready(function () {
    $('#lblPagetitle').text("Candidate");

    $('#dropdownMenuButton').css('display', 'none');
    $('#lblDurationview').css('display', 'none');

    $('#lblCandidatename').text(getSession("CName"));
    $('#lblCandidatemail').text(getSession("CMail"));
    $('#lblCandidatephone').text(getSession("CPhone"));

    $('#lblJobtitle').text(getSession("CJobName"));
    $('#lblDuration').text(getSession("CJobDuration"));
    $('#lblType').text(getSession("CJobType"));
    $('#lblWorkingtype').text(getSession("CJobWorkType"));
    //$("#imgJob").attr("src", getSession('CJobImg'));

    getQuestionlist(getSession("RegionValue"));
    
    var url = window.location.href;
    hashes = url.split("?")[1];
    if (hashes != null) {

        var hash = hashes.split('&');
        if (hash.length == 1) {

            var params1 = hash[0].split("=");

            getCandidateQuestionlist(params1[1]);
        }

    }    

});

function validatevisaprev() {
    document.getElementById("visa").style.display = "none";
    document.getElementById("linkedIn").style.display = "block";
    tablist('linkedIn');
}

function validateEducationprev() {
    document.getElementById("Education").style.display = "none";
    document.getElementById("visa").style.display = "block";
    tablist('visa');
}


function validateratingprev() {
    document.getElementById("Rating").style.display = "none";
    document.getElementById("Education").style.display = "block";
    tablist('Education');
}

//Validation of radio button

function validateradiobtn(tabname, tablecount) {
    var emptyarr = new Array;
    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var diverror = "div_error" + tabname + "QNo";
    var j = 1;

    for (var k = 0; k < tablecount; k++) {


        if (document.getElementById(radbtnYes + j).checked == true || document.getElementById(radbtnNo + j).checked == true) {

            var index = emptyarr.indexOf(radbtnYes + j);
            document.getElementById(diverror + j).style.border = "";

            if (index != -1)
                emptyarr.splice(index, 1);

        }

        else {

            emptyarr.push(radbtnYes + j);
            document.getElementById(diverror + j).style.border = "1px solid red";
        }
        j++;
    }
    if (emptyarr.length > 0) {

        return false;
    }
    else {

        Validationtxtarea(tabname, tablecount);
    }
}
//validation of linkedIntextarea

function Validationtxtarea(tabname, tablecount) {
    var emptyarr = new Array;
    var txtarea = "txt" + tabname + "commentsQ";

    var j = 1;

    for (var k = 0; k < tablecount; k++) {
        if (document.getElementById(txtarea + j).value == "") {
            emptyarr.push(txtarea + j);
            document.getElementById(txtarea + j).classList.add("is-invalid");
            document.getElementById(txtarea + j).focus();

        }

        else {

            var index = emptyarr.indexOf(txtarea + j);

            if (index != -1)
                emptyarr.splice(index, 1);
            document.getElementById(txtarea + j).classList.remove("is-invalid");


        }
        j++;
    }

    if (emptyarr.length > 0) {
        return false;
    }

    else if (tabname == "linkedIn") {
        if (emptyarr1.length == "0") {

            document.getElementById("visa").style.display = "block";
            document.getElementById("linkedIn").style.display = "none";
            document.getElementById("Education").style.display = "none";
            document.getElementById("Rating").style.display = "none";
            document.getElementById("lblerrormsglinkedIn").style.display = "none";
            document.getElementById("lblerrormsgvisa").style.display = "none";
            tablist('visa');
        }


    }
    else if (tabname == "visa") {
        if (emptyarr1.length == "0") {
            document.getElementById("visa").style.display = "none";
            document.getElementById("Education").style.display = "block";
            document.getElementById("linkedIn").style.display = "none";
            document.getElementById("Rating").style.display = "none";
            document.getElementById("lblerrormsgEducation").style.display = "none";
            tablist('Education');

        }
    }
    else if (tabname == "Education") {
        document.getElementById("Education").style.display = "none";
        document.getElementById("Rating").style.display = "block";
        document.getElementById("lblerrormsgRating").style.display = "none";
        document.getElementById("linkedIn").style.display = "none";
        document.getElementById("visa").style.display = "none";
        document.getElementById("value").innerHTML = Math.round((parseInt(document.getElementById("lbllinkedInpercentage").innerHTML) + parseInt(document.getElementById("lblvisapercentage").innerHTML) + parseInt(document.getElementById("lblEducationpercentage").innerHTML)) / 3) + " %";
        tablist("Rating");
        return true;

    }

}



var emptyarr1 = new Array;

function txtvalidation(tabname, lblname) {

    //var txtarea = "txt" + tabname + "commentsQ";
    //var lblvalue = "lbl" + tabname;
    var numWords = 0;
    // var j = 1;

    var text = document.getElementById(tabname.id).value;
    for (var i = 0; i < text.length; i++) {

        var currentCharacter = text[i];


        if (currentCharacter == " ") {
            numWords += 1;

        }

    }
    numWords += 1;



    //for (k = 1; k < 10; k++) {

    if (numWords <= "5") {

        document.getElementById(lblname).style.display = "block";

        if (emptyarr1.length > 0) {
            var index = emptyarr1.indexOf(tabname.id);

            if (index != -1) {

            }
            else {
                emptyarr1.push(tabname.id);
            }
        }
        else {
            emptyarr1.push(tabname.id);
        }

    }
    else {
        document.getElementById(lblname).style.display = "none";
        var index = emptyarr1.indexOf(tabname.id);

        if (index != -1)
            emptyarr1.splice(index, 1);
    }

    //}

}

//Validation of linkedIn Questions
function validateQNo(tabname, j, tablecount) {
    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var txtarea = "txt" + tabname + "commentsQ";
    var diverror = "div_error" + tabname + "QNo";
    var tabcount;
    if (tabname == "linkedIn") {
        tabcount = "9";
    }
    else if (tabname == "visa") {
        tabcount = "8";
    }
    else if (tabname == "Education") {
        tabcount = "4";
    }
    if (document.getElementById(radbtnYes + j).checked == true || document.getElementById(radbtnNo + j).checked == true) {

        document.getElementById(txtarea + j).disabled = false;
        document.getElementById(diverror + j).style.border = "";
        CalculateOvrallRatinglinkedIn(tabname, tabcount);
    }
    else {

        document.getElementById(txtarea + j).disabled = true;

    }

}


//CalculateOverallRatinglinkedIn
function CalculateOvrallRatinglinkedIn(tabname, tablecount) {
    var markarr = new Array;

    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var ans = "lbl" + tabname + "answer";
    var mark = "lbl" + tabname + "mark";
    var overalllinkedIn = "lbl" + tabname + "ovrallrating";
    var overallvisa = "lbl" + tabname + "ovrallrating";
    var overallEducation = "lbl" + tabname + "ovrallrating";
    var j = 1;
    for (var k = 0; k < tablecount; k++) {
        var Ans = document.getElementById(ans + j).innerHTML;

        if (document.getElementById(radbtnYes + j).checked == true) {
            if (Ans == "Yes") {
                markarr.push(document.getElementById(mark + j).innerHTML);
            }


        }
        else if (document.getElementById(radbtnNo + j).checked == true) {
            if (Ans == "No") {
                markarr.push(document.getElementById(mark + j).innerHTML);
            }

        }
        j++;
    }


    var totMar = "0";
    for (var i = 0; i < markarr.length; i++) {
        totMar = parseInt(totMar) + parseInt(markarr[i]);

    }
    if (overalllinkedIn == "lbllinkedInovrallrating") {
        document.getElementById("lbllinkedInovrallrating").innerHTML = totMar;
        document.getElementById("lbllinkedInpercentage").innerHTML = (totMar / parseInt(document.getElementById("lbllinkedInoverallvalue").innerHTML)) * 100;
    }
    else if (overallvisa == "lblvisaovrallrating") {
        document.getElementById("lblvisaovrallrating").innerHTML = totMar;
        document.getElementById("lblvisapercentage").innerHTML = (totMar / parseInt(document.getElementById("lblvisaoverallvalue").innerHTML)) * 100;
    }
    else if (overallEducation == "lblEducationovrallrating") {
        document.getElementById("lblEducationovrallrating").innerHTML = totMar;
        document.getElementById("lblEducationpercentage").innerHTML = (totMar / parseInt(document.getElementById("lblEducationoverallvalue").innerHTML)) * 100;
    }


}



function createlinkedInDiv(data) {

    var str = "";
    var str1 = "";
    var str2 = "";
    var j = 1;
    var k = 1;
    var l = 1;
    $.each(data, function (key, item) {

        if (item.QuestionHeadingid == "15000") {

            str += "<div class='col-12'>" +
                "<div class='row'>" +
                "<div class='col-8'>" +
                //"<label>" + j + ".</label>" +
                "<label class='form-label' id='lbllinkedInquestion" + j + "'>" + j + "." + " " +
                item.Question +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedInQuestionId" + j + "'>" +
                item.Questionid + "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedInanswer" + j + "'>" +
                item.Answer +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedInmark" + j + "'>" +
                item.Mark +
                "</label>" +
                "</div>" +
                "<div class='col-4'>" +
                "<div class='row' style='border-radius: 10px;margin: 0px 40px 7px 0px;' id='div_errorlinkedInQNo" + j + "'>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10000' name='radlinkedInANo" + j + "' id='radlinkedInYesQNo" + j + "' onclick=validateQNo('linkedIn','" + j + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>Yes</label>" +
                "</div>" +
                "</div>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10001' name='radlinkedInANo" + j + "' id='radlinkedInNoQNo" + j + "' onclick=validateQNo('linkedIn','" + j + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>No</label>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<div class='form-group'>" +
                "<textarea class='form-control' id='txtlinkedIncommentsQ" + j + "' onkeyup=txtvalidation(this,'lbllinkedIn" + j + "') rows='3' disabled></textarea>" +

                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<label id='lbllinkedIn" + j + "' style='color:red;display:none'>Please Enter Mininum 50 Words</label>" +
                "</div>" +
                "</div>" +
                "</div>";
            j++;
        }
    });
    $("#div_linkedIn_question").append(str);

    $.each(data, function (key, item) {

        if (item.QuestionHeadingid == "15001") {

            str1 += "<div class='col-12'>" +
                "<div class='row'>" +
                "<div class='col-8'>" +
                //"<label>" + k + ".</label>" +
                "<label class='form-label' id='lblvisaquestion" + k + "'>" + k + "." + " " +
                item.Question +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lblvisaQuestionId" + k + "'>" +
                item.Questionid + "</label>" +
                "<label class='form-label' style='display:none;' id='lblvisaanswer" + k + "'>" +
                item.Answer +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lblvisamark" + k + "'>" +
                item.Mark +
                "</label>" +
                "</div>" +
                "<div class='col-4'>" +
                "<div class='row' style='border-radius: 10px;margin: 0px 40px 7px 0px;' id='div_errorvisaQNo" + k + "'>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10000' name='radvisaANo" + k + "' id='radvisaYesQNo" + k + "' onclick=validateQNo('visa','" + k + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>Yes</label>" +
                "</div>" +
                "</div>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10001' name='radvisaANo" + k + "' id='radvisaNoQNo" + k + "' onclick=validateQNo('visa','" + k + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>No</label>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<div class='form-group'>" +
                "<textarea class='form-control' id='txtvisacommentsQ" + k + "'  onkeyup=txtvalidation(this,'lblvisa" + k + "') rows='3' disabled></textarea>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<label id='lblvisa" + k + "' style='color:red;display:none'>Please Enter Mininum 50 Words</label>" +
                "</div>" +
                "</div>" +
                "</div>";
            k++;
        }
    }
    );
    $("#div_visa_question").append(str1);

    $.each(data, function (key, item) {

        if (item.QuestionHeadingid == "15002") {

            str2 += "<div class='col-12'>" +
                "<div class='row'>" +
                "<div class='col-8'>" +
                //"<label>" + l + ".</label>" +
                "<label class='form-label' id='lblEducationquestion" + l + "'>" + l + "." + " " +
                item.Question +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lblEducationQuestionId" + l + "'>" +
                item.Questionid + "</label>" +
                "<label class='form-label' style='display:none;' id='lblEducationanswer" + l + "'>" +
                item.Answer +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lblEducationmark" + l + "'>" +
                item.Mark +
                "</label>" +
                "</div>" +
                "<div class='col-4'>" +
                "<div class='row' style='border-radius: 10px;margin: 0px 40px 7px 0px;' id='div_errorEducationQNo" + l + "'>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10000' name='radEducationANo" + l + "' id='radEducationYesQNo" + l + "' onclick=validateQNo('Education','" + l + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>Yes</label>" +
                "</div>" +
                "</div>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10001' name='radEducationANo" + l + "' id='radEducationNoQNo" + l + "' onclick=validateQNo('Education','" + l + "','" + data.length + "')>" +
                "<label class='custom-control-label' for='customRadio1'>No</label>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<div class='form-group'>" +
                "<textarea class='form-control' id='txtEducationcommentsQ" + l + "' onkeyup=txtvalidation(this,'lblEducation" + l + "') rows='3' disabled></textarea>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<label id='lblEducation" + l + "' style='color:red;display:none'>Please Enter Mininum 50 Words</label>" +
                "</div>" +
                "</div>" +
                "</div>";
            l++;
        }
    }
    );
    $("#div_Education_question").append(str2);

}

function getQuestionlist(val) {

    var strdata = { "regionid": val };

    common_api_ajax_request("api/GenuinityQuestiondetails", "QUESTIONLIST", strdata);

}

function getCandidateQuestionlist(val) {
   
    var strdata = { "candidateid": val };

    common_api_ajax_request("api/getCandidateGenuinityQuestion", "QUESTIONCANDLIST", strdata);

}


function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "QUESTIONLIST") {
        $("#lbltableheading1").text(resData.questionheadings[0].QuestionHeadingname);
        $("#hdntableheadingid1").val(resData.questionheadings[0].QuestionHeadingid);
        $("#lbllinkedInoverallvalue").text(resData.questionheadings[0].OutofMark);

        $("#lbltableheading2").text(resData.questionheadings[1].QuestionHeadingname);
        $("#hdntableheadingid2").val(resData.questionheadings[1].QuestionHeadingid);
        $("#lblvisaoverallvalue").text(resData.questionheadings[1].OutofMark);

        $("#lbltableheading3").text(resData.questionheadings[2].QuestionHeadingname);
        $("#hdntableheadingid3").val(resData.questionheadings[2].QuestionHeadingid);
        $("#lblEducationoverallvalue").text(resData.questionheadings[2].OutofMark);

        createlinkedInDiv(resData.question);
    }

    else if (key == "SaveGenuinity") {
        $("#msgpopup").modal('show');
    }

    else if (key =="QUESTIONCANDLIST") {
        setCandidateQuestion(resData.genuinityChecks);
    }

}

function tablist(filterVal) {
    if (filterVal == "linkedIn") {

        $("#anchlinkedIn").addClass("change_color");
        $("#anchvisa").removeClass("change_color");
        $("#anchEducation").removeClass("change_color");
        $("#anchDraft").removeClass("change_color");


    }
    else if (filterVal == "visa") {
        $("#anchlinkedIn").removeClass("change_color");
        $("#anchvisa").addClass("change_color");
        $("#anchEducation").removeClass("change_color");
        $("#anchDraft").removeClass("change_color");


    }
    else if (filterVal == "Education") {
        filterType = "Education";
        $("#anchlinkedIn").removeClass("change_color");
        $("#anchvisa").removeClass("change_color");
        $("#anchEducation").addClass("change_color");
        $("#anchDraft").removeClass("change_color");


    }
    else if (filterVal == "Rating") {
        $("#anchlinkedIn").removeClass("change_color");
        $("#anchvisa").removeClass("change_color");
        $("#anchEducation").removeClass("change_color");
        $("#anchDraft").addClass("change_color");


    }


}

//function popupcontinue() {
//    $("#msgpopup").modal('show');
//}
function closepopup() {
    $("#msgpopup").modal('hide');
}


function saveGenuinity(tabname1, tabname2, tabname3) {

    if ($('#txtRatingcommentsQ1').val() == "") {
        $("#txtRatingcommentsQ1").addClass("is-invalid");
    }

    else {
        var mode;
        var url = window.location.href;
        hashes = url.split("?")[1];
        if (hashes != null) {

            var hash = hashes.split('&');
            var params1 = hash[0].split("=");
            mode = "U";

        }
        else {
            mode = "I";
        }
        var mailid = $("#lblCandidatemail").text();
        $("#txtRatingcommentsQ1").removeClass("is-invalid");

        var GenuinityArr = new Array;

        var j = 1;
        var k = 1;
        var l = 1;

        var tabname;
        for (q = 1; q < 4; q++) {
            if (q == 1) {
                tabname = tabname1;
            }
            else if (q == 2) {
                tabname = tabname2;
            }
            else if (q == 3) {
                tabname = tabname3;
            }

            var radbtnYes = "rad" + tabname + "ANo";
            var txtname = "txt" + tabname + "commentsQ";
            if (tabname == "linkedIn") {

                for (i = 0; i < 9; i++) {
                    var obj = {};
                    obj.QuestionHeadingId = document.getElementById("hdntableheadingid1").value;
                    obj.Questionid = document.getElementById("lbllinkedInQuestionId" + j).innerHTML;
                    obj.Comments = document.getElementById(txtname + j).value;

                    if (document.getElementsByName(radbtnYes + j)[0].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + j)[0].value;

                    }
                    else if (document.getElementsByName(radbtnYes + j)[1].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + j)[1].value;
                    }

                    GenuinityArr.push(obj);
                    j++;
                }
            }

            if (tabname == "visa") {

                for (n = 0; n < 8; n++) {
                    var obj = {};
                    obj.QuestionHeadingId = document.getElementById("hdntableheadingid2").value;
                    obj.Questionid = document.getElementById("lblvisaQuestionId" + k).innerHTML;
                    obj.Comments = document.getElementById(txtname + k).value;

                    if (document.getElementsByName(radbtnYes + k)[0].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + k)[0].value;

                    }
                    else if (document.getElementsByName(radbtnYes + k)[1].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + k)[1].value;
                    }

                    GenuinityArr.push(obj);
                    k++;
                }
            }


            if (tabname == "Education") {

                for (h = 0; h < 4; h++) {
                    var obj = {};
                    obj.QuestionHeadingId = document.getElementById("hdntableheadingid3").value;
                    obj.Questionid = document.getElementById("lblEducationQuestionId" + l).innerHTML;
                    obj.Comments = document.getElementById(txtname + l).value;

                    if (document.getElementsByName(radbtnYes + l)[0].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + l)[0].value;

                    }
                    else if (document.getElementsByName(radbtnYes + l)[1].checked) {
                        obj.Answer = document.getElementsByName(radbtnYes + l)[1].value;
                    }

                    GenuinityArr.push(obj);
                    l++;
                }

            }

        }

        var objRating = {};

        objRating.LinkedInrating = $("#lbllinkedInpercentage").text();
        objRating.Visarating = $("#lblvisapercentage").text();
        objRating.Educationrating = $("#lblEducationpercentage").text();
        objRating.Overallsystemrating = $("#value").text();
        objRating.Overallrecruiterrating = $("#value1").text();
        objRating.Remarks = $("#txtRatingcommentsQ1").val();

        var strdata = { "GenuinityArr": GenuinityArr, "objRating": objRating, "mode": mode, "mailid": mailid };

        common_api_ajax_request("api/saveGenuinityCheck", "SaveGenuinity", strdata);
    }
}

function tablist1() {

    document.getElementById("Education").style.display = "none";
    document.getElementById("linkedIn").style.display = "block";
    document.getElementById("Rating").style.display = "none";
    document.getElementById("visa").style.display = "none";

    tablist('linkedIn');


    document.getElementById("lblerrormsgvisa").style.display = "block";
    document.getElementById("lblerrormsgEducation").style.display = "block";
    document.getElementById("lblerrormsglinkedIn").style.display = "none";


}
function tablist2() {

    if (validateradiobtn("linkedIn", "9") == true) {
        document.getElementById("Education").style.display = "none";
        document.getElementById("linkedIn").style.display = "none";
        document.getElementById("Rating").style.display = "none";
        document.getElementById("visa").style.display = "block";
        tablist('visa');
    }
    else {
        document.getElementById("lblerrormsglinkedIn").style.display = "block";
        document.getElementById("lblerrormsgEducation").style.display = "block";
        document.getElementById("lblerrormsgRating").style.display = "block";
    }

}
function tablist3() {
    if (validateradiobtn("visa", "8") == true) {
        document.getElementById("Education").style.display = "block";
        document.getElementById("linkedIn").style.display = "none";
        document.getElementById("Rating").style.display = "none";
        document.getElementById("visa").style.display = "none";
        tablist('Education');
    }
    else {
        document.getElementById("lblerrormsgRating").style.display = "block";
        document.getElementById("lblerrormsglinkedIn").style.display = "block";
        document.getElementById("lblerrormsgvisa").style.display = "block";
    }

}
function tablist4() {
    if (validateradiobtn("Education", "4") == true) {
        document.getElementById("Education").style.display = "none";
        document.getElementById("linkedIn").style.display = "none";
        document.getElementById("Rating").style.display = "block";
        document.getElementById("visa").style.display = "none";
        tablist('Rating');
    }
    else {
        document.getElementById("lblerrormsgRating").style.display = "none";
        document.getElementById("lblerrormsglinkedIn").style.display = "block";
        document.getElementById("lblerrormsgEducation").style.display = "block";
    }
}


function setCandidateQuestion(data) {
    var j = 1;
    $.each(data, function (key, item) {

        if (item.QuestionHeadingid == "15000") {

            if (item.Questionid == $("#lbllinkedInQuestionId"+j).text()) {

                if (item.Answer == "10000") {
                    document.getElementById("radlinkedInYesQNo"+j).checked = true; 
                }
                else if (item.Answer == "10001") {
                    document.getElementById("radlinkedInNoQNo"+j).checked = true;
                }

                $("#txtlinkedIncommentsQ"+j).val(item.Comments);
            }

        }
        j++;

    });

}