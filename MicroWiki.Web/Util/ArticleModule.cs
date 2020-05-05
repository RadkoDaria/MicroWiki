using MicroWiki.BLL.Interfaces;
using MicroWiki.BLL.Service;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MicroWiki.Web.Util
{
    public class ArticleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IArticleService>().To<ArticleService>();
        }
    }
}