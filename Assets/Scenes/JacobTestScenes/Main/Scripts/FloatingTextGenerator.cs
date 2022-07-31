using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTextGenerator : MonoBehaviour
{
    [Header("Floating Text Props")]
    public GameObject floatingTextPrefab;
    [Range(0.1f, 10.0f)]
    public float lifetime = 1.0f;
    [Range(0.1f, 100.0f)]
    public float maxHeight = 10.0f;
    [Range(0.1f, 100.0f)]
    public float maxWiggle = 1.0f;
    [Range(6, 24)]
    public float maxTextSize = 6;
    [Range(0, 6)]
    public float minTextSize = 6;
    [Range(0, 50)]
    public float minValueSize = 50;
    [Range(50, 100)]
    public float maxValueSize = 50;


    [Header("Debugging")]
    public bool testing = false;
    float timeBetweenValues = 2.0f;
    Timer timer;

    private void Awake()
    {
        if (!testing) return;
        timer = gameObject.AddComponent<Timer>();
    }

    private void Start()
    {
        if (!testing) return;
        timer.timeout.AddListener(DebugGenerate);
        timer.Start(timeBetweenValues);
    }

    private void OnDestroy()
    {
        timer.timeout.RemoveAllListeners();
    }

    public void DebugGenerate()
    {
        int value = (int)Random.Range(minValueSize, maxValueSize);
        float fontSize = Mathf.Lerp(minTextSize, maxTextSize, value / (maxValueSize - minValueSize));
        Generate(value.ToString(), fontSize);
    }

    public void Generate(string s, float size)
    {
        GameObject floater = Instantiate(floatingTextPrefab);
        FloatingText text = floater.GetComponent<FloatingText>();

        text.maxHeight = maxHeight;
        text.maxWiggle = maxWiggle;
        text.lifetime = lifetime;

        text.SetTextSize(size);
        text.SetText(s);
    }
}
