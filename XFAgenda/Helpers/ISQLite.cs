using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFAgenda.Helpers
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
