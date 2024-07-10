using System;
using System.Text;
using System.Configuration;


namespace ConnectionString
{
    public static class clsConnectionString
    {
        // as i put it in app setting section (calss but serialized)
        public static string ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
    }
}
