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

        ///// <summary>
        ///// A list of genders for textbox validation
        ///// </summary>
        //public enum Gender
        //{
        //    M, F
        //}

        ///// <summary>
        ///// A list of genders for drop-down lists
        ///// </summary>
        //public static List<SelectListItem> GenderSelectList
        //{
        //    get
        //    {
        //        List<SelectListItem> genders = new List<SelectListItem>();
        //        genders.Add(new SelectListItem { Text = "Male", Value = "M" });
        //        genders.Add(new SelectListItem { Text = "Female", Value = "F" });
        //        return genders;
        //    }
        //}

        [DisplayName("Id")]
        public int fId { get; set; }

        [DisplayName("First Name")]
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(100)]
        public string firstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(100)]
        public string lastName { get; set; }

        [DisplayName("Phone Number")]
        [Required(ErrorMessage = "Please enter your phone number.")]
        [StringLength(100)]
        public string phone { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Please enter your email address.")]
        [StringLength(100)]
        [DataType(DataType.EmailAddress)]
        [Remote("CheckEmail", "Validation", AdditionalFields = "fId", ErrorMessage = "This email address is already taken.")]
        public string eMail { get; set; }

        [DisplayName("Gender")]
        [Required(ErrorMessage = "You do have a gender, don't you?")]
        //[EnumDataType(typeof(Gender))]
        public string gender { get; set; }

        // passwordHashFields is required, but we'll just hide it for now
        private string _passwordHashFields;

        [DisplayName("Password")]
        public string passwordHashFields
        {
            get
            {
                return _passwordHashFields;
            }
            set
            {
                if (value != null && value != "") _passwordHashFields = value;
                else _passwordHashFields = "N/A";
            }
        }

        public virtual ICollection<FishingSession> FishingSession { get; set; }
    }
}
