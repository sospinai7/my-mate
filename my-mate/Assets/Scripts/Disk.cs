using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public GameObject Player;
    public GameObject disk;
    public float magnitudePlayer;

    public float magnitudeBorder;
    private bool moveDisk = false;

    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    private void OnMouseExit()
    {
        moveDisk = false;
    }

    private void OnCollisionEnter(Collision other) {
        // If the object we hit is the enemy
        if (other.gameObject.tag == "player")
        {  
            //var magnitude = 50;
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (force * magnitudePlayer);
            Debug.Log("Me toco el azul");
        }

        if (other.gameObject.tag == "border")
        {  
            //var magnitude = 50;
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (-force * magnitudeBorder);
            Debug.Log("Me toco el borde");
        }
    }
}
