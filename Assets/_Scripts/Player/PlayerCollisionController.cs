using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionController : MonoBehaviour
{
    public static UnityAction Collision;
    private void OnCollisionEnter(Collision collision) //При соприкосновении с преградой инвокаю ивент
    {
        Collision?.Invoke();
    }

    private void OnDestroy()
    {
        Collision = null;
    }
}
