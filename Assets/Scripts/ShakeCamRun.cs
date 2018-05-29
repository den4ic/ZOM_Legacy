using UnityEngine;
using System.Collections;

//public class ShakeCamRun : MonoBehaviour {
//
//    public float targetTime = 0.2f; // Время на один шаг в секундах
//    public float Smooth = 10; // Мягкость
//    public float AmplitudeHeight = 0.1f; // Амплитуда покачивания вверх-вниз 
//    public float AmplitudeRot = 1.5f; // Амплитуда поворота  
//
//    private float Progress; // Прогресс
//    private int PassedStep = 1; // Шаг
//    private float DefCamPos = 0; // Изначальная позиция камеры
//    private float DefCamRot = 0; // Изначальный поворот камеры
//    private Transform MyTransform; // Наш трансформ
//
//
//    void Start()
//    {
//        MyTransform = transform; // Ну, я где-то прочитал что так будет работать быстрей
//        DefCamPos = MyTransform.localPosition.y; // Изначальная позиция камеры
//        DefCamRot = MyTransform.localEulerAngles.z; // Изначальный поворот камеры
//    }
//
//
//    void Update()
//    {
//        float Pssd = Passed(); // Наш прогресс
//
//        // Позиция в Vector3, к которой мы стримимся
//        Vector3 GoalPos = new Vector3(MyTransform.localPosition.x, Pssd * AmplitudeHeight + DefCamPos, MyTransform.localPosition.z);
//        // Интерполяция позиции (сглаживание)
//        MyTransform.localPosition = Vector3.Lerp(MyTransform.localPosition, GoalPos, Time.deltaTime * Smooth);
//
//
//        // Поворот в Vector3, к которому мы стримимся
//        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 1 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
//        {
//            Pssd = 0; // Только если мы не идем в бок
//        }
//        Vector3 GoalRot = new Vector3(MyTransform.localPosition.x, MyTransform.localPosition.y, Pssd * AmplitudeRot + DefCamRot);
//        // Интерполяция поворота (сглаживание)
//        MyTransform.localEulerAngles = Vector3.Lerp(MyTransform.localPosition, GoalRot, Time.deltaTime * Smooth);
//    }
//
//
//    private float Passed()
//    {
//
//        // Если мы вообще никуда не двигаемся (право, лево, вперед, назад)
//        // То возвращаем ноль
//        if (Mathf.Abs(Input.GetAxis("Horizontal")) == 0 && Mathf.Abs(Input.GetAxis("Vertical")) == 0)
//        {
//            PassedStep = 1; // Сбрасываем шаг
//            return (Progress = 0); // Прогресс сводим к нулю и возвращаем его
//        }
//
//        // Умножаем прогресс на шаг (PassedStep)
//        // Если step = 1, то тогда значение не меняется. 
//        // А если step = -1, то тогда значение формулы становится отрицательным и мы начинаем вычитать из Progress
//        Progress += (Time.deltaTime * (1f / targetTime)) * PassedStep;
//        if (Mathf.Abs(Progress) >= 1)
//        { // Если Progress больше или равно 1, или меньше или равно -1
//            PassedStep *= -1; // Инвертируем шаг
//        }
//
//        // Возвращаем прогресс, он у нас шляется от -1 до 1
//        return Progress;
//    }
//}


