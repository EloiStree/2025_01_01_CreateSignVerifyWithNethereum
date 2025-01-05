using UnityEngine;

public class EthMaskMono_CoasterPrivateKeySign : EthMaskMono_AbstractClipboardSigner
{
    public EthMaskMono_AbstractPrivateKey m_privateKeyHolder;
    public string m_marqueLetterCliboardText;
    public STRUCT_EthMaskCoasterMaqueLetter m_markLetter;
    public string m_masterToCoasterId;

    private void OnValidate()
    {
        if (m_marqueLetterCliboardText!="")
        {
            string[] splitToken = m_marqueLetterCliboardText.Split('|');
            if (splitToken.Length>=1)
            m_markLetter.m_coasterAddress = splitToken[0];
            if (splitToken.Length>=2)
            m_markLetter.m_masterAddress = splitToken[1];
            if (splitToken.Length>=3)
            m_markLetter.m_signedMarqueLetter = splitToken[2];
            m_masterToCoasterId = m_markLetter.m_masterAddress + ">"+ m_markLetter.m_coasterAddress;
            m_marqueLetterCliboardText= "";
        }
    }

    public override void GetClipboardSignedMessage(string message, out string coasterSignedMessage)
    {
        if (m_markLetter.m_coasterAddress == "" || m_markLetter.m_masterAddress == "")
        {
            MetaMaskSignUtility.GenerateClipboardSignMessage(
                m_privateKeyHolder,
                message,
                out coasterSignedMessage);
        }
        else { 
            MetaMaskSignCoasterUtility.GenerateClipboardSignCoasterMessage(
                m_privateKeyHolder,
                m_markLetter,
                message,
                out coasterSignedMessage);
        }
    }


    [ContextMenu("Create letter marque")]
    public void OpenUrlToCreateLetterMarque()
    {
        MetaMaskSignCoasterUtility.OpenPageToSignCoaster((IEthMaskPrivateKeyHolderGet) m_privateKeyHolder);

    }

}
