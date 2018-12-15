let hubUrl = 'https://localhost:44336/Hub';
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl(hubUrl)
    .configureLogging(signalR.LogLevel.Information)
    .build();
let userName = '';

hubConnection.on('Send', function (message, userName) {
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(userName + ': '));

    let elem = document.createElement("p");
    elem.appendChild(userNameElem);
    elem.appendChild(document.createTextNode(message));

    var firstElem = document.getElementById("chatroom").firstChild;
    document.getElementById("chatroom").insertBefore(elem, firstElem);
});

hubConnection.on('Connect', function (userName) {
    let userNameElem = document.createElement("b");
    userNameElem.appendChild(document.createTextNode(userName));

    let elem = document.createElement("p");
    elem.appendChild(userNameElem);

    var firstElem = document.getElementById("players").firstChild;
    document.getElementById("players").insertBefore(elem, firstElem);
});

document.getElementById("loginBtn").addEventListener("click", function (e) {
    userName = document.getElementById("userName").innerText;
    document.getElementById("player").innerHTML = '<h3>' + userName + '</h3>';
    $('#loginBtn').css('display', 'none');
    $('#inputForm').css('display', 'block');
    $('#crocoCanvas').css('display', 'block');
    hubConnection.invoke('Connect', userName);
});

document.getElementById("sendBtn").addEventListener("click", function (e) {
    let message = document.getElementById("message").value;
    hubConnection.invoke('Send', message, userName);
});

hubConnection.start();

var canvas = document.getElementById("crocoCanvas"),
    context = canvas.getContext("2d");

var mouse = { x: 0, y: 0 };
var draw = false;

hubConnection.on("MouseDown", function (x, y) {
    draw = true;
    context.beginPath();
    context.moveTo(x, y);
});
hubConnection.on("MouseMove", function (x, y) {
    context.lineTo(x, y);
    context.stroke();
});
hubConnection.on("MouseUp", function (x, y) {
    context.lineTo(x, y);
    context.stroke();
    context.closePath();
    draw = false;
});

canvas.addEventListener("mousedown", function (e) {
    var rect = canvas.getBoundingClientRect();
    mouse.x = e.pageX - rect.left;
    mouse.y = e.pageY - rect.top;
    draw = true;
    hubConnection.invoke("MouseDown", mouse.x, mouse.y);
});
canvas.addEventListener("mousemove", function (e) {
    if (draw == true) {
        var rect = canvas.getBoundingClientRect();
        mouse.x = e.pageX - rect.left;
        mouse.y = e.pageY - rect.top;
        hubConnection.invoke("MouseMove", mouse.x, mouse.y);
    }
});
canvas.addEventListener("mouseup", function (e) {   
    var rect = canvas.getBoundingClientRect();
    mouse.x = e.pageX - rect.left;
    mouse.y = e.pageY - rect.top;
    draw = false;
    hubConnection.invoke("MouseUp", mouse.x, mouse.y);
});

$(function () {
    var chat = $.connection.chatHub;

//    chat.client.addMessage = function (name, message) {
//        $('#chatroom').append('<p><b>' + htmlEncode(name)
//            + '</b>: ' + htmlEncode(message) + '</p>');
//    };

    chat.client.onConnected = function (id, userName, allUsers) {
//        $('#hdId').val(id);
//        $('#players').html('<h3>' + userName + '</h3>');
        for (i = 0; i < allUsers.length; i++) {
            AddUser(allUsers[i].ConnectionId, allUsers[i].Name);
        }
    };

    chat.client.onNewUserConnected = function (id, name) {
        AddUser(id, name);
    };

//    chat.client.onUserDisconnected = function (id, userName) {
//        $('#' + id).remove();
//    };

//    $.connection.hub.start().done(function () {

//        $('#sendBtn').click(function () {
//            chat.server.send($('#userName').val(), $('#message').val());
//            $('#message').val('');
//        });

//        $("#btnLogin").click(function () {

//            var name = $("#userName").val();
//            if (name.length > 0) {
//                chat.server.connect(name);
//            }
//        });
//    });
});

//function htmlEncode(value) {
//    var encodedValue = $('<div />').text(value).html();
//    return encodedValue;
//}

function AddUser(id, name) {
    //var userId = $('#hdId').val();
    if (userId != id) {
        $("#players").append('<p id="' + id + '"><b>' + name + '</b></p>');
    }
}