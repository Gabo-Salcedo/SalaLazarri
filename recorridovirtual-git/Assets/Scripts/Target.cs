using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    GameObject TargetObjet;
    // Start is called before the first frame update
    void Start()
    {
        TargetObjet = GameObject.Find("Sphere");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPosition = new Vector3(TargetObjet.transform.position.x,transform.position.y,TargetObjet.transform.position.z);
        transform.LookAt(TargetPosition);

    }
}
