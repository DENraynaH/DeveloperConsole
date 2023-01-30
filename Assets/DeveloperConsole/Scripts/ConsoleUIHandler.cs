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
        [SerializeField] private Canvas _canvas;
        [SerializeField] private RectTransform _rectTransform;

        public void OnDrag(PointerEventData eventData)
        {
            _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        }

    }
}

