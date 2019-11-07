using UnityEngine;
using UnityEngine.SceneManagement;

namespace theGame
{
    class TinyStart : MonoBehaviour
    {
        public static bool IsTinyStart;

        public static string LevelName = "Main";
        
        void Awake()
        {
            if (!TheGame.Inited)
            {
                IsTinyStart = true;

                LevelName = SceneManager.GetActiveScene().name;
                
                SceneManager.LoadScene("_Start");
                return;
            }
           
            Destroy(gameObject);
            
        }

    }
}