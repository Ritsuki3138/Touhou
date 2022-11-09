using UnityEngine;

namespace Ritsuki
{
    public class EnemyShot1 : MonoBehaviour
    {
        public Quaternion InitAngle;

        void Start()
        {
            transform.rotation = InitAngle;
        }

        void Update()
        {
            transform.Translate(new Vector2(0, 0.05f));

            if ((transform.position.y >= 6) || (transform.position.y <= -6) ||
               (transform.position.x >= 10) || (transform.position.x <= -10))
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
}
