// -----------------------------------------------------------------------
// Class for the patient definition that implements IComparable
// to allow for sorting of patients by name.
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianPortal2
{
    public class Patient : IComparable<Patient>
    {

        public string ptid { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string dob { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }


        #region IComparable<DataFile> Members

        public int CompareTo(Patient other)
        {
            return String.Compare(this.ptid, other.ptid);

        }

        #endregion

        public override string ToString()
        {
            return "ID: " + ptid + "\n" +
                "Patient Name: " + lastName + ", " + firstName + "\n" +
                "DOB: " + dob + "\n" +
                "Address: " + address + "\n"
                + city + ", " + state + " " + zip + "\n";

        }
        public override int GetHashCode()
        {
            return this.ptid.GetHashCode();
        }

    }
}