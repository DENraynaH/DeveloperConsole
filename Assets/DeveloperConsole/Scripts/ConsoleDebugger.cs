using System;
using System.Collections;
using System.Collections.Generic;
using R.DeveloperConsole;
using UnityEngine;
using Random = UnityEngine.Random;

public class ConsoleDebugger : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("your random number is " + Random.Range(1, 1000));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            GetComponent<ConsoleLogger>().HandleCommandLog("command example", LogMode.Command);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            DeveloperConsole.Instance.ToggleConsole();
        }
    }
}
