using UnityEngine;

using System.Collections;

public class CreateBall : MonoBehaviour
{

	Ray ray;
	RaycastHit hit;
	System.Random r;

	public GameObject prefab;

    public int noBallToCreate;

	// Use this for initialization
	void Start ()
	{
        r = new System.Random();
	}

	// Update is called once per frame
	void Update ()
	{
		//Debug.Log ("CreateBall.Update");
		ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray, out hit)) {

			if (Input.GetKey (KeyCode.Mouse0)) {
				
				Vector3 spawnPoint = new Vector3 (1, 6, 0);
				var hitColliders = Physics.OverlapSphere(spawnPoint, 2);//2 is purely chosen arbitrarly
                                                                        //Debug.Log ("hitColliders:"+hitColliders+" l:"+hitColliders.Length);
                if (hitColliders.Length <= 0) //You have someone with a collider here
                {
                    createBall(noBallToCreate);
                    
                }

			}

		}
	}

    void createBall(int count)
    {
        for (int i = 1; i <= count; i++)
        {
            createBall();
        }
    }

	void createBall()
	{
		//Debug.Log ("CreateBall.here 0");
		GameObject obj = Instantiate (prefab, new Vector3 (1, 6, 0), Quaternion.identity) as GameObject;

		//Debug.Log ("CreateBall.here 1");
		Renderer renderer = obj.GetComponentInChildren<Renderer>();
		//Debug.Log ("Renderer: " + renderer);

		int choice = r.Next (1, 5);
		string materialName = "BallDefault";
		if (choice == 1) {
			materialName = "BallBlue";
		} else if (choice == 2) {
			materialName = "BallGreen";
		} else if (choice == 3) {
			materialName = "BallRed";
		} else if (choice == 4) {
			materialName = "BallYellow";
		}

		//Debug.Log ("materialName: " + materialName);
		Material newColour = Resources.Load ("Materials/"+materialName, typeof(Material)) as Material;
		var mats = renderer.materials;
		//Debug.Log ("renderer.materials: " + renderer.materials + " l:"+renderer.materials.Length);
		//Debug.Log ("newColour: " + newColour);
		mats[0] = newColour;
		renderer.materials = mats;

		BallCounter.add ();

		//Debug.Log ("material: " + renderer.material);
	}
}