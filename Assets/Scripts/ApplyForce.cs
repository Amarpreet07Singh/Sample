using UnityEngine;

public class ApplyForce : MonoBehaviour
{
    private Rigidbody rb;
    private bool isDragging = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 direction;
    private float forceMultiplier = 10f;
    public LayerMask layer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit,Mathf.Infinity,layer) )
            {
                isDragging = true;
                startPosition = transform.position;
            }
        }

        if (Input.GetMouseButton(0) && isDragging)
        {
            //Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
            Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = new Vector3(currentMousePosition.x, currentMousePosition.y, startPosition.z);
            transform.position = currentMousePosition;
        }

        /*if (Input.GetMouseButtonUp(0) && isDragging)
        {
            endPosition = transform.position;
            direction = (endPosition - startPosition).normalized;
            rb.AddForce(direction * forceMultiplier, ForceMode.Impulse);
            isDragging = false;
        }*/
    }
}
