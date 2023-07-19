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
    // delegate의 형태
    private delegate void MyLogFunction(object message);



    private System.Action<object, int, int> myAction;
    // System.Action은 delegate의 다른 형태, object, int, int 세 개를 매개변수로 받고 반환형은 void이다.
    // <> 안에 받을 자료형을 써주면 된다. 없으면 <>를 지우면 된다.
    private delegate void MyAction001(object message, int number1, int number2);



    private System.Func<float, float, int, int, string> myFunc;
    // System.Func는 맨 뒤의 자료형을 반환(return)하고 이전의 자료형을 매개변수로 받는다.
    // float float int int 총 4개의 매개변수를 받아서 string으로 내보낸다.
    // delegate로 나타내면 다음과 같다
    private delegate string MyAction002(float f1, float f2, int i1, int i2);

    //////////////////////////////////////////////////////////







    private void Awake()
    {
        // 캔버스를 private으로 바꾸고 Func_G 의 GetRootObj 메서드를 이용하여 루트오브젝트(캔버스)를 찾기
        UICanvas = Function_Global.GetRootObj("UICanvas").GetComponent<Canvas>();
        
        itemRect = GetComponent<RectTransform>();

#region 오브젝트 안에 컴포넌트 찾기
        //Debug.LogFormat("제대로 찾아오나? {0}",
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
        //myLogFunction("이제부터 이 Log 함수는 제겁니다");
        ///////////////////////////////////////////////////




        //////////////////////////////////////////////////
        int number = 100;

        // 람다함수
        MyLogFunction myLogFunction = (object obj_) =>
        {
            Debug.Log("이 로그가 잘 찍히는지 테스트");
            Debug.Log("넘겨받은 메시지는 : ");
            Debug.Log(obj_);

            Debug.LogFormat("여기서 number 값을 불러 올 수 있을까? {0}", number);
        };
        //////////////////////////////////////////////////
    }





    // Start is called before the first frame update
    void Start()
    {
        // 로컬 포지션과 앵커드 포지션은 다르다
        itemRect.anchoredPosition += new Vector2(100f, 0f);
        // itemRect.localPosition += new Vector3(100f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }






    // OnPointer 관련 메서드들은 항상 퍼블릭으로 구현해야함
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        Debug.Log("클릭하는 바로 그 순간");
    }

    public void OnDrag(PointerEventData eventData) 
    {
        if (isDragging) 
        {
            // 앵커드 포지션에 변화량을 더하여 움직이는 것
            // Legacy
            // itemRect.anchoredPosition += eventData.delta;

            // Update -> UI Canvas의 스케일 팩터로 변화량을 나누면 드래그에 오차가 없어짐
            itemRect.anchoredPosition += (eventData.delta / UICanvas.scaleFactor);
            Debug.LogFormat("드래그 할 준비 완료 -> {0}", eventData.delta); // 마우스 변화량 측정
        }
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
        isDragging = false;
        Debug.Log("떼는 바로 그 순간");
    }


    //public void OnPointerClick(PointerEventData eventData) 
    //{
    //    Debug.Log("이거 함수 만든 것 뿐인데 정말로 클릭이 되는가?");
    //}
}
