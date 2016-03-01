$(function () {
    $.connection.hub.logging = true;
    var myhub = $.connection.siteActivityHub;

    //Function to load upcoming donation camps

    myhub.client.loadCampDetails = function (count) {
        if (document.getElementById('campCount') != null)
            var pcount = document.getElementById('campCount').innerHTML;

        //Append camps count to the home page
        $('#campCount').text(count);

    };

    $.connection.hub.start().done(function () {
    });

});
