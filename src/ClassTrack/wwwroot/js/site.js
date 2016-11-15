// site.js

(function () {

    var $sidebarAndWrapper = $("#sidebar, #wrapper");
    var $icon = $("#sidebarToggle i.fa");
    var $toggle = $("#sidebarToggle");

    $toggle.on("click", function () {
        $sidebarAndWrapper.toggleClass("hide-sidebar");
        if ($sidebarAndWrapper.hasClass("hide-sidebar")) {
            $icon.removeClass("fa-angle-left");
            $icon.addClass("fa-angle-right");
            $toggle.addClass("move");
        } else {
            $icon.removeClass("fa-angle-right");
            $icon.addClass("fa-angle-left");
            $toggle.removeClass("move");
        }
    });


})();