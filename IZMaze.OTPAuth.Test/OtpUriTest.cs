using System;
using IZMaze.OTPAuth;
using IZMaze.OTPAuth.Constants;
using NUnit.Framework;

namespace IZMaze.OTPAuth.Test;

[TestFixture]
public class OtpUriTest
{
    private const string BaseSecret = "MYC452VTGBKRP7OE";
    private const string BaseUser = "izmaze@izmaze.com";
    private const string BaseIssuer = "izmaze";

    [TestCase(BaseSecret, OtpType.Totp, BaseUser, BaseIssuer, OtpHashMode.Sha1, 6, 30, 0,
        "otpauth://totp/iz-maze:izmaze%40izmaze.com?secret=MYC452VTGBKRP7OE&issuer=iz-maze&algorithm=SHA1&digits=6&period=30")]
    [TestCase(BaseSecret, OtpType.Totp, BaseUser, BaseIssuer, OtpHashMode.Sha256, 6, 30, 0,
        "otpauth://totp/iz-maze:izmaze%40izmaze.com?secret=MYC452VTGBKRP7OE&issuer=iz-maze&algorithm=SHA256&digits=6&period=30")]
    [TestCase(BaseSecret, OtpType.Totp, BaseUser, BaseIssuer, OtpHashMode.Sha512, 6, 30, 0,
        "otpauth://totp/iz-maze:izmaze%40izmaze.com?secret=MYC452VTGBKRP7OE&issuer=iz-maze&algorithm=SHA512&digits=6&period=30")]
    [TestCase(BaseSecret, OtpType.Hotp, BaseUser, BaseIssuer, OtpHashMode.Sha512, 6, 30, 0,
        "otpauth://hotp/iz-maze:izmaze%40izmaze.com?secret=MYC452VTGBKRP7OE&issuer=iz-maze&algorithm=SHA512&digits=6&counter=0")]
    public void GenerateOtpUriTest(string secret, OtpType otpType, string user, string issuer,
        OtpHashMode hash, int digits, int period, int counter, string expectedUri)
    {
        var uriString = new OtpUri(otpType, secret, user, issuer, hash, digits, period, counter).ToString();
        Assert.That(uriString, Is.EqualTo(expectedUri));
    }
}
