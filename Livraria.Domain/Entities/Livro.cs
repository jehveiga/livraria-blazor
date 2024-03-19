using Livraria.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Livraria.Domain.Entities
{
    public class Livro
    {
        public Livro(int id, string? titulo, string? autor, DateTime lancamento, string? capa, Editora editora, Categoria categoria)
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Lancamento = lancamento;
            Capa = capa;
            Editora = editora;
            Categoria = categoria;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o título do livro")]
        [StringLength(150, ErrorMessage = "{0} tem que ter menos de {1} caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Informe o título do livro")]
        [StringLength(200, ErrorMessage = "{0} tem que ter menos de {1} caracteres")]
        public string? Autor { get; set; }

        [Required(ErrorMessage = "Informe a data de lançamento")]
        public DateTime Lancamento { get; set; }

        [Required(ErrorMessage = "Informe a imagem da capa")]
        public string? Capa { get; set; }

        [Required]
        [EnumDataType(typeof(Editora), ErrorMessage = "Selecione a editora")]
        public Editora Editora { get; set; }

        [Required]
        [EnumDataType(typeof(Categoria), ErrorMessage = "Selecione a categoria")]
        public Categoria Categoria { get; set; }
    }
}
