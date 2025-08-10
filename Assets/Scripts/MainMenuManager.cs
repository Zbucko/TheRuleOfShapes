using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] AudioSource clickFX;
    public void StartGame()
    {
        StartCoroutine(PlaySound(2));
      
    }

    public void StartTutorial()
    {
        StartCoroutine(PlaySound(1));
    }

    public void Exit()
    {
        StartCoroutine(PlaySound(3));
    }

    IEnumerator PlaySound(int sceneNum)
    {
        clickFX.Play();
        yield return new WaitForSeconds(1f);
        if (sceneNum == 3)
        {
            Application.Quit();
        }
        else
        {
            SceneManager.LoadScene(sceneNum);
        }
        
    }

}
