using System;
using UnityEngine;

public class MetaMaskCoasterConceptMono : MonoBehaviour {


    [Header("Generate")]
    public string m_publicAddressCoaster;
    public EthMaskMono_AbstractPrivateKey m_coasterPrivateKey;
    public string m_guidToSign;
    [TextArea(1,5)]
    public string m_coasterMarqueLetter;
    public string m_coasterReceiptAsCoaster;
    [TextArea(1, 5)]
    public string m_signGuid;


    [Header("Generate")]
    public string m_publicAddressPointedByMarqueLetter;
    public string m_publicAddressPointedBySignedMessage;
    public bool m_isCoasterIsReferencedByMarqueLetter;
    public bool m_isMessageSignedByCoaster;



    [ContextMenu("Generate New Guid")]
    public void GenerateNewGuid()
    {

        m_guidToSign = System.Guid.NewGuid().ToString();
    }
    [ContextMenu("Generate Time id")]
    public void GenerateTimeId()
    {
        //Display time to the tick as human formation
        m_guidToSign = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss_fffff");
    }

    [ContextMenu("Sign In Browser the coaster")]
    public void SignInBrowserTheCoaster() { 

        m_coasterPrivateKey.GetPublicAddress(out m_publicAddressCoaster);
        Application.OpenURL("https://eloistree.github.io/SignMetaMaskTextHere/index.html?q="+ m_publicAddressCoaster);
    }

    [ContextMenu("Generate Signed Message")]
    public void GenerateCoasterSignedMessage() { 
        MetaMaskSignUtility.GenerateClipboardSignMessage(m_coasterPrivateKey.GetPrivateKey(), m_guidToSign, out m_coasterReceiptAsCoaster);
        MetaMaskSignUtility.SplitClipboardMessage(m_coasterReceiptAsCoaster,
            out string messageToSign,
            out string coasterAddress,
            out string signedMessage);
        MetaMaskSignUtility.SplitClipboardMessage(m_coasterMarqueLetter,
            out string shouldBeCoasterAddress, 
            out string masterAddress, 
            out string signedMarqueLetter);
      
        MetaMaskSignCoasterUtility.GenerateClipboardSignCoasterMessage(
            messageToSign,
            coasterAddress, 
            signedMessage,
            masterAddress,
            signedMarqueLetter,
            out m_signGuid);

       }

    [ContextMenu("Verify Signed Message")]
    public void SignOutBrowserTheCoaster()
    {
        string [] parts = m_signGuid.Split('|');
        string messageToSign = parts[0];
        string coasterAddress = parts[1];
        string signedMessage = parts[2];
        string masterAddress = parts[3];
        string marqueLetter = parts[4];

        MetaMaskSignUtility.GetPublicAddressInSignedMessage(messageToSign, signedMessage, out m_publicAddressPointedBySignedMessage);
        MetaMaskSignUtility.GetPublicAddressInSignedMessage(coasterAddress, marqueLetter, out m_publicAddressPointedByMarqueLetter);

        m_isCoasterIsReferencedByMarqueLetter = masterAddress == m_publicAddressPointedByMarqueLetter;
        m_isMessageSignedByCoaster = coasterAddress ==m_publicAddressPointedBySignedMessage  ;
    }
}