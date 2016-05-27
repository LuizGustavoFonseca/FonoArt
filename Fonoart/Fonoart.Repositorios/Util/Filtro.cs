namespace Repositorios.Util
{
    public class Filtro<T>
    {
        public virtual string NomeCampo { get; set; }
        public virtual T Valor { get; set; }
    }
}
