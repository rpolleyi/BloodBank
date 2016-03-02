$(function () {
    var myhub = $.connection.siteActivityHub;
    //Function to load upcoming donation camps
    myhub.client.loadCampDetails = function (count) {
        if (document.getElementById('campCount') != null)
            var pcount = document.getElementById('campCount').innerHTML;
        //Append camps count to the home page
        $('#campCount').text(count);
    };
    //Function to load donor count
    myhub.client.loadDonorStatNumber = function (count) {
        if (document.getElementById('donorCount') != null)
            var pcount = document.getElementById('donorCount').innerHTML;
        //Append camps count to the home page
        $('#donorCount').text(count);
    };
    $.connection.hub.start().done(function () {
    });
});
//# sourceMappingURL=SiteActivity.js.map