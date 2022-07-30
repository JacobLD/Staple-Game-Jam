using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public bool autostart = false;
    public bool oneShot = false;
    public bool paused = false;
    bool running = false;
    public float timeLeft { get; private set; } = 0.0f;
    public float waitTime { get; private set; } = 1.0f;

    public UnityEvent timeout = new UnityEvent();

    // Update is called once per frame
    void Update()
    {
        if (IsStopped()) return;

        timeLeft -= Time.deltaTime;
        if(timeLeft <= 0)
        {
            timeLeft = 0;
            timeout.Invoke();
            if (oneShot) running = false;
            else timeLeft = waitTime;
        }
    }

    private void Start()
    {
        if (autostart) Start(waitTime);
    }

    public bool IsStopped()
    {
        return paused || !running;
    }

    public void Start(float time)
    {
        if (time <= 0) return; 
        waitTime = time;
        running = true;
    }

    public void Stop()
    {
        running = false;
    }
}
