﻿using System.Collections.Generic;

/// <summary>
/// Controlador (Máquina de Estados) que alterna estre os jogadores presentes em uma partida.
/// </summary>
public class JogadorDaVez
{
		/// <summary>
		/// Identifica o Jogador da Vez.
		/// </summary>
		/// <remarks>
		/// Iniciamos o jogo com o Jogador Vermelho (pela disposição da interface).
		/// </remarks>
		private int jogadorDaVez = (int)Constantes.Jogador.Vermelho;

		/// <summary>
		/// Coleção com os jogadores definidos para iniciar uma partida.
		/// </summary>
		private List<Jogador> jogador = new List<Jogador> ();


		/// <summary>
		/// Construtor...
		/// Instancia os jogadores baseando-se na classe <see cref="JogadorDaVez"/> com o saldo inicial planejado.
		/// </summary>
		public JogadorDaVez ()
		{
				jogador.Add (new Jogador ((int)Constantes.Jogador.Vermelho, (int)Constantes.Saldo.Inicial));
				jogador.Add (new Jogador ((int)Constantes.Jogador.Azul, (int)Constantes.Saldo.Inicial));
		}


		/// <summary>
		/// Recupera o objeto Jogador da vez na partida iniciada.
		/// </summary>
		/// <returns>Jogador da vez.</returns>
		public Jogador getJogadorDaVez ()
		{
				return jogador [jogadorDaVez];
		}


		/// <summary>
		/// Método que verifica o jogador atual da partida e informa qual será o próximo a jogar.
		/// </summary>
		public void proximoJogador ()
		{
				if (this.jogadorDaVez == (int)Constantes.Jogador.Vermelho)
						// Passamos a vez para o Jogador Azul
						jogadorDaVez = (int)Constantes.Jogador.Azul;
				else
						// Mantemos a vez do Jogador Vermelho
						jogadorDaVez = (int)Constantes.Jogador.Vermelho;
		}
}
