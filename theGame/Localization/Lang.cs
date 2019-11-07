using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace theGame
{

    public class Lang
    {
        private Dictionary<string, string> _curLang = null;

        private readonly Dictionary<string, string> _ru = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _en = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _pl = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _de = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _fr = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _pt = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _es = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _ko = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _ja = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _zh = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _it = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _nn = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _da = new Dictionary<string, string>();
        

        public static Lang Instance { get; private set; }

        public Lang()
        {
            Instance = this;
        }

        public void Load()
        {
            var lngRes = Resources.Load<TextAsset>("db/lang");
            if (lngRes != null)
            {
                var text = Helper.CheckJson(lngRes.text);
                var data = JsonUtility.FromJson<LangDataModel>(text);
                Load(data);
            }

            SetLang(Application.systemLanguage);
        }

        
        private void Load(LangDataModel data)
        {
            foreach(var l in data.items)
            {
                if(_ru.ContainsKey(l.key))
                {
                    Debug.LogError("Lang double key: " + l.key);
                    continue;
                }

                _ru.Add(l.key, l.ru);
                _en.Add(l.key, l.en);
                _da.Add(l.key, l.da);
                _de.Add(l.key, l.de);
                _es.Add(l.key, l.es);
                _fr.Add(l.key, l.fr);
                _it.Add(l.key, l.it);
                _ja.Add(l.key, l.ja);
                _ko.Add(l.key, l.ko);
                _nn.Add(l.key, l.nn);
                _pl.Add(l.key, l.pl);
                _pt.Add(l.key, l.pt);
                _zh.Add(l.key, l.zh);
            }
        }
        
        public string GetText(string key)
        {
            if (_curLang != null && _curLang.ContainsKey(key)) return _curLang[key];
            return key;
        }

        public static string Get(string key)
        {
            return Instance != null ? Instance.GetText(key) : key;
        }

        public static string Get(string key, int val)
        {
            return string.Format(Instance.GetText(key), val);
        }

        public static string Get(string key, int val, int val2)
        {
            return string.Format(Instance.GetText(key), val, val2);
        }

        public static string Get(string key, object val1)
        {
            return string.Format(Instance.GetText(key), val1);
        }

        public static string Get(string key, object val1, object val2)
        {
            return string.Format(Instance.GetText(key), val1, val2);
        }

        public void SetLang(SystemLanguage lang)
        {
            if (lang == SystemLanguage.Russian)
                _curLang = _ru;
            else if (lang == SystemLanguage.Polish)
                _curLang = _pl;
            else if (lang == SystemLanguage.German)
                _curLang = _de;
            else if (lang == SystemLanguage.French)
                _curLang = _fr;
            else if (lang == SystemLanguage.Portuguese)
                _curLang = _pt;
            else if (lang == SystemLanguage.Spanish)
                _curLang = _es;
            else if (lang == SystemLanguage.Korean)
                _curLang = _ko;
            else if (lang == SystemLanguage.Japanese)
                _curLang = _ja;
            else if (lang == SystemLanguage.Chinese)
                _curLang = _zh;
            else if (lang == SystemLanguage.Italian)
                _curLang = _it;
            else if (lang == SystemLanguage.Norwegian)
                _curLang = _nn;
            else if (lang == SystemLanguage.Danish)
                _curLang = _da;
                                
            else
                _curLang = _en;
        }

        public SystemLanguage CurLang
        {
            get
            {
                if (_curLang == _ru)
                    return SystemLanguage.Russian;
                else if (_curLang == _pl)
                    return SystemLanguage.Polish;
                else if (_curLang == _de)
                    return SystemLanguage.German;
                else if (_curLang == _fr)
                    return SystemLanguage.French;
                else if (_curLang == _pt)
                    return SystemLanguage.Portuguese;
                else if (_curLang == _es)
                    return SystemLanguage.Spanish;
                else if (_curLang == _ko)
                    return SystemLanguage.Korean;
                else if (_curLang == _ja)
                    return SystemLanguage.Japanese;
                else if (_curLang == _zh)
                    return SystemLanguage.Chinese;
                else if (_curLang == _it)
                    return SystemLanguage.Italian;
                else if (_curLang == _nn)
                    return SystemLanguage.Norwegian;
                else if (_curLang == _da)
                    return SystemLanguage.Danish;

                return SystemLanguage.English;
            }
        }
    }

}
