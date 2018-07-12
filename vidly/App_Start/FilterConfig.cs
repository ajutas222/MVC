using System.Web;
using System.Web.Mvc;

namespace vidly
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            // Apply globally
            filters.Add(new AuthorizeAttribute());
            // Force SSL Login access only
            filters.Add(new RequireHttpsAttribute());
        }
    }
}
