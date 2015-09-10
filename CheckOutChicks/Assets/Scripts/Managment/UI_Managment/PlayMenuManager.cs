using UnityEngine;
using System.Collections;

public class PlayMenuManager : MonoBehaviour {

    [SerializeField]
    private GameObject testdriveButton;

    [SerializeField]
    private GameObject twoPlayerButton;

    [SerializeField]
    private GameObject threePlayerButton;

    [SerializeField]
    private GameObject fourPlayerButton;

	void Start () 
    {
        GameObject TestDriveButton = Instantiate(testdriveButton) as GameObject;
        //TestDriveButton.
        GameObject TwoPlayerButton = Instantiate(twoPlayerButton) as GameObject;
        GameObject ThreePlayerButton = Instantiate(threePlayerButton) as GameObject;
        GameObject FourPlayerButton = Instantiate(fourPlayerButton) as GameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
