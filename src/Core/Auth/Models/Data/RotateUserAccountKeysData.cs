using Bit.Core.Auth.Entities;
using Bit.Core.Entities;
using Bit.Core.Enums;
using Bit.Core.Tools.Entities;
using Bit.Core.Vault.Entities;

namespace Bit.Core.Auth.Models.Data;

public class RotateUserAccountKeysData
{
    public KdfType KdfType { get; set; }
    public int KdfIterations { get; set; }
    public int? KdfMemory { get; set; }
    public int? KdfParallelism { get; set; }

    public string Email { get; set; }
    public string MasterPasswordHash { get; set; }

    public string MasterKeyEncryptedUserKey { get; set; }
    public string UserKeyEncryptedPrivateKey { get; set; }

    public IEnumerable<Cipher> Ciphers { get; set; }
    public IEnumerable<Folder> Folders { get; set; }
    public IReadOnlyList<Send> Sends { get; set; }
    public IEnumerable<EmergencyAccess> EmergencyAccesses { get; set; }
    public IReadOnlyList<OrganizationUser> OrganizationUsers { get; set; }
    public IEnumerable<WebAuthnLoginRotateKeyData> WebAuthnKeys { get; set; }
}
