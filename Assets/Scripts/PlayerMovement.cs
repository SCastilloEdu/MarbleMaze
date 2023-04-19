using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement: MonoBehaviour {
	
   private Rigidbody rb;

   [Header("Options")]
   public float speed = 0.5f;
   private float moveForce;
   public float jumpForce;
   public float raycastDistance;
   public bool autohop = true;
   public float jumpBuffer = 0.05f;
   private float jumpBufferTimer = 0f;
   [Header("Movement Keys")]
   public KeyCode upKey = KeyCode.W;
   public KeyCode downKey = KeyCode.S;
   public KeyCode leftKey = KeyCode.A;
   public KeyCode rightKey = KeyCode.D;
   public KeyCode upKeyAlt = KeyCode.UpArrow;
   public KeyCode downKeyAlt = KeyCode.DownArrow;
   public KeyCode leftKeyAlt = KeyCode.LeftArrow;
   public KeyCode rightKeyAlt = KeyCode.RightArrow;

   IEnumerator wait(double sec) {
      yield
      return new WaitForSeconds(Convert.ToSingle(sec));
   }

   void FixedUpdate() {
      if (Input.GetKey(upKey) || Input.GetKey(upKeyAlt)) // Up
      {
         if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) // Up Left
         {
            rb.AddForce(Vector3.forward * moveForce / 1.5f, ForceMode.Impulse);
			rb.AddForce(Vector3.left * moveForce / 1.5f, ForceMode.Impulse);
         } else if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) // Up Right
         {
            rb.AddForce(Vector3.forward * moveForce / 1.5f, ForceMode.Impulse);
			rb.AddForce(Vector3.right * moveForce / 1.5f, ForceMode.Impulse);
         } else {
            rb.AddForce(Vector3.forward * moveForce, ForceMode.Impulse);
         }
      }

      if (Input.GetKey(downKey) || Input.GetKey(downKeyAlt)) // Down
      {
         if (Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) // Down Left
         {
            rb.AddForce(Vector3.back * moveForce / 1.5f, ForceMode.Impulse);
			rb.AddForce(Vector3.left * moveForce / 1.5f, ForceMode.Impulse);
         } else if (Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) // Down Right
         {
            rb.AddForce(Vector3.back * moveForce / 1.5f, ForceMode.Impulse);
			rb.AddForce(Vector3.right * moveForce / 1.5f, ForceMode.Impulse);
         } else {
            rb.AddForce(Vector3.back * moveForce, ForceMode.Impulse);
         }
      }

      if ((Input.GetKey(leftKey) || Input.GetKey(leftKeyAlt)) && !(Input.GetKey(upKey) || Input.GetKey(upKeyAlt) || Input.GetKey(downKey) || Input.GetKey(downKeyAlt))) // Left
      {
		  rb.AddForce(Vector3.left * moveForce, ForceMode.Impulse);
	  }
	  if ((Input.GetKey(rightKey) || Input.GetKey(rightKeyAlt)) && !(Input.GetKey(upKey) || Input.GetKey(upKeyAlt) || Input.GetKey(downKey) || Input.GetKey(downKeyAlt))) // Right
	  {
		 rb.AddForce(Vector3.right * moveForce, ForceMode.Impulse);
	  }
   }
   
   void Start() { // Start is called before the first frame update
      rb = GetComponent < Rigidbody > ();
	  moveForce = speed;
   }

   void Update() { // Update is called once per frame
      if ((Input.GetKeyDown(KeyCode.Space)) || (Input.GetKey(KeyCode.Space)) && autohop)
         if (Grounded() && jumpBufferTimer <= 0) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpBufferTimer = jumpBuffer;
         }

      if (Grounded()) {
         jumpBufferTimer -= Time.deltaTime;
		 moveForce = speed;
      } else {
		 moveForce = speed/2;
	  }
   }

   bool Grounded() { // Tells if the player is on the ground.
      return Physics.Raycast(transform.position, Vector3.down, raycastDistance);
   }
}

// Textures
//https://free-3dtextureshd.com/download/oak-wood-seamless-3d-textures-pbr-material-high-resolution-free-download-4k-unity-unreal-vray/
//https://free-3dtextureshd.com/download/metal-iron-3d-texture-bpr-material-seamless-high-resolution-free-download-hd-4k/