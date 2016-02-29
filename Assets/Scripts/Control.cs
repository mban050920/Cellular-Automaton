using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {
    const int X = 54;
    const int Y = 36;
    [SerializeField]
    GameObject CellPrefab;
    GameObject[,] Cell = new GameObject[X, Y];
    SpriteRenderer SpriteRenderer;
    Cell[,] CellScripts=new Cell[X,Y];
    // Use this for initialization
    void Start() {
        Static.Play = false;
        if (Static.Fast) {
            Application.targetFrameRate = 45;
        }
        else {
            Application.targetFrameRate = 8;
        }
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                Cell[i, j] = Instantiate(CellPrefab, new Vector2(i + 0.5f, j + 0.5f), Quaternion.identity) as GameObject;
                Cell[i, j].name = i.ToString() +" "+ j.ToString();
                CellScripts[i, j] = Cell[i, j].GetComponent<Cell>();
            }
        }
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                SpriteRenderer = Cell[i, j].GetComponent<SpriteRenderer>();
                if (CellScripts[i, j].Survival) {
                    SpriteRenderer.color = Static.SurvivalColor;
                }
                else {
                    SpriteRenderer.color = Static.DeadColor;
                }
            }
        }
        //G();
    }
    void Update() {
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                SpriteRenderer = Cell[i, j].GetComponent<SpriteRenderer>();
                if (CellScripts[i, j].Survival) {
                    SpriteRenderer.color = Static.SurvivalColor;
                }
                else {
                    SpriteRenderer.color = Static.DeadColor;
                }
            }
        }
        if (Static.Play) {
            UpdateCell();
        }
    }
    // Update is called once per frame
    void UpdateCell() {
        
        for (int i = 0; i < X; i++) {
            for (int j = 0; j < Y; j++) {
                int SurroundingsCell=0;
                int[] Cell = new int[8];
                try {
                    if (CellScripts[i - 1, j - 1].Survival) {
                        Cell[0] = 1;
                    }
                }
                catch {
                    Cell[0] = 0;
                }
                try {
                    if (CellScripts[i -1, j ].Survival) {
                        Cell[1] = 1;
                    }
                }
                catch {
                    Cell[1] = 0;
                }
                try {
                    if (CellScripts[i - 1, j +1].Survival) {
                        Cell[2] = 1;
                    }
                }
                catch {
                    Cell[2] = 0;
                }
                try {
                    if (CellScripts[i , j - 1].Survival) {
                        Cell[3] = 1;
                    }
                }
                catch {
                    Cell[3] = 0;
                }
                try {
                    if (CellScripts[i , j + 1].Survival) {
                        Cell[4] = 1;
                    }
                }
                catch {
                    Cell[4] = 0;
                }
                try {
                    if (CellScripts[i + 1, j + 1].Survival) {
                        Cell[5] = 1;
                    }
                }
                catch {
                    Cell[5] = 0;
                }
                try {
                    if (CellScripts[i +1, j ].Survival) {
                        Cell[6] = 1;
                    }
                }
                catch {
                    Cell[6] = 0;
                }
                try {
                    if (CellScripts[i + 1, j - 1].Survival) {
                        Cell[7] = 1;
                    }
                }
                catch {
                    Cell[7] = 0;
                }
                for (int k = 0; k < Cell.Length; k++) {
                    SurroundingsCell += Cell[k];
                }
                StartCoroutine(Survical(CellScripts[i, j], SurroundingsCell));
            }
        }
       
    }
    IEnumerator Survical(Cell cell,int surroundingscell) {
        yield return new WaitForEndOfFrame();
        if (cell.Survival) {
            if (Static.Survival[surroundingscell]) {
               cell.Survival = true;
            }
            else {
                cell.Survival = false;
            }
        }
        else {
            if (Static.DeadToBorn[surroundingscell]) {
                cell.Survival = true;
            }
            else {
                cell.Survival = false;

            }
        }
    }
    void G() {
        CellScripts[0, 0].Survival = true;
        CellScripts[1, 1].Survival = true;
        CellScripts[2, 1].Survival = true;
        CellScripts[0, 2].Survival = true;
        CellScripts[1, 2].Survival = true;
    }
}
