$(document).ready(function () {
    $("#btnLogin").click(function () {
        $.ajax({
            type: "POST",
            url: "/Login/DangNhap",
            data: {
                UserName: $('#UserName').val(),
                Password: $('#Password').val()
            },
            error: function (result) {
                alert("Đăng nhập thất bại");
            },
            success: function (result) {
                window.location.href = "Home";
            }
        });
    });
});