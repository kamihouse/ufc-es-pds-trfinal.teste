/// <summary>
/// Interface entre o <see cref="Tabuleiro"/> e seus diferentes tipos genéricos de logradouros.
/// </summary>
public interface ILogradouro
{
		/// <summary>
		/// É executado quando o jogador entra em um logradouro.
		/// </summary>
		/// <param name="jogador">Jogador.</param>
		/// <param name="outroJogador">Outro jogador.</param>
		bool acao (Jogador jogador, Jogador outroJogador);
}
