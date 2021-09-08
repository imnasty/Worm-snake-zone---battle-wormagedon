using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean;
using UnityEngine.UI;

public class LBAccessLocalization : MonoBehaviour
{
    private void Update()
    {
        if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "English")
        {
            this.gameObject.GetComponent<Text>().text = "For access to the Table of Leaders, an Internet connection is necessary.";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Russian")
        {
            this.gameObject.GetComponent<Text>().text = "Для доступа к таблице лидеров необходимо интернет-соединение";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Spanish")
        {
            this.gameObject.GetComponent<Text>().text = "Para acceder a la tabla de líderes, es necesario una conexión a Internet.";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Portuguese")
        {
            this.gameObject.GetComponent<Text>().text = "Para acesso à tabela de líderes, é necessária uma conexão com a Internet.";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Arabic")
        {
            this.gameObject.GetComponent<Text>().text = "للوصول إلى جدول القادة، اتصال بالإنترنت ضروري.";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Japanese")
        {
            this.gameObject.GetComponent<Text>().text = "リーダーのテーブルへのアクセスのためには、インターネット接続が必要です。";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Chinese")
        {
            this.gameObject.GetComponent<Text>().text = "为了访问领导者，需要互联网连接。";
        }
    }
}
