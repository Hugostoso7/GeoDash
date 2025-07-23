using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MudarDeFase : MonoBehaviour
{
    [SerializeField] private string nomeDaProximaFase = "";
    [SerializeField] private float tempoDeTransicao = 1.0f;
    private Animator animator;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Saida"))
        {
            if (!string.IsNullOrEmpty(nomeDaProximaFase))
            {
                StartCoroutine(TransicaoParaProximaFase());
            }
        }
    }
    IEnumerator TransicaoParaProximaFase()
    {

        yield return new WaitForSeconds(tempoDeTransicao);
        SceneManager.LoadScene(nomeDaProximaFase);
    }


}