define([], function () {

    function getWeapons() {
        var options = {
            url: "api/weapons",
            type: 'GET'
        }
        return $.ajax(options);
    }

    var dataService = {
        getWeapons:getWeapons
    };

    return dataService;

})