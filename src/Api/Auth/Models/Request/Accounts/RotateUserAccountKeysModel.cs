﻿using System.ComponentModel.DataAnnotations;
using Bit.Api.AdminConsole.Models.Request.Organizations;
using Bit.Api.Auth.Models.Request.WebAuthn;
using Bit.Api.Tools.Models.Request;
using Bit.Api.Vault.Models.Request;

namespace Bit.Api.Auth.Models.Request.Accounts;

public class RotateUserAccountKeysModel
{
    [Required]
    public MasterPasswordUnlockDataModel MasterPasswordUnlockData { get; set; }
    [Required]
    public string OldMasterPasswordHash { get; set; }
    [Required]
    public string UserKeyEncryptedPrivateKey { get; set; }
    public IEnumerable<CipherWithIdRequestModel> Ciphers { get; set; }
    public IEnumerable<FolderWithIdRequestModel> Folders { get; set; }
    public IEnumerable<SendWithIdRequestModel> Sends { get; set; }
    public IEnumerable<EmergencyAccessWithIdRequestModel> EmergencyAccessKeys { get; set; }
    public IEnumerable<ResetPasswordWithOrgIdRequestModel> ResetPasswordKeys { get; set; }
    public IEnumerable<WebAuthnLoginRotateKeyRequestModel> WebAuthnKeys { get; set; }

}
