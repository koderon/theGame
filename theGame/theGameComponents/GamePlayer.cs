using System;
using System.Collections;
using System.Collections.Generic;
using theGame;
using UnityEngine;

namespace theGame
{
    
    public class GamePlayer : TheGameComponent
    {
        private PlayerDataModel _playerDataModel;
        
        public override void Init()
        {
            var playerData = TheGame.GetComponent<GameData>().GetPlayerData();
            _playerDataModel = playerData;
        }

        public PlayerDataModel GetPlayerData()
        {
            return _playerDataModel;
        }

        public void NewGame()
        {
            _playerDataModel.Init();
            SaveGame();
        }

        public void SetSoundVolume(float volume)
        {
            _playerDataModel.soundVolume = volume;
            SaveGame();
        }

        public float GetSoundVolume()
        {
            return _playerDataModel.soundVolume;
        }

        public void SetActiveSound(bool muted)
        {
            _playerDataModel.activeSound = muted;
            SaveGame();
        }

        public bool GetActiveSound()
        {
            return _playerDataModel.activeSound;
        }

        public void SaveGame()
        {
            TheGame.GetComponent<GameData>().SaveTime();
        }


    }

}