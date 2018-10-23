using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour {

    [SerializeField] float waitingPeriod = 3f;

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(waitingPeriod);
        SceneManager.LoadScene("Game Over");
    }
}