using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingScript : MonoBehaviour
{
    public LineRenderer SlingLeft;
    public LineRenderer SlingRight;
    public Transform[] BirdLeft;
    public Transform[] BirdRight;
    // Start is called before the first frame update
    public BirdToHit birdToHit;
    private void Awake()
    {
        DisableSlings();
    }
    // Update is called once per frame
    void Update()
    {
        if(birdToHit.index < birdToHit.length)
        {
            SlingLeft.SetPosition(1, BirdLeft[birdToHit.index].position);
            SlingRight.SetPosition(1, BirdRight[birdToHit.index].position);
        }
       

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
