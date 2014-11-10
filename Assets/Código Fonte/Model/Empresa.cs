/// <summary>
/// Model que controla as açoes que podes ser feitas no jogo com entidade do tipo <see cref="Empresa"/>.
/// </summary>
public class Empresa : ILogradouro
{
		/// <summary>
		/// Armazena o identiicador do jogador que e dono da entidade <see cref="Empresa"/>.
		/// </summary>
		private	int jogadorDono;

		/// <summary>
		/// Armazena o preço de compra da entidade <see cref="Empresa"/>.
		/// </summary>
		private int preco;

		/// <summary>
		/// Armazena a taxa que o jogador adversario deve pagar ao passar pela <see cref="Empresa"/>.
		/// </summary>
		private int taxa;


		/// <summary>
		/// Construtor. Recebe o indice e preço que representa a posiçao da <see cref="Empresa"/> no tabuleiro.
		/// </summary>
		/// <param name="preco">Preco.</param>
		public Empresa (int preco)
		{
				this.jogadorDono		= (int)Constantes.Jogador.Nenhum;
				this.preco				= preco;
				double calculaTaxa		= preco * 0.2; 
				this.taxa				= (int)calculaTaxa;
		}
	
			
		/// <summary>
		/// Interface entre o tabuleiro e seus diferentes tipos de casas.
		/// Este metodo detecta que tipo de açao o jogo deve executar quendo o jogador vai para a posiçao da empresa.
		/// </summary>
		/// <remarks>
		/// É executado quando o <see cref="Jogador"/> para em uma casa.
		/// </remarks>
		/// <param name="j">Jogador.</param>
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
		/// Realiza a compra da empresa para o jogador que e passado por parametro.
		/// </summary>
		/// <param name="j">J.</param>
		private void opcaoCompra (Jogador jogador)
		{
				comprar (jogador, true);
		}


		/// <summary>
		/// Atribui um dono para a empresa.
		/// A decisão é baseada na escolha do jogador na Gui.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		/// <param name="decisaoDoJogador">Caso seja <c>true</c> efetua a compra.</param>
		public void comprar (Jogador jogador, bool decisaoDoJogador)
		{
				if (decisaoDoJogador) {
						this.jogadorDono = jogador.getIdJogador ();
						jogador.cobrarValor (this.preco);
				}
		}


		/// <summary>
		/// Retira do saldo do jogador (cobrando taxa) com o valor da taxa da empresa em que o mesmo está localizado.
		/// Sempre debitamos e depois creditamos.
		/// </summary>
		/// <param name="jogadorDebita">Jogador debita.</param>
		/// <param name="jogadorCredita">Jogador credita.</param>
		public void cobrarTaxa (Jogador jogadorDebita, Jogador jogadorCredita)
		{
				// Debita do Jogador
				jogadorDebita.cobrarValor (this.taxa);
				
				// Credita para Jogador
				jogadorCredita.creditarValor(this.taxa);
		}


		/// <summary>
		/// Retorna o preço da empresa.
		/// </summary>
		/// <returns>Preco.</returns>
		public int getPreco ()
		{
				return this.preco;
		}
}
