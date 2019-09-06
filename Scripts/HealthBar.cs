using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Sprite[] barra;
	public Image healthBarUI;

	private PlayerBehaviour player;

	void Start () {
		player = GameObject.Find("Player").GetComponent<PlayerBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		healthBarUI.sprite = barra[player.vidas];
	}
}
