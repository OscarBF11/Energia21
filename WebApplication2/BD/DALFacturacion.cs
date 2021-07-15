using System;
using System.Data.SqlClient;

namespace WebApplication2.BD
{
    public class DALFacturacion
    {
        DbConnect cnx;

        // CRUD
        public DALFacturacion()
        {
            cnx = new DbConnect();
            Console.WriteLine("Te has connectado");
        }

        public void InsertFacturacion(Facturacion us)
        {
            try
            {
                string sql = @"INSERT INTO FACTURACION_ENERGIA 
                    (datetime, geo_name, price)
                    VALUES (@pDateTime,@pGeoName,@pPrice)";

                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pDateTime = new SqlParameter("@pDateTime", System.Data.SqlDbType.DateTime, 50);
                pDateTime.Value = us.Datetime;
                SqlParameter pGeoName = new SqlParameter("@pGeoName", System.Data.SqlDbType.NVarChar, 20);
                pGeoName.Value = us.GeoName;
                SqlParameter pPrice = new SqlParameter("@pPrice", System.Data.SqlDbType.Decimal, 8);
                pPrice.Value = us.Price;

                cmd.Parameters.Add(pDateTime);
                cmd.Parameters.Add(pGeoName);
                cmd.Parameters.Add(pPrice);


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Insert");
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
                    us.IdUsuario = (int)dr["idUsuario"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Select");
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

                SqlParameter pId = new SqlParameter("@pId", us.IdUsuario);
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
                Console.WriteLine("Error Update");
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
                Console.WriteLine("Error Delete");
            }

        }
    }
}
