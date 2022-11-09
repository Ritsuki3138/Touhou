using UnityEngine;

namespace Ritsuki
{
    /// <summary>
    /// 敵機資訊
    /// </summary>
    public class EnemyScript : MonoBehaviour
    {
        public GameObject Shot;
        public int HP = 100;

        private int counter = 0;

        void Update()
        {
            counter++;
            Vector3 ShotAngle = new Vector3(0, 0, Random.Range(120, 240));
            Vector3 ShotPos = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            if (counter % 5 == 0) // 子彈發射間隔
            {

                GameObject ShotObj = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(ShotAngle);
                ShotObj.GetComponent<EnemyShot1>().SC.initposition = ShotPos;
                ShotObj.GetComponent<EnemyShot1>().SC.initSpeed = new Vector3(0, 0.001f, 0); // 初始速度
                //隨機速度0.05f + Random.Range(-0.02f, 0.02f)

                ShotObj.GetComponent<EnemyShot1>().SC.IsAcc = true;
                ShotObj.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                //ShotObj.GetComponent<EnemyShot1>().SC.IsRotate = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度

                ShotObj.GetComponent<EnemyShot1>().SC.IsReflect = true;
                ShotObj.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數

                ShotObj.GetComponent<EnemyShot1>().SC.IsTarce = true;
                ShotObj.GetComponent<EnemyShot1>().SC.TarceValue = 60; // 追蹤間隔
                ShotObj.GetComponent<EnemyShot1>().SC.TraceInterval = 1; // 追蹤次數
            }
        }

        private void LateUpdate()
        {
            if (HP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
