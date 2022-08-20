using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class InvaderManager : MonoBehaviour
{
    [Header("Flow Handling")]
    [SerializeField] GameData gameData;
    [SerializeField] string gameOverScene;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI livesDisplay;
    [SerializeField] TextMeshProUGUI scoreDisplay;

    [Header("Game Handling")]
    [SerializeField] GameObject enemyPrefab;

    void Start() {
        for(int i = 0; i < 3; i++) {
            for(int j = -4; j < 5; j++) {
                Instantiate(enemyPrefab, new Vector3(j*1.4f, i*1.4f+1.0f, 0.0f), Quaternion.identity);
            }
        }
    }

    void Update() {
        livesDisplay.SetText("Lives Left: {0}", gameData.playerHealthPoints);
        scoreDisplay.SetText("Score: {0}", gameData.score);

        if(gameData.playerHealthPoints == 0) {
            SceneManager.LoadScene(gameOverScene);
        } else if (gameData.enemyCount == 0) {
            gameData.won = true;
            SceneManager.LoadScene(gameOverScene);
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
        if(col.tag == "Enemy") {
            gameData.won = false;
            SceneManager.LoadScene(gameOverScene);
        }
    }
}
