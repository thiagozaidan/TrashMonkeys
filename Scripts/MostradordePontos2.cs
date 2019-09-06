using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradordePontos2 : MonoBehaviour {

	private Text campoTexto;
	public Pontuacao pontos;

	void Start () {
		campoTexto = GetComponent<Text> ();
	}
	
	void Update () {
		campoTexto.text = " SCORE:  " + pontos.GetPontos();
	}
}

