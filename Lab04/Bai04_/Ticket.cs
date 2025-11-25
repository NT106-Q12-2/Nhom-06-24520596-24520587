using System;

namespace Bai04_.Models
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public int NumberOfTickets { get; set; }
        public decimal PricePerTicket { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }

        public Ticket()
        {
            TicketId = GenerateTicketId();
            BookingDate = DateTime.Now;
        }

        public void CalculateTotal()
        {
            TotalAmount = NumberOfTickets * PricePerTicket;
        }

        private string GenerateTicketId()
        {
            return "TICK" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }
    }
}