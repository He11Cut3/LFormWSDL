﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LForm.Dto
{
    public class NewCustomerResponse : ResultResponse
    {
        public int EntityId { get; set; }

        public int AffiliateResultCode { get; set; }

        public string AffiliateResultMessage { get; set; }

    }
}