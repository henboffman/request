using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gamedata.Models.Instance
{
    public class WeaponInstance
    {
        public string Name;
        public int weapon_type_id;
        public string Weapon_Type;
        public int Speed;
        public int Weight;
        public int Durability;
        public int min_damage;
        public int max_damage;
        public int min_value;
        public int max_value;

        public WeaponInstance() { }

        public WeaponInstance(weapon weapon)
        {
            Name = weapon.Name;
            weapon_type_id = weapon.TypeId;
            Weapon_Type = weapon.weapon_types.Name;
            Speed = weapon.Speed;
            Weight = weapon.Weight;
            Durability = 100;
            min_damage = weapon.Min_Damage;
            max_damage = weapon.Max_Damage;
            min_value = weapon.Min_Value;
            max_value = weapon.Max_Value;
        }


    }
}