using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening;

public enum StageType
{
	City = 0,
	Forest,
	Desert,
}

public class UIActionManager : JumperBehavior
{
	public struct StageData
	{
		public GameObject gameObj;
		public Vector3 target;
		public float moveDuration;
		public Material skybox;

		public StageData(GameObject gameObj , Vector3 target , float moveDuration , Material skybox)
		{
			this.gameObj = gameObj;
			this.target = target;
			this.moveDuration = moveDuration;
			this.skybox = skybox;
		}
	}

    public Text rig;
    public Text tracking;

    public GameObject titleWindow;

    public GameObject mainWindow;

    public GameObject stageSelectWindow;

    public GameObject playWindow;

    public GameObject gameOverWindow;

	public Material BlackSkybox;

	public GameObject[]  modeling;

//	public List<GameObject> MapImage = new List<GameObject>();

	private Dictionary<StageType , StageData> stages = new Dictionary<StageType, StageData> ();

	public Camera camera = new Camera();

	public float Scale_Setting_Speed = 0.7f;

	public bool ImageEnter;

	public Material[] skyboxes;
	public GameObject[] Image;

	private StageType nowSelectedType;

	private StageType lastSelectedType;

	public Button startButton;

	int SkyboxNumber;

	public bool Imready=false;

	public GameObject[] gameEnterButton;

	bool ImageClick=false;
	bool selectImageFreeze = false;
	int typecount=0;
	bool skyBoxFreeze = false;






    protected override void Awake()
    {
        base.Awake();
        game.SetUI(this);
    }
	void Start()
	{
		
		stages.Add (StageType.City, new StageData (Image [0] , Vector3.right * 100.0f , 1.0f , skyboxes[0]));
		stages.Add (StageType.Forest, new StageData (Image [1], Vector3.zero, 1.0f , skyboxes[1]));
		stages.Add (StageType.Desert, new StageData (Image [2], Vector3.right * 1000.0f, 1.0f , skyboxes[2]));

		DOTween.Play ("TI");
		DOTween.Play ("SI");
		DOTween.Play ("STI");
		DOTween.Play ("TTI");

	}
	public void  SelectWindowReadyChange()
	{
		Imready = !Imready;
	}
	void Update()
	{
		if (ImageEnter) 
			Scale_Up ();
		
		else
			Scale_Down();

		if (selectImageFreeze) {
			SelectImageFreeze ();
		}
		if (skyBoxFreeze) {
			SkyboxFreeze ();
		}



//		if (nowSelectedType !== nowSelectedType) {
//			nowSelectedType = lastSelectedType;
//		}
	}
    public void ActiveTitleWindow()
    {

    }
    public void ActiveMainWindow()
    {

    }
    public void ActiveStageSelectWindow()
    {
		
//		GameObject titleName = titleWindow.transform.FindChild ("TitleName").gameObject;
//		GameObject startButton = titleWindow.transform.FindChild ("StartButton").gameObject;
		DOTween.Play("TO");
		DOTween.Play ("STO");
		DOTween.Play("SO");
		DOTween.Play ("TTO");
		DOTween.Play ("SM");








//		titleName.SetActive (false);

		stageSelectWindow.SetActive (true);

    }
	public void TitleSetfalse()
	{
		titleWindow.SetActive (false);
	}
	public void Buttontrue()
	{
		startButton.interactable = true;
	}
	public void StageSetfalse()
	{
		titleWindow.SetActive (false);
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




	public void Image_Enter(int typeCount)
	{
		nowSelectedType = (StageType)typeCount;
		ImageEnter = true;
//		Move (nowSelectedType);
	}

	private void Move(StageType type)
	{
		stages [type].gameObj.transform.DOMove (stages [type].target, stages [type].moveDuration);
	}
			
	void SkyboxChange(StageType type)
	{
		RenderSettings.skybox = stages [type].skybox;
	}

	public void ModelingSetTrue(int index)
	{
		modeling [index].SetActive (true);
	}
		


	public void Scale_Up()
	{
		
		if (stages[nowSelectedType].gameObj.transform.localScale.x <= 1.5f&& ImageEnter == true) {

			stages[nowSelectedType].gameObj.transform.localScale += Vector3.one * 1f * Time.deltaTime;
			if (stages [nowSelectedType].gameObj.transform.localScale.x >= 1.5f && Imready)
			SkyboxChange (nowSelectedType);
		}
		
	}
	public void Image_Move()
	{
//		stages [nowSelectedType].gameObj.transform.localPosition -= new Vector3 (-820, 0, 0) * Time.deltaTime;

	}
	public void OnStageSelectExit()
	{
		ImageEnter = false;

    }
	public void Scale_Down()
	{
		if (stages[nowSelectedType].gameObj.transform.localScale.x >= 1.1f && !ImageEnter) {
			stages [nowSelectedType].gameObj.transform.DOScale (1.0f, 0.7f);
			RenderSettings.skybox = BlackSkybox;
		}

		
	}


	public void OnStageSelectClick(int typeCount)
	{
		nowSelectedType = (StageType)typeCount;
		typeCount = typecount;
		ImageClick = true;
		selectImageFreeze = true;
		skyBoxFreeze = true;

		if (ImageClick) {
			for (int i = 0; i <stages.Count; i++) {
				stages [(StageType)i].gameObj.SetActive (false);
				DOTween.Play ("Image1Move");

			}
			stages [nowSelectedType].gameObj.SetActive (true);


		}
	}
	public void ModelingAppear()
	{
		modeling [typecount].SetActive (true);
	}
	public void GameEnterButtonAppear()
	{
		gameEnterButton [typecount].SetActive (true);
		
	}
	public void SkyboxFreeze()
	{
		SkyboxChange (nowSelectedType);
	}
	public void SelectImageFreeze()
	{
		stages [nowSelectedType].gameObj.transform.localScale = new Vector3 (1.5f,1.5f,1.5f);
	}
	public void ImageClickReady()
	{
		ImageClick = !ImageClick;
	}
    public void OnTestMapClick()
    {

    }
}
