using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    
    void Update()
    {
        Vector3 mousePos2d = Input.mousePosition;

        mousePos2d.z = -Camera.main.transform.position.x;
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);

        Vector3 pos = this.transform.position;
        pos.x = mousePos3d.x;
        this.transform.position = pos;

    }
    void OnCollisionEnter(Collision coll )
    {
        GameObject collidedWith = coll.gameObject;
        if( collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
        }
    }
}
