using System.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionstring =@"Server=.;Database=TP9;Trusted_Connection=True;";

    public static bool Login(string username, string contraseña){
        bool correcto=false;    
        using(SqlConnection db = new SqlConnection(_connectionstring)){
            string sql ="EXEC Login @pUsername, @pContraseña";
            correcto=Convert.ToBoolean(db.QueryFirstOrDefault<int>(sql,new{pUsername=username,pContraseña=contraseña}));
        }
        return correcto;
    }

    public static void CambiarContraseña(string username, string contraseña){

        using(SqlConnection db = new SqlConnection(_connectionstring)){
            string sql="EXEC CambiarContraseña @pUsername, @pContraseña";
            db.Execute(sql, new{pUsername=username,pContraseña=contraseña});
        }
    }
    
}