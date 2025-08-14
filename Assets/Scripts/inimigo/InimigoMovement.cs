using UnityEngine;

public class InimigoMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 3f;
    private Rigidbody2D rb;
    private int dir = 1;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
         MovementInimimgo();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6)
        {
            dir = 2;
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (collision.gameObject.layer == 7)
        {
            dir = 1;
            GetComponent<SpriteRenderer>().flipX = false;
        }
    }
}


