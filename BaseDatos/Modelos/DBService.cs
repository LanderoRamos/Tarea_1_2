using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseDatos.Modelos;
using SQLite;
using static SQLite.SQLite3;

namespace BaseDatos.Modelos
{
    public class DBService
    {
        readonly SQLiteAsyncConnection _connection;
       
        public DBService()
        {
            SQLite.SQLiteOpenFlags extensiones = SQLiteOpenFlags.ReadWrite |
                SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

            _connection = new SQLiteAsyncConnection(
                Path.Combine(
                    FileSystem.AppDataDirectory,
                    "DBPerson.db3"), extensiones);

            _connection.CreateTableAsync<Personas>();

            _connection.CreateTableAsync<Autores>();

        }

        //en clases
        public async Task<int> StorePerson(Personas person)
        {
            if (person.Id == 0)
            {
                return await _connection.InsertAsync(person);
            }
            else
            {
                return await _connection.UpdateAsync(person);
            }
        }
        //read
        public async Task<List<Modelos.Personas>> GetPersonas()
        {
            return await _connection.Table<Modelos.Personas>().ToListAsync();
        }
        //read ID
        public async Task<Modelos.Personas> GetPerson(int pid)
        {
            return await _connection.Table<Modelos.Personas>().
               Where(i => i.Id == pid).FirstOrDefaultAsync();
        }
        //delete
        public async Task<int> DeletePersonas(Modelos.Personas person)
        {
            return await _connection.DeleteAsync(person);
        }
        ///////////////////////////////////////////////////////////////////////////
        //tomar foto
        public async Task<int> StoreAutor(Autores autores)
        {
            if (autores.Id == 0)
            {
                Console.WriteLine("Autor insertado: ");
                return await _connection.InsertAsync(autores);
              
            }
            else
            {
                Console.WriteLine("Autor actualizado: " + await _connection.UpdateAsync(autores));
                return await _connection.UpdateAsync(autores);
                
            }
        }
        //read
        public async Task<List<Modelos.Autores>> GetAutores()
        {
            return await _connection.Table<Modelos.Autores>().ToListAsync();
        }
        //read ID
        public async Task<Modelos.Autores> GetAutores(int pid)
        {
            return await _connection.Table<Modelos.Autores>().
               Where(i => i.Id == pid).FirstOrDefaultAsync();
        }
        //delete
        public async Task<int> DeleteAutores(Modelos.Autores autores)
        {
            return await _connection.DeleteAsync(autores);
        }


    }
}
