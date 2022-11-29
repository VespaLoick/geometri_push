using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joueure : MonoBehaviour
{
    // Start is called before the first frame update
    public float vitessaut ;//= 8.0f ;
    public float vitesseh ;//= 3.0f;
    public float vitesstourne ;//= -1.5f;
    public bool estmort = false;
    Rigidbody2D joueurephy ;
    GameObject rotator;

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
       rotator = transform.GetChild (0).gameObject;  
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 coordray = new Vector2(joueurephy.transform.position.x , joueurephy.transform.position.y - 0.64f);
        RaycastHit2D rtouchesol = Physics2D.Raycast( joueurephy.transform.position , Vector2.down , 1.0f , LayerMask.GetMask("soll") );


        bool touchsol = doestouchsol(rtouchesol) ;
        if (Input.GetKey(KeyCode.Space) && asapce && touchsol ) //quand on touche espace et le sol
        { 
            asapce = false ; 
            Vector2 bougey = joueurephy.velocity  ;
            bougey[1] = vitessaut;
            joueurephy.velocity = bougey;
        }
        else if ( !Input.GetKey(KeyCode.Space)) //quand on relève espace
        {
            asapce = true ;
        }
        if(!touchsol) //quand ca tourne
        {
           rotator.transform.Rotate(0.0f, 0.0f, vitesstourne, Space.Self);            
        }
        else // quand ca retouche le sol on redresse le cube
        {                            
            if (rotator.transform.rotation.eulerAngles.z <= 315 && rotator.transform.rotation.eulerAngles.z > 225 )
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,270);
            }
            else if (rotator.transform.rotation.eulerAngles.z <= 225 && rotator.transform.rotation.eulerAngles.z > 135  )
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,180);
            }
            else if(rotator.transform.rotation.eulerAngles.z <= 135 && rotator.transform.rotation.eulerAngles.z > 45   )
            {
                 rotator.transform.rotation = Quaternion.Euler(0,0,90);
            }
            else
            {
                rotator.transform.rotation = Quaternion.Euler(0,0,0);
            }     
        }
        Vector2 bougex = joueurephy.velocity  ;
        bougex[0] = vitesseh;
        joueurephy.velocity = bougex;  

        //si touche un mur
    }

    void OnTriggerEnter2D(Collider2D collideur)//si touche un pique
    {
         if( collideur.tag == "pique")
            estmort = true;
    }




}


