using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class UIActionManager : JumperBehavior
{
    public Text rig;
    public Text tracking;

    public GameObject titleWindow;

    public GameObject mainWindow;

    public GameObject stageSelectWindow;

    public GameObject playWindow;

    public GameObject gameOverWindow;

	public Material BlackSkybox;

//	public List<GameObject> MapImage = new List<GameObject>();

	public List<Material> Skybox = new List<Material>();

	public Camera camera = new Camera();

	public float Scale_Setting_Speed = 0.7f;

	public bool ImageEnter;

	public GameObject[] Image;

	int index;






		





    protected override void Awake()
    {
        base.Awake();
        game.SetUI(this);
    }
	void Start()
	{
		
	}
	void Update()
	{
		if (ImageEnter) 
			Scale_Up ();
		
		else
			Scale_Down();
	}
    public void ActiveTitleWindow()
    {

    }
    public void ActiveMainWindow()
    {

    }
    public void ActiveStageSelectWindow()
    {
		mainWindow.SetActive (false);
		stageSelectWindow.SetActive (true);

    }
    public void ActivePlayWindow()
    {

    }
    public void ActiveGameOverWindow()
    {
		
    }

    public void OnTitleClick()
    {

    }

//	public void OnStageSelectEnter()
//	{   
//		
//		Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward,Color.red);
//		Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
//		RaycastHit Hitobj;
//
//		if (Physics.Raycast(ray, out Hitobj, Mathf.Infinity))
//		{ 
////			if (lastImage != Hitobj.transform.gameObject) {
////				lastImage = ThisImage;
////			}
//			if (Hitobj.transform.name.Contains ("Image1")) {
//				Debug.Log ("이미지1");
//				ThisImage = Hitobj.transform.gameObject;
//                ImageEnter = true;
//				Invoke ("SkyboxChage(0)", 2);
//		
//               }
//			} if (Hitobj.transform.name.Contains ("Image2")) {
//			Debug.Log ("이미지2");
//			if (Hitobj.transform.name.Contains ("Image2")) {
//				ThisImage = Hitobj.transform.gameObject;
//                ImageEnter = true;
//				Invoke ("SkyboxChage(1)", 2);
//
//			}
//			} if (Hitobj.transform.name.Contains ("Image3")) {
//			    Debug.Log ("이미지3");
//				ThisImage = Hitobj.transform.gameObject;
//                ImageEnter = true;
//			    Invoke ("SkyboxChage(2)", 2);
//
//
//			}
//		}

	public void Image_Enter(int Number)
	{
		index = Number;
		ImageEnter = true;

	}
		
			
	void SkyboxChange(int index)
	{
		RenderSettings.skybox = Skybox [index];
	}
		


	public void Scale_Up()
	{
		
		if (Image[index].transform.localScale.x <= 1.5f&& ImageEnter == true) {

			Image[index].transform.localScale += Vector3.one * 1f * Time.deltaTime;
			if (Image[index].transform.localScale.x >=1.5f)
			RenderSettings.skybox = Skybox [index];


		}
		
	}
	public void OnStageSelectExit()
	{
		ImageEnter = false;

    }
	public void Scale_Down()
	{
		if (Image[index].transform.localScale.x >= 1.1f && !ImageEnter) {
			Image[index].transform.localScale -= Vector3.one * 1.5f * Time.deltaTime;
			RenderSettings.skybox = BlackSkybox;
		}

		
	}
	public void OnStageSelectClick(int Number)
    {
		

    }
    public void OnTestMapClick()
    {

    }
}
