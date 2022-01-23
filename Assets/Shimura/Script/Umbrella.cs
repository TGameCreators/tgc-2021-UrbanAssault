using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DG.Tweening;

public class Umbrella : MonoBehaviour
{
    //必要になったらDOTweenインポートしてください
/*
float timer;
GameObject CollisionDetection;

// Start is called before the first frame update
void Start()
{
    timer = 1;
    CollisionDetection = GameObject.Find("CollisionDetection");
    CollisionDetection.SetActive(false);
}

// Update is called once per frame
void Update()
{
    timer += Time.deltaTime;
    if (Input.GetMouseButtonDown(1)&&timer>=1) StartCoroutine("SlashMove");
    //if (timer >= 0.2f) transform.Rotate(new Vector3(0,0,0));
}



IEnumerator SlashMove()
{
    Debug.Log("Slash");
    CollisionDetection.SetActive(true);
    timer = 0;
    transform.DOLocalRotate(new Vector3(120, 0, 0), 0.2f);
    yield return new WaitForSeconds(0.2f);
    transform.DOLocalRotate(new Vector3(0, 0, 0), 0.2f);
    yield return new WaitForSeconds(0.1f);
    CollisionDetection.SetActive(false);
}
*/
}
