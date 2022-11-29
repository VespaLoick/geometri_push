using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject joeur; 
  
    void Start()
    {
       

        GameObject[] joeurtmptab =  GameObject.FindGameObjectsWithTag("Player"); 
        if (joeurtmptab[0] != null) //
        {
            joeur = joeurtmptab[0];
        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 deblacement = joeur.transform.position;
        deblacement[1] = transform.position.y;
        transform.position = deblacement;
    }


}
