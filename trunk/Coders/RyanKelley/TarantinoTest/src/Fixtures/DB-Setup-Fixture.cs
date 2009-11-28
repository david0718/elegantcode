using FluentNHibernate;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using TarantinoSample.Domain;

namespace TarantinoSample.Fixtures
{
    [TestFixture]
    public class DB_Setup_Fixture
    {
        private Configuration _configuration;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {

            _configuration = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                              .ConnectionString(c =>
                                                c.FromConnectionStringWithKey("testData"))
                              .UseReflectionOptimizer()
                              .ShowSql())
                .Mappings(m =>
                          m.AutoMappings.Add(AutoMap.AssemblyOf<Order>()
                                                 .Where(x => x.Namespace.EndsWith("Domain"))))
                .BuildConfiguration();
            
        }

        [Test, Explicit, Category("DBSetup")]
        public void Create_DB_Schema()
        {
            var exporter = new SchemaExport(_configuration);
            exporter.Create(true, true);

        }
    }
}