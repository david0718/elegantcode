using FubuCart.Core.Web.DisplayModels;
using FubuMVC.Core;
using FubuMVC.Core.Controller.Config;

namespace FubuCart.Core.Web
{
    public static class Well_known_URLs
    {
        public static string PublishedProduct(this IUrlResolver resolver, ProductDisplay product)
        {
            // TODO: _resolver.UrlFor<BlogController>() + "/" + ...;
            return ("~/product/" +
                    product.Category.Name + "/" +
                    product.Name).ToFullUrl();
        }
    }
}