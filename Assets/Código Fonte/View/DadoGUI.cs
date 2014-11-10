using UnityEngine;
using System;
using System.Collections;

/// <summary>
/// View responsavel por manipular a interface grafica dos Dados do jogo
/// </summary>
public class DadoGUI : MonoBehaviour
{
		/// <summary>
		/// Armazena o valor do dado 1.
		/// </summary>
		private string valorDado1 = "1";

		/// <summary>
		/// Armazena o valor do dado 2.
		/// </summary>
		private string valorDado2 = "0";

		/// <summary>
		/// Armazena um booleano que permite saber qual o jogador atual.
		/// </summary>
		public bool jogouDado;

		/// <summary>
		/// Armazena um booleano que permite saber quando o formulario dos dados deve ser exibido na tela.
		/// </summary>
		public bool exibeDados;
		

		/// <summary>
		/// Start this instance.
		/// Método padrao do Unity que inicializa os GameObjects.
		/// </summary>
		void Start ()
		{
				jogouDado = false;
				MostrarDados ();
		}
	

		/// <summary>
		/// Update this instance.
		/// Método padrao do Unity que atuaaliza os GameObjects.
		/// </summary>
		void Update ()
		{
	
		}


		/// <summary>
		/// Raises the GU event.
		/// Metodo default do Unity para criar a interface grafica.
		/// </summary>
		void OnGUI ()
		{
				if (this.exibeDados) {
						this.valorDado1 = GUI.TextField (new Rect (1071, 268, 120, 20), this.valorDado1, 25);
						this.valorDado2 = GUI.TextField (new Rect (1071, 298, 120, 20), this.valorDado2, 25);
				
						if (GUI.Button (new Rect (1076, 328, 110, 30), "Jogar Dados")) {
								EsconderDados ();
								jogouDado = true;
						}
				}
		}


		/// <summary>
		/// Altera o atributo de visibilidade do Dado para TRUE na Gui.
		/// </summary>
		public void MostrarDados ()
		{
				this.exibeDados = true;
		}


		/// <summary>
		/// Altera o atributo de visibilidade do para FALSE Dado na Gui.
		/// </summary>
		public void EsconderDados ()
		{
				this.exibeDados = false;
		}


		/// <summary>
		/// Informa se o jogar jogou ou não o dado.
		/// </summary>
		/// <returns><c>true</c>, caso o dado foi jogado, <c>false</c> caso contrário.</returns>
		public bool JogadorJogouDados ()
		{
				return this.jogouDado;
		}


		/// <summary>
		/// Retorna o valor dos dois dados somados.
		/// </summary>
		/// <returns>Valor dados.</returns>
		public int somaValorDados ()
		{
				int vDado1 = Convert.ToInt32 (this.valorDado1);
				int vDado2 = Convert.ToInt32 (this.valorDado2);
				
				if((vDado1+vDado2) <= 0){
					return 1;
				}

				return vDado1 + vDado2;
		}


		/// <summary>
		/// Altenar entre os jogadores atuais.
		/// </summary>
		public void MudarPlayer ()
		{
				this.jogouDado = false;
				MostrarDados ();
		}
}
