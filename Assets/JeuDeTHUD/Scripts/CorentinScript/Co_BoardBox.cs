﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Co_BoardBox : MonoBehaviour {

    public Vector2 coordinate;
    public Material normalMaterial;
    public Material movementMaterial;
    public Material hoverMovementMaterial;
    public bool isMarkedForMovement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LookForDwarfMovement(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 2))
        {
            if (hit.transform.gameObject.GetComponent<Co_BoardBox>())
            {
                if (hit.transform.gameObject.transform.childCount == 0)
                {
                    hit.transform.gameObject.GetComponent<Renderer>().material = movementMaterial;
                    hit.transform.gameObject.GetComponent<Co_BoardBox>().isMarkedForMovement = true;
                    hit.transform.gameObject.GetComponent<Co_BoardBox>().LookForDwarfMovement(direction);
                }
            }
        }
    }

    public void LookForTrollMovement(Vector3 direction)
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, direction, out hit, 2))
        {
            if (hit.transform.gameObject.GetComponent<Co_BoardBox>())
            {
                if (hit.transform.gameObject.transform.childCount == 0)
                {
                    hit.transform.gameObject.GetComponent<Renderer>().material = movementMaterial;
                    hit.transform.gameObject.GetComponent<Co_BoardBox>().isMarkedForMovement = true;
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        if (isMarkedForMovement)
        {
            this.GetComponent<Renderer>().material = hoverMovementMaterial;
        }
    }

    private void OnMouseExit()
    {
        if (isMarkedForMovement)
        {
            this.GetComponent<Renderer>().material = movementMaterial;
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            if (isMarkedForMovement)
            {
                //Mouvement pion
                this.GetComponentInParent<Co_GameBoard>().GetSelectedPawn().GetComponent<Co_Pawn>().MoveTo(this.gameObject);
                //On remet l'apparence du plateau de départ
                this.GetComponentInParent<Co_GameBoard>().ResetGameBoardBoxesAspect();
                //Désélectionne le pion
                this.GetComponentInParent<Co_GameBoard>().SetSelectedPawn(null);
            }
        }
    }
}
