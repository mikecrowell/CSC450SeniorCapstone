// -----------------------------------------------------------------------
// Thread that was to monitor the import directory for new files.
// This wasn't fully implemented for this version of the application
// as files are received using web services instead.
// -----------------------------------------------------------------------

namespace PhysicianPortal2
{
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Threading;

    public class MonitorHL7Input
    {
        public void run()
        {
            Process scriptProc = new Process();
            scriptProc.StartInfo.FileName = @"cscript"; 
            scriptProc.StartInfo.Arguments ="//B \\Scripts\\Test.vbs";
            scriptProc.Start();
            scriptProc.WaitForExit();
            scriptProc.Close();

            Thread.Sleep(5000);
        }

    }

}