namespace Multi_Layered_Architecture.part3.CommonLayer
{
    public static class ErrorHandler
    {
        public static string GetErrorMessage(Exception ex)
        {
            return ex.Message;
        }
    }
}
