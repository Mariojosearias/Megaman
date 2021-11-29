using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemy3 : MonoBehaviour
{
    [SerializeField] Transform player_pos;
    public GameObject bala;
    public Animator ani;
    private float tiempo;
    public int Radius;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D Hitting = Physics2D.OverlapCircle(transform.position, Radius, LayerMask.GetMask("Player"));
        if (Hitting != null)
        {
            Disparo();
        }
    }
    public void Disparo()
    {
        tiempo += Time.deltaTime;
        if (tiempo >= 2)
        {
            GameObject balder = Instantiate(bala, transform.position, transform.rotation);
            GameObject balizq = Instantiate(bala, transform.position, transform.rotation);

            bulletDos balitader = balder.GetComponent<bulletDos>();
            bulletDos balitaizq = balizq.GetComponent<bulletDos>();

            balitader.posicion = new Vector2(1f, 1f);
            balitaizq.posicion = new Vector2(-1f, 1f);

            ani = GetComponent<Animator>();
            ani.SetBool("Shoot", true);
            tiempo = 0;
            StartCoroutine("Idle");
        }
    }
    IEnumerator Idle()
    {
        yield return new WaitForSeconds(3);
        ani.SetBool("Shoot", false);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}

