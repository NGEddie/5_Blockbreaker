using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Level : MonoBehaviour {
    [SerializeField] int blocksLeft;

    SceneLoaderScript sceneLoader;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoaderScript>();
    }

    public void CountBlocksLeft()
    {
        blocksLeft++;
    }

    public void RemoveBlock()
    {
        blocksLeft--;
        if(blocksLeft <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }
    


}
