$(function () {
    class Message {
        constructor(name, text, sendtime) {
            this.SenderName = name;
            this.Text = text;
            this.SendTime = sendtime;
        }
    }

    //jquery variables
    const textInput = $('#messageInput');
    const chat = $('#chat');
    const sendMessageBtn = $('#sendMessageBtn');
    const username = $('#username');
    const messagesQueue = [];

    var chatHub = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

    sendMessageBtn.attr('disabled', 'disabled');

    chatHub.start().then(function () {
        sendMessageBtn.removeAttr('disabled');
    }).catch(function (err) {
        return console.log(err.toString());
    });

    //when message is received then add message to chat
    chatHub.on('ReceiveMessage', function (message) {
        addMessageToChat(message);
    });

    //Send message
    $('#messageInput').on('keydown', (e) => {
        if (e.code === 'Enter') {
            sendMessage();
        }
    });

    sendMessageBtn.on('click', () => {
        sendMessage();
    });

    function sendMessage() {
        messagesQueue.push(textInput.val());
        let text = messagesQueue.shift() || "";
        if (text.trim() === "") return;

        if (username.val().trim() === "") {
            $('#usernameStatus').addClass("text-danger");
            return;
        } else {
            $('#usernameStatus').removeClass("text-danger");
        }
        var currentDate = new Date();

        var options = {
            year: 'numeric',
            month: 'long',
            day: 'numeric',
            hour: '2-digit',
            minute: '2-digit',
            second: '2-digit',
        };

        var formattedDate = currentDate.toLocaleString('en-US', options);
        let msg = new Message(username.val(), textInput.val(), formattedDate);
        textInput.val("");

        chatHub.invoke('SendMessage', msg);
    }

    function addMessageToChat(message) {
        if (message != null) {
            var messageTemplate = 
                `<div class="chat-message-left pb-4">
                    <div class="flex-shrink-1 bg-light rounded py-2 px-3 mr-3">
                        <div class="font-weight-bold mb-1">
                            <div class="text-muted small" style="display:inline;">(${message.sendTime})</div>
                            <span class="bold">${message.senderName}</span>: ${message.text}
                        </div>
                    </div>
                </div>`;

            chat.prepend(messageTemplate);
        }
    }
});