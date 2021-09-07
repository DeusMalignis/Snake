using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Move : MonoBehaviour
{
    private void Update()
    {

        GetComponent<Animator>().speed = 2f;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f);
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z + 0.5f);


    }

   
    public void Right()
    {
       
        if(tag == "Middle")
        {
            tag = "Right";
            GetComponent<Animator>().Play("MoveRightFromMid");
        }
        if(tag == "Left")
        {
            GetComponent<Animator>().Play("MoveRightFromLeft");
            tag = "Middle";

        }
    }
    public void Left()
    {
        if(tag == "Middle")
        {
            tag = "Left";
            GetComponent<Animator>().Play("MoveLeftFromMid");
        }
        if (tag == "Right")
        {
            tag = "Middle";
            GetComponent<Animator>().Play("MoveLeftFromRight");

        }
    }
   public  void Exit()
    {
        Application.Quit();
    }
}
