using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


/*
  해당 코드는 제작한 UI가 '어떻게 작동하는가' 정도만 보여주기 위한 스크립트 이기에
  그대로 게임에 적용하기에는 좀 난잡하고 비효율적일 겁니다... (코드에 대한 설명은 가능함)
  웬만해서는 그냥 참고 정도만 하시고, 그대로 쓰는건 매우 비추천 합니다...
*/

public class MapMoveSample : MonoBehaviour
{
    public Camera MainCam; // 메인 카메라
    public Vector3 MainCamPos; // 카메라 위치

    public TMP_Text MoveUIText;

    public GameObject NodeMoveUI; // 이동 UI
    public GameObject PartyUI; // 파티원 UI

    public Transform[] MapNodeLocations = new Transform[11]; // 맵 노드별 Transfrom
    public Vector3[] MapNodeVectors = new Vector3[11]; //맵 노드별 Transfrom을 Vector3로 변환하기 위한 함수
    public GameObject[] MapNodeArrows = new GameObject[13]; // 화살표 오브젝트

    public GameObject UIChangeButton; // UI 변경 버튼
    public GameObject UIChangeButton2; // UI 변경 버튼

    public GameObject NodeMoveButton1; //왼쪽 버튼
    public GameObject NodeMoveButton2; //가운데 버튼
    public GameObject NodeMoveButton3; //오른쪽 버튼



    public int CurrentNode;  //현재 플레이어 노드 위치

    /*
    현재 테스트 맵 기준 노드 위치:
    0: 시작 노드
    1: 전투 사건 1 노드
    2: 전투 사건 2 노드
    3: 중립적 사건 1 노드
    4: 긍정적 사건 1 노드
    5: 부정적 사건 1 노드
    6: 정예 전투 사건 노드
    7: 전투 사건 3 노드
    8: 중립적 사건 2 노드
    9: 긍정적 사건 2 노드
    10: 보스 노드
   */


    // Start is called before the first frame update
    void Start()
    {
        MainCamPos = MainCam.transform.position; // 해당 스크립트 내 카메라 위치 = 현재 카메라 위치로 시작
        MoveUIText.text = "어디로 갈까?";
        PartyUI.SetActive(true);
        CurrentNode = 0;
        SetOnlyOneActive(0);

        for (int i = 0; i < MapNodeLocations.Length; i++) // 맵 노드의 Transform을 Vector3로 변환해서, MapNodeVectors 배열에 집어넣음
        {
            if (MapNodeLocations[i] != null)
                MapNodeVectors[i] = MapNodeLocations[i].position;
        }

    }

