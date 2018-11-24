$("#submitTweet").click(function () {
    $.ajax({
        type: 'POST',
        data: {
            content: $("#newTweet").val()
        },
        url: 'http://localhost:59125/api/twitter',
        beforeSend: function (xhr) {
            var token = sessionStorage.getItem("accessToken");
            xhr.setRequestHeader("Authorization", "Bearer " + token);
        },
        success: function () {
            document.location.href = document.location.href;
        },
        fail: function (data) {
            console.log(data);
        }
    });
});
