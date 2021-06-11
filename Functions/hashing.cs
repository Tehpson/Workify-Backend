namespace Workify_Backend.Functions
{
    internal static class Hashing
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