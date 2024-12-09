using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Jogador : MonoBehaviour
{
    private CharacterController controladorPersonagem;
    private Vector3 movimento;


    public float forcaPulo = 24f; // Força do pulo


    public float gravidade = 9.81f * 2f; // Aumenta a gravidade 

    private void Awake()
    {
            controladorPersonagem = GetComponent<CharacterController>(); // Pega o CharacterController do jogador
    }

    private void OnEnable()
    {
        movimento = Vector3.zero; // Zera o movimento
    }

    private void Update()
    {
            movimento += gravidade * Time.deltaTime * Vector3.down; // Adiciona a gravidade ao movimento

        if (controladorPersonagem.isGrounded)
        {
             movimento = Vector3.down; // Zera o movimento

            if (Input.GetButton("Jump")) // Se o jogador apertar o botão de pulo
            {
                movimento = Vector3.up * forcaPulo;
            }
        }

        controladorPersonagem.Move(movimento * Time.deltaTime); // Move o jogador
    }

    private void OnTriggerEnter(Collider other) // Quando o jogador colidir com um obstáculo
    {
        if (other.CompareTag("Obstaculo"))
        {
            GameManager.Instance.GameOver(); 
        }
    }
}