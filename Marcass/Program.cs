using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
namespace Marcass
{
    class Program
    {
        public static byte intEMPRESAID = 0;
        public static byte intSUCURSALID = 0;

        public const string appName = "GrupoGuadiana";
        public const string section = "Config";


        [STAThread]
        static void Main(string[] args)
        {

            intEMPRESAID = Convert.ToByte(GetSetting(appName, section, "EmpresaID", String.Empty));
            intSUCURSALID = Convert.ToByte(GetSetting(appName, section, "SucursalID", String.Empty));




            TimeSpan stop;
            TimeSpan start = new TimeSpan(DateTime.Now.Ticks);

            //string connectionStringer = GetDestiny(intSUCURSALID);
            string connectionStringer = "SERVER = gggctserver.database.windows.net; DATABASE = rdbms_GGGC_Public_TESTING; USER ID = abril; PASSWORD = gggc.2017 ";
            SqlConnection sqlcon = new SqlConnection(connectionStringer);


            DataTable dtbl = GetExistenciaDataTable();

            //Eliminar(sqlcon);
            MarcasBulkInsertion(sqlcon, dtbl);
           // Fecha(sqlcon);

            stop = new TimeSpan(DateTime.Now.Ticks);
            Console.WriteLine(stop.Subtract(start).TotalMilliseconds);




            Console.ReadKey();

        }
        static DataTable GetExistenciaDataTable()
        {
            string conect = GetOrigen(intSUCURSALID);

            SqlConnection sqlconn = new SqlConnection(conect);
            sqlconn.Open();
            //string oso = GetTablaSuc(intSUCURSALID);
            //SqlDataAdapter adapter = new SqlDataAdapter(oso, sqlconn);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Razones ", sqlconn);
            DataSet dsPubs = new DataSet("Pubs");
            adapter.Fill(dsPubs, "Razones");
            DataTable dtbl = new DataTable();

            dtbl = dsPubs.Tables["Razones"];
            sqlconn.Close();
            //tratando de agrgar una columna de un data set ya definido 
            //dtbl.Columns.Add("Fecha", typeof(DateTime));
            return dtbl;
        }
        static string GetOrigen(int empresa)
        {
            string conexion;
            switch (empresa)
            {
                case 1:
                    conexion = "SERVER = 192.168.2.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 2:
                    conexion = "SERVER = 192.168.6.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 3:
                    conexion = "SERVER = 192.168.14.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 4:
                    conexion = "SERVER = 192.168.200.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 5:
                    conexion = "SERVER = 192.168.15.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 7:
                    conexion = "SERVER = 192.168.200.20; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 8:
                    conexion = "SERVER = 192.168.100.100; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 9:
                    conexion = "SERVER = 192.168.4.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 10:
                    conexion = "SERVER = 192.168.100.100; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 11:
                    conexion = "SERVER = 192.168.11.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 12:
                    conexion = "SERVER = 192.168.11.140; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 13:
                    conexion = "SERVER = 192.168.5.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 15:
                    conexion = "SERVER = 192.168.20.7; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 16:
                    conexion = "SERVER = 192.168.7.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                case 17:
                    conexion = "SERVER = 192.168.8.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

                case 18:
                    conexion = "SERVER = 192.168.8.140; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;
                default:
                    conexion = "SERVER = 192.168.14.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

            }
        }
        static string GetTablaSuc(int empresa)
        {
            string conexion;
            switch (empresa)
            {
                case 1:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='1' ";
                    return conexion;
                    break;

                case 2:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='2' ";
                    return conexion;
                    break;
                case 3:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='3' ";
                    return conexion;
                    break;

                case 4:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='4' ";
                    return conexion;
                    break;
                case 5:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='55' ";
                    return conexion;
                    break;

                case 7:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='7' ";
                    return conexion;
                    break;
                case 8:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='8' ";
                    return conexion;
                    break;

                case 9:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='9' ";
                    return conexion;
                    break;
                case 10:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='10' ";
                    return conexion;
                    break;

                case 11:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='11' ";
                    return conexion;
                    break;
                case 12:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='12' ";
                    return conexion;
                    break;

                case 13:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='13' ";
                    return conexion;
                    break;
                case 15:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='15' ";
                    return conexion;
                    break;

                case 16:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='16' ";
                    return conexion;
                    break;
                case 17:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='17' ";
                    return conexion;
                    break;

                case 18:
                    conexion = "SELECT Numero_Corto_De_Sucursal, Codigo_De_Articulo, Cantidad FROM dbo.vtaFormaExistrenciasPorSucursalExistencias WHERE(Cantidad <> 0) and Numero_Corto_De_Sucursal ='18' ";
                    return conexion;
                    break;
                default:
                    conexion = "SERVER = 192.168.14.1; DATABASE = Punto_De_Venta; USER ID = sa; PASSWORD = dgo2007";
                    return conexion;
                    break;

            }
        }
       
