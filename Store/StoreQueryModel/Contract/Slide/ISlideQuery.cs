﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQueryModel.Contract.Slide
{
    public interface ISlideQuery
    {
        List<SlideQueryModel> GetListSlide();
    }
}
