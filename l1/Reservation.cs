using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum ReservationStatus
{
    Активно,
    Отменено,
    Завершено
}
public class Reservation
{
    public string CustomerName { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public ReservationStatus Status { get; set; }
    public Reservation(string customerName, DateTime startTime, DateTime endTime)
    {
        CustomerName = customerName;
        StartTime = startTime;
        EndTime = endTime;
        Status = ReservationStatus.Активно;
    }
    public void UpdateStatus(ReservationStatus newStatus)
    {
        Status = newStatus;
    }
}

