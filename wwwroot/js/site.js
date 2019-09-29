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