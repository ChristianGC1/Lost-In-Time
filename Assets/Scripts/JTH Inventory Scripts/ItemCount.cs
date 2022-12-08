using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    [SerializeField]
    public static int heal;
    [SerializeField]
    public static int enemiesEliminated;
    public Text potion;
    public Text enemiesDead;

    public SpriteChanger sc;

    // Start is called before the first frame update
    void Start()
    {
        heal = PlayerPrefs.GetInt("hMany");
        enemiesEliminated = 0;
    }

    // Update is called once per frame
    void Update()
    {
        potion.text = " " + heal;
        enemiesDead.text = " " + enemiesEliminated;
        CheckEnemies();
        Debug.Log(enemiesEliminated);
    }

    public void CheckEnemies()
    {
        if(enemiesEliminated >= 6)
        {
            sc.ChangeSpriteOne();
            GetComponent<SpriteChanger>().ChangeSpriteOne();
        }
    }

    public void AddEnemy()
    {
        enemiesEliminated+=1;
    }
}
