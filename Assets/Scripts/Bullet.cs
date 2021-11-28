using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator ani;
    public float speed;
    public int Damage;

    [SerializeField] AudioClip sfx_bullet;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = transform.right * speed;
    }
    public void Shoot(bool dir, float speed)
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;

        AudioSource.PlayClipAtPoint(sfx_bullet, Camera.main.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataformas"))
        {
            ani = GetComponent<Animator>();
            ani.SetTrigger("Destruir");
            rb.velocity = Vector2.zero;
        }
        if (other.CompareTag("Enemy"))
        {
            ani = GetComponent<Animator>();
            ani.SetTrigger("Destruir");
            rb.velocity = Vector2.zero;
        }
    }
    public int DamageDone()
    {
        return Damage;
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

