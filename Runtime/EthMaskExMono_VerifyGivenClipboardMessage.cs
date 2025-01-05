using System;
using UnityEngine;

public class EthMaskExMono_VerifyGivenClipboardMessage : MonoBehaviour
{
    
    public string m_messageToVerify = "";
    public string m_messageGivenToSign;
    public string m_signedMessage;
    public string m_claimedAddress;
    public string m_recoveredAddress;
    public bool m_isVerified;

    [ContextMenu("Verify The Message")]
    void VerifyTheMessage()
    {
        EthMaskSignUtility.SplitClipboardMessage(m_messageToVerify, out m_messageGivenToSign, out m_claimedAddress, out m_signedMessage);
        EthMaskSignUtility.IsVerifiedClipboardSignMessage(m_messageToVerify, out m_isVerified, out m_claimedAddress, out m_recoveredAddress);
    }

    [ContextMenu("Get Message to Sign")]
    void GetMessageToSign()
    {
        EthMaskSignUtility.OpenPageToSignMessage(DateTime.Now.ToString());
    }
}
