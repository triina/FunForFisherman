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
    
    public partial class Catch
    {
        public Catch()
        {
            this.FishingSession = new HashSet<FishingSession>();
        }
    
        public int cId { get; set; }
        public decimal weight { get; set; }
        public int lureweight { get; set; }
        public int depth { get; set; }
        public string description { get; set; }
        public int lId { get; set; }
        public int fiId { get; set; }
    
        public virtual FishSpecies FishSpecies { get; set; }
        public virtual Lure Lure { get; set; }
        public virtual ICollection<FishingSession> FishingSession { get; set; }
    }
}