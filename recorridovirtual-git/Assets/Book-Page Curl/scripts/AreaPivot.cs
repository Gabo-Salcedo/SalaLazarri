using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AreaPivot : MonoBehaviour
{

public SliderJoint2D zoom;
public Transform area1;
public Transform area2;

public Transform Libro;
public bool B = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(B == true){
            Libro.SetParent(area1);
        }
        else{
           Libro.SetParent(area2);
        }

    }
}
