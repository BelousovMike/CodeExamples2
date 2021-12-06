﻿using System.Collections.Generic;

namespace APS.Core.Catalog.Models
{
    public static class DefaultRoles
    {
        public const string User = "User";
        public const string Admin = "Admin";

        public static IEnumerable<string> All()
        {
            yield return User;
            yield return Admin;
        }
    }
}
