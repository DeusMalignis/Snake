using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOfLine : MonoBehaviour
{
    [SerializeField] GameObject[] lines = new GameObject[4];
    [SerializeField] GameObject humans;
    [SerializeField] GameObject lets;
    [SerializeField] GameObject crysts;
    System.Random random = new System.Random();
    int n;
    int humanNum;
    bool Ok = true;
    bool Okey = true;
    List<GameObject> human = new List<GameObject> { };
    List<GameObject> let = new List<GameObject> { };
    List<GameObject> cryst = new List<GameObject> { };
    // Start is called before the first frame update
    private void Start()
    {
        ChangeCOlor();
        foreach (var line in lines)
        {
            for (int i = 50; i < 200; i += 30)
            {
                humanNum = human.Count;
                ColorHuman(4, 5, i, line);
                ColorHuman(-1, 0, i, line);
                ColorHuman(-6, -5, i, line);
                


                if ((Okey) & (let.Count > 0))
                {
                    Destroy(let[let.Count - 1]);
                }
                else
                {
                    Okey = true;
                }

                if ((Ok) & (human.Count > humanNum))
                {
                    foreach (MeshRenderer humanss in human[human.Count - 1].GetComponentsInChildren<MeshRenderer>())
                    {
                        humanss.material.color = line.GetComponent<MeshRenderer>().material.color;
                    }
                }
                else
                {
                    Ok = true;
                }


            }
        }


    }

    void ColorHuman(float x1, float x2, int i, GameObject line)
    {
        n = random.Next(1, 4);
        switch (n)
        {
            case 1:
                human.Add(Instantiate(humans, new Vector3(x1, 1, i + line.transform.position.z), Quaternion.identity));
                Colorr(line);
                Okey = false;
                break;
            case 2:
                let.Add(Instantiate(lets, new Vector3(x2, 1.1f, i + line.transform.position.z), Quaternion.identity));
                let[let.Count - 1].tag = "Let";
                break;
            case 3:
                cryst.Add(Instantiate(crysts, new Vector3(x2, 1, i + line.transform.position.z), Quaternion.identity));
                cryst[cryst.Count - 1].transform.Rotate(new Vector3(90, 0, 0));
                cryst[cryst.Count - 1].tag = "Cryst";
                Okey = false;   
                break;
        }
    }
    void Colorr(GameObject line)
    {


        n = random.Next(1, 7);
        foreach (MeshRenderer littleHuman in human[human.Count - 1].GetComponentsInChildren<MeshRenderer>())
        {

            littleHuman.tag = "Human";
            Switch(littleHuman);
        }

        if (human[human.Count - 1].GetComponentInChildren<MeshRenderer>().material.color == line.GetComponent<MeshRenderer>().material.color)
        {
            Ok = false;
        }






    }

    void Switch(MeshRenderer rndr)
    {
        switch (n)
        {
            case 1:

                rndr.material.color = Color.red;
                break;

            case 2:
                rndr.material.color = Color.blue;
                break;
            case 3:
                rndr.material.color = Color.yellow;
                break;
            case 4:
                rndr.material.color = Color.green;
                break;

            case 5:
                rndr.material.color = Color.black;
                break;

            case 6:
                rndr.material.color = Color.white;
                break;


        }
    }

    public void ChangeCOlor()
    {
        
        foreach (var line in lines)
        {
            n = random.Next(1, 7);
            Switch(line.GetComponent<MeshRenderer>());
            line.GetComponent<ColorChange>().enabled = true;
        }
    }
}
