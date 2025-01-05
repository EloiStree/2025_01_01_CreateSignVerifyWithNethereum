using UnityEngine;

public class EthMaskMono_PrivateKeySign: EthMaskMono_AbstractClipboardSigner
{
    public EthMaskMono_AbstractPrivateKey m_privateKeyHolder;
    public override void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage)
    {
        if (m_privateKeyHolder == null)
        {
            clipboardableSignedMessage = "";
            return;
        }
        string privateKey = ((IEthMaskPrivateKeyHolderGet)m_privateKeyHolder).GetPrivateKey();
        MetaMaskSignUtility.GenerateClipboardSignMessage(privateKey, message, out clipboardableSignedMessage);
    }
}
