/// <summary>
/// Model que controla as açoes para as casas de <see cref="Sorte"/> do tabuleiro.
/// </summary>
public class Sorte : ILogradouro
{
		/// <summary>
		/// Armazena o tipo de sorte.
		/// </summary>
		private int tipoDeSorte;


		/// <summary>
		/// Inicializa uma nova instância da classe <see cref="Sorte"/>.
		/// </summary>
		/// <param name="tipoDaSorte">Tipo da sorte.</param>
		public Sorte (int tipoDaSorte)
		{
				this.tipoDeSorte = tipoDaSorte;
		}


		/// <summary>
		/// É executado quando o jogador para em um logradouro.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		/// <param name="outroJogador">Outro jogador.</param>
		public bool acao (Jogador jogador, Jogador outroJogador)
		{
				if (tipoDeSorte == 1) {
						jogador.setPosicao(jogador.getPosicao() + (int)Constantes.Sorte.AvancaLogradouro);
						return false;		
				} else if (tipoDeSorte == 2) {
						jogador.setPosicao(jogador.getPosicao() - (int)Constantes.Sorte.RecuaLogradouro);
						return false;	
				} else if (tipoDeSorte == 3) {
						jogador.creditarValor((int)Constantes.Sorte.CreditaSaldo);
						return false;
				}

				if (tipoDeSorte == 4) {
						jogador.cobrarValor((int)Constantes.Sorte.DoaSaldo);
						outroJogador.creditarValor((int)Constantes.Sorte.DoaSaldo);
				}

				return false;	
		}


		// Devemos criar uma classe para a cartaSorte com 2 atributos...
		private void modificaSaldo ()
		{
				// Ao rolar os dados...
		}


		// Devemos criar uma classe para a cartaSorte com 2 atributos...
		private void modificaPosicao ()
		{
				// Ao rolar os dados...
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
