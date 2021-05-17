using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Requetes
{
    class Modifier : Requete
    {
        private TypeRequete _typeRequete;
        private List<Contact> _resultatGet;
       
        /// <summary>
        /// Ici, contact a modifier est la nouvelle instance du contact, et IdModif sert a cibler le contact existant
        /// </summary>
        /// <param name="ContactAModifier"></param>
        /// <param name="IdModif"></param>
        public Modifier(Contact ContactAModifier, int IdModif)
        {
            _typeRequete = TypeRequete.Get;
            using (ContexteSQL db = new ContexteSQL())
            {
                var aModifier = db.Contact.Where(x => x.ContactID == IdModif).Single();

                aModifier.Nom = ContactAModifier.Nom;
                aModifier.Prenom = ContactAModifier.Prenom;
                aModifier.Telephone = ContactAModifier.Telephone;
                aModifier.Service = ContactAModifier.Service;
                aModifier.DateEntree = ContactAModifier.DateEntree;
                


                //Sauvegarde la database, sinon appelle TraceErreur si il y a une erreur (sauvegarde du message d'erreur)
                string retour = db.Validation();
                if (retour == string.Empty)
                    db.SaveChanges();
                else
                    TraceErreur.Log(retour);



                _resultatGet = db.Contact.ToList<Contact>();

            }
        }

        public override TypeRequete TypeRequete
        {
            get { return _typeRequete; }
        }

        public override List<Contact> ResultatGet
        {
            get { return _resultatGet; }
        }

    }
}
