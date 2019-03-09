using Shop.Shared.Entities.Enums;
using System;

namespace Shop.Shared.Helpers
{
    public static class RoleHelper
    {
        public static RoleType ConvertToRoleType(string roleName)
        {
            return (RoleType)Enum.Parse(typeof(RoleType), roleName);
        }

        public static RoleType ConvertToRoleType(int roleid)
        {
            return (RoleType)roleid;
        }
    }
}
