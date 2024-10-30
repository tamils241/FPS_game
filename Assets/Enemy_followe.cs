using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_followe : MonoBehaviour
{
     public float speed=2.0f;
    public Transform target;
    public bool chasing;
    public Rigidbody rd;
    public float chasingDistance=20f, stoppingDistance =25f;
    public Vector3 targetpoint;
    // walk animation //
    public Animator ani; 
    public bool Player_move;
    // Audio source //
   // public AudioSource Audio;
    //public gameObject Player_move;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     //transform.position = Vector3.MoveTowards(transform.position,target.position,speed*Time.deltaTime); 
     if(!chasing)
     {
        targetpoint =  Move_Player.instance.transform.position;
        targetpoint.y= transform.position.y;
        if(Player_move == false)
        {
        if(Vector3.Distance(transform.position,targetpoint) < chasingDistance)
        {
           chasing=true;
           ani.SetBool("Walk",true);
           Player_move = false;
            //Audio.Play();  
        }
        }
      
     }  
   
     else
     {
         transform.LookAt( Move_Player.instance.transform.position);
         rd.velocity =  transform.forward*speed;
         if(Vector3.Distance(transform.position,targetpoint)> stoppingDistance)
         {
          chasing = false;
          ani.SetBool("Walk",false);
         
         }
        
     }
}
public void OnTriggerEnter(Collider other)
{
   if(other.gameObject.tag == "Player")
   {
      ani.SetBool("Attack",true);
      ani.SetBool("Walk",false);
      Player_move = true;
   }
}
public void OnTriggerExit(Collider other)
{
 if(other.gameObject.tag == "Player")
   {
      ani.SetBool("Attack",false);
      ani.SetBool("Walk",true);
      
   }
}
}