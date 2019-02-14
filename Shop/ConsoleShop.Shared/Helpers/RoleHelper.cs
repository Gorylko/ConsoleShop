using ConsoleShop.Shared.Entities.Enums;
using System;

namespace ConsoleShop.Shared.Helpers
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
