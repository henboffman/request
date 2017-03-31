define(['durandal/app', 'services/dataService'], function (app, dataService) {
    
    var initialized = false;
    var newWeapon = ko.observable();
    var newWeaponType = ko.observable();
    var weapons = ko.observableArray([]);
    var weaponTypes = ko.observableArray([]);

    var WeaponType = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
        self.Description = "";
        self.Hands_Required = 1;
    }

    var Weapon = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
        self.TypeId = 0;
        self.Max_Durability = 0;
        self.Min_Durability = 0;
        self.Max_Damage = 0;
        self.Min_Damage = 0;
        self.Max_Value = 0;
        self.Min_Value = 0;
        self.Weight = 0;
        self.Speed = 0;
    }

    //#region Weapons

    function getWeapons() {
        return dataService.getWeapons().then(function (returnedWeapons) {
            console.log(returnedWeapons);
            weapons(returnedWeapons);
        });
    }

    function validateWeaponInputs() {
        var isValid = true;
        if (newWeapon().Name == "") {
            alert("Weapon Name must be provided!");
            isValid = false;
        }
        if (parseInt(newWeapon().Max_Damage) <= parseInt(newWeapon().Min_Damage)) {
            alert("Maximum damage (" + newWeapon().Max_Damage + ") must be greater than minimum damage (" + newWeapon().Min_Damage + ")");
            isValid = false;
        }
        if (parseInt(newWeapon().Max_Durability) <= parseInt(newWeapon().Min_Durability)) {
            alert("Maximum durability (" + newWeapon().Max_Durability + ") must be greater than minimum durability (" + newWeapon().Min_Durability + ")");
            isValid = false;
        }
        if (parseInt(newWeapon().Max_Value) <= parseInt(newWeapon().Min_Value)) {
            alert("Maximum value must be greater than minimum value");
            isValid = false;
        }
        return isValid;
    }

    function convertInputs() {
        console.info("Converting Values");
        for (var property in newWeapon()) {
            //don't attempt to convert name to an integer
            if (property != "Name") {
                newWeapon()[property] = parseInt(newWeapon()[property]);
            }
        }
    }

    function saveWeapon() {
        if (validateWeaponInputs()) {
            convertInputs();
            console.log(newWeapon());
            return dataService.createWeapon(newWeapon()).then(function (savedWeapon) {
                console.log(savedWeapon);
                weapons.push(savedWeapon);
                $('#weaponModal').modal('hide');
                newWeapon(new Weapon());                
            });
            
        }        
    }

    //#endregion

    //#region Weapon Types

    function getWeaponTypes(){
        return dataService.getWeaponTypes().then(function (returnedWeaponTypes) {
            console.log(returnedWeaponTypes);
            weaponTypes(returnedWeaponTypes);
        });
    }
    
    function validateWeaponType() {
        var isValid = true;
        if (newWeaponType().Name == "") {
            alert("Weapon name is required");
            isValid = false;
        }
        if (newWeaponType().Description == "") {
            alert("Weapon type is required");
            isValid = false;
        }
        return isValid;
    }

    function saveWeaponType() {
        console.log(newWeaponType());
        if (validateWeaponType()) {
            return dataService.createWeaponType(newWeaponType()).then(function (savedWeaponType) {
                console.log(savedWeaponType);
                weaponTypes.push(savedWeaponType);
                $('#weaponTypeModal').modal('hide');
                newWeaponType(new WeaponType());
            });
        }
        
    }


    //#endregion

    function activate() {
        if (initialized) return initialized;

        //initialize arrays
        getWeapons();
        getWeaponTypes();
        //initialize new Items
        newWeapon(new Weapon());
        newWeaponType(new WeaponType());

        initialized = true;
        return initialized;
    }

    var home = {
        activate: activate,
        getWeapons: getWeapons,
        newWeapon: newWeapon,
        newWeaponType:newWeaponType,
        saveWeapon: saveWeapon,
        saveWeaponType:saveWeaponType,
        weapons: weapons,
        weaponTypes:weaponTypes
    };

    return home;

});