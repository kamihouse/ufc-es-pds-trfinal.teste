/// <summary>
/// Model que controla as açoes para as casas de <see cref="Sorte"/> do tabuleiro.
/// </summary>
public class Sorte : ILogradouro
{
		/// <summary>
		/// Posiçao da <see cref="Sorte"/> no tabuleiro.
		/// </summary>
		private int posicaoNoTabuleiro;

		/// <summary>
		/// Armazena o tipo de sorte.
		/// </summary>
		private int tipoDeSorte;


		/// <summary>
		/// Inicializa uma nova instância da classe <see cref="Sorte"/>.
		/// </summary>
		/// <param name="indice">Posicao indice.</param>
		/// <param name="testeSortes">Teste sortes.</param>
		public Sorte (int posicaoIndice, int testeSortes)
		{
				this.posicaoNoTabuleiro = posicaoIndice;
				this.tipoDeSorte = testeSortes;
		}


		/// <summary>
		/// É executado quando o jogador para em um logradouro.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		public bool acao (Jogador jogador)
		{
				if (tipoDeSorte == 1) {
						jogador.setPosicao(jogador.getPosicao() + (int)Constantes.Sorte.AvancaLogradouro);
						return false;		
				} else if (tipoDeSorte == 2) {
						jogador.setPosicao(jogador.getPosicao() - (int)Constantes.Sorte.RecuaLogradouro);
						return false;	
				} else if (tipoDeSorte == 3) {
						jogador.cobrarValor((int)Constantes.Sorte.CreditaSaldo);
						return false;
				}

				if (tipoDeSorte == 4) {
						jogador.setSaldo(jogador.getSaldo() + (int)Constantes.Sorte.DebitaSaldo);
				}

				return false;	
		}


		/// <summary>
		/// Retorna a posicao (índice) do logradouro em questão.
		/// </summary>
		/// <returns>Indice.</returns>
		public int getPosicaoIndice ()
		{
				return this.posicaoNoTabuleiro;
		}


		// Devemos criar uma classe para a cartaSorte com 2 atributos...
		private void modificaSaldo ()
		{

		}


		// Devemos criar uma classe para a cartaSorte com 2 atributos...
		private void modificaPosicao ()
		{

		}


		/// <summary>
		/// Sorteia pelo indice da coleções e executar os métodos de acordo com o contexto
		/// </summary>
		public void sorteia ()
		{
				this.modificaSaldo ();
				this.modificaPosicao ();
		}
}
