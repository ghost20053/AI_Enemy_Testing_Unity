using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingPlace : MonoBehaviour
{
    public GameObject hideText, stopHideText, hidingCam;
    public GameObject normalPlayer, hidingPlayer;
    public EnemyAI monsterScript;
    public Transform monsterTransform;
    bool interactable, hiding;
    public float loseDistance;

    private void Start()
    {
        interactable = false;
        hiding = false;
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            hideText.SetActive(true);
            interactable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            hideText.SetActive(false);
            interactable = false;
        }
    }

    private void Update()
    {
        if (interactable == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                hideText.SetActive(false);
                hidingPlayer.SetActive(true);
                float distance = Vector3.Distance(monsterTransform.position, normalPlayer.transform.position);
                if (distance > loseDistance)
                {
                    if (monsterScript.chasing == true)
                    {
                        monsterScript.stopChase();
                    }
                }
                hidingCam.SetActive(true);
                stopHideText.SetActive(true);
                hiding = true;
                normalPlayer.SetActive(false);
                interactable = false;
            }
        }
        if(hiding == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                hidingCam.SetActive(false);
                stopHideText.SetActive(false);
                normalPlayer.SetActive(true);
                hidingPlayer.SetActive(false);
            }
                
        }
    }
}
