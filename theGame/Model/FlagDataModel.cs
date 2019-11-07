using System;
using System.Collections.Generic;
using UnityEngine;

namespace theGame
{
    [Serializable]
    public class FlagsModel
    {
        public List<FlagDataModel> flags = new List<FlagDataModel>();

        public FlagDataModel GetFlag(string engName)
        {
             var f = flags.Find(g => g.image.Contains(engName.ToLower()));
             if(f == null)
                 Debug.LogError(engName + " not found!");

             return f;
        }
    }

    [Serializable]
    public class FlagDataModel
    {
        public int id;
        public string image;
        public string continent;

        public string en;
        public string de;
        public string fr;
        public string pl;
        public string ru;
        public string pt;
        public string es;
        public string ko;
        public string ja;
        public string zh;
        public string it;
        public string nn;
        public string da;

        public string GetName()
        {
            string curLang = en;
            var lang = Lang.Instance.CurLang;
            if (lang == SystemLanguage.Russian)
                curLang = ru;
            else if (lang == SystemLanguage.Polish)
                curLang = pl;
            else if (lang == SystemLanguage.German)
                curLang = de;
            else if (lang == SystemLanguage.French)
                curLang = fr;
            else if (lang == SystemLanguage.Portuguese)
                curLang = pt;
            else if (lang == SystemLanguage.Spanish)
                curLang = es;
            else if (lang == SystemLanguage.Korean)
                curLang = ko;
            else if (lang == SystemLanguage.Japanese)
                curLang = ja;
            else if (lang == SystemLanguage.Chinese)
                curLang = zh;
            else if (lang == SystemLanguage.Italian)
                curLang = it;
            else if (lang == SystemLanguage.Norwegian)
                curLang = nn;
            else if (lang == SystemLanguage.Danish)
                curLang = da;

            return curLang;
        }
    }
}