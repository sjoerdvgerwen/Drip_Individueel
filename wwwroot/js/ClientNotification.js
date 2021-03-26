"use strict"
var connection = new signalR.HubConnectionBuilder().WithUrl("/currentwaterusagehub").build();
connection.start();
connection.on("ReceiveMessage", function (message) {

    var li = document.createElement("li");
    li.textContent = message;
    document.getElementById("msglist").appendChild(li);
})