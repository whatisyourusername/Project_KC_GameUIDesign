using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRate : MonoBehaviour
{
    private void Awake()
    {
        // 배터리 절약을 위해 절전모드 끄기 (모바일용)
        Application.runInBackground = true;

        // VSync 끄기 (VSync가 켜져 있으면 targetFrameRate 설정이 무시됨)
        QualitySettings.vSyncCount = 0;

        // 프레임 고정
        Application.targetFrameRate = 60;
    }
}
