using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;

namespace WebServicesCidades.Models
{
    public class DAOCidades
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;

        string conexao = @"Data Source=.\sqlexpress;Initial Catalog=ProjetoCidades;user id=sa;password=senai@123"; 
        
        public List<Cidades> Listar(){
            List<Cidades> cidades = new List<Cidades>();
            try{
                con = new SqlConnection(); //SqlConnection tem dois construtores. Vai fazer "por fora" msm
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = " Select * from Cidades";
                
                rd = cmd.ExecuteReader();

                while(rd.Read()){ //ENQUANTO TIVER LINHA/CONTEÚDO PARA LER EM RD
                    
                    cidades.Add(new Cidades{Id=rd.GetInt32(0), Nome=rd.GetString(1), Estado = rd.GetString(2),Habitantes = rd.GetInt32(3)});
                    //CLASSE CIDADES: MEIO DE PASSAGEM DE DADOS
                    //ADICIONANDO NESSA LISTA UMA NOVA CIDADE, GERADA ANONIMAMENTE(?)
                    //COLOCA OS DADOS DENTRO DELE
                    //ADICIONA NA LISTA (LISTA QUE SÓ RECEBE CIDADES).
                    
                }
                
            }
            catch(SqlException se){
                throw new Exception(se.Message);
            }
            catch(Exception ex){
                throw new Exception(ex.Message);
            }
            finally{
                con.Close();
            }
            return cidades;
        
            
        }
        public bool Cadastrar(Cidades cidades){
            bool rs = false;
            try{

            con = new SqlConnection(); //SqlConnection tem dois construtores. Vai fazer "por fora" msm
            con.ConnectionString = conexao;
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
            
            //cmd.CommandType = CommandType.Text;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Cidades"; //os parâmetros não estão aqui, estão lá dentro da procedure, no BD.
                //Veja que não tem @nome de nada, portanto, ele não é um parâmetro de C#, é um parâmetro de Banco!
                //Se quiser, compare com o método ListarCategorias, acima.
            
            SqlParameter p_id = new SqlParameter("@id",SqlDbType.VarChar,10);//é um parâmetro de SQL mesmo.
            //Estou criando um parâmetro pome para que o C# tome conhecimento do parâmetro lá dentro da minha procedure!
            //AGORA, aquele parâmetro está sendo representado pelo pnome.
            p_id.Value = cidades.Id;
            cmd.Parameters.Add(p_id);
            //lá na procedure, tenho vários elementos aguardando para serem adicionados.
            //vou passar primeiro todos os elementos para o parâmetro; só depois, eu vou mandar inserir.

            SqlParameter p_nome = new SqlParameter("@nome",SqlDbType.VarChar,100);
            p_nome.Value = cidades.Nome;
            cmd.Parameters.Add(p_nome);

            SqlParameter p_estado = new SqlParameter("@estado",SqlDbType.VarChar,50);
            p_estado.Value = cidades.Estado;
            cmd.Parameters.Add(p_estado);

            SqlParameter p_habitantes = new SqlParameter("@habitantes",SqlDbType.VarChar,20);
            p_habitantes.Value = cidades.Habitantes;
            cmd.Parameters.Add(p_habitantes);

            
            int r = cmd.ExecuteNonQuery();

            if(r > 1)
                rs = true;
                
            cmd.Parameters.Clear();
                  
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar inserir os dados "+se.Message);
            }
            catch(Exception ex){
                throw new Exception("erro inesperado "+ex.Message);
            }
            finally{
                con.Close();
            }
            return rs;

        }
    }
}