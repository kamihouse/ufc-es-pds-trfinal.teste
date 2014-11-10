using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// View que gerencia os elementos visuais do jogo
/// </summary>
public class TabuleiroGUI : MonoBehaviour
{
		public GameObject playerVermelho;
		public GameObject playerAzul;
		public GameObject casaPlayerVermelo;
		public GameObject casaPlayerAzul;

		private GameObject casaComprada;

		private List<Vector3> posicoes = new List<Vector3> ();
		

		// Inicializa a lista de posiçoes. 
		void Start ()
		{
				float x = -4.033f;
				float y = -3.75f;
				float z = 0f;

				//Preeenche a lista de posiçoes.
				for (int i =0; i<9; i++) {
			
						posicoes.Add (new Vector3 (x, y, z));
						x += 0.79f;
				}
		
				y += 0.79f;
				for (int i=0; i<9; i++) {
						posicoes.Add (new Vector3 (x, y, z));
						y += 0.79f;
				}
				x -= 0.79f;
		
				for (int i=0; i<9; i++) {
						posicoes.Add (new Vector3 (x, y, z));
						x -= 0.79f;
				}
				y -= 0.79f;

				for (int i=0; i<9; i++) {
						posicoes.Add (new Vector3 (x, y, z));
						y -= 0.79f;
				}
		
		}


		// Update is called once per frame
		void Update ()
		{

		}


		/// <summary>
		/// Atualiza a posiçao na tela dos GameObject que representam os jogadores.
		/// </summary>
		/// <param name="idJogadorDaVez">Identifier jogador da vez.</param>
		/// <param name="posicaoJogador">Posicao jogador.</param>
		public void percorerTabuleiro (int idJogadorDaVez, int posicaoJogador)
		{
				if (idJogadorDaVez == 0) {
						playerVermelho.transform.position = posicoes [posicaoJogador];
				} else {
						if (idJogadorDaVez == 1) {
								playerAzul.transform.position = posicoes [posicaoJogador];
						}
				}
		}


		/// <summary>
		/// Adiciona a cada casa o Gameobject que representa que a mesma foi comprada por um jogador
		/// </summary>
		/// <param name="idJogadorDaVez">Identifier jogador da vez.</param>
		/// <param name="posicaoJogadorC">Posicao jogador c.</param>
		public void comprarLogradouro (int idJogadorDaVez, int posicaoJogadorC)
		{
				if (idJogadorDaVez == 0) {
						casaComprada = GameObject.Instantiate (casaPlayerVermelo) as GameObject;
						casaComprada.transform.position = posicoes [posicaoJogadorC];
						casaComprada.transform.parent = transform;
				} else if (idJogadorDaVez == 1) {
						casaComprada = GameObject.Instantiate (casaPlayerAzul) as GameObject;
						casaComprada.transform.position = posicoes [posicaoJogadorC];
						casaComprada.transform.parent = transform;
				}
		}
}