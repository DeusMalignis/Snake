using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewPlane : MonoBehaviour
{
    [SerializeField] public GameObject ground;
    [SerializeField] GameObject ground1;
    [SerializeField] Text crystCount;
    [SerializeField] GameObject snake;
     [SerializeField] Button left;
    [SerializeField] Button right;
    GameObject groundDop;
    GameObject groundI;
    int crystCountDop;

    int i;
    private void Start()
    {
        crystCountDop = 0;
        snake.GetComponent<Animator>().speed = 2f;
       i = 0;
        groundI = ground;
    
    }
    private void Update()
    {
        
       if(crystCountDop == 3)
        {
            right.enabled = false;
            left.enabled = false;
            snake.GetComponent<Move>().enabled = false;
         
            snake.GetComponent<Fever>().enabled = true;
            crystCount.text = "0";
            crystCountDop = 0;
        }
      

            
       

    }



    private void OnCollisionEnter(Collision collision)
    {
        if ((!snake.GetComponent<Move>().enabled) & ((collision.gameObject.tag == "Human")||(collision.gameObject.tag == "Let")||(collision.gameObject.tag == "Cryst")))
        {
            Destroy(collision.gameObject);
        }
        else if (collision.collider == ground1.GetComponent<Collider>())
        {

            ++i;
            if (i == 2)
            {
                i = 0;
                Destroy(groundI);
                groundI = ground;
            }
            groundDop = ground1;
            ground1 = Instantiate(ground, new Vector3(ground.transform.position.x, ground.transform.position.y, ground.transform.position.z + 1625f), Quaternion.identity);
            ground = groundDop;


        }
        else
        {
           
            if (collision.gameObject.tag == "Human")
            {
                
                if (collision.gameObject.GetComponent<MeshRenderer>().material.color != GetComponent<MeshRenderer>().material.color)
                {

                    SceneManager.LoadScene(0);
                }
                else
                {
                    crystCountDop = 0;
                    

                    
                    Destroy(collision.gameObject);
                }

            }
            if (collision.gameObject.tag == "Cryst")
            {
                Destroy(collision.gameObject);
                crystCountDop+= 1;
                crystCount.text = (int.Parse(crystCount.text) + 1).ToString();

            }
            if (collision.gameObject.tag == "Let")
            {
                SceneManager.LoadScene(0);
            }
        }
  
    }


}
