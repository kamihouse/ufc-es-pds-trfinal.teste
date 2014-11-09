using UnityEngine;
using System.Collections;

public class ControladorJogo : MonoBehaviour
{

		public TextMesh saldoJogadorVermelho;
		public TextMesh saldoJogadorAzul;
		public TextMesh indicadorDeVez;
		public GameObject dadoGameObject;
		public GameObject tabuleiroGameObjectGUI;
		TabuleiroGUI tabuleiroGUI;
		DadoGUI dado;
		Tabuleiro tabuleiro = new Tabuleiro ();
		JogadorDaVez jogador_da_vez = new JogadorDaVez ();
		Jogador jogadorAtual;
		ILogradouro casaAtual;
		//bool JogoGameOver = false;
		bool mostrarTelaDeCompra = false;
		// Use this for initialization
		void Start ()
		{

				jogadorAtual = jogador_da_vez.getJogadorDaVez ();

				saldoJogadorVermelho.text = "" + jogadorAtual.getSaldo ();
				saldoJogadorAzul.text = "" + jogadorAtual.getSaldo ();

				tabuleiroGUI = tabuleiroGameObjectGUI.GetComponent<TabuleiroGUI> ();
				dado = dadoGameObject.GetComponent<DadoGUI> ();
				TextVezDoJogadorAtual ();



		}

		void TextVezDoJogadorAtual ()
		{
				if (jogadorAtual.getJogadorAtual () == 0) 
						indicadorDeVez.text = "E a vez do vermelho";
				else
						indicadorDeVez.text = "E a Vez do Azul";
		}

		void Update ()
		{
				atualizarSaldo ();
				//Debug.Log (mostrarTelaDeCompra);
				if (mostrarTelaDeCompra) {
						TelaDeCompra ();
				}

				if (dado.JogadorJogouDados () && !mostrarTelaDeCompra) {

						testeMaquinaDeEstados ();
						dado.MudarPlayer ();
				}

		}
		
		public void testeMaquinaDeEstados ()
		{

				
				tabuleiro.percorrerTabuleiro (jogadorAtual, dado.somaValorDados ());

				tabuleiroGUI.percorerTabuleiro (jogadorAtual.getJogadorAtual (), jogadorAtual.getPosicao ());
				casaAtual = tabuleiro.getCasaDaVez ();
				mostrarTelaDeCompra = casaAtual.acao (jogadorAtual);
				tabuleiroGUI.percorerTabuleiro (jogadorAtual.getJogadorAtual (), jogadorAtual.getPosicao ());

				if (!mostrarTelaDeCompra)
						alternaJogador ();

	
		}

		public void TelaDeCompra ()
		{
				dado.EsconderDados ();

				if (casaAtual.GetType () == typeof(Imovel)) {
						Imovel imovel = (Imovel)casaAtual;
						indicadorDeVez.text = "Deseja comprar por " + imovel.getPreco () + "? S/N";

				} else
			if (casaAtual.GetType () == typeof(Empresa)) {
						Empresa empresa = (Empresa)casaAtual;
						indicadorDeVez.text = "Deseja comprar por " + empresa.getPreco () + "? S/N";
				}
		}

		public void alternaJogador ()
		{
				atualizarSaldo ();
				if (!mostrarTelaDeCompra) {
						jogador_da_vez.proximoJogador ();
						jogadorAtual = jogador_da_vez.getJogadorDaVez ();

						atualizarSaldo ();

						TextVezDoJogadorAtual ();
						dado.MudarPlayer ();
				}
		}

		public void comprarImovel (bool decisao)
		{
				
				if (casaAtual.GetType () == typeof(Imovel)) {
						Imovel imovel = (Imovel)casaAtual;
						imovel.comprar (jogadorAtual, decisao);
				} else
		if (casaAtual.GetType () == typeof(Empresa)) {
						Empresa empresa = (Empresa)casaAtual;
						empresa.comprar (jogadorAtual, decisao);
				}
				
		}

		void atualizarSaldo ()
		{
				if (jogadorAtual.getJogadorAtual () == 0) {
						saldoJogadorVermelho.text = "" + jogadorAtual.getSaldo ();
				} else if (jogadorAtual.getJogadorAtual () == 1) {
						saldoJogadorAzul.text = "" + jogadorAtual.getSaldo ();
				}
		}

		void OnGUI ()
		{
				if (mostrarTelaDeCompra) {

						if (GUI.Button (new Rect (888, 323, 80, 30), "sim")) {
								mostrarTelaDeCompra = false;
								comprarImovel (true);

								tabuleiroGUI.comprarLogradouro (jogadorAtual.getJogadorAtual (), jogadorAtual.getPosicao ());

								alternaJogador ();
						}
						if (GUI.Button (new Rect (700, 323, 80, 30), "nao")) {
								mostrarTelaDeCompra = false;
								comprarImovel (false);
								alternaJogador ();
						}
				}
		}
}