using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBody02 : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    Rigidbody body;
    //RaycastHit hit1;
    Camera cam;
    [SerializeField] LayerMask layerMask ;
    //[SerializeField] LayerMask layerMaskPlat;
    bool isMouseButtonClicked;
    Vector3 startingPosition;
    Vector3 endPosition;
   // public SlingScript slingScript;

    void Start()
    {
        cam = Camera.main;
        isMouseButtonClicked = false;
        body = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        // Ray ray1 = new Ray(transform.position, transform.forward);
        //Debug.DrawRay(transform.position,transform.forward,Color.green);
        //if (Physics.Raycast(ray, out hit1, Mathf.Infinity, layerMaskPlat))
        // {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask ))
            {
                //slingScript.EnableSlings();
                startingPosition = body.position;
                isMouseButtonClicked = true;
            }
        }

        if (Input.GetMouseButton(0)&&isMouseButtonClicked)
        {
             Vector3 pos = mousePos();
             Vector3 clampedPos = ClampToViewport(pos);
             transform.position = clampedPos;  
            
          
        }

        if (Input.GetMouseButtonUp(0)&&isMouseButtonClicked)
        {
            isMouseButtonClicked = false;
            endPosition = transform.position;
            Vector3 direction =  (endPosition - startingPosition).normalized;
            body.AddForce(direction * 10, ForceMode.Impulse);
            Debug.Log(startingPosition + " " + endPosition + " " + direction);
           // slingScript.DisableSlings();
        }
    }

    Vector3 mousePos()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 4f,Input.mousePosition.y));
    }

     Vector3 ClampToViewport(Vector3 pos)
    {
        //Debug.Log("original " + pos);
        Vector3 viewportPos = cam.WorldToViewportPoint(pos);
       // Debug.Log("Viewport" + viewportPos);
        viewportPos.x = Mathf.Clamp(viewportPos.x,0f,1f);
        viewportPos.z = Mathf.Clamp(viewportPos.z,0.3f,0.6f);
         viewportPos.y = 4f;
        //Vector3 view = cam.ViewportToWorldPoint(viewportPos);
       // Debug.Log("View " + view);
        return cam.ViewportToWorldPoint(viewportPos);
    }  
}
