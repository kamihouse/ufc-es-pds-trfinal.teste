using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Constrolador que gerencia o Tabuleiro e suas ações no Banco Imobiliário.
/// </summary>
public class Tabuleiro
{
		/// <summary>
		/// Uma coleção de logradouro genéricos do tabuleiro.
		/// </summary>
		private List<ILogradouro> listaLogradourosTabuleiro = new List<ILogradouro> ();

		/// <summary>
		/// Armazena genericamente a casa da vez.
		/// </summary>
		ILogradouro casaDaVez;


		/// <summary>
		/// Inicializa uma nova instância da classe <see cref="Tabuleiro"/>.
		/// </summary>
		public Tabuleiro ()
		{
				GerarTabuleiro ();
		}


		/// <summary>
		/// Factory para criação do <see cref="Tabuleiro"/>.
		/// </summary>
		public void GerarTabuleiro ()
		{
				criarLogradouros ();
		}


		/// <summary>
		/// Método que prepara a instanciação customizada das casas presentes no Tabuleiro.
		/// E adiciona à coleção <see cref="listaLogradourosTabuleiro"/>
		/// </summary>
		/// <remarks>
		/// Casas iniciam-se com valores entre [0-35]
		/// </remarks>
		private void criarLogradouros ()
		{
				// Instanciando Imóveis
				Imovel casa0	= new Imovel (0, 400);
				Imovel casa1	= new Imovel (1, 100);
				Imovel casa2	= new Imovel (2, 350);
				Sorte casa3		= new Sorte (3, 4);
				Empresa casa4	= new Empresa (4, 150);
				Imovel casa5	= new Imovel (5, 180);
				Imovel casa6	= new Imovel (6, 200);
				Imovel casa7	= new Imovel (7, 180);
				Empresa casa8	= new Empresa (8, 100);
				Imovel casa9	= new Imovel (9, 220);
				Sorte casa10	= new Sorte (10, 2);
				Imovel casa11	= new Imovel (11, 220);
				Empresa casa12	= new Empresa (12, 200);
				Imovel casa13	= new Imovel (13, 240);
				Imovel casa14	= new Imovel (14, 60);
				Imovel casa15	= new Imovel (15, 60);
				Sorte casa16 	= new Sorte (16, 3);
				Imovel casa17 	= new Imovel (17, 100);
				Imovel casa18 	= new Imovel (18, 260);
				Imovel casa19 	= new Imovel (19, 280);
				Sorte casa20 	= new Sorte (20, 4);
				Imovel casa21 	= new Imovel (21, 300);
				Empresa casa22 	= new Empresa (22, 200);
				Imovel casa23 	= new Imovel (23, 300);
				Imovel casa24 	= new Imovel (24, 320);
				Empresa casa25 	= new Empresa (25, 200);
				Imovel casa26 	= new Imovel (26, 260);
				Imovel casa27 	= new Imovel (27, 140);
				Imovel casa28 	= new Imovel (28, 140);
				Imovel casa29 	= new Imovel (29, 160);
				Imovel casa30 	= new Imovel (30, 100);
				Empresa casa31 	= new Empresa (31, 50);
				Imovel casa32 	= new Imovel (32, 120);
				Sorte casa33 	= new Sorte (33, 1);
				Empresa casa34 	= new Empresa (34, 150);
				Sorte casa35 	= new Sorte (35, 3);

				// Adicionando à coleção
				listaLogradourosTabuleiro.Add (casa0);
				listaLogradourosTabuleiro.Add (casa1);
				listaLogradourosTabuleiro.Add (casa2);
				listaLogradourosTabuleiro.Add (casa3);
				listaLogradourosTabuleiro.Add (casa4);
				listaLogradourosTabuleiro.Add (casa5);
				listaLogradourosTabuleiro.Add (casa6);
				listaLogradourosTabuleiro.Add (casa7);
				listaLogradourosTabuleiro.Add (casa8);
				listaLogradourosTabuleiro.Add (casa9);
				listaLogradourosTabuleiro.Add (casa10);
				listaLogradourosTabuleiro.Add (casa11);
				listaLogradourosTabuleiro.Add (casa12);
				listaLogradourosTabuleiro.Add (casa13);
				listaLogradourosTabuleiro.Add (casa14);
				listaLogradourosTabuleiro.Add (casa15);
				listaLogradourosTabuleiro.Add (casa16);
				listaLogradourosTabuleiro.Add (casa17);
				listaLogradourosTabuleiro.Add (casa18);
				listaLogradourosTabuleiro.Add (casa19);
				listaLogradourosTabuleiro.Add (casa20);
				listaLogradourosTabuleiro.Add (casa21);
				listaLogradourosTabuleiro.Add (casa22);
				listaLogradourosTabuleiro.Add (casa23);
				listaLogradourosTabuleiro.Add (casa24);
				listaLogradourosTabuleiro.Add (casa25);
				listaLogradourosTabuleiro.Add (casa26);
				listaLogradourosTabuleiro.Add (casa27);
				listaLogradourosTabuleiro.Add (casa28);
				listaLogradourosTabuleiro.Add (casa29);
				listaLogradourosTabuleiro.Add (casa30);
				listaLogradourosTabuleiro.Add (casa31);
				listaLogradourosTabuleiro.Add (casa32);
				listaLogradourosTabuleiro.Add (casa33);
				listaLogradourosTabuleiro.Add (casa34);
				listaLogradourosTabuleiro.Add (casa35);
		}


