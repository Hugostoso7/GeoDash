using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class TiroBoss : MonoBehaviour
{
    [SerializeField] private GameObject destroyTiroPreFab;
    [SerializeField] private float forcaTiro;
    [SerializeField] Transform alvo;
    [SerializeField] BoxCollider2D collider;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        Vector3 direcao = alvo.position - transform.position;
        direcao.y = rb.gravityScale;
        transform.position += direcao * forcaTiro * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collider || collision.gameObject.tag == "Player")
        {
            Instantiate(destroyTiroPreFab, gameObject.transform.position, gameObject.transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
