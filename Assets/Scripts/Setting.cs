using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public class Setting : MonoBehaviour { 
    [SerializeField]
    Toggle[] BirthToggle = new Toggle[9];
    [SerializeField]
    Toggle[] SurvivalToggle = new Toggle[9];
    [SerializeField]
    Toggle FastToggle;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 9; i++) {
            SurvivalToggle[i].isOn = Static.Survival[i];
        }
        for (int i = 0; i < 9; i++) {
            BirthToggle[i].isOn = Static.DeadToBorn[i];
        }
        FastToggle.isOn = Static.Fast;
    }
	
	// Update is called once per frame
	void Update () {
   
    
        for(int i = 0; i < 9; i++) {
            Static.Survival[i] = SurvivalToggle[i].isOn;
        }
        for (int i = 0; i < 9; i++) {
            Static.DeadToBorn[i] = BirthToggle[i].isOn;
        }
        Static.Fast = FastToggle.isOn;
    }
}
