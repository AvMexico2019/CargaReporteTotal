using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// https://www.entityframeworktutorial.net/code-first/simple-code-first-example.aspx

namespace CargaReporteTotal
{
    static public class Program
    {
        static string inputFile = @"D:\Contratos de Arrendamiento Documentos\reporte total\Reporte Total.txt";

        static public Decimal DineroADecimal(string monto)
        {
            if (IsExcelNull(monto))
            {
                return (Decimal)0.0;
            }
            else
            {
                Console.WriteLine("--" + monto);
                monto = monto.Trim('"');
                int pos;
                while ((pos = monto.IndexOf(',')) >= 0)
                {
                    monto = monto.Remove(pos, 1);
                }
                while ((pos = monto.IndexOf('$')) >= 0)
                {
                    monto = monto.Remove(pos, 1);
                }
                Console.WriteLine("--" + monto);
                return Convert.ToDecimal(monto);
            }   
        }

        static public bool IsExcelNull(string valor)
        {
            if (String.IsNullOrEmpty(valor) || valor.Equals("NULL") || String.IsNullOrWhiteSpace(valor)) return true; else return false;
        } 

        static void Main(string[] args)
        {
            Regex rx = new Regex("[0-9]{1,2}[/-]{1}[0-9]{1,2}[/-]{1}[0-9]{2,4}");
            int contratos = 0;
            using (var ctx = new ArrendamientoInmuebleEntities())
            {
                ctx.Database.ExecuteSqlCommand("TRUNCATE TABLE [ReporteTotal]");
                using (var reader = new StreamReader(inputFile, Encoding.GetEncoding("iso-8859-1"), true))
                {
                    var linea = reader.ReadLine(); // leemos los nombres de las columnas
                    Console.WriteLine(linea);
                    while (!reader.EndOfStream)
                    {
                        contratos++;
                        string line = reader.ReadLine();
                        Console.WriteLine("-" + (contratos + 1) + " " + line);
                        string[] values = line.Split('\t');

                        int Id = Int32.Parse(values[0]);
                        int Fk_IdInstitucion = Int32.Parse(values[1]);
                        int No = Int32.Parse(values[2]);
                        int FolioContrato = Int32.Parse(values[3]);
                        int FolioContratoAnterior = Convert.ToInt32(IsExcelNull(values[4]) ? "-1" : values[4]);
                        string TipoContrato = values[5]  ;
                        string TipoOcupacion = values[6] ;
                        string Secuencial = values[7] ;
                        string Propietario = values[8]  ;
                        DateTime FechaDictamen = Convert.ToDateTime(IsExcelNull(values[9]) ? "1-1-1900" : values[9]);
                        string Responsable = values[10] ;
                        string Sector = values[11] ;
                        string Promovente = values[12]  ;
                        int FkIdPais = Int32.Parse(values[13])  ;
                        int Pais = Convert.ToInt32(IsExcelNull(values[14]) ? "-1" : values[14])  ;
                        int Fk_IdEstado = Convert.ToInt32(IsExcelNull(values[15]) ? "-1" : values[15]) ;
                        string Estado = values[16] ;
                        int Fk_IdMunicipio = Convert.ToInt32(IsExcelNull(values[17]) ? "0" : values[17]);
                        string Municipio = values[18] ;
                        int Fk_IdLocalidad = Convert.ToInt32(IsExcelNull(values[19]) ? "0" : values[19]);
                        int RetrieveBusColonia = Convert.ToInt16(values[20]) ;
                        string Colonia = values[21] ;
                        string Calle = values[22] ;
                        string CodigoPostal = values[23] ;
                        string NumInterior = values[24] ;
                        string NumExterior = values[25] ;
                        string Ciudad = values[26] ;
                        decimal  MontoDictaminado = DineroADecimal(values[27])  ;
                        DateTime FechaContratoDesde = Convert.ToDateTime(values[28]) ;
                        DateTime FechaCntratoHasta = Convert.ToDateTime(values[29])  ;
                        int  Fk_IdTipoArrendamiento = Convert.ToInt16(values[30])  ;
                        string DescripcionTipoArrendamiento = values[31]  ;
                        int  Fk_IdTipoInmueble = Convert.ToInt16(values[32])  ;
                        string TipoInmueble = values[33]  ;
                        decimal  MontoPagoPorCajonesEstacionamiento = DineroADecimal(values[34])  ;
                        int  Fk_IdTipoContratacion = Convert.ToInt32(IsExcelNull(values[35]) ? "-1" : values[35]);
                        string DescripcionTipoContratacion = values[36] ;
                        decimal  RentaUnitariaMensual = DineroADecimal(values[37]);
                        decimal  MontoPagoMensual = DineroADecimal(values[38]);
                        decimal  CuotaMantenimiento = DineroADecimal(values[39]);
                        double  AreaOcupadaM2 = Convert.ToDouble(IsExcelNull(values[40]) ? "-1" : values[40]);
                        int  Fk_IdTipoUsoInmueble = Convert.ToInt32(values[41])  ;
                        string TipoUsoInmueble = values[42]  ;
                        string OtroUsoInmueble = values[43]  ;
                        string TablaSMOI = values[44]  ;
                        string ResultadosOpinion = values[45]  ;
                        decimal  MontoAnterior = DineroADecimal(values[46])  ;
                        double  SMOI = Convert.ToDouble(values[47])  ;
                        DateTime Fecha = Convert.ToDateTime(IsExcelNull(values[48]) ? "1-1-1900" : values[48]);
                        string RIUF = values[49]  ;
                        decimal GeoRefLatitud = Convert.ToDecimal(IsExcelNull(values[50]) ? "0.0" : values[50]);
                        decimal GeoRefLongitud = Convert.ToDecimal(IsExcelNull(values[51]) ? "0.0" : values[51]);


                        var reporteTotal = new ReporteTotal()
                        {
                          NumeroSecuencial = contratos,
                          Id = Int32.Parse(values[0]),
                          Fk_IdInstitucion = Int32.Parse(values[1]),
                          No = Int32.Parse(values[2]),
                          FolioContrato = Int32.Parse(values[3]),
                          FolioContratoAnterior = Convert.ToInt32(IsExcelNull(values[4]) ? "-1" : values[4]),
                          TipoContrato = values[5]  ,
                          TipoOcupacion = values[6] ,
                          Secuencial = values[7] ,
                          Propietario = values[8]  ,
                          FechaDictamen = Convert.ToDateTime(IsExcelNull(values[9]) ? "1-1-1900" : values[9]),
                          Responsable = values[10] ,
                          Sector = values[11] ,
                          Promovente = values[12]  ,
                          FkIdPais = Int32.Parse(values[13])  ,
                          Pais = Convert.ToInt32(IsExcelNull(values[14]) ? "-1" : values[14])  ,
                          Fk_IdEstado = Convert.ToInt32(IsExcelNull(values[15]) ? "-1": values[15]) ,
                          Estado = values[16] ,
                          Fk_IdMunicipio = Convert.ToInt32(IsExcelNull(values[17]) ? "0" : values[17]),
                          Municipio = values[18] ,
                          Fk_IdLocalidad = Convert.ToInt32(IsExcelNull(values[19]) ? "0" : values[19]),
                          RetrieveBusColonia = Convert.ToInt16(values[20] ) ,
                          Colonia = values[21] ,
                          Calle = values[22] ,
                          CodigoPostal = values[23] ,
                          NumInterior = values[24] ,
                          NumExterior = values[25] ,
                          Ciudad = values[26] ,
                          MontoDictaminado = DineroADecimal(values[27])  ,
                          FechaContratoDesde = Convert.ToDateTime(values[28] ) ,
                          FechaCntratoHasta = Convert.ToDateTime(values[29])  ,
                          Fk_IdTipoArrendamiento = Convert.ToInt16(values[30])  ,
                          DescripcionTipoArrendamiento = values[31]  ,
                          Fk_IdTipoInmueble = Convert.ToInt16(values[32])  ,
                          TipoInmueble = values[33]  ,
                          MontoPagoPorCajonesEstacionamiento = DineroADecimal(values[34])  ,
                          Fk_IdTipoContratacion = Convert.ToInt32(IsExcelNull(values[35]) ? "-1" : values[35]),
                          DescripcionTipoContratacion = values[36] ,
                          RentaUnitariaMensual = DineroADecimal(values[37]),
                          MontoPagoMensual = DineroADecimal(values[38]),
                          CuotaMantenimiento = DineroADecimal(values[39]),
                          AreaOcupadaM2 = Convert.ToDouble(IsExcelNull(values[40]) ? "-1" : values[40]),
                          Fk_IdTipoUsoInmueble = Convert.ToInt32(values[41])  ,
                          TipoUsoInmueble = values[42]  ,
                          OtroUsoInmueble = values[43]  ,
                          TablaSMOI = values[44]  ,
                          ResultadosOpinion = values[45]  ,
                          MontoAnterior = DineroADecimal(values[46])  ,
                          SMOI = Convert.ToDouble(values[47])  ,
                          Fecha = Convert.ToDateTime(IsExcelNull(values[48]) ? "1-1-1900" : values[48]),
                          RIUF = values[49]  ,
                          GeoRefLatitud = Convert.ToDecimal(IsExcelNull(values[50]) ? "0.0" : values[50]),
                          GeoRefLongitud = Convert.ToDecimal(IsExcelNull(values[51]) ? "0.0" : values[51])
 
                        };
                        ctx.ReporteTotal.Add(reporteTotal);
                        ctx.SaveChanges();
                    }
                }
            }

            Console.WriteLine("Contratos vigentes: " + contratos);
            Console.ReadKey();
        }
    }
}
