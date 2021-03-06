﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projet_ASP.Models
{
    public class Reclamation
    {
        [Key]
        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID Reclamation")]
        public int idReclamation { get; set; }


        [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Createur")]
        public Boolean Createur { get; set; } //true : proprie  ,false:locataire


        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Reclamation), ErrorMessageResourceName = "reqDescription")]
        [Display(Name = "description", ResourceType = typeof(projet_ASP.Resources.Models.Reclamation))]
        public string description { get; set; }


        [Required(ErrorMessageResourceType = typeof(projet_ASP.Resources.Models.Reclamation), ErrorMessageResourceName = "reqdateCreation")]
        [Display(Name = "dateCreation", ResourceType = typeof(projet_ASP.Resources.Models.Reclamation))]
        public string dateCreation { get; set; }

        // [Required(ErrorMessage = "Ce champs est obligatoire", AllowEmptyStrings = false)]
        [Display(Name = "Reclamation Validé")]
        public Boolean valide { get; set; } //true : proprie  ,false:locataire

        public int idProprietaire { get; set; }
        [ForeignKey("idProprietaire")]
        public virtual Proprietaire proprietaire { get; set; }

        public int idLocataire { get; set; }
        [ForeignKey("idLocataire")]
        public virtual Locataire Locataire { get; set; }

    }
}