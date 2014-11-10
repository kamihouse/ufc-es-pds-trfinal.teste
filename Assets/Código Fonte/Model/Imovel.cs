using UnityEngine;
using System.Collections;

/// <summary>
/// Model que controla as açoes que podem ser feitas no jogo com uma entidade do tipo <see cref="Imovel"/>.
/// </summary>
public class Imovel : ILogradouro
{
		/// <summary>
		/// Identiicador do jogador dono da entidade <see cref="Imovel"/>.
		/// </summary>
		private	int jogadorDono;
		
		/// <summary>
		/// Preço de compra da entidade <see cref="Imovel"/>.
		/// </summary>
		private int preco;

		/// <summary>
		/// Taxa que o jogador adversario deve pagar ao passar pelo imovel.
		/// </summary>
		private int taxa;

	
		/// <summary>
		/// Construtor da classe. Recebe o indice que representa a posiçao do <see cref="Imovel"/> no tabuleiro.
		/// Recebe  o preço de compra que o <see cref="Imovel"/> deve ter.
		/// </summary>
		/// <param name="preco">Preco.</param>
		public Imovel (int preco)
		{
				this.jogadorDono		= (int)Constantes.Jogador.Nenhum;
				this.preco				= preco;
				double calcTaxa			= preco * 0.2; 
				this.taxa				= (int)calcTaxa;
		}


		/// <summary>
		/// Este método detecta que tipo de açao o jogo deve executar quando o jogador vai para a posiçao onde o <see cref="Imovel"/> está.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		public bool acao (Jogador jogador, Jogador outroJogador)
		{
				if (this.jogadorDono == (int)Constantes.Jogador.Nenhum) {
						return true;
				} else if (this.jogadorDono != jogador.getIdJogador ()) {
						cobrarTaxa (jogador,outroJogador);
						return false;
				}
				return false;
		}
	

		/// <summary>
		///Realiza a compra da imovel para o jogador que e passado por parametro.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		/// <param name="decisaoDoJogador">Caso <c>true</c> efetua a compra.</param>
		public void comprar (Jogador jogador, bool decisaoDoJogador)
		{
				if (decisaoDoJogador) {
						this.jogadorDono = jogador.getIdJogador ();
						jogador.cobrarValor (this.preco);
				}
		}

		
		/// <summary>
		/// Retira do saldo do jogador (cobrando taxa) com o valor da taxa do <see cref="Imovel"/> em que o mesmo está localizado.
		/// </summary>
		/// <param name="j">Jogador.</param>
		public void cobrarTaxa (Jogador jogador,Jogador outroJogador)
		{
				jogador.cobrarValor (this.taxa);
				outroJogador.creditarValor(this.taxa);
		}

		
		/// <summary>
		/// Retorna o preço do <see cref="Imovel"/>
		/// </summary>
		/// <returns>The preco.</returns>
		public int getPreco ()
		{
				return this.preco;
		}
}