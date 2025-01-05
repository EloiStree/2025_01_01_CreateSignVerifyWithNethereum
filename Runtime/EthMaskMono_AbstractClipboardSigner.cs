using UnityEngine;

public abstract class EthMaskMono_AbstractClipboardSigner : MonoBehaviour, IEthMaskCliboardableSigner
{
    public abstract void GetClipboardSignedMessage(string message, out string clipboardableSignedMessage);
}
