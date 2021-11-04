using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Hockey : MonoBehaviour
{
    public bool redGoal;
    public bool blueGoal;
    private int redScore = 0;
    private int blueScore = 0;

    public Text blueTextScore;
    public Text redTextScore;

    public void goToMain()
    {
        SceneManager.LoadScene("main");
    }

    private void LateUpdate() {
        if (redGoal)
        {  
            redScore++;
            redGoal = false;
        }

        if (blueGoal)
        {  
            blueScore++;
            blueGoal = false;
        }

        blueTextScore.text = blueScore.ToString();
        redTextScore.text = redScore.ToString();
        
        if (redScore == 3 || blueScore == 3) {
            blueScore = 0;
            redScore = 0;
            MainMenu.gameVariable += 10;
            SceneManager.LoadScene("main");
            Debug.Log("Se acaba el partido");
        }
    }
}
