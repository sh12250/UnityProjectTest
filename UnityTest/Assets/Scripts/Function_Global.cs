using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ������ �޼����� �ʿ� ��ó����
using UnityEngine.UI;
// ������ �޼����� �ʿ� ��ó����
using UnityEngine.SceneManagement;

public static partial class Function_Global
{
    //������ ��ó���⸦ ǥ��
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    //Log ����, define symbol
    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }


    [System.Diagnostics.Conditional("DEBUG_MODE")]
    //LogWarning
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }


    [System.Diagnostics.Conditional("DEBUG_MODE")]
    //Assert ����
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }


    //! GameObject �޾Ƽ� Text ã�Ƽ� text �ʵ� �� �����ϴ� �Լ�, text�� ����ϱ� ���ؼ��� using UnityEngine.UI �����
    public static void SetText(this GameObject target, string text)
    {
        Text textcomponent = target.GetComponent<Text>();
        if (textcomponent == null || textcomponent == default)
        {
            return;
        }

        textcomponent.text = text;
    }


    // ! LoadScene �Լ��� ����
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    // ! ���� ���� �̸��� �����Ѵ�
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }


    // �� ���͸� ���ϴ� �޼���(����3�� ����2�� ���ϰ� ������)
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }


    // ! ������Ʈ�� �����ϴ��� ���θ� üũ�ϴ� �Լ�
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default)
        {
            return false;
        }
        else
        {
            return true;
        }
    }


    // ! ����Ʈ�� ��ȿ���� ���θ� üũ�ϴ� �Լ�
    public static bool IsValid<T>(this List<T> target)
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0;

        if (isInvalid == true)
        {
            return false;
        }
        else
        {
            return true;
        }
    }



    // ! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ������Ʈ�� ã���ִ� �Լ�
    public static T FindChilComponent<T>
        (this GameObject targetObj_, string objName_)
        where T : Component
    {
        T searchResultComponent = default(T);
        GameObject searchResultObj = default(GameObject);

        searchResultObj = targetObj_.FindChilObj(objName_);
        if(searchResultObj != null || searchResultObj != default)
        {
            searchResultComponent = searchResultObj.GetComponent<T>();
        }
        return searchResultComponent; 
    }





    // ! Ư�� ������Ʈ�� �ڽ� ������Ʈ�� ��ġ�ؼ� ã���ִ� �Լ� !!!
    public static GameObject FindChilObj
        (this GameObject targetObj_, string objName_) 
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        // Ž�� Ÿ�� ������Ʈ�� �ڽ� ������Ʈ ������ŭ ��ȸ�ϴ� ����
        for(int i = 0; i < targetObj_.transform.childCount; i++) 
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            // ���� ã�� ���� ������Ʈ�� ã�� ���
            if (searchTarget.name.Equals(objName_)) 
            {
                searchResult = searchTarget;
                return searchResult;
            }
            //���� ã�� ���� ������Ʈ�� ���� ��ã�� ���
            else 
            {
                searchResult = FindChilObj(searchTarget, objName_);

                if(searchResult == null || searchResult == default) { /* Pass */ }
                else { return searchResult; }
            }
        }
        return searchResult;
    }






    // ! Ȱ��ȭ �� ���� ���� ��Ʈ ������Ʈ�� ã���ִ� �Լ�
    public static GameObject GetRootObj(string objName_) 
    {
        Scene activeScene = SceneManager.GetActiveScene();
        GameObject[] rootObjs_ = activeScene.GetRootGameObjects();

        GameObject targetObj_ = default;
        foreach(GameObject rootObj_ in rootObjs_) 
        {
            if (rootObj_.name.Equals(objName_)) 
            {
                targetObj_ = rootObj_;
                return targetObj_;
            }
            else { continue; }
        }
        return targetObj_;
    }
}
