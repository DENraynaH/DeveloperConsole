using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


namespace  R.DeveloperConsole
{
    public class ConsoleUIHandler : MonoBehaviour, IDragHandler
    {
        [SerializeField] private float _UIscale = 1;
        [SerializeField] private float _UIscaleMin = 0.6f;
        [SerializeField] private float _UIscaleMax = 1.4f;

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

