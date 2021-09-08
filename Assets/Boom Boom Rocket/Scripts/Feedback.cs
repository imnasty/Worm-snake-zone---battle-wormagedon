using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using TMPro;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine.UI;

public class Feedback : MonoBehaviour
{
    public Text _feedbackText = default;
   
  
    public void GoToStorePage()
    {
        

#if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier);
#elif UNITY_IPHONE
        Application.OpenURL("itms-apps://itunes.apple.com/app/id" + Application.identifier);
#endif
    }

    public void SendFeedback()
    {
        

        MailAddress from = new MailAddress("askerwebreviews@yandex.by");
        MailAddress to = new MailAddress("askerwebreviews@yandex.by");
        MailMessage message = new MailMessage(from, to);

        message.Subject = "Отзыв";

        message.Body = _feedbackText.text + " Пришло с игры:" + Application.productName.ToString();

        SmtpClient client = new SmtpClient("smtp.yandex.by", 587);
        client.Credentials = new NetworkCredential("askerwebreviews@yandex.by", "Gjw-nv5-j8M-RLu");
        client.EnableSsl = true;
        client.Send(message);
    }
    

}
