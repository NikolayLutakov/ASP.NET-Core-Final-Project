﻿using GlassesStore.Services.Glasses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassesStore.Services.Glasses
{
    public interface IGlassesService
    {
        IEnumerable<GlassesServiceModel> All();

        GlassesFormServiceModel PopulateBookFormModel();

        GlassesFormServiceModel PopulateBookFormModel(int id);

        bool Add(
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId);

        public bool Edit(
            int id,
            string modelName,
            string description,
            decimal price,
            string imageUrl,
            int brandId,
            int typeId);

        public bool Delete(int id);
    }
}