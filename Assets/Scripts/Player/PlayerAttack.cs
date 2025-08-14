using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float alcance = 1f;
    public LayerMask inimigoLayer;

    // Essa função é chamada pelo Animation Event
    public void AplicarDano()
    {
        // Detecta inimigos no alcance
        Collider2D[] inimigos = Physics2D.OverlapCircleAll(transform.position, alcance, inimigoLayer);

        foreach (Collider2D inimigo in inimigos)
        {
            // Tenta pegar o script de vida do inimigo
            inimigo.GetComponent<Vida>()?.LevarDano();
        }
    }

    // Só para visualizar o alcance no editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alcance);
    }
}
