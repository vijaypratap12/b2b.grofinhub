apiLoadStates = function(stateId, cityId) {
  if (stateId === undefined) stateId = -1;
  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/states",
    success: function(data) {
      console.log(data);
      onStatesLoaded_Enq(data, stateId, cityId);
    },
    error: function(xhr, ajaxOptions, thrownError) {
      console.log("apiLoadStates: " + thrownError);
    }
  });
};

apiLoadCities = function(stateId, cityId) {
  if (stateId === undefined) return;
  if (cityId === undefined) cityId = -1;
  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/states/" + stateId + "/cities",
    success: function(data) {
      onCitiesLoaded_Enq(data,stateId,cityId);
    },
    error: function(xhr, ajaxOptions, thrownError) {
      console.log("apiLoadCities: " + thrownError);
    }
  });
};

function apiSubmitEnquiry(name, stateId, cityId, mobile, email, enquiredFor, variantId, otherCity, otp) {
  if(variantId === undefined) variantId = "";
  var jsonData = {
    name: name,
    stateId: parseInt(stateId),
    cityId: parseInt(cityId),
    mobile: mobile,
    email: email,
    enquiredFor: enquiredFor,
    variantId: variantId,
    otherCity:otherCity,
    otp: otp
    };
  jsonData.originURL = getRefURL();

  var utm = getUTM();
  if (utm) {
    jsonData.utmCampaign = utm.ca;
    jsonData.utmSource = utm.so;
    jsonData.utmTerm = utm.te;
    jsonData.utmContent = utm.co;
    jsonData.utmMedium = utm.me;
  }
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/enquiry/new",
    data: JSON.stringify(jsonData),

    success: function(data) {
      onSubmitEnquirySuccess(data, name, enquiredFor);
    },
    error: function(xhr, ajaxOptions, thrownError) {
      onSubmitEnquiryError(xhr, ajaxOptions, thrownError);
    }
  });
}
