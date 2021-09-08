using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

#if UNITY_IOS

public class NotificationManagerIOS : MonoBehaviour
{
    private string notificationID = "Record_notification";
    private int ID;
    private string RecordTitle, RecordBody;
    [Header("Время до уведомления")] public int recordDelay;

    private void Start()
    {
        if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "English")
        {
            RecordTitle = "Beat your record!";
            RecordBody = "Retails to another galaxy";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Russian")
        {
            RecordTitle = "Побей свой рекорд!";
            RecordBody = "Долети до другой галактики";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Spanish")
        {
            RecordTitle = "¡Vence su registro!";
            RecordBody = "Se vende a otra galaxia";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Portuguese")
        {
            RecordTitle = "Bata seu registro!";
            RecordBody = "Venda para outra galáxia";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Arabic")
        {
            RecordTitle = "تغلب على السجل الخاص بك!";
            RecordBody = "التجزئة إلى مجرة ​​أخرى";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Japanese")
        {
            RecordTitle = "あなたの記録を破った！";
            RecordBody = "他の銀河に小売りします";
        }
        else if (Lean.Localization.LeanLocalization.currentLanguage.ToString() == "Chinese")
        {
            RecordTitle = "击败你的唱片！";
            RecordBody = "零售给另一个星系";
        }

        iOSNotificationTimeIntervalTrigger timeTrigger = new iOSNotificationTimeIntervalTrigger()
        {
            TimeInterval = new TimeSpan(recordDelay, 0, 0),
            Repeats = false
        };

        iOSNotificationCalendarTrigger calendarTrigger = new iOSNotificationCalendarTrigger()
        {
            // Year = xxxx,
            // Month = xx,
            // Day = xx,
               Hour = 12,
               Minute = 0,
            // Second = xx,
               Repeats = true
        };

        iOSNotificationLocationTrigger locationTrigger = new iOSNotificationLocationTrigger()
        {
            Center = new Vector2(2.3f , 49f),
            Radius = 250f,
            NotifyOnEntry = true,
            NotifyOnExit = false
        };

        iOSNotification notification = new iOSNotification()
        {
            Identifier = notificationID,
            Title = RecordTitle,
            Body = RecordBody,
            ShowInForeground = true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = calendarTrigger
        };

        iOSNotificationCenter.ScheduleNotification(notification);

        iOSNotificationCenter.OnRemoteNotificationReceived += recievedNotification =>
        {
            Debug.Log("Recieved notification " + notification.Identifier + "!");
        };

        iOSNotification notificationIntentData = iOSNotificationCenter.GetLastRespondedNotification();
    }

    private void OnApplicationPause(bool pause)
    {
        iOSNotificationCenter.RemoveScheduledNotification(notificationID);

        iOSNotificationCenter.RemoveDeliveredNotification(notificationID);
    }
}

#endif