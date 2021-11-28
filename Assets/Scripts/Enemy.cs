using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public SpriteRenderer sprite;
    public Animator ani;
    Blink material;
    
    public int HealthPoints;
    private bool isDamaged;

    public DisparoEnemy disparoEnemy;
    public BoxCollider2D boxCollider;
    public Enemy1Score score;
    [SerializeField] AudioClip sfx_enemydeath;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        material = GetComponent<Blink>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (gameManager.isRunning == true)
            {
                (GameObject.Find("GameManager").GetComponent<GameManager>()).CaptureEnemy();
                Destroy(this.gameObject);
            }
            else
            {
                HealthPoints -= collision.gameObject.GetComponent<Bullet>().DamageDone();

                StartCoroutine(Damager());
                if (HealthPoints <= 0)
                {
                    (GameObject.Find("GameManager").GetComponent<GameManager>()).CaptureEnemy();
                    ani = GetComponent<Animator>();
                    ani.SetBool("Death", true);
                    AudioSource.PlayClipAtPoint(sfx_enemydeath, Camera.main.transform.position);
                }

                IEnumerator Damager()
                {
                    isDamaged = true;
                    GetComponent<SpriteRenderer>().material = GetComponent<Blink>().blink;
                    yield return new WaitForSeconds(0.5f);
                    isDamaged = false;
                    GetComponent<SpriteRenderer>().material = GetComponent<Blink>().original;
                }
            }
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
    void InActive()
    {
        disparoEnemy.enabled = false;
        boxCollider.enabled = false;
        (score.GetComponent<Enemy1Score>()).OnDestroy();
    }
}
