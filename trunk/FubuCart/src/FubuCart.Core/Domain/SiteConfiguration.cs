using System.Collections.Generic;

namespace FubuCart.Core.Domain
{
    public class SiteConfiguration : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Host { get; set; }
        public virtual string LanguageDefault { get; set; }
        public virtual string PageTitleSeparator { get; set; }
        public virtual string ThemeDefault { get; set; }
        public virtual string FavIconUrl { get; set; }
        public virtual string ScriptsPath { get; set; }
        public virtual string CssPath { get; set; }
        public virtual string ImagesPath { get; set; }
        //public virtual string CommentAnonymousStateDefault { get; set; }
        public virtual string EmailUsername { get; set; }
        public virtual bool IncludeOpenSearch { get; set; }
        //public virtual bool AuthorAutoSubscribe { get; set; }
        //public virtual double PostEditTimeout { get; set; }
        public virtual string SEORobots { get; set; }
        public virtual string GravatarDefault { get; set; }
        //public virtual bool TrackbacksEnabled { get; set; }

        // TODO: What are the Aliases For?
        //public IEnumerable<Alias> GetAliases()
        //{
        //    return _aliases.AsEnumerable();
        //}
        //public void AddAlias(Alias alias)
        //{
        //    _aliases.Add(alias);
        //}

        //public void RemoveAlias(Alias alias)
        //{
        //    _aliases.Remove(alias);
        //}
    }
}