﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Net5.Fundamentals.DI.Console
{
    public interface IDataStorage
    {
        string Get(int id);
        Dictionary<int, string> List();
        void Insert(string data);
        void Update(int id, string data);
        void Delete(int id);
    }
}
