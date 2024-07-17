using Game.Scripts.GameRoot.Services.SceneLoader;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.GameFirst.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private Button _menuButton;
        
        private ISceneLoaderService _sceneLoaderService;

        private void Start()
        {
            _sceneLoaderService = ServiceLocator.Instance.Resolve<ISceneLoaderService>();
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        }

        private void OnMenuButtonClick()
        {
            _sceneLoaderService.LoadScene(Scenes.MENU);
        }
    }
}