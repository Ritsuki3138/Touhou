using UnityEngine;

namespace Ritsuki
{
    /// <summary>
    /// 玩家控制
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public GameObject Shot;
        public float PLAYERSPEED = 5f;
        public int HP = 1;

        private int counter = 0;

        void Start()
        {
            transform.position = new Vector3(PSVScript.SCREENCENTERX, transform.position.y, transform.position.z);
        }

        void Update()
        {
            counter ++;

            //射出子彈

            if (counter % 7 == 0)
            {
                Instantiate(Shot, transform.position + new Vector3(0.15f, 1.35f, 0), new Quaternion(0, 0, 0, 0));
            }

            if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < PSVScript.BOUNDYMAX)
            {
                transform.Translate(new Vector2(0, PLAYERSPEED * Time.deltaTime));    
            }

            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > PSVScript.BOUNDYMIN)
            {
                transform.Translate(new Vector2(0, -PLAYERSPEED * Time.deltaTime));
            }

            if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < PSVScript.BOUNDXMAX)
            {
                transform.Translate(new Vector2(PLAYERSPEED * Time.deltaTime, 0));
            }

            else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > PSVScript.BOUNDXMIN)
            {
                transform.Translate(new Vector2(-PLAYERSPEED * Time.deltaTime, 0));
            }
        }

        private void LateUpdate()
        {
            if (HP <= 0)
            {
                if (PSVScript.IsDebug)
                {
                    HP = 1;
                }
                else
                {
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
