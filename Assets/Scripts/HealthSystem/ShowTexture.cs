using UnityEngine;
using System.Collections;

public class ShowTexture : MonoBehaviour
{
bool show;
public Texture2D textureToShow;

void Start (){
	show = true;
}

void OnGUI (){
	if(show){
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), textureToShow);
	}
}
}