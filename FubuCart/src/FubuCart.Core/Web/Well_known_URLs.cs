using FubuCart.Core.Web.Controllers;
using FubuCart.Core.Web.DisplayModels;
using FubuMVC.Core;
using FubuMVC.Core.Controller.Config;

namespace FubuCart.Core.Web
{
    public static class Well_known_URLs
    {
        public static string Home(this IUrlResolver resolver)
        {
            return resolver.UrlFor<HomeController>();
        }

        public static string PublishedProduct(this IUrlResolver resolver, ProductDisplay product)
        {
            // TODO: _resolver.UrlFor<BlogController>() + "/" + ...;
            return ("~/product/" +
                    product.Name).ToFullUrl();
        }
    }
}