        static string delt(int empresa)
        {
            string conexion;
            switch (empresa)
            {
                case 1:
                    conexion = "Delete From Existencia1 where Numero_Corto_De_Sucursal = '1'";
                    return conexion;
                    break;

                case 2:
                    conexion = "Delete From Existencia2 where Numero_Corto_De_Sucursal = '2'";
                    return conexion;
                    break;
                case 3:
                    conexion = "Delete From Existencia3 where Numero_Corto_De_Sucursal = '3'";
                    return conexion;
                    break;

                case 4:
                    conexion = "Delete From Existencia44 where Numero_Corto_De_Sucursal = '4'";
                    return conexion;
                    break;
                case 5:
                    conexion = "Delete From Existencia5 where Numero_Corto_De_Sucursal = '55'";
                    return conexion;
                    break;

                case 7:
                    conexion = "Delete From Existencia7 where Numero_Corto_De_Sucursal = '7'";
                    return conexion;
                    break;
                case 8:
                    conexion = "Delete From Existencia8 where Numero_Corto_De_Sucursal = '8'";
                    return conexion;
                    break;

                case 9:
                    conexion = "Delete From Existencia9 where Numero_Corto_De_Sucursal = '9'";
                    return conexion;
                    break;
                case 10:
                    conexion = "Delete From Existencia10 where Numero_Corto_De_Sucursal = '10'";
                    return conexion;
                    break;

                case 11:
                    conexion = "Delete From Existencia11 where Numero_Corto_De_Sucursal = '11'";
                    return conexion;
                    break;
                case 12:
                    conexion = "Delete From Existencia12 where Numero_Corto_De_Sucursal = '12'";
                    return conexion;
                    break;

                case 13:
                    conexion = "Delete From Existencia13 where Numero_Corto_De_Sucursal = '13'";
                    return conexion;
                    break;
                case 15:
                    conexion = "Delete From Existencia15 where Numero_Corto_De_Sucursal = '15'";
                    return conexion;
                    break;

                case 16:
                    conexion = "Delete From Existencia16 where Numero_Corto_De_Sucursal = '16'";
                    return conexion;
                    break;
                case 17:
                    conexion = "Delete From Existencia17 where Numero_Corto_De_Sucursal = '17'";
                    return conexion;
                    break;

                case 18:
                    conexion = "Delete From Existencia18 where Numero_Corto_De_Sucursal = '18'";
                    return conexion;
                    break;
                default:
                    conexion = "Delete From Existencia454 where Numero_Corto_De_Sucursal = '45'";
                    return conexion;
                    break;

            }
        }
        static void Fecha(SqlConnection sqlcon)
        {
            var cmd = sqlcon.CreateCommand();
            sqlcon.Open();
            string selenio = Getsel(intSUCURSALID);
            cmd.CommandText = selenio;
            //cmd.CommandText = "Update Existencia44 set Fecha = getdate() where Numero_Corto_De_Sucursal = '4'";
            cmd.ExecuteNonQuery();
            sqlcon.Close();
        }
        static string Getsel(int empresa)
        {

            string conexion;
            switch (empresa)
            {
                case 1:
                    conexion = "Update Existencia1 set Fecha = getdate() where Numero_Corto_De_Sucursal = '1'";
                    return conexion;
                    break;

                case 2:
                    conexion = "Update Existencia2 set Fecha = getdate() where Numero_Corto_De_Sucursal = '2'";
                    return conexion;
                    break;
                case 3:
                    conexion = "Update Existencia3 set Fecha = getdate() where Numero_Corto_De_Sucursal = '3'";
                    return conexion;
                    break;

                case 4:
                    conexion = "Update Existencia44 set Fecha = getdate() where Numero_Corto_De_Sucursal = '4'";
                    return conexion;
                    break;
                case 5:
                    conexion = "Update Existencia5 set Fecha = getdate() where Numero_Corto_De_Sucursal = '55'";
                    return conexion;
                    break;

                case 7:
                    conexion = "Update Existencia7 set Fecha = getdate() where Numero_Corto_De_Sucursal = '7'";
                    return conexion;
                    break;
                case 8:
                    conexion = "Update Existencia8 set Fecha = getdate() where Numero_Corto_De_Sucursal = '8'";
                    return conexion;
                    break;

                case 9:
                    conexion = "Update Existencia9 set Fecha = getdate() where Numero_Corto_De_Sucursal = '9'";
                    return conexion;
                    break;
                case 10:
                    conexion = "Update Existencia10 set Fecha = getdate() where Numero_Corto_De_Sucursal = '10'";
                    return conexion;
                    break;

                case 11:
                    conexion = "Update Existencia11 set Fecha = getdate() where Numero_Corto_De_Sucursal = 11'";
                    return conexion;
                    break;
                case 12:
                    conexion = "Update Existencia12 set Fecha = getdate() where Numero_Corto_De_Sucursal = '12'";
                    return conexion;
                    break;

                case 13:
                    conexion = "Update Existencia13 set Fecha = getdate() where Numero_Corto_De_Sucursal = '13'";
                    return conexion;
                    break;
                case 15:
                    conexion = "Update Existencia15 set Fecha = getdate() where Numero_Corto_De_Sucursal = '15'";
                    return conexion;
                    break;

                case 16:
                    conexion = "Update Existencia16 set Fecha = getdate() where Numero_Corto_De_Sucursal = '16'";
                    return conexion;
                    break;
                case 17:
                    conexion = "Update Existencia17 set Fecha = getdate() where Numero_Corto_De_Sucursal = '17'";
                    return conexion;
                    break;

                case 18:
                    conexion = "Update Existencia18 set Fecha = getdate() where Numero_Corto_De_Sucursal = '18'";
                    return conexion;
                    break;
                default:
                    conexion = "Update Existencia66 set Fecha = getdate() where Numero_Corto_De_Sucursal = '66'";
                    return conexion;
                    break;

            }

        }


