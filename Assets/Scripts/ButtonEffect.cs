using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    public float scaleFactor = 1.2f;
    public float speed = 2f;
    private bool isHovered = false;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        if (isHovered)
        {
            float scale = Mathf.PingPong(Time.time * speed, scaleFactor - 1) + 1;
            transform.localScale = originalScale * scale;
        }
        else
        {
            transform.localScale = originalScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
    }
}