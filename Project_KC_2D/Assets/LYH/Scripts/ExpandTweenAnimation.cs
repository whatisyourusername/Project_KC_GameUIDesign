using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class ExpandTweenAnimation : MonoBehaviour
{
    private Button button;
    [SerializeField] Image panel;
    [SerializeField] Image panel2;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Image triangle;
    [SerializeField] float tweenTime;
    [SerializeField] float panelHeight;
    [SerializeField] float panelHeight2;

    private RectTransform rectTransform;
    private RectTransform rectTransform2;
    private float originalHeight;
    private float originalHeight2;

    private bool isExpanded = false;

    void Start()
    {
        button = GetComponent<Button>();
        rectTransform = panel.rectTransform;
        rectTransform2 = panel2.rectTransform;

        // 원래 높이 기억
        originalHeight = rectTransform.sizeDelta.y;
        originalHeight2 = rectTransform2.sizeDelta.y;

        button.onClick.AddListener(() =>
        {
            if (isExpanded)
                ToggleShrink();
            else
                ToggleExpand();
        });

    }

    public void ToggleExpand()
    {

        // panel, panel2 확장
        rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, panelHeight), tweenTime);
        rectTransform2.DOSizeDelta(new Vector2(rectTransform2.sizeDelta.x, panelHeight2), tweenTime);

        text.text = "간단하게";
        triangle.rectTransform.DOScale(new Vector3(1, 1, 1), tweenTime);

        isExpanded = true;
    }

    public void ToggleShrink()
    {

        // 원래 높이로 줄이기
        rectTransform.DOSizeDelta(new Vector2(rectTransform.sizeDelta.x, originalHeight), tweenTime);
        rectTransform2.DOSizeDelta(new Vector2(rectTransform2.sizeDelta.x, originalHeight2), tweenTime);

        text.text = "자세히보기";
        triangle.rectTransform.DOScale(new Vector3(1, -1, 1), tweenTime);

        isExpanded = false;
    }
}
