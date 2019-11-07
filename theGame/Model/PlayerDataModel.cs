using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace theGame
{
    
    [Serializable]
    public class PlayerDataModel
    {
        public void Init()
        {
            
        }

        public int langId = -1;
        public float soundVolume = 1.0f;
        public bool activeSound = true;
    }
}