using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragPlayer2 : MonoBehaviour
{
    public GameObject player2;

    private bool isMoving = false;

    private float gameObjectPositionX;
    private float gameObjectPositionY;
    private float gameObjectPositionZ;

    void Update()
    {
        gameObjectPositionX = player2.transform.position.x;
        gameObjectPositionY = player2.transform.position.y;
        gameObjectPositionZ = player2.transform.position.z;

        if (gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, gameObjectPositionZ);
        }
        else if (gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, gameObjectPositionZ);
        }

        if (gameObjectPositionZ < 0)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, 0);
        }
        else if (gameObjectPositionZ > 3.4f)
        {
            gameObject.transform.position = new Vector3(gameObjectPositionX, gameObjectPositionY, 3.4f);
        }

        if (gameObjectPositionZ < 0f && gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, 0f);
        }
        else if (gameObjectPositionZ < 0f && gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, 0f);
        }
        else if (gameObjectPositionZ > 3.4f && gameObjectPositionX > 1.9f)
        {
            gameObject.transform.position = new Vector3(1.9f, gameObjectPositionY, 3.4f);
        }
        else if (gameObjectPositionZ > 3.4f && gameObjectPositionX < -1.9f)
        {
            gameObject.transform.position = new Vector3(-1.9f, gameObjectPositionY, 3.4f);
        }
    }

    void OnMouseDrag()
    {
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen));
        transform.position = new Vector3(pos_move.x, transform.position.y, pos_move.z);
    }
}
