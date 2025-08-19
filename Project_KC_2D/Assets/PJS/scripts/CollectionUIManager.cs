using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionUIManager : MonoBehaviour
{
    // [Header("...")]를 변수 위에 추가하면 인스펙터 창에 소제목이 생깁니다.
    [Header("캐릭터")]
    public List<GameObject> characterPanels;

    [Header("몬스터")]
    public List<GameObject> monsterPanels;

    [Header("사건")]
    public List<GameObject> eventPanels;

    [Header("요리")]
    public List<GameObject> cookingPanels;

    [Header("유물")]
    public List<GameObject> relicPanels;

    // 현재 열려있는 패널을 기억하기 위한 변수
    private GameObject currentActivePanel = null;

    void Start()
    {
        // 시작할 때 모든 패널을 비활성화합니다.
        HideAllPanels();
    }

    // ★★★ 모든 패널을 끄는 범용 함수
    private void HideAllPanels()
    {
        // 모든 리스트를 순회하며 각 패널을 끈다
        foreach (var panel in characterPanels) if (panel != null) panel.SetActive(false);
        foreach (var panel in monsterPanels) if (panel != null) panel.SetActive(false);
        foreach (var panel in eventPanels) if (panel != null) panel.SetActive(false);
        foreach (var panel in cookingPanels) if (panel != null) panel.SetActive(false);
        foreach (var panel in relicPanels) if (panel != null) panel.SetActive(false);
    }

    // 패널을 보여주는 범용 함수
    private void ShowPanel(GameObject panelToShow)
    {
        // 우선 모든 패널을 끈다
        HideAllPanels();

        // 그 다음, 선택한 패널만 켠다
        if (panelToShow != null)
        {
            panelToShow.SetActive(true);
            currentActivePanel = panelToShow;
        }
    }

    // 아래부터는 버튼의 OnClick 이벤트에 직접 연결할 함수들입니다.
    // 인덱스(순서)를 받아서 해당 카테고리의 패널을 켭니다.

    public void ShowCharacterPanel(int index)
    {
        if (index < characterPanels.Count)
            ShowPanel(characterPanels[index]);
    }

    public void ShowMonsterPanel(int index)
    {
        if (index < monsterPanels.Count)
            ShowPanel(monsterPanels[index]);
    }

    public void ShowEventPanel(int index)
    {
        if (index < eventPanels.Count)
            ShowPanel(eventPanels[index]);
    }

    public void ShowCookingPanel(int index)
    {
        if (index < cookingPanels.Count)
            ShowPanel(cookingPanels[index]);
    }

    public void ShowRelicPanel(int index)
    {
        if (index < relicPanels.Count)
            ShowPanel(relicPanels[index]);
    }
}