using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void StartTutorial()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }

}
