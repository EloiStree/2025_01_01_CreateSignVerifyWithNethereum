public class EthMaskCreateSignVerify :  IEthMaskCreateSignVerify
{
    public void CreatePrivateKey(out string privateKey)
    {
        EthMaskSignUtility.GeneratePrivateKey(out privateKey);
    }

    public void CreatePrivateKey(out IEthMaskPrivateKeyHolderGet privateKeyHolder)
    {
        EthMaskSignUtility.GeneratePrivateKey(out string privateKey);
        STRUCT_EthMaskPrivateKey structEthMaskPrivateKey = new STRUCT_EthMaskPrivateKey()
        {
            m_privateKey = privateKey
        };
        privateKeyHolder = structEthMaskPrivateKey;
    }

    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage)
    {
        EthMaskSignUtility.SplitClipboardMessage(clipboardableSignedMessage, out messageGivenToSign, out claimedAddress, out signedMessage);
    }

    public void GetPublicAddress(IEthMaskPrivateKeyHolderGet privateKeyHolder, out string publicAddress)
    {
        EthMaskSignUtility.GetPublicAddressFromPrivateKey(privateKeyHolder.GetPrivateKey(), out publicAddress);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified)
    {
        EthMaskSignUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out _, out _);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress)
    {
        EthMaskSignUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out claimedAddress, out recoveredAddress);
    }

    public void SignMessageAsClipboardable(IEthMaskPrivateKeyHolderGet privateKeyHolder, string message, out string clipboardableSignedMessage)
    {
        EthMaskSignUtility.GenerateClipboardSignMessage(privateKeyHolder.GetPrivateKey(), message, out clipboardableSignedMessage);
    }
}