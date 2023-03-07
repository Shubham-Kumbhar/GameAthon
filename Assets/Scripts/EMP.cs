using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EMP : MonoBehaviour
{
    // Start is called before the first frame update
    public int killCount;
    public float EMP_CoolDown;
    private int kc;
    public bool isEMP=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        if(killCount>=21)
        SceneManager.LoadScene("MainMenu");
    }
    void ActivateEMP()
		{
			if(kc>=4 && Input.GetKeyDown(KeyCode.X)){
			isEMP=true;
      kc-=4;
			
		}
		Invoke("DisActivateEMP",EMP_CoolDown);}

		void DisActivateEMP()
		{
			isEMP=false;
		}
}
