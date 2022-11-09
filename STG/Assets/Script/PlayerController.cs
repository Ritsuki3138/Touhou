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

        void Update()
        {
            counter ++;

            //射出子彈

            if (counter % 10 == 0)
            {
                Instantiate(Shot, transform.position + new Vector3(0.15f, 1.35f, 0), new Quaternion(0, 0, 0, 0));
            }

            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector2(0, PLAYERSPEED * Time.deltaTime));    
            }

            else if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector2(0, -PLAYERSPEED * Time.deltaTime));
            }

            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector2(PLAYERSPEED * Time.deltaTime, 0));
            }

            else if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector2(-PLAYERSPEED * Time.deltaTime, 0));
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
