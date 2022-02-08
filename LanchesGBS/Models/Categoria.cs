﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesGBS.Models;

[Table("Categorias")]
public class Categoria
{
    [Key]
    public int CategoriaID { get; set; }

    [StringLength(100,ErrorMessage ="O tamanho máximo é {1} caracteres")]
    [Required(ErrorMessage ="Nome da categoria é obrigatório")]
    [Display(Name ="Nome")]
    public string CategoriaNome { get; set; }
    [StringLength(200, ErrorMessage = "O tamanho máximo é {1} caracteres")]
    [Required(ErrorMessage = "Informe Descrição")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; }

    public List<Lanche> Lanches { get; set;}

}

