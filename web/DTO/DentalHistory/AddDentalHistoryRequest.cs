namespace web.DTO.DentalHistory
{
    public record AddDentalHistoryRequest(
        int UserId,
        List<string> Procedures,
        DateTime ConsultationDate,
        string ToothCondition
    );
}
