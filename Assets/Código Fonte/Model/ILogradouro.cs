/// <summary>
/// Interface entre o <see cref="Tabuleiro"/> e seus diferentes tipos genéricos de logradouros.
/// </summary>
public interface ILogradouro
{
		/// <summary>
		/// É executado quando o jogador para em um logradouro.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		bool acao (Jogador jogador);
		

		/// <summary>
		/// Retorna a posicao (índice) do logradouro em questão.
		/// </summary>
		/// <returns>Indice.</returns>
		int getPosicaoIndice ();
}
