using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class JoyCon : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Image joyBG;
    [SerializeField]
    public Image joy;
    private Vector2 Inputvector;
    private bool active;
    
    private void Awake()
    {
        joyBG = GetComponent<Image>();
        joy = transform.GetChild(0).GetComponent<Image>();
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(joyBG.rectTransform, eventData.position, eventData.pressEventCamera, out pos))
        {
            pos.x = (pos.x / joyBG.rectTransform.sizeDelta.x);
            pos.y = (pos.y / joyBG.rectTransform.sizeDelta.x);
            Inputvector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            Inputvector = (Inputvector.magnitude > 1.0f) ? Inputvector.normalized : Inputvector;
            joy.rectTransform.anchoredPosition = new Vector2(Inputvector.x * (joyBG.rectTransform.sizeDelta.x / 2), Inputvector.y * (joyBG.rectTransform.sizeDelta.y / 2));

        }
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    { Inputvector = Vector2.zero;
        joy.rectTransform.anchoredPosition = Vector2.zero;
        active = !active;

    }
    public virtual void OnPointerDown(PointerEventData eventData)
    { OnDrag(eventData); active = !active; }

    public float Horizon()
    {
        return Inputvector.x;
    }
    public float Vertical()
    {
        return Inputvector.y;
    }
    public bool IsActive()
    {
        return active;

    }
    
}
