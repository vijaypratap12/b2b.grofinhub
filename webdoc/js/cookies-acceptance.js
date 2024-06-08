
 window.addEventListener('load', function (){
    checkCookies();   
});
function loadCookieComponent() {
    $.get('/common/cookies.html', function (response) {
        $('body').append(response);
        $("#sectionCookies").hide().fadeIn('slow');
    }).fail(function () {
        console.log("Failed to load cookie Component!");
    });
}


checkCookies=function(){
    var cookieName=getCookie('AcceptCookies');
    if(cookieName==""){
        loadCookieComponent();
    }
}
acceptCookies = function(){
    setCookie('AcceptCookies','yes',365);
    $("#sectionCookies").fadeOut('slow');
}