var contact = {
    init: function () {
        contact.regEvent();
    },
    regEvent: function () {
        $('#btnSend').off('click').on('click', function () {
            var name = $('#name').val();
            var phone = $('#phone').val();
            var email = $('#email').val();
            var content = $('#content').val();
            var address = $('#address').val();

            $.ajax({
                url: '/Contact/Send',
                type: 'POST',
                dataType: 'json',
                data: {
                    name: name,
                    phone: phone,
                    email: email,
                    content: content,
                    address: address
                },
                success: function (res) {
                    if (res.status == true) {
                        window.alert("Gửi phản hồi thành công");
                        contact.resetForm();
                    }
                }
            })
        })
    },
    resetForm: function () {
        $('#name').val('');
        $('#phone').val('');
        $('#email').val('');
        $('#content').val('');
        $('#address').val('');
    }
}
contact.init();