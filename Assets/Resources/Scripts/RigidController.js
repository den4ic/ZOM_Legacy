#pragma strict

var crouchSpeed = 2.0;
var walkSpeed = 8.0;
var runSpeed = 20.0;

var fallDamageMultiplier : int = 2;
var inAirControl = 0.1;
var gravity = 20.0;
var maxVelocityChange = 10.0;
var canJump = true;
var jumpHeight = 2.0;

var grounded = false;
private var sliding : boolean = false;
private var speed = 10.0;
private var limitDiagonalSpeed = true;
private var crouching : boolean;
private var normalHeight : float = 0.5;
private var crouchHeight : float = -0.2;
private var crouchingHeight = 0.3;
private var hit : RaycastHit;
private var myTransform : Transform;
private var rayDistance : float;
private var mainCameraGO : GameObject;
private var weaponCameraGO : GameObject;

public var playerCollider : CapsuleCollider;
public var playerRigidbody : Rigidbody;

function Awake (){
	playerRigidbody.freezeRotation = true;
    playerRigidbody.useGravity = false;
	myTransform = transform;
	mainCameraGO = gameObject.FindWithTag("MainCamera");
	rayDistance = 1.1;//collider.radius;

}

function FixedUpdate (){
    if (grounded){			
		var inputX = Input.GetAxis("Horizontal");
		var inputY = Input.GetAxis("Vertical");
		var inputModifyFactor = (inputX != 0.0 && inputY != 0.0 && limitDiagonalSpeed)? .7071 : 1.0;

        // Calculate how fast we should be moving
        var targetVelocity = new Vector3(inputX * inputModifyFactor, 0.0, inputY * inputModifyFactor);
        targetVelocity = myTransform.TransformDirection(targetVelocity);
        targetVelocity *= speed;	
		
        // Apply a force that attempts to reach our target velocity
        var velocity = playerRigidbody.velocity;
        var velocityChange = (targetVelocity - velocity);
        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
        velocityChange.y = 0;
        playerRigidbody.AddForce(velocityChange, ForceMode.VelocityChange);
   
        
        if (canJump && Input.GetButton("Jump")){
            playerRigidbody.velocity = Vector3(velocity.x, CalculateJumpVerticalSpeed(), velocity.z);
        }
		
		if(!crouching){
            if (Input.GetButton("Run") && Input.GetKey("w"))
				speed = runSpeed;
			    else 
			    speed = walkSpeed;
			}else{
			speed = crouchSpeed;
		}
	
	}else{
	
		// AirControl 
		targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		targetVelocity = transform.TransformDirection(targetVelocity) * inAirControl;
		playerRigidbody.AddForce(targetVelocity, ForceMode.VelocityChange);
	} 

    // Gravity 
    playerRigidbody.AddForce(Vector3 (0, -gravity * playerRigidbody.mass, 0));
}

function HitJumpPad (velocity : float) {
    playerRigidbody.velocity.z += velocity;
}

function CalculateJumpVerticalSpeed (){
    return Mathf.Sqrt(2 * jumpHeight * gravity);
}

 function IsGrounded() : boolean {
   return Physics.Raycast(transform.position, -Vector3.up, playerCollider.bounds.extents.y + 0.1);
 }

function Update(){
	grounded = IsGrounded();
	
	if(mainCameraGO.transform.localPosition.y > normalHeight){
		mainCameraGO.transform.localPosition.y = normalHeight;
	} else if(mainCameraGO.transform.localPosition.y < crouchHeight){
		mainCameraGO.transform.localPosition.y = crouchHeight;
	}

	if (Input.GetButtonDown("Crouch") && !crouching) {
        playerCollider.height = 1.5;
		playerCollider.center = Vector3 (0, -0.25, 0);
		crouching = true;
	} 

	if(Input.GetButtonUp("Crouch") && crouching){
		playerCollider.height = 2.0;
	    playerCollider.center = Vector3 (0, 0, 0);
        crouching = false;
	}
	
	if(crouching){
		if(mainCameraGO.transform.localPosition.y > crouchHeight){
			if(mainCameraGO.transform.localPosition.y - (crouchingHeight * Time.deltaTime/.1) < crouchHeight){
				mainCameraGO.transform.localPosition.y = crouchHeight;
			} else {
				mainCameraGO.transform.localPosition.y -= crouchingHeight * Time.deltaTime/.1;
			}
		}

	} else {
		if(mainCameraGO.transform.localPosition.y < normalHeight){
			if(mainCameraGO.transform.localPosition.y + (crouchingHeight * Time.deltaTime/.1) > normalHeight){
				mainCameraGO.transform.localPosition.y = normalHeight;
			} else {
				mainCameraGO.transform.localPosition.y += crouchingHeight * Time.deltaTime/.1;
			}
		}
	}
}

@script RequireComponent(Rigidbody)