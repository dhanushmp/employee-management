namespace EmployeeManagementSystem.Dto
{
    public class LeaveDto
    {
        public int Serialno { get; set; }
        public string EmployeeId { get; set; }
        public string Type { get; set; }
        public DateTime When { get; set; }
        public string LeaveReason { get; set; }
    }
}
