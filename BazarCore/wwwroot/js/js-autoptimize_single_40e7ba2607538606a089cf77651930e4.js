//(function ($) {
//    "use strict"; $(document).ready(function () {
//        $('#signupform').submit(function (e) {
//            var submit = true; $('#signupform .required').each(function (event) {
//                if ($(this).val() == '') {
//                    var msg = $(this).data('msg'); if (msg) { alert(msg); }
//                    submit = false; return false;
//                }
//            }); if ($('#signupform input[name="password"]').length) {
//                var password_val = $('#signupform input[name="password"]').val(); if (password_val.length < 9) {
//                    var pass_error = $('#signupform input[name="password"]').data('error'); if (pass_error) { alert(pass_error); }
//                    return false;
//                }
//            }
//            if ($('#signupform .register_term:checkbox').hasClass('required')) {
//                if ($('#signupform .register_term:checkbox:checked').length <= 0 && submit == true) {
//                    var msg_checkbox = $('#signupform .register_term:checkbox').data('msg'); if (msg_checkbox) { alert(msg_checkbox); }
//                    submit = false; return false;
//                }
//            }
//            if (submit == true) {
//                return true;
//            }

//        });
//    });
//})(jQuery);