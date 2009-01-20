using FubuMVC.Core.Controller.Config;
using Microsoft.Practices.ServiceLocation;

namespace FubuCart.Core.Web
{
    public static class UrlToExtensions
    {
        public static IUrlResolver UrlTo(this IFubuCartPage viewPage)
        {
            return ServiceLocator.Current.GetInstance<IUrlResolver>();
        }
    }
}