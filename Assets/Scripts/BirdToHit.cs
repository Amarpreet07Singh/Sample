using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BirdToHit : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Birds;
    public  int index;
    public float length;
    public Transform stayPosition;
    DragBody dragbody;
    //Rigidbody rb;
    public TextMeshProUGUI BirdsCount;
    void Start()
    {
       
        index = 0;
        length = Birds.Length;
        Birds[0].transform.position = stayPosition.position;
    }
    private void Update()
    {   
        if(index < length)
        {   
            
            dragbody = Birds[index].GetComponent<DragBody>();
            //rb = Birds[index].GetComponent<Rigidbody>();
            //rb.isKinematic = false;
            dragbody.enabled = true;
        }
        

    }
    public  void NextBird()
    {

        if (index < length)
        {
            BirdsCount.text = "Birds : " + (length - (index + 1)).ToString();
            Destroy(Birds[index].gameObject, 10f);
            index++;
            dragbody.enabled = false;
            StartCoroutine("PlaceNext");

        }
        else  
        {
           
            dragbody.enabled = false;
             
        }
       
    }
    
    IEnumerator PlaceNext()
    {
        yield return new WaitForSeconds(length);
        if (index < length )
        {
            Birds[index].transform.position = stayPosition.position;
        }
         
    }

    // Update is called once per frame
   
}
