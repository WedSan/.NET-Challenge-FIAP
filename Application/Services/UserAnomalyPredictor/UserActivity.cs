namespace MachineLearning;

public class UserActivity
{
    public int UserId { get; set; }
    public float NumRelatos { get; set; }
    public float NumProcedimentos { get; set; }

    public UserActivity(int userId, float numRelatos, float numProcedimentos)
    {
        UserId = userId;
        NumRelatos = numRelatos;
        NumProcedimentos = numProcedimentos;
    }
}