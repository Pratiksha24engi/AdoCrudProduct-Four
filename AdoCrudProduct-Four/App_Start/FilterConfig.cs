using System.Web;
using System.Web.Mvc;

namespace AdoCrudProduct_Four
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
