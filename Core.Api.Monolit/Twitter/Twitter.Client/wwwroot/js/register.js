$('#submitRegister').click(function (e) {
    e.preventDefault();
    var loginData = {
        grant_type: 'password',
        email: $('#Email').val(),
        password: $('#Password').val(),
        confirmPassword: $('#ConfirmPassword').val()
    };
    $.ajax({
        type: 'POST',
        url: 'http://localhost:59125/api/register',
        data: loginData
    }).success(function (data) {
        sessionStorage.setItem("accessToken", data.accessToken);
        console.log(data.accessToken);
        window.location.href = "http://localhost:49720/twitter.html";
    }).fail(function (data) {
        console.log(data);
    });
});