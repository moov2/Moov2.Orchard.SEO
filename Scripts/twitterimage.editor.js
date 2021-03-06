/*
** NOTE: This file is generated by Gulp and should not be edited directly!
** Any changes made directly to this file will be overwritten next time its asset group is processed by Gulp.
*/

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
        document.querySelector('.js-twitter-image .js-favicon-url-input').value = url;
    };

    /**
     * Initialises favicon editor
     */
    var init = function () {
        var $mediaLibrary = document.querySelector('.js-twitter-image .js-open-media-library');
        $mediaLibrary.addEventListener('click', openMediaPicker);
    };

    init();
})();
//# sourceMappingURL=data:application/json;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbInR3aXR0ZXJpbWFnZS5lZGl0b3IuanMiXSwibmFtZXMiOltdLCJtYXBwaW5ncyI6IkFBQUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEFBTEE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBIiwiZmlsZSI6InR3aXR0ZXJpbWFnZS5lZGl0b3IuanMiLCJzb3VyY2VzQ29udGVudCI6WyIoZnVuY3Rpb24gKCkge1xyXG4gICAgLyoqXHJcbiAgICAgKiBPcGVucyBtZWRpYSBsaWJyYXJ5IHBpY2tlci5cclxuICAgICAqL1xyXG4gICAgdmFyIG9wZW5NZWRpYVBpY2tlciA9IGZ1bmN0aW9uIChlKSB7XHJcbiAgICAgICAgZS5wcmV2ZW50RGVmYXVsdCgpO1xyXG5cclxuICAgICAgICB2YXIgYWRtaW5JbmRleCA9IGxvY2F0aW9uLmhyZWYudG9Mb3dlckNhc2UoKS5pbmRleE9mKFwiL2FkbWluL1wiKSxcclxuICAgICAgICAgICAgdXJsO1xyXG5cclxuICAgICAgICBpZiAoYWRtaW5JbmRleCA9PT0gLTEpIHtcclxuICAgICAgICAgICAgcmV0dXJuO1xyXG4gICAgICAgIH1cclxuXHJcbiAgICAgICAgdXJsID0gbG9jYXRpb24uaHJlZi5zdWJzdHIoMCwgYWRtaW5JbmRleCkgKyBcIi9BZG1pbi9PcmNoYXJkLk1lZGlhTGlicmFyeT9kaWFsb2c9dHJ1ZVwiO1xyXG5cclxuICAgICAgICAkLmNvbG9yYm94KHtcclxuICAgICAgICAgICAgaHJlZjogdXJsLFxyXG4gICAgICAgICAgICBpZnJhbWU6IHRydWUsXHJcbiAgICAgICAgICAgIHJlcG9zaXRpb246IHRydWUsXHJcbiAgICAgICAgICAgIHdpZHRoOiAnOTAlJyxcclxuICAgICAgICAgICAgaGVpZ2h0OiAnOTAlJyxcclxuICAgICAgICAgICAgb25Mb2FkOiBmdW5jdGlvbiAoKSB7XHJcbiAgICAgICAgICAgICAgICAvLyBoaWRlIHRoZSBzY3JvbGxiYXJzIGZyb20gdGhlIG1haW4gd2luZG93XHJcbiAgICAgICAgICAgICAgICAkKCdodG1sLCBib2R5JykuY3NzKCdvdmVyZmxvdycsICdoaWRkZW4nKTtcclxuICAgICAgICAgICAgfSxcclxuICAgICAgICAgICAgb25DbG9zZWQ6IGZ1bmN0aW9uICgpIHtcclxuICAgICAgICAgICAgICAgIHZhciBhZG1pbkluZGV4ID0gbG9jYXRpb24uaHJlZi50b0xvd2VyQ2FzZSgpLmluZGV4T2YoXCIvYWRtaW4vXCIpXHJcbiAgICAgICAgICAgICAgICB2YXIgc2VsZWN0ZWREYXRhID0gJC5jb2xvcmJveC5zZWxlY3RlZERhdGE7XHJcblxyXG4gICAgICAgICAgICAgICAgJCgnaHRtbCwgYm9keScpLmNzcygnb3ZlcmZsb3cnLCAnJyk7XHJcblxyXG4gICAgICAgICAgICAgICAgaWYgKHNlbGVjdGVkRGF0YS5sZW5ndGggPT09IDApIHtcclxuICAgICAgICAgICAgICAgICAgICByZXR1cm47XHJcbiAgICAgICAgICAgICAgICB9XHJcblxyXG4gICAgICAgICAgICAgICAgLy8gVGhlIG1lZGlhIGRvZXNuJ3Qgc2VlbSB0byBiZSBhIGxvY2FsIHJlc291cmNlLCBcclxuICAgICAgICAgICAgICAgIC8vIHBhc3MgaXRzIGN1cnJlbnQgcmVzb3VyY2UgcGF0aCB0byBzZXRNZWRpYVxyXG4gICAgICAgICAgICAgICAgaWYgKHNlbGVjdGVkRGF0YVswXS5yZXNvdXJjZVswXSAhPT0gXCIvXCIpXHJcbiAgICAgICAgICAgICAgICAgICAgc2V0TWVkaWEoc2VsZWN0ZWREYXRhWzBdLnJlc291cmNlKTtcclxuICAgICAgICAgICAgICAgIGVsc2VcclxuICAgICAgICAgICAgICAgICAgICBzZXRNZWRpYShsb2NhdGlvbi5ocmVmLnN1YnN0cigwLCBhZG1pbkluZGV4KSArIHNlbGVjdGVkRGF0YVswXS5yZXNvdXJjZSk7XHJcbiAgICAgICAgICAgIH1cclxuICAgICAgICB9KTtcclxuICAgIH07XHJcblxyXG4gICAgdmFyIHNldE1lZGlhID0gZnVuY3Rpb24gKHVybCkge1xyXG4gICAgICAgIGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3IoJy5qcy10d2l0dGVyLWltYWdlIC5qcy1mYXZpY29uLXVybC1pbnB1dCcpLnZhbHVlID0gdXJsO1xyXG4gICAgfTtcclxuXHJcbiAgICAvKipcclxuICAgICAqIEluaXRpYWxpc2VzIGZhdmljb24gZWRpdG9yXHJcbiAgICAgKi9cclxuICAgIHZhciBpbml0ID0gZnVuY3Rpb24gKCkge1xyXG4gICAgICAgIHZhciAkbWVkaWFMaWJyYXJ5ID0gZG9jdW1lbnQucXVlcnlTZWxlY3RvcignLmpzLXR3aXR0ZXItaW1hZ2UgLmpzLW9wZW4tbWVkaWEtbGlicmFyeScpO1xyXG4gICAgICAgICRtZWRpYUxpYnJhcnkuYWRkRXZlbnRMaXN0ZW5lcignY2xpY2snLCBvcGVuTWVkaWFQaWNrZXIpO1xyXG4gICAgfTtcclxuXHJcbiAgICBpbml0KCk7XHJcbn0pKCk7Il0sInNvdXJjZVJvb3QiOiIvc291cmNlLyJ9
