using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Annuaire_CESI.SQLFactory.Requetes
{
    class Delete : Requete
    {
        private TypeRequete _typeRequete;
        private List<Contact> _resultatGet;

        public Delete(int IdASupprimer)
        {
            _typeRequete = TypeRequete.Get;
            using (ContexteSQL db = new ContexteSQL())
            {
                Contact aSupprimer = db.Contact.Where(x => x.ContactID == IdASupprimer).Single() ;
                db.Contact.Remove(aSupprimer);

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
