using System;
using System.Collections.Generic;

namespace Bai04.Models
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
        public List<string> SelectedSeats { get; set; }
        public string EmailStatus { get; set; }

        public Ticket()
        {
            TicketId = GenerateTicketId();
            BookingDate = DateTime.Now;
            SelectedSeats = new List<string>();
            EmailStatus = "Chưa gửi";
        }

        public void CalculateTotal()
        {
            TotalAmount = NumberOfTickets * PricePerTicket;
        }

        private string GenerateTicketId()
        {
            return "TICK" + DateTime.Now.ToString("yyyyMMddHHmmssfff");
        }

        public string GetSeatsInfo()
        {
            if (SelectedSeats == null || SelectedSeats.Count == 0)
            {
                return "Tự động chọn";
            }
            return string.Join(", ", SelectedSeats);
        }
    }
}