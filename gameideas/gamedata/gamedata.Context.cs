﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gamedata
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class requestEntities : DbContext
    {
        public requestEntities()
            : base("name=requestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<weapon_types> weapon_types { get; set; }
        public virtual DbSet<weapon> weapons { get; set; }
        public virtual DbSet<attack_type> attack_type { get; set; }
        public virtual DbSet<damage_type> damage_type { get; set; }
        public virtual DbSet<monster> monsters { get; set; }
        public virtual DbSet<item_rarity> item_rarity { get; set; }
    }
}
