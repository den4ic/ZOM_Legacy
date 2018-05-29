using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayerPush : MonoBehaviour {

    private PlayerController player;
    private ScrolWeapon sw;
    private MeleeWeapon mw;
    public GameObject anim;
    public GameObject animDraw;
    public string ShakeCam = "CamAnimShakeWood";
    public string DrawAnimation = "DrawAXE";
    public bool addForceOne = false;
    public bool addForceTwo = false;

    void Start()
    {
        anim = GameObject.Find("WeaponCam");
        animDraw = GameObject.Find("Animations");
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        sw = GameObject.Find("ScrollWeapon").GetComponent<ScrolWeapon>();
        mw = GameObject.Find("AXE").GetComponent<MeleeWeapon>();
    }

     void Update()
     {
        if (addForceOne == true)
        {
            RepulsionRight();
        }

        if (addForceTwo == true)
        {
            RepulsionLeft();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {           
            anim.GetComponent<Animation>()[ShakeCam].speed = 1.0f;
            anim.GetComponent<Animation>().CrossFade(ShakeCam);        
    
            if (sw.ScrolInt == 1) //|| sw.ScrolInt == 2
            {
                StartCoroutine(AnimDraw());               
            }
        }
    }


    //void OnCollisionEnter(Collision other)
    //{
    //    anim.GetComponent<Animation>()[ShakeCam].speed = 1.0f;
    //    anim.GetComponent<Animation>().CrossFade(ShakeCam);
    //
    //    if (sw.ScrolInt == 1 || sw.ScrolInt == 2)
    //    {
    //        StartCoroutine(AnimDraw());
    //    }
    //}


    IEnumerator AnimDraw()
    {
        mw.selected = false;
        if (DrawAnimation != "")
        {
       // animDraw.GetComponent<Animation>()[DrawAnimation].speed = animDraw.GetComponent<Animation>()[DrawAnimation].clip.length / 1.0f;
        animDraw.GetComponent<Animation>().Play(DrawAnimation);
        }

        yield return new WaitForSeconds(1.0f);
        animDraw.GetComponent<Animation>().Stop();
       
        int rand = Random.Range(0, 100);
        if (rand <= 50)
        {
            addForceOne = true;
            addForceTwo = false;
        }
        else if (rand > 50)
        {
            addForceTwo = true;
            addForceOne = false;
        }

        mw.selected = true;
    }

     public void RepulsionRight()
     {
        if (mw.selected == false)
        {
           player.rb.AddForce(transform.forward * 50, ForceMode.Acceleration);
           player.rb.AddForce(transform.right * 200, ForceMode.Acceleration);
        }
     }


    public void RepulsionLeft()
    {
        if (mw.selected == false)
        {
            player.rb.AddForce(transform.forward * 50, ForceMode.Acceleration);
            player.rb.AddForce(-transform.right * 200, ForceMode.Acceleration);
        }
    }


  //public IEnumerator RepulsionRight()
  //{
  //    player.rb.AddForce(transform.forward * 500, ForceMode.Acceleration);
  //    player.rb.AddForce(transform.right * 500, ForceMode.Acceleration);
  //    yield return new WaitForSeconds(12.3f);
  //}
  //
  //public IEnumerator RepulsionLeft()
  //{
  //    player.rb.AddForce(transform.forward * 500, ForceMode.Acceleration);
  //    player.rb.AddForce(-transform.right * 500, ForceMode.Acceleration);
  //    yield return new WaitForSeconds(12.3f);
  //}



}
















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class TriggerPlayerPush : MonoBehaviour
//{
//
//    // public PlayerController player;
//    public int moveSpeed = 6;
//    //private Transform myTransform;
//
//    private PlayerController player;
//
//    private ScrolWeapon sw;
//    private MeleeWeapon mw;
//
//    public float returnSpeed = 12.0f;
//    public Transform Target;
//
//    public GameObject anim;
//    public GameObject animDraw;
//
//    public GameObject WeaponAXE;
//
//    public string ShakeCam = "CamAnimShakeWood";
//    public string DrawAnimation = "DrawAXE";
//
//    void Start()
//    {
//        anim = GameObject.Find("WeaponCam");
//        animDraw = GameObject.Find("Animations");
//
//        player = GameObject.Find("Player").GetComponent<PlayerController>();
//
//        sw = GameObject.Find("ScrollWeapon").GetComponent<ScrolWeapon>();
//        mw = GameObject.Find("AXE").GetComponent<MeleeWeapon>();
//        // myTransform = player.transform;
//
//        // anim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
//        // anim.GetComponent<Animation>()[ShakeCam].wrapMode = WrapMode.Once;
//        // anim.GetComponent<Animation>()[ShakeCam].layer = 2;
//        // anim.GetComponent<Animation>().Stop();
//        // 
//        // animDraw.GetComponent<Animation>().wrapMode = WrapMode.Loop;
//        // animDraw.GetComponent<Animation>()[DrawAnimation].wrapMode = WrapMode.Once;
//        // animDraw.GetComponent<Animation>()[DrawAnimation].layer = 2;
//        // animDraw.GetComponent<Animation>().Stop();
//    }
//
//
//    //   void Update()
//    //  {
//    //      transform.position = Vector3.Lerp(transform.position, Target.position, 0.01f);
//    //  }
//
//    void OnTriggerEnter(Collider other)
//    {
//        if (other.tag == "Player")
//        {
//            anim.GetComponent<Animation>()[ShakeCam].speed = 1.0f;
//            anim.GetComponent<Animation>().CrossFade(ShakeCam);
//
//            if (sw.ScrolInt == 1 || sw.ScrolInt == 2)
//            {
//                //animDraw.GetComponent<Animation>()[DrawAnimation].speed = 1.0f;
//                //      animDraw.GetComponent<Animation>().CrossFade(DrawAnimation);
//                // if (animDraw.GetComponent<Animation>()[DrawAnimation].time > 1.0f)
//                // {
//                //     animDraw.GetComponent<Animation>().Stop();
//                // }
//
//                StartCoroutine(AnimDraw());
//
//            }
//
//            // player.rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 100, player.rb.velocity.y, player.rb.velocity.z);
//
//
//            // Target.localRotation = Quaternion.Slerp(Target.localRotation, Quaternion.identity, Time.deltaTime * returnSpeed);
//
//            // int rand = 100;
//            //
//            // if (rand <= 50){
//            //
//            //     player.rb.velocity = new Vector3(Input.GetAxis("Horizontal") * 100, player.rb.velocity.y, player.rb.velocity.z);
//            // }
//            // else if (rand > 50)
//            // {
//            //     player.rb.velocity = new Vector3(Input.GetAxis("Horizontal") * -100, player.rb.velocity.y, player.rb.velocity.z);
//            // }
//
//
//
//            //  player.rb.AddForce(-transform.forward * 1000, ForceMode.Acceleration);
//            //player.rb.velocity = new Vector3(player.rb.velocity.x, 4, player.rb.velocity.z);
//
//            //player.rb.velocity = new Vector3( 2000, 5, 2000); // * Time.deltaTime; // player.rb.velocity.x
//
//            // myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
//
//        }
//    }
//
//
//    //void OnCollisionEnter(Collision other)
//    //{
//    //     Debug.Log("Дотронулся");
//    //     anim.GetComponent<Animation>()[ShakeCam].speed = 1.0f;
//    //     anim.GetComponent<Animation>().CrossFade(ShakeCam);
//    //     Debug.Log("Анимация проигралась");
//    //     player.rb.velocity = new Vector3(150, player.rb.velocity.y, 150) ; // player.rb.velocity.x
//    //}
//
//
//
//    IEnumerator AnimDraw()
//    {
//        mw.selected = false;
//        if (DrawAnimation != "")
//        {
//            // animDraw.GetComponent<Animation>()[DrawAnimation].speed = animDraw.GetComponent<Animation>()[DrawAnimation].clip.length / 1.0f;
//            animDraw.GetComponent<Animation>().Play(DrawAnimation);
//        }
//
//        yield return new WaitForSeconds(1.0f);
//        animDraw.GetComponent<Animation>().Stop();
//        mw.selected = true;
//
//        // GetComponent<AudioSource>().clip = soundAxeSlash;
//        // GetComponent<AudioSource>().Play();
//
//    }
//
//
//}