using Dapper;
using Npgsql;
using QamarKitoblar.DataAccess.Handler;

namespace QamarKitoblar.DataAccess.Repositories;

public class BaseRepository
{
    protected readonly NpgsqlConnection _connection;
    public BaseRepository()
    {
        SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());
        Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        this._connection = new NpgsqlConnection("Host=localhost; Port=5432; Database=QamarKitoblar-db; User Id=postgres; Password=ll;");
    }
}
