using UnityEngine;

public class MenuGanhou : MonoBehaviour
{
		// Use this for initialization
		void Start ()
		{
	
		}


		// Update is called once per frame
		void Update ()
		{
	
		}


		/// <summary>
		/// Método do Unity.
		/// Define as opções de Finalização do Jogo.
		/// </summary>
		void OnGUI ()
		{
				if (GUI.Button (new Rect (490, 500, 125, 30), "Nova Partida")) {
						Application.LoadLevel ("Principal");
				}

				if (GUI.Button (new Rect (660, 500, 125, 30), "Sair")) {
						Application.Quit ();
				}
		}
}
