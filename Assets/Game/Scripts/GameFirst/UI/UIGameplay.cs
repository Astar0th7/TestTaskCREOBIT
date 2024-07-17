using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using Game.Scripts.GameRoot.Services.ServiceLocator;
using Game.Scripts.Root.Services.Progress;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.GameFirst.UI
{
    public class UIGameplay : MonoBehaviour
    {
        [SerializeField] private TMP_Text _clickText;
        [SerializeField] private float _duration = 0.2f;
        [SerializeField] private Button _gooseButton;
        [SerializeField] private float _scaleGooseModify = 0.8f;

        private IProgressService _progressService;
        
        private Tween _tweenText;
        private Tween _tweenGoose;
        private float _scaleModify = 1.5f;

        private void Start()
        {
            _progressService = ServiceLocator.Instance.Resolve<IProgressService>();
        }

        private void OnEnable()
        {
            _gooseButton.onClick.AddListener(OnGooseButtonClick);
            _tweenText = _clickText.transform.DOScale(Vector3.one * _scaleModify, _duration).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDisable()
        {
            _gooseButton.onClick.RemoveListener(OnGooseButtonClick);
            _tweenText?.Kill();
        }

        private void OnGooseButtonClick()
        {
            _tweenGoose?.Kill();
            _gooseButton.transform.localScale = Vector3.one;
            _tweenGoose = _gooseButton.transform.DOScale(Vector3.one * _scaleGooseModify, 0.1f).SetEase(Ease.Linear).SetLoops(2, LoopType.Yoyo);
            _progressService.Data.GameFirstData.Click();
        }
    }
}