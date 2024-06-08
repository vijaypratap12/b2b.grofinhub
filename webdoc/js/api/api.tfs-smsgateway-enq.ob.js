var _OTP_Enq;
var _ENTEREDMOBILENUMBER_Enq;
var _otpTimer_Enq;

function requestOtp_Enq(objMobileNumber, btnVerify_Enq) {

  _ENTEREDMOBILENUMBER_Enq = objMobileNumber.mobile;
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/smsgateway/otp",
    data: JSON.stringify(objMobileNumber),
    success: function(data, textstatus, xhr) {
      onOtpGenerated_Enq(data, xhr, btnVerify_Enq);
    },
    error: function(xhr, ajaxOptions, thrownError) {
        var response = JSON.parse(xhr.responseText);
        onOtpError_Enq(response.message);
    }
  });
}

function onOtpGenerated_Enq(data, xhr, btnVerify_Enq) {
  if (xhr.status == 200) {
    var otp = data.otp;
    _OTP_Enq = atob(otp.substring(6, otp.length - 6));
    onOtpSuccess_Enq();
    _otpTimer_Enq = setInterval(function() {
      countDown_Enq(btnVerify_Enq);
    }, 1000);
  }
}

function onValidateOtp_Enq(objMobileNumber, objOtp) {
 
  if(_ENTEREDMOBILENUMBER_Enq == null) return false;
   if(_OTP_Enq == null)
  {
       onOtpValidationError_Enq("NO_OTP_GENERATED");
       return false;
  }
  if($(objOtp).val() == "")
  {
    onOtpValidationError_Enq("NO_OTP_ENTERED");
    return false;
  } 
  
  if ($(objMobileNumber).val() == _ENTEREDMOBILENUMBER_Enq) {
    if ($(objOtp).val() == _OTP_Enq) {
      return true;
    } else {
      onOtpValidationError_Enq("OTP_MISMATCH");
      return false;
    }
  } else {
    onOtpValidationError_Enq("MOBILE_MISMATCH");
    return false;
  }
}

var _otpCountDownTime_Enq = 30;
function countDown_Enq(btnVerify_Enq) {
  if (_otpCountDownTime_Enq !== 0) {
    $(btnVerify_Enq).text("Verify ("+ _otpCountDownTime_Enq + ")");
    $(btnVerify_Enq).attr("disabled", true);
    _otpCountDownTime_Enq = _otpCountDownTime_Enq - 1;
  } else {
    clearInterval(_otpTimer_Enq);
    $(btnVerify_Enq).text("Verify");
    $(btnVerify_Enq).attr("disabled", false);
    $(btnVerify_Enq).focus();
    _otpCountDownTime_Enq = 30;
  }
}