    // Update is called once per frame
    void Update()
    {

        // SetOnlyOneActive,SetMultipleActive,SetAllActive에 대한 설명은 코드 최하단에 있습니다.
        //갈림길 유형에 따라서, 활성화 되는 버튼 갯수 다름
        //갈림길이 나오는 노드는 UI 전환버튼오로 파티원 UI와 이동 UI 전환 가능
        //갈림길이 좌우이면 Button1,3 활성화
        //단방향 길이면 Button2 만 활성화
        //갈김길이 3개이면 모든 Button 3개 전부 활성화 (갈림길은 최대 3로만 나뉨, 4개 이상으로 나뉘는 길이 없음)
        //단, 해당 스크립트 내에서는 3방향 길을 직접 구현하지 않았지만, 구현은 충분히 가능
        //해당 스크립트는 노드의 위치에 맞춰서 '카메라 이동' 만 대강 구현되었습니다. (플레이어 현재 위치 계산하는 기능은 미포함)

        switch (CurrentNode)
            {
                case 0: //0: 시작 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[0].x, MapNodeVectors[0].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetOnlyOneActive(0); //시작 노드에서는 해당 노드에 활당된 화살표만 활성화하면서 시작
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(true); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;

                case 1: //1: 전투 사건 1 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[1].x, MapNodeVectors[1].y, MainCamPos.z); //이동한 노드 위치로 카메라 이동
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(1, 2); //해당 노드에 할당된 화살표 오브젝트 활성화 (양 방향길이라, 2개 활성화)
                     // 갈림길이 나오는 노드는 UI 전환버튼오로 파티원 UI와 이동 UI 전환 가능
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(true); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(true); // 오른쪽 버튼 활성화
                    break;

                case 2: // 2: 전투 사건 2 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[2].x, MapNodeVectors[2].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(3); //해당 노드에 할당된 화살표 오브젝트 활성화 (단 방향길이라, 1개 활성화)
                    NodeMoveButton1.SetActive(true); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;

                case 3: //  3: 중립적 사건 1 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[3].x, MapNodeVectors[3].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(4, 5); //양방향 길
                    UIChangeButton.SetActive(true);
                    UIChangeButton2.SetActive(true);
                    NodeMoveButton1.SetActive(true);
                    NodeMoveButton2.SetActive(false);
                    NodeMoveButton3.SetActive(true);
                    break;

                case 4: //  4: 긍정적 사건 1 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[4].x, MapNodeVectors[4].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(6); //단방향 길
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(true); // 오른쪽 버튼 활성화
                    break;

                case 5: // 5: 부정적 사건 1 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[5].x, MapNodeVectors[5].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(7, 8); //양방향 길
                    UIChangeButton.SetActive(true);
                    UIChangeButton2.SetActive(true);
                    NodeMoveButton1.SetActive(true);
                    NodeMoveButton2.SetActive(false);
                    NodeMoveButton3.SetActive(true);
                    break;

                case 6: // 6: 정예 전투 사건 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[6].x, MapNodeVectors[6].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(9);//단방향 길
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(true);
                    NodeMoveButton2.SetActive(false); 
                    NodeMoveButton3.SetActive(false); 
                    break;

                case 7: //  7: 전투 사건 3 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[7].x, MapNodeVectors[7].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(10); //단방향 길
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(true); // 오른쪽 버튼 활성화
                    break;

                case 8: //  8: 중립적 사건 2 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[8].x, MapNodeVectors[8].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(11);  //단방향 길
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(true); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;

                case 9: // 9: 긍정적 사건 2 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[9].x, MapNodeVectors[9].y, MainCamPos.z);
                    MoveUIText.text = "어디로 갈까?";
                    SetMultipleActive(12); //단방향 길
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(true); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;

                case 10: //10: 보스 노드
                    MainCam.transform.position = new Vector3(MapNodeVectors[10].x, MapNodeVectors[10].y, MainCamPos.z);
                    MoveUIText.text = "더 이상 갈 방향이 없네 :(";
                    SetAllActive(false);
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;

                default: // 버그 방지용 (switch문 범위 벗어나면, 보스 노드로 이동함, 웬만해서 실제로 작동을 하지 않을 것임.)
                    MainCam.transform.position = new Vector3(MapNodeVectors[10].x, MapNodeVectors[10].y, MainCamPos.z);
                    MoveUIText.text = "더 이상 갈 방향이 없네 :(";    
                    SetAllActive(false);
                    UIChangeButton.SetActive(true); // 이동 UI 내부 전환 버튼 활성화
                    UIChangeButton2.SetActive(true); // 파티원 UI 내부 전환 버튼 활성화
                    NodeMoveButton1.SetActive(false); //왼쪽 버튼 활성화
                    NodeMoveButton2.SetActive(false); //가운데 버튼 비활성화
                    NodeMoveButton3.SetActive(false); // 오른쪽 버튼 활성화
                    break;
            }
    }
        


    public void Button1() //왼쪽 이동 버튼
    {
        Debug.Log("Button1 Press");

        switch (CurrentNode)
        {
            case 0:
                Debug.Log("지금은 사용 불가능"); 
                break;

            case 1:
                Debug.Log("전투 사건 1  -> 전투 사건 2번으로 이동!");
                CurrentNode = 2;
                break;

            case 2:
                Debug.Log("전투 사건 2  -> 긍정적 사건 1번으로 이동!");
                CurrentNode = 4;
                break;

            case 3:
                Debug.Log("중립적 사건 1 -> 부정적 사건 1로 이동!");
                CurrentNode = 5;
                break;

            case 4:
                Debug.Log("긍정적 사건 1 -> 전투 사건 2번으로 이동!");
                CurrentNode = 7;
                break;

            case 5:
                Debug.Log("부정적 사건 1 -> 전투 사건 3번으로 이동!");
                CurrentNode = 7;
                break;

            case 6:
                Debug.Log("정예 전투 사건 -> 중립적 사건 2로 이동!");
                CurrentNode = 8;
                break;

            case 7:
                Debug.Log("지금은 사용 불가능");
                break;

            case 8:
                Debug.Log("지금은 사용 불가능");
                break;

            case 9:
                Debug.Log("지금은 사용 불가능");
                break;

            case 10:
                Debug.Log("지금은 사용 불가능");
                break;

            default:
                Debug.Log("지금은 사용 불가능");
                break;
        }
    }

