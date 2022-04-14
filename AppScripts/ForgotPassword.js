function sendForgetPasswordMail() {
    if (Validateforgotpass() == true) {
        
        var strdata = { "emailid": $('#txtemailid').val(), "TWE_Id": $('#txtusername').val() };

        common_api_ajax_request("api/ForgotPassword", "FORGOTMAIL", strdata);
    }
}



function successCallBack(key, value) {

    var response = value.d;
    var resData = response.data;

    if (key == "FORGOTMAIL") {
        if (resData =="Valid User") {
            $("#div-message").text('Mail has been sent successfully');
        }
        else if (resData == "Invalid Credentials") {
            $("#div-message").text('Invalid Username and email id');
        }
        else if (resData == "Mail Failed") {
            $("#div-message").text('Mail has not been sent');
        }

        $("#msgpopup").modal('show');
        stopLoader();
    }

    
}

function Validateforgotpass() {
    var count = 0;
    var emptycount = 0;
    if ($("#txtusername").val() == "") {
        $('#txtusername').addClass("is-invalid");
        $('#txtusername').focus();
        emptycount++;
    }
    else {
        $('#txtusername').removeClass("is-invalid");
        count++;
    }

    if ($("#txtemailid").val() == "") {
        $('#txtemailid').addClass("is-invalid");
        $('#txtemailid').focus();
        emptycount++;
    }
    else {
        $('#txtemailid').removeClass("is-invalid");
        count++;
    }

    if (parseInt(emptycount) > 0) {
        return false;
    }

    else if (parseInt(count) > 0) {
        return true;
    }
}

function ValidateEmail(input) {
    var inputText = document.getElementById(input);
    var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    if (inputText.value.match(mailformat)) {
        //alert("Valid email address!");
        $("#" + input).removeClass("is-invalid");
        $('#btnReset').prop('disabled', false);
        $('#lblvalidemail').css("display", "none");
        return true;
    }
    else {
        if (inputText.value != "") {
            $("#" + input).addClass("is-invalid");
            $("#" + input).focus();
            $('#btnReset').prop('disabled', 'disabled');
            $('#lblvalidemail').css("display", "block");
            //alert("You have entered an invalid email address!");
            return false;
        }
    }
}



