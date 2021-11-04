using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CleaningRoomScript : MonoBehaviour
{
    public static int tries = 0;
    private GameObject firstCardGameObject;
    private GameObject secondtCardGameObject;
    public static string firstCardParent;
    public static string secondCardParent;
    public static string firstCard;
    public static string secondCard;
    public GameObject[] takeABathList;
    public GameObject takeABathListBackArrow;
    private int cardsCount = 0;
    public GameObject[] mainlySceneAssets;
    public GameObject[] list;
    

    // Start is called before the first frame update
    void Start()
    {
        foreach (var asset in takeABathList)
        {
            asset.SetActive(false);
        }
        /*
        foreach (var step in list)
        {
            step.SetActive(false);
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        if (tries == 2) {
            if (firstCard == secondCard) {
                cardsCount++;
                Debug.Log("Congratulations! you select a couple: " + firstCard);
            } else {
                firstCardGameObject = GameObject.Find(firstCardParent);
                secondtCardGameObject = GameObject.Find(secondCardParent);
                StartCoroutine(returnTransition());
            }
            tries = 0;
        }

        if(cardsCount == 4) {
            MainMenu.cleanVariable += 7;
            StartCoroutine(finishGame());
        }
    }


    IEnumerator returnTransition()
    {
        yield return new WaitForSeconds(2f);
        LeanTween.rotateY(firstCardGameObject, 0F, 1.5f);
        LeanTween.rotateY(secondtCardGameObject, 0F, 1.5f);
        Debug.Log("Try Again");
    }

    IEnumerator finishGame()
    {
        yield return new WaitForSeconds(2f);
        GoToMain();
    }


    public void GoToMain()
    {
        SceneManager.LoadScene("main");
    }

    public void TakeABath() {
        foreach (var asset in takeABathList)
        {
            asset.SetActive(true);
        }
        turnOffScene();
    }

    void turnOffScene() {
        foreach (var asset in mainlySceneAssets)
        {
            asset.SetActive(false);
        }
    }

    void turnOnScene() {
        foreach (var asset in mainlySceneAssets)
        {
            asset.SetActive(true);
        }
    }

    public void returnToCleaningLobbby() {
        SceneManager.LoadScene("CleaningRoom");
    }
}
