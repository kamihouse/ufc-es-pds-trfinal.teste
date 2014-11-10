/// <summary>
/// Model Jogador, que define e configura as propriedades referente a um esqueleto de <see cref="Jogador"/> no Banco Imobiliário.
/// </summary>
public class Jogador
{
		/// <summary>
		/// Armazena a posição em que o <see cref="Jogador"/> se encontra no tabuleiro.
		/// </summary>
		private int posicao;

		/// <summary>
		/// Armazena o #ID do <see cref="Jogador"/> atual.
		/// </summary>
		private int idJogador;

		/// <summary>
		/// Armazena o Saldo atual do <see cref="Jogador"/>.
		/// </summary>
		private int saldo;


		/// <summary>
		/// Construtor da Classe <see cref="Jogador"/>.
		/// </summary>
		/// <param name="idJogador">Jogador.</param>
		/// <param name="saldo">Saldo.</param>
		public Jogador (int idJogador, int saldo)
		{
				this.posicao	= -1;
				this.idJogador	= idJogador;
				this.saldo		= saldo;
		}


		/// <summary>
		/// Recupera a posição em que o <see cref="Jogador"/> se encontra.
		/// </summary>
		/// <returns>A posicao.</returns>
		public int getPosicao ()
		{
				return this.posicao;
		}

		
		/// <summary>
		/// Recupera o ID <see cref="Jogador"/> atual da partida.
		/// </summary>
		/// <returns>The identifier jogador.</returns>
		public int getIdJogador ()
		{
				return this.idJogador;
		}


		/// <summary>
		/// Recupera o Saldo atual do <see cref="Jogador"/>.
		/// </summary>
		/// <returns>Ssaldo.</returns>
		public int getSaldo ()
		{
				return this.saldo;
		}


		/// <summary>
		/// Seta a posição da casa em que o <see cref="Jogador"/> se encontra.
		/// </summary>
		/// <param name="posicao">Posicao.</param>
		public void setPosicao (int posicao)
		{
				this.posicao = posicao;
		}
		
		
		/// <summary>
		/// Método para cobra valores do saldo do <see cref="Jogador"/>.
		/// </summary>
		/// <param name="valor">int Valor.</param>
		public void cobrarValor (int valor)
		{
				this.saldo -= valor;
		}

		
		/// <summary>
		/// Método que credita valor no atributo saldo.
		/// </summary>
		/// <param name="valor">Valor.</param>
		public void creditarValor(int valor)
		{
				this.saldo += valor;
		}
}
