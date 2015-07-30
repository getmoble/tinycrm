$("#btntoggle").click(function (e) {
    if (localStorage.getItem('collapseStatus') == "Open" || localStorage.getItem('collapseStatus') == "") {
        e.preventDefault();
        alert('hh');
        var collapseStatus = "Close";
        localStorage.setItem('collapseStatus', collapseStatus);
        alert(localStorage.getItem('collapseStatus'));
    } else {
        e.preventDefault();
        alert('hhsss');
        var collapseStatus = "Open";
        localStorage.setItem('collapseStatus', collapseStatus);
        alert(localStorage.getItem('collapseStatus'));
    }
});
var getValue = localStorage.getItem('collapseStatus');
if (getValue == 'Close') {
    $('#nav').addClass('nav-xs');
    $('#btntoggle').addClass('active');
}
else {
    $('#nav').removeClass('nav-xs');
    $('#btntoggle').removeClass('active');
}
jQuery(document).ready(function ($) {
    var isLateralNavAnimating = false;

    //open/close lateral navigation
    $('.cd-nav-trigger').on('click', function (event) {
        if (localStorage.getItem('collapseStatus') == "Open" || localStorage.getItem('collapseStatus') == "") {
            event.preventDefault();
            //stop if nav animation is running 
            if (!isLateralNavAnimating) {
                if ($(this).parents('.csstransitions').length > 0) isLateralNavAnimating = true;

                $('body').toggleClass('navigation-is-open');
                $('.cd-navigation-wrapper').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
                    //animation is over
                    isLateralNavAnimating = false;
                });
                var collapseStatus = "Close";
                localStorage.setItem('collapseStatus', collapseStatus);
            }
        } else {
            event.preventDefault();
            //stop if nav animation is running 
            if (!isLateralNavAnimating) {
                if ($(this).parents('.csstransitions').length > 0) isLateralNavAnimating = true;

                $('body').toggleClass('navigation-is-open');
                $('.cd-navigation-wrapper').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
                    //animation is over
                    isLateralNavAnimating = false;
                });
                var collapseStatus = "Open";
                localStorage.setItem('collapseStatus', collapseStatus);
            }
        }
    });
});

$('.nav-primary ul.nav>li.active>ul').hover(
    function () { $('.nav-primary .nav>li').css({ 'background-color': '#cccccc' }); },
    function () { $('.nav-primary .nav>li').css({ 'background-color': '#f8f8f8' }); }
 );