		/// <summary>
		/// Método que percorre por entre as casas disponíveis no tabuleiro.
		/// </summary>
		/// <remarks>
		/// Neste método acontece o percurso circular do tabuleiro, e adiciona o saldo estabelecido nas constantes para cada volta que o jogador passar pela cada de Início.
		/// </remarks>
		/// <param name="jogadorDaVez">Objeto Jogador.</param>
		/// <param name="valorDados">Valor da soma dos dados.</param>
		public void percorrerTabuleiro (Jogador jogadorDaVez, int valorDados)
		{
				int totalCasasTabuleiro = this.listaLogradourosTabuleiro.Count;

				if ((jogadorDaVez.getPosicao() + valorDados) > (totalCasasTabuleiro - 1)) {
						jogadorDaVez.setPosicao(jogadorDaVez.getPosicao() + valorDados - totalCasasTabuleiro);
						jogadorDaVez.setSaldo(jogadorDaVez.getSaldo() + (int)Constantes.Saldo.VoltaTabuleiro);
				} else {
						jogadorDaVez.setPosicao(jogadorDaVez.getPosicao() + valorDados);
				}

				this.setCasaDaVez (this.listaLogradourosTabuleiro [jogadorDaVez.getPosicao ()]);
		}
		

		/// <summary>
		/// Método que Determina uma Ação de Parada Abstrata.
		/// Sendo executada por cada Casa do Tabuleiro (Cada casa possui sua implementação de Ação).
		/// </summary>
		/// <param name="jogadorDaVez">Objeto Jogador da vez.</param>
		public void AcaoDeParada (Jogador jogadorDaVez)
		{
				this.listaLogradourosTabuleiro [jogadorDaVez.getPosicao()].acao (jogadorDaVez);
	
		}


		/// <summary>
		/// Método que Seta o objeto no atributo casaDaVez.
		/// </summary>
		/// <param name="casaDaVez">Casa da vez.</param>
		public void setCasaDaVez (ILogradouro casaDaVez)
		{
				this.casaDaVez = casaDaVez;
		}


		/// <summary>
		/// Retorna um objeto com a Casa da Vez.
		/// </summary>
		/// <returns>Objeto Casa da vez</returns>
		public ILogradouro getCasaDaVez ()
		{
				return this.casaDaVez;
		}
}
