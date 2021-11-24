using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectFood : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "fruit")
        {
            Debug.Log("Itrm picked up");
        }
    }
}
