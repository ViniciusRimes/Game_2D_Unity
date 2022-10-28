using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Animator anim;
    public float force;
    public bool isUp;
    public int life = 5;
    public GameObject collectedbox;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Instantiate(collectedbox, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        {
        if (collision.gameObject.tag == "Player")
        {
           
            if (isUp)
            {
                anim.SetTrigger("hit");
                life--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0f, force), ForceMode2D.Impulse);
                
            }
            else
            {
                anim.SetTrigger("hit");
                life--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2 (0f, -force), ForceMode2D.Impulse);
                
                
            }
        }
    }
    }
}

