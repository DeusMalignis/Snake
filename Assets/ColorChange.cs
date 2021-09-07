using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ColorChange : MonoBehaviour
{
    [SerializeField] GameObject snake;
 
   

    private void OnCollisionEnter(Collision collision){
        if (collision.collider == snake.GetComponentInChildren<BoxCollider>())
        {
            MeshRenderer[] snakes = snake.GetComponentsInChildren<MeshRenderer>();

            foreach (MeshRenderer snakess in snakes)
            {
                snakess.material.color = GetComponent<MeshRenderer>().material.color;
            }
        }
     
    }
   

}

   
   


