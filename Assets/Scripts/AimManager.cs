using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimManager : MonoBehaviour
{
    public Vector2 dir;
    public RectTransform rectTransform;
    [SerializeField] float speed;

    void Update()
    {
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1)
            dir.Normalize();

        rectTransform.anchoredPosition += dir * Time.deltaTime * speed;
        rectTransform.anchoredPosition = new Vector2(Mathf.Clamp(rectTransform.anchoredPosition.x, 0, Screen.width ), rectTransform.anchoredPosition.y);
        
    }
}
