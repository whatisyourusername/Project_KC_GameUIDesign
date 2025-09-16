using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ExpandMenu : MonoBehaviour
{
    private Button button;
    [SerializeField] float tweenTime;
    [SerializeField] GameObject panel;

    private RectTransform rectTransform;
    private float originalHeight;

    void Start()
    {
        button = GetComponent<Button>();
        rectTransform = GetComponent<RectTransform>();

        // 원래 높이 기억
        originalHeight = rectTransform.sizeDelta.y;

        button.onClick.AddListener(ToggleExpand);
    }

    private bool isExpanded = false;

    void ToggleExpand()
    {
        float panelHeight = ((RectTransform)panel.transform).rect.height;

        if (isExpanded)
        {
            // 원래 높이로 줄이기
            rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, originalHeight), tweenTime);
        }
        else
        {
            // panel의 현재 높이만큼 확장
            rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, panelHeight + originalHeight), tweenTime);
        }

        isExpanded = !isExpanded;
    }
}
