using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class switch_scene : MonoBehaviour
{
    public GameObject protag;
    public GameObject mainCamera;
    private int currentScene;

    public static switch_scene instance;

    // Start is called before the first frame update
    void Start()
    {
        
        instance = this;
        DontDestroyOnLoad(protag);
        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(this.gameObject);
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame

    void Update()
    {
        
    }

    public void switchScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void loadNextScene()
    {
        currentScene++;
        SceneManager.LoadScene(currentScene);
    }

    public void RestartScene(int sceneNumber)
    {
        //SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber);
    }

}
