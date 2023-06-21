using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField]
    private Text scoreText;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score;
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }
}
