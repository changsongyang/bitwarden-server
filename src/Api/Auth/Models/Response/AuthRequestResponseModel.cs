﻿using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Bit.Core.Auth.Entities;
using Bit.Core.Models.Api;

namespace Bit.Api.Auth.Models.Response;

public class AuthRequestResponseModel : ResponseModel
{
    public AuthRequestResponseModel(
        AuthRequest authRequest,
        string vaultUri,
        string obj = "auth-request"
    )
        : base(obj)
    {
        ArgumentNullException.ThrowIfNull(authRequest);

        Id = authRequest.Id;
        PublicKey = authRequest.PublicKey;
        RequestDeviceType = authRequest
            .RequestDeviceType.GetType()
            .GetMember(authRequest.RequestDeviceType.ToString())
            .FirstOrDefault()
            ?.GetCustomAttribute<DisplayAttribute>()
            ?.GetName();
        RequestIpAddress = authRequest.RequestIpAddress;
        Key = authRequest.Key;
        MasterPasswordHash = authRequest.MasterPasswordHash;
        CreationDate = authRequest.CreationDate;
        RequestApproved = authRequest.Approved ?? false;
        Origin = new Uri(vaultUri).Host;
        ResponseDate = authRequest.ResponseDate;
    }

    public Guid Id { get; set; }
    public string PublicKey { get; set; }
    public string RequestDeviceType { get; set; }
    public string RequestIpAddress { get; set; }
    public string Key { get; set; }
    public string MasterPasswordHash { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? ResponseDate { get; set; }
    public bool RequestApproved { get; set; }
    public string Origin { get; set; }
}
