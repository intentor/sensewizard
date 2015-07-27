using UnityEngine;
using System.Collections;
using TDC.TripeAGame.Behaviours;

public class Door : MonoBehaviour {
	private AudioSource som;
	public WaypointCameraMove cameraMove;
	public Vector3 target_position;
	public float speed = 0.01f;
	GameObjectShaker shaker;

	void Start()
	{
		shaker = Camera.main.gameObject.GetComponent<GameObjectShaker> ();
		som = this.GetComponent<AudioSource> ();

		if(target_position == Vector3.zero)
		{
			target_position = transform.position + new Vector3(0.0f, 5.0f, 0.0f);
		}
	}

	void OpenSesame()
	{
		transform.position = Vector3.MoveTowards (transform.position, target_position, speed);

		if(transform.position == target_position)
		{
			//Camera Shake Ends
			//
			cameraMove.startMotion();
			CancelInvoke("OpenSesame");
			Destroy(this.gameObject);
		}
	}

	public void OpenDoor()
	{
		//Camera Shake Starts
		//
		som.Play ();
		shaker.Shake ();
		InvokeRepeating ("OpenSesame", 0.02f, 0.02f);
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.B))
		{
			OpenDoor();
		}
	}
}
