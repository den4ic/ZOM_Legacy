using UnityEngine;

public class SwordVelocityFilter : MonoBehaviour
{
    public float tipSpeedForCutting = 1f;
    public float lengthInWorldUnits = 5f;

    private new Transform transform;

    public GameObject CheckAXESlice;


   // public float curr_time; // счётчик для слайсера
   // public float repeat_time; // повторитель

    void Start()
    {
       // curr_time = repeat_time * 1f;

        transform = GetComponent<Transform>();

        priorTipPositionInWorldSpace = deriveTipPosition();
    }

    private Vector3 priorTipPositionInWorldSpace;

    private bool _IsFastEnoughToCut = false;
    public bool IsFastEnoughToCut {
        get {
            return _IsFastEnoughToCut;
        }
    }

    private Vector3 deriveTipPosition()
    {
        return transform.localToWorldMatrix.MultiplyPoint3x4(Vector3.forward * lengthInWorldUnits);
    }

    // Update is called once per frame FixedUpdate or Update
    void FixedUpdate()
    {
        Vector3 tipPositionInWorldSpace = deriveTipPosition();

        Vector3 tipDelta = tipPositionInWorldSpace - priorTipPositionInWorldSpace;

        float tipSpeed = tipDelta.magnitude / Time.deltaTime;

        //_IsFastEnoughToCut = tipSpeed > tipSpeedForCutting;
        // Проверка анимации на атаку топора

        _IsFastEnoughToCut = CheckAXESlice.GetComponent<MeleeWeapon>().curr_time <= 0.6f && CheckAXESlice.GetComponent<MeleeWeapon>().curr_time >= 0.4f;
       // _IsFastEnoughToCut = CheckAXESlice.GetComponent<MeleeWeapon>().inAttack;

        // curr_time -= Time.deltaTime; /* Вычитаем из 10 время кадра (оно в миллисекундах) */
        // if (curr_time <= 0.2f) /* Время вышло пишем */
        // {
        //     _IsFastEnoughToCut = CheckAXESlice.GetComponent<MeleeWeapon>().inAttack;
        //     curr_time = repeat_time * 1f; /* запускает опять таймер на 10,чтобы повторялось бесконечно */
        //
        // }

        priorTipPositionInWorldSpace = tipPositionInWorldSpace;
	}
}
