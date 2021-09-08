using UnityEngine;
#if UNITY_ANDROID
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
	
	AndroidNotificationChannel defaultChannel;
	private string RecordTitle, RecordBody;
	[Header("Время до уведомления(ч)")] public int recordDelay;

    void Start()
    {
		if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "English")
		{
			RecordTitle = "Beat your record!";
			RecordBody = "Go to the game and show everyone what you are capable";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Russian")
		{
			RecordTitle = "Побей свой рекорд!";
			RecordBody = "Зайди в игру и покажи всем, на что ты способен";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Spanish")
		{
			RecordTitle = "¡Vence su registro!";
			RecordBody = "Ve al juego y muestra a todos lo que eres capaz.";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Portuguese")
		{
			RecordTitle = "Bata seu registro!";
			RecordBody = "Vá para o jogo e mostre a todos o que você é capaz";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Arabic")
		{
			RecordTitle = "تغلب على السجل الخاص بك!";
			RecordBody = "انتقل إلى اللعبة وإظهار الجميع ما أنت قادر";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Japanese")
		{
			RecordTitle = "あなたの記録を破った！";
			RecordBody = "ゲームに行き、あなたができることをみんなに見せる";
		}
		else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Chinese")
		{
			RecordTitle = "击败你的唱片！";
			RecordBody = "去游戏并告诉大家你有能力的东西";
		}


		AndroidNotificationCenter.CancelAllNotifications();

		defaultChannel = new AndroidNotificationChannel()
		{
			Id = "lynx_channel",
			Name = "Lynx Channel",
			Description = "Generic Notification",
			EnableLights = true,
			Importance = Importance.Default
		};

		AndroidNotificationCenter.RegisterNotificationChannel(defaultChannel);

			AndroidNotification notification = new AndroidNotification()
			{
				Title = RecordTitle,
				Text = RecordBody,
				LargeIcon = "app_icon_large",
				FireTime = System.DateTime.Now.AddHours(recordDelay)
			};
			AndroidNotificationCenter.SendNotification(notification, defaultChannel.Id);

		
		
		AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler = delegate (AndroidNotificationIntentData data)
		{
			var msg = "Notification received: " + data.Id + "\n";
			msg += "\n Notification received: ";
			msg += "\n .Title: " + data.Notification.Title;
			msg += "\n .Body: " + data.Notification.Text;
			msg += "\n .Channel: " + data.Channel;
			Debug.Log(msg);
		};

		AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;

		var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

		if (notificationIntentData != null) Debug.Log("App was opened with notifcation!");
	}
    
}
#endif