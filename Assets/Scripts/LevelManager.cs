using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {
    public string levelName;
    public string door;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag == "Player") {
            GameObject player = col.gameObject;
            PlayerController.door = door;

            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(levelName);
            SceneManager.UnloadSceneAsync(currentScene);
        }
    }
}
