using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WomenEmpowermentAPI.models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
       
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Username required")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Password required")]
        [MaxLength(10,ErrorMessage ="Maximum allowable length 10")]
        [MinLength(4,ErrorMessage ="Minimum length required is 4")]
        public string Password { get; set; }
    }
}
