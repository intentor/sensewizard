using UnityEngine;
using System.Collections;

namespace TDC.TripeAGame.Behaviours {
	/// <summary>
	/// Modify a GameObject so it can be shaken.
	/// </summary> 
	public class GameObjectShaker : MonoBehaviour {
		/// <summary>Indicates if the object will shake on start.</summary>
		public bool shakeOnStart = false;
		/// <summary>Initial intensity of the shaking — how much variance to allow in the camera position.</summary>
		public float shakeIntensity = 0.3f;
		/// <summary>Amount that shakeIntensity is decremented each update. It determines if the shake is long or short.</summary>
		public float shakeDecay = 0.002f;
		/// <summary>Indicates if the shaking should be done using rotation and movement.</summary>
		public bool rotateAndMove = true;
		
		/// <summary>GameObject's Transform compoonent reference.</summary>
		protected Transform _transform;
		/// <summary>The GameObject's original position.</summary>
		protected Vector3 _originPosition;
		/// <summary>The GameObject's original rotation.</summary>
		protected Quaternion _originRotation;
		/// <summary>Shake decay temp variable.</summary>
		protected float _shakeDecay;
		/// <summary>Shake intensity temp variable.</summary>
		protected float _shakeIntensity;
		
		protected void Start() {
			_transform = this.GetComponent<Transform>();
			
			if (this.shakeOnStart) this.Shake();
		}
		
		protected void Update(){
			if (_shakeIntensity > 0){
				if (this.rotateAndMove) _transform.position = _originPosition + Random.insideUnitSphere * _shakeIntensity;
				_transform.rotation =  new Quaternion(
					_originRotation.x + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
					_originRotation.y + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
					_originRotation.z + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f,
					_originRotation.w + Random.Range(-_shakeIntensity, _shakeIntensity) * 0.2f);
				_shakeIntensity -= _shakeDecay;
			}
		}
		
		/// <summary>
		/// Shakes the camera.
		/// </summary>
		public void Shake(){
			_originPosition = _transform.position;
			_originRotation = _transform.rotation;
			_shakeIntensity = this.shakeIntensity;
			_shakeDecay = this.shakeDecay;
		}
	}
}