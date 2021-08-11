﻿using GlassesStore.Services.Brand.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Brand
{
    public interface IBrandService
    {
        IEnumerable<BrandServiceModel> All();
    }
}