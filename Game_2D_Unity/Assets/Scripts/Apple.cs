using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;

    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>(); 
        circle = GetComponent<CircleCollider2D>();
        
    }

    void OnTriggerEnter2D( Collider2D collider)
    {
        if (collider.gameObject.tag == "Player") //se o gamePbject colidir com outro objeto com a tag
        {
            sr.enabled = false; //desativando SpriteRenderer
            circle.enabled = false; //desativando CircleCollider2D
            collected.SetActive(true); //ativando o collected com a animacao

            GameController.instance.totalScore += Score;
            GameController.instance.UpdateScoreText();

            
            Destroy(gameObject, 0.24f); //destruindo a maca e ativando e desativando o collected em 0.24 segundos.
        }
    }
}
