using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CorridaBoss : MonoBehaviour
{
    [SerializeField] private float velocidade = 4f;
    [SerializeField] private float tempoDeCorrida = 6f;
    [SerializeField] private float tempoDePulo = 8f;
    [SerializeField] private float tempoDeTiro = 10f;
    [SerializeField] private float forcaPulo = 5f;
    [SerializeField] private float forcaTiro = 5f;
    [SerializeField] private Transform alvo;
    [SerializeField] private GameObject tiroPrefab;
    [SerializeField] private GameObject miraPrefab;
    private float inputH;
    private Vector2 direcaoDash;
    private Vector2 direcaoTiro;
    private Rigidbody2D rb;
    private GameObject ataque;
    private SpriteRenderer sR;
    private int dir = 1;
    private bool atak = true;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
        inputH = Input.GetAxis("Horizontal");
        direcaoTiro = alvo.position - transform.position;
        miraPrefab = GameObject.Find("TiroMira");
    }

    private void Update()
    {
        MovementInimimgo();
    }

    private void MovementInimimgo()
    {
        if (dir != 0)
        {
            if (dir == 1)
            {
                transform.position += new Vector3(dir * velocidade * Time.deltaTime, 0, 0);
                sR.flipX = false;
                miraPrefab.GetComponent<SpriteRenderer>().flipX = false;
            }
            else if (dir == -1)
            {
                transform.position += new Vector3(dir * velocidade * Time.deltaTime, 0, 0);
                sR.flipX = true;
                miraPrefab.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }

    private void Runboss()
    {
        direcaoDash = alvo.position - transform.position;
        rb.AddForce(Vector2.right * direcaoDash, ForceMode2D.Impulse);
        tempoDeCorrida = 6;
    }

    private void Puloboss()
    {
        direcaoDash = alvo.position - transform.position * forcaPulo;
        rb.AddForce(Vector2.up * direcaoDash, ForceMode2D.Impulse);
        tempoDePulo = 8;
    }

    private void TiroBoss()
    {
        Instantiate(tiroPrefab, miraPrefab.transform.position, miraPrefab.transform.rotation);
    }

    IEnumerator RotBossDir()
    {
        dir = 0;
        transform.position += new Vector3(1 * dir * Time.deltaTime, 0, 0);
        TiroBoss();
        yield return new WaitForSeconds(1f);
        dir = -1;
        yield return new WaitForSeconds(1f);
        Puloboss();
    }

    IEnumerator RotBossEsq()
    {
        dir = 0;
        transform.position += new Vector3(1 * dir * Time.deltaTime, 0, 0);
        TiroBoss();
        yield return new WaitForSeconds(1f);
        dir = 1;
        yield return new WaitForSeconds(1f);
        Puloboss();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine(RotBossDir());
        }
        else if (collision.gameObject.layer == 7)
        {
            StartCoroutine(RotBossEsq());
        }
    }
}
