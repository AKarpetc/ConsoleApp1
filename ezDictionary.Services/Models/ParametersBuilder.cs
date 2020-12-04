using System;
using System.Collections.Generic;
using System.Text;

namespace ezDictionary.Services.Models
{
    public abstract class ParametersBuilder
    {
        protected string url;
        protected string lang;
    

        public virtual ParametersBuilder SetOriginLanguage(Lang lang)
        {
            this.lang = lang.ToString();
            return this;
        }

        public virtual ParametersBuilder SetUrl(string url)
        {
            this.url = url;
            return this;
        }




        internal abstract string Build();

    }

    public enum Lang
    {
        en,
        ru
    }

}
