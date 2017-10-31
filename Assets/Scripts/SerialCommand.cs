using UnityEngine;
using System.Collections;
using System;

[System.Serializable]
public class SerialCommand : MonoBehaviour
{

    public string message;
    public Action messageEvent;

    void Start()
    {
        if(messageEvent == null)
        {
            Debug.LogError("There are undescribed events");
        }
    }

    public SerialCommand(string msg, Action evnt)
    {
        message = msg;
        messageEvent = evnt;
    }
}
