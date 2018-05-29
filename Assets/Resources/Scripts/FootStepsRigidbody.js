#pragma strict

var concrete : AudioClip[];
private var step : boolean = true;
var audioStepLengthWalk : float = 0.45;
var audioStepLengthRun : float = 0.25;
var walkSpeed : float = 8.0;
var runSpeed : float = 12.0;
var controller : RigidController;

function OnCollisionStay (col : Collision) {
	
	if (controller.grounded && GetComponent.<Rigidbody>().velocity.magnitude > (walkSpeed-2) && GetComponent.<Rigidbody>().velocity.magnitude < (walkSpeed+2) && col.gameObject.tag == "Concrete" && step == true || controller.grounded && GetComponent.<Rigidbody>().velocity.magnitude < (walkSpeed+2) && GetComponent.<Rigidbody>().velocity.magnitude > (walkSpeed-2) && col.gameObject.tag == "Untagged" && step == true ) {
		WalkOnConcrete();
	}else if (controller.grounded && GetComponent.<Rigidbody>().velocity.magnitude > (runSpeed-2) && col.gameObject.tag == "Concrete" && step == true || controller.grounded && GetComponent.<Rigidbody>().velocity.magnitude > (runSpeed-2) && col.gameObject.tag == "Untagged" && step == true ) {
		RunOnConcrete();
	}
}	

function WalkOnConcrete() {
	step = false;
	GetComponent.<AudioSource>().clip = concrete[Random.Range(0, concrete.length)];
	GetComponent.<AudioSource>().volume = .1;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthWalk);
	step = true;
}

function RunOnConcrete() {
	step = false;
	GetComponent.<AudioSource>().clip = concrete[Random.Range(0, concrete.length)];
	GetComponent.<AudioSource>().volume = .3;
	GetComponent.<AudioSource>().Play();
	yield WaitForSeconds (audioStepLengthRun);
	step = true;
}

@script RequireComponent(AudioSource)