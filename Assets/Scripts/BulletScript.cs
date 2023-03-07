using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float damage=10f;
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Player"))
        other.transform.gameObject.GetComponent<Health>().health-=damage;
    }
}
