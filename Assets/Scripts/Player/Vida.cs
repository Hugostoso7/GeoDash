using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{
    [SerializeField] public int vida = 3;
    [SerializeField] private int danoDoInimigo = 1;
    [SerializeField] private Image imagemVida;
    [SerializeField] private Sprite sVida4;
    [SerializeField] private Sprite sVida3;
    [SerializeField] private Sprite sVida2;
    [SerializeField] private Sprite sVida1;
    [SerializeField] private Sprite gameOver;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inimigo;
    private Rigidbody2D rb;
    private bool estahVivo = true;
    private Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = rb.GetComponent<Animator>();
        if (imagemVida == null)
        {
            GameObject.Find("ImagemVida");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!estahVivo && player != null && inimigo == null)
        {
            imagemVida.sprite = gameOver;
        }
    }
    public bool EstaVivo()
    {
        return estahVivo;
    }
    public void LevarDano()
    {
        vida -= danoDoInimigo;
        
        if (player != null)
        {
            anim.SetTrigger("Hurt");
            ExibirVida();
        }

        if (vida < 1)
        {
            vida = 0;
            rb.Sleep();
            estahVivo = false;
        }
    }

    private void ExibirVida()
    {
        imagemVida.enabled = true;
        if (vida == 1)
        {
            imagemVida.sprite = sVida1;
        }

        else if (vida == 2)
        {
            imagemVida.sprite = sVida2;
        }

        else if (vida == 3)
        {
            imagemVida.sprite = sVida3;
        }
        else if (vida == 4)
        {
            imagemVida.sprite = sVida4;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (inimigo != null && player == null)
        {
            if (collision.gameObject.tag == "PontoAtaque")
            {
                LevarDano();
            }
        }
    }

    private void Morrer()
    {
        if (vida <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
