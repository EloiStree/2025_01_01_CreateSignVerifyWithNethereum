using Nethereum.Signer;
using System;
using System.Security.Cryptography;


public class MetaMaskSignCoasterUtility {

    public static void GenerateClipboardSignCoasterMessage(
        string messageToSign,
        string publicAddressCoaster,
        string signedMessageCoaster,
        string publicAddressMaster,
        string signedMarqueLetter,
        out string clipboardableSignature)
    {
        clipboardableSignature = string.Join("|", messageToSign.Trim(), publicAddressCoaster.Trim(), signedMessageCoaster.Trim(), publicAddressMaster.Trim(), signedMarqueLetter.Trim());
    }
}

public class MetaMaskSignUtility
{
    // Generate a clipboard message containing the original message, public address, and signed message
    public static void GenerateClipboardSignMessage(string privateKey, string message, out string clipboardMessage)
    {
        GetSignedMessage(privateKey, message, out string signedMessage);
        GetPublicAddressFromPrivateKey(privateKey, out string publicAddress);
        clipboardMessage = $"{message}|{publicAddress}|{signedMessage}";
    }

   

    // Check if the clipboard message is verified
    public static bool IsVerifiedClipboardSignMessage(string clipboardMessage)
    {
        IsVerifiedClipboardSignMessage(clipboardMessage, out bool isVerified, out _, out _);
        return isVerified;
    }
    
    public static void SplitClipboardMessage(string clipboardMessage, out string message, out string claimedAddress, out string signedMessage)
    {
        string[] parts = clipboardMessage.Split('|');
        message = parts.Length >= 1?parts[0]:"";
        claimedAddress = parts.Length >= 2?parts[1]:"";
        signedMessage = parts.Length >= 3?parts[2]:"";
    }

    // Retrieve verification details from the clipboard message
    public static bool IsVerifiedClipboardSignMessage(
        string clipboardMessage,
        out bool isVerified,
        out string claimedAddress,
        out string recoveredAddress)
    {
        string[] parts = clipboardMessage.Split('|');

        if (parts.Length != 3)
        {
            isVerified = false;
            claimedAddress = string.Empty;
            recoveredAddress = string.Empty;
            return false;
        }

        string message = parts[0];
        claimedAddress = parts[1];
        string signedMessage = parts[2];

        isVerified = VerifySignedMessage(claimedAddress, signedMessage, message, out recoveredAddress);
        return true;
    }

    // Generate a new Ethereum private key
    public static string GeneratePrivateKey()
    {
        return EthECKey.GenerateKey().GetPrivateKey();

    }// Generate a new Ethereum private key
    public static void GeneratePrivateKey(out string privateKey)
    {
        privateKey = EthECKey.GenerateKey().GetPrivateKey();
    }

    // Get the public address associated with a given private key
    public static void GetPublicAddressFromPrivateKey(string privateKey, out string publicAddress)
    {
        var ecKey = new EthECKey(privateKey);
        publicAddress = ecKey.GetPublicAddress();
    }

    // Sign a message using the provided private key
    public static void GetSignedMessage(string privateKey, string message, out string signedMessage)
    {
        var signer = new EthereumMessageSigner();
        signedMessage = signer.EncodeUTF8AndSign(message, new EthECKey(privateKey));
    }

    public static void GetPublicAddressInSignedMessage(string message, string signedMessage, out string recoveredAddress)
    {
        var signer = new EthereumMessageSigner();
        recoveredAddress = signer.EncodeUTF8AndEcRecover(message, signedMessage);

    }

    // Verify if a signed message matches the original message and public address
    public static bool VerifySignedMessage(
        string publicAddress,
        string signedMessage,
        string originalMessage,
        out string recoveredAddress)
    {
        GetPublicAddressInSignedMessage(originalMessage,  signedMessage, out recoveredAddress);
        return string.Equals(publicAddress.Trim(), recoveredAddress.Trim());
    }

    public static void OpenPageToSignMessage(string messageToSign)
    {
        UnityEngine.Application.OpenURL("https://eloistree.github.io/SignMetaMaskTextHere/index.html?q="+messageToSign);
    }

    public static void GeneratePrivateKeyFromBytes(byte[] bytes, out string privateKey)
    {
        // Step 1: Hash the input bytes using SHA-256 to ensure a 32-byte value
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hash = sha256.ComputeHash(bytes);

            // Step 2: Convert the hash into a hexadecimal string
            privateKey = BitConverter.ToString(hash).Replace("-", "").ToLower();

            // Step 3: Validate the private key (ensure it is 32 bytes in length)
            if (privateKey.Length != 64) // 64 hex characters = 32 bytes
            {
                throw new InvalidOperationException("Invalid private key length. Must be 32 bytes.");
            }
        }
    }
}

