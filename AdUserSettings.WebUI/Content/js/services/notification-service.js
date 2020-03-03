class notificationService {

    //#TODO
    toastNotificationsExampleWithParameter(message, type) {
        var $showToast;
        var options = {},
            messages = message;

        $(':input').each(function (index) {
            var input = $(this),
                key = input.attr('id'),
                val = input.val();

            if (input.is("input[type='checkbox']")) val = input.prop('checked');

            if (key && val) options[key] = val;
        });

        var title = options.title || '',
            _message = messages;

        toastr[type](_message, title, options);
        //});
        return null;
    }
} 