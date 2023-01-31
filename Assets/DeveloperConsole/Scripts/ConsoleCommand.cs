using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


public class ConsoleCommand : ScriptableObject
{
    [SerializeField] private string _commandPrefix;
    public string CommandPrefix => _commandPrefix;

    public virtual void Execute(string[] args)
    {
        throw new System.NotImplementedException();
    }
}
