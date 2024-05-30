let user = JSON.parse(localStorage.getItem('user'));
let fromUser = user.fullName;

let connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/chatHub") // Update this with the correct URL of your SignalR hub
    .build();

connection.on("ReceiveMessage", function(fromUser, message) {
    console.log("Received message: ", fromUser, message);
    let messages = document.getElementById("messages");
    let messageItem = document.createElement("div");
    messageItem.textContent = fromUser + ": " + message;
    messages.appendChild(messageItem);
    console.log("Appended message: ", messageItem.textContent);
    scrollToBottom(messages);
});

connection.on("UserJoined", function(username) {
    console.log(username + " joined the chat");
    let messages = document.getElementById("messages");
    let messageItem = document.createElement("div");
    messageItem.textContent = username + " joined the chat";
    messages.appendChild(messageItem);
    scrollToBottom(messages);
});

connection.on("UserLeft", function(username) {
    console.log(username + " left the chat");
    let messages = document.getElementById("messages");
    let messageItem = document.createElement("div");
    messageItem.textContent = username + " left the chat";
    messages.appendChild(messageItem);
    scrollToBottom(messages);
});

connection.start().then(function () {
    connection.invoke("UserJoined", fromUser).catch(function (err) {
        return console.error(err.toString());
    });
    connection.invoke("GetOldMessages").catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("messageForm").addEventListener("submit", function (event) {
    event.preventDefault();
    let messageInput = document.getElementById("messageInput");
    let message = messageInput.value;
    connection.invoke("SendMessage", fromUser, message).catch(function (err) {
        return console.error(err.toString());
    });
    messageInput.value = '';
});

connection.onclose(async () => {
    await connection.invoke("UserLeft", fromUser).catch(function (err) {
        return console.error(err.toString());
    });
    await startSignalRConnection(connection);
});

function displayError(message) {
    let messages = document.getElementById("messages");
    let messageItem = document.createElement("div");
    messageItem.textContent = "Error: " + message;
    messageItem.style.color = "red";
    messages.appendChild(messageItem);
    scrollToBottom(messages);
}

async function startSignalRConnection(connection) {
    try {
        await connection.start();
        console.log('connected');

        connection.invoke("GetOldMessages")
            .then(function (oldMessages) {
                console.log("Received old messages: ", oldMessages);
                for (let i = 0; i < oldMessages.length; i++) {
                    let message = oldMessages[i];
                    let messages = document.getElementById("messages");
                    let messageItem = document.createElement("div");
                    messageItem.textContent = message.fromUser + ": " + message.message;
                    messageItem.className = message.fromUser === user.fullName ? 'user-message' : 'other-message';
                    messages.appendChild(messageItem);
                    scrollToBottom(messages);
                }
            })
            .catch(function (err) {
                console.error('Error while getting old messages: ' + err);
                displayError('Error while getting old messages: ' + err);
            });
    } catch (err) {
        console.log('Error while establishing connection: ' + err);
        displayError('Error while establishing connection: ' + err);
        setTimeout(() => startSignalRConnection(connection), 5000);
    }
}

function scrollToBottom(messages) {
    messages.scrollTop = messages.scrollHeight;
}