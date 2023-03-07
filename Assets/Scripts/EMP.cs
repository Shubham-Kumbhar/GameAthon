using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EMP : MonoBehaviour
{
    // Start is called before the first frame update
    public int killCount;
    public float EMP_CoolDown;
    public bool isEMP=false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ActivateEMP()
		{
			if(killCount>=4 && Input.GetKeyDown(KeyCode.X)){
			isEMP=true;
			killCount-=4;
		}
		Invoke("DisActivateEMP",EMP_CoolDown);}

		void DisActivateEMP()
		{
			isEMP=false;
		}
}
