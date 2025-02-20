namespace Multi_Layered_Architecture.part3.CommonLayer
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        public static bool IsValidId(int id)
        {
            return id > 0;
        }
    }
}
