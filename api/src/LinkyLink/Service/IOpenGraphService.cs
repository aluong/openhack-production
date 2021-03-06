﻿using LinkyLink.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LinkyLink.Service
{
    public interface IOpenGraphService
    {
        Task<IEnumerable<OpenGraphResult>> GetGraphResults(HttpRequest req, IEnumerable<OpenGraphRequest> openGraphRequests);
    }
}
