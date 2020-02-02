using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public Animator transition;
    public Animator hideLevel;
    public float transitionTime = 1f;

    WinCondition winmat;

    bool win;
    bool conversationEnded;

    private void Start()
    {
        winmat = FindObjectOfType<WinCondition>();
    }
    // Update is called once per frame
    void Update()
    {
        win = winmat.win;
        conversationEnded = winmat.conversationDone;

        if (win)
        {
            HideLevel();
        }

        if (conversationEnded)
        {
            LoadNextLevel();
        }
    }

    public void HideLevel()
    {
        StartCoroutine(hidePlayArea());
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int index)
    {
        //Play animation
        transition.SetTrigger("Start");

        //wait for animation to complete
        yield return new WaitForSeconds(transitionTime);

        //load next scene
        SceneManager.LoadScene(index);
    }

    IEnumerator hidePlayArea()
    {
        yield return new WaitForSeconds(transitionTime);
        hideLevel.SetTrigger("Start");
    }
}
