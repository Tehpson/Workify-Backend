namespace Workify_Backend.Functions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    internal static class hashing
    {
        internal static string HashPassword(string pwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(pwd);
        }

        internal static bool VerifyPassword(string pwd, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(pwd, passwordHash);
        }
    }
}
