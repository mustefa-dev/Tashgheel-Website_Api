let connection = new signalR.HubConnectionBuilder()
    .withUrl("http://localhost:5000/users")
    .build();

connection.on("event", function(event) {
    console.log(" updated: ", event);
    let userList = document.getElementById("userList");

    // Assuming event.data is the user data object
    let userData = event.data;
    for (let key in userData) {
        let row = userList.insertRow(-1);
        let eventCell = row.insertCell(0);
        eventCell.textContent = event.event;
        let userCell = row.insertCell(1);
        userCell.textContent = key + ": " + userData[key];
    }
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});