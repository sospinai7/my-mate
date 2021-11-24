using UnityEngine;

public class DragDropFruit : MonoBehaviour
{
    /*
    private bool isDrag;
    [SerializeField] private Transform focus;
    [SerializeField] private Camera cam;
    [SerializeField] private Vector3 screenPos;
    [SerializeField] private Vector3 offset;
    [SerializeField] private RaycastHit hit;
    [SerializeField] private Ray ray;
    */

    bool isDrag;
    bool getInitialPosition;
    Transform focus;
    Camera cam;
    Vector3 screenPos;
    Vector3 offset;
    Vector3 initialPos;
    RaycastHit hit;
    Ray ray;

    private void Start()
    {
        isDrag = false;
        getInitialPosition = false;
        cam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                focus = hit.collider.transform;
                //print("click = " + focus.name);

                if (focus.tag == "fruit")
                {
                    if (!getInitialPosition) {
                        initialPos = new Vector3(focus.position.x, focus.position.y, focus.position.z);
                        Debug.Log(initialPos);
                        getInitialPosition = false;
                    }
                    screenPos = cam.WorldToScreenPoint(focus.position);
                    offset = focus.position - cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z));
                    isDrag = true;
                }
            }
        } else if (Input.GetMouseButtonUp(0) && isDrag == true)
        {
            Debug.Log("Solto");
            focus.position = initialPos;
            isDrag = false;
        }
        else if (isDrag == true)
        {
            Vector3 currentScreenPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPos.z);
            Vector3 currentPos = cam.ScreenToWorldPoint(currentScreenPos) + offset;

            focus.position = currentPos;
        }
    }
}
