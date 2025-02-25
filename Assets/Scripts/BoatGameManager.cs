using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoatGameManager : MonoBehaviour
{
    public static int numLives = 3;
    public static int numPoints = 0;

    [SerializeField] GameObject[] livesIndicatorObjects;
    [SerializeField] GameObject endScreenObject;
    [SerializeField] GameObject obstacleContainer;
    [SerializeField] GameObject pool;

    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text scoreText;

    public void ResetGame() {
        numLives = 3;
        numPoints = 0;
        gameOverText.text = "";
        for (int i = 0; i < numLives; i++) {
            livesIndicatorObjects[i].SetActive(true);
        }
        pool.SetActive(true);

        foreach(Transform obstacle in obstacleContainer.transform)
        {
            Destroy(obstacle.gameObject);
        }
        endScreenObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
    }

    public void EndGame() {
        pool.SetActive(false);
        endScreenObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
        gameOverText.text = "Game Over, your score was: " + numPoints;
    }

    public void RemoveLife() {
        numLives--;
        
        if (numLives >= 0 && numLives < livesIndicatorObjects.Length) {
            livesIndicatorObjects[numLives].SetActive(false);
        }

        if (numLives <= 0) { 
            EndGame();
        }
    }

    public void AddPoint() {
        numPoints++;
        scoreText.text = "Score: " + numPoints;
    }
}
