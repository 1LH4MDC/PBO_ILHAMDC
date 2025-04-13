using System;

class Karyawan
{
    private string nama;
    private string id;
    private double gajiPokok;


    public Karyawan(string nama, string id, double gajiPokok)
    {
        this.nama = nama;
        this.id = id;
        this.gajiPokok = gajiPokok;
    }

    public string GetNama() { return nama; }
    public void SetNama(string value) { nama = value; }

    public string GetID() { return id; }
    public void SetID(string value) { id = value; }

    public double GetGajiPokok() { return gajiPokok; }
    public void SetGajiPokok(double value) { gajiPokok = value; }

    
    public virtual double HitungGaji()
    {
        return gajiPokok;
    }
}

class KaryawanTetap : Karyawan
{
    public KaryawanTetap(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok() + 500000;
    }
}


class KaryawanKontrak : Karyawan
{
    public KaryawanKontrak(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok() - 200000;
    }
}


class KaryawanMagang : Karyawan
{
    public KaryawanMagang(string nama, string id, double gajiPokok)
        : base(nama, id, gajiPokok) { }

    public override double HitungGaji()
    {
        return GetGajiPokok(); 
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Manajemen Karyawan Perusahaan ===");
        Console.WriteLine("Pilih Jenis Karyawan:");
        Console.WriteLine("1. Karyawan Tetap");
        Console.WriteLine("2. Karyawan Kontrak");
        Console.WriteLine("3. Karyawan Magang");
        Console.Write("Masukkan pilihan (1/2/3): ");
        string pilihan = Console.ReadLine();

        Console.Write("\nMasukkan Nama Karyawan: ");
        string nama = Console.ReadLine();

        Console.Write("Masukkan ID Karyawan: ");
        string id = Console.ReadLine();

        double gajiPokok;
        while (true)
        {
            Console.Write("Masukkan Gaji Pokok: Rp. ");
            if (double.TryParse(Console.ReadLine(), out gajiPokok))
                break;
            Console.WriteLine("Input tidak valid! Masukkan angka.");
        }

        Karyawan karyawan = null;

        if (pilihan == "1")
            karyawan = new KaryawanTetap(nama, id, gajiPokok);
        else if (pilihan == "2")
            karyawan = new KaryawanKontrak(nama, id, gajiPokok);
        else if (pilihan == "3")
            karyawan = new KaryawanMagang(nama, id, gajiPokok);
        else
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        Console.WriteLine("\n=== Hasil Akhir ===");
        Console.WriteLine($"Nama Karyawan : {karyawan.GetNama()}");
        Console.WriteLine($"ID Karyawan   : {karyawan.GetID()}");
        Console.WriteLine($"Gaji Akhir    : Rp. {karyawan.HitungGaji():N0}");
    }
}
