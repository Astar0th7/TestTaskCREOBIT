using Game.Scripts.GameRoot.Services.SceneLoader;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Menu.UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private Button _gameFirstButton;
        [SerializeField] private Button _gameSecondButton;
        
        private ISceneLoaderService _sceneLoaderService;

        private void Start()
        {
            _sceneLoaderService = ServiceLocator.Instance.Resolve<ISceneLoaderService>();
        }

        private void OnEnable()
        {
            _gameFirstButton.onClick.AddListener(OnGameFirstButtonClick);
            _gameSecondButton.onClick.AddListener(OnGameSecondButtonClick);
        }

        private void OnDisable()
        {
            _gameFirstButton.onClick.RemoveListener(OnGameFirstButtonClick);
            _gameSecondButton.onClick.RemoveListener(OnGameSecondButtonClick);
        }

        private void OnGameFirstButtonClick()
        {
            _sceneLoaderService.LoadScene(Scenes.GAME_FIRST);
        }

        private void OnGameSecondButtonClick()
        {
            _sceneLoaderService.LoadScene(Scenes.GAME_SECOND);
        }
    }
}