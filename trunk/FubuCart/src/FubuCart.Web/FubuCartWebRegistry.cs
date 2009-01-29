using FubuCart.Core.Config;
using FubuCart.Core.Domain;
using StructureMap.Configuration.DSL;

namespace FubuCart.Web
{
    public class FubuCartWebRegistry : Registry
    {
        protected override void configure()
        {

            ForRequestedType<SiteConfiguration>()
                .AsSingletons()
                .TheDefault.Is.ConstructedBy(() =>
                    new SiteConfiguration()
                    .FromAppSetting("FubuCart.SiteConfiguration"));
        }
    }
}