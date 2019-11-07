using UnityEngine;
using UnityEngine.SceneManagement;

namespace theGame
{
    class Startup : MonoBehaviour
    {
        [SerializeField] private string _loadLevel = "Main";
        [SerializeField] private bool _publishingBuild = true;
        [SerializeField] private bool _testAds = true;

        public GameObject SystemGameObject;

        public static string LoadLevelAfterAuth = "Main";

        public static bool PublishingBuild = true;
        public static bool TestADS = true;
        
        // Use this for initialization
        public void Awake()
        {
            Debug.Log("############### -= loading scene : " + SceneManager.GetActiveScene().name + " =- ###############");

            Screen.fullScreen = true;  

            if (!TheGame.Inited)  
            {
                if (TinyStart.IsTinyStart)
                {
                    Debug.Log("Tiny start");

                    TinyStart.IsTinyStart = false;

                    LoadLevelAfterAuth = TinyStart.LevelName;
                }
                else
                {
                    LoadLevelAfterAuth = _loadLevel;
                }

                TheGame.Instance.Init();

                PublishingBuild = _publishingBuild;
                TestADS = _testAds;
            }
            

            DontDestroyOnLoad(SystemGameObject);

            Debug.Log("scene name := " + LoadLevelAfterAuth);

            SceneManager.LoadScene(LoadLevelAfterAuth);

            Application.runInBackground = true;
        }
    }

}