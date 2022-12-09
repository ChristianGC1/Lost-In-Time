using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCaller : MonoBehaviour
{
    public UnityEvent start;
    public UnityEvent startTwo;
    public UnityEvent startThree;
    public UnityEvent startFour;

    public SpriteChanger changer;

    public float timer;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 25)
        {
            startTwo?.Invoke();
        }
        if (timer <= 22.5)
        {
            startThree?.Invoke();
        }
        if (timer <= 15)
        {
            startFour?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        start?.Invoke();
        changer.enabled = false;
    }

    public void ChangeScene()
    {
        GetComponent<LevelChanger>().FadeToLevel("End Scene");
    }
}
