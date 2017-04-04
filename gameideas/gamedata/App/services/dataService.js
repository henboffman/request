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

    //#region weapon types

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

    //#endregion

    //#region attack types

    function getAttackTypes() {
        var options = {
            url: "api/attack_type",
            type: "GET"
        }
        return $.ajax(options);
    }

    function createAttackType(attackType) {
        var options = {
            url: "api/attack_type",
            type: "POST",
            data: attackType
        }

        return $.ajax(options);
    }

    //#endregion attack types


    //#region damage types

    function getDamageTypes() {
        var options = {
            url: "api/damage_type",
            type: "GET"
        }
        return $.ajax(options);
    }

    function createDamageType(damageType) {
        var options = {
            url: "api/damage_type",
            type: "POST",
            data: damageType
        }

        return $.ajax(options);
    }

    //#endregion damage types


    //#region monsters

    function getMonsters() {
        var options = {
            url: "api/monsters",
            type: "GET"
        }
        return $.ajax(options);
    }

    function createMonster(monster) {
        var options = {
            url: "api/monsters",
            type: "POST",
            data: monster
        }

        return $.ajax(options);
    }

    //#endregion monsters


    var dataService = {
        createAttackType: createAttackType,
        createDamageType: createDamageType,
        createMonster: createMonster,
        createWeapon:createWeapon,
        createWeaponType: createWeaponType,
        getAttackTypes: getAttackTypes,
        getDamageTypes: getDamageTypes,
        getMonsters:getMonsters,
        getWeapons: getWeapons,
        getWeaponTypes:getWeaponTypes
    };

    return dataService;

})