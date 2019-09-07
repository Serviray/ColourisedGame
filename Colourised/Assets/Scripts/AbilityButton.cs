using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButton : MonoBehaviour
{
	private Button mButton = null;
	private Graphic mGraphic = null;

	public void Fill(string hotkey)
	{
		Text hotkeyText = GetComponentInChildren<Text> ();
		hotkeyText.text = hotkey;

		mButton = GetComponent<Button> ();
		mGraphic = mButton.targetGraphic;
	}
	public void OnClick()//Player player)
	{
		
	}

	public void OnFocus()//Player player)
	{
		mGraphic.CrossFadeColor (mButton.colors.highlightedColor, 0.05f, true, true);
	}

	public void OnLoseFocus()//Player player)
	{
		mGraphic.CrossFadeColor (mButton.colors.normalColor, 0.05f, true, true);
	}
}
