using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fever : MonoBehaviour
{ 
    [SerializeField] GameObject head;
    [SerializeField] Button left;
    [SerializeField] Button right;
    int count;
    // Start is called before the first frame update
    private void Start()
    {
        if((head.transform.position.x >= -5)&(head.transform.position.x < 0))        {
            GetComponent<Animator>().Play("MoveRightFromLeft");
        }
        if ((head.transform.position.x > 0) & (head.transform.position.x <= 5))
        {
            GetComponent<Animator>().Play("MoveLeftFromRight");
        }
        count = 0;

    }
    private void FixedUpdate()
    {
        ++count;
       transform.position = new Vector3(transform.position.x, transform.position.y,transform.position.z + 2f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 2f);
        if (count > 250)
        {
            GetComponent<Move>().enabled = true;
            right.enabled = true;
            left.enabled = true;
            count = 0;
            GetComponent<Fever>().enabled = false;
            
            
            
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
