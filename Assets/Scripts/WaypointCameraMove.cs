using UnityEngine;
using System.Collections;

[RequireComponent(typeof(iTweenPath))]
public class WaypointCameraMove : MonoBehaviour {
	public TrackingAction cameraReference;
    public GameObject targetToMove;
    public string iTweenPathName;
    public GameObject scriptToEnable;
    public float easeTime = 100f;
	public float lookTime = 0.3f;

    private bool isMoving = false;
    private iTween.EaseType easyType = iTween.EaseType.linear;

    void Update() {
        //if (Input.GetButtonDown("Fire1")) {
            //this.startMotion();
        //}
    }

    public void startMotion() {
        if (!this.isMoving) {
			//this.cameraReference.enabled = true;
            this.isMoving = true;
            iTween.MoveTo(targetToMove, iTween.Hash("path", iTweenPath.GetPath(iTweenPathName), 
			                                        "time", easeTime, 
			                                        "orienttopath", true, 
			                                        "looktime", lookTime, 
			                                        "oncomplete", "stopMotion",
			                                        "oncompletetarget",this.gameObject,
			                                        "easeType", easyType));
        }
    }

    public void stopMotion() {
		Debug.Log ("Animation End!");
		this.isMoving = false;
		//this.cameraReference.enabled = false;
		//iTween.RotateTo (this.cameraReference, new Vector3 (0f, 0f, 0f), 1);
		if (this.scriptToEnable != null)
			this.scriptToEnable.SetActive(true);
		this.gameObject.SetActive (false);
	}
}
