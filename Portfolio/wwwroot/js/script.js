function removeBodyOverflowHidden() {
    document.body.style.overflow = '';
    $('body').removeClass('fixed').css({ 'top': 0 });
    window.scrollTo(0, scrollpos);
}

function setupHamburgerMenu() {
    $(".js-ham, .js-ham-lower").click(function () {
        $(this).toggleClass('is-active');
        let drawerClass = $(this).hasClass('js-ham') ? '.js-drawer' : '.js-drawer-lower';
        if ($(this).hasClass('is-active')) {
            $(drawerClass).addClass('is-active');
            scrollpos = $(window).scrollTop();
            $('body').addClass('fixed').css({ 'top': -scrollpos });
        } else {
            $(drawerClass).removeClass('is-active');
            $('body').removeClass('fixed').css({ 'top': 0 });
            window.scrollTo(0, scrollpos);
        }
    });

    $('.js-drawer a, .js-drawer-lower a').on('click', function () {
        $('.js-ham, .js-ham-lower').trigger('click');
    });
}

var scrollpos;

function addHamburgerMenu() {
    scrollpos = $(window).scrollTop();
    $('body').addClass('fixed').css({ 'top': -scrollpos });
}

function removeHamburgerMenu() {
    $('body').removeClass('fixed').css({ 'top': 0 });
    window.scrollTo(0, scrollpos);
}


function setupModal() {
    if ($(".modal").length > 0) {
        MicroModal.init({
            disableScroll: true,
            awaitOpenAnimation: true,
            awaitCloseAnimation: true
        });
    }
}

function setupSelectBoxes() {
    $('.js-select').each(function () {
        $(this).addClass("is-empty");

        $(this).on("change", function () {
            if ($(this).val() !== "") {
                $(this).removeClass("is-empty");
            } else {
                $(this).addClass("is-empty");
            }
        });
    });
}

function setupTabs() {
    $('.js-tab').on('click', function () {
        $('.js-tab, .js-panel').removeClass('is-active');
        $(this).addClass('is-active');
        var index = $('.js-tab').index(this);
        $('.js-panel').eq(index).addClass('is-active');
    });
}
