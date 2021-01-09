using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

	public GameObject firstTank, secondTank;
	BulletBehaviour bulletBehaviour;
	NavMeshAgent agent1, agent2;
	public Button fireButton;
	public int counter;
	public int numOfmovements = 2;
	public Text movementText;

	private void Awake()
	{
		bulletBehaviour = GameObject.FindObjectOfType<BulletBehaviour>();
	}

	// Start is called before the first frame update
	void Start()
    {
		agent1 = firstTank.GetComponent<NavMeshAgent>();
		agent2 = secondTank.GetComponent<NavMeshAgent>();
	}

    // Update is called once per frame
   public void Update()
    {

		if (counter <= 1)
		{
			//Touch touch = Input.GetTouch(0);
			//touch.phase == TouchPhase.Began
			if (Input.GetMouseButtonDown(0) && bulletBehaviour.pressed == false)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit, Mathf.Infinity) && !EventSystem.current.IsPointerOverGameObject())
				{
					
					agent1.SetDestination(hit.point);
					counter++;
					numOfmovements--;
					movementText.text = "Number of movements: " + numOfmovements.ToString();
					Debug.Log(counter + "Player mow");
				}
			}
			if (Input.GetMouseButtonDown(0) && bulletBehaviour.pressed == true)
			{
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

				if (Physics.Raycast(ray, out hit, Mathf.Infinity) && !EventSystem.current.IsPointerOverGameObject())
				{


					agent2.SetDestination(hit.point);
					counter++;
					numOfmovements--;
					movementText.text = "Number of movements: " +numOfmovements.ToString();
					Debug.Log(counter + "Player mow");
				}
			}
		}

	}
}
