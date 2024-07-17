﻿using Game.Scripts.GameRoot.Services.SceneLoader;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root;
using Game.Scripts.Root.Services.Progress;
using Game.Scripts.Root.Services.SaveLoad;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.GameFirst.UI
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scopeText;
        [SerializeField] private Button _menuButton;

        private ISaveLoadService _saveLoadService;
        private ISceneLoaderService _sceneLoaderService;
        private IProgressService _progressService;

        private void Start()
        {
            _saveLoadService = ServiceLocator.Instance.Resolve<ISaveLoadService>();
            _sceneLoaderService = ServiceLocator.Instance.Resolve<ISceneLoaderService>();
            _progressService = ServiceLocator.Instance.Resolve<IProgressService>();
            _progressService.Data.GameFirstData.ClickCountValueChangeEvent += OnClickCountValueChange;
            OnClickCountValueChange(_progressService.Data.GameFirstData.ClickCount);
        }

        private void OnEnable()
        {
            _menuButton.onClick.AddListener(OnMenuButtonClick);
        }

        private void OnDisable()
        {
            _menuButton.onClick.RemoveListener(OnMenuButtonClick);
        }

        private void OnDestroy()
        {
            if (_progressService == null)
                return;
            
            _progressService.Data.GameFirstData.ClickCountValueChangeEvent -= OnClickCountValueChange;
        }

        private void OnMenuButtonClick()
        {
            _saveLoadService.Save();
            _sceneLoaderService.LoadScene(Scenes.MENU);
        }

        private void OnClickCountValueChange(int amount)
        {
            _scopeText.text = amount.ToString();
        }
    }
}