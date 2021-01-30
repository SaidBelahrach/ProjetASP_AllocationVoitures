﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace projet_ASP.Models
{
    [Table("proprietaires")]
    public class Proprietaire
    {
      //  [Column("ID")]      //ces 3 sont obligatoire
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)] 
       // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  
        public int idProprietaire { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Nom complet")]
        public string nomComplet { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "téléphone")]
        public string tel { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Adresse")]
        public string adresse { get; set; }

        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        public string email { get; set; }

        public ICollection<Voiture> Voitures { get; set; } //un proprietaire peut avoir plusieurs voitures
    }
}