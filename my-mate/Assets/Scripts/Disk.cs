using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    /*
    public int movementSpeed;
    private void Update() {
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("izquierda");
            GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
        }
        if(Input.GetKey(KeyCode.D)){
            Debug.Log("derecha");
            GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
        }
        if(Input.GetKey(KeyCode.W)){
            Debug.Log("arriba");
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, movementSpeed));
        }
        if(Input.GetKey(KeyCode.S)){
            Debug.Log("abajo");
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -movementSpeed));
        }
    }
    */
    
    public GameObject Player;
    public GameObject disk;
    public float movementSpeed;
    private bool moveDisk = false;

    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

    void Update()
    {
        /*
        if(Input.GetKey(KeyCode.A)){
            Debug.Log("izquierda");
            disk.GetComponent<Rigidbody>().AddForce(new Vector3(movementSpeed, 0, 0));
        }
        if(Input.GetKey(KeyCode.D)){
            Debug.Log("derecha");
            disk.GetComponent<Rigidbody>().AddForce(new Vector3(-movementSpeed, 0, 0));
        }
        if(Input.GetKey(KeyCode.W)){
            Debug.Log("arriba");
            disk.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, movementSpeed));
        }
        if(Input.GetKey(KeyCode.S)){
            Debug.Log("abajo");
            disk.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -movementSpeed));
        }
*/
        gameObjectPositionX = disk.transform.position.x;
        gameObjectPositionY = disk.transform.position.y;
        gameObjectPositionZ = disk.transform.position.z;
/*
        if (gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, gameObjectPositionZ);
        }
        else if (gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, gameObjectPositionZ);
        }

        if (gameObjectPositionZ > 0)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, 0);
        }
        else if (gameObjectPositionZ < -3.4f)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, -3.4f);
        }

        if (gameObjectPositionZ > 0f && gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, 0f);
        }
        else if (gameObjectPositionZ > 0f && gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, 0f);
        }
        else if (gameObjectPositionZ < -3.4f && gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, -3.4f);
        }
        else if (gameObjectPositionZ < -3.4f && gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, -3.4f);
        }
        */
    }

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
            var magnitude = 50;
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (force * magnitude);
            Debug.Log("Me toco el azul");
        }
    }

/*
    private void OnTriggerEnter(Collider other)
    {
        // If the object we hit is the enemy
        if (other.gameObject.tag == "player")
        {  
            var magnitude = 50;
            var force = transform.position - other.transform.position;
            force.Normalize ();
            disk.GetComponent<Rigidbody> ().AddForce (force * magnitude);
            Debug.Log("Me toco el azul");
        }
    }
    */
}
