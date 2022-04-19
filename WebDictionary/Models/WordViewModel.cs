using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebDictionary.Models
{
    public class WordViewModel
    {
         public int Id { get; set; }
        [Required( ErrorMessage="Kelime giriniz")]
        [Display(Name ="Kelime")]
        public string Words { get; set; }
        [Required(ErrorMessage = "Tanım giriniz")]
        [Display(Name = "Tanımı")]
      //  [StringLength(5,MinimumLength =5,ErrorMessage ="telefon 10 haneli olmalıdır")]
       // [MyFirstVal]
        public string Description { get; set; }
    }
}
