using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala_Enemy: MonoBehaviour
{
    private Rigidbody2D rb;
    public SpriteRenderer SpRenderer;
    public Animator ani;
    public float speed;
    public void Shoot(bool dir, float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        if (dir)
        {
            rb.velocity = new Vector2(-speed, 0);
            SpRenderer.flipX = false;
        }
        else
        {
            rb.velocity = new Vector2(speed, 0);
            SpRenderer.flipX = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataformas"))
        {
            ani = GetComponent<Animator>();
            ani.SetTrigger("Destruir");
            rb.velocity = Vector2.zero;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
