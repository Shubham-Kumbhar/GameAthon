using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public string newScene;
    public void SceneChange()
    {
        SceneManager.LoadScene(newScene);
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
    
        
    
}
