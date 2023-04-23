namespace GEscolar.Domain.Filtros
{
    public class FiltroGenerico<T>
    {
        public List<T> Valores { get; set; }
        public int Pagina { get; set; }
        public int QuantidadePorPagina { get; set; }
        public int Total { get; set; }
    }
}
