using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.BD
{
    public class DALSitio
    {
        DbConnect cnx;

        // CRUD
        public DALSitio()
        {
            cnx = new DbConnect();
            Console.WriteLine("te has connectado");
        }

        public void InsertSitio(Sitio si)
        {
            try
            {
                string sql = @"INSERT INTO SITIO 
                    (Nombre, Tipo)
                    VALUES (@pNombre,
                        @pTipo)";

                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                pNombre.Value = si.Nombre;
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);
                pTipo.Value = si.Tipo;
                
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
               
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Insert");
            }
        }

        public Sitio SelectSitioById(int id)
        {
            Sitio si = null;

            try
            {
                string sql = "SELECT * FROM SITIO WHERE IdSitio=@pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    si = new Sitio();
                    si.Nombre = (string)dr["Nombre"];
                    si.Tipo = (string)dr["Tipo"];                   
                    si.IdSitio = (int)dr["IdSitio"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }

            return si;
        }

        public void UpdateSitio(Sitio si)
        {
            try
            {
                string sql = @"UPDATE SITIO
                SET Nombre = @pNombre,                                   
                    Tipo = @pTipo                    
                    WHERE IdSitio = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", si.IdSitio);
                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);

                cmd.Parameters.Add(pId);
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
               
                pNombre.Value = si.Nombre;
                pTipo.Value = si.Tipo;
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }
        }

        public void DeleteSitio(int id)
        {
            try
            {
                string sql = "DELETE FROM SITIO WHERE IdSitio = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }

        }

    }
}