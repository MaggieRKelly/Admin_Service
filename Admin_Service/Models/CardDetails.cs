namespace Admin_Service.Models
{
    public class CardDetails
    {
        public int ID { get; set; }
        public long CardNum { get; set; }
        public string ExpDate { get; set; }
        public int CvsNum { get; set; }
       // public bool EditCardPermission { get; set; } 

        public Staff Staff { get; set; }
    }
}
