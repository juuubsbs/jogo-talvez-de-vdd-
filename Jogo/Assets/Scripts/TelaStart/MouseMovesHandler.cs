using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovesHandler : MonoBehaviour
{
    private Ray raio = new Ray();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)){
            raio = Camera.main.ScreenPointToRay(Input.mousePosition);
            Debug.Log("Mouse clicked" + raio);
        };
    }
}
