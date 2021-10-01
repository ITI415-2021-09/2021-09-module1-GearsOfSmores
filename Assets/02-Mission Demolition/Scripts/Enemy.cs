using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private GameObject _fireballParticlePrefab;
     void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile"  )
            Instantiate(_fireballParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);

    }
}
