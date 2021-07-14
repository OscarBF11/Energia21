using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace proyecto.BD
{
    public class DALElectrodomestico
    {
        DbConnect cnx;

        // CRUD
        public DALElectrodomestico()
        {
            cnx = new DbConnect();
            Console.WriteLine("te has connectado");
        }

        public void InsertElectrodomestico(Electrodomestico el)
        {
            try
            {
                string sql = @"INSERT INTO SITIO 
                    (Nombre, Tipo, Ruido,Consumo)
                    VALUES (@pNombre,
                        @pTipo, @pRuido,@pConsumo)";

                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                pNombre.Value = el.Nombre;
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);
                pTipo.Value = el.Tipo;
                SqlParameter pRuido = new SqlParameter("@pRuido", System.Data.SqlDbType.NVarChar, 50);
                pRuido.Value = el.Ruido;
                SqlParameter pConsumo = new SqlParameter("@pConsumo", System.Data.SqlDbType.Int);
                pConsumo.Value = el.Consumo;

                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
                cmd.Parameters.Add(pRuido);
                cmd.Parameters.Add(pConsumo);
                

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Eror Insert");
            }
        }

        public Electrodomestico SelectElectrodomesticoById(int id)
        {
            Electrodomestico el = null;

            try
            {
                string sql = "SELECT * FROM ELECTRODOMESTICO WHERE IdElectrodomestico=@pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);
                SqlParameter pId = new SqlParameter("@pId", id);
                cmd.Parameters.Add(pId);

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    el = new Electrodomestico();
                    el.Nombre = (string)dr["Nombre"];
                    el.Tipo = (string)dr["Tipo"];
                    el.Ruido = (string)dr["Ruido"];
                    el.Consumo = (int)dr["Consumo"];
                    el.IdElectrodomestico = (int)dr["IdElectrodomestico"];
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }

            return el;
        }

        public void UpdateElectrodomestico(Electrodomestico el)
        {
            try
            {
                string sql = @"UPDATE ELECTROMESTICO
                SET Nombre = @pNombre,                                   
                    Tipo = @pTipo, 
                    Ruido = @pRuido,
                    Consumo = @pConsumo
                    WHERE IdElectrodomestico = @pId";
                SqlCommand cmd = new SqlCommand(sql, cnx.MiCnx);

                SqlParameter pId = new SqlParameter("@pId", el.IdElectrodomestico);
                SqlParameter pNombre = new SqlParameter("@pNombre", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pTipo = new SqlParameter("@pTipo", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pRuido = new SqlParameter("@pRuido", System.Data.SqlDbType.NVarChar, 50);
                SqlParameter pConsumo = new SqlParameter("@pConsumo", System.Data.SqlDbType.Int);
                
                cmd.Parameters.Add(pId);
                cmd.Parameters.Add(pNombre);
                cmd.Parameters.Add(pTipo);
                cmd.Parameters.Add(pRuido);
                cmd.Parameters.Add(pConsumo);

                pNombre.Value = el.Nombre;
                pTipo.Value = el.Tipo;
                pRuido.Value = el.Ruido;
                pConsumo.Value = el.Consumo;


                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error en Insert: " + ex.Message);
            }
        }

        public void DeleteElectrodomestico(int id)
        {
            try
            {
                string sql = "DELETE FROM ELECTRODOMESTICO WHERE IdElectrodomestico = @pId";
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