using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovesHandler : MonoBehaviour
{
    private Ray raio = new Ray();
    private Vector2 mousePosition = new Vector2();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            raio = Camera.main.ScreenPointToRay(mousePosition);
            Debug.Log("Mouse clicked" + raio);
        };
    }
}
