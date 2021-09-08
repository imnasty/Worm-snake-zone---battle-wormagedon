using UnityEngine;
using Lean;
using UnityEngine.UI;

public class ShowAllPlayersLocaliz : MonoBehaviour
{
    private void OnEnable()
    {
		if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "English")
		{
			gameObject.GetComponentInChildren<Text>().text = "Show Top 100";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Russian")
		{
			gameObject.GetComponentInChildren<Text>().text = "Показать топ 100";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Spanish")
		{
			gameObject.GetComponentInChildren<Text>().text = "Mostrar 100 top 100";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Portuguese")
		{
			gameObject.GetComponentInChildren<Text>().text = "Mostrar top 100";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Arabic")
		{
			gameObject.GetComponentInChildren<Text>().text = "إظهار أعلى 100";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Japanese")
		{
			gameObject.GetComponentInChildren<Text>().text = "トップ100を表示します";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Chinese")
		{
			gameObject.GetComponentInChildren<Text>().text = "显示前100名";
		}
	}
}
