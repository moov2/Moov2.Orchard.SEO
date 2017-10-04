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
                var selectedData = $.colorbox.selectedData;

                $('html, body').css('overflow', '');

                if (selectedData.length === 0) {
                    return;
                }

                setMedia(selectedData);
            }
        });
    };

    var setMedia = function (selectedData) {
        document.querySelector('.js-favicon .js-favicon-url-input').value = selectedData[0].resource;
    };

    /**
     * Initialises favicon editor
     */
    var init = function () {
        var $mediaLibrary = document.querySelector('.js-favicon .js-open-media-library');
        $mediaLibrary.addEventListener('click', openMediaPicker);
    };

    init();
})();