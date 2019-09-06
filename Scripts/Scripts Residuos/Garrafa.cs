using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Garrafa : MonoBehaviour {

	[SerializeField] private Pontuacao pontos;
	[SerializeField] private Pontuacao controle;

	Vector3 posInicial;
	Vector3 posDestino;
	Vector3 vetDirecao;
	
	Rigidbody2D _rigidbody2D;

	[Space(10)] public Transform conector;

	[HideInInspector] public bool estaConectado;
	bool estaArrastando;

	public float velocidadeMov = 2f;
	public float distanciaMinConec = 0.5f;
	float distancia;

	public Vector3 scanPos;
	public Vector3 screenPoint;
	public Vector3 offset;

	void Start () {
	    _rigidbody2D = transform.root.GetComponent<Rigidbody2D>();
		_rigidbody2D.gravityScale = 1;
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

	void OnTriggerEnter2D(Collider2D collision2D){
		if(collision2D.gameObject.CompareTag("Vidro")){
			Destroy(this.gameObject);
			Debug.Log("Oi");
			pontos.GanhaPontos();
			 

		}

			if(collision2D.gameObject.CompareTag("Papel")){
			Destroy(this.gameObject);
			Debug.Log("Oi");
			pontos.PerdePontos();
			 
		}

		if(collision2D.gameObject.CompareTag("Organico")){
			Destroy(this.gameObject);
			Debug.Log("Oi");
			pontos.PerdePontos();
			 
		}

		if(collision2D.gameObject.CompareTag("Plastico")){
			Destroy(this.gameObject);
			Debug.Log("Oi");
			pontos.PerdePontos();
			 
		}

		if(collision2D.gameObject.CompareTag("Metal")){
			Destroy(this.gameObject);
			Debug.Log("Oi");
			pontos.PerdePontos();
			 
		}
	}  
}