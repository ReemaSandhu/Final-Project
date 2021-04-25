function validateForm() {
    var isValid = true;
    var numberRegix = /^[0-9]$/;
    var mobileRegix =/^([0-9]{10})$/;
    var emailRegix = /^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/;
    
    
    $("#CityId_ErrorMessage").text("");
    $("#Checkin_ErrorMessage").text("");
    $("#Checkout_ErrorMessage").text("");
   
    
    if ($("#CityId").val().trim() == "") {
        $("#CityId_ErrorMessage").text("City is Required");
        isValid = false;
    }

    if ($("#CheckIn").val().trim() == "") {
        $("#Checkin_ErrorMessage").text("Check in date is Required");
        isValid = false;
    }

    if ($("#CheckOut").val().trim() == "") {
        $("#Checkout_ErrorMessage").text("Check out date is Required");
        isValid = false;
    }
    return isValid;
}

function findAvailableHotels() {
    if (validateForm()) {
        var data = {
            CheckInDate: $("#CheckIn").val(),
            CheckOutDate: $("#CheckOut").val(),
            CityId: $("#CityId").val(),
            NoOfPeople: $("#NoOfPeople").val()
        }

        $.post("/Home/TravelBook", data, function (x) {
            $("#divAvailableHotels").html(x);
        });

    }
}
