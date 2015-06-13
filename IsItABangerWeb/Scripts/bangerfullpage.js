$(document).ready(function () {
    $('#fullpage').fullpage({
        sectionsColor: ['#1bbc9b', '#C63D0F', '#4BBFC3', '#7BAABE'],
    });
    $.fn.fullpage.setAllowScrolling(false);
    $.fn.fullpage.setKeyboardScrolling(false);

    $('.banger-scroll-down').each(function (button) {
        $(this).on('click', function (e) {
            $.fn.fullpage.moveSectionDown();
        })
    });

    $('.banger-scroll-up').each(function (button) {
        $(this).on('click', function (e) {
            $.fn.fullpage.moveSectionUp();
        })
    });

});