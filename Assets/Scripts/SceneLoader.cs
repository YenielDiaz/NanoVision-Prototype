using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public void LoadMinigameScene(string sceneName)
    {
        //each button that calls on this method will specify its own scene to load
        SceneManager.LoadScene(sceneName);
    }

    public void LoadHub()
    {
        //loads scene at build index- 0. Which at the moment is the hub scene
        SceneManager.LoadScene(0);
    }
}
