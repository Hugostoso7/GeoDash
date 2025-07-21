using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    private float inputH;
    private bool noPiso = true;
    private Rigidbody2D rb;
    private Vida vida;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        vida = GetComponent<Vida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (vida.EstaVivo())
        {
            Andar();
            Pular();
        }
        else if (!vida.EstaVivo())
        {
            rb.Sleep();
        }

    }

    private void Andar()
    {
        inputH = Input.GetAxis("Horizontal");
        transform.position += new Vector3(inputH * velocidade * Time.deltaTime, 0, 0);
    }

    private void Pular()
    {
        if(Input.GetKey(KeyCode.Space) && noPiso)
        {
            rb.AddForce(Vector2.up *  forcaPulo, ForceMode2D.Impulse);
            noPiso = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dano")
        {
            vida.LevarDano();
        }

        if (collision.gameObject.tag == "Chao")
        {
            noPiso = true;
        }
    }
}
