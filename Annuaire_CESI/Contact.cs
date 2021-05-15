using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Annuaire_CESI
{
    [Table("Contact", Schema = "public")]
    public class Contact
    {
        [Key] // PRIMARY KEY
        public int ContactID { get; set; }
        [Required] //NOT NULL
        public string Nom { get; set; }
        [Required] //NOT NULL
        public string Prenom { get; set; }
        public string Telephone { get; set; }
        public string Service { get; set; }
        public DateTime DateEntree { get; set; }

        public Contact() { }
        public Contact(string nom, string prenom, string telephone, string service, DateTime dateEntree)
        {
            Nom = nom;
            Prenom = prenom;
            Telephone = telephone;
            Service = service;
            DateEntree = dateEntree;
        }


    }
}
