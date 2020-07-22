using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamaraPivot : MonoBehaviour
{
    public Transform objetoReferencia2;
    [SerializeField]
    private Rigidbody Pj2;
    void Start()
    {
        Pj2 = GetComponent<Rigidbody>();
    }
    void Awake() {
    }
    // Update is called once per frame
    void Update()
    {

        Pj2.rotation = objetoReferencia2.rotation;

      
    }
}
