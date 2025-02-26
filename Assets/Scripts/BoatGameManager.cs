using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BoatGameManager : MonoBehaviour
{
    public static int numLives = 3;
    public static int numPoints = 0;

    [SerializeField] GameObject[] livesIndicatorObjects;
    [SerializeField] GameObject[] crateImages;
    [SerializeField] GameObject endScreenObject;
    [SerializeField] GameObject gameScreenObject;
    [SerializeField] GameObject obstacleContainer;
    [SerializeField] GameObject pool;

    [SerializeField] TMP_Text gameOverText;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;

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
        for (int i = 0; i < crateImages.Length; i++) {
            crateImages[i].GetComponent<RawImage>().color = new Color(85, 85, 85);
        }
        endScreenObject.SetActive(false);
        gameScreenObject.SetActive(true);
    }

    public void EndGame() {
        pool.SetActive(false);
        endScreenObject.SetActive(true);
        gameScreenObject.SetActive(false);
        gameOverText.text = "Game Over, your score was: " + numPoints;
    }

    public void RemoveLife() {
        numLives--;
        
        if (numLives >= 0 && numLives < livesIndicatorObjects.Length) {
            livesIndicatorObjects[numLives].SetActive(false);
        }

        if (numLives >= 0) {
            lifeText.text = "Lives: " + numLives + "/" + livesIndicatorObjects.Length;
        }

        if (numLives <= 0) { 
            EndGame();
        }
    }

    public void AddPoint() {
        if (numPoints < crateImages.Length) {
            crateImages[numPoints].GetComponent<RawImage>().color = Color.white;
        }
        numPoints++;
        scoreText.text = "Crates " + numPoints + "/" + crateImages.Length;
    }
}
