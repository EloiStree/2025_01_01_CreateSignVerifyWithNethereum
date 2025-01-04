public interface IEthMaskCreateSignVerify
{
    #region CREATE
    public void CreatePrivateKey(out string privateKey);
    public void CreatePrivateKey(out IEthMaskPrivateKeyHolderGet privateKeyHolder);
    #endregion

    #region SIGN
    public void SignMessageAsClipboardable(IEthMaskPrivateKeyHolderGet privateKeyHolder, string message,  out string clipboardableSignedMessage);
    #endregion

    #region VERIFY
    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified);
    public void IsVerifiedClipboardSignMessage(string clipboardableSignedMessage, out bool isVerified, out string claimedAddress, out string recoveredAddress);
    #endregion

    #region UTILITY
    public void GetPublicAddress(IEthMaskPrivateKeyHolderGet privateKeyHolder, out string publicAddress);
    public void GetClipboardableAsSplitMessage(string clipboardableSignedMessage, out string messageGivenToSign, out string claimedAddress, out string signedMessage);
    #endregion
}
