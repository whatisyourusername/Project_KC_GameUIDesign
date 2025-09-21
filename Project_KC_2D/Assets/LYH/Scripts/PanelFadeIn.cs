using UnityEngine;
using UnityEngine.UI;

public class PanelFadeIn : MonoBehaviour
{
    private Image whitePanelImage;
    [SerializeField] private float fadeDuration = 1.5f;

    void Start()
    {
        whitePanelImage = GetComponent<Image>();
        StartCoroutine(FadeIn());
    }

    System.Collections.IEnumerator FadeIn()
    {
        float elapsed = 0f;
        Color startColor = whitePanelImage.color;

        yield return new WaitForSeconds(0.5f);

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, elapsed / fadeDuration);
            whitePanelImage.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }
    }
}
