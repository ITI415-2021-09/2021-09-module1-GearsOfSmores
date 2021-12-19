using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    [Header("Set in Inspector")]
    public static float bottomY = -20f;


     void Update()
    {
        if (transform.position.y < bottomY )
        {
            Destroy(this.gameObject);

            ApplePicker apScript = Camera.main.GetComponent<ApplePicker>();  // Get a reference to the ApplePicker component of MainCamera

            apScript.AppleDestroyed();
        }

       
    }
}