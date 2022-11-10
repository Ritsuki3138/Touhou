using UnityEngine;

namespace Ritsuki
{
    /// <summary>
    /// 敵機子彈資料
    /// </summary>
    public class EnemyShot1 : MonoBehaviour
    {
        public ShotConfig SC = new ShotConfig();
        int TraceCount = 0;

        void Start()
        {
            transform.rotation = SC.InitAngle;
            transform.position = SC.initposition;
        }

        void Update()
        {
            transform.Translate(SC.initSpeed);

            //加速度
            if (SC.IsAcc)
            {
                SC.initSpeed = SC.initSpeed.normalized * (SC.initSpeed.magnitude + SC.AccValue);
            }

            //轉向
            if (SC.IsRotate)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, SC.RotateValue));
            }

            //反彈
            if (SC.IsReflect)
            {
                if ((SC.ReflectValue == -1) || (SC.ReflectValue > 0))
                {
                    if ((transform.position.y >= PSVScript.BOUNDYMAX) || (transform.position.y <= PSVScript.BOUNDYMIN))
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180 - transform.rotation.eulerAngles.z));

                        if (SC.ReflectValue > 0)
                        {
                            SC.ReflectValue--;
                        }
                    }

                    if ((transform.position.x >= PSVScript.BOUNDXMAX) || (transform.position.x <= PSVScript.BOUNDXMIN))
                    {
                        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -transform.rotation.eulerAngles.z));

                        if (SC.ReflectValue > 0)
                        {
                            SC.ReflectValue--;
                        }
                    }
                }
            }

            //追蹤
            if (SC.IsTarce)
            {
                TraceCount++;
                if ((TraceCount > SC.TarceValue) && (SC.TraceInterval > 0))
                {
                    float AngleZ = Mathf.Atan2(PSVScript.PlayerPosition.y - transform.position.y, PSVScript.PlayerPosition.x - transform.position.x);
                    transform.rotation = Quaternion.Euler(new Vector3(0, 0, AngleZ * Mathf.Rad2Deg - 90));
                    TraceCount = 0;
                    SC.TraceInterval--;
                }
            }

            if ((transform.position.y >= PSVScript.SCREENYMAX) || (transform.position.y <= PSVScript.SCREENYMIN) ||
               (transform.position.x >= PSVScript.SCREENXMAX) || (transform.position.x <= PSVScript.SCREENXMIN))
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerController>().HP --;
                Destroy(this.gameObject);
            }
        }
    }

    public class ShotConfig
    {
        public Quaternion InitAngle;
        public Vector3 initposition, initSpeed;
        public bool IsAcc = false, IsRotate = false, IsReflect = false, IsTarce = false;
        public float AccValue = 0f, RotateValue = 0f;
        public int ReflectValue = 0, TarceValue = 0, TraceInterval = 0;
        // ReflectValue = -1：無限反彈
    }
}
