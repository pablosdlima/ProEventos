namespace ProEventos.Persistence
{
    public interface IGeralPersistence
    {
           // os métodos genéricos valem para todas as classes do dominio
            void Add<T>(T entity) where T: class; //Add classe representada por 'T' ("entity" é o objeto de T) where T: é uma classe
            void Update<T>(T entity) where T: class;
            void Delete<T>(T entity) where T: class;
            void DeleteRange<T>(T entity) where T: class;
        // Fim
    }
}