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

    [SerializeField] Image diedBG;
    [SerializeField] GameObject diedTxt;

    [SerializeField] GameObject[] buttons;

    public float changePerSecond;

    private void Start()
    {
        if (eatVariable > 1 || cleanVariable > 1 || gameVariable > 1)
        {
            diedTxt.SetActive(false);
            diedBG.enabled = false;
        }
    }

    private void Update()
    {
        if (eatVariable > 101)
        {
            eatVariable = 101f;
        }
        else if (cleanVariable > 101f)
        {
            cleanVariable = 101f;
        }
        else if (gameVariable > 101f)
        {
            gameVariable = 101f;
        }
        if (eatVariable < 0)
        {
            died();
            eatVariable = 0f;
        }
        else if (cleanVariable < 0)
        {
            died();
            cleanVariable = 0f;
        }
        else if (gameVariable < 0)
        {
            died();
            gameVariable = 0f;
        }

        if (!useFixedUpdate)
        {
            eatVariable -= changePerSecond + Time.deltaTime;
            cleanVariable -= changePerSecond + Time.deltaTime;
            eatVariable -= changePerSecond + Time.deltaTime;
        }
        eatPorcent.text = Mathf.Floor(eatVariable).ToString() + "%";
        cleanPorcent.text = Mathf.Floor(cleanVariable).ToString() + "%";
        gamePorcentage.text = Mathf.Floor(gameVariable).ToString() + "%";
    }

    private void FixedUpdate()
    {
        if (useFixedUpdate)
        {
            eatVariable -= changePerSecond * Time.deltaTime;
            cleanVariable -= changePerSecond * Time.deltaTime;
            gameVariable -= changePerSecond * Time.deltaTime;
        }
    }

    public void GoToKitcenRoom()
    {
        SceneManager.LoadScene("KitchenRoom");
    }

    public void GoToCleaningRoom()
    {
        SceneManager.LoadScene("CleaningRoom");
    }

    public void GoToGameRoom()
    {
        SceneManager.LoadScene("GameRoom");
    }

    public void GoToLogin()
    { }

    public void died()
    {
        Debug.Log("died function called");
        diedTxt.SetActive(true);
        diedBG.enabled = true;

        foreach (GameObject button in buttons)
        {
            button.SetActive(false);
        }
       
    }
}
