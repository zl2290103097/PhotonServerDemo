using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Photon.Pun.Demo.Asteroids
{
	public class Move : MonoBehaviourPunCallbacks, IPunObservable
	{
		private float ballVelocity = 3.0f;

		public float speed = 5.0f;

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
//		float BallX = Input.GetAxis("Horizontal");
//		float BallY = Input.GetAxis("Vertical");
// 
//		if (BallX>0)
//		{
//			transform.GetComponent<Rigidbody>().velocity = Vector3.right*ballVelocity;
//		}
//		if (BallX < 0)
//		{
//			transform.GetComponent<Rigidbody>().velocity = Vector3.left * ballVelocity;
//		}
//		if (BallY > 0)
//		{
//			transform.GetComponent<Rigidbody>().velocity = Vector3.forward * ballVelocity;
//		}
//		if (BallY < 0)
//		{
//			transform.GetComponent<Rigidbody>().velocity = Vector3.back * ballVelocity;
//		}
			// 水平移动
			if (Input.GetAxisRaw("Horizontal") != 0)
			{
				transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed);
			}

			//前后移动
			if (Input.GetAxisRaw("Vertical") != 0)
			{
				transform.Translate(Vector3.forward * Input.GetAxisRaw("Vertical") * Time.deltaTime * speed);
			}
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
			
		}
	}
}
