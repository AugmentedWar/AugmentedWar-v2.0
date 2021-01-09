using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletBehaviour : MonoBehaviour
{
	public GameObject enemy1, enemy2;
	public Button tank1, tank2;
	PlayerMovement playerMovement;
	public GameObject firstTank, secondTank;
	public int numOfbullets;
	public Text bulletText;
	public Button fireButton;


	public bool pressed = true;





	private void Awake()
	{
		playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
	}


	private void Start()
	{
		tank1.onClick.AddListener(falseState);
		tank2.onClick.AddListener(trueState);
		fireButton.onClick.AddListener(counterMethod);
		
	}


	public void Update()
	{
		if (numOfbullets > 0)
			bulletText.text = "Number of bullets: " + (numOfbullets - 1);
		else
			bulletText.text = "Number of bullets: 0";

		Debug.Log(numOfbullets);
	}


	 void myInvoke()
	{
		enemy1.GetComponent<ParticleSystem>().Play();
	}

	private void falseState()
	{
	
		pressed = false;
		firstTank.GetComponent<PlayerWeapon>().bulletSpeed = 30;
		secondTank.GetComponent<PlayerWeapon>().bulletSpeed = 0;
		
		

		
	}

	private void trueState()
	{
		pressed = true;
		firstTank.GetComponent<PlayerWeapon>().bulletSpeed = 0;
		secondTank.GetComponent<PlayerWeapon>().bulletSpeed = 30;

	}

	public void counterMethod()
	{
		numOfbullets--;
	}

	public void OnTriggerEnter(Collider other)
	{

		if (playerMovement.counter <= 1)
		{
			
			if (pressed && numOfbullets > 0)
			{
				
				print(other.name);
				GameObject.Destroy(gameObject);
				if (other.name == "BTR - 80")
				{
				
					enemy1.GetComponent<ParticleSystem>().Play();
					playerMovement.counter++;
					
				
				}
				if (other.name == "BTR - 80 (1)")
				{
					
					
					
						enemy2.GetComponent<ParticleSystem>().Play();

						playerMovement.counter++;
					}
				
				
				

				

				



			}
			else if(!pressed && numOfbullets > 0)
			{

				print(other.name);
				GameObject.Destroy(gameObject);
				if (other.name == "BTR - 80")
				{
					enemy1.GetComponent<ParticleSystem>().Play();
					playerMovement.counter++;
				
				
				}
				if (other.name == "BTR - 80 (1)")
				{
					enemy2.GetComponent<ParticleSystem>().Play();
					playerMovement.counter++;
					
				
				}
				

			}

		}
	}


}
