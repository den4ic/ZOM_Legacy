using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {

    private Rigidbody rigidbodyArrow;


    // Use this for initialization
    void Start () {
        //смещение центра тяжести по оси z
        rigidbodyArrow = GetComponent<Rigidbody>();
        rigidbodyArrow.centerOfMass = new Vector3(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // функция проверки столкновения
    void OnCollisionEnter(Collision collision)
    {
        // отключение физики стрелы включение кинематики
        rigidbodyArrow.isKinematic = true;
        // координаты стрелы присоединяются к координатам объекта столкновения.
        transform.parent = collision.transform;
    }

}
