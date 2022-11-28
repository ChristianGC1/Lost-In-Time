using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    [SerializeField]
    public static int heal;
    public Text potion;

    // Start is called before the first frame update
    void Start()
    {
        heal = PlayerPrefs.GetInt("hMany");
    }

    // Update is called once per frame
    void Update()
    {
        potion.text = " " + heal;
    }
}
