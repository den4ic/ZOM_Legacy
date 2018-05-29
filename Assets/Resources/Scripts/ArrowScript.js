#pragma strict
 
var layerMask : LayerMask; 
var soundHit : AudioClip;
var trigger : Trigger;

private var velocity : Vector3 = Vector3.zero; 	
private var newPos : Vector3 = Vector3.zero;   
private var oldPos : Vector3 = Vector3.zero;   	
var hasHit : boolean = false;          	
private var direction : Vector3;               
private var hit : RaycastHit;
var speed : float;
var arrowRotation : Transform;
var forceToApply : float;
var arrowGravity : float;
private var follow : GameObject;
var projectileSpread : float = 0.1;
var meleeDamage : float = 10.0;  

function Start() { 
	newPos = transform.position;   
    oldPos = newPos;              
    velocity = speed * transform.forward;	
	direction = transform.TransformDirection(Vector3(Random.Range(-projectileSpread, projectileSpread), Random.Range(-projectileSpread, projectileSpread), 1));
}

function Update () {

    newPos += (velocity + direction) * Time.deltaTime;

	var dir : Vector3 = newPos - oldPos;
	var dist : float = dir.magnitude;
	
	if (dist > 0){
		
		if(Physics.Raycast(oldPos, dir, hit, dist, layerMask)){
			newPos = hit.point;
		
			if(hit.collider){
				trigger.activated = true;
				GetComponent.<AudioSource>().PlayOneShot(soundHit, 0.3);
				
				if(hit.rigidbody){
					var hitPoint : GameObject = Instantiate (new GameObject(), hit.point, transform.root.rotation);
					hitPoint.transform.parent = hit.transform;
					follow = hitPoint;	
					hit.rigidbody.AddForceAtPosition(forceToApply * dir, hit.point);
					hasHit = true; // если на false то физика увеличивает потенциал массы в разы
				}else{	
					GetComponent.<Collider>().isTrigger = false;
					enabled = false;
				}
			}
			
			hit.collider.SendMessageUpwards("ApplyDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);

		}	
	}


	oldPos = transform.position;  
	transform.position = newPos;
	velocity.y -= arrowGravity * Time.deltaTime;
	arrowRotation.transform.rotation = Quaternion.LookRotation(dir); 
}	


