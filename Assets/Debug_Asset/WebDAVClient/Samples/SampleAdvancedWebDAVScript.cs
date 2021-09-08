using System.Net;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class SampleAdvancedWebDAVScript : MonoBehaviour
{
    
    // Create a field of type Client, and assign it in the Editor
    public WebDAVClient.Client webDAVClient;

    public Button downloadButtonTemplate;
    public RawImage downloadImageTemplate;

    void Start()
    {
        downloadButtonTemplate.gameObject.SetActive(false);
        downloadImageTemplate.gameObject.SetActive(false);
        // Optionally add support for Certificates validation
        ServicePointManager.ServerCertificateValidationCallback = WebDAVClient.Helpers.CertificatesValidation.ServerCertificateValidation;
        var res = webDAVClient.List("/Samples/");
        foreach (WebDAVClient.Model.Item item in res)
        {
            GameObject newButton = Instantiate(downloadButtonTemplate.gameObject, downloadButtonTemplate.transform.parent);
            newButton.SetActive(true);

            Text btnTxt = newButton.GetComponentInChildren<Text>();
            btnTxt.text = item.DisplayName;

            Button Btn = newButton.GetComponent<Button>();
            Btn.onClick.AddListener(delegate { 
                LoadImage(item.Href);
            });
        }
    }

    public async void LoadImage(string href)
    {
        var downloadAsbyteArray = await DownloadToImage(href);


        
        
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(downloadAsbyteArray);

        GameObject newImage = Instantiate(downloadImageTemplate.gameObject, downloadImageTemplate.transform.parent);
        var image = newImage.GetComponent<RawImage>();
        image.texture = tex;
        image.gameObject.SetActive(true);
    }
    

    public async Task<byte[]> DownloadToImage(string remotePath)
    {
        byte[] downloadAsbyteArray;

        using (Stream input = await webDAVClient.DownloadAsync(remotePath).ConfigureAwait(false))
        {
            using (MemoryStream ms = new MemoryStream())
            {
                await input.CopyToAsync(ms).ConfigureAwait(false);
                downloadAsbyteArray = ms.ToArray();
            }
        }

        return downloadAsbyteArray;
    }
}
