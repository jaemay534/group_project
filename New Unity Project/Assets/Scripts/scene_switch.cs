using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class scene_switch : MonoBehaviour
{
    public GameObject player;
    public GameObject mainCamera;
    private int currentScene;

    public static scene_switch instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        DontDestroyOnLoad(player);
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
}
