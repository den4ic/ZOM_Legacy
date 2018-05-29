using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepulsionRight : MonoBehaviour
{

    private PlayerController player;
    private ScrolWeapon sw;
    private MeleeWeapon mw;
    public GameObject anim;
    public GameObject animDraw;
    public GameObject WeaponAXE;
    public string ShakeCam = "CamAnimShakeWood";
    public string DrawAnimation = "DrawAXE";

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
        RepulsionRightW();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            anim.GetComponent<Animation>()[ShakeCam].speed = 1.0f;
            anim.GetComponent<Animation>().CrossFade(ShakeCam);

            if (sw.ScrolInt == 1 || sw.ScrolInt == 2)
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

        mw.selected = true;
    }

    public void RepulsionRightW()
    {
        if (mw.selected == false)
        {
            player.rb.AddForce(transform.forward * 50, ForceMode.Acceleration);
            player.rb.AddForce(transform.right * 200, ForceMode.Acceleration);
        }
    }


}

