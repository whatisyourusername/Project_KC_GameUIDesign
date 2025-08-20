using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
  해당 코드는 제작한 UI가 '어떻게 작동하는가' 정도만 보여주기 위한 스크립트 이기에,
  그대로 게임에 적용하기에는 좀 난잡하고 비효율적일 겁니다... (코드에 대한 설명은 가능함)
  웬만해서는 그냥 참고 정도만 하시고, 그대로 쓰는건 매우 비추천 합니다...
*/


public class ArrowMove : MonoBehaviour
{
    public MapMoveSample MapMoveSample; //맵 노드 이동에서 코드를 받아옴

    public int ArrowDirection; //화살표 이동방향 

    //화살표는 스프라이트라서, Canvas의 Button 처럼 작동이 불가능해서
    //화살표에 일일히 Box Collider 2D를 넣고, 그 콜라이더를 이용한 충돌(터치)를 이용해서 버튼처럼 구현함.
    //콜라이더는 터치 체크용이라서, 해당 스크립트 내에서는 딱히 콜라이더 관련 처리를 하지 않음.

    // Start is called before the first frame update

    void OnMouseDown() // 
    {
        switch(ArrowDirection)
        {
            case 0:
                MapMoveSample.CurrentNode = 1;
                break;

            case 1:
                MapMoveSample.CurrentNode = 2;
                break;

            case 2:
                MapMoveSample.CurrentNode = 3;
                break;

            case 3:
                MapMoveSample.CurrentNode = 4;
                break;

            case 4:
                MapMoveSample.CurrentNode = 5;
                break;

            case 5:
                MapMoveSample.CurrentNode = 6;
                break;

            case 6:
                MapMoveSample.CurrentNode = 7;
                break;

            case 7:
                MapMoveSample.CurrentNode = 7;
                break;

            case 8:
                MapMoveSample.CurrentNode = 8;
                break;

            case 9:
                MapMoveSample.CurrentNode = 8;
                break;

            case 10:
                MapMoveSample.CurrentNode = 9;
                break;


            case 11:
                MapMoveSample.CurrentNode = 9;
                break;

            case 12:
                MapMoveSample.CurrentNode = 10;
                break;



            default:
                MapMoveSample.MainCam.transform.position = new Vector3(MapMoveSample.MapNodeVectors[10].x, MapMoveSample.MapNodeVectors[10].y, MapMoveSample.MainCamPos.z);
                break;

        }
    }

}
