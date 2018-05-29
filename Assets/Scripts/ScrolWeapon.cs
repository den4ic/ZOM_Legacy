using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrolWeapon : MonoBehaviour {

    public GameObject Weapon1;
    public GameObject Weapon2;
    //public GameObject Weapon3;
    public AudioClip soundDraw;
    protected MeleeWeapon drawWeapons;

    public int MaxWeapon = 1; //3
    public int ScrolInt;

    void Start () {
        drawWeapons = FindObjectOfType<MeleeWeapon>();
    }

    void Update () {

        if (Weapon2.GetComponent<MeleeWeapon>().HitCount <= 0)
        {
            Weapon1.SetActive(true);
            Weapon2.SetActive(false);

            ScrolInt -= 1;
        }

    	if (ScrolInt == 0) {
          // Weapon2.GetComponent<MeleeWeapon>().inAttack = false;
          // Weapon2.GetComponent<MeleeWeapon>().selected = false;
            Weapon1.SetActive (true);
    		Weapon2.SetActive (false);
        }

    	if (ScrolInt == 1) {
         // Weapon2.GetComponent<MeleeWeapon>().selected = true;
            Weapon1.SetActive (false);
    		Weapon2.SetActive (true);
        }

    	if (ScrolInt <= 0) {
    		ScrolInt = 0;
    	}
    	if (ScrolInt >= MaxWeapon) {
    		ScrolInt = MaxWeapon;
    	}
    	//if (Input.GetAxis ("Mouse ScrollWheel") > 0f) { 
    	//	ScrolInt += 1;
    	//}if (Input.GetAxis ("Mouse ScrollWheel") < 0f) { 
    	//	ScrolInt -= 1;
    	//}
    }

    public void swapWeapons()
    {
        if (ScrolInt == 0) // если 0 - это арболет, то при свапе меняется индекс и булевое значение 
        {
            StartCoroutine(drawWeapons.DrawWeapon());
            GetComponent<AudioSource>().clip = soundDraw;
            GetComponent<AudioSource>().Play();
            // Weapon2.GetComponent<MeleeWeapon>().selected = true;
            ScrolInt += 1;
        }
        else if (ScrolInt == 1)
        {
            Weapon2.GetComponent<MeleeWeapon>().inAttack = false;
            Weapon2.GetComponent<MeleeWeapon>().selected = false;
            ScrolInt -= 1;
        }
    }
}

