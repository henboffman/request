//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class damage_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public damage_type()
        {
            this.monsters = new HashSet<monster>();
        }
    
        public int id { get; set; }
        public string Name { get; set; }
        public int Attack_Type_Id { get; set; }
    
        public virtual attack_type attack_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<monster> monsters { get; set; }
    }
}
