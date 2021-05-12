using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Annuaire_CESI
{
    [Table("Contact", Schema = "public")]
    class Contact
    {
        [Key] // PRIMARY KEY
        public int ClientID { get; set; }
        [Required] //NOT NULL
        public string Nom { get; set; }
        [Required] //NOT NULL
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Service { get; set; }
        public DateTime DateEntree { get; set; }

      
    }
}
