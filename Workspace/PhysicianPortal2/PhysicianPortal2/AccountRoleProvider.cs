// -----------------------------------------------------------------------
// A custom AccountRoleProvider class was implemented to provide
// security based on the data layout of the external SQL Server
// database that was used for this application.
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PhysicianPortal2
{
    public class AccountRoleProvider : System.Web.Security.RoleProvider
    {
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        // Determine roles based on values from the SQL database.
        public override string[] GetRolesForUser(string username)
        {
            String[] roles;
            DataAccess da = new DataAccess();
            if (da.isUserAdmin(username))
            {
                roles = new String[] { "Admin" };
            }
            else if (da.isUserPhysician(username))
            {
                roles = new String[] { "Physician" };
            }
            else
            {
                roles = new String[] { "User" };
            }
            return roles;
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            DataAccess da = new DataAccess();
            if (da.isUserAdmin(username) && roleName.Equals("Admin"))
            {
                return true;
            }
            else if (da.isUserPhysician(username) && roleName.Equals("Physician"))
            {
                return true;
            }
            else if (!(da.isUserPhysician(username)) && !(da.isUserAdmin(username)) && roleName.Equals("User"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}