using UnityEngine;

/// <summary>
/// Bootstrap para inicialização e execução do Jogo Completo.
/// </summary>
public class Bootstrap : MonoBehaviour
{
		/// <summary>
		/// Exibe o saldo do Jogador vermelho na Gui.
		/// </summary>
		public TextMesh saldoJogadorVermelho;

		/// <summary>
		/// Exibe o saldo do Jogador azul na Gui.
		/// </summary>
		public TextMesh saldoJogadorAzul;

		/// <summary>
		/// Exibir o feedback de mensagens da Gui.
		/// </summary>
		public TextMesh mensagemDeJogada;

		/// <summary>
		/// Objeto Dado no Unity.
		/// </summary>
		public GameObject dadoGameObject;
		
		/// <summary>
		/// É utilizado para lincar a instância do GameObject do Unity.
		/// </summary>
		public GameObject tabuleiroGameObjectGUI;

		/// <summary>
		/// É utilizado para lincar o script da instância do GameObject do Unity.
		/// </summary>
		TabuleiroGUI tabuleiroGUI;

		/// <summary>
		/// É utilizado para lincar o script da instância do GameObject do Dado no Unity.
		/// </summary>
		DadoGUI dado;

		/// <summary>
		/// Instâncias das casas no Tabuleiro.
		/// </summary>
		Tabuleiro tabuleiro = new Tabuleiro ();

		/// <summary>
		/// Prepara da instanciação dos jogadores.
		/// </summary>
		JogadorDaVez jogadorDaVez = new JogadorDaVez ();

		/// <summary>
		/// O jogador atual.
		/// </summary>
		Jogador jogadorAtual;

		/// <summary>
		/// Armazena o jogador que não é o ativa na partida atual.
		/// </summary>
		Jogador outroJogador;

		/// <summary>
		/// Armazena a casa atual genérica do tabuleiro.
		/// </summary>
		ILogradouro casaAtual;

		/// <summary>
		/// Exibe a janela com opções de compra na Gui.
		/// </summary>
		private bool mostrarTelaDeCompra = false;


		/// <summary>
		/// Método do Unity usado para inicialização.
		/// </summary>
		public void Start ()
		{

				this.jogadorAtual 				= jogadorDaVez.getJogadorDaVez ();
				this.outroJogador 				= jogadorDaVez.getOutroJogador ();

				this.saldoJogadorVermelho.text	= "" + jogadorAtual.getSaldo ();
				this.saldoJogadorAzul.text		= "" + jogadorAtual.getSaldo ();

				this.tabuleiroGUI 				= tabuleiroGameObjectGUI.GetComponent<TabuleiroGUI> ();
				this.dado 						= dadoGameObject.GetComponent<DadoGUI> ();
				TextVezDoJogadorAtual ();
		}
		

		/// <summary>
		/// Chama a cena de gameover no Unity.
		/// </summary>
		private void Ganhou ()
		{
				if (jogadorAtual.getSaldo () <= 0) {
						if (jogadorAtual.getIdJogador () == 1) {
								Application.LoadLevel ("VermelhoWin");
						} else
								Application.LoadLevel ("AzulWin");
				}
		}


		/// <summary>
		/// Indica na Gui vez do jogador atual.
		/// </summary>
		private void TextVezDoJogadorAtual ()
		{
				if (jogadorAtual.getIdJogador () == (int)Constantes.Jogador.Vermelho) {
						mensagemDeJogada.text = "Jogador Vermelho";
						GameObject.FindGameObjectWithTag ("setaIdentificaJogador").SendMessage ("mudarVezParaVermelho");
				} else {
						mensagemDeJogada.text = "Jogador Azul";
						GameObject.FindGameObjectWithTag ("setaIdentificaJogador").SendMessage ("mudarVezParaAzul");
				}
		}

		
		/// <summary>
		/// Método do Unity, é executado a cada frame.
		/// </summary>
		public void Update ()
		{
				atualizarSaldo ();

				if (this.mostrarTelaDeCompra) {
						TelaDeCompra ();
				}

				if (this.dado.JogadorJogouDados () && !this.mostrarTelaDeCompra) {
						maquinaDeEstados ();
						this.dado.MudarPlayer ();
				}

		}
		

