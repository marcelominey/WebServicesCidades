//esse arquivo foi clonado do projeto da Naila
using System.Data.SqlClient;
        using System.Data;
        using System.Collections.Generic;
        using System;
        
        namespace WebServicesCidades.Models
        {
            public class DAOCidades
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                SqlDataReader rd = null;
      
                string conexao = @"Data Source=.\SqlExpress;Initial Catalog=ProjetoCidades;user id=sa;password=senai@123";// ProjetoCidades nome do BD.
        
                public List<Cidades> Listar()
                {
                    List<Cidades> cidades = new List<Cidades>(); //criando uma lista e populando com os dados do banco
                    try
                    {
                        con = new SqlConnection();
                        con.ConnectionString = conexao;
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Select * from cidades"; // cidades é o nome da tabela
                        rd = cmd.ExecuteReader();
                        while (rd.Read())
                        {
                            cidades.Add(new Cidades()
                            {
                                Id = rd.GetInt32(0),
                                Nome = rd.GetString(1),
                                Estado = rd.GetString(2),
                                Habitantes = rd.GetInt32(3)
                            });
                        }
                    }
                    catch (SqlException se)
                    {
                        throw new Exception(se.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        con.Close();
                    }
                    return cidades;
                }
        
                public bool Cadastrar(Cidades cidades){
                    bool resultado = false;
                    try {
                        con = new SqlConnection(conexao);
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "insert into cidades(nome,estado,habitantes) values(@n,@e,@h)"; // cidades é o nome da tabela
                        cmd.Parameters.AddWithValue("@n",cidades.Nome);
                        cmd.Parameters.AddWithValue("@e",cidades.Estado);
                        cmd.Parameters.AddWithValue("@h",cidades.Habitantes);
        
                        int r = cmd.ExecuteNonQuery();
                        if(r > 0)
                        resultado = true;
        
                        cmd.Parameters.Clear();
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
                    return resultado;
                }
                    public bool Atualizar(Cidades cidades){
                    bool resultado = false;
                    try {
                        con = new SqlConnection(conexao);
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "UPDATE cidades set nome=@n, estado=@e, habitantes=@h where id=@id"; // cidades é o nome da tabela
                        cmd.Parameters.AddWithValue("@n",cidades.Nome);
                        cmd.Parameters.AddWithValue("@e",cidades.Estado);
                        cmd.Parameters.AddWithValue("@h",cidades.Habitantes);
                        cmd.Parameters.AddWithValue("@id",cidades.Id);
        
                        int r = cmd.ExecuteNonQuery();
                        if(r > 0)
                        resultado = true;
        
        
                        cmd.Parameters.Clear();
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
                    return resultado;
                }
                public bool Deletar(int id){
                    bool resultado = false;
                    try {
                        con = new SqlConnection(conexao);
                        con.Open();
                        cmd = new SqlCommand();
                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "DELETE FROM cidades WHERE id=@id";
                        cmd.Parameters.AddWithValue("@id",id);
        
                        int r = cmd.ExecuteNonQuery();
                        if(r > 0)
                        resultado = true;
        
                        cmd.Parameters.Clear();
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
                    return resultado;
                }
            }
        }
