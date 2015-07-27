using UnityEngine;
using System.Collections;

public class Wave0End : MonoBehaviour {
	public Door porta;
	public Animator intro;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextLevel() {
		this.porta.OpenDoor ();
		intro.SetTrigger ("Exit");
	}
}
