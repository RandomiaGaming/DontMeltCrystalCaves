﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoalGateScript : MonoBehaviour {


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" )
        {
            /*collision.gameObject.GetComponent<GameSaver>().Delete();
            SceneManager.LoadSceneAsync("YouWin");*/
        }
    }
}
