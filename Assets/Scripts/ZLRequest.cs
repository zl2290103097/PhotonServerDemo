using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using LitJson;
using UnityEditor;
using System.Collections.Generic;


public class FamilyInfo {
    public string name;
    public int age;
    public string tellphone;
    public string address;
}

public class FamilyList
{
    public List<FamilyInfo> family_list;
}

public class ZLRequest : MonoBehaviour
{
    
    public FamilyList m_FamilyList = null;
    void Start()
    {
        Debug.Log("开始http网络请求");
        StartCoroutine(Upload());
    }

    IEnumerator Upload()
    {
        WWWForm form = new WWWForm();
        form.AddField("phoneNum", "13057537823");
        form.AddField("pwd", "123456");
        using (UnityWebRequest www = UnityWebRequest.Post("http://192.168.33.59:8080/main/login", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log("网络请求错误"+ www.error);
            }
            else
            {
                if (www.responseCode == 200) {
                    // 
                    string text = www.downloadHandler.text;
                    //string text = "[{'name':'周俊宏','age':22,'tellphone':'13888888888','address':'苏州'}]";
                    Debug.Log("http请求成功"+text);
                    // 
                    byte [] results = www.downloadHandler.data;
                   
                    
                    // 这个例子里family的绝对路径为“Resources/family”
                    //TextAsset s = www.downloadHandler.text as TextAsset; 
 
                    //string tmp = s.text;  
                    m_FamilyList = JsonMapper.ToObject<FamilyList>(text);  
                    Debug.Log("http请求成功" + m_FamilyList.family_list.Count);
                    DisplayFamilyList(m_FamilyList);
                }

                Debug.Log("http请求成功");
            }
        }
    }
    
    private void DisplayFamilyList (FamilyList familyList) {  
        if ( familyList == null )
            return;  
 
        foreach(FamilyInfo info in familyList.family_list ) {  
            Debug.Log("Name:" + info.name + "       Age:" + info.age + "        Tel:" + info.tellphone + "      Addr:" + info.address);  
        }  
    }
}