using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBusInvoker : MonoBehaviour
{

    public EventSignalBus.Events EventType;

    public void Invoke()
    {
        EventSignalBus.instance.Invoke(EventType);
    }
}
