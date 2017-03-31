define([], function () {

    function getWeapons() {
        var options = {
            url: "api/weapons",
            type: "GET"
        }
        return $.ajax(options);
    }

    function createWeapon(weapon) {
        var options = {
            url: "api/weapons",
            type: "POST",
            data: weapon
        }
        return $.ajax(options);
    }


    function getWeaponTypes() {
        var options = {
            url: "api/weapon_types",
            type: "GET"
        }
        return $.ajax(options);
    }

    function createWeaponType(weaponType) {
        var options = {
            url: "api/weapon_types",
            type: "POST",
            data: weaponType
        }

        return $.ajax(options);
    }

    var dataService = {
        createWeapon:createWeapon,
        createWeaponType:createWeaponType,
        getWeapons: getWeapons,
        getWeaponTypes:getWeaponTypes
    };

    return dataService;

})