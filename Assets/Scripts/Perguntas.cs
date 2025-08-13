using TMPro;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Perguntas : MonoBehaviour
{
    [System.Serializable]
    public class Pergunta
    {
        public string textoPergunta;
        public string[] alternativas;
        public int respostaCorreta; // índice da alternativa correta
    }
    [SerializeField] private string nomeCena;
    public Pergunta[] perguntas;
    public TextMeshProUGUI textoPergunta;
    public Button[] botoesAlternativas;
    public TextMeshProUGUI textoResultado;

    private int perguntaAtual = 0;

    void Start()
    {
        textoResultado.material.color = Color.white;
    }

    void MostrarPergunta()
    {
        textoResultado.text = "";

        Pergunta p = perguntas[perguntaAtual];
        textoPergunta.text = p.textoPergunta;

        for (int i = 0; i < botoesAlternativas.Length; i++)
        {
            if (i < p.alternativas.Length)
            {
                botoesAlternativas[i].gameObject.SetActive(true);
                botoesAlternativas[i].GetComponentInChildren<TextMeshProUGUI>().text = p.alternativas[i];

                int indice = i; // evita problema de referência
                botoesAlternativas[i].onClick.RemoveAllListeners();
                botoesAlternativas[i].onClick.AddListener(() => Responder(indice));
            }
            else
            {
                botoesAlternativas[i].gameObject.SetActive(false);
            }
        }
    }

    void Responder(int alternativaEscolhida)
    {
        Pergunta p = perguntas[perguntaAtual];

        if (alternativaEscolhida == p.respostaCorreta)
        {
            textoResultado.color = Color.green;
            textoResultado.text = "Resposta correta!";

        }
        else
        {
            textoResultado.color = Color.red;
            textoResultado.text = "Resposta errada!";
        }

        perguntaAtual++;
        if (perguntaAtual < perguntas.Length)
        {
            Invoke(nameof(MostrarPergunta), 2f);
            textoResultado.color = Color.white;
        }
        else
        {
            textoPergunta.text = "Fim do quiz!";
            SceneManager.LoadScene(nomeCena);
            foreach (Button b in botoesAlternativas)
            {
                b.gameObject.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MostrarPergunta();
        }
    }
}
