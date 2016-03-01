/// <reference path="../typings/jquery/jquery.d.ts" />
//$(() => {
//    // Declare a proxy to reference the hub.
//    var notifications = $.connection.messagesHub;
//    //debugger;
//    // Create a function that the hub can call to broadcast messages.
//    notifications.client.updateMessages = () => {
//        getAllMessages();
//    };
//    // Start the connection.
//    $.connection.hub.start().done(() => {
//        // alert("connection started")
//        getAllMessages();
//    }).fail(e => {
//        alert(e);
//    });
//});
//function getAllMessages() {
//    var tbl = $('#messagesTable');
//    $.ajax({
//        url: '/Camp/GetMessages',
//        contentType: 'application/html ; charset:utf-8',
//        type: 'GET',
//        dataType: 'html'
//    })
//    .success(function (result) {
//        tbl.empty().append(result);
//    })
//    .error(() => {});
//} 
//# sourceMappingURL=CampsUpdateSQLDependency.js.map