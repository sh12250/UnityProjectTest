using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDrag : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private Canvas UICanvas = default;
    private RectTransform itemRect = default;

    private GameObject sdPlayer = default;

    private bool isDragging = false;




    //////////////////////////////////////////////////////////
    // delegate�� ����
    private delegate void MyLogFunction(object message);



    private System.Action<object, int, int> myAction;
    // System.Action�� delegate�� �ٸ� ����, object, int, int �� ���� �Ű������� �ް� ��ȯ���� void�̴�.
    // <> �ȿ� ���� �ڷ����� ���ָ� �ȴ�. ������ <>�� ����� �ȴ�.
    private delegate void MyAction001(object message, int number1, int number2);



    private System.Func<float, float, int, int, string> myFunc;
    // System.Func�� �� ���� �ڷ����� ��ȯ(return)�ϰ� ������ �ڷ����� �Ű������� �޴´�.
    // float float int int �� 4���� �Ű������� �޾Ƽ� string���� ��������.
    // delegate�� ��Ÿ���� ������ ����
    private delegate string MyAction002(float f1, float f2, int i1, int i2);

    //////////////////////////////////////////////////////////







    private void Awake()
    {
        // ĵ������ private���� �ٲٰ� Func_G �� GetRootObj �޼��带 �̿��Ͽ� ��Ʈ������Ʈ(ĵ����)�� ã��
        UICanvas = Function_Global.GetRootObj("UICanvas").GetComponent<Canvas>();
        
        itemRect = GetComponent<RectTransform>();

#region ������Ʈ �ȿ� ������Ʈ ã��
        //Debug.LogFormat("����� ã�ƿ���? {0}",
        //    UICanvas.gameObject.FindChilObj("ForeImg").name);

        //sdPlayer = Function_Global.GetRootObj("Set Costume_02 SD Unity-Chan WGS");
        //GameObject sdPlayerLeftEye = sdPlayer.FindChilObj("Eye_L");
        //Debug.LogFormat("player is null {0}, Left Eye is null : {1}",
        //sdPlayer == null, sdPlayerLeftEye == null);
#endregion


        isDragging = false;

        ///////////////////////////////////////////////////
        // delegate
        //MyLogFunction myLogFunction = Debug.Log;
        //myLogFunction("�������� �� Log �Լ��� ���̴ϴ�");
        ///////////////////////////////////////////////////




        //////////////////////////////////////////////////
        int number = 100;

        // �����Լ�
        MyLogFunction myLogFunction = (object obj_) =>
        {
            Debug.Log("�� �αװ� �� �������� �׽�Ʈ");
            Debug.Log("�Ѱܹ��� �޽����� : ");
            Debug.Log(obj_);

            Debug.LogFormat("���⼭ number ���� �ҷ� �� �� ������? {0}", number);
        };
        //////////////////////////////////////////////////
    }





    // Start is called before the first frame update
    void Start()
    {
        // ���� �����ǰ� ��Ŀ�� �������� �ٸ���
        itemRect.anchoredPosition += new Vector2(100f, 0f);
        // itemRect.localPosition += new Vector3(100f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    // OnPointer ���� �޼������ �׻� �ۺ����� �����ؾ���
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log("Ŭ���ϴ� �ٷ� �� ����");
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (isDragging) 
        {
            // ��Ŀ�� �����ǿ� ��ȭ���� ���Ͽ� �����̴� ��
            // Legacy
            // itemRect.anchoredPosition += eventData.delta;

            // Update -> UI Canvas�� ������ ���ͷ� ��ȭ���� ������ �巡�׿� ������ ������
            itemRect.anchoredPosition += (eventData.delta / UICanvas.scaleFactor);
            Debug.LogFormat("�巡�� �� �غ� �Ϸ� -> {0}", eventData.delta); // ���콺 ��ȭ�� ����
        }
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isDragging = false;
        Debug.Log("���� �ٷ� �� ����");
    }


    //public void OnPointerClick(PointerEventData eventData) 
    //{
    //    Debug.Log("�̰� �Լ� ���� �� ���ε� ������ Ŭ���� �Ǵ°�?");
    //}
}
