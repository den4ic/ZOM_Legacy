using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeleeWeapon : MonoBehaviour {

    public GameObject weaponAnim;
    public string idleAnim = "Idle";

    public float meleeAttackRange = 3.0f;             //how far you can hit someone or something (i suggest to use from 1 to 3).
    public float meleeDamage = 300.0f;                //how much damage will receive enemy.
    public AudioClip meleeSlash;
    public GameObject meleeHitUntagged;
    public GameObject meleeHitEnemy;
    public bool inAttack = false; // было запривачено но без этого нельзя сделать проверку на проигрывание анимации в скроле оружия для корректной работы

    //MELEE ANIMATIONS
    public string axeHit = "HitAnim";
    public string DrawAnimation = "DrawAXE";
    public string axeHitTwo = "HitAnimRight";
    public string axeHitThree = "HitAnimLeft";

  //  public AudioClip soundDraw; // интегрирован в scrollweapon
    public AudioClip soundAxeSlash;

    //CROSSHAIR
    public Texture2D crosshair;

    //GUI
    public GUISkin mySkin;

    public float force = 400;
    public bool selected = false;
    public LayerMask layerMask;



    public int HitCount = 10;
    public Text HitCountText;

    public float curr_time = 0.6f; // счётчик
    public float repeat_time = 0.6f; // повторитель

    protected JoysButton joysbutton;


    void Start()
    {
        weaponAnim.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        weaponAnim.GetComponent<Animation>()[axeHit].wrapMode = WrapMode.Once;
        weaponAnim.GetComponent<Animation>()[axeHit].layer = 1;

        weaponAnim.GetComponent<Animation>()[axeHitTwo].wrapMode = WrapMode.Once;
        weaponAnim.GetComponent<Animation>()[axeHitTwo].layer = 1;

        weaponAnim.GetComponent<Animation>()[axeHitThree].wrapMode = WrapMode.Once;
        weaponAnim.GetComponent<Animation>()[axeHitThree].layer = 1;

        joysbutton = FindObjectOfType<JoysButton>();

        inAttack = false;       
    }

    void Update()
    {
        HitCountText.text = HitCount.ToString();
    }

    void FixedUpdate()
    {
        curr_time -= Time.deltaTime;

        if (selected)
        {
            if (!inAttack && joysbutton.Pressed)    // Input.GetButtonDown("Fire1")
            {
                if (curr_time >= 0.99f) /* Время вышло пишем */
                {
                    StartCoroutine(MeleeAttack());
                }
            }

            if (!inAttack && !joysbutton.Pressed)
            {
                inAttack = false;
                weaponAnim.GetComponent<Animation>().CrossFade(idleAnim);
                curr_time = repeat_time * 1f;
            }

            if (curr_time <= 0.0f) /* Время вышло пишем */
            {
                inAttack = false;
            }

        }
    }

    void OnGUI()
    {

        if (crosshair != null)
        {
            //w = crosshair.width / 2;
            //h = crosshair.height / 2;
            Rect position = new Rect((Screen.width - crosshair.width / 2) / 2, (Screen.height - crosshair.height / 2) / 2, crosshair.width / 2, crosshair.height / 2);
            GUI.DrawTexture(position, crosshair);
        }

    }

    IEnumerator MeleeAttack()
    {
        if (inAttack)
            yield break; // return;
        inAttack = true;

        int rand = Random.Range(0,100);

        if (rand <= 30)
        {
            if (axeHit != "")
            {
                weaponAnim.GetComponent<Animation>()[axeHit].speed = weaponAnim.GetComponent<Animation>()[axeHit].clip.length / 1.0f;
                weaponAnim.GetComponent<Animation>().Play(axeHit);
                //if (HitCount > 0) {
                //    HitCount--;
                //}
            }
        }
        else if (rand > 30 && rand <= 60)
        {
            if (axeHitTwo != "")
            {
                weaponAnim.GetComponent<Animation>()[axeHitTwo].speed = weaponAnim.GetComponent<Animation>()[axeHitTwo].clip.length / 1.0f;
                weaponAnim.GetComponent<Animation>().Play(axeHitTwo);
                //if (HitCount > 0) {
                //    HitCount--;
                //}
            }
        }
        else if (rand > 60)
        {
            if (axeHitThree != "")
            {
                weaponAnim.GetComponent<Animation>()[axeHitThree].speed = weaponAnim.GetComponent<Animation>()[axeHitThree].clip.length / 1.0f;
                weaponAnim.GetComponent<Animation>().Play(axeHitThree);
                //if (HitCount > 0) {
                //    HitCount--;
                //}
            }
        }

        yield return new WaitForSeconds(0.3f);
            GetComponent<AudioSource>().clip = soundAxeSlash;
            GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.2f);
            StartCoroutine(MeleeAttackHit());
            yield return new WaitForSeconds(0.3f);
            curr_time = repeat_time * 1f;
        }

    IEnumerator MeleeAttackHit()
    {
        var direction = transform.TransformDirection(0, 0, 1);
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction,out hit, 600.0f, layerMask.value))
        {
            var contact = hit.point;
            var rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

            if (hit.distance < meleeAttackRange)
            {

                if (hit.rigidbody)
                {
                    hit.rigidbody.AddForceAtPosition(force * direction, hit.point);
                }

                if (hit.transform.tag == "Untagged" || hit.transform.tag == "Concrete" || hit.transform.tag == "Dirt" || hit.transform.tag == "Wood" || hit.transform.tag == "Metal")
                {
                    var default1 = Instantiate(meleeHitUntagged, contact, rotation) as GameObject;
                    default1.transform.position = hit.point;
                    default1.transform.localPosition += .02f * hit.normal;
                    GetComponent<AudioSource>().clip = meleeSlash;
                    GetComponent<AudioSource>().Play();
                }

                if (hit.transform.tag == "Enemy")
                {
                    Instantiate(meleeHitEnemy, contact, rotation);
                }

                hit.collider.SendMessageUpwards("ApplyDamage", meleeDamage, SendMessageOptions.DontRequireReceiver);
            }
        }
        yield return new WaitForSeconds (0.5f);
        inAttack = false;     
    }

    public IEnumerator DrawWeapon()
    {
        //bool draw = true;
       //GetComponent<AudioSource>().clip = soundDraw;
       //GetComponent<AudioSource>().Play();
      //  weaponAnim.GetComponent<Animation>()[DrawAnimation].speed = weaponAnim.GetComponent<Animation>()[DrawAnimation].clip.length / 0.9f; // хз но багается
        weaponAnim.GetComponent<Animation>().Play(DrawAnimation);
        yield return new WaitForSeconds(0.6f);

        selected = true;
    }

    public void Deselect()
    {
        selected = false;
    }



}