//public class ShakeCamRun : MonoBehaviour
//{
//
//    public float Smooth = 5;
//    public float bobSpeed = 0.25f;
//    public float bobAmount = 0.005f;
//
//    private float defCamPos = 0;
//    private float timer = 0.0f;
//    private float camPos;
//    private float waveslice;
//    private float translateChange;
//    private float totalAxes;
//    private Transform MyTransform;
//
//    void Start()
//    {
//        MyTransform = transform;
//        defCamPos = MyTransform.localPosition.y;
//        camPos = defCamPos;
//    }
//
//    void Update()
//    {
//        Vector3 camHeight = new Vector3(MyTransform.localPosition.x, camPos, MyTransform.localPosition.z);
//        Vector3 smoothHeight = Vector3.Lerp(MyTransform.localPosition, camHeight, Time.deltaTime * Smooth);
//        MyTransform.localPosition = smoothHeight;
//
//        waveslice = 0.0f;
//        float horizontal = Input.GetAxis("Horizontal");
//        float vertical = Input.GetAxis("Vertical");
//        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
//        {
//            timer = 0.0f;
//        }
//        else
//        {
//            waveslice = Mathf.Sin(timer);
//            timer = timer + bobSpeed;
//            if (timer > Mathf.PI * 2)
//            {
//                timer = timer - (Mathf.PI * 2);
//            }
//        }
//        if (waveslice != 0)
//        {
//            translateChange = waveslice * bobAmount;
//            totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
//            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
//            translateChange = totalAxes * translateChange;
//            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y + translateChange, MyTransform.localPosition.z);
//        }
//        else
//        {
//            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y, MyTransform.localPosition.z);
//        }
//    }
//}


//public class ShakeCamRun : MonoBehaviour
//{
//
//    public float Smooth = 20;
//    public float bobSpeed = 0.09f;
//    public float bobAmount = 0.005f;
//
//    public float defCamPos = 0;
//    public float timer = 0.0f;
//    public float camPos;
//    public float waveslice;
//    public float translateChange;
//    public float totalAxes;
//    public Transform MyTransform;
//
//    void Start()
//    {
//        MyTransform = transform;
//        defCamPos = MyTransform.localPosition.y;
//        camPos = defCamPos;
//    }
//
//    void Update()
//    {
//        Vector3 camHeight = new Vector3(MyTransform.localPosition.x, camPos, MyTransform.localPosition.z);
//        Vector3 smoothHeight = Vector3.Lerp(MyTransform.localPosition, camHeight, Time.deltaTime * Smooth);
//        MyTransform.localPosition = smoothHeight;
//
//        waveslice = 0.0f;
//        float horizontal = Input.GetAxis("Horizontal");
//        float vertical = Input.GetAxis("Vertical");
//        if (Mathf.Abs(horizontal) == 1 && Mathf.Abs(vertical) == 1)
//        {
//            timer = 0.0f;
//        }
//        else
//        {
//            waveslice = Mathf.Sin(timer);
//            timer = timer + bobSpeed;
//            if (timer > Mathf.PI * 2)
//            {
//                timer = timer - (Mathf.PI * 2);
//            }
//        }
//        if (waveslice != 0)
//        {
//            translateChange = waveslice * bobAmount;
//            totalAxes = 1;
//            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
//            translateChange = totalAxes * translateChange;
//            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y + translateChange, MyTransform.localPosition.z);
//        }
//        else
//        {
//            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y, MyTransform.localPosition.z);
//        }
//    }
//}



public class ShakeCamRun : MonoBehaviour
{

    public float Smooth = 20;
    public float bobSpeed = 0.09f;
    public float bobAmount = 0.005f;

    private float defCamPos = 0;
    private float timer = 0.0f;
    private float camPos;
    private float waveslice;
    private float translateChange;
    private float totalAxes;
    private Transform MyTransform;

    void Start()
    {
        MyTransform = transform;
        defCamPos = MyTransform.localPosition.y;
        camPos = defCamPos;
    }

    void Update()
    {
        Vector3 camHeight = new Vector3(MyTransform.localPosition.x, camPos, MyTransform.localPosition.z);
        Vector3 smoothHeight = Vector3.Lerp(MyTransform.localPosition, camHeight, Time.deltaTime * Smooth);
        MyTransform.localPosition = smoothHeight;

        waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if (Mathf.Abs(horizontal) == 1 && Mathf.Abs(vertical) == 1)
        {
            timer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(timer);
            timer = timer + bobSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }
        if (waveslice != 0)
        {
            translateChange = waveslice * bobAmount;
            totalAxes = 1;
            translateChange = totalAxes * translateChange;
            MyTransform.localPosition = new Vector3(MyTransform.localPosition.x, smoothHeight.y + translateChange, MyTransform.localPosition.z);
        }
    }
}