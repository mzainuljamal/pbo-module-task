using System;
using System.Collections.Generic;

// Perusahaan
class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();
    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
    }
    public void DaftarKaryawan()
    {
        Console.WriteLine("\n=== Daftar Karyawan ===");
        foreach (var k in daftarKaryawan)
        {
            k.InfoKaryawan();
            k.Kerja();
            Console.WriteLine();
        }
    }
}

// Karyawan
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }
    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }
    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja.");
    }
    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");
    }
}

// Karyawan Tetap : turunan class karyawan
class Tetap : Karyawan
{
    public double Tunjangan { get; set; }
    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }
    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Tetap) bekerja dengan stabil.");
    }
}

// Karyawan Kontrak : Turunan class karyawan
class Kontrak : Karyawan
{
    public int Durasi { get; set; }
    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }
    public void CekKontrak()
    {
        Console.WriteLine($"{Nama} kontrak selama {Durasi} bulan.");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Kontrak) bekerja sesuai perjanjian.");
    }
}

// Manager : Turunan class karyawan tetap
class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }
    public void Memimpin()
    {
        Console.WriteLine($"{Nama} sedang memimpin tim.");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Manager) mengatur pekerjaan.");
    }
}

// Staff : Turunan class karyawan tetap
class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }
    public void KerjakanTugas()
    {
        Console.WriteLine($"{Nama} mengerjakan tugas.");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Staff) menjalankan tugas.");
    }
}

// Magang : Turunan class karyawan kontrak
class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }
    public void Belajar()
    {
        Console.WriteLine($"{Nama} sedang belajar.");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Magang) sedang belajar sambil kerja.");
    }
}

// Freelancer : Turunan class karyawan kontrak
class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }
    public void AmbilProyek()
    {
        Console.WriteLine($"{Nama} mengambil proyek.");
    }
    public override void Kerja()
    {
        Console.WriteLine($"{Nama} (Freelancer) bekerja fleksibel.");
    }
}


// Main Program
class Program
{
    static void Main(string[] args)
    {
        Perusahaan perusahaan = new Perusahaan();

        Manager m1 = new Manager("Zainul", 8000000, 2000000);
        Staff s1 = new Staff("Jamal", 5000000, 1000000);
        Magang mg1 = new Magang("Messi", 1000000, 6);
        Freelancer f1 = new Freelancer("Ronaldo", 3000000, 3);

        perusahaan.TambahKaryawan(m1);
        perusahaan.TambahKaryawan(s1);
        perusahaan.TambahKaryawan(mg1);
        perusahaan.TambahKaryawan(f1);

        perusahaan.DaftarKaryawan();

        Console.WriteLine("\n=== Demonstrasi Polymorphism ===");
        Karyawan k2 = new Manager("JE", 9000000, 3000000);
        k2.Kerja();
        Console.WriteLine("Penjelasan: Meskipun variabel bertipe Karyawan, method yang dijalankan adalah versi Manager.");

        Console.WriteLine("\n=== Pemanggilan Method Khusus ===");
        m1.Memimpin();
        s1.KerjakanTugas();
        mg1.Belajar();
        f1.AmbilProyek();
        Console.WriteLine();

        // Menjawab soal 
        Console.WriteLine("=== Jawaban Soal Nomor 1 ===");
        m1.Kerja();
        f1.Kerja();

        Console.WriteLine("\n=== Jawaban Soal Nomor 2 ===");
        m1.Memimpin();

        Console.WriteLine("\n=== Jawaban Soal Nomor 3 ===");
        Console.WriteLine("Informasi Lengkap Manager:");
        Console.WriteLine($"Nama      : {m1.Nama}");
        Console.WriteLine($"Gaji Pokok: {m1.Gaji}");
        Console.WriteLine($"Tunjangan : {m1.Tunjangan}");
        Console.WriteLine($"Total Gaji: {m1.HitungGajiTotal()}");

        Console.WriteLine("\n=== Jawaban Soal Nomor 4 ===");
        mg1.Belajar();

        Console.WriteLine("\n=== Jawaban Soal Nomor 5 ===");
        s1.Kerja();
    }
}