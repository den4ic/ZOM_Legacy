#pragma strict 

var activated : boolean = false;
function OnTriggerStay (other : Collider) {
	
	if(activated){
		if(other.name == "Player" && Input.GetKey(KeyCode.E)){
			other.gameObject.BroadcastMessage ("PickUpArrow");
			Destroy(transform.root.gameObject);
		}
	}
}
	