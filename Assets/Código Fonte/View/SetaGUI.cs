using UnityEngine;
using System.Collections;

public class SetaGUI : MonoBehaviour
{
		private Vector2	posicaoVezAzul;
		private Vector2	posicaoVezVermelho;
		private bool	alternarJogador;


		// Use this for initialization
		void Start ()
		{
				posicaoVezVermelho = new Vector3 (0.55f, 1.1f, -5f);
				posicaoVezAzul = new Vector3 (1.85f, 1.1f, -5f);

				alternarJogador = true;
		}


		// Update is called once per frame
		void Update ()
		{
				if (alternarJogador)
						transform.position = this.posicaoVezVermelho;
				else
						transform.position = this.posicaoVezAzul;
		}

		/// <summary>
		/// Mudar a Seta para o jogador azul.
		/// </summary>
		public void mudarVezParaAzul ()
		{
				this.alternarJogador = false;
		}


		/// <summary>
		/// Mudar a Seta para o jogador vermelho.
		/// </summary>
		public void mudarVezParaVermelho ()
		{
				this.alternarJogador = true;
		}
}
