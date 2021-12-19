using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float easing = 0.05f;
    public Vector2 minXY = Vector2.zero;

    static public GameObject POI; // The static point of interest               
    [Header("Set Dynamically")]
    public float camZ; // The desired Z pos of the camera


    void Awake()
    {
        camZ = this.transform.position.z;
    }
    void FixedUpdate()
    {

        Vector3 destination;
        if (POI == null)
        {
            destination = Vector3.zero;
        }
        else
        {
            destination = POI.transform.position;

            if (POI.tag == "Projectile")
            {
                // if it is sleeping 
                if(POI.GetComponent<Rigidbody>().IsSleeping())
                {
                    // return to the default view
                    POI = null;
                    // in the next update
                    return;
                }
            }
        }
        // Limit the X & Y to the minimum values
        destination.x = Mathf.Max(minXY.x, destination.x);
        destination.y = Mathf.Max(minXY.y, destination.y); 
        // Interpolate from the current Camera position toward destination
        destination = Vector3.Lerp(transform.position, destination, easing); 
        // Force destination.z to be camZ to keep the camera far enough away
        destination.z = camZ;
        // Set the camera to the destination
        transform.position = destination;
        // Set the orthographicSize of the Camera to keep Ground in view
        Camera.main.orthographicSize = destination.y + 10; 
    }
}



