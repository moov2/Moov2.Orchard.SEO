(function () {
    /**
     * Opens media library picker.
     */
    var openMediaPicker = function (e) {
        e.preventDefault();

        var adminIndex = location.href.toLowerCase().indexOf("/admin/"),
            url;

        if (adminIndex === -1) {
            return;
        }

        url = location.href.substr(0, adminIndex) + "/Admin/Orchard.MediaLibrary?dialog=true";

        $.colorbox({
            href: url,
            iframe: true,
            reposition: true,
            width: '90%',
            height: '90%',
            onLoad: function () {
                // hide the scrollbars from the main window
                $('html, body').css('overflow', 'hidden');
            },
            onClosed: function () {
                var adminIndex = location.href.toLowerCase().indexOf("/admin/")
                var selectedData = $.colorbox.selectedData;

                $('html, body').css('overflow', '');

                if (selectedData.length === 0) {
                    return;
                }

                // The media doesn't seem to be a local resource, 
                // pass its current resource path to setMedia
                if (selectedData[0].resource[0] !== "/")
                    setMedia(selectedData[0].resource);
                else
                    setMedia(location.href.substr(0, adminIndex) + selectedData[0].resource);
            }
        });
    };

    var setMedia = function (url) {
        document.querySelector('.js-open-graph-image .js-favicon-url-input').value = url;
    };

    /**
     * Initialises favicon editor
     */
    var init = function () {
        var $mediaLibrary = document.querySelector('.js-open-graph-image .js-open-media-library');
        $mediaLibrary.addEventListener('click', openMediaPicker);
    };

    init();
})();