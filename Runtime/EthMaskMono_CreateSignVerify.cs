using UnityEngine;

public class EthMaskMono_CreateSignVerify : MonoBehaviour, IEthMaskPrivateKeyHolderGet, IEthMaskCreateSignVerify
{ 
    public EthMaskMono_AbstractPrivateKey m_privateKeyHolder;
    public EthMaskCreateSignVerify m_createSignVerify = new EthMaskCreateSignVerify();

    public void CreatePrivateKey(out string privateKey)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).CreatePrivateKey(out privateKey);
    }

    public void CreatePrivateKey(out IEthMaskPrivateKeyHolderGet privateKeyHolder)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).CreatePrivateKey(out privateKeyHolder);
    }

    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).GetClipboardableAsSplitMessage(clipboardableSignedMessage, out messageGivenToSign, out claimedAddress, out signedMessage);
    }

    public string GetPrivateKey()
    {
        if (m_privateKeyHolder == null)
        {
            return "";
        }
        return ((IEthMaskPrivateKeyHolderGet)m_privateKeyHolder).GetPrivateKey();
    }

    public void GetPrivateKey(out string privateKey)
    {
        if (m_privateKeyHolder == null)
        {
            privateKey = "";
            return;
        }
        ((IEthMaskPrivateKeyHolderGet)m_privateKeyHolder).GetPrivateKey(out privateKey);
    }

    public void GetPublicAddress(IEthMaskPrivateKeyHolderGet privateKeyHolder, out string publicAddress)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).GetPublicAddress(privateKeyHolder, out publicAddress);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out claimedAddress, out recoveredAddress);
    }

    public void SignMessageAsClipboardable(IEthMaskPrivateKeyHolderGet privateKeyHolder, string message, out string clipboardableSignedMessage)
    {
        ((IEthMaskCreateSignVerify)m_createSignVerify).SignMessageAsClipboardable(privateKeyHolder, message, out clipboardableSignedMessage);
    }
}
