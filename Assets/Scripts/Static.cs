using UnityEngine;
using System.Collections.Generic;
static public class Static {
    static public Color SurvivalColor = Color.green;
    static public Color DeadColor=Color.black;
    static public bool[] Survival = { false, false, true, true, false, false, false, false, false };
    static public bool[] DeadToBorn = { false, false, false, true, false, false, false, false, false };
    static public bool Play;
    static public bool Fast = true;
}