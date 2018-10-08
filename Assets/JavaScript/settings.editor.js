(function () {

    var checkRedirectToDomain = function () {
        if ($('.js-redirect-type-select').val() === 'RedirectToDomain') {
            $('.js-redirect-domain-field').css('display', 'block');
        } else {
            $('.js-redirect-domain-field').css('display', 'hidden');
        }
    };

    $('.js-redirect-type-select').on('change', checkRedirectToDomain);

    checkRedirectToDomain();
})();