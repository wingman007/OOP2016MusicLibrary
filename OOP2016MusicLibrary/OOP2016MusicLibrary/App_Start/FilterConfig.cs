using System.Web;
using System.Web.Mvc;

namespace OOP2016MusicLibrary
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
