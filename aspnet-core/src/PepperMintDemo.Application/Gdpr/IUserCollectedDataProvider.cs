﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Abp;
using PepperMintDemo.Dto;

namespace PepperMintDemo.Gdpr
{
    public interface IUserCollectedDataProvider
    {
        Task<List<FileDto>> GetFiles(UserIdentifier user);
    }
}
