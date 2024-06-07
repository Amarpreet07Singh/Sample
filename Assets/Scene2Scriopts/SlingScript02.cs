using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingScript02 : MonoBehaviour
{
    public LineRenderer SlingLeft;
    public LineRenderer SlingRight;
    public Transform BirdLeft;
    public Transform BirdRight;
    // Start is called before the first frame update

    private void Awake()
    {
        //DisableSlings();
    }
    // Update is called once per frame
    void Update()
    {
        SlingLeft.SetPosition(1, BirdLeft.position);
        SlingRight.SetPosition(1, BirdRight.position);

    }
    public void EnableSlings()
    {
        SlingLeft.enabled = true;
        SlingRight.enabled = true;
    }
    public void DisableSlings()
    {
        SlingLeft.enabled = false;
        SlingRight.enabled = false;
    }
}
