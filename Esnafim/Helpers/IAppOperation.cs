﻿using Esnafim.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esnafim.Helpers
{
    public interface IAppOperation
    {
        Task<List<Dukkanlar>> AllShops();

    }
}