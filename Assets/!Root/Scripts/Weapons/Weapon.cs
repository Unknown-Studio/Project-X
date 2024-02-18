using System;
using UnityEngine;

namespace Suhdo.Weapons
{
	public class Weapon : MonoBehaviour
	{
		private Animator _anim;
		private GameObject _baseGameObject;

		private void Awake()
		{
			_baseGameObject = transform.Find("Base").gameObject;
			_anim = _baseGameObject.GetComponent<Animator>();
		}

		public void Enter()
		{
			print($"{transform.name} enter");
			
			_anim.SetBool("active", true);
		}
	}
}