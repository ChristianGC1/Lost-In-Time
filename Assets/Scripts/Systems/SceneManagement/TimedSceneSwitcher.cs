using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TimedSceneSwitcher : MonoBehaviour
{
    public float changeTime;

    public UnityEvent onSceneChanged;

    // Update is called once per frame
    void Update()
    {
        changeTime -= Time.deltaTime;
        if (changeTime <= 0)
        {
            onSceneChanged?.Invoke();
        }
    }
}
