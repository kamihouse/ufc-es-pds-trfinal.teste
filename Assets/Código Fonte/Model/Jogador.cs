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
		/// Armazena o <see cref="Jogador"/> atual.
		/// </summary>
		private int JogadorAtual;

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
				this.posicao = -1;
				this.JogadorAtual = idJogador;
				this.saldo = saldo;
	
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
		/// Recupera o <see cref="Jogador"/> atual da partida.
		/// </summary>
		/// <returns>Jogador Atual.</returns>
		public int getJogadorAtual ()
		{
				return this.JogadorAtual;
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
		/// Seta o saldo do <see cref="Jogador"/>.
		/// </summary>
		/// <param name="valor">int Valor.</param>
		public void setSaldo (int valor)
		{
				if(valor <= 0){
					this.saldo = 0;
				} else {
					this.saldo = valor;
				}
		}
}