		/// <summary>
		/// Método que modifica a posição do <see cref="Jogador"/>.
		/// Chama os métodos que realizam ações no <see cref="Jogador"/>.
		/// Seta a visibilidade da <see cref="TelaDeCompra"/>.
		/// </summary>
		public void maquinaDeEstados ()
		{
				this.tabuleiro.percorrerTabuleiro (this.jogadorAtual, this.dado.somaValorDados ());

				this.tabuleiroGUI.percorerTabuleiro (this.jogadorAtual.getIdJogador (), this.jogadorAtual.getPosicao ());
				this.casaAtual = this.tabuleiro.getCasaDaVez ();
				this.mostrarTelaDeCompra = this.casaAtual.acao (this.jogadorAtual, this.outroJogador);
				this.tabuleiroGUI.percorerTabuleiro (this.jogadorAtual.getIdJogador (), this.jogadorAtual.getPosicao ());
				
				if (!this.mostrarTelaDeCompra)
						alternaJogador ();
		}


		/// <summary>
		/// Exibe a janela da tela de compras na Gui.
		/// </summary>
		public void TelaDeCompra ()
		{
				dado.EsconderDados ();

				if (casaAtual.GetType () == typeof(Imovel)) {
						Imovel imovel = (Imovel)casaAtual;
						this.mensagemDeJogada.text = "Valor R$" + imovel.getPreco () + " - Deseja comprar?";

				} else
			if (casaAtual.GetType () == typeof(Empresa)) {
						Empresa empresa = (Empresa)casaAtual;
						this.mensagemDeJogada.text = "Valor R$ " + empresa.getPreco () + " - Deseja comprar?";
				}
		}

		
		/// <summary>
		/// Prepara o ambiente para a próxima jogada.
		/// </summary>
		/// <remarks>
		/// Verifica se é o Fim do jogo atual.
		/// </remarks>
		public void alternaJogador ()
		{
				atualizarSaldo ();
				Ganhou ();

				if (!mostrarTelaDeCompra) {
						this.jogadorDaVez.proximoJogador ();
						this.jogadorAtual = this.jogadorDaVez.getJogadorDaVez ();
						this.outroJogador = this.jogadorDaVez.getOutroJogador ();

						atualizarSaldo ();

						TextVezDoJogadorAtual ();
						this.dado.MudarPlayer ();
				}
		}

		
		/// <summary>
		/// Método que recebe a desisão do jogador pel <see cref="OnGui"/> e executa a ação de comprar.
		/// </summary>
		/// <param name="decisao">Caso seja <c>true</c> decisao é comprar.</param>
		public void comprarImovel (bool decisao)
		{
				if (this.casaAtual.GetType () == typeof(Imovel)) {
						Imovel imovel = (Imovel)casaAtual;
						imovel.comprar (this.jogadorAtual, decisao);
				} else
						if (this.casaAtual.GetType () == typeof(Empresa)) {
								Empresa empresa = (Empresa)casaAtual;
								empresa.comprar (this.jogadorAtual, decisao);
						}
		}


		/// <summary>
		/// Atualiza na Gui o saldo de ambos os jogadores.
		/// </summary>
		private void atualizarSaldo ()
		{
				if (jogadorAtual.getIdJogador () == 0) {
						this.saldoJogadorVermelho.text = "" + this.jogadorAtual.getSaldo ();
				} else if (jogadorAtual.getIdJogador () == 1) {
						this.saldoJogadorAzul.text = "" + this.jogadorAtual.getSaldo ();
				}
		}

		
		/// <summary>
		/// Método default do Unity.
		/// Exibe as opções (Sim, Não) na interface gráfica.
		/// </summary>
		public void OnGUI ()
		{
				if (this.mostrarTelaDeCompra) {
						if (GUI.Button (new Rect (498, 469, 80, 30), "Sim")) {
								this.mostrarTelaDeCompra = false;
								comprarImovel (true);

								this.tabuleiroGUI.comprarLogradouro (this.jogadorAtual.getIdJogador (), this.jogadorAtual.getPosicao ());

								alternaJogador ();
						}

						if (GUI.Button (new Rect (700, 469, 80, 30), "Nao")) {
								this.mostrarTelaDeCompra = false;
								comprarImovel (false);
								alternaJogador ();
						}
				}
		}
}