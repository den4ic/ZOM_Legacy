using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public float smooth = 2.0f; // 2.0f
    public float tiltAngle; // = -30.0f

    private MobileController mContr;

    void Start()
    {
        mContr = GameObject.FindWithTag("Joystick").GetComponent<MobileController>();
    }

    void FixedUpdate()
    {
        CamerOsy();
    }


    public void CamerOsy()
    {
        // float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        // float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

        float tiltAroundZ = mContr.Horizontal() * tiltAngle;
        float tiltAroundX = mContr.Vertical() * tiltAngle;
        Quaternion target = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);


    }
}

//public class Razbros : MonoBehaviour
//{
//    float iy;
//    float x;
//    Vector3 povorot;
//    Vector3 povorotx;
//    float minRazbros = -1;
//    float maxRazbros = 1;
//    float minR;
//    public float razbrosHoot;
//
//
//    void Update()
//  }
//    x = Random.Range(minRazbros, maxRazbros);
//    iy = Random.Range(minRazbros, maxRazbros);
//    povorot = transform.localRotation.eulerAngles;
//    povorot.y = iy;
//    Debug.Log(povorot);
//    transform.localRotation = Quaternion.Euler(povorot);
//
//    povorotx = transform.localRotation.eulerAngles;
//    povorotx.x = x;
//    transform.localRotation = Quaternion.Euler(povorotx);
//                   
//    }
//}
 