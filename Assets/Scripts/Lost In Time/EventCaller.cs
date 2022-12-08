using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCaller : MonoBehaviour
{
    public UnityEvent start;
    public UnityEvent startTwo;

    public SpriteChanger changer;

    public void Start()
    {
        startTwo?.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        start?.Invoke();
        changer.enabled = false;
    }
}
