using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace R.DeveloperConsole
{
    public class ConsoleLogger : MonoBehaviour
    {

        private DeveloperConsole _developerConsole;
        private ConsoleUIHandler _consoleUIHandler;
        
        private readonly Queue _logQueue = new Queue();

        private void Awake()
        {
            _consoleUIHandler = GetComponent<ConsoleUIHandler>();
            _developerConsole = GetComponent<DeveloperConsole>();
        }

        private void OnEnable()
        {
            Application.logMessageReceived += HandleLog;
        }

        private void OnDisable()
        {
            Application.logMessageReceived -= HandleLog;
        }
        
        private void OnGUI()
        {
            OutputDebugMessages();
        }

        private void HandleLog(string logMessage, string stackTrace, LogType logType)
        {
            _logQueue.Enqueue($"[{logType}] : {logMessage}");
            CleanLog();
        }

        public void LogMessage(string logMessage, LogMode logMode)
        {
            switch (logMode)
            {
                case LogMode.UserTyped:
                    _logQueue.Enqueue($"{logMessage}");
                    break;
                case LogMode.Command:
                    _logQueue.Enqueue($"[Command] {logMessage}");
                    break;
                case LogMode.Warning:
                    _logQueue.Enqueue($"[Warning] {logMessage}");
                    break;
                case LogMode.Error:
                    _logQueue.Enqueue($"[Error] {logMessage}");
                    break;
                case LogMode.General:
                    _logQueue.Enqueue($"[General] {logMessage}");
                    break;
                case LogMode.Executed:
                    _logQueue.Enqueue($"[Executed] {logMessage}");
                    break;
            }
            CleanLog();
        }

        private void CleanLog()
        {
            while (_logQueue.Count > _developerConsole.ConsoleLines) { _logQueue.Dequeue(); }
        }
   
        private void OutputDebugMessages()
        {
            _consoleUIHandler.ConsoleOutput.text = string.Join("\n", _logQueue.ToArray());
        }
        
    }

    public enum LogMode
    {
        UserTyped,
        Command,
        Warning,
        Error, 
        General,
        Executed
    }
    
}
