using UnityEngine;
using UnityEngine.SceneManagement;

namespace AZhelnov.Components
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        }
    }
}
