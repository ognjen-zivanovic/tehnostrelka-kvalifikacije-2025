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

    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text lifeText;
    [SerializeField] TMP_Text endText;


    [SerializeField] AudioSource crateSound;
    [SerializeField] AudioSource obstacleSound;

    public void ResetGame() {
        numLives = 3;
        numPoints = 0;
        for (int i = 0; i < numLives; i++) {
            livesIndicatorObjects[i].SetActive(true);
        }
        pool.SetActive(true);

        foreach(Transform obstacle in obstacleContainer.transform)
        {
            Destroy(obstacle.gameObject);
        }
        for (int i = 0; i < crateImages.Length; i++) {
            crateImages[i].GetComponent<RawImage>().color = new Color(0.33f, 0.33f, 0.33f, 1.0f);
        }
        endScreenObject.SetActive(false);
        gameScreenObject.SetActive(true);
        lifeText.text = "Lives (Жизни) " + numLives + "/" + livesIndicatorObjects.Length;
        scoreText.text = "Crates (Ящики) " + numPoints + "/" + crateImages.Length;
        GameObject uiManager = GameObject.FindGameObjectWithTag("UIManager");
        uiManager.GetComponent<UIManager>().SetValues("", "");
    }

    public void EndGame() {
        pool.SetActive(false);
        endScreenObject.SetActive(true);
        gameScreenObject.SetActive(false);
        if (numLives <= 0) {
            endText.text = "GAME OVER\nИГРА ОКОНЧЕНА";
            endText.color = Color.red;
        }    
        else if (numPoints >= crateImages.Length) {
            endText.text = "YOU WIN\nВЫ ПОБЕДИЛИ";
            endText.color = Color.green;
        }
        else {
            endText.text = "GAME OVER\nИГРА ОКОНЧЕНА";
            endText.color = Color.red;
        }
    }

    public void RemoveLife() {
        numLives--;
        obstacleSound.Play();
        
        if (numLives >= 0 && numLives < livesIndicatorObjects.Length) {
            livesIndicatorObjects[numLives].SetActive(false);
        }

        if (numLives >= 0) {
            lifeText.text = "Lives (Жизни) " + numLives + "/" + livesIndicatorObjects.Length;
        }

        if (numLives <= 0) { 
            EndGame();
        }
    }

    public void AddPoint() {
        crateSound.Play();
        if (numPoints < crateImages.Length) {
            crateImages[numPoints].GetComponent<RawImage>().color = Color.white;
        }
        numPoints++;
        scoreText.text = "Crates (Ящики) " + numPoints + "/" + crateImages.Length;
    }
}
