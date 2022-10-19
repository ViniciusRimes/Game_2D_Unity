using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float FallingTime;
   
   
    private TargetJoint2D Target;
    private BoxCollider2D BoxCollider;
    private SpriteRenderer Sr;
    
    
    // Start is called before the first frame update
    void Start()
    {
        Target = GetComponent<TargetJoint2D>();
        BoxCollider = GetComponent<BoxCollider2D>();
        Sr = GetComponent<SpriteRenderer>();

    }

   void OnCollisionEnter2D(Collision2D collision) //player está tocando na colisao
    {
        if (collision.gameObject.tag == "Player") 
        {
           Invoke("Falling", FallingTime); //invoca um metodo apos certo tempo
        }
    }
    void OnTriggerEnter2D( Collider2D collider)
    {
       if (collider.gameObject.layer == 9)
       {
        Destroy(gameObject);
       }
    }

    void Falling()
    {
        Target.enabled= false; //desativando targetjoint2d
        BoxCollider.isTrigger = true; //is trigger sendo ativado no box collider
    }
}
