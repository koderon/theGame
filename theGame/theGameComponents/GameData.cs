using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

namespace theGame
{

    public class GameData : TheGameComponent
    {
        // playerData
        private PlayerDataModel _playerDataModel;

        private bool _isNeedSave = false;

        private string _fileName = Application.identifier + ".data";

        public override void Init()
        {
            Load();
        }

        #region Save / Load
        private IEnumerator SaveGameData()
        {
            yield return new WaitForSeconds(60);

            _isNeedSave = false;
            Save();
        }

        void Load()
        {
            var serializedInput = FileUtils.LoadTextFromFile(_fileName);

            if (string.IsNullOrEmpty(serializedInput))
            {
                _playerDataModel = new PlayerDataModel();
                _playerDataModel.Init();
                return;
            }

            _playerDataModel = JsonUtility.FromJson<PlayerDataModel>(serializedInput);
            if ( _playerDataModel == null )
            {
                _playerDataModel = new PlayerDataModel();
                _playerDataModel.Init();
            }

            if(_playerDataModel.langId != -1)
                Lang.Instance.CurLang = (SystemLanguage)_playerDataModel.langId;
        }

        public void SaveTime()
        {
            if (!_isNeedSave)
                StartCoroutine(SaveGameData());

            _isNeedSave = true;
        }

        public void Save()
        {
            if (TheGame.GetComponent<GamePlayer>() == null)
                return;

            _playerDataModel = TheGame.GetComponent<GamePlayer>().GetPlayerData();
            _playerDataModel.langId = (int)Lang.Instance.CurLang;

            var serializedOutput = JsonUtility.ToJson(_playerDataModel);
            
            FileUtils.SaveTextToFile(_fileName, serializedOutput);

            Debug.Log("Save Game");
        }

        public PlayerDataModel GetPlayerData()
        {
            return _playerDataModel;
        }

        #endregion
    }

}