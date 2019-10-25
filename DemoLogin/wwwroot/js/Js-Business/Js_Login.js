function Login() {
    if ($('#UserName').val() == '') {
        $.notify(
            {
                icon: 'glyphicon glyphicon-star',
                message: "Tên đăng nhập không được bỏ trống!"
            }, {
            type: 'danger'
        });
    }
    else {
        $.ajax(
            {
                type: "POST",
                url: '@Url.Action("Validate", "Login")',
                data: {
                    UserName: $('#UserName').val(),
                    Password: $('#Password').val()
                },
                error: function (result) {
                    $.notify(
                        {
                            icon: 'glyphicon glyphicon-star',
                            message: result.message
                        }, {
                        type: 'danger'
                    });
                },
                success: function (result) {
                    //console.log(result);
                    if (result.status == true) {
                        $.notify(
                            {
                                icon: 'glyphicon glyphicon-star',
                                message: result.message
                            }, {
                            type: 'success'
                        });
                        window.location.href = '@Url.Action("Index", "Home")';
                    }
                    else {
                        $.notify(
                            {
                                icon: 'glyphicon glyphicon-star',
                                message: result.message
                            }, {
                            type: 'danger'
                        });
                    }
                }
            });
    }
}
var username = document.getElementById("UserName");
username.addEventListener("keyup", function (event) {
    if (event.keyCode === 13) {
        event.preventDefault();
        document.getElementById("btnLogin").click();
    }
});
var password = document.getElementById("Password");
password.addEventListener("keyup", function (event) {
    if (event.keyCode == 13) {
        event.preventDefault();
        document.getElementById('btnLogin').click();
    }
});