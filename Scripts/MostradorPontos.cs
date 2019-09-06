using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostradorPontos : MonoBehaviour {

	private Text campoTexto;
	public Pontuacao pontos;
	[SerializeField] public int lixos = 0;

	void Start () {
		campoTexto = GetComponent<Text> ();
	}
	
	void Update () {
		if(lixos != 10){
			campoTexto.text = " SCORE:  " + pontos.GetPontos();
		}
	}
}
