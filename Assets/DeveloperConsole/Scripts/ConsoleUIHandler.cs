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
        [SerializeField] private float _currentScale = 1;
        [SerializeField] private float _scaleMinimum = 0.6f;
        [SerializeField] private float _scaleMaximum = 1.4f;
        [SerializeField] private TextMeshProUGUI _consoleOutput;

        public TextMeshProUGUI ConsoleOutput => _consoleOutput;

        [Header("References")]
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;
        
        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

        public void SetScale(float scale)
        {
            _rectTransform.localScale = new Vector3(scale, scale, scale);
        }

        public void AddScale(float scale)
        {
            _rectTransform.localScale = _rectTransform.localScale + new Vector3(scale, scale, scale);
        }
    }
}

