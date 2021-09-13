using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nodeFunction : MonoBehaviour
{
    void Start() {

    }

    void Update() {

    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("hizo trigger con: " + other.gameObject.name);
    }
}
