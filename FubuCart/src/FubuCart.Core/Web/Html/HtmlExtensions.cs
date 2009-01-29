
using System.Collections.Generic;
using FubuCart.Core.Domain;
using FubuMVC.Core.Controller.Config;
using FubuMVC.Core.Html;
using FubuMVC.Core.Html.Expressions;
using FubuMVC.Core.View.WebForms;
using Microsoft.Practices.ServiceLocation;

namespace FubuCart.Core.Web.Html
{
    public static class HtmlExtensions
    {
        public static LinkExpression SkinCSS(this IFubuCartPage viewPage, string url)
        {
            var siteConfig = ServiceLocator.Current.GetInstance<SiteConfiguration>();
            var baseUrl = siteConfig.CssPath;
            return viewPage.CSS(url).BasedAt(baseUrl);
        }

        public static ScriptReferenceExpression SkinScript(this IFubuCartPage viewPage, string url)
        {
            var siteConfig = ServiceLocator.Current.GetInstance<SiteConfiguration>();
            var baseUrl = siteConfig.ScriptsPath;
            return viewPage.Script(url).BasedAt(baseUrl);
        }

        public static ScriptReferenceExpression SkinScript(this IFubuCartPage viewPage, IEnumerable<string> urls)
        {
            var siteConfig = ServiceLocator.Current.GetInstance<SiteConfiguration>();
            var baseUrl = siteConfig.ScriptsPath;
            return viewPage.Script(urls).BasedAt(baseUrl);
        }

        // TODO: Implement login for customer
        //public static LoginStatusExpression DisplayDependingOnLoginStatus(this IFubuCartPage viewPage)
        //{
        //    var renderer = ServiceLocator.Current.GetInstance<IWebFormsViewRenderer>();
        //    var conventions = ServiceLocator.Current.GetInstance<FubuConventions>();
        //    return new LoginStatusExpression(viewPage, renderer, conventions);
        //}
    }
}