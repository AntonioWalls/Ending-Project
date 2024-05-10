using Microsoft.EntityFrameworkCore;
using API.Entidades;

namespace API.Comun.Interfaces
{
    public interface IAplicacionBdContexto
    {
        //Una por cada entidad de la base de datos :v
        public DBSET<Rol> Rol {get; set; }
    public DbSet<Usuario> Usuario { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        int SaveChanges();

        Task<int> ExecutarSqlComandoAsync(string comandoSql, CancellationToken cancellationToken)
        Task<int> ExecutarSqlComandoAsync(string comandoSql, IEnumerable<object> parametros, CancellationToken cancellationToken);

        Task EmpezarTransaccionAsync();
        Task MandarTransaccionAsync();

        void CancelarTransaccion();

}
