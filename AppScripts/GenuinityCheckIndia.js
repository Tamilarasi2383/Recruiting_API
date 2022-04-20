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
    $("#imgJob").attr("src", getSession('CJobImg'));

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
    document.getElementById("tail2").style.display = "none";
    document.getElementById("LinkedIn").style.display = "block";
    getcandidateList('VISA');
}

function validateeducationprev() {
    document.getElementById("Rating").style.display = "none";
    document.getElementById("tail2").style.display = "block";
    getcandidateList('LinkedIn');
}

function validateradiobtn(tabname, tablecount) {
    var emptyarr = new Array;
    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var diverror = "div_error" + tabname + "QNo";

    var j;
    if (tabname == "linkedIn1") {
        j = 1;
    }
    else if (tabname == "linkedIn2") {
        j = 11;
    }
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

function Validationtxtarea(tabname, tablecount) {
    var emptyarr = new Array;
    var txtarea = "txt" + tabname + "commentsQ";

    var j;
    if (tabname == "linkedIn1") {
        j = 1;
    }
    else if (tabname == "linkedIn2") {
        j = 11;
    }
    else if (tabname == "Rating") {
        j = 1;
    }
    for (var k = 0; k < tablecount; k++) {
        if (document.getElementById(txtarea + j).value == "") {
            emptyarr.push(txtarea + j);
            document.getElementById(txtarea + j).classList.add("is-invalid");
            document.getElementById(txtarea + j).focus();
            // findthevalue('linkedIn', 'visa', 'Education');
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
    else if (tabname == "linkedIn1") {
        document.getElementById("tail2").style.display = "block";
        document.getElementById("LinkedIn").style.display = "none";
        // document.getElementById("lblerrormsgvisa").style.display = "none";
        //tablist2('VISA');

    }
    else if (tabname == "linkedIn2") {
        document.getElementById("tail2").style.display = "none";
        document.getElementById("Rating").style.display = "block";
        //document.getElementById("lblerrormsgEducation").style.display = "none";
        document.getElementById("value1").innerHTML = Math.round((parseInt(document.getElementById("lbllinkedIn1percentage").innerHTML) + parseInt(document.getElementById("lbllinkedIn2percentage").innerHTML)));
        tablist('VISA');

        return true;
    }

}

function txtvalidation(tabname, lblname) {
    var numWords = 0;
    var text = document.getElementById(tabname.id).value;
    for (var i = 0; i < text.length; i++) {
        var currentCharacter = text[i];
        if (currentCharacter == " ") {
            numWords += 1;
        }
    }
    numWords += 1;
    if (numWords <= "5") {
        emptyarr1.push(numWords);
        document.getElementById(lblname).style.display = "block";
    }
    else {
        document.getElementById(lblname).style.display = "none";
        var index = emptyarr1.indexOf(numWords);

        if (index != -1)
            emptyarr1.splice(index, 1);
    }
}

function validateQNo(tabname, j) {
    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var txtarea = "txt" + tabname + "commentsQ";
    var diverror = "div_error" + tabname + "QNo";



    if (document.getElementById(radbtnYes + j).checked == true || document.getElementById(radbtnNo + j).checked == true) {

        document.getElementById(txtarea + j).disabled = false;
        document.getElementById(diverror + j).style.border = "";
        CalculateOvrallRatinglinkedin(tabname);
    }
    else {

        document.getElementById(txtarea + j).disabled = true;

    }

}

var emptyarr1 = new Array;

function createLinkedinDiv(data) {

    var str = "";
    var str1 = "";
    var p = 11;
    var j = 1;
    var k = 1;

    $.each(data, function (key, item) {

        if (j <= 10) {

            str += "<div class='col-12'>" +
                "<div class='row'>" +
                "<div class='col-8'>" +
                // "<label>" + j + ".</label>" +
                "<label class='form-label' id='lbllinkedIn1question" + j + "'>" + j + "." + " " +
                item.Question +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn1QuestionId" + j + "'>" +
                item.Questionid + "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn1answer" + j + "'>" +
                item.Answer +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn1mark" + j + "'>" +
                item.Mark +
                "</label>" +
                "</div>" +
                "<div class='col-4'>" +
                "<div class='row' style='border-radius: 10px;margin: 0px 40px 0px 0px;' id='div_errorlinkedIn1QNo" + j + "'>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10000' name='radlinkedIn1ANo" + j + "' id='radlinkedIn1YesQNo" + j + "' onclick=validateQNo('linkedIn1','" + j + "')>" +
                "<label class='custom-control-label' for='customRadio1'>Yes</label>" +
                "</div>" +
                "</div>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10001' name='radlinkedIn1ANo" + j + "' id='radlinkedIn1NoQNo" + j + "' onclick=validateQNo('linkedIn1','" + j + "')>" +
                "<label class='custom-control-label' for='customRadio1'>No</label>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<div class='form-group'>" +
                "<div class='form-control col-md-12 text-right' style='background-color:#e9ecef;padding: 0px;'>" +
                "<i style='display:none;'class='fa fa-pen top-0'></i>" +
                "<textarea class='form-control' style='border: none;' id='txtlinkedIn1commentsQ" + j + "' onkeyup=txtvalidation(this,'lbllinkedIn1" + j + "') rows='3' disabled></textarea>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<label id='lbllinkedIn1" + j + "' style='color:red;display:none'>Please enter mininum 50 words</label>" +
                "</div>" +
                "</div>" +
                "</div>";

            j++;

        }
        else if (j > 10) {
            str1 += "<div class='col-12'>" +
                "<div class='row'>" +
                "<div class='col-8'>" +
                //"<label>" + k + ".</label>" +
                "<label class='form-label' id='lbllinkedIn2question" + j + "'>" + j + "." + " " +
                item.Question +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn2QuestionId" + j + "'>" +
                item.Questionid + "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn2answer" + j + "'>" +
                item.Answer +
                "</label>" +
                "<label class='form-label' style='display:none;' id='lbllinkedIn2mark" + j + "'>" +
                item.Mark +
                "</label>" +
                "</div>" +
                "<div class='col-4'>" +
                "<div class='row' style='border-radius: 10px;margin: 0px 39px 7px 0px;' id='div_errorlinkedIn2QNo" + j + "'>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10003' name='radlinkedIn2ANo" + j + "' id='radlinkedIn2YesQNo" + j + "' onclick=validateQNo('linkedIn2','" + j + "')>" +
                "<label class='custom-control-label' for='customRadio1'>Yes</label>" +
                "</div>" +
                "</div>" +
                "<div class='col-6'>" +
                "<div class='form-check mb-0 mt-1'>" +
                "<input class='form-check-input' type='radio' value='10004' name='radlinkedIn2ANo" + j + "' id='radlinkedIn2NoQNo" + j + "' onclick=validateQNo('linkedIn2','" + j + "')>" +
                "<label class='custom-control-label' for='customRadio1'>No</label>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<div class='form-group'>" +
                "<textarea class='form-control' id='txtlinkedIn2commentsQ" + j + "' rows='3' disabled></textarea>" +
                "</div>" +
                "</div>" +
                "</div>" +
                "<div class='row'>" +
                "<div class='col-12'>" +
                "<label id='lbllinkedIn2" + j + "' style='color:red;display:none'>Please enter mininum 50 words</label>" +
                "</div>" +
                "</div>" +
                "</div>";
            j++;
        }
    });
    $("#div_linkedin1_question").append(str);

    $("#div_linkedin2_question").append(str1);

}

function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "QUESTIONLIST") {
        $("#lbltableheading1").text(resData.questionheadings[0].QuestionHeadingname);
        $("#hdntableheadingid1").val(resData.questionheadings[0].QuestionHeadingid);
        $("#lbllinkedIn1overallvalue").text(resData.questionheadings[0].OutofMark);

        $("#lbltableheading2").text(resData.questionheadings[0].QuestionHeadingname);
        $("#hdntableheadingid2").val(resData.questionheadings[0].QuestionHeadingid);
        $("#lbllinkedIn2overallvalue").text(resData.questionheadings[0].OutofMark);

        createLinkedinDiv(resData.question);
    }

    else if (key == "SaveGenuinity") {
        $("#msgpopup").modal('show');
    }
    else if (key == "QUESTIONCANDLIST") {
        setCandidateQuestion(resData.genuinityChecks);
        document.getElementById("value1").innerHTML = resData.genuinityCheckRating.Overallrecruiterrating;
        document.getElementById("txtRatingcommentsQ1").value = resData.genuinityCheckRating.Remarks;

    }

}

function tablist(filterVal) {
    if (filterVal == "LinkedIn") {
        $("#anchlinkedIn").addClass("change_color");
        $("#anchvisa").removeClass("change_color");



    }
    else if (filterVal == "VISA") {
        $("#anchlinkedIn").removeClass("change_color");
        $("#anchvisa").addClass("change_color");
    }
}

function closepopup() {
    $("#msgpopup").modal('hide');
}

function saveGenuinity(tabname1, tabname2) {

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
        var k = 11;
        

        var tabname;
        for (q = 1; q < 2; q++) {
            if (q == 1) {
                tabname = tabname1;
            }
            else if (q == 2) {
                tabname = tabname2;
            }
           

            var radbtnYes = "rad" + tabname + "ANo";
            var txtname = "txt" + tabname + "commentsQ";
            if (tabname == "linkedIn1") {

                for (i = 0; i < 10; i++) {
                    var obj = {};
                    obj.QuestionHeadingId = document.getElementById("hdntableheadingid1").value;
                    obj.Questionid = document.getElementById("lbllinkedIn1QuestionId" + j).innerHTML; 
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

            if (tabname == "linkedIn2") {

                for (n = 0; n < 10; n++) {
                    var obj = {};
                    obj.QuestionHeadingId = document.getElementById("hdntableheadingid2").value;
                    obj.Questionid = document.getElementById("lbllinkedIn2QuestionId" + k).innerHTML;
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

        }

        var objRating = {};

        objRating.LinkedInrating = $("#lbllinkedIn1percentage").text();
        objRating.Visarating = $("#lbllinkedIn2percentage").text();
        objRating.Overallsystemrating = $("#value").text();
        objRating.Overallrecruiterrating = $("#value1").text();
        objRating.Remarks = $("#txtRatingcommentsQ1").val();

        var strdata = { "GenuinityArr": GenuinityArr, "objRating": objRating, "mode": mode, "mailid": mailid };

       // common_api_ajax_request("api/saveGenuinityCheck", "SaveGenuinity", strdata);
    }
}

function getQuestionlist(val) {

    var strdata = { "regionid": val };

    common_api_ajax_request("api/GenuinityQuestiondetails", "QUESTIONLIST", strdata);

}

function getCandidateQuestionlist(val) {

    var strdata = { "candidateid": val };

    common_api_ajax_request("api/getCandidateGenuinityQuestion", "QUESTIONCANDLIST", strdata);

}

function CalculateOvrallRatinglinkedin(tabname) {
    var markarr = new Array;

    var radbtnYes = "rad" + tabname + "YesQNo";
    var radbtnNo = "rad" + tabname + "NoQNo";
    var ans = "lbl" + tabname + "answer";
    var mark = "lbl" + tabname + "mark";
    var overalllinkedin = "lbl" + tabname + "ovrallrating";
    var overallvisa = "lbl" + tabname + "ovrallrating";

    var j;
    if (tabname == "linkedIn1") {
        j = 1;
    }
    else if (tabname == "linkedIn2") {
        j = 11;
    }
    for (var k = 0; k < 10; k++) {
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
    if (overalllinkedin == "lbllinkedIn1ovrallrating") {
        document.getElementById("lbllinkedIn1ovrallrating").innerHTML = (totMar);
        document.getElementById("lbllinkedIn1percentage").innerHTML = Math.round((totMar / parseInt(document.getElementById("lbllinkedIn1overallvalue").innerHTML)) * 100);
    }
    else if (overallvisa == "lbllinkedIn2ovrallrating") {
        document.getElementById("lbllinkedIn2ovrallrating").innerHTML = totMar;
        document.getElementById("lbllinkedIn2percentage").innerHTML = (totMar / parseInt(document.getElementById("lbllinkedIn2overallvalue").innerHTML)) * 100;
    }



}

function tabList1(tabname) {
    document.getElementById("lblerrormsgRating").style.display = "block";
    if (tabname == "LinkedIn") {
        document.getElementById("Rating").style.display = "none";
        document.getElementById("LinkedIn").style.display = "block";
        tablist('LinkedIn');
    }

}

function tabList2() {

    document.getElementById("lblerrormsglinkedIn1").style.display = "block";
    document.getElementById("lblerrormsglinkedIn2").style.display = "block";
}

function setCandidateQuestion(data) {
    var tabname;
    var j = 1;
    var k = 1;
    var l = 1;
    var markarr = new Array;
    var markarr1 = new Array;
    var markarr2 = new Array;

    $.each(data, function (key, item) {

        if (item.QuestionHeadingid == "15000") {

            tabname = "linkedIn";
        }
        else if (item.QuestionHeadingid == "15001") {
            tabname = "visa";
        }
        else if (item.QuestionHeadingid == "15002") {
            tabname = "Education";
        }

        var radbtn = "rad" + tabname + "ANo";
        var mark = "lbl" + tabname + "mark";
        var QuestionID = "lbl" + tabname + "QuestionId";
        var ans = "lbl" + tabname + "answer";
        var Commands = "txt" + tabname + "commentsQ";
        var overalllinkedIn = "lbl" + tabname + "overallrating";



        if (item.QuestionHeadingid == "15000") {
            // for (i = 0; i < 9; i++) {
            var Ans = document.getElementById(ans + j).innerHTML;
            if (item.Questionid == parseInt(document.getElementById(QuestionID + j).innerHTML)) {
                if (item.Answer == "10000") {
                    if (Ans == "Yes") {
                        markarr.push(document.getElementById(mark + j).innerHTML);
                    }
                    // document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                    document.getElementsByName(radbtn + j)[0].checked = true;

                }
                else if (item.Answer == "10001") {
                    if (Ans == "No") {
                        markarr.push(document.getElementById(mark + j).innerHTML);
                    }
                    document.getElementsByName(radbtn + j)[1].checked = true;
                    //document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                }
                document.getElementById(Commands + j).value = item.Comments;

            }
            j++;
            // }
        }
        var totMar = "0";

        for (var p = 0; p < markarr.length; p++) {
            totMar = parseInt(totMar) + parseInt(markarr[p]);
        }
        if (tabname == "linkedIn") {
            document.getElementById("lbllinkedInovrallrating").innerHTML = totMar;
            document.getElementById("lbllinkedInpercentage").innerHTML = (totMar / parseInt(document.getElementById("lbllinkedInoverallvalue").innerHTML)) * 100;
        }










        if (item.QuestionHeadingid == "15001") {
            var Ans = document.getElementById(ans + k).innerHTML;
            //for (i = 0; i < 8; i++) {
            if (item.Questionid == parseInt(document.getElementById(QuestionID + k).innerHTML)) {
                if (item.Answer == "10000") {
                    if (Ans == "Yes") {
                        markarr1.push(document.getElementById(mark + k).innerHTML);
                    }
                    //document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                    document.getElementsByName(radbtn + k)[0].checked = true;

                }
                else if (item.Answer == "10001") {
                    if (Ans == "No") {
                        markarr1.push(document.getElementById(mark + k).innerHTML);
                    }
                    document.getElementsByName(radbtn + k)[1].checked = true;
                    //document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                }
                document.getElementById(Commands + k).value = item.Comments;

            }
            k++;
            //}
        }
        var totMar1 = "0";

        for (var q = 0; q < markarr1.length; q++) {
            totMar1 = parseInt(totMar1) + parseInt(markarr1[q]);
        }
        if (tabname == "visa") {
            document.getElementById("lblvisaovrallrating").innerHTML = totMar1;
            document.getElementById("lblvisapercentage").innerHTML = (totMar1 / parseInt(document.getElementById("lblvisaoverallvalue").innerHTML)) * 100;
        }









        if (item.QuestionHeadingid == "15002") {
            var Ans = document.getElementById(ans + l).innerHTML;
            //for (i = 0; i < 4; i++) {
            if (item.Questionid == parseInt(document.getElementById(QuestionID + l).innerHTML)) {
                if (item.Answer == "10000") {
                    if (Ans == "Yes") {
                        markarr2.push(document.getElementById(mark + l).innerHTML);
                    }
                    //document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                    document.getElementsByName(radbtn + l)[0].checked = true;

                }
                else if (item.Answer == "10001") {
                    if (Ans == "No") {
                        markarr2.push(document.getElementById(mark + l).innerHTML);
                    }
                    document.getElementsByName(radbtn + l)[1].checked = true;
                    //document.getElementById("lbllinkedInovrallrating").innerHTML = parseInt(document.getElementById(mark + j).innerHTML);
                }
                document.getElementById(Commands + l).value = item.Comments;

            }
            l++;
        }

        // }

        //}

    });
    //markarr.length = "0";
    var totMar2 = "0";

    for (var p = 0; p < markarr2.length; p++) {
        totMar2 = parseInt(totMar2) + parseInt(markarr2[p]);
    }
    if (tabname == "Education") {
        document.getElementById("lblEducationovrallrating").innerHTML = totMar2;
        document.getElementById("lblEducationpercentage").innerHTML = (totMar2 / parseInt(document.getElementById("lblEducationoverallvalue").innerHTML)) * 100;
    }



}