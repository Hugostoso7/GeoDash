using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private AudioSource player;
    [SerializeField] private AudioClip som;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Jogar()
    {
        TocarSom();
        Invoke("SelecionarPersonagem", 1f);
    }

    public void Creditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void BlueEyes()
    {
        SceneManager.LoadScene("BlueEyes");
    }

    public void ThousandDragon()
    {
        SceneManager.LoadScene("ThousandDragon");
    }

    public void ChegadaPoco()
    {
        SceneManager.LoadScene("ChegadaPoco");

    }

    public void LutaFinal()
    {
        SceneManager.LoadScene("LutaFinal");
    }

    public void Vitoria()
    {
        SceneManager.LoadScene("Vitoria");
    }

    public void Derrota()
    {
        SceneManager.LoadScene("Derrota");
    }
    public void SlyferSky()
    {
        SceneManager.LoadScene("SlyferSky");
    }

    public void TocarSom()
    {
        player.PlayOneShot(som);
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("SceneTest");
    }

    public void continueS()
    {
        SceneManager.LoadScene("Narrativa1S");
    }

    public void continueTD()
    {
        SceneManager.LoadScene("Narrativa1TD");
    }

    public void Cena1TD()
    {
        SceneManager.LoadScene("Cena1TD");
    }
    public void Caminho1TD()
    {
        SceneManager.LoadScene("Caminho1TD");
    }

    public void Caminho2TD()
    {
        SceneManager.LoadScene("Caminho2TD");
    }

    public void LutaTDvsC()
    {
        SceneManager.LoadScene("TDvsCoruja");
    }

    public void Conversa1TDCoruja()
    {
        SceneManager.LoadScene("Conversa1TDC");
    }
    public void Conversa2TDCoruja()
    {
        SceneManager.LoadScene("Conversa2TDC");
    }

    public void continueBW()
    {
        SceneManager.LoadScene("Narrativa1BW");
    }

    public void Mapa()
    {
        SceneManager.LoadScene("mapa");

    }






}
