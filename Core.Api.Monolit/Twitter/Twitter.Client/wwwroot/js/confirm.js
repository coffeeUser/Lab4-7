$.ajaxSetup({
    success: function (xhr, status, err) {
        if (xhr.status == 200) {
            $('#success').text(xhr.responseText);
            $('#success').css('display', 'block');
        }
    },
    error: function (xhr, status, err) {
        if (xhr.status == 400) {
            $('#danger').text(xhr.responseText);
            $('#danger').css('display', 'block');
        }            
    }
})