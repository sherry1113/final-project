using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    float xRotation;
    float yRotation;

    public Transform Player;

        public Transform target;

        public float smoothSpeed = 0.125f;
        public Vector3 offset;
        
        public float pLerp = 0.02f;
        public float rLerp = 0.01f;

        void Start()
        {
            
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        }

        void Update()
        {
            
        //get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90f);

        // rotate cam
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        Player.rotation =Quaternion.Euler(0, yRotation, 0);

        // cam with player
        transform.position = Vector3.Lerp(transform.position, target.position, pLerp);

        }
}