    public void Button2() // 가운데 버튼
    {
        Debug.Log("Button2 Press");
        switch (CurrentNode)
        {
            case 0:
                Debug.Log("시작 지점 -> 전투 사건 1번으로 이동!");
                CurrentNode = 1;
                break;

            case 1:
                Debug.Log("지금은 사용 불가능");
                break;

            case 2:
                Debug.Log("지금은 사용 불가능");
                break;

            case 3:
                Debug.Log("지금은 사용 불가능");
                break;

            case 4:
                Debug.Log("지금은 사용 불가능");
                break;

            case 5:
                Debug.Log("지금은 사용 불가능");
                break;

            case 6:
                Debug.Log("지금은 사용 불가능");
                break;

            case 7:
                Debug.Log("지금은 사용 불가능");
                break;

            case 8:
                Debug.Log("중립적 사건 2 -> 긍정적 사건 2로 이동!");
                CurrentNode = 9;
                break;

            case 9:
                Debug.Log("긍정적 사건 2 ->보스 전투로 이동!");
                CurrentNode = 10;
                break;

            case 10:
                Debug.Log("지금은 사용 불가능");
                break;

            default:
                Debug.Log("지금은 사용 불가능");
                break;
        }
    }
    public void Button3()  //오른쪽 버튼
    {

        Debug.Log("Button3 Press");
        switch (CurrentNode)
        {
            case 0:
                Debug.Log("지금은 사용 불가능");
                break;

            case 1:
                Debug.Log("전투 사건 1 -> 중립적 사건 1로 이동!");
                CurrentNode = 3;
                break;

            case 2:
                Debug.Log("지금은 사용 불가능");
                break;

            case 3:
                Debug.Log("중립적 사건 1 -> 정예 전투 사건으로 이동!");
                CurrentNode = 6;
                break;

            case 4:
                Debug.Log("긍정적 사건 1 -> 전투 사건 2번으로 이동!");
                CurrentNode = 7;
                break;

            case 5:
                Debug.Log("부정적 사건 1 ->중립적 사건 2로 이동!");
                CurrentNode = 8;
                break;

            case 6:
                Debug.Log("지금은 사용 불가능");
                break;

            case 7:
                Debug.Log("전투 사건 3 -> 긍정적 사건 2로 이동!");
                CurrentNode = 9;
                break;

            case 8:
                Debug.Log("지금은 사용 불가능");
                break;

            case 9:
                Debug.Log("지금은 사용 불가능");
                break;

            case 10:
                Debug.Log("지금은 사용 불가능");
                break;

            default:
                Debug.Log("지금은 사용 불가능");
                break;
        }
    }

    // 갈림길 노드가 나올시 나오는 UI 전환 버튼
    public void UIChange1()
    {  
        PartyUI.SetActive(false);
    }
    public void UIChange2()
    {
        PartyUI.SetActive(true);
    }


    // 노드 위치 리셋 버튼 (테스트용)
    public void ResetButton()
    {
        CurrentNode = 0; //시작 지점으로 리셋됨
    }




    //밑의 코드 3개는 GPT5로 작성했습니다.


    public void SetAllActive(bool isActive) //화살표 전체 비활성화, 사용 예시: SetAllActive(true) or SetAllActive(false) 
    {
        for (int i = 0; i < MapNodeArrows.Length; i++)
        {
            if (MapNodeArrows[i] != null)
                MapNodeArrows[i].SetActive(isActive);
        }
    }


    public void SetOnlyOneActive(int index) //특정 한개의 화살표 제외하고 비활성화, 사용 예시: SetOnlyOneActive(2) = 2번 화살표 빼고 전부 비활성화
    {
        for (int i = 0; i < MapNodeArrows.Length; i++)
        {
            if (MapNodeArrows[i] != null)
                MapNodeArrows[i].SetActive(i == index);
        }
    }

    public void SetMultipleActive(params int[] indices) //특정 여러 개 화살표 제외하고 비활성화, 사용 예시: SetMultipleActive(1,2.4) = 1,2,4 번 화살표 빼고 전부 비활성화
    {
        for (int i = 0; i < MapNodeArrows.Length; i++)
        {
            bool shouldBeActive = System.Array.Exists(indices, idx => idx == i);
            if (MapNodeArrows[i] != null)
                MapNodeArrows[i].SetActive(shouldBeActive);
        }
    }


}
