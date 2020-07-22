using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Control : MonoBehaviour
{
    private Vector3 InputVector;
    public Vector3 objetoReferencia;
    [SerializeField]
    private Rigidbody Pj;
    void Start()
    {
        Pj = GetComponent<Rigidbody>();
    }
    void Awake() {
    }
    // Update is called once per frame
    void Update()
    {

        InputVector = new Vector3(Input.GetAxisRaw("Horizontal"),Pj.velocity.y,Input.GetAxisRaw("Vertical"));
        Pj.velocity = InputVector;

        transform.LookAt(transform.position + objetoReferencia);
        //Pj.rotation = objetoReferencia.rotation;

        /*if(Input.GetKey(KeyCode.D))
        {
        Pj.velocity=new Vector3(2f,0,0);
        }

        if(Input.GetKey(KeyCode.A))
        {
        Pj.velocity=new Vector3(-2f,0,0);
        }

         if(Input.GetKey(KeyCode.W) || Input.mouseScrollDelta.y > 0)
        {
        Pj.velocity=new Vector3(0,0,Pj.velocity.z);
        }

        if(Input.GetKey(KeyCode.S) || Input.mouseScrollDelta.y < 0)
        {
        Pj.velocity=new Vector3(0,0,-2f);
        }*/

      
    }
}
