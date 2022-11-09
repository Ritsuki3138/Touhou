using UnityEngine;

namespace Ritsuki
{
    /// <summary>
    /// 玩家子彈資料
    /// </summary>
    public class PlayerShot1 : MonoBehaviour
    {
        public float ShotSpeed = 0.2f;
        public int ATK = 1;

        void Update()
        {
            transform.Translate(new Vector2(0, ShotSpeed));

            if (transform.position.y >= 6)
            {
                Destroy(this.gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyScript>().HP -= ATK;
                Destroy(this.gameObject);
            }
        }
    }
}
