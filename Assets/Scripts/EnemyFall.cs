using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyFall : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI Score;
    static int score;
    public ParticleSystem deadParticle;
    private void Start()
    {
        score = 0;
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {   
            
            score += 100;
            Score.text = "Score :" + score.ToString(); 
            deadParticle.transform.position = collision.transform.position;
            Destroy(collision.gameObject, 5f);
           
            
        }
        if(collision.collider.CompareTag("Blocks"))
        {
            score += 10;
            Score.text = "Score :" + score.ToString();
            deadParticle.transform.position = collision.transform.position;
            Destroy(collision.gameObject, 5f);
             
            
        }
        
        
    }
}
