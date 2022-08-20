using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] GameData gameData;

    [SerializeField] string gameScene;

    [Header("Win/Lose Display")]
    [SerializeField] string winText;
    [SerializeField] string loseText;
    [SerializeField] TextMeshProUGUI winLoseObject;

    [Header("Score Display")]
    [SerializeField] TextMeshProUGUI scoreObject;

    void Start() {
        scoreObject.SetText("Score: {0}", gameData.score);

        if(gameData.won) winLoseObject.text = winText;
        else winLoseObject.text = loseText;
    }

    public void Restart() {
        gameData.playerHealthPoints = 3;
        gameData.score = 0;
        gameData.won = false;
        gameData.enemyCount = 27;

        SceneManager.LoadScene(gameScene);
    }

    public void Exit() {
        Application.Quit();
    }
}
