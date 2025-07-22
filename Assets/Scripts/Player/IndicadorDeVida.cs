using UnityEngine;

public class IndicadorDeVida : MonoBehaviour
{
    private bool vida1;
    private bool vida2;
    private bool vida3;
    private SpriteRenderer spriteRenderer;
    private Vida vida;

    private void Start()
    {
        vida = GetComponent<Vida>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void ExibirVida(Sprite s1, Sprite s2, Sprite s3, Color c )
    {

    }
}