        static void MarcasBulkInsertion(SqlConnection sqlcon, DataTable marcasTable)
        {


            if (sqlcon.State == ConnectionState.Closed)
                sqlcon.Open();
            string shine = Getbulk(intSUCURSALID);
            SqlCommand sqlcmd = new SqlCommand(shine, sqlcon);
            // SqlCommand sqlcmd = new SqlCommand("MarcasBulkInsertion", sqlcon);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@marcas4", marcasTable);
            sqlcmd.ExecuteNonQuery();
            sqlcon.Close();



        }
        static string Getbulk(int empresa)
        {
            string conexion;
            switch (empresa)
            {
                case 1:
                    conexion = "ExistenciasBulkInsertion1";
                    return conexion;
                    break;

                case 2:
                    conexion = "ExistenciasBulkInsertion2";
                    return conexion;
                    break;
                case 3:
                    conexion = "ExistenciasBulkInsertion3";
                    return conexion;
                    break;

                case 4:
                    conexion = "MarcasBulkInsertion";
                    return conexion;
                    break;
                case 5:
                    conexion = "ExistenciasBulkInsertion5";
                    return conexion;
                    break;

                case 7:
                    conexion = "ExistenciasBulkInsertion7";
                    return conexion;
                    break;
                case 8:
                    conexion = "ExistenciasBulkInsertion8";
                    return conexion;
                    break;

                case 9:
                    conexion = "ExistenciasBulkInsertion9";
                    return conexion;
                    break;
                case 10:
                    conexion = "ExistenciasBulkInsertion10";
                    return conexion;
                    break;

                case 11:
                    conexion = "ExistenciasBulkInsertion11";
                    return conexion;
                    break;
                case 12:
                    conexion = "ExistenciasBulkInsertion12";
                    return conexion;
                    break;

                case 13:
                    conexion = "ExistenciasBulkInsertion13";
                    return conexion;
                    break;
                case 15:
                    conexion = "ExistenciasBulkInsertion14";
                    return conexion;
                    break;

                case 16:
                    conexion = "ExistenciasBulkInsertion16";
                    return conexion;
                    break;
                case 17:
                    conexion = "ExistenciasBulkInsertion17";
                    return conexion;
                    break;

                case 18:
                    conexion = "ExistenciasBulkInsertion18";
                    return conexion;
                    break;
                default:
                    conexion = "ExistenciasBulkInsertion66";
                    return conexion;
                    break;

            }

        }
        public static string GetSetting(string appName, string section, string key, string sDefault)
        {
            // Los datos de VB se guardan en:
            // HKEY_CURRENT_USER\Software\VB and VBA Program Settings
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\VB and VBA Program Settings\" +
                                                              appName + "\\" + section);
            string s = sDefault;
            if (rk != null)
            {
                s = (string)rk.GetValue(key);
            }
            return s;
        }
    }
}
