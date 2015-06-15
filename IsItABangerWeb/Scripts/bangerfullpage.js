$(document).ready(function () {
    $('#fullpage').fullpage({
        sectionsColor: ['#1bbc9b', '#C63D0F', '#4BBFC3', '#7BAABE'],
    });
    $.fn.fullpage.setAllowScrolling(false);
    $.fn.fullpage.setKeyboardScrolling(false);

    $('.banger-scroll-down').each(function (button) {
        $(this).on('click', function (e) {
            // When clicking the Next button, validate the field before scrolling to the next section.
            // The field to validate is stored in the data-banger-valfield attribute
            var fieldToValidate = $(this).attr('data-banger-valfield');            
            if (fieldToValidate != null)
            {
                var isValid = $('#' + fieldToValidate).valid();
                if (!isValid)
                {
                    return;
                }
            }
            
            $.fn.fullpage.moveSectionDown();
        })
    });

    $('.banger-scroll-up').each(function (button) {
        $(this).on('click', function (e) {
            $.fn.fullpage.moveSectionUp();
        })
    });

});