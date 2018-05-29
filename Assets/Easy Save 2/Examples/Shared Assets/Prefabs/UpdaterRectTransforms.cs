using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdaterRectTransforms : MonoBehaviour {

    public Sprite m_Sprite;

    // Use this for initialization Awake Start
    void Start() {
        //  RectTransform sc = gameObject.AddComponent<RectTransform>();
        // sc.anchorMin = new Vector2(0, 0);
        // sc.anchorMax = new Vector2(1, 1);
        //  sc.sizeDelta = new Vector2(0, 0);
        

        Image im = gameObject.AddComponent<Image>();
        im.sprite = m_Sprite;
        gameObject.GetComponent<UpdaterRectTransforms>().enabled = false;
    }
	
}
