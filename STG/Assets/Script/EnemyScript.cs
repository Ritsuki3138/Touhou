using UnityEngine;

namespace Ritsuki
{
    /// <summary>
    /// 敵機資訊
    /// </summary>
    public class EnemyScript : MonoBehaviour
    {
        public GameObject Shot;
        public int HP = 50;  // 敵機血量

        private int counter = 0;
        private Vector3 EnemyPos = new Vector3();
        private bool ShotDir = true;

        void Start()
        {
            transform.position = new Vector3(PSVScript.SCREENCENTERX, transform.position.y, transform.position.z);
        }

        void Update()
        {
            counter++;

            //敵機移動
            if ((counter > 120) && (counter % 120 == 0))
            {
                EnemyPos = new Vector3(Random.Range(-3, 3) - transform.position.x, Random.Range(2.5f, 4) - transform.position.y, 0);
            }

            if ((counter > 120) && (counter % 120 <= 60))
            {
                transform.Translate(EnemyPos / 60);
            }

            //敵機發射子彈
            
            Vector3 ShotPos = transform.position; // + new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0) 隨機
            if (counter % 60 == 0) // 子彈發射間隔
            {
                Vector3 ShotAngle = new Vector3(0, 0, Random.Range(0, 360)); //生成子彈的範圍
                int LoopCount = 20; // 生成子彈的數量
                for (int i = 0; i < LoopCount; i++)
                {
                    float AngleZ = ShotAngle.z + (360 / LoopCount) * i;
                    GameObject ShotObj = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));

                    //子彈偏向角度
                    if (ShotDir)
                    {
                        ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, AngleZ - 50));
                    }
                    else
                    {
                        ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, AngleZ - 130));
                    }
                    ShotObj.GetComponent<EnemyShot1>().SC.initposition = ShotPos + new Vector3(Mathf.Cos(AngleZ * Mathf.Deg2Rad) * 2, Mathf.Sin(AngleZ * Mathf.Deg2Rad) * 2, 0);
                    ShotObj.GetComponent<EnemyShot1>().SC.initSpeed = new Vector3(0, 0.04f, 0); // 初始速度，隨機速度0.05f + Random.Range(-0.02f, 0.02f)

                    ShotObj.GetComponent<EnemyShot1>().SC.IsRotate = true;
                    ShotObj.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度
                }
                ShotDir = !ShotDir;

                //ShotObj.GetComponent<EnemyShot1>().SC.IsAcc = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                //ShotObj.GetComponent<EnemyShot1>().SC.IsRotate = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度

                //ShotObj.GetComponent<EnemyShot1>().SC.IsReflect = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數

                //ShotObj.GetComponent<EnemyShot1>().SC.IsTarce = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.TarceValue = 60; // 追蹤間隔
                //ShotObj.GetComponent<EnemyShot1>().SC.TraceInterval = 1; // 追蹤次數
            }
                        
            if (counter % 130 == 0) // 子彈發射間隔
            {
                int LoopCount = 12; // 生成子彈的數量

                for (int i = 0; i < LoopCount; i++)
                {
                    ShotPos = new Vector3(transform.position.x + 2, transform.position.y, 0);
                    GameObject ShotObj = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                    ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, 0));
                    ShotObj.GetComponent<EnemyShot1>().SC.initposition = ShotPos;
                    ShotObj.GetComponent<EnemyShot1>().SC.initSpeed = new Vector3(0, 0.03f + i * 0.012f, 0); // 初始速度，隨機速度0.05f + Random.Range(-0.02f, 0.02f)

                    ShotObj.GetComponent<EnemyShot1>().SC.IsAcc = true;
                    ShotObj.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                    //ShotObj.GetComponent<EnemyShot1>().SC.IsRotate = true;
                    //ShotObj.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度

                    //ShotObj.GetComponent<EnemyShot1>().SC.IsReflect = true;
                    //ShotObj.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數

                    ShotObj.GetComponent<EnemyShot1>().SC.IsTarce = true;
                    ShotObj.GetComponent<EnemyShot1>().SC.TarceValue = 0; // 追蹤間隔
                    ShotObj.GetComponent<EnemyShot1>().SC.TraceInterval = 1; // 追蹤次數

                    ShotPos = new Vector3(transform.position.x - 2, transform.position.y, 0);
                    GameObject ShotObj1 = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                    ShotObj1.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, 0));
                    ShotObj1.GetComponent<EnemyShot1>().SC.initposition = ShotPos;
                    ShotObj1.GetComponent<EnemyShot1>().SC.initSpeed = new Vector3(0, 0.03f + i * 0.012f, 0); // 初始速度，隨機速度0.05f + Random.Range(-0.02f, 0.02f)

                    ShotObj1.GetComponent<EnemyShot1>().SC.IsAcc = true;
                    ShotObj1.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                    //ShotObj1.GetComponent<EnemyShot1>().SC.IsRotate = true;
                    //ShotObj1.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度

                    //ShotObj1.GetComponent<EnemyShot1>().SC.IsReflect = true;
                    //ShotObj1.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數

                    ShotObj1.GetComponent<EnemyShot1>().SC.IsTarce = true;
                    ShotObj1.GetComponent<EnemyShot1>().SC.TarceValue = 0; // 追蹤間隔
                    ShotObj1.GetComponent<EnemyShot1>().SC.TraceInterval = 1; // 追蹤次數
                }
            }

            if (counter % 100 == 0) // 子彈發射間隔
            {
                Vector3 ShotAngle = new Vector3(0, 0, Random.Range(120, 240)); //生成子彈的範圍
                int LoopCount = 10; // 生成子彈的數量
                for (int i = 0; i < LoopCount; i++)
                {
                    float AngleZ = ShotAngle.z + (360 / LoopCount) * i;
                    GameObject ShotObj = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));

                    //子彈偏向角度
                    if (ShotDir)
                    {
                        ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, AngleZ - 50));
                    }
                    else
                    {
                        ShotObj.GetComponent<EnemyShot1>().SC.InitAngle = Quaternion.Euler(new Vector3(0, 0, AngleZ - 130));
                    }
                    ShotObj.GetComponent<EnemyShot1>().SC.initposition = ShotPos + new Vector3(Mathf.Cos(AngleZ * Mathf.Deg2Rad) * 2, Mathf.Sin(AngleZ * Mathf.Deg2Rad) * 2, 0);
                    ShotObj.GetComponent<EnemyShot1>().SC.initSpeed = new Vector3(0, 0.04f, 0); // 初始速度，隨機速度0.05f + Random.Range(-0.02f, 0.02f)

                    ShotObj.GetComponent<EnemyShot1>().SC.IsAcc = true;
                    ShotObj.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                    ShotObj.GetComponent<EnemyShot1>().SC.IsReflect = true;
                    ShotObj.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數
                }
                ShotDir = !ShotDir;

                //ShotObj.GetComponent<EnemyShot1>().SC.IsAcc = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.AccValue = 0.0015f; // 加速度多寡

                //ShotObj.GetComponent<EnemyShot1>().SC.IsRotate = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.RotateValue = Random.Range(-0.8f, 0.8f); // 轉向幅度

                //ShotObj.GetComponent<EnemyShot1>().SC.IsReflect = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.ReflectValue = 1; // 反彈次數

                //ShotObj.GetComponent<EnemyShot1>().SC.IsTarce = true;
                //ShotObj.GetComponent<EnemyShot1>().SC.TarceValue = 60; // 追蹤間隔
                //ShotObj.GetComponent<EnemyShot1>().SC.TraceInterval = 1; // 追蹤次數
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
