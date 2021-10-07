using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelectFood : MonoBehaviour
{
    public GameObject[] eats;
    public GameObject[] eatButtons;
    public GameObject backToMain;
    public GameObject backToSelectEats;

    private void Start()
    {
        //hideSteps();
        backToSelectEats.SetActive(false);
    }

    private void hideSteps()
    {
        foreach (GameObject eat in eats)
        {
            eat.SetActive(false);
        }
        backToSelectEats.SetActive(false);
    }

    private void hideButtons()
    {
        foreach (GameObject eatbutton in eatButtons)
        {
            eatbutton.SetActive(false);
        }
        backToMain.SetActive(false);
        backToSelectEats.SetActive(true);
    }

    public void showEatButtons()
    {
        foreach (GameObject eatbutton in eatButtons)
        {
            eatbutton.SetActive(true);
        }
        hideSteps();
        backToMain.SetActive(true);
    }

    public void goToMain()
    {
        SceneManager.LoadScene("main");
    }

    public void eatAnIceCream()
    {
        /*
        hideSteps();
        hideButtons();
        eats[0].SetActive(true);
        */
        MainMenu.eatVariable += 2;
        SceneManager.LoadScene("main");
    }

    public void eatAChicken()
    {
        /*
        hideSteps();
        hideButtons();
        eats[1].SetActive(true);
        */
        MainMenu.eatVariable += 4;
        SceneManager.LoadScene("main");
    }

    public void eatApple()
    {
        /*
        hideSteps();
        hideButtons();
        eats[2].SetActive(true);
        */
        MainMenu.eatVariable += 8;
        SceneManager.LoadScene("main");
    }

    public void eatASalad()
    {
        /*
        hideSteps();
        hideButtons();
        eats[3].SetActive(true);
        */
        MainMenu.eatVariable += 16;
        SceneManager.LoadScene("main");
    }

/*
    public void eatAMeat()
    {
        hideSteps();
        hideButtons();
        eats[3].SetActive(true);
    }

    public void drinkAnOrangeJiuce()
    {
        hideSteps();
        hideButtons();
        eats[5].SetActive(true);
    }
*/
}
