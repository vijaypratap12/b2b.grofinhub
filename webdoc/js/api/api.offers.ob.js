$(document).ready(function () {
    apiLoadOffers = function () { 
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: API_BASEURL + '1.0/api/offers',
            success: function (data) {
                onOffersLoaded(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log("apiLoadOffers: " + thrownError);
            }
        });
    }

});