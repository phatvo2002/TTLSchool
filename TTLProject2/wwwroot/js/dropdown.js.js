jQuery(function ($) {
    //$(".chosen-select").chosen({ allow_single_deselect: true });

    $('.app-tootip').popover({
        container: 'body',
        trigger: 'focus',
        template: '<div class="popover bgc-primary-tp1 border-0" role="tooltip"><div class="arrow arrow2 brc-primary-tp1"></div><div class="popover-body text-white text-110"></div></div>'
    });
});