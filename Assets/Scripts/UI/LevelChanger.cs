using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator anim;

    public string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //public void FadeToNextLevel()
    //{
    //    FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    //}

    public void FadeToLevel(string levelIndex)
    {
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        FadeToLevel(levelToLoad);
    }

    public void LoadLevel()
    {
        FadeToLevel(levelToLoad);
    }

    public void FadeToLevelCounter()
    {
        StartCoroutine(FadeToLevelCo(levelToLoad));
    }

    public IEnumerator FadeToLevelCo(string levelIndex)
    {
        yield return new WaitForSeconds(1.25f);
        levelToLoad = levelIndex;
        anim.SetTrigger("FadeOut");
    }
}
