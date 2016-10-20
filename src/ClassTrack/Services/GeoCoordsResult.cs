namespace ClassTrack.Services
{
    // This object created to store data obtained using our GeoCoordsService.cs object
    public class GeoCoordsResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}