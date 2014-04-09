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

    public partial class Fisherman
    {
        public Fisherman()
        {
            this.FishingSession = new HashSet<FishingSession>();
        }

        public enum Gender
        {
            M, F
        }

        [DisplayName("Id")]
        public int fId { get; set; }

        [DisplayName("Fist Name")]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        public string lastName { get; set; }

        [DisplayName("Phone Number")]
        public string phone { get; set; }

        [DisplayName("E-mail")]
        public string eMail { get; set; }

        [DisplayName("Gender")]
        [EnumDataType(typeof(Gender))]
        public string genre { get; set; } // genre?! // testwtf

        public string passwordHashFields { get; set; }

        public virtual ICollection<FishingSession> FishingSession { get; set; }
    }
}
