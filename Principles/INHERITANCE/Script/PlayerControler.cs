using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Agil
{
    public enum playerCheck { move, wait }

    public class PlayerControler : MonoBehaviour
    {
        public GameObject RaycastForDetect;
        public float distance = 0.1f;
        public playerCheck Detect = playerCheck.move;
        public float lastTime, Move;
        public float Movement = 50f;
        void Update()
        {
            if (Time.time > lastTime + .5f)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Move = 0f;
                    //Detect = playerCheck.wait;
                    lastTime = Time.time;
                    this.gameObject.GetComponent<Animator>().SetTrigger("Attack");
                    #region DAMAGE WITH RAYCAST
                    Vector3 rightDetect = RaycastForDetect.transform.TransformDirection
                                            (Vector3.right) * distance;
                    RaycastHit2D hit = Physics2D.Raycast(RaycastForDetect.transform.position,
                        rightDetect, distance);
                    if (hit.collider != null)
                    {
                        if (hit.collider.TryGetComponent<EnemiesControler>(out var Damageable))
                        {
                            Damageable.Damage(0.5f);
                        }
                    }
                    #endregion
                }
                //else if (Time.time != lastTime)
                //{
                //    Detect = playerCheck.move;
                //}
            }
        }
        void FixedUpdate()
        {
            #region MOVEMENT
            if (Detect == playerCheck.move)
            {
                if (Input.GetKey(KeyCode.D))
                {
                    rotateRight();
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rotateLeft();
                }
                else
                {
                    Move = 0f;
                    this.gameObject.GetComponent<Animator>().SetBool("Walk", false);
                }
            }
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                       Move * Time.deltaTime,
                       this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
            #endregion
        }

        void rotateLeft()
        {
            Move = -Movement;
            transform.rotation = Quaternion.Euler(
                0, 180, 0);
            this.gameObject.GetComponent<Animator>().SetBool("Walk", true);
        }

        void rotateRight()
        {
            Move = Movement;
            transform.rotation = Quaternion.Euler(
                0,0, 0);
            this.gameObject.GetComponent<Animator>().SetBool("Walk", true);
        }
    }
}
