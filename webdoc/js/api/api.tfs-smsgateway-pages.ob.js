var _OTP_Pages;
var _ENTEREDMOBILENUMBER_Pages;
var _otpTimer_Pages;

function requestOtp_Pages(objMobileNumber, btnVerify_pages) {
  _ENTEREDMOBILENUMBER_Pages = objMobileNumber.mobile;
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/smsgateway/otp",
    data: JSON.stringify(objMobileNumber),
    success: function(data, textstatus, xhr) {
      onOtpGenerated_Pages(data, xhr, btnVerify_pages);
    },
    error: function(xhr, ajaxOptions, thrownError) {
        var response = JSON.parse(xhr.responseText);
        onOtpError_Pages(response.message);
    }
  });
}

function onOtpGenerated_Pages(data, xhr, btnVerify_pages) {
  if (xhr.status == 200) {
    var otp = data.otp;
    _OTP_Pages = atob(otp.substring(6, otp.length - 6));
    onOtpSuccess_Pages();
    _otpTimer_Pages = setInterval(function() {
      countDown_Pages(btnVerify_pages);
    }, 1000);
  }
}

function onValidateOtp_Pages(objMobileNumber, objOtp) {    
  if(_ENTEREDMOBILENUMBER_Pages == null) return false;
   if(_OTP_Pages == null)
  {
       onOtpValidationError_Pages("NO_OTP_GENERATED");
       return false;
  }
  if($(objOtp).val() == "")
  {
    onOtpValidationError_Pages("NO_OTP_ENTERED");
    return false;
  } 
  
  if ($(objMobileNumber).val() == _ENTEREDMOBILENUMBER_Pages) {
    if ($(objOtp).val() == _OTP_Pages) {
      return true;
    } else {
      onOtpValidationError_Pages("OTP_MISMATCH");
      return false;
    }
  } else {
    onOtpValidationError_Pages("MOBILE_MISMATCH");
    return false;
  }
}

var _otpCountDownTime_Pages = 30;
function countDown_Pages(btnVerify_pages) {
  if (_otpCountDownTime_Pages !== 0) {
    $(btnVerify_pages).text("Verify ("+ _otpCountDownTime_Pages + ")");
    $(btnVerify_pages).attr("disabled", true);
    _otpCountDownTime_Pages = _otpCountDownTime_Pages - 1;
  } else {
    clearInterval(_otpTimer_Pages);
    $(btnVerify_pages).text("Verify");
    $(btnVerify_pages).attr("disabled", false);
    $(btnVerify_pages).focus();
    _otpCountDownTime_Pages = 30;
  }
}
