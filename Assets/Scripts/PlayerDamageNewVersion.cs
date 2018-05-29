using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerDamageNewVersion : MonoBehaviour {

    public float hitPoints;
    public int regenerationSkill;
    public int shieldSkill;
    public AudioClip painSound;
    public AudioClip die;
    public Transform deadReplacement;
    public GUISkin mySkin;
    public GameObject explShake;
    private GameObject radar;
    public int maxHitPoints;
    public Texture damageTexture;
    private float time = 0.0f;
    private float alpha;
    private bool callFunction = false;
    //private ScoreManager scoreManager;


   public void Start ()
    {
        hitPoints = maxHitPoints;
        alpha = 0;
    }

	void Update ()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        alpha = time;
        if (hitPoints <= maxHitPoints)
        {
            hitPoints += Time.deltaTime * regenerationSkill;
        }

        if (hitPoints > maxHitPoints)
        {
            float convertToScore = hitPoints - maxHitPoints;
            //scoreManager = gameObject.Find("ScoreManager").GetComponent("ScoreManager");
            //scoreManager.addScore(convertToScore);
            hitPoints = maxHitPoints;
        }
    }

    public void PlayerDamage(int damage)
    {
        if (hitPoints < 0.0)
            return;

        damage -= shieldSkill;

        if (damage > 0)
        {
            // Apply damage
            hitPoints -= damage;
            GetComponent<AudioSource>().PlayOneShot(painSound, 1.0f / GetComponent<AudioSource>().volume);
            time = 2.0f;


            // Are we dead?
            if (hitPoints <= 0.0)
                Die();
        }
        else
        {
            damage = 0;
        }
    }

    //Picking up MedicKit
    public void Medic(int medic)
    {

        hitPoints += medic;

        if (hitPoints > maxHitPoints)
            hitPoints = maxHitPoints;
    }

    IEnumerator Die()
    {
        if (callFunction)
            yield break;
        callFunction = true;

        if (die && deadReplacement)
            AudioSource.PlayClipAtPoint(die, transform.position);

        // Disable all script behaviours (Essentially deactivating player control)
        Component[] coms = GetComponentsInChildren<MonoBehaviour>();
	    foreach (var b in coms)
        {
            var p = b as MonoBehaviour;
            if (p)
                p.enabled = false;
        }
        // Disable all renderers
        var gos = GetComponentsInChildren<Renderer>();
        foreach (Renderer go in gos)
        {
            go.enabled = false;

        }
        //if(radar != null){
        //	radar = gameObject.FindWithTag("Radar");
        //	radar.gameObject.SetActive(false);
        //}
        Instantiate(deadReplacement, transform.position, transform.rotation);
        yield return new WaitForSeconds(4.5f);
        //Destroy (transform.root.gameObject);
        //LevelLoadFade.FadeAndLoadLevel(Application.loadedLevel, Color.black, 2.0);
    }

    public void OnGUI()
    {
        GUI.skin = mySkin;
        var style1 = mySkin.customStyles[0];
        GUI.Label(new Rect(40, Screen.height - 80, 90, 90), " Health: ");
        GUI.Label(new Rect(115, Screen.height - 50, 60, 60), "" + hitPoints.ToString("F0"), style1);

        GUI.color = new Color(1.0f, 1.0f, 1.0f, alpha); //Color (r,g,b,a)
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), damageTexture);
    }

    void Exploasion()
    {
        explShake.GetComponent<Animation>().Play("exploasion");
    }
    void rskill(int quantia)
    {
        regenerationSkill = quantia;
    }
   public void save(bool salve)
    {
        if (salve)
        {
            PlayerPrefs.SetInt("vida", maxHitPoints);
        }
    }
    public void load(bool loaded)
    {
        if (loaded)
        {
            hitPoints = PlayerPrefs.GetInt("Vida", maxHitPoints);
        }

    }

}

