using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShift : MonoBehaviour
{
    public Camera wideAngel;
    // Start is called before the first frame update
    void Start()
    {
       wideAngel = GetComponent<Camera>();
    }
   public void SwitchCamera()
    {
        Debug.Log("Entered");
        wideAngel.enabled = !wideAngel.enabled;
    }


    // Update is called once per frame
    
}
