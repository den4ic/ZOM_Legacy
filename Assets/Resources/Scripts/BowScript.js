#pragma strict 

	var arrowPrefab : GameObject;
	var reloadTime = 0.5;
	var arrowCount = 20;
	private var lastShot = -10.0;
	var launchPosition : GameObject;
	var anim : Animation;
	var aSource : AudioSource;
	var soundFire : AudioClip;
	var pickUp : AudioClip;
	var arrowGO : GameObject;
	var layerM : LayerMask;
	var mainCamera : Camera;
	var zoomSpeed : float;
	var FOV : float = 30;
	var ammoUI : UnityEngine.UI.Text;
	
	function Start(){
		ammoUI.text = arrowCount.ToString();
	}

	function Update () {

		if(Input.GetMouseButton(1)){
			mainCamera.fieldOfView -= FOV * Time.deltaTime/zoomSpeed;
			if(mainCamera.fieldOfView < FOV){
				mainCamera.fieldOfView = FOV;
			}
		}else{
			mainCamera.fieldOfView += 60 * Time.deltaTime/0.5;
			if(mainCamera.fieldOfView > 60){
				mainCamera.fieldOfView = 60;
			}
		}	

		var fwd = transform.TransformDirection (Vector3.forward);
		if (!Physics.Raycast (transform.position, fwd, 1, layerM)) {
			if (Input.GetButtonDown("Fire1")){
				if (Time.time > reloadTime + lastShot && arrowCount > 0){	
					Fire();
				}	
			}	
		}	
	}

	function Fire () {
		
		Instantiate (arrowPrefab, launchPosition.transform.position, launchPosition.transform.rotation);
		anim["Shot"].speed = 5;
		anim.Rewind("Shot");
		anim.Play("Shot");
		
		aSource.PlayOneShot(soundFire, 0.1);

		lastShot = Time.time;
		arrowCount--;
		ammoUI.text = arrowCount.ToString();
	}

	function PickUpArrow (){
		arrowCount ++;
		ammoUI.text = arrowCount.ToString();
		aSource.PlayOneShot(pickUp, 0.5);
	}
