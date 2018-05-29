using UnityEngine;
using System.Collections;

public class CameraSteer : MonoBehaviour {
	
	private Vector3 naturalForward, naturalUp, naturalRight;
	private Vector3 forward, forwardDelta;
	private new Transform transform;
	public float panSpeed = 0.33f;
	
	void Awake ()
	{
		transform = GetComponent<Transform>();
		
		naturalForward = transform.forward;
		naturalRight = transform.right;
		naturalUp = transform.up;
		
		forward = naturalForward;
		forwardDelta = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
		Vector2 current = (Vector2) Input.mousePosition;

        Vector2 delta = current - center;
		
		delta.x /= Screen.width;
		delta.y /= Screen.height;
		
		delta *= 0.33f;
		
		Vector3 idealForward = (naturalForward + naturalRight * delta.x + naturalUp * delta.y).normalized;
		
		forward = Vector3.SmoothDamp(forward, idealForward, ref forwardDelta, panSpeed);
		
		transform.forward = forward;
	}
}

//using UnityEngine;
//using System.Collections;
//public class CameraSteer : MonoBehaviour
//{
//    float iy;
//    float x;
//    Vector3 povorot;
//    Vector3 povorotx;
//    public float minRazbros = -1;
//    public float maxRazbros = 1;
//    float minR;
//    public float razbrosHoot;
//
//
//    void Update()
//    { 
//        x = Random.Range(minRazbros, maxRazbros);
//        iy = Random.Range(minRazbros, maxRazbros);
//        povorot = transform.localRotation.eulerAngles;
//        povorot.y = iy * Time.deltaTime;
//        povorotx.x = x * Time.deltaTime;
//        //  Debug.Log(povorot);
//        Quaternion targets = Quaternion.Euler(x, iy, 0);
//        transform.rotation = Quaternion.Slerp(transform.rotation, targets, Time.deltaTime * razbrosHoot);
//
//      //  povorotx = transform.localRotation.eulerAngles;
//      //  povorotx.x = x;
//      //  Quaternion target = Quaternion.Euler(povorotx);
//      //  transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * razbrosHoot);
//
//    }
//}


//using UnityEngine;
//using System.Collections;
//
//public class CameraSteer : MonoBehaviour
//{
//
//    private Vector3 naturalForward, naturalUp, naturalRight;
//    private Vector3 forward, forwardDelta;
//    private new Transform transform;
//    public float panSpeed = 0.33f;
//
//    void Awake()
//    {
//        transform = GetComponent<Transform>();
//
//        naturalForward = transform.forward;
//        naturalRight = transform.right;
//        naturalUp = transform.up;
//
//        forward = naturalForward;
//        forwardDelta = Vector3.zero;
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        Vector2 center = new Vector2(Screen.width / 2f, Screen.height / 2f);
//        Vector2 current = (Vector2)Input.mousePosition;
//
//        Vector2 delta = current - center;
//
//        delta.x /= Screen.width;
//        delta.y /= Screen.height;
//
//        delta *= 0.33f;
//
//        Vector3 idealForward = (naturalForward + naturalRight * delta.x + naturalUp * delta.y).normalized;
//
//        forward = Vector3.SmoothDamp(forward, idealForward, ref forwardDelta, panSpeed);
//
//        transform.forward = forward;
//    }
//}
