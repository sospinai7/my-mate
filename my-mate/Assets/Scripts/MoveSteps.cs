using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSteps : MonoBehaviour
{
    void OnMouseDrag()
    {
        Debug.Log("IsDragging");
        /*
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
        transform.position = new Vector3( pos_move.x, transform.position.y, pos_move.z );
        */
        float distance_to_screen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen ));
        transform.position = new Vector3( pos_move.x, pos_move.y, pos_move.z );
    }
}
