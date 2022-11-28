using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueure : MonoBehaviour
{
    // Start is called before the first frame update
    float vitessaut = 8.0f ;
    float vitesseh = 2.0f;
    Rigidbody2D joueurephy ;
    bool asapce = true ;
    public bool doestouchsol(RaycastHit2D touchesol)
    {
        if (touchesol.collider == null)
        {
            return false ;
        }
        else 
        {
            float distance = Mathf.Abs(touchesol.point.y - transform.position.y);
            return distance < 0.33f ;
        }
    }
    
    void Start()
    {
       joueurephy = GetComponent<Rigidbody2D>();         
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 coordray = new Vector2(joueurephy.transform.position.x , joueurephy.transform.position.y - 0.64f);
        RaycastHit2D touchesol = Physics2D.Raycast( joueurephy.transform.position , Vector2.down , 1.0f , LayerMask.GetMask("soll") );

        if (Input.GetKey(KeyCode.Space) && asapce && doestouchsol(touchesol) ) //quand on touche espace et le sol
        { 
            asapce = false ; Vector2 bougey = joueurephy.velocity  ;
            bougey[1] = vitessaut;
            joueurephy.velocity = bougey;
        }
        else if ( !Input.GetKey(KeyCode.Space)) //quand on relève espace
        {
            asapce = true ;
        }
        Vector2 bougex = joueurephy.velocity  ;
        bougex[0] = vitesseh;
        joueurephy.velocity = bougex;  
    }
}


