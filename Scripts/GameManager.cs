using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; } 

    public float velocidadeInicial = 5f;
    public float taxaDeAumentoDeVelocidade = 0.1f;
    public float Velocidade { get; private set; } 

    public TextMeshProUGUI TextoGameOver;
    public Button Button;
    public TextMeshProUGUI Pontos;


    private Jogador jogador;
    private Spawner spawner;

    private float pontuacao = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // Garante que só exista uma instância do GameManager
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        jogador = FindObjectOfType<Jogador>(); // Encontra o jogador na cena
        spawner = FindObjectOfType<Spawner>(); // Encontra o spawner na cena
        
        Velocidade = velocidadeInicial; 

        NewGame();
    }

    private void Update()
    {
        Velocidade += taxaDeAumentoDeVelocidade * Time.deltaTime; // Aumenta a velocidade com o tempo
        pontuacao += Time.deltaTime * 5 ; // Aumenta a pontuação com o tempo
        Pontos.text = Mathf.FloorToInt(pontuacao).ToString();
    }

    public void NewGame()
    {
        Obstaculos[] obstaculos = FindObjectsOfType<Obstaculos>();

        foreach (var obstaculos1 in obstaculos) {
            Destroy(obstaculos1.gameObject);
        } // Destroi todos os obstáculos na cena

        
        Velocidade = velocidadeInicial;
        enabled = true;

        jogador.gameObject.SetActive(true); // Ativa o jogador
        spawner.gameObject.SetActive(true); // Ativa o spawner

        TextoGameOver.gameObject.SetActive(false); // Desativa o texto de game over
        Button.gameObject.SetActive(false); // Desativa o botão de game over
        



    }
    public void GameOver()
    {
        Velocidade = 0f;
        enabled = false;
        jogador.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        TextoGameOver.gameObject.SetActive(true);
        Button.gameObject.SetActive(true);
        pontuacao = 0;
    } // Função que é chamada quando o jogador perde
}
