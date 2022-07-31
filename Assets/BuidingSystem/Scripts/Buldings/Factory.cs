using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Factory : GridTile
{
    public int workerCapacity;
    public int currentWorkerCount;

    public float maxIncomePerTick;

    public int currentStorageCapacity;
    public int maxStorageCapacity;

    public UnityEvent onIncomeChanged;
    public UnityEvent onMaxIncome;
    public UnityEvent onEmpty;

    private bool isAtMaxIncome = false;
    private void Start()
    {
        GameManager.instance.onTick.AddListener(OnTick);
    }
    private void OnDestroy()
    {
        GameManager.instance.onTick.RemoveListener(OnTick);
    }
    public void OnTick()
    {
        int Income = GetCurrentIncome();

        currentStorageCapacity += Income;

        if (currentStorageCapacity > maxStorageCapacity)
        {
            if (!isAtMaxIncome)
            {
                onMaxIncome.Invoke();
                onIncomeChanged.Invoke();
                isAtMaxIncome = true;
            }
            currentStorageCapacity = maxStorageCapacity;
        }
        else
        {
            onIncomeChanged.Invoke();
        }
    }
    public void OnEmpty()
    {
        GameManager.instance.SellStaples(currentStorageCapacity);
        currentStorageCapacity = 0;
        onIncomeChanged.Invoke();
    }
    public int GetCurrentIncome()
    {
        return (int)Mathf.Lerp(0, (float)maxIncomePerTick, (float)currentWorkerCount / (float)workerCapacity);
    }
}
