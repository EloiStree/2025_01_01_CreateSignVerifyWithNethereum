public class EthMaskCreateSignVerify :  IEthMaskCreateSignVerify
{
    public void CreatePrivateKey(out string privateKey)
    {
        MetaMaskSignUtility.GeneratePrivateKey(out privateKey);
    }

    public void CreatePrivateKey(out IEthMaskPrivateKeyHolderGet privateKeyHolder)
    {
        MetaMaskSignUtility.GeneratePrivateKey(out string privateKey);
        STRUCT_EthMaskPrivateKey structEthMaskPrivateKey = new STRUCT_EthMaskPrivateKey()
        {
            m_privateKey = privateKey
        };
        privateKeyHolder = structEthMaskPrivateKey;
    }

    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage)
    {
        MetaMaskSignUtility.SplitClipboardMessage(clipboardableSignedMessage, out messageGivenToSign, out claimedAddress, out signedMessage);
    }

    public void GetPublicAddress(IEthMaskPrivateKeyHolderGet privateKeyHolder, out string publicAddress)
    {
        MetaMaskSignUtility.GetPublicAddressFromPrivateKey(privateKeyHolder.GetPrivateKey(), out publicAddress);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified)
    {
        MetaMaskSignUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out _, out _);
    }

    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress)
    {
        MetaMaskSignUtility.IsVerifiedClipboardSignMessage(clipboardableSignedMessage, out isVerified, out claimedAddress, out recoveredAddress);
    }

    public void SignMessageAsClipboardable(IEthMaskPrivateKeyHolderGet privateKeyHolder, string message, out string clipboardableSignedMessage)
    {
        MetaMaskSignUtility.GenerateClipboardSignMessage(privateKeyHolder.GetPrivateKey(), message, out clipboardableSignedMessage);
    }
}