var ignoredKeys = [9, 32, 8, 35, 36, 37, 38, 39, 40, 46, 17, 18];
$(document).on('keypress', '[data-format="passport"]', function (e) {

    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /^[0-9]+$/;
    var regExEn = /^[A-Za-z ]+$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    var value = $(this).val() + lastChar;
    var length = value.length;


    if (length == 1) {
        if (!regExEn.test(lastChar))
            e.preventDefault();
    } else if (length > 1 && length < 10) {
        if (!regExNum.test(lastChar))
            e.preventDefault();
    } else {
        e.preventDefault();
    }
});

function checkNationalCode(code) {
    var L = code.length;
    if (L < 8 || parseInt(code, 10) == 0)
        return false;
    code = ('0000' + code).substr(L + 4 - 10);
    if (parseInt(code.substr(3, 6), 10) == 0)
        return false;
    var c = parseInt(code.substr(9, 1), 10), s = 0;
    for (var i = 0; i < 9; i++)
        s += parseInt(code.substr(i, 1), 10) * (10 - i);
    s = s % 11;
    return (s < 2 && c == s) || (s >= 2 && c == (11 - s));
}

$(document).on('keypress', '[data-format="number"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    //^[0-9]*$
    var regExNum = /^[0-9]*$/;
    //var regExNum = /^[+-]?\d$/;
    //var regExNum = /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?(?:\.([0-9]{0,3}))?$/;
    //var regExNum = /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?$/;
    //var regExNum = new RegExp('^-?\\d{1,9}(\\.\\d{1,2})?$');
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="price"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    //^[0-9]*$
    var regExNum = /^[0-9]*$/;
    //var regExNum = /^[+-]?\d$/;
    //var regExNum = /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?(?:\.([0-9]{0,3}))?$/;
    //var regExNum = /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?$/;
    //var regExNum = new RegExp('^-?\\d{1,9}(\\.\\d{1,2})?$');
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();




    //if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
    //    return;
    //}
    //e.preventDefault();
    //var lastChar = String.fromCharCode(e.which || e.keyCode);
    //var value = $(this).val() + lastChar;
    //if (value.length <= 15) {
    //    var newValue = value.replace(/\D/g, "").replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    //    $(this).val(newValue);
    //    $(this).attr('value', newValue.replace(/\D/g, ""));
    //}



});
$(document).on('keypress', '[data-format="floatnumber"]', function (e) {
    debugger;
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    //var regExNum = /^[-+]?[0-9]*\.?[0-9]+$/;
    //var regExNum = /^(0|[1-9]\d*)$/;
    var regExNum = /^(-{1}?(?:([0-9]{0,10}))|([0-9]{1})?(?:([0-9]{0,9})))?(?:\.([0-9]{0,3}))?$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="geographicalCode"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /^[0-9]+$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if ($(e.currentTarget).val().length >= 12 || !regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="phone"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /^[0-9]+$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if ($(e.currentTarget).val().length >= 11 || !regExNum.test(lastChar))
        e.preventDefault();
});

$(document).on('keypress', '[data-format="mobile"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /^[0-9]+$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if ($(e.currentTarget).val().length >= 11 || !regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="persian"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /^[\u0600-\u06FF\s]+$/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="en"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /[A-Z]|[0-9]|[a-z]/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();
});
$(document).on('keypress', '[data-format="cardban"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var regExNum = /[0-9]/;
    var lastChar = String.fromCharCode(e.which || e.keyCode);
    if (!regExNum.test(lastChar))
        e.preventDefault();

    var val = $(this).val().replace(/-/g, '')
    if (val.length  >= 16) {
        e.preventDefault();
        return;
    }
    if (val.length > 0 && val.length % 4 == 0 ) {
        $(this).val($(this).val() + '-');
    }


});
$(document).on('keypress', '[data-format="iban"]', function (e) {
    if (ignoredKeys.find(function (d) { return d == e.keyCode; })) {
        return;
    }
    if (e.shiftKey) {
        e.preventDefault();
        return;
    }
    var charRegs = [/^I|i/, /^R|r/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/
        , /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/, /^[0-9]/];


    var lastChar = String.fromCharCode(e.which || e.keyCode);
    var index = $(e.currentTarget).val().length;
    if (!charRegs[index] || !charRegs[index].test(lastChar))
        e.preventDefault();
});
function initOnAjax() {
    //$('[data-format="iban"]').shieldMaskedTextBox({
    //    enabled: true,
    //    mask: "LL-00-0000-0000-0000-0000-00",
    //    value:'IR'
    //});
    //$('[data-format="iban"]').click(function () {
    //    this.selectionStart = 0;
    //    this.selectionEnd = 0;
    //});
    //$('[data-format="date"]').shieldMaskedTextBox({
    //    enabled: true,
    //    mask: "0000/00/00"
    //});
    //$('[data-format="date"]').click(function () {
    //    this.selectionStart = 0;
    //    this.selectionEnd = 0;
    //});
}