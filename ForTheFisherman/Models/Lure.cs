//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ForTheFisherman.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    
    public partial class Lure
    {
        public Lure()
        {
            this.Catch = new HashSet<Catch>();
        }
    
        public int lId { get; set; }
        
        [Required(ErrorMessage = "Lure name is necessary")]
        [DisplayName("Lure")]
        [StringLength(100)]
        [Remote("CheckLureName", "Validation", AdditionalFields = "lId", ErrorMessage = "This lure name is already taken.")]
        public string name { get; set; }
        
        [DisplayName("Lure description")]
        [StringLength(200)]
        public string description { get; set; }

        [DisplayName("Lure type")]
        public int ltId { get; set; }
    
        public virtual ICollection<Catch> Catch { get; set; }
        public virtual LureType LureType { get; set; }
    }
}
