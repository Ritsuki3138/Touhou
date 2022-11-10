using UnityEngine;

namespace Ritsuki
{
    public class PSVScript : MonoBehaviour
    {
        //抓取玩家位置
        public static Vector3 PlayerPosition;

        // debug 模式
        public static bool IsDebug = false;
        public const float SCREENXMAX = 3.6f, SCREENXMIN = -8.85f, SCREENYMAX = 4.55f, SCREENYMIN = -4.55f, SCREENCENTERX = (3.7f - 8.7f) / 2.0f;
        public const float BOUNDOFFSET = 0.1f,BOUNDXMAX = SCREENXMAX - BOUNDOFFSET, BOUNDXMIN = SCREENXMIN + BOUNDOFFSET,
                                               BOUNDYMAX = SCREENYMAX - BOUNDOFFSET, BOUNDYMIN = SCREENYMIN + BOUNDOFFSET;
        public GameObject PlayerGameObj;
        void Start()
        {
            QualitySettings.vSyncCount = 0; // 將垂直同步關閉
            Application.targetFrameRate = 60; // 設定FPS為60
        }

        void Update()
        {
            if (PlayerGameObj)
            {
                PlayerPosition = PlayerGameObj.transform.position; // 每秒更新玩家座標
            }

            //按 D 鍵 切換 debug 模式
            if (Input.GetKeyDown(KeyCode.D))
            {
                IsDebug = !IsDebug;
            }
        }
    }
}
