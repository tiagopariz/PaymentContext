using System;

namespace PaymentContext.Shared
{
    public static class Helpers
    {
        public static bool ValidEmail(string address)
        {
            if (address.IndexOf('@') > 0)
                return true;
            return false;
        }

        public static bool ValidDocument(string number)
        {
            if (number.Length > 10)
                return true;
            return false;
        }
    }
}