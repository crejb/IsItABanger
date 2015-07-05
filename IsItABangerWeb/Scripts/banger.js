$(function () {
    var refreshTable = function () {
        var $a = $(this);
        
        // Create the options for an ajax request:
        // - type is Get
        // - target url comes from the element href attribute
        var options = {
            url: $a.attr("href"),
            data: $("form").serialize(),
            type: "get"
        };

        // Perform the ajax request
        $.ajax(options).done(function (data) {
            // When the refreshed table comes back, replace the table with the new data
            var target = $a.parents("div.async-table-host").attr("data-banger-target");
            $(target).replaceWith(data);
        });
        // Prevent the normal link operation
        return false;
    };

    // Refresh paging async
    // Handle click events on the main body-content
    // Look for an event that has bubbled up from a async-table-host, and intercept it
    // i.e. clicked on an <a /> tag inside an element with class "async-table-host"
    $(".body-content").on("click", ".async-table-host a", refreshTable);

});