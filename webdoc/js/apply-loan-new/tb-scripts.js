"use strict";

// Choose Model [Start]
var modelList = $(".tb-model-list");
var modelListAttributes = {
    lazyLoad: 'ondemand',
    arrows: false,
    loop: false,
    slidesPerRow: 3,
    rows: 3,
    responsive: [
        {
            breakpoint: 600,
            settings: {
                rows: 1,
                centerMode: true,
                centerPadding: '50px',
                slidesToShow: 1,
                focusOnSelect: true
            }
        }
    ]
}

var modelListAttributesMobile = {
    lazyLoad: 'ondemand',
    arrows: false,
    loop: false,
    infinite:false,
    slidesToShow: 3,
    rows: 3,
    responsive: [
        {
            breakpoint: 600,
            settings: {
                rows: 1,
                centerMode: true,
                centerPadding: '50px',
                slidesToShow: 1,
                focusOnSelect: true
            }
        }
    ]
}
// Choose Model [End]

// // Tabs Clone [Start]
// var tabName1 = $(".tb-tabs-list li:nth-child(1) a[data-steps]").clone(true, true);
// var tabName2 = $(".tb-tabs-list li:nth-child(2) a[data-steps]").clone(true, true);
// var tabName3 = $(".tb-tabs-list li:nth-child(3) a[data-steps]").clone(true, true);
// $(".tb-mobile-tabs-choosecar").html(tabName1);
// $(".tb-mobile-tabs-dealership").html(tabName2);
// $(".tb-mobile-tabs-personal").html(tabName3);

// // Tabs Clone [End]

$(".tb-car-thumbs .slick-current .tb-subtabs-block").addClass("tb-subtabs-active");

$(".tb-car-thumbs").on("breakpoint", function (event, slick, currentSlide, nextSlide) {
    var index = $(this).data("slick-index");
    if ($(".tb-car-thumbs.slick-slider").slick("slickCurrentSlide") !== index) {
        $(".tb-car-thumbs.slick-slider").slick("slickGoTo", index);
    }
});


// Slick Control [Start]
function slickInitialize() {

    modelList.slick(modelListAttributes);
    if ($(".tb-subtabs-block[data-substeps='choose-model']").hasClass("tb-subtabs-active")) {
        modelList.slick("setPosition");
    }

}

function slickReInitialize() {
   if ($(".tb-subtabs-block[data-substeps='choose-model']").hasClass("tb-subtabs-active")) {
        if ($(".tb-model-list.slick-initialized").length > 0) {
            modelList.slick("setPosition");
        }
    }
}
// Slick Control [End]