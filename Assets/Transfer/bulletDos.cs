using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDos : MonoBehaviour
{

    public float speed;
    public Vector2 posicion;
    public Animator an;

    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = posicion.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Plataformas"))
            {
            an.SetTrigger("Destruir");
            }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
