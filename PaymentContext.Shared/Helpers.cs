namespace PaymentContext.Shared
{
    public static class Helpers
    {
        public static bool ValidEmail(string address)
        {
            return address.IndexOf('@') > 0;
        }

        public static bool ValidDocument(string number)
        {
            return number.Length > 10;
        }
    }
}