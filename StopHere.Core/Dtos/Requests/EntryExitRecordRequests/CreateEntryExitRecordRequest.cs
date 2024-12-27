using System.ComponentModel.DataAnnotations;

namespace StopHere.Core.Dtos.Requests.EntryExitRecordRequests;

public class CreateEntryExitRecordRequest : Request
{
    [Required]
    public DateTime EntryDate { get; set; }

    [Required(ErrorMessage = "É necessário o número da vaga")]
    public int Number { get; set; }

    [Required]
    [StringLength(7, MinimumLength = 7, ErrorMessage = "É necessário 7 caracteres")]
    public string LicensePlateValue { get; set; } = string.Empty;
}
