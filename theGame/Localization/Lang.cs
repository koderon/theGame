using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace theGame
{

    public class Lang
    {
        private Dictionary<string, string> _curLang = null;

        private SystemLanguage _curSystemLanguage = SystemLanguage.English;
        
        private readonly Dictionary<SystemLanguage, Dictionary<string, string>> _allLang = new Dictionary<SystemLanguage, Dictionary<string, string>>();
        

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

            CurLang = Application.systemLanguage;
        }

        
        private void Load(LangDataModel data)
        {
            foreach(var l in data.items)
            {
                _allLang[SystemLanguage.Russian].Add(l.key, l.ru);
                _allLang[SystemLanguage.English].Add(l.key, l.en);
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

        public SystemLanguage CurLang
        {
            get => _curSystemLanguage;
            set
            {
                _curSystemLanguage = value;

                if (_allLang.ContainsKey(value))
                    _curLang = _allLang[value];
                else
                {
                    if (_allLang.ContainsKey(SystemLanguage.English))
                        _curLang = _allLang[SystemLanguage.English];
                }
            }
        }
    }

}
