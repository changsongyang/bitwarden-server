using System.ComponentModel.DataAnnotations;
using Bit.Api.AdminConsole.Models.Request.Organizations;
using Bit.Api.Auth.Models.Request.WebAuthn;
using Bit.Api.Tools.Models.Request;
using Bit.Api.Vault.Models.Request;
using Bit.Core.Enums;

namespace Bit.Api.Auth.Models.Request.Accounts;

public class RotateUserAccountKeysModel
{
    [Required]
    public KdfType KdfType { get; set; }
    [Required]
    public int KdfIterations { get; set; }
    public int? KdfMemory { get; set; }
    public int? KdfParallelism { get; set; }

    [Required]
    public string Email { get; set; }
    [Required]
    [StringLength(300)]
    public string MasterPasswordHash { get; set; }
    [Required]
    public string MasterKeyEncryptedUserKey { get; set; }
    [Required]
    public string UserKeyEncryptedPrivateKey { get; set; }

    public IEnumerable<CipherWithIdRequestModel> Ciphers { get; set; }
    public IEnumerable<FolderWithIdRequestModel> Folders { get; set; }
    public IEnumerable<SendWithIdRequestModel> Sends { get; set; }
    public IEnumerable<EmergencyAccessWithIdRequestModel> EmergencyAccessKeys { get; set; }
    public IEnumerable<ResetPasswordWithOrgIdRequestModel> ResetPasswordKeys { get; set; }
    public IEnumerable<WebAuthnLoginRotateKeyRequestModel> WebAuthnKeys { get; set; }

}
