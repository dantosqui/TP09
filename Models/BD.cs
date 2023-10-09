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

    public static int CambiarContraseña(string username, string contraseña){

        int resultado=0;
        using(SqlConnection db = new SqlConnection(_connectionstring)){
            string sql="EXEC CambiarContraseña @pUsername, @pContraseña";
            resultado=db.QueryFirstOrDefault<int>(sql, new{pUsername=username,pContraseña=contraseña});
        }
        return resultado;
    }

    public static void Registro(string us, string con, string em, string fec, char se, string fot,int preg,string rta){

        using (SqlConnection db= new SqlConnection(_connectionstring)){
            string sql ="EXEC registrarse @u,@c,@e,@f,@s,@fo,@pr,@rt";
            db.Execute(sql, new{u=us,c=con,e=em,f=fec,s=se,fo=fot,pr=preg,rt=rta});
        }
    }
    
    public static List<Preguntas> ListarPreguntas(){

        List<Preguntas> preguntas = new List<Preguntas>();
        using (SqlConnection db = new SqlConnection(_connectionstring)){
            string sql ="SELECT * FROM Preguntas";
            preguntas=db.Query<Preguntas>(sql).ToList();
        }
        return preguntas;
    }

    public static int ValidarPregunta(int id, string rta,string usuario){

        int result=0;
        using (SqlConnection db=new SqlConnection(_connectionstring)){
            string sql = "EXEC ValidarPregunta @pid, @rt, @user";
            result=db.QueryFirstOrDefault<int>(sql, new{pid=id,rt=rta,user=usuario});
        }
        return result;
    }
    
}