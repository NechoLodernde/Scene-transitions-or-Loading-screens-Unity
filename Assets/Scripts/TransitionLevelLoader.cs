using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionLevelLoader : MonoBehaviour
{
    public Animator Transition;

    public float transitionTime = 1f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }    
    }

    public void LoadNextLevel()
    {
        if (LastScene(SceneManager.GetActiveScene().buildIndex))
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        } 
        else
        {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play Animation
        Transition.SetTrigger("Start");

        // Wait Animation
        yield return new WaitForSeconds(transitionTime);

        // Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    private bool LastScene(int currentIndex)
    {
        bool result = true;
        int lastIndex = SceneManager.sceneCountInBuildSettings - 1;
        Debug.Log("Last index is: " + lastIndex);
        if (currentIndex < lastIndex)
        {
            result = false;
        }

        return result;
    }
}
