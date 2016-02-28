using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour {

	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

	}
    public void Option() {
        SceneManager.LoadScene("Option");   
    }
    public void Game() {
        SceneManager.LoadScene("Game");
    }
    public void Play() {
        Static.Play = !Static.Play;
    }
}
