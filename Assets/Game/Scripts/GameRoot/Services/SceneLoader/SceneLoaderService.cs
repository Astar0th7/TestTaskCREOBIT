using System.Collections;
using Game.Scripts.Root;
using Game.Scripts.Utils;
using UnityEngine.SceneManagement;

namespace Game.Scripts.GameRoot.Services.SceneLoader
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public void LoadScene(string sceneName)
        {
            Coroutines.Instance.StartCoroutine(Load(sceneName));
        }
        
        private IEnumerator Load(string sceneName)
        {
            yield return LoadSceneRoutine(Scenes.BOOT);
            yield return LoadSceneRoutine(sceneName);
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}