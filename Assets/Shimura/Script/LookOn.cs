using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookOn : MonoBehaviour
{
    [SerializeField, Tooltip("���C���̃J�������Z�b�g\nRay�̊J�n�n�_")]
    Camera camera;//Ray�̊J�n�n�_�i�J�����͐퓬�@��Ǐ]���Ă���j
    [SerializeField, Tooltip("player��ݒ�")]
    GameObject Player;
    [SerializeField, Tooltip("Canvas��RectTransform")]
    RectTransform CanvasRect;
    [SerializeField, Tooltip("�Ə���RectTransform")]
    RectTransform RT;
    [SerializeField,Tooltip("�W�����̉摜:[0]\n���b�N�I�����̉摜:[1]")]
    Sprite[] Sprite;
    Image UsingImage;
    [SerializeField,Tooltip("�����Ɗi�[����Ă��邩�m�F�p" +
        "\nRay���������Ă���I�u�W�F�N�g���i�[����Ă����OK" +
        "\nRay���������Ă��Ȃ��Ƃ���null�ɂȂ�")]
    GameObject TargetPos;
    float Distance;//�v���C���[�ƓG�i�^�[�Q�b�g���j�Ƃ̋���
    Vector3 TargetPoint;//�Ə��̈ʒu
    RaycastHit hit;

    void Start()
    {
        RT = this.GetComponent<RectTransform>();
        UsingImage = this.GetComponent<Image>();
        UsingImage.sprite = Sprite[0];
    }

    void Update()
    {
        if (TargetPos != null)
        {
            Distance = Vector3.Distance( TargetPos.transform.position,Player.transform.position);
            //TargetPoint = Camera.main.WorldToScreenPoint(TargetPos.transform.position);
            //RT.position = TargetPoint;
            Vector2 pos;
            Vector2 ScreenPos=RectTransformUtility.WorldToScreenPoint(camera, TargetPos.transform.position);
            RectTransformUtility.ScreenPointToLocalPointInRectangle(CanvasRect, ScreenPos, camera, out pos);
            RT.position = pos;
        }
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(Player.transform.position, Vector3.forward, Color.blue);
        if (Physics.BoxCast(Player.transform.position, new Vector3(40f, 20f, 1f),
            Vector3.forward, out hit, Quaternion.identity, 100f, LayerMask.GetMask("Enemy")))
        {
            //Ray���q�b�g�����Ƃ��̏���
            if (hit.collider.CompareTag("Enemy"))
            {
                LockonStart();
            }
            else
            {
                LockonEnd();
            }
        }
        else
        {
            LockonEnd();
        }
    }

        //Ray�œG��⑫������Ăяo��
        public void LockonStart()
    {
        Debug.Log("hit");
        TargetPos = hit.collider.gameObject;
        Debug.Log("Target:"+TargetPos);
        UsingImage.sprite = Sprite[1];
    }

    //Ray�œG������������Ăяo��
    public void LockonEnd()
    {
        Debug.Log("no hit");
        TargetPos = null;
        RT.localPosition=new Vector3(0f,0f,0f);
        UsingImage.sprite = Sprite[0];
    }

    void OnDrawGizmos()
    {
        //�@Cube�̃��C���^���I�Ɏ��o��
        Gizmos.color = Color.green;
        //Gizmos.DrawWireCube(Player.transform.position + transform.forward * Distance, new Vector3(40f, 20f, 1f));
        Gizmos.DrawWireCube(hit.point, new Vector3(40f, 20f, 1f));
    }





    /*
    [SerializeField,Tooltip("���C���̃J�������Z�b�g\nRay�̊J�n�n�_")]
    Camera camera;//Ray�̊J�n�n�_�i�J�����͐퓬�@��Ǐ]���Ă���j
    [SerializeField, Tooltip("���b�N�I�����Ƀ^�[�Q�b�gUI��ύX")]
    Sprite[] Sprite;
    Image Image;
    [SerializeField, Tooltip("�Ə���UI��ݒ�")]
    GameObject AimUI;
    [SerializeField, Tooltip("player��ݒ�")]
    GameObject Player;

    void Start()
    {
        Image =AimUI.GetComponent<Image>();
        Debug.Log(Sprite);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
        RaycastHit hit;
        Debug.DrawRay(Player.transform.position, Vector3.forward, Color.blue);
        if(Physics.Raycast(Player.transform.position, Vector3.forward,out hit))
        {
            //Ray���q�b�g�����Ƃ��̏���
            if (hit.collider.CompareTag("Enemy"))
            {
                Image.sprite = Sprite[1];//UI�̐F��ς���
                Debug.Log("hit");
                //UI��Enemy�̈ʒu�Ɏ����Ă���
            }
            else
            {
                Image.sprite = Sprite[0];//�W���̐F
                Debug.Log("no hit");
            }
            
        }
    }
    */

}
