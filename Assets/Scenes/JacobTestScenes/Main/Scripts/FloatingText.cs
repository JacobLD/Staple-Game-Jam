using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]
public class FloatingText : MonoBehaviour
{
    [Range(0.1f, 10.0f)]
    public float lifetime = 1.0f;
    [Range(0.1f, 100.0f)]
    public float maxHeight = 10.0f;
    [Range(0.1f, 100.0f)]
    public float maxWiggle = 1.0f;
    


    TextMeshPro text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshPro>();
    }

    private void Start()
    {
        LeanTween.moveY(gameObject, transform.position.y + maxHeight, lifetime).setOnComplete(OnTweenComplete);
        if(maxWiggle > 0)
        {
            LTSeq seq = LeanTween.sequence();
            seq.append(LeanTween.moveX(gameObject, transform.position.x + maxWiggle, lifetime / 2.0f).setEaseInQuad());
            seq.append(LeanTween.moveX(gameObject, transform.position.x - maxWiggle, lifetime / 2.0f).setEaseInOutQuad());
        }
    }

    void OnTweenComplete()
    {
        Destroy(gameObject);
    }

    public void SetText(string s)
    {
        text.SetText(s);
    }

    public void SetTextSize(float size)
    {
        text.fontSize = size;
    }
}
