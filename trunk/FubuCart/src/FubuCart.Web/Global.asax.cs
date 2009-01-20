using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FubuCart.Core.Web;
using FubuMVC.Container.StructureMap.Config;
using FubuMVC.Core.Html.Expressions;

namespace FubuCart.Web
{
    public class Global : HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            ControllerConfig.Configure = x =>
             {
                 x.UsingConventions(conventions =>
                                        {
                                            conventions.PartialForEachOfHeader =
                                                FubuCartDefaultPartialHeader;
                                            conventions.PartialForEachOfFooter =
                                                FubuCartDefaultPartialFooter;
                                        });
                 x.ByDefault.EveryControllerAction(d =>
                                                       {
                                                           //Need to setup up some controller behaviors here?
                                                           //d.Will<Some_Controller_action_or_behavior>();
                                                       });

                 x.AddControllersFromAssembly.ContainingType<ViewModel>(c =>
                 {
                     // All objects in Web.Controllers whose name ends with "*Controller"
                     // All public OMIOMO methods are actions, so no need to filter the methods
                     c.Where(t =>
                         t.Namespace.EndsWith("Web.Controllers")
                         && t.Name.EndsWith("Controller"));

                     c.MapActionsWhere((m, i, o) => true);
                 });
             };

            Bootstrapper.Bootstrap();
        }

        //protected void Session_Start(object sender, EventArgs e)
        //{

        //}

        //protected void Application_BeginRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_AuthenticateRequest(object sender, EventArgs e)
        //{

        //}

        //protected void Application_Error(object sender, EventArgs e)
        //{

        //}

        //protected void Session_End(object sender, EventArgs e)
        //{

        //}

        //protected void Application_End(object sender, EventArgs e)
        //{

        //}

        private static HtmlExpressionBase FubuCartDefaultPartialHeader(object itemList, int totalCount)
        {
            var expr = new GenericOpenTagExpression("ul");

            return expr;
        }

        private static string FubuCartDefaultPartialFooter(object itemList, int totalCount)
        {
            // For Debug View
            //if (itemList is IEnumerable<DebugSingleLineDisplay>) return "</ol>";

            return "</ul>";
        }
    }
}