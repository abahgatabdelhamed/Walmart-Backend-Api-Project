﻿using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Contracts
{
   
    public interface IPaymentRepoistory : IGenericReposatiry<Payment, int>
    {
        IQueryable<Payment> SearchByTransactionId(string transactionId);
    }
}



