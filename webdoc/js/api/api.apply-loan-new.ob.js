apiLoadBusinessStates = function (stateId, cityId) {
  if (stateId === undefined) stateId = -1;
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/businessstates",
      success: function (data) {
        resolve(onBusinessStatesLoaded(data, stateId, cityId));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadBusinessStates: " + thrownError);
      },
    });
  });
};

apiLoadBusinessCities = function (stateId, cityId) {
  if (stateId === undefined) return;
  if (cityId === undefined) cityId = -1;
  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/states/" + stateId + "/businesscities",
    success: function (data) {
      onBusinessCitiesLoaded(data, stateId, cityId);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      console.log("apiLoadBusinessCities: " + thrownError);
    },
  });
};

apiLoadDealers = function (cityId) {
  if (cityId === undefined) cityId = -1;
  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/city/" + cityId + "/dealers",
    success: function (data) {
      onDealersLoaded(data, cityId);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      console.log("apiLoadDealers: " + thrownError);
    },
  });
};

apiLoadStates = function (stateId) {
  if (stateId === undefined) stateId = -1;
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/states",
      success: function (data) {
        resolve(onStatesLoaded(data, stateId));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadStates: " + thrownError);
      },
    });
  });
};

apiLoadModels = function (city_id) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      url: API_BASEURL + "1.0/api/cities/" + city_id + "/models",
      dataType: "JSON",
      success: function (JSON) {
        resolve(bindModels(JSON));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadModels: " + thrownError);
      },
    });
  });
};

apiLoadFuelTypes = function (modelId) {
  if (modelId === undefined) return;

  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/models/" + modelId + "/fuelTypes",
    success: function (data) {
      onFuelTypesLoaded(data, modelId);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      console.log("apiLoadFuelType: " + thrownError);
    },
  });
};
apiLoadVariants = function (modelId, cityId) {
  if (modelId === undefined) return;
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url:
        API_BASEURL +
        "1.0/api/cities/" +
        cityId +
        "/models/" +
        modelId +
        "/variants",
      success: function (data) {
        resolve(onVariantsLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadFuelType: " + thrownError);
      },
    });
  });
};

apiLoadVariantsFuelType = function (fuelType, modelId, cityId) {
  if (fuelType === undefined) return;
  if (modelId === undefined) return;

  $.ajax({
    type: "POST",
    dataType: "json",
    url:
      API_BASEURL +
      "1.0/api/cities/" +
      cityId +
      "/models/" +
      modelId +
      "/fueltypes/" +
      fuelType +
      "/variants",
    success: function (data) {
      onFuelTypeVariantsLoaded(data, fuelType, modelId, cityId);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      console.log("apiLoadVariants: " + thrownError);
    },
  });
};

apiUsageType = function () {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      url: API_BASEURL + "1.0/api/usagetypes",
      success: function (data) {
        resolve(onUsageTypeLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiUsageType: " + thrownError);
      },
    });
  });
};

apiLoadSalutation = function () {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/titles",
      success: function (data) {
        resolve(onSalutationLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadSalutation: " + thrownError);
      },
    });
  });
};
apiLoadInitialEmiChart = function (id) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "post",
      dataType: "json",
      url: API_BASEURL + "1.0/api/application/" + id + "/initialemi",
      success: function (data) {
        resolve(onInitialEmiValuesLoad(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("onInitialEmiValuesLoad: " + thrownError);
      },
    });
  });
};

apiLoadEMiCharts = function (jsonData) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      url: API_BASEURL + "1.0/api/emi",
      data: JSON.stringify(jsonData),
      success: function (data) {
        resolve(emiGraphData(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadEmiCharts: " + thrownError);
      },
    });
  });
};

apiLoadGender = function () {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/genders",
      success: function (data) {
        resolve(onGenderLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadVariantPrice: " + thrownError);
      },
    });
  });
};

apiLoadNatureOfBusiness = function () {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/nobs",
      success: function (data) {
        resolve(onNatureOfBusinessLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadNatureOfBusiness " + thrownError);
      },
    });
  });
};

apiLoadResidenceStatus = function () {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      url: API_BASEURL + "1.0/api/residencestatuses",
      success: function (data) {
        resolve(onResidenceStatusLoaded(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiLoadNatureOfBusiness " + thrownError);
      },
    });
  });
};
function requestOtp_Pages(objMobileNumber) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/smsgateway/otp",
    data: JSON.stringify(objMobileNumber),
    success: function (data, textstatus, xhr) {
      onOtpGenerated_Pages(xhr);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      var response = JSON.parse(xhr.responseText);
      onOtpError_Pages(response.message);
    },
  });
}
// Upload Documents

