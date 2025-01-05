using UnityEngine;

public class EthMaskMono_TextAsPrivateKey : EthMaskMono_AbstractPrivateKey
{
    [TextArea(0,10)]
    public string m_textToGeneratePrivateKey;
    public string m_publicAddress;
    private string m_textToGeneratePrivateKeyPrevious;

    public bool m_useDeviceId;
    private bool m_useDeviceIdPrevious;

    private string m_deviceId;
    private void Awake()
    {
        
        m_deviceId = SystemInfo.deviceUniqueIdentifier;
    }

    private void OnValidate()
    {
        m_deviceId = SystemInfo.deviceUniqueIdentifier;
        if (m_textToGeneratePrivateKeyPrevious != m_textToGeneratePrivateKey || m_useDeviceId != m_useDeviceIdPrevious)
        {
            m_textToGeneratePrivateKeyPrevious = m_textToGeneratePrivateKey;
            m_useDeviceIdPrevious = m_useDeviceId;

            GetPrivateKey(out string privateKey);
            MetaMaskSignUtility.GetPublicAddressFromPrivateKey(privateKey, out m_publicAddress);
        }
        

    }

    [ContextMenu("Display Private In Console")]
    public void DisplayPrivateInConsole()
    {
        Debug.Log(GetPrivateKey());
    }

    [ContextMenu("Display Device Id In Console")]
    public void DisplayDeviceUniqueId() { 
    
        Debug.Log(SystemInfo.deviceUniqueIdentifier);
    }
    public override string GetPrivateKey()
    {
        string t = m_textToGeneratePrivateKey;
        t = t.Replace("\n", "");
        t = t.Replace("\r", "");
        t= t.Trim();

        if (m_useDeviceId)
        {
            t += m_deviceId;
        }

        byte [] bytes = System.Text.Encoding.UTF8.GetBytes(t);
        MetaMaskSignUtility.GeneratePrivateKeyFromBytes(bytes, out string privateKey);
        return privateKey;
    }
}
