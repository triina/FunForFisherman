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

        /// <summary>
        /// A list of genders for textbox validation
        /// </summary>
        //public enum Gender
        //{
        //    M, F
        //}

        /// <summary>
        /// A list of genders for drop-down lists
        /// </summary>
        public static List<SelectListItem> GenderSelectList
        {
            get
            {
                List<SelectListItem> genders = new List<SelectListItem>();
                genders.Add(new SelectListItem { Text = "Male", Value = "M" });
                genders.Add(new SelectListItem { Text = "Female", Value = "F" });
                return genders;
            }
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
        //[EnumDataType(typeof(Gender))]
        public string gender { get; set; }

        [Required]
        public string passwordHashFields { get; set; }

        public virtual ICollection<FishingSession> FishingSession { get; set; }
    }
}
