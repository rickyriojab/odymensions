using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float speed;
    [SerializeField] private float timer;
    public float time = 2f;
    private bool isRight = true;
    public Transform player;
    private bool needToAttack = false;
    private float distance; // distancia del enemigo al jugador
    private float absDistance;
    public SpriteRenderer spriteRenderer;


    void Start()
    {
        timer = time;
        spriteRenderer.flipX = true;
    }

    void Update()
    {

        distance = player.position.x - transform.position.x;
        absDistance = Mathf.Abs(distance);

        if (absDistance < 13)
        {
            needToAttack = true;
        }
        else
        {
            needToAttack = false;
        }

        if (needToAttack == true)
        {
            Attack();
        }
        else
        {
            Idle();
        }

        

        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            timer = time;
            isRight = !isRight;
        }
    }

    private void Idle()
    {
        if (isRight == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            spriteRenderer.flipX = true;
        }

        if (isRight == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            spriteRenderer.flipX = false;
        }
    }

    private void Attack()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        if (distance > 0) spriteRenderer.flipX = true;
        if (distance < 0) spriteRenderer.flipX = false;
    }
}
