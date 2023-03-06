using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Slider slider;
    public float health=100f;
    [SerializeField]private float damageRadius=2f;
    [SerializeField]private float damage=100f;
    [SerializeField]private LayerMask enemyLayer;
    Ray ray;

    
    void Start()
    {
        slider.maxValue=health;
    }
    private void Update() {
        slider.value=health;
        if(Input.GetMouseButtonDown(0))
        AttackEnemy();
    }
    void AttackEnemy()
    {
        RaycastHit hit;
        if(Physics.Raycast(this.transform.position,this.transform.forward, out hit,damageRadius, enemyLayer))
        Destroy(hit.transform.gameObject);
    }
        
    }

