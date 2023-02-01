using System;
using System.Collections;
using System.Collections.Generic;
using R.DeveloperConsole;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private ConsoleCommand _consoleCommand;
    [SerializeField] private ConsoleCommand _listCommands;

    private void OnEnable()
    {
        _listCommands.AssignMethod(ListCommands);
        _consoleCommand.AssignMethod(TestFunction);
    }

    private void OnDisable()
    {
        _listCommands.RemoveMethod(ListCommands);
        _consoleCommand.RemoveMethod(TestFunction);
    }


    private void TestFunction()
    {
        Debug.Log("test function 1");
    }
    
    private void TestFunction2()
    {
        Debug.Log("test function 2");
    }

    private void ListCommands()
    {
        string[] commands = DeveloperConsole.Instance.GetAllCommandPrefix().ToArray();
        foreach (string commandPrefix in commands)
        {
            DeveloperConsole.Instance.ConsoleLogger.LogMessage(commandPrefix, LogMode.General);
        }
    }
    
    
}
