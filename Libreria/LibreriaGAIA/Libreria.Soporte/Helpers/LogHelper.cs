namespace Libreria.Soporte.Helpers
{
    using System;
    using System.IO;

    public class LogHelper
    {


        private string path = "";
        public LogHelper(string RutaLog)
        {

            path = RutaLog;
        }



        public void EscribirLog(Logtype type, string mensaje)
        {
            string nombre = "Log-" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
            string str = "_";
            char underLine = '_';
            string logMessage = "\n" + DateTime.Now.ToString() + " ";
            logMessage = logMessage + type.ToString() + " ";
            logMessage = logMessage + mensaje;
            logMessage = logMessage + "\n" + str.PadLeft(100, underLine);

            try
            {
                using (StreamWriter sw = new StreamWriter(path + nombre, true))
                {
                    sw.WriteLine(logMessage);
                    sw.Close();
                }
            }
            catch { }

        }
    }

    public enum Logtype
    {
        info = 1,
        advertencia = 2,
        error = 3,
        fatal = 4
    }
}
