using System.Data.Common;
using System.Data.Entity;


namespace Annuaire_CESI
{

    class ContexteSQL : DbContext
    {
        public DbSet<Contact> Contact { get; set; }

        /// <summary>
        /// Recupération des erreurs, si il y a, sous forme d'un string
        /// </summary>
        /// <returns></returns>
        public string Validation()
        {
            string msg = string.Empty;

            //On récupère les résultats de validation de base de données
            foreach (var validationResult in GetValidationErrors())
            {
                foreach (var error in validationResult.ValidationErrors)
                {
                    msg += "Entité : " + error.PropertyName + "\n\tErreur : " + error.ErrorMessage + "\n";
                }
            }
            //On nettoie les erreurs
            foreach (var validationResults in GetValidationErrors())
            {
                validationResults.ValidationErrors.Clear();
            }

            return msg;
        }
    }
}
