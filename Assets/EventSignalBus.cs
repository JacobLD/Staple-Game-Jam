using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSignalBus : MonoBehaviour
{

    #region Singleton Stuff
    public static EventSignalBus instance;

    private void Awake()
    {
        instance = this;

        EventDict.Add(Events.FactoryBuildSelected, FactoryBuildSelectedEvent);
        EventDict.Add(Events.HouseBuildSelected, HouseBuildSelectedEvent);
        EventDict.Add(Events.WarehouseBuildSelected, WarehouseBuildSelectedEvent);
        EventDict.Add(Events.NothingBuildSelected, NothingBuildSelectedEvent);
    }

    #endregion

    UnityEvent FactoryBuildSelectedEvent = new UnityEvent();
    UnityEvent HouseBuildSelectedEvent = new UnityEvent();
    UnityEvent WarehouseBuildSelectedEvent = new UnityEvent();
    UnityEvent NothingBuildSelectedEvent = new UnityEvent();

    [SerializeField]
    public enum Events
    {
        FactoryBuildSelected,
        HouseBuildSelected,
        WarehouseBuildSelected,
        NothingBuildSelected
    }

    public Dictionary<Events, UnityEvent> EventDict = new();

    public void Invoke(Events e){
        if (EventDict.TryGetValue(e, out UnityEvent value))
        {
            value.Invoke();
        }
    }

    public bool SubscribeTo(Events e, UnityAction a)
    {
        if (EventDict.TryGetValue(e, out UnityEvent value))
        {
            value.AddListener(a);
            return true;
        }

        return false;
    }

    public bool UnsubscribeTo(Events e, UnityAction a)
    {
        if (EventDict.TryGetValue(e, out UnityEvent value))
        {
            value.RemoveListener(a);
            return true;
        }

        return false;
    }
}
