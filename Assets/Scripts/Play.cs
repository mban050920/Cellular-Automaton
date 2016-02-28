using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Play : MonoBehaviour {
    [SerializeField]
    Text Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Static.Play) {
            Text.text = "Stop";
        }
        else {
            Text.text = "Play";
        }
    }
}
