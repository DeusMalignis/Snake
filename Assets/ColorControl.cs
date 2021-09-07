using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorControl : MonoBehaviour
{
    bool Ok;
    private void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        {
            for (int i = 0; i < GameObject.FindGameObjectsWithTag("Human").Length; i++)
            {
                if (GameObject.FindGameObjectsWithTag("Human")[i].GetComponentInChildren<MeshRenderer>().material.color == GetComponent<MeshRenderer>().material.color)
                {
                    Ok = false;
                }
                if (i % 2 == 0)
                    if (Ok)
                    {
                        foreach(var humans in GameObject.FindGameObjectsWithTag("Human")[i].GetComponentsInChildren<MeshRenderer>())
                        {
                              humans.material.color = GetComponent<MeshRenderer>().material.color;
                        }
                        
                    }
                    else
                    {
                        Ok = true;
                    }
                {
                    
                    
                }
            }




        }
    }
}
