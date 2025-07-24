using UnityEngine;
using UnityEngine.SceneManagement;

public class MudancaDeCena : MonoBehaviour
{
    [SerializeField] private string nomeCena;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(nomeCena);
        }
    }
}
