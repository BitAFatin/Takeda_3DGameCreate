using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

/// <summary>
/// ���C����UI�́u�X�e�[�^�X�v�A�u�ݒ�v�Ȃǂ̃{�^���𐧌䂷��N���X�ł��B
/// �I�����ꂽ�{�^�����Ƃɉ��o����X���C�h��ς���Ȃǂ̖����������Ă��܂��B
/// </summary>
public class ButtonOpen : MonoBehaviour
{
    [SerializeField]
    private List<PlayableDirector> buttonPlayables = new List<PlayableDirector>();

    [SerializeField]
    private List<GameObject> selsectButton = new List<GameObject>();

    [SerializeField]
    private List<GameObject> selsectBackButton = new List<GameObject>();

    [SerializeField]
    private List<ButtonController> buttonConList = new List<ButtonController>();

    [SerializeField]
    private GameObject mainEveSys;

    [SerializeField]
    private GameObject subEveSys;

    [SerializeField]
    private GameManager GM;
    [SerializeField]
    private GameObject FindGM;

    ButtonController buttonController;
    private GameObject findButtonCntr;


    private bool openNow = false;

    private bool cancelOK = false;//UI�R���g���[���[�Ŏg��

    [SerializeField]
    private string selectButtonName;

    public bool OpenNow { get => openNow; set => openNow = value; }
    public bool CancelOK { get => cancelOK; set => cancelOK = value; }
    public string SelectButtonName { get => selectButtonName; set => selectButtonName = value; }

    // Start is called before the first frame update
    void Start()
    {
        //findButtonCntr = GameObject.FindWithTag("SelectButton");

        //buttonController = findButtonCntr.GetComponent<ButtonController>();



        GM = FindGM.GetComponent<GameManager>();
       
      
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonConList[0].EventSystem.currentSelectedGameObject.name != null && buttonConList[0].EventSystem.currentSelectedGameObject.name == "Status")
        {
            selectButtonName = buttonConList[0].EventSystem.currentSelectedGameObject.name;
        }

        if (buttonConList[1].EventSystem.currentSelectedGameObject.name != null && buttonConList[1].EventSystem.currentSelectedGameObject.name == "��")
        {
            selectButtonName = buttonConList[1].EventSystem.currentSelectedGameObject.name;
        }

        if (buttonConList[5].EventSystem.currentSelectedGameObject.name != null && buttonConList[5].EventSystem.currentSelectedGameObject.name == "Setting")
        {
            selectButtonName = buttonConList[5].EventSystem.currentSelectedGameObject.name;
        }

    }

    public void SlideOpen()
    {
       
        GM.Decision_Sound();

        switch (selectButtonName)
        {
            case "Status":

                buttonPlayables[0].Play();
                //buttonConList[0].EventSystem.enabled = false;
             
                mainEveSys.SetActive(false);
               

            break;

            case "Setting":
                buttonPlayables[5].Play();
             
                mainEveSys.SetActive(false);
            break;
        }
    }

    public void SlidePause()//�V�O�i���Ő���
    {  
        openNow = true;

        cancelOK = true;

        switch (selectButtonName)
        {
            case "Status":

            buttonPlayables[0].Pause();
     
            subEveSys.SetActive(true);

            //subEveSys.GetComponent<EventSystem>().firstSelectedGameObject = selsectBackButton[0];

                break;

            case "Setting":

                buttonPlayables[5].Pause();

                subEveSys.SetActive(true);

                //subEveSys.GetComponent<EventSystem>().firstSelectedGameObject = selsectBackButton[1];

            break;
        }

    }

    public void SlideResum()//�{�^��
    {
        GM.Cancel_Sound();

        switch (selectButtonName)
        {
            case "Status":

                //buttonConList[0].EventSystem.enabled = false;
              
                buttonPlayables[0].Resume();

                break;

            case "Setting":

                //buttonConList[0].EventSystem.enabled = false;

                buttonPlayables[5].Resume();

                break;
        }
    }

    public void SlideClose()//�V�O�i���Ő���
    { 
        
        switch (selectButtonName)
        {
            case "Status":

                subEveSys.SetActive(false);
                mainEveSys.SetActive(true);
                mainEveSys.GetComponent<EventSystem>().firstSelectedGameObject = selsectButton[0];

                break;

            case "Setting":

                subEveSys.SetActive(false);
                mainEveSys.SetActive(true);
                mainEveSys.GetComponent<EventSystem>().firstSelectedGameObject = selsectButton[5];

                break;
        }

        openNow = false;
        cancelOK=false;
    }

    
}