apiCheckApplication = function (digiRefNo) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/liveapplication/check",
    data: JSON.stringify(digiRefNo),
    success: function (data) {
      onApplicationCheck(data);
    },
    error: function (xhr, ajaxOptions, data) {
      var errorCode = JSON.parse(xhr.responseText);
      onApplicationError(errorCode.code);
    },
  });
  apiDocumentCategories = function (id) {
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      url: API_BASEURL + "1.0/api/application/" + id + "/documentcategories",
      success: function (data) {
        onDocumentCategories(data);
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiDocumentCategories: " + thrownError);
      },
    });
  };

  apiDocumentNames = function (id, categoryId) {
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      url:
        API_BASEURL +
        "1.0/api/application/" +
        id +
        "/documentcategories/" +
        categoryId +
        "/names",
      success: function (data) {
        onDocumentNamesLoaded(data);
      },
      error: function (xhr, ajaxOptions, thrownError) {
        console.log("apiDocumentNames: " + thrownError);
      },
    });
  };
};

apiFileUpload = function (data, applicationId, documentNameId, hash) {
  $.ajax({
    type: "POST",
    enctype: "multipart/form-data",
    headers: {
      hash: hash,
    },
    url:
      API_BASEURL +
      "1.0/api/application/" +
      applicationId +
      "/documentnames/" +
      documentNameId +
      "/upload",
    data: data,
    processData: false,
    contentType: false,
    cache: false,
    timeout: 600000,
    success: function (result) {
      onFileUploadSuccess(result);
    },
    error: function (e) {
      onFileUploadError(e);
    },
  });
};

apiDeleteDocument = function (applicationId, documentId, hash) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    headers: {
      hash: hash,
    },
    url:
      API_BASEURL +
      "1.0/api/application/" +
      applicationId +
      "/documents/" +
      documentId +
      "/delete",
    success: function (result) {
      onDocumentDelete(result);
    },
    error: function (e) {
      console.log(e);
    },
  });
};

apiSubmitDocuments = function (applicationId, hash) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    headers: {
      hash: hash,
    },
    url:
      API_BASEURL + "1.0/api/application/" + applicationId + "/uploadcomplete",
    success: function (result) {
      onDocumentSubmitSuccess(result);
    },
    error: function (e) {
      console.log(e);
    },
  });
};
// Upload Documents End

// Survey api

apiSubmitSurvey = function (applicationId, surveyData, hash) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    headers: {
      hash: hash,
    },
    url: API_BASEURL + "1.0/api/application/" + applicationId + "/survey",
    data: JSON.stringify(surveyData),
    success: function (data) {
      onSurveySuccess(data);
    },
    error: function (data) {
      onSurveyError(data);
    },
  });
};
// Survey api

// loan-applicatation-status

apiGetStatus = function (jsonData) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/application/applicationstatus",
    data: JSON.stringify(jsonData),
    success: function (data) {
      onGetStatusSuccess(data);
    },
    error: function (data) {
      onGetStatusError(data);
    },
  });
};

// loan-application-status

// submit api
apiDraftFormSubmit = function (jsonData) {
  return new Promise(function (resolve, reject) {
    $.ajax({
      type: "POST",
      dataType: "json",
      contentType: "application/json; charset=utf-8",
      url: API_BASEURL + "1.0/api/application/savedraft",
      data: JSON.stringify(jsonData),
      success: function (data) {
        resolve(onSubmitFormSuccess(data));
      },
      error: function (xhr, ajaxOptions, thrownError) {
        var responseText = JSON.parse(xhr.responseText);
        console.log(responseText);
        onErrorDraftFormSubmit(responseText.code);
      },
    });
  });
};

apiFinalSaveDetails = function (url, jsonData) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + url,
    data: JSON.stringify(jsonData),
    success: function (data) {
      onFinalSaveDetails(data);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      var error = JSON.parse(xhr.responseText);
      onFinalSaveErrorMsg(error.code);
    },
  });
};

apiLoadUserDetails = function (jsonData, id) {
  $.ajax({
    type: "POST",
    dataType: "json",
    contentType: "application/json; charset=utf-8",
    url: API_BASEURL + "1.0/api/application/" + id + "/retrieve",
    data: JSON.stringify(jsonData),
    success: function (data) {
      populateUserFormDetails(data);
    },
    error: function (xhr, ajaxOptions, thrownError) {
      var errorCode = JSON.parse(xhr.responseText);
      onLoadRetriveErrorMsg(errorCode.code);
    },
  });
};
