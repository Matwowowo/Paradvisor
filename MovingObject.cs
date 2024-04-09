using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    public LayerMask MoveableMask;

    GameObject selectedObject;
    bool IsDragging;

    Vector3 initialPosition = Vector3.zero;

    private void Awake()
    {
        initialPosition = transform.position;
    }


    // Start is called before the first frame update
    void Start()
    {
        IsDragging = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))

        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity, MoveableMask);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                selectedObject = hit.collider.gameObject;
                IsDragging = true;
                
            }
        }

    
        if (IsDragging)
        {
            Vector3 pos = mousePos();
            selectedObject.transform.position = pos;
            
        }
    
        if(Input.GetMouseButtonUp(0))
        {
            RaycastHit2D bodyHit = Physics2D.Raycast(transform.right, selectedObject.transform.position, Mathf.Infinity);
            Debug.DrawRay(transform.right, selectedObject.transform.position, Color.magenta);

            if (bodyHit.collider != null)
            {
                Debug.Log(bodyHit.collider.gameObject.name);
                Debug.Log("J'ai touché");
        

            }
            IsDragging = false;
            selectedObject.transform.position = initialPosition;
           
        }
    }

    Vector3 mousePos()
    {
        return Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
    }

}
