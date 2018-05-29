using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour {

    public GameObject arrowPrefab;
	public float reloadTime = 0.5f;
    public int arrowCount = 20; // надо избавиться от статика
    private double lastShot = -10.0;
    public GameObject launchPosition;
	public Animation anim;
	public AudioSource aSource;
	public AudioClip soundFire;
	public AudioClip pickUp;
	public GameObject arrowGO;
	public LayerMask layerM;
	public Camera mainCamera;
	public float zoomSpeed;
	public float FOV = 30;
    public UnityEngine.UI.Text ammoUI;

    protected JoysButton joysbutton;

    // Use this for initialization
    void Start () {
        //  ammoUI.text = arrowCount.ToString();
        joysbutton = FindObjectOfType<JoysButton>();
    }

    void FixedUpdate()
    {
        ammoUI.text = arrowCount.ToString();
    }

	void Update () {
       //if (Input.GetMouseButton(1))
       //{
       //    mainCamera.fieldOfView -= FOV * Time.deltaTime / zoomSpeed;
       //    if (mainCamera.fieldOfView < FOV)
       //    {
       //        mainCamera.fieldOfView = FOV;
       //    }
       //}
       //else
       //{
       //    mainCamera.fieldOfView += 60 * Time.deltaTime / 0.5f;
       //    if (mainCamera.fieldOfView > 60)
       //    {
       //        mainCamera.fieldOfView = 60;
       //    }
       //}

        var fwd = transform.TransformDirection(Vector3.forward);
        if (!Physics.Raycast(transform.position, fwd, 1, layerM))
        {
            if (joysbutton.Pressed) // Input.GetButtonDown("Fire1")
            {
                if (Time.time > reloadTime + lastShot && arrowCount > 0)
                {
                    Fire();
                }
            }
        }
    }


    void Fire()
    {

        Instantiate(arrowPrefab, launchPosition.transform.position, launchPosition.transform.rotation);
        anim["Shot"].speed = 5;
        anim.Rewind("Shot");
        anim.Play("Shot");

        aSource.PlayOneShot(soundFire, 0.1f);

        lastShot = Time.time;
        arrowCount--;
        ammoUI.text = arrowCount.ToString();
    }

    void PickUpArrow()
    {
        arrowCount++;
        ammoUI.text = arrowCount.ToString();
        aSource.PlayOneShot(pickUp, 0.5f);
    }
}
