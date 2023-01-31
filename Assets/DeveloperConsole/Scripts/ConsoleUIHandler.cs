using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


namespace  R.DeveloperConsole
{
    public class ConsoleUIHandler : MonoBehaviour, IDragHandler
    {
        [SerializeField] private float _scaleMinimum = 0.6f;
        [SerializeField] private float _scaleMaximum = 1.4f;
        [SerializeField] private TextMeshProUGUI _consoleOutput;
        private float _currentScale => _rectTransform.localScale.x;

        public TextMeshProUGUI ConsoleOutput => _consoleOutput;

        [Header("References")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }
        
        private void SetScale(float scale)
        {
            _rectTransform.localScale = new Vector3(scale, scale, scale);
        }

        public void AddScale(float scale)
        {
            if (_currentScale + scale > _scaleMaximum) { return; }
            SetScale(_rectTransform.localScale.x + scale);
        }

        public void SubtractScale(float scale)
        {
            if (_currentScale + scale < _scaleMinimum) { return; }
            SetScale(_rectTransform.localScale.x - scale);
        }
    }
}

