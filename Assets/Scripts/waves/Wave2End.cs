using UnityEngine;
using System.Collections;

public class Wave2End : MonoBehaviour {
	public static int deadEnemies = 0;
	public int enemies = 2;
	public Door porta;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnDestroy() {
		deadEnemies ++;
		if (deadEnemies >= this.enemies) {
			porta.OpenDoor();
		}
	}
}
