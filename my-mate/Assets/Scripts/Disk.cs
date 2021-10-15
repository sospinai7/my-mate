using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public GameObject disk;
    private Hockey hockey;
    public float magnitudePlayer;
    public float magnitudeBorder;
    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

    private void Awake() {
        hockey = GameObject.FindObjectOfType<Hockey>();
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }

    private void OnCollisionEnter(Collision other) {
        // If the object we hit is the enemy
        if (other.gameObject.tag == "player")
        {  
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (force * magnitudePlayer);
        }

        if (other.gameObject.tag == "border")
        {  
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (-force * magnitudeBorder);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "blueGoal")
        {  
            hockey.redGoal = true;
            Instantiate(disk, new Vector3(0, 0.08f, 0), Quaternion.identity);
            Destroy(disk);
        }

        if (other.gameObject.tag == "redGoal")
        {  
            hockey.blueGoal = true;
            Instantiate(disk, new Vector3(0, 0.08f, 0), Quaternion.identity);
            Destroy(disk);
        }
    }
}
