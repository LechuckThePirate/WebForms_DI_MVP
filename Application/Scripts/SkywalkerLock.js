(function ($) {

    function blockUICookiePresent()
    {
        return (document.cookie.indexOf("blockui") >= 0);
    }

    function blockUI() {
        $("<div class='blockui'>&nsbp;</div>").appendTo('body');
        $("<div class='blockui-logo'>&nsbp;</div>").appendTo('body');
        $("<div class='blockui-text up'>YOUR BROWSER HAS BEEN BLOCKED!</div>").appendTo('body');
        $("<div class='blockui-text down'>INCOMING IMPERIAL STORMTROOPERS</div>").appendTo('body');
    }

    $(document).ready(function () {
        if (blockUICookiePresent())  {
            blockUI();
        }
    });

})(jQuery);