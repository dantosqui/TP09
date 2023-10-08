using System.Data.SqlClient;
using Dapper;

public class BD{
    private static string _connectionstring =@"Server=DANOSQUI20GAMER\SQLEXPRESS;Database=TP9;Trusted_Connection=True;";

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

    public static void Registro(string us, string con, string em, string fec, char se, string fot){

        using (SqlConnection db= new SqlConnection(_connectionstring)){
            string sql ="EXEC registrarse @u,@c,@e,@f,@s,@fo";
            db.Execute(sql, new{u=us,c=con,e=em,f=fec,s=se,fo=fot});
        }
    }
    
}