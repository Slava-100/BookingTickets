using System.Security.Cryptography;

namespace BookingTickets.Business;
public class HashingSettings
{
    public const int keySize = 64;
    public const int iterations = 3;
    public HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;
}

