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

        [Header("References")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private TextMeshProUGUI _consoleOutput;
        [SerializeField] private TextMeshProUGUI _consoleInput;

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
            if (_rectTransform.localScale.x + scale > _scaleMaximum) { return; }
            SetScale(_rectTransform.localScale.x + scale);
        }

        public void SubtractScale(float scale)
        {
            if (_rectTransform.localScale.x + scale < _scaleMinimum) { return; }
            SetScale(_rectTransform.localScale.x - scale);
        }

        public void ClearInput()
        {
            Debug.Log("clearing input field");
            _consoleInput.text = String.Empty;
        }

        #region Get

        public TextMeshProUGUI ConsoleOutput => _consoleOutput;

        #endregion
        
    }
}

