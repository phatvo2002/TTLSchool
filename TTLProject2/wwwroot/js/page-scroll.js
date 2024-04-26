(function($) {
    $('a.page-scroll').bind('click', function(event) {
        var $anchor = $(this);
        var href= $anchor.attr('href');        
        var arr = href.split('/');      
        var idFocus = "#" + arr[arr.length-1];

         $('html, body').stop().animate({
            scrollTop: ($(idFocus).offset().top - 50)
        }, 1250, 'easeInOutExpo');
    });
});