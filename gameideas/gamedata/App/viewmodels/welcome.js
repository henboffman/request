define(['durandal/app', 'services/dataService'], function (app, dataService) {
    
    var initialized = false;
    var attackTypes = ko.observableArray();
    var newAttackType = ko.observable();
    var createNewAttackType = ko.observable(false);

    var damageTypes = ko.observableArray();
    var newDamageType = ko.observable();
    var createNewDamageType = ko.observable(false);

    var newWeapon = ko.observable();    
    var weapons = ko.observableArray([]);    
    var createNewWeapon = ko.observable(false);
    var testWeapons = ko.observableArray([]);
    

    var newWeaponType = ko.observable();
    var weaponTypes = ko.observableArray([]);
    var createNewWeaponType = ko.observable(false);

    var monsters = ko.observableArray([]);
    var newMonster = ko.observable();
    var createNewMonster = ko.observable(false);

    var AttackType = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
    };

    var DamageType = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
        self.Attack_Type_Id = 0;
    };

    var Monster = function () {
        var self = this;
        self.id = 0;
        self.Name = "";
        //self.Sprite = "";
        self.damage_type_id=null;
        self.level=null;
        self.experience=null;
        self.difficulty=null;
        self.health_min=null;
        self.health_max=null;
        self.resistance_ice=null;
        self.resistance_fire=null;
        self.resistance_electric=null;
        self.resistance_poison=null;
        self.resistance_melee=null;
        self.resistance_projectile=null;
    };

    var WeaponType = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
        self.Description = "";
        self.Hands_Required = 1;
    };

    var Weapon = function () {
        var self = this;
        self.Name = "";
        self.id = 0;
        self.TypeId = 0;
        //self.Max_Durability = 0;
        //self.Min_Durability = 0;
        self.Max_Damage = 0;
        self.Min_Damage = 0;
        self.Max_Value = 0;
        self.Min_Value = 0;
        self.Weight = 0;
        self.Speed = 0;
        self.item_rarity_id = 0;
    };

    //#region Weapons

    function toggleCreateWeapon() {
        createNewWeapon(!createNewWeapon());
        //reset the weapon fields if discarded
        if (!createNewWeapon()){
            newWeapon(new Weapon());
        }
    }

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
        //if (parseInt(newWeapon().Max_Durability) <= parseInt(newWeapon().Min_Durability)) {
        //    alert("Maximum durability (" + newWeapon().Max_Durability + ") must be greater than minimum durability (" + newWeapon().Min_Durability + ")");
        //    isValid = false;
        //}
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

    //#region test methods - weapon

    function spawnWeapon() {
        return dataService.spawnWeapon().then(function (returnedWeapon) {
            console.log(returnedWeapon);
            testWeapons.push(returnedWeapon);
        })

    }


    //#endregion

    //#endregion

    //#region Weapon Types

    function toggleCreateWeaponType(){
        createNewWeaponType(!createNewWeaponType());
        if (!createNewWeaponType()) {
            newWeaponType(new WeaponType());
        }
    }

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

    //#region attack types

    function toggleCreateAttackType() {
        createNewAttackType(!createNewAttackType());
        if (!createNewAttackType()) {
            newAttackType(new AttackType());
        }
    }

    function getAttackTypes() {
        return dataService.getAttackTypes().then(function (returnedAttackTypes) {
            console.log(returnedAttackTypes);
            attackTypes(returnedAttackTypes);
        });
    }

    function saveAttackType() {
        console.log(newAttackType());
        if (newAttackType().Name != "") {
            return dataService.createAttackType(newAttackType()).then(function (savedAttackType) {
                attackTypes.push(savedAttackType);
                $('#attackTypeModal').modal('hide');
                newAttackType(new AttackType());
            })
        }
    }

    //#endregion

    //#region damage types

    function toggleCreateDamageType() {
        createNewDamageType(!createNewDamageType());
        if (!createNewDamageType()) {
            newDamageType(new DamageType());
        }
    }


    function getDamageTypes() {
        return dataService.getDamageTypes().then(function (returnedDamageTypes) {
            console.log(returnedDamageTypes);
            damageTypes(returnedDamageTypes);
        });
    }

    function saveDamageType() {
        console.log(newDamageType());
        if (newDamageType().Name != "") {
            return dataService.createDamageType(newDamageType()).then(function (savedDamageType) {
                damageTypes.push(savedDamageType);
                $('#damageTypeModal').modal('hide');
                newDamageType(new DamageType());
            })
        }
    }

    //#endregion



    //#region monsters

    function toggleCreateMonster() {
        createNewMonster(!createNewMonster());
        if (!createNewMonster()) {
            newMonster(new Monster());
        }
    }

    function getMonsters() {
        return dataService.getMonsters().then(function (returnedMonsters) {
            console.log(returnedMonsters);
            monsters(returnedMonsters);
        });
    }

    function saveMonster() {
        console.log(newMonster());
        var isValid = true;
        for (var property in newMonster()) {            
            if (newMonster()[property] == null) {
                isValid = false;
                console.error("Monster is not valid: not all fields populated");
            }
        }
        if (newMonster().Name != "" && isValid) {
            return dataService.createMonster(newMonster()).then(function (savedMonster) {
                monsters.push(savedMonster);
                $('#monsterModal').modal('hide');
                newMonster(new Monster());
            })
        }
    }

    //#endregion


    function activate() {
        if (initialized) return initialized;

        //initialize arrays
        getAttackTypes();
        getDamageTypes();
        getMonsters();
        getWeapons();
        getWeaponTypes();

        //initialize new Items
        newAttackType(new AttackType());
        newDamageType(new DamageType());
        newMonster(new Monster());
        newWeapon(new Weapon());
        newWeaponType(new WeaponType());

        initialized = true;
        return initialized;
    }

    var home = {
        activate: activate,
        attackTypes: attackTypes,
        createNewAttackType:createNewAttackType,
        createNewDamageType: createNewDamageType,
        createNewMonster:createNewMonster,
        createNewWeapon: createNewWeapon,
        createNewWeaponType :createNewWeaponType ,
        damageTypes: damageTypes,        
        getWeapons: getWeapons,
        monsters:monsters,
        newAttackType: newAttackType,
        newDamageType: newDamageType,
        newMonster:newMonster,
        newWeapon: newWeapon,
        newWeaponType: newWeaponType,
        spawnWeapon:spawnWeapon,
        saveAttackType: saveAttackType,
        saveDamageType: saveDamageType,
        saveMonster:saveMonster,
        saveWeapon: saveWeapon,
        saveWeaponType: saveWeaponType,
        testWeapons: testWeapons,
        toggleCreateAttackType:toggleCreateAttackType,
        toggleCreateDamageType: toggleCreateDamageType,
        toggleCreateMonster: toggleCreateMonster,
        toggleCreateWeapon: toggleCreateWeapon,
        toggleCreateWeaponType:toggleCreateWeaponType,
        weapons: weapons,
        weaponTypes:weaponTypes
    };

    return home;

});