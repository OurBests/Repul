
$("#menu_toggle_btn").click(function () {
    if (!$(this).attr('data-toggle') || $(this).attr('data-toggle') === '0') {
        $("#sidebar-wrapper").attr('style', 'width:250px!important');
        $("#sidebar-wrapper *").show();
        $(this).attr('data-toggle', '1');
    } else {
        $("#sidebar-wrapper").attr('style', 'width:50px!important');
        $("#sidebar-wrapper *").hide();
        $(this).attr('data-toggle', '0');
    }
});
function animateCSS(element, animationName, callback) {
    const node = document.querySelector(element);
    node.classList.add('animated', animationName, 'faster');

    function handleAnimationEnd() {
        node.classList.remove('animated', animationName);
        node.removeEventListener('animationend', handleAnimationEnd);
            
        if (typeof callback === 'function') callback();
    }

    node.addEventListener('animationend', handleAnimationEnd);
}
function isValidIranianNationalCode(input) {
    if (!/^\d{10}$/.test(input))
        return false;

    var check = parseInt(input[9]);
    var sum = 0;
    var i;
    for (i = 0; i < 9; ++i) {
        sum += parseInt(input[i]) * (10 - i);
    }
    sum %= 11;

    return (sum < 2 && check == sum) || (sum >= 2 && check + sum == 11);
}

const targetElement = document.querySelector("body");
bodyScrollLock.disableBodyScroll(targetElement);
bodyScrollLock.enableBodyScroll(targetElement);
bodyScrollLock.clearAllBodyScrollLocks();


// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//$(document).ready(function () {
//    $("#menu-toggle").click(function (e) {
//        e.preventDefault();
//        $("#wrapper").toggleClass("menuDisplayed");
//    });
//});

//$.ajaxSetup({ cache: false });
//const get = url => new Promise((resolve, reject) => {
//    $.getJSON(url)
//        .then(d => resolve(d))
//        .fail(e => reject(e));
//});
//window.addEventListener('popstate', (e) => {
//    const path = document.location.pathname;
//    app.run('/', path);
//});
//$('.sidebar-nav li a').on('click', function (event) {
//    event.preventDefault();
//    $('.sidebar-nav li').removeClass('active');
//    $(this).parents('li').addClass('active');
//    const menu = $(this).addClass('active')[0];
//    history.pushState(null, '', menu.href);
//    app.run('/', menu.pathname);
//});
//const view = (state) => state;
//const update = {
//    '/': async (_, path) => {
//        const json = await get(path);
//        return json;
//    }
//};
//app.start('apprun-app', null, view, update);