using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    [SerializeField] private GameObject destroyTiroPreFab;
    [SerializeField] private float forcaTiro;
    [SerializeField] Transform alvo;
    [SerializeField] LayerMask layerMask;
    Rigidbody2D rb;
    Vida vida;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = GetComponent<Vida>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        Tiro();
    }
    private void Tiro()
    {
        Vector3 direcao = alvo.position - transform.position;
        direcao.y = rb.gravityScale;
        transform.position += direcao * forcaTiro * Time.deltaTime;
        StartCoroutine(TempoTiro());
    }

    IEnumerator TempoTiro()
    {
        yield return new WaitForSeconds(3.0f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.layer == layerMask)
        {
            Instantiate(destroyTiroPreFab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
