using UnityEngine;

namespace Ritsuki
{
    public class EnemyScript : MonoBehaviour
    {
        public GameObject Shot;
        public int HP = 100;

        private int counter = 0;

        void Update()
        {
            counter++;
            Vector3 ShotAngle = new Vector3(0, 0, Random.Range(0, 360));
            if (counter % 4 == 0)
            {

                GameObject ShotObj = Instantiate(Shot, transform.position, new Quaternion(0, 0, 0, 0));
                ShotObj.GetComponent<EnemyShot1>().InitAngle = Quaternion.Euler(ShotAngle);
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
