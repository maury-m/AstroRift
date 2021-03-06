﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	/*
	 * Rotation
	 */	
	public float RotationSensitivityX = 15F;
	public float RotationSensitivityY = 15F;
	public float RotationSensitivityZ = 15F;
	
	/*
	 * Movement
	 */
	public float MovementSensitivityX = 1F;
	public float MovementSensitivityY = 1F;
	public float MovementSensitivityZ = 1F;
	
	private GUIText PositionText = null;
	private GUIText RotationText = null;
	
	void OnEnable()
	{
		GameObject HUD = GameObject.FindGameObjectWithTag("HUD");
		
		if (HUD != null)
		{
			Transform trans = HUD.transform.FindChild("Position");
			PositionText = trans.GetComponent<GUIText>();
			
			trans = HUD.transform.FindChild("Rotation");
			RotationText = trans.GetComponent<GUIText>();
		}
	}
	
	void Update()
	{
		UpdateRotation();
		UpdateMovement();
		UpdateHUD();
	}
	
	void UpdateRotation()
	{
		Quaternion rotX = Quaternion.AngleAxis(Input.GetAxis("LookX") * RotationSensitivityX * Time.deltaTime, Vector3.up);
		Quaternion rotY = Quaternion.AngleAxis(Input.GetAxis("LookY") * RotationSensitivityY * Time.deltaTime, Vector3.left);
		Quaternion rotZ = Quaternion.AngleAxis(-1.0f * Input.GetAxis("LookRoll") * RotationSensitivityZ * Time.deltaTime, Vector3.forward);
		
		transform.localRotation = transform.localRotation * rotX * rotY * rotZ;
	}
	
	void UpdateMovement()
	{
		transform.Translate(
			new Vector3(
				Input.GetAxis("MoveX") * MovementSensitivityX * Time.deltaTime, 
				Input.GetAxis("MoveZ") * MovementSensitivityZ * Time.deltaTime, 
				Input.GetAxis("MoveY") * MovementSensitivityY * Time.deltaTime), 
			Space.Self);
	}
	
	void UpdateHUD()
	{
		if (PositionText != null)
		{
			PositionText.text = string.Format("Position: {0:F}, {1:F}, {2:F}", transform.position.x, transform.position.y, transform.position.z);
		}
		if (RotationText != null)
		{
			RotationText.text = string.Format("Rotation: {0:F}, {1:F}, {2:F}", transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z);
		}
	}
}
