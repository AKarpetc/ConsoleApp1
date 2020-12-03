using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ezDictionary.Services.Services
{
    public interface ITranslationService
    {
        Task<string> Translate(string ru);
    }
}
