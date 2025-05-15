using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace l1
{
    public class ReservationManager
    {
        public List<Reservation> Reservations { get; private set; }
        public ReservationManager()
        {
            Reservations = new List<Reservation>();
            LoadReservations();
        }
        public void AddReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            Reservations.Add(reservation);
            SaveReservations();
        }
        public void RemoveReservation(Reservation reservation)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            Reservations.Remove(reservation);
            SaveReservations();
        }
        public void UpdateReservationStatus(Reservation reservation, ReservationStatus
        newStatus)
        {
            if (reservation == null)
            {
                throw new ArgumentNullException(nameof(reservation));
            }
            reservation.UpdateStatus(newStatus);
            SaveReservations();
        }
        private void SaveReservations()
        {
            File.WriteAllLines("reservations.txt", Reservations.Select(r =>
                $"{r.CustomerName}|{r.StartTime.ToString("yyyy-MM-dd HH:mm")}|{r.EndTime.ToString("yyyy-MM-dd HH:mm")}|{(int)r.Status}"));
        }
        private void LoadReservations()
        {
            if (File.Exists("reservations.txt"))
            {
                var lines = File.ReadAllLines("reservations.txt");
                foreach (var line in lines)
                {
                    var parts = line.Split('|');
                    if (parts.Length == 4)
                    {
                        DateTime startTime;
                        DateTime endTime;
                        if (DateTime.TryParse(parts[1], out startTime) && DateTime.TryParse(parts[2], out endTime) && Enum.TryParse(parts[3], out ReservationStatus status))
                        {
                            Reservations.Add(new Reservation(parts[0], startTime, endTime));
                            Reservations.Last().Status = status;
                        }
                    }
                }
            }
        }
    }
}