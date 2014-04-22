// -----------------------------------------------------------------------
// The DataAccess class is a single point for all database queries.
// It translates the business logic into database queries and provides
// a layer of separation between the data layer and the view layer.
// This class references a linq data context, which provides the actual
// communication with the SQL database.
// -----------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianPortal2
{
    public class DataAccess
    {
        private LinqToAllDataDataContext linqDat = new LinqToAllDataDataContext();

        public List<USER> getListofAllUsers()
        {
            List<USER> uList = new List<USER>();
            var u = from usr in linqDat.USERs select usr;
            foreach (var v in u)
            {
                USER newU = new USER();
                newU.User_Name = v.User_Name;
                newU.Password = v.Password;
                newU.Is_Physician = v.Is_Physician;
                uList.Add(newU);
            }
            return uList;
        }

        public bool isValidUser(String name)
        {
            var users = (from dat in linqDat.USERs
                         where dat.User_Name.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                if (users.First().dat.Is_Active)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public String getUserPassword(String name)
        {
            var users = (from dat in linqDat.USERs
                         where dat.User_Name.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.Password;
            }
            else
            {
                return null;
            }

        }


        public bool isUserAdmin(String name)
        {
            var users = (from dat in linqDat.USERs
                         where dat.User_Name.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.Is_Admin;
            }
            else
            {
                return false;
            }
        }

        public bool isUserPhysician(String name)
        {
            var users = (from dat in linqDat.USERs
                         where dat.User_Name.Equals(name)
                         select new { dat }).ToList();

            if (users.Count > 0)
            {
                return users.First().dat.Is_Physician;
            }
            else
            {
                return false;
            }
        }


        public void addPatient(Patient patient)
        {
            PATIENT newPatient = new PATIENT();
            newPatient.Patient_ID = patient.ptid;
            newPatient.Last_Name = patient.lastName;
            newPatient.First_Name = patient.firstName;
            DateTime dt = Convert.ToDateTime(patient.dob);
            newPatient.DOB = dt;
            newPatient.Address = patient.address;
            newPatient.City = patient.city;
            newPatient.State = patient.state;
            newPatient.Zip = patient.zip;
            linqDat.PATIENTs.InsertOnSubmit(newPatient);
            linqDat.SubmitChanges();
        }

        public Patient getPatientByID(String id)
        {
            var patients = (from dat in linqDat.PATIENTs
                            where dat.Patient_ID.Equals(id)
                            select new { dat }).ToList();

            if (patients.Count > 0)
            {
                Patient patient = new Patient();
                patient.ptid = patients.First().dat.Patient_ID;
                patient.firstName = patients.First().dat.First_Name;
                patient.lastName = patients.First().dat.Last_Name;
                patient.address = patients.First().dat.Address;
                patient.city = patients.First().dat.City;
                patient.state = patients.First().dat.State;
                patient.zip = patients.First().dat.Zip;
                patient.dob = patients.First().dat.DOB.ToString();
                return patient;
            }
            else
            {
                return null;
            }
        }

        public List<ORDER> getPatientOrdersByPatientID(String id)
        {
            List<ORDER> orderList = new List<ORDER>();

            var ord = from dat in linqDat.PATIENTs
                         join orders in linqDat.ORDERs on dat.Patient_ID equals orders.Patient_ID
                         where dat.Patient_ID.Equals(id)
                         select new { orders };

            foreach (var v in ord)
            {
                ORDER o = new ORDER();
                o.Order_ID = v.orders.Order_ID;
                o.Physician_ID = v.orders.Physician_ID;
                o.Test_Code = v.orders.Test_Code;
                o.Order_Date = v.orders.Order_Date;
                o.Order_Status = v.orders.Order_Status;
                orderList.Add(o);
            }
            return orderList;
        }

        public List<PATIENT> getAllPatients()
        {
            List<PATIENT> patientList = new List<PATIENT>();

            var p = from pat in linqDat.PATIENTs select pat;
            foreach (var v in p)
            {
                PATIENT newPat = new PATIENT();
                newPat.Patient_ID = v.Patient_ID;
                newPat.Last_Name = v.Last_Name;
                newPat.First_Name = v.First_Name;
                newPat.DOB = v.DOB;
                newPat.Address = v.Address;
                newPat.City = v.City;
                newPat.State = v.State;
                newPat.Zip = v.Zip;
                patientList.Add(newPat);
            }
            return patientList;
        }

        public List<PATIENT> getPatientsByPhysicianID(String id)
        {
            List<PATIENT> patientList = new List<PATIENT>();

            var dat = from pat in linqDat.PATIENTs
                      join orders in linqDat.ORDERs on pat.Patient_ID equals orders.Patient_ID
                      where orders.Physician_ID.Equals(id)
                      select new { pat};

            foreach (var v in dat)
            {
                PATIENT newPat = new PATIENT();
                newPat.Patient_ID = v.pat.Patient_ID;
                newPat.Last_Name = v.pat.Last_Name;
                newPat.First_Name = v.pat.First_Name;
                newPat.DOB = v.pat.DOB;
                newPat.Address = v.pat.Address;
                newPat.City = v.pat.City;
                newPat.State = v.pat.State;
                newPat.Zip = v.pat.Zip;
                patientList.Add(newPat);
            }
            return patientList;
        }

        public RESULT getResultByOrderID(String id)
        {
            var result = (from res in linqDat.RESULTs
                            where res.Order_ID.Equals(id)
                            select new { res }).ToList();

            if (result.Count > 0)
            {
                return result.First().res;                
            }
            else
            {
                return null;
            }
        }

        public List<RESULT> getResultListByOrderID(String id)
        {
            var result = (from res in linqDat.RESULTs
                          where res.Order_ID.Equals(id)
                          select new { res }).ToList();

            List<RESULT> resultList = new List<RESULT>();
            
            foreach (var v in result)
            {
                RESULT newRes = new RESULT();
                newRes.Result_ID = v.res.Result_ID;
                newRes.Order_ID = v.res.Order_ID;
                newRes.Result_Date = v.res.Result_Date;
                newRes.Resulted_By = v.res.Resulted_By;
                newRes.Result_Report = v.res.Result_Report;
                resultList.Add(newRes);
            }
            return resultList;
        }

        public String getPhysicianIDByUserID(String id)
        {
            var result = (from res in linqDat.PHYSICIANs
                          where res.User_Name.Equals(id)
                          select new { res }).ToList();

            if (result.Count > 0)
            {
                return result.First().res.Physician_ID;
            }
            else
            {
                return null;
            }
        }

        public bool isPatientExist(String id)
        {
            var patients = (from dat in linqDat.PATIENTs
                         where dat.Patient_ID.Equals(id)
                         select new { dat }).ToList();

            if (patients.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addPatient(PATIENT patient)
        {           
            linqDat.PATIENTs.InsertOnSubmit(patient);
            linqDat.SubmitChanges();
        }

        public void modifyPatient(PATIENT patient)
        {
            PATIENT modPatient = getPATIENTByPtID(patient.Patient_ID.ToString());
            modPatient.Patient_ID = patient.Patient_ID;
            modPatient.Last_Name = patient.Last_Name;
            modPatient.First_Name = patient.First_Name;
            modPatient.DOB = patient.DOB;
            modPatient.Address = patient.Address;
            modPatient.City = patient.City;
            modPatient.State = patient.State;
            modPatient.Zip = patient.Zip;
            modPatient.Gender = patient.Gender;
            linqDat.SubmitChanges();
        }

        public PATIENT getPATIENTByPtID(String id)
        {
            var patients = (from dat in linqDat.PATIENTs
                         where dat.Patient_ID.Equals(id)
                         select new { dat }).ToList();

            if (patients.Count > 0)
            {
                return patients.First().dat;
            }
            else
            {
                return null;
            }
        }

        public bool isOrderExist(String id)
        {
            var orders = (from dat in linqDat.ORDERs
                            where dat.Order_ID.Equals(id)
                            select new { dat }).ToList();

            if (orders.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addOrder(ORDER order)
        {
            linqDat.ORDERs.InsertOnSubmit(order);
            linqDat.SubmitChanges();
        }

        public void modifyOrder(ORDER order)
        {
            ORDER modOrder = getORDERByOrderID(order.Order_ID.ToString());
            modOrder.Order_ID = order.Order_ID;
            modOrder.Physician_ID = order.Physician_ID;
            modOrder.Test_Code = order.Test_Code;
            modOrder.Order_Date = order.Order_Date;
            modOrder.Order_Status = order.Order_Status;
            modOrder.Patient_ID = order.Patient_ID;
            modOrder.Site_ID = order.Site_ID;
            linqDat.SubmitChanges();
        }

        public ORDER getORDERByOrderID(String id)
        {
            var orders = (from dat in linqDat.ORDERs
                            where dat.Order_ID.Equals(id)
                            select new { dat }).ToList();

            if (orders.Count > 0)
            {
                return orders.First().dat;
            }
            else
            {
                return null;
            }
        }

        public bool isResultExist(String id)
        {
            var results = (from dat in linqDat.RESULTs
                            where dat.Result_ID.Equals(id)
                            select new { dat }).ToList();

            if (results.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addResult(RESULT result)
        {
            linqDat.RESULTs.InsertOnSubmit(result);
            linqDat.SubmitChanges();
        }

        public void modifyResult(RESULT result)
        {
            RESULT modResult = getRESULTByResultID(result.Result_ID.ToString());
            modResult.Result_ID = result.Result_ID;
            modResult.Result_Date = result.Result_Date;
            modResult.Resulted_By = result.Resulted_By;
            modResult.Result_Report = result.Result_Report;
            modResult.Order_ID = result.Order_ID;
            linqDat.SubmitChanges();
        }

        public RESULT getRESULTByResultID(String id)
        {
            var results = (from dat in linqDat.RESULTs
                            where dat.Result_ID.Equals(id)
                            select new { dat }).ToList();

            if (results.Count > 0)
            {
                return results.First().dat;
            }
            else
            {
                return null;
            }
        }

        public void writeToInterfaceLog(INTERFACELOG log)
        {
            linqDat.INTERFACELOGs.InsertOnSubmit(log);
            linqDat.SubmitChanges();
        }

        public List<INTERFACELOG> getInterfaceLog()
        {
            List<INTERFACELOG> logList = new List<INTERFACELOG>();
            var l = from log in linqDat.INTERFACELOGs select log;
            foreach (var v in l)
            {
                INTERFACELOG newLog = new INTERFACELOG();
                newLog.Date_Time = v.Date_Time;
                newLog.Log_Entry = v.Log_Entry;
                logList.Add(newLog);
            }
            return logList;
        }

        public void addSite(SITE site)
        {
            linqDat.SITEs.InsertOnSubmit(site);
            linqDat.SubmitChanges();
        }

        public void modifySite(SITE site)
        {
            SITE modSite = getSiteByID(site.Site_ID.ToString());
            modSite.Site_ID = site.Site_ID;
            modSite.Name = site.Name;
            modSite.Address = site.Address;
            modSite.City = site.City;
            modSite.State = site.State;
            modSite.Zip = site.Zip;
            linqDat.SubmitChanges();
        }

        public SITE getSiteByID(String id)
        {
            var sites = (from dat in linqDat.SITEs
                           where dat.Site_ID.Equals(id)
                           select new { dat }).ToList();

            if (sites.Count > 0)
            {
                return sites.First().dat;
            }
            else
            {
                return null;
            }
        }

        public void addTestCode(TEST test)
        {
            linqDat.TESTs.InsertOnSubmit(test);
            linqDat.SubmitChanges();
        }

        public void modifyTestCode(TEST test)
        {
            TEST modTest = getTestCodeByID(test.Test_Code.ToString());
            modTest.Test_Code = test.Test_Code;
            modTest.Description = test.Description;
            linqDat.SubmitChanges();
        }

        public TEST getTestCodeByID(String id)
        {
            var tests = (from dat in linqDat.TESTs
                         where dat.Test_Code.Equals(id)
                         select new { dat }).ToList();

            if (tests.Count > 0)
            {
                return tests.First().dat;
            }
            else
            {
                return null;
            }
        }

        public List<SITE> getListofAllSites()
        {
            List<SITE> sList = new List<SITE>();
            var s = from site in linqDat.SITEs select site;
            foreach (var v in s)
            {
                SITE newS = new SITE();
                newS.Site_ID = v.Site_ID;
                newS.Name = v.Name;
                newS.Address = v.Address;
                newS.City = v.City;
                newS.State = v.State;
                newS.Zip = v.Zip;
                sList.Add(newS);
            }
            return sList;
        }

        public List<TEST> getListofAllTests()
        {
            List<TEST> tList = new List<TEST>();
            var t = from test in linqDat.TESTs select test;
            foreach (var v in t)
            {
                TEST newT = new TEST();
                newT.Test_Code = v.Test_Code;
                newT.Description = v.Description;
                tList.Add(newT);
            }
            return tList;
        }

        public List<TestCodeReport> getTestCodeUseage()
        {
            var testcodes = from order in linqDat.ORDERs
                            join test in linqDat.TESTs on order.Test_Code equals test.Test_Code
                            group new
                            {
                                order,
                                test
                            } by new
                            {
                                test.Test_Code
                            } into g
                            select new
                            {
                                testCount = g.Count(),
                                testCode = g.Key.Test_Code
                            };


            if (testcodes.Count() > 0)
            {
                List<TestCodeReport> tList = new List<TestCodeReport>();
                foreach (var v in testcodes)
                {
                    TestCodeReport tr = new TestCodeReport();
                    tr.tetCode = v.testCode;
                    tr.useageCount = v.testCount;
                    tList.Add(tr);
                }
                return tList;
            }
            else
            {
                return null;
            }
        }

    }
}