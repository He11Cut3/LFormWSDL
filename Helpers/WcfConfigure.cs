using LForm.ServiceReference;

namespace LForm.Helpers
{
    public class WcfConfigure
    {
        public static void Authorize(ICUTechClient proxy)
        {
            if (proxy.ClientCredentials == null)
                return;

            if (!ConfigHelper.GetValue<bool>("IsProduction"))
                return;

            proxy.ClientCredentials.UserName.UserName = ConfigHelper.GetValue<string>("WSDL-Usr");
            proxy.ClientCredentials.UserName.Password = ConfigHelper.GetValue<string>("WSDL-Psw");
        }
    }
}
