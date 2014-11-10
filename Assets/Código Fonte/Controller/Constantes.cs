using System;

/// <summary>
/// Classe Constantes, unifica todo código estático (enumerações, constantes) utilizadas pelo Banco Imobiliário.
/// </summary>
public class Constantes
{
	/// <summary>
	/// Lista de Jogadores disponíveis para instânciação.
	/// </summary>
	public enum Jogador{
		Vermelho			= 0,
		Azul				= 1,
		Nenhum				= -1,
	}

	/// <summary>
	/// Lista de Saldos disponíveis para instânciação.
	/// </summary>
	public enum Saldo{
		Inicial				= 500,
		VoltaTabuleiro		= 200,
	}

	/// <summary>
	/// Lista de Sortes disponíveis para instânciação.
	/// </summary>
	public enum Sorte{
		CreditaSaldo		= 200,
		DoaSaldo			= 200,
		AvancaLogradouro	= 3,
		RecuaLogradouro		= 3,
	}

	/// <summary>
	/// Lista Operações do logradouro de Sortes disponíveis para instânciação.
	/// </summary>
	public enum Operacoes{
		Avancar				= 1,
		Recuar				= 2,
		Creditar			= 3,
		Doar				= 4,
	}
}