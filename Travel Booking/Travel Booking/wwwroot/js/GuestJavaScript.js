function validateForm() {
    var isValid = true;
    var numberRegix = /[2-9]{2}\d{8}/;
    var emailRegix = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    var salaryRegix = /^\d{1,6}(?:\.\d{0,2})?$/;
    var passwordRegix = /^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$/;
    $("#GuestFirstName_ErrorMessage").text("");
    $("#GuestLastName_ErrorMessage").text("");
    $("#MobileNumber_ErrorMessage").text("");
    $("#Email_ErrorMessage").text("");
    

    if ($("#GuestFirstName").val().trim() == "") {
        $("#GuestFirstName_ErrorMessage").text("First Name is Required");
        isValid = false;
    }
    if ($("#GuestLastName").val().trim() == "") {
        $("#GuestLastName_ErrorMessage").text("Last Name is Required");
        isValid = false;
    }

    if ($("#MobileNumber").val().trim() == "") {
        $("#MobileNumber_ErrorMessage").text("Mobile Number is Required");
        isValid = false;
    }

    if ($("#MobileNumber").val().trim() != "" && !numberRegix.test($("#MobileNumber").val().trim())) {
        $("#MobileNumber_ErrorMessage").text("Mobile Number is INVALID");
    }

    if ($("#Email").val().trim() == "") {
        $("#Email_ErrorMessage").text("Email is Required");
        isValid = false;
    }
    if ($("#Email").val().trim() != "" && !emailRegix.test($("#Email").val().trim())) {
        $("#Email_ErrorMessage").text("Email is INVALID");
    }
    return isValid;
}



function submitForm() {
    if (validateForm()) {
        $("#GuestForm").submit();
    }
}

