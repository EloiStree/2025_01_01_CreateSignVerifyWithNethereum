using System;
using UnityEngine;

public class EthMaskExMono_CreateSignVerify : MonoBehaviour
{

    public string m_messageToSign = "J'aime les frites";
    public string m_privateKeyGenerated;
    public string m_publicAddressGenerated;
    public string m_signatureAsClipboardMessage;

    public string m_claimedAddress;
    public string m_recoveredAddress;
    public bool m_isVerified;

    [ContextMenu("Test")]
    void Test()
    {

        m_privateKeyGenerated = MetaMaskSignUtility.GeneratePrivateKey();
        MetaMaskSignUtility.GetPublicAddressFromPrivateKey(m_privateKeyGenerated, out m_publicAddressGenerated);
        MetaMaskSignUtility.GenerateClipboardSignMessage(m_privateKeyGenerated, m_messageToSign, out m_signatureAsClipboardMessage);
        MetaMaskSignUtility.IsVerifiedClipboardSignMessage(m_signatureAsClipboardMessage, out m_isVerified, out m_claimedAddress, out m_recoveredAddress);
    }
}
