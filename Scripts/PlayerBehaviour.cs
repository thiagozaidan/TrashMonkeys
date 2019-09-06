using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour {

	private Rigidbody2D rb;
	private Transform tr;
	private Animator an;
	public Transform verificaChao;
	public Transform verificaParede;

	private bool estaAndando;
	private bool estaNoChao;
	private bool estaNaParede;
	private bool estaVivo;
	private bool viradoParaDireita;

	private float axis;
	public float velocidade;
	public float forcaPulo;
	public float raioValidaChao;
	public float raioValidaParede;

	public LayerMask solido;

	public AudioSource peguei;
	public AudioSource pegueierrado;
	public AudioSource die;

	public int lixos;
	public int vidas = 3;
	private GameObject player;
 

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		tr = GetComponent<Transform> ();
		an = GetComponent<Animator> ();

		estaVivo = true;
		viradoParaDireita = true;
	}

	void Update () {
		
		estaNoChao = Physics2D.OverlapCircle(verificaChao.position, raioValidaChao, solido);
		estaNaParede = Physics2D.OverlapCircle(verificaParede.position, raioValidaParede, solido);

		if(estaVivo){

			Animations();

			axis = Input.GetAxisRaw("Horizontal");

			estaAndando = Mathf.Abs (axis) > 0f;

			if (axis > 0f && !viradoParaDireita)
				Flip ();
			else if(axis < 0f && viradoParaDireita)
				Flip ();

			if (Input.GetButtonDown ("Jump") && estaNoChao)
				rb.AddForce(tr.up * forcaPulo);

			if (Input.GetButtonDown ("Space") && estaNoChao)
				rb.AddForce(tr.up * 1.5f * forcaPulo);
			Morre();
		}

	}

	void FixedUpdate() {
		if(estaAndando && !estaNaParede){
			if(viradoParaDireita)
				rb.velocity = new Vector2 (velocidade, rb.velocity.y);
			else
				rb.velocity = new Vector2 (-velocidade, rb.velocity.y);
		}
	}

	void Flip() {
		viradoParaDireita = !viradoParaDireita;

		tr.localScale = new Vector2(-tr.localScale.x, tr.localScale.y);
	}

	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;

		Gizmos.DrawWireSphere(verificaChao.position, raioValidaChao);
		Gizmos.DrawWireSphere(verificaParede.position, raioValidaParede);
	}

	void Animations(){

		an.SetBool("Andando", (estaNoChao && estaAndando));
		an.SetBool("Pulando", (!estaNoChao));
		an.SetFloat("VelVertical", (rb.velocity.y));

	}

	private void OnTriggerEnter2D(Collider2D collision2D){
		if(collision2D.gameObject.CompareTag("Lixos")){
			Destroy(collision2D.gameObject);
			peguei.Play();
			lixos++;
		}
		if(collision2D.gameObject.CompareTag("Fim") && lixos >= 10){
			SceneManager.LoadScene(5);
		}


		if(collision2D.gameObject.CompareTag("LixosErrados")){
			Destroy(collision2D.gameObject);
			pegueierrado.Play();
			vidas--;
		}
	}

	private void Awake(){
    	player = GameObject.Find("Player");
 	}

	private void Morre(){
		if(vidas <= 0 || player.transform.position.y <= -5){
			gameObject.GetComponent<Animator>().Play("Die");
			SceneManager.LoadScene(1);
		}
	}

}
