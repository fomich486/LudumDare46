using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Animator animator;
    
     public float radius = 0.55f;
     public float translateSpeed = 180.0f;
     public float rotateSpeed = 360.0f;

     float angle = 0.0f;
     Vector3 direction = Vector3.one;
     Quaternion rotation = Quaternion.identity;

     public LayerMask mask;
     
     void Update()    
     {
         if((Input.GetKey(KeyCode.LeftArrow)||Input.GetKey(KeyCode.RightArrow)||Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)) && !animator.GetBool("isRuning") )
            animator.SetBool("isRuning", true);
         else
         {
             if(animator.GetBool("isRuning") &&(!Input.GetKey(KeyCode.LeftArrow)&&!Input.GetKey(KeyCode.RightArrow)&&!Input.GetKey(KeyCode.UpArrow)&&!Input.GetKey(KeyCode.DownArrow)))
                animator.SetBool("isRuning", false);
         }
         
         direction = new Vector3(Mathf.Sin(angle), Mathf.Cos(angle));

         // Rotate with left/right arrows
         if (Input.GetKey(KeyCode.LeftArrow))  Rotate( rotateSpeed);
         if (Input.GetKey(KeyCode.RightArrow)) Rotate(-rotateSpeed);

         Vector3 originCenter = transform.position + transform.forward * transform.localScale.x/2;
         if (!Physics.Raycast(originCenter, transform.forward, 0.05f, mask))
         {
             // Translate forward/backward with up/down arrows
             if (Input.GetKey(KeyCode.UpArrow)) Translate(0, translateSpeed);
            
         }
            
         Vector3 originCenterBack = transform.position - transform.forward * transform.localScale.x/2;
         if (!Physics.Raycast(originCenterBack, -transform.forward, 0.05f, mask))
         {
         // Translate left/right with A/D. Bad keys but quick test.
         if (Input.GetKey(KeyCode.DownArrow)) Translate(0, -translateSpeed);
         }

         UpdatePositionRotation();
     }
 
     void Rotate(float amount)
     {
         angle += amount * Mathf.Deg2Rad * Time.deltaTime;
     }
 
     void Translate(float x, float y)
     {
         var perpendicular = new Vector3(-direction.y, direction.x);
         var verticalRotation = Quaternion.AngleAxis(y * Time.deltaTime, perpendicular);
         var horizontalRotation = Quaternion.AngleAxis(x * Time.deltaTime, direction);
         rotation *= horizontalRotation * verticalRotation;
     }
 
     void UpdatePositionRotation()
     {
         transform.localPosition = rotation * Vector3.forward * radius;
         transform.rotation = rotation * Quaternion.LookRotation(direction, Vector3.forward);
     }
}
