$("#menu-toggle").click(function (e) {
    e.preventDefault();
    $("#wrapper").toggleClass("toggled");


});

//$("#menu-toggle").click(function () {
//    $(".nav-primary>ul>li>a span").hide();
//    $(".nav-primary li").css("padding", "10px 0px");


    
        $("#menu-toggle").click(function () {
            $(".nav-primary>ul>li>a span").toggle();
           
        });
       

        jQuery(document).ready(function ($) {
            var isLateralNavAnimating = false;

            //open/close lateral navigation
            $('.cd-nav-trigger').on('click', function (event) {
                event.preventDefault();
                //stop if nav animation is running 
                if (!isLateralNavAnimating) {
                    if ($(this).parents('.csstransitions').length > 0) isLateralNavAnimating = true;

                    $('body').toggleClass('navigation-is-open');
                    $('.cd-navigation-wrapper').one('webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend', function () {
                        //animation is over
                        isLateralNavAnimating = false;
                    });
                }
            });
        });

