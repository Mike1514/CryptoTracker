﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoTracker.Fetcher.Application.Interfaces
{
    public interface IPriceFetcherService
    {
        Task FetchAndStorePriceAsync(CancellationToken cancellationToken);
    }
}
