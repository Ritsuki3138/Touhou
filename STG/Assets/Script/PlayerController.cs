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

            if (counter % 8 == 0)
            {
                Instantiate(Shot, transform.position + new Vector3(0.15f, 1.35f, 0), new Quaternion(0, 0, 0, 0));
            }

            if(Input.GetKey(KeyCode.UpArrow) && transform.position.y < 4.45f)
            {
                transform.Translate(new Vector2(0, PLAYERSPEED * Time.deltaTime));    
            }

            else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > -4.45f)
            {
                transform.Translate(new Vector2(0, -PLAYERSPEED * Time.deltaTime));
            }

            if(Input.GetKey(KeyCode.RightArrow) && transform.position.x < 4.95f)
            {
                transform.Translate(new Vector2(PLAYERSPEED * Time.deltaTime, 0));
            }

            else if(Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -4.95f)
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
