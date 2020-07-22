using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomGabo : MonoBehaviour
{

    // Start is called before the first frame update
    public float SpeedZoom;

    // Update is called once per frame
    void Update()
    {
        
        if (Input.mouseScrollDelta.y > 0){
            this.transform.localScale=this.transform.localScale + new Vector3(SpeedZoom,SpeedZoom,SpeedZoom)*Time.deltaTime;
        }
        if (Input.mouseScrollDelta.y < 0){
            this.transform.localScale=this.transform.localScale - new Vector3(SpeedZoom,SpeedZoom,SpeedZoom)*Time.deltaTime;
        }
    }
}
