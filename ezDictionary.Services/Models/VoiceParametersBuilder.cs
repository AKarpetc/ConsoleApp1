using System;
using System.Collections.Generic;
using System.Text;

namespace ezDictionary.Services.Models
{
    public class VoiceParametersBuilder : ParametersBuilder
    {
        protected string text;

        public virtual ParametersBuilder SetText(string text)
        {
            this.text = text;
            return this;
        }

        internal override string Build()
        {
            return url + $"?ie=UTF-8&q={text}&tl={lang}&client=tw-ob";
        }
    }
}
