// site.js

(function () {

    // Animation for Sidebar Toggling
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

    // Initialize and Configure Scroll Reveal Animation
    window.sr = ScrollReveal();
    sr.reveal('.sr-img', {
        duration: 1000,
        delay: 200
    });
    sr.reveal('.sr-icons', {
        duration: 600,
        scale: 0.3,
        distance: '0px'
    }, 200);    

})();