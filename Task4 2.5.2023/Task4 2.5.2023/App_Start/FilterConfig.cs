using System.Web;
using System.Web.Mvc;

namespace Task4_2._5._2023
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
