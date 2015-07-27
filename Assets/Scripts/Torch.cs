using UnityEngine;
using System.Collections;

public class Torch : MonoBehaviour {

	public GameObject myTocha;
	public string projectile_tag = "fogo";

	void OnCollisionEnter(Collision collision) 
	{
		AcendeTocha();	
	}

	void OnTriggerEnter (Collider collision)
	{
		if (collision.gameObject.tag == projectile_tag) 
		{
			//AcendeTocha();
		}

		Debug.Log("Tocha Colidiu");

		AcendeTocha();
	}

	void AcendeTocha()
	{
		myTocha.SetActive(true);
		Destroy (this.gameObject);
	}
}
