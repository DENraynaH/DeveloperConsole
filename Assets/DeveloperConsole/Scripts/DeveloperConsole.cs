using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

namespace R.DeveloperConsole
{
   public class DeveloperConsole : Singleton<DeveloperConsole>
   {

      private bool _isActive;
      private GameObject _consoleInterface;
      private string _lastCommand;

      [Header("Settings")] 
      [SerializeField] private List<ConsoleCommand> _consoleCommands;
      [SerializeField] private int _consoleLines;
      [SerializeField] private Vector2 _windowSize;
      [SerializeField] private char _consoleToggle;
      [SerializeField] private bool _logUnityConsole;

      private void Start()
      {
         Debug.Log(_consoleCommands[0].CommandPrefix);
         _consoleInterface = transform.GetChild(0).gameObject;
      }

      public void ToggleConsole()
      {
         if (_consoleInterface.activeSelf) { DisableConsole(); }
         else { EnableConsole(); }
      }

      public void GetInput(string consoleInput)
      {
         _lastCommand = consoleInput;
         GetComponent<ConsoleLogger>().LogMessage(consoleInput, LogMode.UserTyped);
         ExecuteCommand();
      }

      private void ExecuteCommand()
      {
         string commandPrefix = ConsoleUtilities.GetPrefix(_lastCommand);
         string[] commandArguments = ConsoleUtilities.GetArguments(_lastCommand);
         
         ConsoleCommand currentCommand = GetCommand(commandPrefix);
         if (currentCommand == null)
         {
            GetComponent<ConsoleLogger>().LogMessage("Command Not Found!", LogMode.Error);
            return;
         }
         currentCommand.Execute(commandArguments);
      }
      
      private ConsoleCommand GetCommand(string commandPrefix)
      {
         return _consoleCommands.FirstOrDefault(consoleCommand => consoleCommand.CommandPrefix == commandPrefix);
      }

      private void DisableConsole() => _consoleInterface.SetActive(false);
      private void EnableConsole() => _consoleInterface.SetActive(true);
      
      #region Getters
      public int ConsoleLines => _consoleLines;
      
      #endregion
      
   }
}
