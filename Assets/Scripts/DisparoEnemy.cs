using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemy : MonoBehaviour
{
    [SerializeField] Transform player_pos;
    public Transform fire_point;
    public GameObject bala;
    private float tiempo;
    public int Radius;

    // Start is called before the first frame update
    void Start()
    {
        //player_pos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D Hitting = Physics2D.OverlapCircle(transform.position, Radius, LayerMask.GetMask("Player"));

        if (Hitting != null)
        {
            Flip();
            Disparo();
        }

    }
    public void Flip()
    {
        if (player_pos.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }
    public void Disparo()
    {

        tiempo += Time.deltaTime;

        if (tiempo >= 2)
        {
            GameObject bullet = Instantiate(bala, transform.position, transform.rotation);

            bool direccion = transform.localScale.x == 1;

            (bullet.GetComponent<Bala_Enemy>()).Shoot(direccion, 10);
            tiempo = 0;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

