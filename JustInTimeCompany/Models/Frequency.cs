using System.ComponentModel.DataAnnotations;

namespace JustInTimeCompany.Models
{
    public enum Frequency
    {
        [Display(Name ="Vol unique")]
        Once,
        [Display(Name = "Chaque jour")]
        Daily,
        [Display(Name = "Chaque semaine")]
        Weekly, 
        [Display(Name = "Chaque mois")]
        Monthly
    }
}
