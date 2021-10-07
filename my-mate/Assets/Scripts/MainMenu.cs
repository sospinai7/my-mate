using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Text eatPorcent;
    public Text cleanPorcent;
    public Text gamePorcentage;
    public bool useFixedUpdate;
    public static float eatVariable = 101f;
    public static float cleanVariable = 101f;
    public static float gameVariable = 101f;

    public float changePerSecond;

    private void Update() {
        if (eatVariable > 101) {
            eatVariable = 101f;
        } else if (cleanVariable > 101f) {
            cleanVariable = 101f;
        }  else if (gameVariable > 101f) {
            gameVariable = 101f;
        }
        if (eatVariable < 0) {
            eatVariable = 0f;
        } else if (cleanVariable < 0) {
            cleanVariable = 0f;
        }  else if (gameVariable < 0) {
            gameVariable = 0f;
        }

        if (!useFixedUpdate) {
            eatVariable -= changePerSecond + Time.deltaTime;
            cleanVariable -= changePerSecond + Time.deltaTime;
            eatVariable -= changePerSecond + Time.deltaTime;
        }

        eatPorcent.text = Mathf.Floor(eatVariable).ToString() + "%";
        cleanPorcent.text = Mathf.Floor(cleanVariable).ToString() + "%";
        gamePorcentage.text = Mathf.Floor(gameVariable).ToString() + "%";
    }

    private void FixedUpdate() {
        if (useFixedUpdate) {
            eatVariable -= changePerSecond * Time.deltaTime;
            cleanVariable -= changePerSecond * Time.deltaTime;
            gameVariable -= changePerSecond * Time.deltaTime;
        }
    }

   public void GoToKitcenRoom()
    {
        SceneManager.LoadScene(3);
    }

    public void GoToCleaningRoom()
    {
        SceneManager.LoadScene(4);
    }

    public void GoToGameRoom()
    {
        SceneManager.LoadScene(5);
    }
}
