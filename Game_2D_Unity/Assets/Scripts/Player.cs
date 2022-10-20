using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float Speed; // velocidade do Player
    public float JumpForce; // forca do pulo    
    public bool isJumping; //se esta pulando ou nao
    public bool DoubleJump; //pulo duplo


    private Rigidbody2D Rig; //omponente
    private Animator Anim; //componente

    
    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>(); //obtendo o componente RigidBody2D 
        Anim = GetComponent<Animator> (); //obtendo o componente Animator

        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); // movimento do player no eixo x
        transform.position += movement * Time.deltaTime * Speed;
        
        if(Input.GetAxis("Horizontal") > 0f)
        {
            Anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0f,0f,0f); //se o player estiver andando para direira, manter rotacao
        }
        
        else if(Input.GetAxis("Horizontal") < 0f)
        {
            Anim.SetBool("walk", true); //habilitando animacao
            transform.eulerAngles = new Vector3(0f, 180f, 0f); //rotacionando o player em 180 graus caso ele mude a direcao para a esquerda
        }
        else
        
        {
            Anim.SetBool("walk", false); //desabilitando animacao
        }
    
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump")) //apertar o botao de pulo
        {
            if (!isJumping)
            {
                Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); // pulo
                DoubleJump = true;
                Anim.SetBool("jump", true); //habilitando animacao
            }
            else
            {
                if (DoubleJump)
                {
                    Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse); //pulo duplo
                    DoubleJump = false;
            
                }
            }
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) //player está tocando na colisao
    {
        if (collision.gameObject.layer == 8) 
        {
            isJumping = false;
            Anim.SetBool("jump",false); //desabilitando animacao
        }

        if (collision.gameObject.tag == "Spikes")
        {
            GameController.instance.ShowGameOver();
            Destroy(gameObject);
        }
    }

     void OnCollisionExit2D(Collision2D collision) //player nao está tocando na colisao
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

}
