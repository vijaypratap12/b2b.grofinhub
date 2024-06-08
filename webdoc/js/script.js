	$(window).scroll(function() {    
    var scroll = $(window).scrollTop();

    if (scroll >= 300) {
        $(".move-up").show();
    } else {
        $(".move-up").hide();
    }
});


/*===================================================
Accordion Minus and Plus Toggle
====================================================*/
	
$('.acc-head').click(function () {
	    var collapsed = $(this).find('i').hasClass('fa-plus');

	    $('.acc-head').find('i.fa').removeClass('fa-minus');

	    $('.acc-head').find('i.fa').addClass('fa-plus');
	    if (collapsed)
	        $(this).find('i.fa').toggleClass('fa-plus fa-minus')
});
	