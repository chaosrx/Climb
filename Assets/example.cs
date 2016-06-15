using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

public class example : MonoBehaviour {

	public Text _text;

	// Use this for initialization
	void Start () {
		DOTween.Play ("fade1");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
