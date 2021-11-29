using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigorango : MonoBehaviour
{
    public GameObject baladisparada;
    public Animator animator;
    [SerializeField] Transform player_pos;
    public int Radius;
    private Transform dispararder;
    private Transform dispararizq;
    int espera = 0;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
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
        if (espera == 0)
        {
            espera = 1;
            animator.SetBool("Shoot", true);
            GameObject balder = Instantiate(baladisparada, dispararder.position, Quaternion.identity) as GameObject;
            GameObject balizq = Instantiate(baladisparada, dispararizq.position, Quaternion.identity) as GameObject;
            bulletDos balitader = balder.GetComponent<bulletDos>();
            bulletDos balitaizq = balizq.GetComponent<bulletDos>();
            balitader.posicion = new Vector2(1f, 1f);
            balitaizq.posicion = new Vector2(-1f, 1f);
            StartCoroutine("disparos");
        }
    }
    private void Awake()
    {
        dispararder = transform.Find("disparador1");
        dispararizq = transform.Find("disparador2");
    }

    IEnumerator disparos()
    {
        yield return new WaitForSeconds(3);
        espera = 0;
        animator.SetBool("Shoot",false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
