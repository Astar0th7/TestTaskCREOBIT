using System.Collections;
using Game.Scripts.GameRoot.Services.SceneLoader;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root.Services.Progress;
using Game.Scripts.Utils;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Scripts.Root
{
    public class GameEntryPoint
    {
        private static GameEntryPoint _instance;
        private readonly ISceneLoaderService _sceneLoader;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            Application.targetFrameRate = 60;
            Screen.sleepTimeout = SleepTimeout.NeverSleep;


            _instance = new GameEntryPoint();
            _instance.RunGame();
        }

        private GameEntryPoint()
        {
            _sceneLoader = ServiceLocator.Instance.RegisterSingle<ISceneLoaderService>(new SceneLoaderService());
            ServiceLocator.Instance.RegisterSingle<IProgressService>(new ProgressService());
        }

        private void RunGame()
        {
#if UNITY_EDITOR
            string sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == Scenes.MENU)
            {
                LoadAndStartMenu();
                return;
            }

            if (sceneName == Scenes.GAME_FIRST)
            {
               LoadAndStartGameFirst();
                return;
            }

            if (sceneName == Scenes.GAME_SECOND)
            {
                LoadAndStartGameSecond();
                return;
            }

            if (sceneName != Scenes.BOOT)
            {
                return;
            }
#endif
            LoadAndStartMenu();
        }

        private void LoadAndStartMenu()
        {
            _sceneLoader.LoadScene(Scenes.MENU);
        }
        
        private void LoadAndStartGameFirst()
        {
            _sceneLoader.LoadScene(Scenes.GAME_FIRST);
        }
        
        private void LoadAndStartGameSecond()
        {
            _sceneLoader.LoadScene(Scenes.GAME_SECOND);
        }
    }
}
