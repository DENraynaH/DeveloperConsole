using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R.DeveloperConsole
{
   public class DeveloperConsole : Singleton<DeveloperConsole>
   {

      private bool _isActive;
      private GameObject _consoleInterface;
      private string _lastInput;

      [Header("Settings")] 
      
      [SerializeField] private int _consoleLines;
      [SerializeField] private Vector2 _windowSize;
      [SerializeField] private char _consoleToggle;
      [SerializeField] private bool _logUnityConsole;

      private void Start()
      {
         _consoleInterface = transform.GetChild(0).gameObject;
      }

      public void ToggleConsole()
      {
         if (_consoleInterface.activeSelf) { DisableConsole(); }
         else { EnableConsole(); }
      }

      public void GetInput(string consoleInput)
      {
         _lastInput = consoleInput;
         GetComponent<ConsoleLogger>().LogMessage(consoleInput, LogMode.None);
      }

      private void DisableConsole() => _consoleInterface.SetActive(false);
      private void EnableConsole() => _consoleInterface.SetActive(true);
      
      #region Getters
      public int ConsoleLines => _consoleLines;
      
      #endregion


   }
}
