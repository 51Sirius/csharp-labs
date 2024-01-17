using System;
using System.Collections.Generic;
using Abstractions.Repository;
using Models.Bill;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class TestBillRepository : IBillRepository
{
    private readonly IEnumerable<Bill> _bills;

    public TestBillRepository(IEnumerable<Bill> bills)
    {
        _bills = bills;
    }

    public Bill? FindBillById(long billId)
    {
        foreach (Bill bill in _bills)
        {
            if (bill.Id == billId)
            {
                return bill;
            }
        }

        throw new ArgumentException("Нету такого счета");
    }
}