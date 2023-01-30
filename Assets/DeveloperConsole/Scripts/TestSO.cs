using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "TestSO", menuName = "TestSO", order = 0)]
public class TestSO : ScriptableObject
{
    public UnityEvent _event;
    public string _name;
}
