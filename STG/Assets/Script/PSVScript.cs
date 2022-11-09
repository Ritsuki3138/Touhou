using UnityEngine;

namespace Ritsuki
{
    public class PSVScript : MonoBehaviour
    {
        //抓取玩家位置
        public static Vector3 PlayerPosition;
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
        }
    }
}
