define(['durandal/app', 'services/dataService'], function (app, dataService) {
    
    var initialized = false;
    var weapons = ko.observableArray([]);

    function getWeapons() {
        return dataService.getWeapons().then(function (returnedWeapons) {
            console.log(returnedWeapons);
            weapons(returnedWeapons);
        });
    }

    function activate() {
        if (initialized) return initialized;
        getWeapons();
        initialized = true;
        return initialized;
    }

    var home = {
        activate: activate,
        getWeapons: getWeapons
    };

    return home;

});