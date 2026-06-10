using System.ComponentModel.DataAnnotations;

namespace my_dotnet_store.Models;

public class KategoriEditModel
{
    public int Id { get; set; }

    [Display(Name = "Kategori Adı")]
    [Required]
    [StringLength(30)]
    public string KategoriAdi { get; set; } = null!;

    [Display(Name = "Url")]
    [Required]
    [StringLength(30)]
    public string Url { get; set; } = null!;
}