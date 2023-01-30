using System;
using System.Collections;
using TMPro;
using UnityEngine;


namespace R.DeveloperConsole
{
    public class ConsoleLogger : MonoBehaviour
    {

        private DeveloperConsole _developerConsole; 
        private readonly Queue _logQueue = new Queue();
        [SerializeField] private TextMeshProUGUI _consoleOutput;
        [SerializeField] private uint _consoleLines;
        
        private void Awake()
        {
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

        public void HandleCommandLog(string logMessage, LogMode logMode)
        {
            switch (logMode)
            {
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
            while (_logQueue.Count > _consoleLines) { _logQueue.Dequeue(); }
        }
   
        private void OutputDebugMessages()
        {
            _consoleOutput.text = string.Join("\n", _logQueue.ToArray());
        }
        
    }

    public enum LogMode
    {
        Command,
        Warning,
        Error, 
        General,
        Executed
    }
    
}
