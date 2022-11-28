using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueure : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D joueurephy ;
    bool asapce = true ;
    
    void Start()
    {
       joueurephy = GetComponent<Rigidbody2D>();         
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetKey(KeyCode.Space) && asapce)
        { 
            asapce = false ; Vector2 bougey = joueurephy.velocity  ;
            bougey[1] = 5.0f;
            joueurephy.velocity = bougey;

        }
        else if ( !Input.GetKey(KeyCode.Space))
        {
            asapce = true ;
        }

        Vector2 bougex = joueurephy.velocity  ;
        bougex[0] = 1.0f;
        joueurephy.velocity = bougex;

    }


    
}


