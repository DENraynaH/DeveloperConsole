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
      private ConsoleLogger _consoleLogger;
      private bool _isActive;
      private GameObject _consoleInterface;
      private string _lastCommand;

      [Header("Settings")] 
      [SerializeField] private List<ConsoleCommand> _consoleCommands;
      [SerializeField] private int _consoleLines;
      [SerializeField] private Vector2 _windowSize;
      [SerializeField] private char _consoleToggle;
      
      //This needs decoupling, potentially scriptable object.
      [SerializeField] private bool _enableUnityLogging;
      public bool EnableUnityLogging => _enableUnityLogging;

      private void Start()
      {
         _consoleInterface = transform.GetChild(0).gameObject;
         _consoleLogger = GetComponent<ConsoleLogger>();
      }

      public void ToggleConsole()
      {
         if (_consoleInterface.activeSelf) { DisableConsole(); }
         else { EnableConsole(); }
      }

      public List<string> GetAllCommandPrefix()
      {
         List<string> commandNames = new List<string>();
         foreach (ConsoleCommand consoleCommand in _consoleCommands)
         {
            commandNames.Add(consoleCommand.CommandPrefix);
         }
         return commandNames;
      }

      public void GetInput(string consoleInput)
      {
         _lastCommand = consoleInput;
         _consoleLogger.LogMessage(consoleInput, LogMode.UserTyped);
         ExecuteCommand();
      }

      private void ExecuteCommand()
      {
         string commandPrefix = ConsoleUtilities.GetPrefix(_lastCommand);
         string[] commandArguments = ConsoleUtilities.GetArguments(_lastCommand);
         
         ConsoleCommand currentCommand = GetCommand(commandPrefix);
         if (currentCommand == null)
         {
            _consoleLogger.LogMessage("Command Not Found!", LogMode.Error);
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
      public ConsoleLogger ConsoleLogger => _consoleLogger;
      
      #endregion

   }
}
