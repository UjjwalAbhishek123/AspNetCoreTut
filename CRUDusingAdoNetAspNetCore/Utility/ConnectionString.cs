namespace CRUDusingAdoNetAspNetCore.Utility
{
    //Here we will set DB Connection string
    //Make it static class to use as Extension, i.e without making objects we can use it
    public static class ConnectionString
    {
        //static property
        private static string conStr = @"Server=DESKTOP-9UUR0U8\SQLEXPRESS; Database=CrudAdoDB; Trusted_Connection=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";
        
        //we can't modify
        public static string dbcs { get => conStr; }
    }
}
