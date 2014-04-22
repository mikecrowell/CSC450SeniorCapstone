// -----------------------------------------------------------------------
// Web service that exposes method to receive an
// HL7 formatted string message
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace PhysicianPortal2
{
    /// <summary>
    /// Web service method to receive HL7 formatted String message
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class HL7ImportWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetHL7Message(String msg)
        {
            IParser hl7;
            hl7 = new HL7Parserv2();
            hl7.parseMSG(msg.ToString());
        }

    }
}
