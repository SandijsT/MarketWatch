using System.Data.SqlClient;

namespace DatabaseLibrary
{
    public class DbConnector
    {
        public static string DbcResource => "Data Source=localhost;Initial Catalog=resource;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static SqlConnection DbResourceConnection => new SqlConnection(ReplaceConnectionStringApplicatioName(DbcResource));

        private static string ReplaceConnectionStringApplicatioName(string connectionString)
        {
            var applicationName = GetApplicationName();
            var connectionStringBuilder = new SqlConnectionStringBuilder(connectionString)
            {
                ApplicationName = applicationName
            };
            return connectionStringBuilder.ToString();
        }

        public static string GetApplicationName()
        {
            var applicationName = GetApplicationNameFromCurrentDomainBaseDirectory();
            return applicationName ?? "MarketWatch";
        }

        private static string GetApplicationNameFromCurrentDomainBaseDirectory()
        {
            var applicationName = AppDomain.CurrentDomain.BaseDirectory;
            if (applicationName.EndsWith("\\"))
            {
                applicationName = applicationName.Substring(0, applicationName.Length - 1);
            }

            if (applicationName.EndsWith("\\Debug"))
            {
                applicationName = applicationName.Substring(0, applicationName.Length - 6);
            }

            if (applicationName.EndsWith("\\Release"))
            {
                applicationName = applicationName.Substring(0, applicationName.Length - 7);
            }

            if (applicationName.EndsWith("\\bin"))
            {
                applicationName = applicationName.Substring(0, applicationName.Length - 4);
            }

            if (applicationName.IndexOf("\\") != -1)
            {
                applicationName = applicationName.Substring(applicationName.LastIndexOf("\\") + 1);
            }

            return applicationName;
        }
    }
}
