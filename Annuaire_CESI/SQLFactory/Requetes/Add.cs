using System;
using System.Collections.Generic;
using System.Linq;

namespace Annuaire_CESI.SQLFactory.Requetes
{
    class Add : Requete
    {
        private TypeRequete _typeRequete;
        private List<Contact> _resultatGet;

        public Add(Contact contact)
        {
            _typeRequete = TypeRequete.Get;
            using (ContexteSQL db = new ContexteSQL())
            {
                db.Contact.Add(contact);

                //Verification de la modification de la database
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
