using Game.Scripts.GameRoot.Services.SceneLoader;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root;
using Game.Scripts.Root.Services.Progress;
using Game.Scripts.Root.Services.SaveLoad;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Menu.UI
{
    public class UIGameFirstPopup : MonoBehaviour, IPopup
    {
        [SerializeField] private Button _loadButton;
        [SerializeField] private Button _unloadButton;

        private ISaveLoadService _saveLoadService;
        private ISceneLoaderService _sceneLoaderService;
        private IProgressService _progressService;

        private void Start()
        {
            _saveLoadService = ServiceLocator.Instance.Resolve<ISaveLoadService>();
            _sceneLoaderService = ServiceLocator.Instance.Resolve<ISceneLoaderService>();
            _progressService = ServiceLocator.Instance.Resolve<IProgressService>();
        }

        private void OnEnable()
        {
            _loadButton.onClick.AddListener(OnLoadButtonClick);
            _unloadButton.onClick.AddListener(OnUnloadButtonClick);
        }

        private void OnDisable()
        {
            _loadButton.onClick.RemoveListener(OnLoadButtonClick);
            _unloadButton.onClick.RemoveListener(OnUnloadButtonClick);
        }

        public void Show()
        {
            gameObject.SetActive(true);   
        }

        public void Hide()
        {
            gameObject.SetActive(false);   
        }

        private void OnLoadButtonClick()
        {
            LoadGame();
        }

        private void OnUnloadButtonClick()
        {
            _progressService.Data.GameFirstData.Reset();
            _saveLoadService.Save();
            LoadGame();
        }

        private void LoadGame()
        {
            _sceneLoaderService.LoadScene(Scenes.GAME_FIRST);
        }
    }
}