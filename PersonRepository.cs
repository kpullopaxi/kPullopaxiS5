using kPullopaxiS5.Models;
using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace kPullopaxiS5
{
    public class PersonRepository
    {
        string dbPath;
        private SQLiteConnection conn;
        
        public string StatusMessage {  get; set; }


        public void Init() {
            if (conn is not null)
                return;
            conn = new (dbPath);
            conn.CreateTable<Persona>();

        }

        public PersonRepository(string dbPath1) {
            dbPath = dbPath1;
        }
        public void AddNewPerson(string nombre) { 
            int result = 0;

            try
            {
                Init();

                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("Nombre Requerido");
                       Persona persona = new Persona() { Name = nombre};
                result = conn.Insert(persona);
                StatusMessage = string.Format("Filas Agregadas", result, nombre);

            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al insetar", nombre, ex.Message);
            }
        }
        public List<Persona> GetAllPeorle(){
            try
            {
                Init();
                return conn.Table<Persona>().ToList();
            }
            catch (Exception ex)
            {

                StatusMessage = string.Format("Error al mostrar los datos", ex.Message);
            }
            return new List<Persona>();


        }
        public void DeletePerson(int personId)
        {
            try
            {
                Init();
                if (personId <= 0)
                {
                    throw new ArgumentException("ID de persona no válido");
                }

                int result = conn.Delete<Persona>(personId);
                StatusMessage = result > 0 ? "Persona eliminada correctamente" : "No se encontró ninguna persona con ese ID";
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar persona: {0}", ex.Message);
            }
        }

        public void UpdatePerson(int personId, string newNombre)
        {
            try
            {
                Init();
                if (personId <= 0)
                {
                    throw new ArgumentException("ID de persona no válido");
                }

                Persona existingPerson = conn.Find<Persona>(personId);
                if (existingPerson != null)
                {
                    existingPerson.Name = newNombre;
                    int result = conn.Update(existingPerson);
                    StatusMessage = result > 0 ? "Persona actualizada correctamente" : "No se encontró ninguna persona con ese ID";
                }
                else
                {
                    StatusMessage = "No se encontró ninguna persona con ese ID";
                }
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar persona: {0}", ex.Message);
            }
        }

        internal void UpdatePerson(int v, object text)
        {
            throw new NotImplementedException();
        }
    }

}

