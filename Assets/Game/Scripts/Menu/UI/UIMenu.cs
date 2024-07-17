using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.Menu.UI
{
    public class UIMenu : MonoBehaviour
    {
        [SerializeField] private UIGameFirstPopup _gameFirstPopup;
        [SerializeField] private UIGameSecondPopup _gameSecondPopup;
        [SerializeField] private Button _gameFirstButton;
        [SerializeField] private Button _gameSecondButton;

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
            _gameFirstPopup.Show();
        }

        private void OnGameSecondButtonClick()
        {
            _gameSecondPopup.Show();
        }
    }
}