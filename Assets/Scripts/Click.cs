using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    // Use this for initialization
    [SerializeField]
    Camera Camera;
    Cell Cell;
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 Point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D Collider2D = Physics2D.OverlapPoint(Point);
            if (Collider2D) {
                GameObject Object = Collider2D.transform.gameObject;
                Cell = Object.GetComponent<Cell>();
                Cell.Survival = !Cell.Survival;
            }
        }
    }
}