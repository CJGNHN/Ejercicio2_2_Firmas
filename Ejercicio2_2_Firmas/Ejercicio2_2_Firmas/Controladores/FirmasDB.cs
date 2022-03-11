using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SQLite;
using Ejercicio2_2_Firmas.Modelos;

namespace Ejercicio2_2_Firmas.Controladores
{
    public class FirmasDB
    {
        readonly SQLiteAsyncConnection db;

        // CONSTRUCTOR VACIO
        public FirmasDB()
        {
        }

        // CONSTRUCTOR CON PARAMETROS
        public FirmasDB(String pathbasedatos)
        {
            db = new SQLiteAsyncConnection(pathbasedatos);

            // CREACION DE TABLA
            db.CreateTableAsync<Firmas>();

        }

        // Procedimientos y funciones CRUD

        // Retorna la tabla de firmas como una lista
        public Task<List<Firmas>> ListaFirmas()
        {

            return db.Table<Firmas>().ToListAsync();


        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        // GUARDAR O ACTUALIZAR Firmas
       public Task<Int32> GuardarFirma(Firmas firma)
        {
            if (firma.Codigo != 0)
            {
                return db.UpdateAsync(firma);
            }
            else
            {
                return db.InsertAsync(firma);
            }
        }

        // BUSCAR POR ID
        public Task<Firmas> BuscarFirma(int bcodigo)
        {
            return db.Table<Firmas>()
                .Where(i => i.Codigo == bcodigo)
                .FirstOrDefaultAsync();
        }

        

        // ELIMINAR Firma
        public Task<Int32> EliminarFirma(Firmas firma)
        {
            return db.DeleteAsync(firma);
        }

    }
}
