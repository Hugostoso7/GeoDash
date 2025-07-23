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
    private int dir = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        inputH = Input.GetAxis("Horizontal");
        direcaoTiro = alvo.position - transform.position;
    }

    private void Update()
    {
        MovementInimimgo();
        Runboss();
        Puloboss();
        tempoDeCorrida -= Time.deltaTime;
        tempoDePulo -= Time.deltaTime;
        tempoDeTiro -= Time.deltaTime;
        TiroBoss();
    }

    private void MovementInimimgo()
    {
        if (dir == 1)
        {
            transform.position += new Vector3(1 * velocidade * Time.deltaTime, 0, 0);
        }
        else if (dir == 2)
        {
            transform.position += new Vector3(-1 * velocidade * Time.deltaTime, 0, 0);
        }
    }

    private void Runboss()
    {
        if (tempoDeCorrida <= 0)
        {
            direcaoDash = alvo.position - transform.position;
            rb.AddForce(Vector2.right * direcaoDash, ForceMode2D.Impulse);
            tempoDeCorrida = 6;
        }
    }

    private void Puloboss()
    {
        if (tempoDePulo <= 0)
        {
            direcaoDash = alvo.position - transform.position * forcaPulo;
            rb.AddForce(Vector2.up * direcaoDash, ForceMode2D.Impulse);
            tempoDePulo = 8;
        }
    }

    private void TiroBoss()
    {
        //Quaternion quaternion = alvo.rotation;
        //if (tempoDeTiro <= 0)
        //{
        //    GameObject tiro = Instantiate(tiroPrefab, miraPrefab.transform.position, miraPrefab.transform.rotation);
        //    Rigidbody2D rbTiro = tiro.GetComponent<Rigidbody2D>();
        //    rbTiro.AddForce(Vector2.right * forcaTiro, ForceMode2D.Impulse);
        //    tempoDeTiro = 10;
        //    Destroy(tiro);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            dir = 2;
        }
        else if (collision.gameObject.layer == 7)
        {
            dir = 1;
        }
    }
}
