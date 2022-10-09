﻿using MyStore.Common.Dto;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Application.Services.Fainances.Queries.GetRequestPayService
{
    public interface IGetRequestPayService
    {
        ResultDto<RequestPayDto> Execute(Guid guid);
    }
}
