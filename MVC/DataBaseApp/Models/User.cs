using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DataBaseApp.Models
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Имя не должно быть пустым")]
        [Display(Name="Имя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Возраст не должен быть пустым")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
    }
}
