using UnityEngine;

public class Vida : MonoBehaviour
{
    [SerializeField] private int vida;
    [SerializeField] private int danoDoInimigo;
    private Rigidbody2D rb;
    private bool estahVivo = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool EstaVivo()
    {
        return estahVivo;
    }
    public void LevarDano()
    {
        vida -= danoDoInimigo;

        if (vida < 1)
        {
            vida = 0;
            rb.Sleep();
            estahVivo = false;
        }
    }
}
