// -----------------------------------------------------------------------
// Class to read file from import directory
// Class was not fully implemented as web services were used
// instead of file import.
// -----------------------------------------------------------------------

namespace PhysicianPortal2
{
    using System;
    using System.IO;
    using System.Text;

    public class ReadDataImportFile
    {
        
        public void readFile()
        {
            StreamReader sr = new StreamReader("~\\Database Import\\Test.txt");
            string strContent = sr.ReadToEnd();
            string[] strArray = strContent.Split(new string[] { "\t" }, StringSplitOptions.None);
            sr.Close();
            sr.Dispose();
        }

    }
}