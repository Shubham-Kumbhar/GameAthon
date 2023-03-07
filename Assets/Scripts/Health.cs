using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Slider slider;
    public float health;
    void Start()
    {
        slider.maxValue=health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value=health;
        if(health<=0)
        SceneManager.LoadScene("GameOver");
    }
}
