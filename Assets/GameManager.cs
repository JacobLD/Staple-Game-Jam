using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public float money;
    public float price;
    public float incomePerTick;
    private Timer timer;
    public static GameManager instance;

    public UnityEvent onMoneyChanged;

    public float TickRate;
    public UnityEvent onTick;
    private void Awake()
    {
        timer = GetComponent<Timer>();
        instance = this;
    }
    private void Start()
    {
        timer.timeout.AddListener(Tick);
        timer.Start(TickRate);
    }
    public void UpdateMoney(float amount)
    {
        money += amount;
        onMoneyChanged.Invoke();
    }

    public void SellStaples(int amount)
    {
        money += (amount * price);
        onMoneyChanged.Invoke();
    }

    public void Tick()
    {
        onTick.Invoke();
    }
}
