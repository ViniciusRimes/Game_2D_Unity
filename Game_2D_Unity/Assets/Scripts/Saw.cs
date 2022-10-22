using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public float Speed;
    public float moveTime;

    private bool dirRight;
    private float timer;
   

    // Update is called once per frame
    void Update()
    {
        if (dirRight)
        {
            transform.Translate(Vector2.right * Speed * Time.deltaTime); //serra vai para direita
        }
        else
        {
            transform.Translate(Vector2.left * Speed * Time.deltaTime); //serra vai para esquerda
        }

        timer += Time.deltaTime;
        if (timer >= moveTime)
        {
            dirRight = !dirRight;
            timer = 0f;
        }
    }
}
