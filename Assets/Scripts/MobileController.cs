using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MobileController : MonoBehaviour,IDragHandler,IPointerUpHandler,IPointerDownHandler
{

    private Image JoystickRB;
    [SerializeField]
    private Image KnobJ;
    private Vector2 inputVector;

    private void Start()
    {
        JoystickRB = GetComponent<Image>();
        KnobJ = transform.GetChild(0).GetComponent<Image>();
    }


    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        KnobJ.rectTransform.anchoredPosition = Vector2.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(JoystickRB.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / JoystickRB.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoystickRB.rectTransform.sizeDelta.y);

            inputVector = new Vector2(pos.x*2-1,pos.y*2-1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;

            KnobJ.rectTransform.anchoredPosition = new Vector2(inputVector.x * (JoystickRB.rectTransform.sizeDelta.x / 2), inputVector.y * (JoystickRB.rectTransform.sizeDelta.y / 2));
        }
    }

    public float Horizontal()
    {
        if (inputVector.x != 0) return inputVector.x;
        else return Input.GetAxis("Horizontal");
    }

    public float Vertical()
    {
        if (inputVector.y != 0) return inputVector.y;
        else return Input.GetAxis("Vertical");
    }

}
