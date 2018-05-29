using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour {

    public GameObject Arrow; //Префаб стрелы/пули
    private float Timer = 0; //таймер который позволяет стрелять
    public float Reload; //время перезарядки
    public int SummArrow = 5000;
    
    void Start ()
    {
        //Cursor.visible = false; //скрыть курсор
    }

    void Update()
    {
        Timer -= Time.deltaTime; //таймер перезарядки
            if (Input.GetMouseButtonDown(0) && Timer <= 0) //(Input.GetKey(KeyCode.Mouse0) && Timer <= 0) 
            { //нажатия ЛКМ
                var Arrov = Instantiate(Arrow, transform.position, transform.rotation);
                Arrov.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * SummArrow);
                Timer = Reload;//устанавливаем таймер например на 2 сек
            }
     }

}













//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ShootArrow : MonoBehaviour
//{
//
//    public GameObject Arrow; //Префаб стрелы/пули
//    private float Timer; //таймер который позволяет стрелять
//    public float Reload; //время перезарядки
//    public int SummArrow = 5000;
//
//    // Use this for initialization
//    void Start()
//    {
//        //Cursor.visible = false; //скрыть курсор
//    }
//
//    // Update is called once per frame
//    void Update()
//    {
//        Timer -= Time.deltaTime; //таймер перезарядки
//        if (Input.GetMouseButtonDown(0) && Timer <= 0) //(Input.GetKey(KeyCode.Mouse0) && Timer <= 0) 
//        { //нажатия ЛКМ
//            var Arrov = Instantiate(Arrow, transform.position, transform.rotation); //Создаем префаб стрелы в позиции обэкта на котором скрипт
//            //Arrov.rigidbody.AddForce(transform.forward * 5000); //придаем стреле ускорение вперед
//            Arrov.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1) * SummArrow);
//            Timer = Reload;//устанавливаем таймер например на 2 сек
//        }
//    }
//
//}




//var Arrow : GameObject; //Префаб стрелы/пули
//private var Timer : float; //таймер который позволяет стрелять
//var Reload : float; //время перезарядкы
//
//function Start()
//{
//    Screen.showCursor = false; //скрыть курсор 
//}
//
//function Update()
//{
//    Timer -= Time.deltaTime; //таймер перезарядки
//    if (Input.GetKey(KeyCode.Mouse0) && Timer <= 0)
//    { //нажатия ЛКМ
//        var Arrov = Instantiate(Arrow, transform.position, transform.rotation); //Создаем префаб стрелы в позиции обэкта на котором скрипт
//        Arrov.rigidbody.AddForce(transform.forward * 5000); //придаем стреле ускорение вперед
//        Timer = Reload; //устанавливаем таймер например на 2 сек
//    }
//}
