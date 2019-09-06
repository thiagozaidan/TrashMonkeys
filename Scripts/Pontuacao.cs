using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pontuacao : MonoBehaviour {

	[SerializeField] public int pontos = 0;
	[SerializeField] public int lixos = 0;
	public Text scoreFinal;
	public GameObject panel;

	public int GetPontos(){
		return pontos;
	}

	public void GanhaPontos(){
			lixos++;
			pontos = pontos + 100;
	}

	public void PerdePontos()
	{
		lixos++;
		pontos = pontos - 25;
		
	}
	
	void Start () {
		panel.gameObject.SetActive(false);

	}
	
	void Update () {
		if(lixos == 10){
		panel.gameObject.SetActive(true);
			scoreFinal.text = "SCORE:" + pontos.ToString();		}
	}
}
