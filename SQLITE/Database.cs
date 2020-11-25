using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SQLITE
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
