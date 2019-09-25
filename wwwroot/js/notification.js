PNotify.prototype.options.styling = "fontawesome";
function notify(title, text, type, icon, hide,customclass) {
    hide = typeof(hide) == 'undefined' ? true : hide;
    var notify = new PNotify({
        title: title,
        text: text,
        type: type,
        icon: icon,
        addclass: 'translucent'+(customclass?customclass:''),
        opacity: 1,
        shadow: true,
        hide: hide,
        history: {
            maxonscreen: 2
        }
    });
}
function dialog(title, text, type, icon, buttons) {
    var buttonsConfig = [];
    for (var i = 0; i < buttons.length; i++) {
        if (buttons[i].visible) {
            buttonsConfig.push({
                text: buttons[i].text,
                addClass: buttons[i].type,
                click: buttons[i].callback
            });
        }
    }
    var notify = new PNotify({
        title: title,   
        text: text,
        icon: icon,
        width: "500px",
        hide: false,
        type: type,
        confirm: {
            confirm: true,
            buttons: buttonsConfig
        },
        buttons: {
            closer: false,
            sticker: false
        },
        history: {
            maxInStack: 2,
            history: false
        },
        addclass: 'stack-modal',
        stack: { 'dir1': 'down', 'dir2': 'right', 'modal': true }
    });
}
function confirmdialog(title, text, type, icon, confirmCallback, cancelCallback) {
    (new PNotify({
        title: title,
        text: text,
        icon: icon,
        hide: false,
        type: type,
        confirm: {
            confirm: true
        },
        buttons: {
            closer: false,
            sticker: false
        },
        history: {
            history: false
        },
        addclass: 'stack-modal',
        stack: { 'dir1': 'down', 'dir2': 'right', 'modal': true }
    })).get()
        .on('pnotify.confirm',
            function () {
                !confirmCallback || confirmCallback();
            })
        .on('pnotify.cancel',
            function () {
                !cancelCallback || cancelCallback();
            });
}