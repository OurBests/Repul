ko.bindingHandlers.modal = {
    init: function (element, valueAccessor) {
        $(element).modal({
            show: false
        });

        var value = valueAccessor();
        if (ko.isObservable(value)) {
            // Update 28/02/2018
            // Thank @HeyJude for fixing a bug on
            // double "hide.bs.modal" event firing.
            // Use "hidden.bs.modal" event to avoid
            // bootstrap running internal modal.hide() twice.
            $(element).on('hidden.bs.modal', function () {
                value(false);
            });
        }

        // Update 13/07/2016
        // based on @Richard's finding,
        // don't need to destroy modal explicitly in latest bootstrap.
        // modal('destroy') doesn't exist in latest bootstrap.
        // ko.utils.domNodeDisposal.addDisposeCallback(element, function () {
        //    $(element).modal("destroy");
        // });

    },
    update: function (element, valueAccessor) {
        var value = valueAccessor();
        if (ko.utils.unwrapObservable(value)) {
            $(element).modal('show');
        } else {
            $(element).modal('hide');
        }
    }
}
ko.bindingHandlers.currencyFormat = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {

        ko.utils.registerEventHandler(element, 'keyup', function (event) {
            var observable = valueAccessor();
            observable(formatInput(element.value));
            observable.notifySubscribers(5);
        });

    },
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        $(element).val(value);
    }
};

ko.bindingHandlers.anmiateVisible = {
    init: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        var $element = $(element);

        if (value)
            $element.show();
        else
            $element.hide();
    },
    update: function (element, valueAccessor, allBindingsAccessor, viewModel, bindingContext) {
        var value = ko.utils.unwrapObservable(valueAccessor());

        var $element = $(element);


        var allBindings = allBindingsAccessor();

        // Grab data from binding property
        var duration = allBindings.duration || 500;
        var isCurrentlyVisible = !(element.style.display == "none");

        if (value && !isCurrentlyVisible)
            $element.show(duration);
        else if ((!value) && isCurrentlyVisible)
            $element.hide(duration);
    }
};

function formatInput(value) {

    value += '';

    value = value.replace(/,/g, '');
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(value)) {
        value = value.replace(rgx, '$1' + ',' + '$2');
    }

    return value;
}
