$(document).ready(function () {

    apiLoadBusinessStates = function (stateId, cityId) {
         if (stateId === undefined) stateId = -1;
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: API_BASEURL + '1.0/api/businessstates',
            success: function (data) {
                onBusinessStatesLoaded(data,stateId, cityId);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("apiLoadBusinessStates: " + thrownError);
            }
        });
    }

	   apiLoadBusinessCities = function (stateId, cityId) {
           if (stateId === undefined) return;
           if (cityId === undefined) cityId = -1;
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: API_BASEURL + '1.0/api/states/' + stateId + '/businesscities',
            success: function (data) {
                onBusinessCitiesLoaded(data,stateId, cityId);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("apiLoadBusinessCities: " + thrownError);
            }
        });
    }
	   
	    apiLoadModels = function () {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: API_BASEURL + '1.0/api/models',
            success: function (data) {
                onModelsLoaded(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("apiLoadModels: " + thrownError);
            }
        });
    }
		
	apiLoadFuelTypes = function(modelId) {
	if(modelId === undefined) return

  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/models/" + modelId + "/fuelType",
    success: function(data) {
      onFuelTypesLoaded(data);
    },
    error: function(xhr, ajaxOptions, thrownError) {
      console.log("apiLoadFuelType: " + thrownError);
    }
  });
};
		
apiLoadVariants = function(fuelTypeId, modelId) {
	console.log(fuelTypeId, modelId)
	if(fuelTypeId === undefined) return;
	if(modelId === undefined) return;
	
  $.ajax({
    type: "POST",
    dataType: "json",
    url: API_BASEURL + "1.0/api/models/" + modelId + "/fuelTypes/" + fuelTypeId + "/variants",
    success: function(data) {
      onVariantsLoaded(data);
    },
    error: function(xhr, ajaxOptions, thrownError) {
      console.log("apiLoadVariants: " + thrownError);
    }
  });
};

		
		  apiLoadVariantLoanTerm = function (variantId ,cityId) {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: API_BASEURL + '1.0/api/cities/' + cityId + '/variants/' + variantId + '/emiinput',
            success: function (data) {
                onVariantLoanTermLoaded(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("apiLoadVariantLoanTerm: " + thrownError);
            }
        });
		  }

		  apiLoadLoanTerm = function () {
		      $.ajax({
		          type: 'POST',
		          dataType: 'json',
		          url: API_BASEURL + '1.0/api/loanterms',
		          success: function (data) {
		              onLoanTermLoaded(data);
		          },
		          error: function (xhr, ajaxOptions, thrownError) {
		              console.log("apiLoadLoanTerm: " + thrownError);
		          }
		      });
		  }
		  
		  apiModelsByBudget = function(cityId, downPayment, desiredMonthlyPayment, loanTenure){
			   var jsonData = { cityId: parseInt(cityId), downPayment: parseInt(downPayment), emi: parseInt(desiredMonthlyPayment), term:parseInt(loanTenure)}; 
			   $.ajax({
				   type: 'POST',
				   dataType: 'json',
				   contentType: 'application/json; charset=utf-8',
				   url: API_BASEURL + '1.0/api/modelsbybudget',
				   data: JSON.stringify(jsonData),

				   success: function (data) {            
					   onSubmitModelsByBudgetSuccess(data);
				   },
				   error: function (xhr, ajaxOptions, thrownError) {
					   onSubmitModelsByBudgetError(xhr, ajaxOptions, thrownError);
        }
    });
		  }

   
});