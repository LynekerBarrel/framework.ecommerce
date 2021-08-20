using System;

namespace framework.ecommerce.auth.domain.Dto.Base
{
    public class PaginacaoEntradaDto
    {
        public const int QTD_ITEMS_PAGINA = 10;

        public int? Pagina { get; set; } = 1;

        private int? _tamanho = QTD_ITEMS_PAGINA;
        public int? Tamanho
        {
            get { return _tamanho; }
            set
            {
                if (value <= 0)
                    value = QTD_ITEMS_PAGINA;

                _tamanho = value;
            }
        }

        public int Skip() { return QTD_ITEMS_PAGINA * (Pagina.Value - 1); }
        public int Take() { return Tamanho.Value; }
    }

    public class PaginacaoSaidaDto
    {
        public const int QTD_MAX_PAGINACAO = 1000000;

        public PaginacaoSaidaDto(int total, PaginacaoEntradaDto paginacao)
        {
            Total = total;
            PaginaCorrente = paginacao?.Pagina ?? 1;
            PaginaTamanho = paginacao == null || paginacao?.Tamanho == QTD_MAX_PAGINACAO ? Convert.ToInt32(total) : paginacao?.Tamanho;
        }

        public int Total { get; set; }
        public int? TotalPaginas
        {
            get
            {
                if (!PaginaTamanho.HasValue || PaginaTamanho.Value == 0)
                    return null;

                return (int)Math.Ceiling((decimal)Total / (decimal)PaginaTamanho.Value);
            }
        }
        public int? PaginaCorrente { get; }
        public int? PaginaTamanho { get; }
    }
}
