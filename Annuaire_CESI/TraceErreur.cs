using System;
using System.IO;
using System.Windows;

namespace Annuaire_CESI
{
    class TraceErreur
    {


        private static readonly string filePath = @"C:\Fichiers\Debug.txt";


        /// <summary>
        /// Log des exceptions dans un fichier pour débug
        /// </summary>
        /// <param name="e"></param>
        public static void Log(Exception e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine("Erreur générée à " + DateTime.Now);
                sw.WriteLine(e.StackTrace);
                sw.WriteLine(e.InnerException);
                sw.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erreur d'enregistrement de l'erreur" + Environment.NewLine + exc.Message);
            }


        }



        /// <summary>
        /// Log des chaines de caractères, sous forme d'un fichier txt
        /// </summary>
        /// <param name="s"></param>
        public static void Log(string s)
        {
#if DEBUG
            MessageBox.Show(s);
#endif
            try
            {
                StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine("Erreur générée à " + DateTime.Now);
                sw.WriteLine(s);
                sw.Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Erreur d'enregistrement de l'erreur" + Environment.NewLine + exc.Message);
            }
        }
    }
}
