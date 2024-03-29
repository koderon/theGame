﻿using UnityEngine;

namespace theGame
{


    public static class PathUtils
    {
        public static string Get()
        {
            string path = "";
#if UNITY_IPHONE && !UNITY_EDITOR
	        string fileNameBase = Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/'));
	        path = fileNameBase.Substring(0, fileNameBase.LastIndexOf('/')) + "/Documents/";
#elif UNITY_ANDROID && !UNITY_EDITOR
            path = Application.persistentDataPath + "/";
#else
            path = Application.persistentDataPath + "/";
#endif
            return path;
        }

    }

}