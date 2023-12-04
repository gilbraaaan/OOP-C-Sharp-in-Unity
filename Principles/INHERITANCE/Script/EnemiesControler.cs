using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Agil
{
    public class EnemiesControler : MonoBehaviour
    {
        public bool child = false;
        private SpawnEnemies spawn;
        public Image bar;
        bool colorChange;
        public Color[] ColorChanging;
        public GameObject RaycastForDetect;
        public bool Movement = false;
        public float[] SpawnX = new float[] {-2.83f, 2.83f, -2.83f, 2.83f , -2.83f, 2.83f };
        public float SpawnY = 1.082443f, SpawnZ = -7.68f;
        public Transform Target;
        public float speedValue = 0.5f;
        float speedMovement;
        public float distance = 0.03f;

        void Awake()
        {
            Target = FindObjectOfType<Player>().transform;
            spawn = FindObjectOfType<SpawnEnemies>();
            Movement = true;
        }
        
        void FixedUpdate()
        {
            //this.transform.LookAt(Target);
            Vector3 rightDetect = RaycastForDetect.transform.TransformDirection
                                    (Vector3.right) * distance;
            Debug.DrawRay(RaycastForDetect.transform.position, rightDetect, Color.green);
            if (Movement == true)
            {
                transform.position = Vector3.Lerp
                    (transform.position, Target.position, 
                    Time.deltaTime * speedMovement);

                if (Vector3.Distance(transform.position, 
                    Target.position) <= 0.45f)
                {
                    idle();
                }else
                {
                    RaycastHit2D hit = Physics2D.Raycast(RaycastForDetect.transform.position,
                        rightDetect, distance);
                    if (hit.collider != null)
                    {
                        idle();
                        //Debug.Log("Enemy In Range!");
                    }
                    else
                    {
                        movement();
                    }
                }
            }
        }

        void movement()
        {
            speedMovement = speedValue;
            this.GetComponent<Animator>().SetBool("Walk", true);
        }
        void idle()
        {
            speedMovement = 0f;
            this.GetComponent<Animator>().SetBool("Walk", false);
        }

        // Blink Damage
        public void Damage(float decrease)
        {
            bar.fillAmount -= decrease;
            if(bar.fillAmount <= 0f)
            {
                spawn.EnemiesDead +=1;
                spawn.GetRandom();
                Destroy(gameObject);
            }else { StartCoroutine(BlinkDamage()); }
        }
        public IEnumerator BlinkDamage()
        {
            GetComponent<SpriteRenderer>().color = ColorChanging[1];
            yield return new WaitForSeconds(0.3f);
            GetComponent<SpriteRenderer>().color = ColorChanging[0];
            yield return new WaitForSeconds(0.3f);
            colorChange = false;
            GetComponent<SpriteRenderer>().color = ColorChanging[0];
        }
    }
}
