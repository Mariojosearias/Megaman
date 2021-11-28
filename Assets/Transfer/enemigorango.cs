using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigorango : MonoBehaviour
{
    public float visionradio;
    GameObject player;
    Vector3 initialposition;
    public GameObject baladisparada;
    public Animator animator;

    private Transform dispararder;
    private Transform dispararizq;
    int espera = 0;

    // Start is called before the first frame update
    void Start()
    {
        //myAnimator = GetComponent<Animator>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        initialposition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initialposition;

        float dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist < visionradio)
        {
            target = player.transform.position;
            if (dispararder != null && dispararizq != null && baladisparada != null && espera==0)
            {
                espera = 1;
                animator.SetBool ("Shoot",true);
                GameObject balder = Instantiate(baladisparada, dispararder.position, Quaternion.identity) as GameObject;
                GameObject balizq = Instantiate(baladisparada, dispararizq.position, Quaternion.identity) as GameObject;
                bulletDos balitader = balder.GetComponent<bulletDos>();
                bulletDos balitaizq = balizq.GetComponent<bulletDos>();
                balitader.posicion = new Vector2(1f, 1f);
                balitaizq.posicion = new Vector2(-1f, 1f);
                Debug.Log("DISPARA PERRA");
                StartCoroutine("disparos");
            }
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
        Debug.Log("aqui dispara");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionradio);
    }
}
