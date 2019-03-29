
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems  ;

public class Controll : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image JoysticBG;
[SerializeField]
    private Image Joystic;
    private Vector2 InputV;

    public void OnDrag(PointerEventData eventData)
    {

        Vector2 pos;
        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(JoysticBG.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / JoysticBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / JoysticBG.rectTransform.sizeDelta.x);


            InputV = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            InputV = (InputV.magnitude > 1.0f) ? InputV.normalized : InputV;

            Joystic.rectTransform.anchoredPosition = new Vector2(InputV.x * (JoysticBG.rectTransform.sizeDelta.x / 2), InputV.y * (JoysticBG.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        InputV = Vector2.zero;
        Joystic.rectTransform.anchoredPosition = Vector2.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        JoysticBG = GetComponent<Image>();
        Joystic = transform.GetChild(0).GetComponent<Image>();
    }

    
}
