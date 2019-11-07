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
        private float _timeToNextSave = 0.0f;
        private const float _constWaitTime = 2.0f;

        private string _fileName = Application.identifier + ".data";

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            UpdateSaveTime();
        }

        public override void Init()
        {
            Load();

            //StartCoroutine(SaveGameData());
        }

        private void UpdateSaveTime()
        {
            if (_isNeedSave)
            {
                _timeToNextSave -= Time.deltaTime;
                if (_timeToNextSave <= 0)
                {
                    Save();
                    _isNeedSave = false;
                }
            }
        }

        #region Save / Load
        private IEnumerator SaveGameData()
        {
            while (true)
            {
                yield return new WaitForSeconds(60);

                Save();
            }
        }

        void Load()
        {
            var path = Helper.GetPathToFileDirectory() + _fileName;
            var serializedInput = "";

            if (File.Exists(path))
            {
                var fileReader = new StreamReader(path, Encoding.ASCII);
                serializedInput = fileReader.ReadLine();
                fileReader.Close();
            }

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
                Lang.Instance.SetLang((SystemLanguage)_playerDataModel.langId);
        }

        public void SaveTime()
        {
            _isNeedSave = true;
            _timeToNextSave = _constWaitTime;
        }

        public void Save()
        {
            if (TheGame.GetComponent<GamePlayer>() == null)
                return;

            _playerDataModel = TheGame.GetComponent<GamePlayer>().GetPlayerData();
            _playerDataModel.langId = (int)Lang.Instance.CurLang;

            StreamWriter fileWriter = null;
            fileWriter = File.CreateText(Helper.GetPathToFileDirectory() + _fileName);

            var serializedOutput = JsonUtility.ToJson(_playerDataModel);
            //Debug.Log(serializedOutput);

            fileWriter.WriteLine(serializedOutput);
            fileWriter.Close();

            Debug.Log("Save Game");
        }

        public PlayerDataModel GetPlayerData()
        {
            return _playerDataModel;
        }

        #endregion
    }

}