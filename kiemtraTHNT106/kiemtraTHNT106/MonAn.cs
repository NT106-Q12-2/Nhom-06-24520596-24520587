namespace Lab03_bai05
{
    public class MonAn
    {
        public string TenNguoi { get; set; }
        public string TenMon { get; set; }
        public string Hinh { get; set; }

        public override string ToString() => $"{TenNguoi} - {TenMon}";
    }
}
