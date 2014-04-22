// -----------------------------------------------------------------------
// Class for the system user definition.
// It implements IComparable for sorting and MembershipUser for
// use by AccountMembershipProvider.
// -----------------------------------------------------------------------

namespace PhysicianPortal2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class User : System.Web.Security.MembershipUser, IComparable<User>
    {
        public string username { get; set; }
        public string password { get; set; }
        public bool isPhysician { get; set; }
        public string userLogin { get; set; }

        public User()
        {

        }

        public User(String name)
            : base(
                providerName: "AccountMembershipProvider",
                name: name,
                providerUserKey: null,
                email: "",
                passwordQuestion: "",
                comment: "",
                isApproved: true,
                isLockedOut: false,
                creationDate: DateTime.UtcNow,
                lastLoginDate: DateTime.UtcNow,
                lastActivityDate: DateTime.UtcNow,
                lastPasswordChangedDate: DateTime.UtcNow,
                lastLockoutDate: DateTime.UtcNow)
        {
            userLogin = name;
        }

        #region IComparable<User> Members

        public int CompareTo(User other)
        {
            return String.Compare(this.username, other.username);

        }

        #endregion
    }

}