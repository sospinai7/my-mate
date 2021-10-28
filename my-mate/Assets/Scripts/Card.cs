using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public GameObject cardParent;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        LeanTween.rotateY(cardParent, 180f, 1.5f);

        if(CleaningRoomScript.tries == 0) {
            CleaningRoomScript.firstCard = gameObject.tag;
            CleaningRoomScript.firstCardParent = cardParent.name;
        }

        if(CleaningRoomScript.tries == 1) {
            CleaningRoomScript.secondCard = gameObject.tag;
            CleaningRoomScript.secondCardParent = cardParent.name;
        }

        CleaningRoomScript.tries += 1;
    }
}
