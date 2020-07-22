using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

public Transform Libro;
public Transform Pivot;
public Transform Canvas;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
        Vector2 cursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(cursorPos.x,cursorPos.y);
        Libro.SetParent(Pivot);
        }
        else{
         Libro.SetParent(Canvas);
        }
    }
}
