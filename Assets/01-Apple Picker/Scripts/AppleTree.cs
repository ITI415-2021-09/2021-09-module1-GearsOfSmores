using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    
    public GameObject applePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection;
    public float secondsBetweenAppleDrop;




    private void Start()
    {
        // Dropping Apples every second

        Invoke("DropApple", 2f);
    }
    void Update()
    {
        //Basic Movenment
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        //Changing Directions
        if ( pos.x < -leftAndRightEdge )
        {
            speed = Mathf.Abs(speed); // move right

        }
        else if( pos.x > leftAndRightEdge )
        {
            speed = -Mathf.Abs(speed); //move left
        }
        
       
    }
    private void FixedUpdate()
    {

         if (Random.value < chanceToChangeDirection)
        {
            speed *= -1; // Change Direction
        }


    }

    void DroppApple()
    {
        GameObject apple = Instantiate < GameObject>(applePrefab);
            apple.transform.position = transform.position;
           Invoke("DropApple", secondsBetweenAppleDrop);
    }
}
