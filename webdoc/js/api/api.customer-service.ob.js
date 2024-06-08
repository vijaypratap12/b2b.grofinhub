apiVerifyWebRequest = function (apiURL, mobile, loanNo) {

    var xmlDocument = $.parseXML("<WebCSRVerify/>");

    var mobileNode = xmlDocument.createElement('Mobile');
    xmlDocument.documentElement.appendChild(mobileNode);
    mobileNode.appendChild(document.createTextNode(mobile));

    var loanNoNode = xmlDocument.createElement('LoanNo');
    xmlDocument.documentElement.appendChild(loanNoNode);
    loanNoNode.appendChild(document.createTextNode(loanNo));

    var oSerializer = new XMLSerializer();
    var xmldata = oSerializer.serializeToString(xmlDocument);
        
    $.ajax({
        type: "POST",
        processData: false,
        dataType: "xml",
        contentType: "application/xml",
        url: apiURL,
        data: xmldata,       
        success: function (xml) {            
            onWebCSRVerifyLoaded(xml);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            onWebCSRVerifyError(xhr.responseText);           
            console.log("apiLoadWebCSRVerifyResponse: " + thrownError);
        }
    });
};

apiSubmitRequest = function (apiURL, vin, requestType) {

    var xmlDocument = $.parseXML("<AppCustomerRequest/>");

    var vinNode = xmlDocument.createElement('VIN');
    xmlDocument.documentElement.appendChild(vinNode);
    vinNode.appendChild(document.createTextNode(vin));

    var requestTypeNode = xmlDocument.createElement('RequestType');
    xmlDocument.documentElement.appendChild(requestTypeNode);
    requestTypeNode.appendChild(document.createTextNode(requestType));
       
    
    var oSerializer = new XMLSerializer();
    var xmldata = oSerializer.serializeToString(xmlDocument);
    
    $.ajax({
        type: 'POST',
        url: apiURL,
        processData: false,
        dataType: "xml",
        contentType: "application/xml",
        data: xmldata,
        success: function (xml) {            
            onWebCustRequestSuccess(xml);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            onWebCustRequestError(xhr.responseText);
            console.log("apiWebCustRequest: " + thrownError);
        }
    });
}