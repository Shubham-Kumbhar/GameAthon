using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private float damage=10f;
    

    // Update is called once per frame
   void OnCollisionEnter(Collision other)
   {
        if(other.transform.CompareTag("Player"))
        other.transform.gameObject.GetComponent<DamageScript>().health-=damage;
        if(!other.transform.CompareTag("Enemy"))
        Destroy(this.transform.gameObject);
   }
}
