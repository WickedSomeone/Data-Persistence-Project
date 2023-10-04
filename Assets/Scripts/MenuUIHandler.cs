using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUIHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
       //do nothing
    }
    public void PlayMainScene()
    {
        SceneManager.LoadScene(1);
    }
}
