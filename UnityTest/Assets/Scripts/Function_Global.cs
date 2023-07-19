using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 래핑할 메서드의 필요 전처리기
using UnityEngine.UI;
// 래핑할 메서드의 필요 전처리기
using UnityEngine.SceneManagement;

public static partial class Function_Global
{
    //래핑할 전처리기를 표시
    [System.Diagnostics.Conditional("DEBUG_MODE")]

    //Log 래핑, define symbol
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
    //Assert 래핑
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }


    //! GameObject 받아서 Text 찾아서 text 필드 값 수정하는 함수, text를 사용하기 위해서는 using UnityEngine.UI 써야함
    public static void SetText(this GameObject target, string text)
    {
        Text textcomponent = target.GetComponent<Text>();
        if (textcomponent == null || textcomponent == default)
        {
            return;
        }

        textcomponent.text = text;
    }


    // ! LoadScene 함수의 래핑
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }


    // ! 현재 씬의 이름을 리턴한다
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }


    // 두 벡터를 더하는 메서드(벡터3와 벡터2를 더하고 싶을때)
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }


    // ! 컴포넌트가 존재하는지 여부를 체크하는 함수
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


    // ! 리스트가 유효한지 여부를 체크하는 함수
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



    // ! 특정 오브젝트의 자식 오브젝트를 서치해서 컴포넌트를 찾아주는 함수
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





    // ! 특정 오브젝트의 자식 오브젝트를 서치해서 찾아주는 함수 !!!
    public static GameObject FindChilObj
        (this GameObject targetObj_, string objName_) 
    {
        GameObject searchResult = default;
        GameObject searchTarget = default;

        // 탐색 타겟 오브젝트의 자식 오브젝트 갯수만큼 순회하는 루프
        for(int i = 0; i < targetObj_.transform.childCount; i++) 
        {
            searchTarget = targetObj_.transform.GetChild(i).gameObject;
            // 내가 찾고 싶은 오브젝트를 찾은 경우
            if (searchTarget.name.Equals(objName_)) 
            {
                searchResult = searchTarget;
                return searchResult;
            }
            //내가 찾고 싶은 오브젝트를 아직 못찾은 경우
            else 
            {
                searchResult = FindChilObj(searchTarget, objName_);

                if(searchResult == null || searchResult == default) { /* Pass */ }
                else { return searchResult; }
            }
        }
        return searchResult;
    }






    // ! 활성화 된 현재 씬의 루트 오브젝트를 찾아주는 함수
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
