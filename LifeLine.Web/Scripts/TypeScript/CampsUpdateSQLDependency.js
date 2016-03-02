/// <reference path="../typings/jquery/jquery.d.ts" />
$(function () {
    // Declare a proxy to reference the hub.
    var notifications = $.connection.messagesHub;
    //debugger;
    // Create a function that the hub can call to broadcast messages.
    notifications.client.updateMessages = function () {
        getAllMessages();
    };
    // Start the connection.
    $.connection.hub.start().done(function () {
        alert("connection started");
        getAllMessages();
    }).fail(function (e) {
        alert(e);
    });
});
function getAllMessages() {
    var tbl = $('#messagesTable');
    $.ajax({
        url: '/Camp/GetMessages',
        contentType: 'application/html ; charset:utf-8',
        type: 'GET',
        dataType: 'html',
        success: function (c) {
            tbl.empty().append(c);
        }
    });
}
//# sourceMappingURL=CampsUpdateSQLDependency.js.map