using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
   

    // Update is called once per frame
    void Update()
    {
        GetComponent<RectTransform>().position = new Vector3(0,0,0); 
    }
}
