﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWeapon : MonoBehaviour
{

	public GameObject bulletPrefab;

	public Transform bulletSpawn;

	public float bulletSpeed = 30;

	public float lifeTime =3;

	public Button fire;




	// Start is called before the first frame update
	void Start()
    {
		fire.onClick.AddListener(Fire);


	}

    // Update is called once per frame
    void Update()
    {
		
		
    }


	private void Fire()
	{

		GameObject bullet = Instantiate(bulletPrefab);

		Physics.IgnoreCollision(bullet.GetComponent<Collider>(),
			bulletSpawn.parent.GetComponent<Collider>());

		bullet.transform.position = bulletSpawn.position;

		Vector3 rotation = bullet.transform.rotation.eulerAngles;

		bullet.transform.rotation = Quaternion.Euler(rotation.x, transform.eulerAngles.y, rotation.z);

		bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);

		StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
	}



	private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
	{
		yield return new WaitForSeconds(delay);

		Destroy(bullet);
	}

}
