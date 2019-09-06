using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Residuos : MonoBehaviour {

	Vector3 posInicial;
	Vector3 posDestino;
	Vector3 vetDirecao;
	
	Rigidbody2D _rigidbody2D;

	[Space(10)] public Transform conector;

	[HideInInspector] public bool estaConectado;
	bool estaArrastando;

	public float velocidadeMov = 10f;
	public float distanciaMinConec = 0.5f;
	float distancia;

	void Start () {
		_rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
		_rigidbody2D.gravityScale = 1;
	}
	
	void Update () {
		
	}

	void OnMouseDown(){
		posInicial = transform.root.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
		_rigidbody2D.gravityScale = 0;
		estaArrastando = true;
		estaConectado = false;
	}

	void OnMouseDrag(){
		posDestino = posInicial + Camera.main.ScreenToWorldPoint(Input.mousePosition);
		vetDirecao = posDestino - transform.root.position;
		_rigidbody2D.velocity = vetDirecao * velocidadeMov;
	}

	void OnMouseUp(){
		_rigidbody2D.gravityScale = 1;
		estaArrastando = false;
		
	}
}
