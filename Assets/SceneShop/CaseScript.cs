using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CaseScript : MonoBehaviour {

    public bool openCase = false;
    public GameObject[] prefabs;
    public GameObject sp;
    public float scrollSpeed = -20f;
    private float velocity = 3f;
    public WSprites[] ws;
    public Image[] prefabsImages;
    public Image finalDrop;
    public GameObject dropPan;
    private int currentCase;
    private AudioSource _as;
    public AudioClip[] ac;
    private bool wasPlayed = false;
    private bool wasPlayedDrop = false;
    private string Index;

    public GameObject[] prefabweapon;
    public ClickEquipGroup FilterInventory;

    void Start()
    {
        _as = gameObject.GetComponent<AudioSource>();
    }
	
	void Update() {
        if (openCase)
        {
            scrollSpeed = Mathf.MoveTowards(scrollSpeed, 0, velocity * Time.deltaTime);
            RaycastHit2D hit = Physics2D.Raycast(Vector2.down, Vector2.up);
            if (hit.collider != null)
            {
                if (scrollSpeed == 0)
                {
                    dropPan.SetActive(true);
                    finalDrop.sprite = hit.collider.gameObject.GetComponent<Image>().sprite;
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                //  if (!wasPlayedDrop && hit.collider.gameObject.tag != "Common" && hit.collider.gameObject.tag != "Legendary")
                //  {
                //      _as.PlayOneShot(ac[1]);
                //      wasPlayedDrop = true;
                //  }
                //  if (!wasPlayedDrop && hit.collider.tag == "Common" || !wasPlayedDrop && hit.collider.tag == "Legendary")
                //  {
                //      _as.PlayOneShot(ac[2]);
                //      wasPlayedDrop = true;
                //  }


                    if (!wasPlayedDrop && hit.collider.gameObject.tag == "Common")
                    {
                        inventoryPro();
                        wasPlayedDrop = true;
                    }

                    if (!wasPlayedDrop && hit.collider.gameObject.tag == "Rare")
                    {
                        inventoryPro2();
                        wasPlayedDrop = true;
                    }

                    if (!wasPlayedDrop && hit.collider.gameObject.tag == "Mythical")
                    {
                        inventoryPro3();
                        wasPlayedDrop = true;
                    }

                    if (!wasPlayedDrop && hit.collider.gameObject.tag == "Legendary")
                    {
                        inventoryPro4();
                        wasPlayedDrop = true;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                }
                else if (!wasPlayed)
                {
                    _as.PlayOneShot(ac[0]);
                    Index = hit.collider.gameObject.name;
                    wasPlayed = true;
                }
                if (Index != hit.collider.gameObject.name)
                {
                    wasPlayed = false;
                }
            }
            else if (scrollSpeed == 0)
            {
                scrollSpeed = Mathf.MoveTowards(scrollSpeed, -5f, velocity * Time.deltaTime);
            }
        }
	}

    public void inventoryPro()
    {
        GameObject objsss = Instantiate(prefabweapon[0], new Vector3(0, 0, 0), transform.rotation);
        FilterInventory.OnItemClick(objsss); // Добавление предмета в экипировку
        objsss.transform.SetParent(FilterInventory.transform);
        objsss.transform.localScale = new Vector3(1, 1, 1);
        objsss.transform.localPosition = new Vector3(0, 0, 0);
        RectTransform rt = objsss.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 0);
    }

    public void inventoryPro2()
    {
        GameObject objssss = Instantiate(prefabweapon[1], new Vector3(0, 0, 0), transform.rotation);
        FilterInventory.OnItemClick(objssss); // Добавление предмета в экипировку
        objssss.transform.SetParent(FilterInventory.transform);
        objssss.transform.localScale = new Vector3(1, 1, 1);
        objssss.transform.localPosition = new Vector3(0, 0, 0);
        RectTransform rt = objssss.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 0);
    }
    public void inventoryPro3()
    {
        GameObject objsssss = Instantiate(prefabweapon[2], new Vector3(0, 0, 0), transform.rotation);
        FilterInventory.OnItemClick(objsssss); // Добавление предмета в экипировку
        objsssss.transform.SetParent(FilterInventory.transform);
        objsssss.transform.localScale = new Vector3(1, 1, 1);
        objsssss.transform.localPosition = new Vector3(0, 0, 0);
        RectTransform rt = objsssss.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 0);
    }
    public void inventoryPro4()
    {
        GameObject objssssss = Instantiate(prefabweapon[3], new Vector3(0, 0, 0), transform.rotation);
        FilterInventory.OnItemClick(objssssss); // Добавление предмета в экипировку
        objssssss.transform.SetParent(FilterInventory.transform);
        objssssss.transform.localScale = new Vector3(1, 1, 1);
        objssssss.transform.localPosition = new Vector3(0, 0, 0);
        RectTransform rt = objssssss.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(0, 0);
    }


    public void caseBttn(int caseInt)
    {
        openCase = true;
        gameObject.SetActive(true);
        currentCase = caseInt;
        simulateCases();
        // velocity = Random.Range(3f, 3.5f);
        velocity = Random.Range(3f, 3.5f);
    }
    public void restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    void simulateCases()
    {
        for (int a = 0; a < 40; a++)
        {
            int rand = Random.Range(0, 1000);
            int randWeapon = 0;
            if (rand <= 600)
            {
                randWeapon = 0;
                prefabsImages[randWeapon].sprite = ws[currentCase].CommonW[Random.Range(0, ws[currentCase].CommonW.Length)];
            }
            else if (rand > 600 && rand <= 830)
            {
                randWeapon = 1;
                prefabsImages[randWeapon].sprite = ws[currentCase].RareW[Random.Range(0, ws[currentCase].RareW.Length)];
            }
            else if (rand > 830 && rand <= 930)
            {
                randWeapon = 2;
                prefabsImages[randWeapon].sprite = ws[currentCase].MythicalW[Random.Range(0, ws[currentCase].MythicalW.Length)];
            }
            else if (rand > 930) //&& rand <= 990
            {
                randWeapon = 3;
                prefabsImages[randWeapon].sprite = ws[currentCase].LegendaryW[Random.Range(0, ws[currentCase].LegendaryW.Length)];
            }
          // else if (rand > 990)
          // {
          //     randWeapon = 4;
          //     prefabsImages[randWeapon].sprite = ws[currentCase].knife[Random.Range(0, ws[currentCase].knife.Length)];
          // }
            GameObject obj = Instantiate(prefabs[randWeapon], new Vector2(0, 0), Quaternion.identity) as GameObject;
            obj.transform.SetParent(sp.transform);
            obj.transform.localScale = new Vector2(1, 1);
            obj.name = obj.name + a.ToString();
        }
    }
}