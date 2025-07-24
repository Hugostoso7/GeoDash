using TMPro;
using UnityEngine;

public class Perguntas : MonoBehaviour
{
    [TextArea] TextMeshProUGUI texto;
    [SerializeField] Vector2 t;

    private void Start()
    {
        texto = GameObject.Find("Texto").GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            texto.transform.position = t;
            texto.text = ToString();
        }
    }
}
