using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.BD
{
    public class DALUsuario
    {
        DbConnect cnx;

        // CRUD
        public DALUsuario()
        {
            cnx = new DbConnect();
            Console.WriteLine("te has connectado");
        }

        public void InsertUsuario(Usuario us)
        {
            try 
            {
                string sql = @"INSERT INTO USUARIO 
                    (Nombre, Correo, Contraseña, RIdSitio)
                    VALUES (@pNombre,@pCorreo,@pContraseña,null)";

                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                pNombre.Value = us.Nombre;
                SqlParameter pCorreo = new SqlParameter("@pCorreo", System.Data.SqlDbType.NVarChar, 50);
                pCorreo.Value = us.Correo;
                SqlParameter pContraseña = new SqlParameter("@pContraseña", System.Data.SqlDbType.NVarChar, 50);
                pContraseña.Value = us.Contraseña;
               
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pCorreo);
                cmd.Parameters.Add(pContraseña);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Insert");                
            }
        }

        public Usuario SelectUsuarioById(int id)
        {
            Usuario us = null;

            try
            {
                string sql = "SELECT * FROM USUARIO WHERE IdUsuario=@pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    us = new Usuario();
                    us.Nombre = (string)dr["Nombre"];
                    us.Correo = (string)dr["Correo"];
                    us.Contraseña = (string)dr["Contraseña"];
                    us.RIdSitio = (int)dr["RIdSitio"];
                    us.idUsuario = (int)dr["idUsuario"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Select");
            }

            return us;
        }

        public void UpdateUsuario(Usuario us)
        {
            try
            {
                string sql = @"UPDATE USUARIO
                SET Nombre = @pNombre,                                   
                    Correo = @pCorreo,
                    Contraseña = @pContraseña
                    WHERE IdUsuario = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", us.idUsuario);
                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pCorreo = new SqlParameter("@pCorreo", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pContraseña = new SqlParameter("@pContraseña", System.Data.SqlDbType.NVarChar, 50);
                                      
                
                cmd.Parameters.Add(pId);
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pCorreo);
                cmd.Parameters.Add(pContraseña);


                pNombre.Value = us.Nombre;
                pCorreo.Value = us.Correo;
                pContraseña.Value = us.Contraseña;
               

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Update");
            }
        }

        public void DeleteUsuario(int id)
        {
            try
            {
                string sql = "DELETE FROM USUARIO WHERE IdUsuario = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Delete");
            }

        }
    }
}