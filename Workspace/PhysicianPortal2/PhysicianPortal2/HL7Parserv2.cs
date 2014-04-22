// -----------------------------------------------------------------------
// Interface for parsing routine
// To allow for easy implementation of different HL7 versions
// or parsing of other formats, such as XML.
// -----------------------------------------------------------------------

namespace PhysicianPortal2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Collections;
    using System.IO;

    public class HL7Parserv2 : IParser
    {
        // Public method to receive a string message that is expected to be in HL7 format.
        // If one of the HL7 IDs are not identified in the message then it is logged as 
        // an invalid HL7 message.  Otherwise the message is passed to the appropriate method.
        public void parseMSG(String msg)
        {
            String msgID = "";
            foreach (string segment in msg.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                //Get field
                String[] field = segment.ToString().Split('|');
                if (field[0].Equals("MSH"))
                {
                    String[] component = field[8].ToString().Split('^');
                    msgID = component[0].ToString();
                    if (msgID.Equals("ADT"))
                    {
                        parseADT(msg);
                    }
                    else if (msgID.Equals("ORM"))
                    {
                        parseOrder(msg);
                    }
                    else if (msgID.Equals("ORU"))
                    {
                        parseResult(msg);
                    }
                    else
                    {
                        //invalid HL7 message
                        INTERFACELOG log = new INTERFACELOG();
                        log.Date_Time = DateTime.Now;
                        log.Log_Entry = "Invalid HL7 message received. \n" + msg;
                        DataAccess da = new DataAccess();
                        da.writeToInterfaceLog(log);
                    }
                }
            }
        }

        // This method handles messages with Patient demographic information.
        // If the patients exists in the database then the existing record is updated.
        // Otherwise a new patient record is added.
        private void parseADT(String msg)
        {
            String ptid = "";
            String lastName = "";
            String firstName = "";
            String dob = "";
            String gender = "";
            String address = "";
            String city = "";
            String state = "";
            String zip = "";

            foreach (string segment in msg.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                String[] field = segment.ToString().Split('|');
                if (field[0].Equals("PID"))
                {
                    ptid = field[2].ToString();
                    String[] nameComponent = field[5].ToString().Split('^');
                    lastName = nameComponent[0].ToString();
                    firstName = nameComponent[1].ToString();
                    dob = field[7].ToString();
                    gender = field[8].ToString();
                    String[] addressComponent = field[11].ToString().Split('^');
                    address = addressComponent[0].ToString();
                    city = addressComponent[2].ToString();
                    state = addressComponent[3].ToString();
                    zip = addressComponent[4].ToString();
                }
            }
            if (!(ptid.Equals("")))
            {
                PATIENT patient = new PATIENT();
                patient.Patient_ID = ptid;
                patient.Last_Name = lastName;
                patient.First_Name = firstName;
                String year = dob.Substring(0, 4);
                String month = dob.Substring(4, 2);
                String day = dob.Substring(6, 2);
                String birthdate = month + "/" + day + "/" + year;
                patient.DOB = Convert.ToDateTime(birthdate);
                patient.Gender = gender;
                patient.Address = address;
                patient.City = city;
                patient.State = state;
                patient.Zip = zip;
                DataAccess da = new DataAccess();
                if (da.isPatientExist(ptid))
                {
                    da.modifyPatient(patient);
                    INTERFACELOG log = new INTERFACELOG();
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Patient id " + ptid + " modified.";
                    da.writeToInterfaceLog(log);
                }
                else
                {
                    da.addPatient(patient);
                    INTERFACELOG log = new INTERFACELOG();
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Patient id " + ptid + " added.";
                    da.writeToInterfaceLog(log);
                }
            }
            else
            {
                //HL7 error
                INTERFACELOG log = new INTERFACELOG();
                log.Date_Time = DateTime.Now;
                log.Log_Entry = "Null patient ID received.\n" + msg;
                DataAccess da = new DataAccess();
                da.writeToInterfaceLog(log);
            }
        }

        // This method handles messages with Patient order information.
        // If the order exists in the database then the existing record is updated.
        // Otherwise a new order is added.
        private void parseOrder(String msg)
        {
            String orderid = "";
            String physicianid = "";
            String testcode = "";
            String orderdate = "";
            String ptid = "";
            String siteid = "";

            foreach (string segment in msg.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                String[] field = segment.ToString().Split('|');
                if (field[0].Equals("PID"))
                {
                    ptid = field[2].ToString();
                }
                else if (field[0].Equals("PV1"))
                {
                    siteid = field[3].ToString();
                }
                else if (field[0].Equals("OBR"))
                {
                    orderid = field[2].ToString();
                    testcode = field[4].ToString();
                    orderdate = field[7].ToString();
                    String[] physicianComponent = field[16].ToString().Split('^');
                    physicianid = physicianComponent[0].ToString();              
                }
            }
            if (!(orderid.Equals("")))
            {
                ORDER order = new ORDER();
                order.Order_ID = orderid;
                order.Physician_ID = physicianid;
                order.Test_Code = testcode;
                String year = orderdate.Substring(0, 4);
                String month = orderdate.Substring(4, 2);
                String day = orderdate.Substring(6, 2);
                String newdate = month + "/" + day + "/" + year;
                order.Order_Date = Convert.ToDateTime(newdate);
                order.Order_Status = "Pending";
                order.Patient_ID = ptid;
                order.Site_ID = siteid;
                DataAccess da = new DataAccess();
                if (da.isOrderExist(orderid))
                {
                    da.modifyOrder(order);
                    INTERFACELOG log = new INTERFACELOG();
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Order id " + orderid + " modified.";
                    da.writeToInterfaceLog(log);
                }
                else
                {
                    da.addOrder(order);
                    INTERFACELOG log = new INTERFACELOG();
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Order id " + orderid + " added.";
                    da.writeToInterfaceLog(log);
                }
            }
            else
            {
                //HL7 error
                INTERFACELOG log = new INTERFACELOG();
                log.Date_Time = DateTime.Now;
                log.Log_Entry = "Null order ID received.\n" + msg;
                DataAccess da = new DataAccess();
                da.writeToInterfaceLog(log);
            }
        }

        // This method handles messages with result information.
        // If the result exists in the database then the existing record is updated.
        // Otherwise a new result is added.
        // The method will also update the order status of the order record.
        private void parseResult(String msg)
        {
            String resultid = "";
            String resultdate = "";
            String resultedby = "";
            String resultreport = "";
            String orderid = "";

            foreach (string segment in msg.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries))
            {
                String[] field = segment.ToString().Split('|');
                if (field[0].Equals("OBR"))
                {
                    resultid = field[2].ToString();
                    orderid = field[3].ToString();
                    resultdate = field[7].ToString();
                    resultedby = field[11].ToString();
                }
                else if (field[0].Equals("OBX"))
                {
                    resultreport += field[5].ToString() + ", ";
                }
            }
            if (!(resultid.Equals("")))
            {
                RESULT result = new RESULT();
                result.Result_ID = resultid;
                String year = resultdate.Substring(0, 4);
                String month = resultdate.Substring(4, 2);
                String day = resultdate.Substring(6, 2);
                String newdate = month + "/" + day + "/" + year;
                result.Result_Date = Convert.ToDateTime(newdate);
                result.Resulted_By = resultedby;
                result.Result_Report = resultreport;
                result.Order_ID = orderid;
                DataAccess da = new DataAccess();
                INTERFACELOG log = new INTERFACELOG();
                if (da.isResultExist(resultid))
                {
                    da.modifyResult(result);
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Result id " + resultid + " modified.";
                    da.writeToInterfaceLog(log);
                }
                else
                {
                    da.addResult(result);
                    log.Date_Time = DateTime.Now;
                    log.Log_Entry = "Result id " + resultid + " added.";
                    da.writeToInterfaceLog(log);
                }
                ORDER order = da.getORDERByOrderID(orderid);
                order.Order_Status = "Resulted";
                da.modifyOrder(order);
                log.Date_Time = DateTime.Now;
                log.Log_Entry = "Order id " + orderid + " modified.";
                da.writeToInterfaceLog(log);
            }
            else
            {
                //HL7 error
                INTERFACELOG log = new INTERFACELOG();
                log.Date_Time = DateTime.Now;
                log.Log_Entry = "Null result ID received.\n" + msg;
                DataAccess da = new DataAccess();
                da.writeToInterfaceLog(log);
            }
        }



    }

}