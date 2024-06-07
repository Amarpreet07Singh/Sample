using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class DragBody : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit hit;
    Rigidbody body;
    //RaycastHit hit1;
    Camera cam;
    [SerializeField] LayerMask layerMask ;
    //[SerializeField] LayerMask layerMaskPlat;
    bool isMouseButtonClicked;
    public Transform startingPosition;
    Vector3 endPosition;
    Vector3 startPosition;
    public SlingScript slingScript;
    float distance;
    public float force;
    public Camera WideAngleCamera;
    CameraShift cameraShift;
    float Z_Value;
    bool isWideAngle = false;
    float X_Min_clamp;
    float Y_Min_clamp;
    float X_Max_clamp;
    float Y_Max_clamp;
    public BirdToHit birdToHit;
    void Start()
    { 
        cam = Camera.main;
         
        isMouseButtonClicked = false;
        body = GetComponent<Rigidbody>();   
        cameraShift = WideAngleCamera.GetComponent<CameraShift>();
    }

    void Update()
    {
         
         //Debug.Log(cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z_Value)));
        HoldBird();
        WideAngle();
        UpdateClampValues();
        
    }

    void UpdateClampValues()
    {
        if (isWideAngle)
        {

            X_Min_clamp = 0.1f;
            Y_Min_clamp = 0.13f;
            X_Max_clamp = 0.3f;
            Y_Max_clamp = 0.4f;
            Z_Value = 30f;
        }
        else
        {
            Debug.Log("Hello");
            X_Min_clamp = 0.3f;
            Y_Min_clamp = 0.3f;
            X_Max_clamp = 0.6f;
            Y_Max_clamp = 0.7f;
            Z_Value = 13f;
        }
    }
    void WideAngle()
    {
        if(Input.GetKeyDown(KeyCode.V) && !isWideAngle)
        {
            cameraShift.SwitchCamera();
            cam = cameraShift.wideAngel;
            isWideAngle = true;
        }
        else if(isWideAngle&& Input.GetKeyDown(KeyCode.V))
        {
            cam = Camera.main;
            isWideAngle = false;
        }
    }
    void HoldBird()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                
                slingScript.EnableSlings();
                //startingPosition = body.position;
                isMouseButtonClicked = true;
            }
        }

        if (Input.GetMouseButton(0) && isMouseButtonClicked)
        {
            Vector3 pos = mousePos();
           
            Vector3 clampedPos = ClampToViewport(pos);
            transform.position = clampedPos;


        }

        if (Input.GetMouseButtonUp(0) && isMouseButtonClicked)
        {
            body.isKinematic = false;
            isMouseButtonClicked = false;
            ApplyForce();
            slingScript.DisableSlings();
            NextBirdCall();
        }
    }
    void ApplyForce()
    {
        endPosition = transform.position;
        startPosition = startingPosition.position;
        Vector3 direction = (endPosition - startPosition).normalized;
        direction.z = 0;
        distance = Vector3.Distance(startPosition, endPosition);
        // direction.x = -1 * direction.x;
        if (Mathf.Abs (startPosition.x - endPosition.x) < 1f)
        {
            Debug.Log("Entered");
            force = 10f;
        }
        //Debug.Log(-direction * force * distance);
        body.AddForce(-direction * force * distance, ForceMode.Impulse);
       // Debug.Log(startingPosition.position + " " + endPosition + " " + direction + " " + distance);
    }
    Vector3 mousePos()
    {
        return cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Z_Value));
    }

     Vector3 ClampToViewport(Vector3 pos)
    {
        //Debug.Log("original " + pos);
        Vector3 viewportPos = cam.WorldToViewportPoint(pos);
       // Debug.Log("Viewport" + viewportPos);
        viewportPos.x = Mathf.Clamp(viewportPos.x, X_Min_clamp, X_Max_clamp);
        viewportPos.y = Mathf.Clamp(viewportPos.y, Y_Min_clamp, Y_Max_clamp);
        viewportPos.z = Z_Value;
        //Vector3 view = cam.ViewportToWorldPoint(viewportPos);
       // Debug.Log("View " + view);
        return cam.ViewportToWorldPoint(viewportPos);
    }
    void NextBirdCall()
    {
        birdToHit.NextBird();
    }

     
}
